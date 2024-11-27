using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera dollyCamera;
    public CinemachineVirtualCamera mainCamera; 
    public float dollyDuration = 5f;

    private CinemachineTransposer transposer;
    public Vector3 targetOffset;

    private void Start()
    {
        transposer = dollyCamera.GetCinemachineComponent<CinemachineTransposer>();

        StartCoroutine(SwitchToFollowCamera());

    }
    private void Update()
    {
        if (transposer != null)
        {
            transposer.m_FollowOffset = Vector3.Lerp(
                transposer.m_FollowOffset,
                targetOffset,
                Time.deltaTime * 1f
            );
        }
    }
    private IEnumerator SwitchToFollowCamera()
    {
        dollyCamera.Priority = 10;
        mainCamera.Priority = 0;
        FindObjectOfType<StunamiMovement>().currentSpeed = 0f;
        GameManager.Instance.playerCanMove = false;

        yield return new WaitForSeconds(dollyDuration);

        dollyCamera.Priority = 0;
        mainCamera.Priority = 10;
        FindObjectOfType<StunamiMovement>().currentSpeed = FindObjectOfType<StunamiMovement>().stunamiSpeed;
        GameManager.Instance.playerCanMove = true;

        Debug.Log("Switched to Follow Camera");
    }
}
