using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int _iceAmmo;
    public GameObject[] ammoTypes;
    public int _currentAmmoType;
    [SerializeField] GameObject shooter;

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
                shooter.GetComponent<PlayerSpells>().projectile = ammoTypes[_currentAmmoType];
            } else
            {
                _currentAmmoType = 0;
                ammoUpdate.text = "Regular Spells: Infinite";
                shooter.GetComponent<PlayerSpells>().projectile = ammoTypes[_currentAmmoType];
            }
        }
        if (_currentAmmoType == 1)
        {
            ammoUpdate.text = "Ice Spells: " + _iceAmmo;
        }
    }
}
