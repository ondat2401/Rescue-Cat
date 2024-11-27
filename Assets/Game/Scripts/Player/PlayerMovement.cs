using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Joystick joystickMovement;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] float gravity = -9.81f;

    private CharacterController controller;
    private Animator anim;
    private Vector3 velocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if(GameManager.Instance.playerCanMove)
        {
            AnimationUpdate();
            MovePlayer();
        }    
    }

    private void AnimationUpdate()
    {
        float movement = joystickMovement.Direction.magnitude;

        anim.SetFloat("Movement Multiplier", movement);

        anim.SetBool("Run", movement > 0);
    }

    private void MovePlayer()
    {
        Vector2 directionInput = joystickMovement.Direction;
        Vector3 direction = new Vector3(directionInput.x, 0, directionInput.y);

        if (direction.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            Vector3 move = direction.normalized * GameManager.Instance.playerSpeed;
            controller.Move(move * Time.deltaTime);
        }

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
