using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int weaponCurrent = 0;
    void Start() 
    {
        SetWeaponAction();
    }
     void Update() 
    {
        int previousWeapon = weaponCurrent;
        processKeyInput();
        processScrollWheel();
        if(previousWeapon != weaponCurrent)
        {
            SetWeaponAction();
        }
    }

    private void processScrollWheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(weaponCurrent >= transform.childCount - 1)
            {
                weaponCurrent = 0;
            }
            else
            {
                weaponCurrent++;
            }

        }
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(weaponCurrent <=0 )
            {
                weaponCurrent = transform.childCount -1;
            }
            else
            {
                weaponCurrent--;
            }
        }
    }

    private void processKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponCurrent = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponCurrent = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponCurrent = 2;
        }
    }

    private void SetWeaponAction()
    {
        int weaponIndex = 0;
        foreach(Transform weapon in transform)
        {
            if(weaponIndex == weaponCurrent)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }
}
