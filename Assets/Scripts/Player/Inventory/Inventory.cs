using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    int _iceAmmo;
    public GameObject[] ammoTypes;
    int _currentAmmoType;
    GameObject shooter;

    [SerializeField] TMP_Text ammoUpdate;

    public void Awake()
    {
        _iceAmmo = 10;
        ammoUpdate.text = "Regular Spells: Infinite";
        _currentAmmoType = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q))
        {
            if (_currentAmmoType == 0)
            {
                _currentAmmoType = 1;
                ammoUpdate.text = "Ice Spells: " + _iceAmmo;
                shooter.GetComponent<PlayerSpells>().projectile = ammoTypes[1];
            } else
            {
                _currentAmmoType = 0;
            }
        }
    }
}
