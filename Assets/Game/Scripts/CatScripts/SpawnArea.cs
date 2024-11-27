using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    [SerializeField] private List<GameObject> catPrefabs = new List<GameObject>();

    public void SpawnCat(Transform transform)
    {
        GameObject cat = Instantiate(catPrefabs[Random.Range(0,2)], transform.position,Quaternion.identity,transform);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 20f);
    }
}
