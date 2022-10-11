using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] Slider _slider;
    [SerializeField] CameraShake cameraShaker;
    [SerializeField] GameObject redScreen;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (redScreen != null)
        {
            if (redScreen.GetComponent<Image>().color.a > 0)
            {
                var color = redScreen.GetComponent<Image>().color;
                color.a -= 0.1f;
                redScreen.GetComponent<Image>().color = color;
            }
        }
    }

    private void OnEnable()
    {
        _player.GetComponent<Health>().UIUpdated += OnTookDamage;
    }

    private void OnDisable()
    {
        _player.GetComponent<Health>().UIUpdated -= OnTookDamage;
    }

    void OnTookDamage(int healthValue)
    {
        _slider.value = healthValue;
        RedScreen();
        if (cameraShaker != null)
        {
            StartCoroutine(cameraShaker.Shake(0.15f, 0.4f));
        }
    }

    public void RedScreen()
    {
        if (redScreen != null)
        {
            var color = redScreen.GetComponent<Image>().color;
            color.a = 0.5f;
            redScreen.GetComponent<Image>().color = color;
        }
    }

    public void SetMaxHealth(int health)
    {
        _slider.maxValue = health;
        _slider.value = health;
    }

    public void SetHealth(int health)
    {
        _slider.value = health;
    }
}
