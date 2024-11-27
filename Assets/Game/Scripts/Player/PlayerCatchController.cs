using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCatchController : MonoBehaviour
{
    [SerializeField] private float catchSpeed;

    public Slider slider;
    public bool isCatching = false;
    private void Update()
    {
        SliderUpdate();
    }

    private void SliderUpdate()
    {
        slider.value += isCatching ? catchSpeed * Time.deltaTime : -catchSpeed * Time.deltaTime;

        slider.value = Mathf.Clamp(slider.value, 0, slider.maxValue);

        slider.gameObject.SetActive(slider.value > 0);
    }

    public void ResetSlider()
    {
        slider.value = 0;
        isCatching = false;
    }
}
