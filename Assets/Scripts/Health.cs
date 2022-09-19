using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] int _health;
    [SerializeField] int _currentHealth;
    [SerializeField] GameObject art;

    private void Awake()
    {
        _currentHealth = _health;
    }
    public void TakeDamage(int damage)
    {
        DamageFeedback();
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

    public void DamageFeedback()
    {
        StartCoroutine(collideFlash());
    }

    IEnumerator collideFlash()
    {
        Color32 c = art.GetComponent<MeshRenderer>().material.color;
        art.GetComponent<MeshRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        art.GetComponent<MeshRenderer>().material.color = c;
    }

    public void KillFeedback()
    {

    }
}
