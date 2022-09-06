using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpells : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;

    public void Shoot(GameObject prefab) {
        GameObject shoot = Instantiate(prefab, transform.position, Quaternion.identity);
        Vector3 shootDir = transform.position;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(projectile);
        }
    }
}
