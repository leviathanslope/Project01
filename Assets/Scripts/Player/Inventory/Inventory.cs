using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    int _iceAmmo;
    public int[] ammoTypes = { 0, 1 };
    int _currentAmmoType;

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

            }
        }
    }
}
