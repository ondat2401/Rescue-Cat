using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuTouchScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Animator anim;
    private CinemachineImpulseSource impulseSource;
    private float playerSpeed;
    private void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
        anim = player.GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        playerSpeed = Mathf.Max(0, playerSpeed - Time.deltaTime);
        anim.SetBool("Run", playerSpeed > 0);
        anim.SetFloat("Movement Multiplier", playerSpeed);

        if(playerSpeed > 0 )
            PlayerMovement();
    }
    private void PlayerMovement()
    {
        player.transform.Translate(Vector3.forward * playerSpeed * 15 * Time.deltaTime);
    }
    public void OnTouch()
    {
        if(playerSpeed <= 10)
            playerSpeed += .5f;
        impulseSource.GenerateImpulse();
        GameManager.Instance.allCoin += 20;
    }
}
