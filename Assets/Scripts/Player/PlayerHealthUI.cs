using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] Slider _slider;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        _player.GetComponent<Health>().UIUpdated += OnTookDamage;
    }

    private void OnDisable()
    {
        _player.GetComponent<Health>().UIUpdated -= OnTookDamage;
    }

    void OnTookDamage(int damage)
    {
        _slider.value -= damage;
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
