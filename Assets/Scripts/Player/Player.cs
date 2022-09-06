using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 100;
    int _currentHealth;

    MoveController _moveController;

    private void Awake()
    {
        _moveController = GetComponent<MoveController>();
    }
}
