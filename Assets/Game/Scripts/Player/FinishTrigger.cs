using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (GameManager.Instance.catCounter == 6)
                GameManager.Instance.GameWon();
            else
                GameManager.Instance.GameFailed();
        }    

    }
}
