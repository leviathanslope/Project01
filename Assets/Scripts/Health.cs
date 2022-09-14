using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] int _health;
    int _currentHealth;

    private void Awake()
    {
        _currentHealth = _health;
    }
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Kill();
        }
    }
    public void Kill()
    {
        Destroy(this.gameObject);
    }
}
