using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 100;
    int _currentHealth;
    [SerializeField] PlayerHealthUI healthBar;

    MoveController _moveController;

    private void Awake()
    {
        _moveController = GetComponent<MoveController>();
    }

    private void Start()
    {
        healthBar.SetMaxHealth(_maxHealth);
    }
}
