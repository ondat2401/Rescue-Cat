using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCatching : MonoBehaviour
{
    private List<GameObject> orangeCatList = new List<GameObject>();
    private List<GameObject> blackCatList = new List<GameObject>();
    public void CatCaught(GameObject _cat)
    {
        FindObjectOfType<AudioManager>().PlaySFX(FindObjectOfType<AudioManager>().caught);
        GameManager.Instance.catCounter += 1;
        _cat.GetComponent<Collider>().enabled = false;


        CatMovement _catScript = _cat.GetComponent<CatMovement>();
        _catScript.isCaught = true;

        _cat.transform.parent = transform;
        _cat.transform.localEulerAngles = Vector3.zero;

        if (_cat.name == "Cat(Clone)")
            OrangeCat(_cat);
        else
            BlackCat(_cat);

        Transform particle = _cat.transform.Find("particle");
        if( particle != null )
            particle.gameObject.SetActive(false);
    }
    private void BlackCat(GameObject _cat)
    {
        blackCatList.Add(_cat);

        Vector3 newPos;
        newPos = new Vector3(0, 0, -8 * (blackCatList.Count));

        _cat.transform.localPosition = newPos;
    }
    private void OrangeCat(GameObject _cat)
    {
        orangeCatList.Add(_cat);

        _cat.GetComponentInChildren<Animator>().SetBool("Idle", true);

        Vector3 newPos;
        if (orangeCatList.Count <= 1)
            newPos = new Vector3(0, 16, 0);
        else
            newPos = new Vector3(0, 16 + 6 * (orangeCatList.Count - 1), 1);

        _cat.transform.localPosition = newPos;
    }
}