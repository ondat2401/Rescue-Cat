using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunamiMovement : MonoBehaviour
{
    [HideInInspector] public float currentSpeed;
    [HideInInspector] public float stunamiSpeed;
    [SerializeField] float currentDistance = 0;
    private void Start()
    {
        stunamiSpeed = GameManager.Instance.stunamiSpeed;
    }
    private void Update()
    {
        float distanceThisFrame = currentSpeed * Time.deltaTime;

        transform.Translate(0, 0, distanceThisFrame);

        currentDistance += distanceThisFrame;

        Debug.Log($"Stunami Distance: {currentDistance:F2} meters");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.Instance.GameFailed();
        }
    }
}

