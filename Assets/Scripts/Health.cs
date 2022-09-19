using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] int _health;
    [SerializeField] int _currentHealth;
    [SerializeField] GameObject art;
    [SerializeField] AudioClip _damageSound;
    [SerializeField] ParticleSystem _killParticles;
    [SerializeField] AudioClip _killSound;

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
        KillFeedback();
        Destroy(this.gameObject);
    }

    public void DamageFeedback()
    {
        if (_damageSound != null)
        {
            AudioHelper.PlayClip2D(_damageSound, 1f);
        }
        StartCoroutine(collideFlash());
    }

    IEnumerator collideFlash()
    {
        Color32 c = art.GetComponent<MeshRenderer>().material.color;
        art.GetComponent<MeshRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        art.GetComponent<MeshRenderer>().material.color = Color.white;
    }

    public void KillFeedback()
    {
        if (_killParticles != null)
        {
            _killParticles = Instantiate(_killParticles, transform.position, Quaternion.identity);
        }

        if (_killSound != null)
        {
            AudioHelper.PlayClip2D(_killSound, 1f);
        }
    }
}
