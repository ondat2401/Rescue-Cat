using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderSetting : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject ON;
    [SerializeField] private GameObject OFF;

    [SerializeField] AudioSource audioSource;
    private bool isTurning;

    private void OnEnable()
    {
        anim.SetBool("Turn", isTurning);
    }
    private void Start()
    {
        anim.updateMode = AnimatorUpdateMode.UnscaledTime;
    }
    public void OnClicked()
    {
        if (!isTurning)
        {
            ON.SetActive(false);
            OFF.SetActive(true);
            audioSource.volume = 0;
        }
        else
        {
            ON.SetActive(true);
            OFF.SetActive(false);
            audioSource.volume = 1;
        }
        isTurning =!isTurning;
        anim.SetBool("Turn", isTurning);
    } 
}
