using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoyCon : MonoBehaviour
{
    public GameObject Duck;
    public GameObject Gun;
    //public GameObject bullet;
    PlayerController2 controls;

    void Awake()
    {
        controls = new PlayerController2();

        //controls.Gameplay.Shoot.performed += ctx => Shoot();
        controls.Gameplay.PickUp.performed += ctx => PickUp();

    }

    void PickUp()
    {
       // GunPU.SetActive(false);
        //HiddenGun.SetActive(true);
    }
    void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    //void OnDisable()
    //{
    //    controls.Gameplay.Disable();
    //}
}