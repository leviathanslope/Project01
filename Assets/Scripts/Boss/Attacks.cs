using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public GameObject projectile;
    public GameObject self;
    [SerializeField] ParticleSystem _shootParticles;
    [SerializeField] AudioClip _shootSound;
    public GameObject player;
    public GameObject boss;
    GameObject[] gameObjects;

    private void Update()
    {
        if (this.gameObject.GetComponent<Health>()._currentHealth <= 0)
        {
            gameObjects = GameObject.FindGameObjectsWithTag("Boss");
            foreach (GameObject bosses in gameObjects)
            {
                bosses.GetComponent<Health>().Kill();
            }
        }
        if (this.gameObject.GetComponent<Health>()._currentHealth == 500)
        {
            GameObject newBoss = Instantiate(boss, this.gameObject.transform);
            newBoss.GetComponent<Health>()._currentHealth = 500;
        }
    }
    public void Separate()
    {
    }
    public void Shooting()
    {
        Instantiate(projectile, self.transform.position, Quaternion.identity);
        Vector3 dir = self.transform.forward;
        Vector3 target = (self.transform.position - player.transform.position).normalized;
        projectile.GetComponent<Projectile>().shooter = target;
        Feedback();
    }
    private void Feedback()
    {
        if (_shootParticles != null)
        {
            _shootParticles = Instantiate(_shootParticles, self.transform.position, Quaternion.identity);
        }

        if (_shootSound != null)
        {
            AudioHelper.PlayClip2D(_shootSound, 1f);
        }
    }
}
