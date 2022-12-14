using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpells : MonoBehaviour
{
    public GameObject projectile;
    public GameObject self;
    public GameObject inventory;

    [SerializeField] ParticleSystem _shootParticles;
    [SerializeField] AudioClip _shootSound;

    public void Shoot(GameObject prefab, Transform direction) {
        Instantiate(prefab, transform.position, Quaternion.identity);
        Vector3 dir = direction.forward;
        prefab.GetComponent<Projectile>().shooter = dir;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (inventory.GetComponent<Inventory>()._currentAmmoType == 1)
            {
                if (inventory.GetComponent<Inventory>()._iceAmmo <= 0)
                {
                    return;
                } else
                {
                    inventory.GetComponent<Inventory>()._iceAmmo -= 1;
                }
            }
            Shoot(projectile, self.transform);
            Feedback();
        }
    }

    private void Feedback()
    {
        if (_shootParticles != null)
        {
            _shootParticles = Instantiate(_shootParticles, transform.position, Quaternion.identity);
        }

        if (_shootSound != null)
        {
            AudioHelper.PlayClip2D(_shootSound, 1f);
        }
    }
}
