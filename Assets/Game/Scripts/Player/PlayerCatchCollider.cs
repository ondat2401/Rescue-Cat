using UnityEngine;

public class PlayerCatchCollider : MonoBehaviour
{
    PlayerCatchController catchController;
    private void Start()
    {
        catchController = FindAnyObjectByType<PlayerCatchController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "cat")
        {
            catchController.isCatching = true;
            other.GetComponent<CatMovement>().isRunning = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "cat")
        {
            if (catchController.slider.value >= .7f)
            {
                FindAnyObjectByType<PlayerCatching>().CatCaught(other.gameObject);
                catchController.ResetSlider();

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "cat")
        {
            catchController.isCatching = false;
            other.GetComponent<CatMovement>().ChooseRandomDirection();

        }
    }
}
