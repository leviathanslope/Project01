using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpells : MonoBehaviour
{
    public GameObject projectile;
    public GameObject self;

    public void Shoot(GameObject prefab, Transform direction) {
        Instantiate(prefab, transform.position, Quaternion.identity);
        Vector3 dir = direction.forward;
        prefab.GetComponent<Projectile>().shooter = dir;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(projectile, self.transform);
        }
    }
}
