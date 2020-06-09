using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoyCon : MonoBehaviour
{
    public GameObject Duck;
    public GameObject GunPU;
    public GameObject HiddenGun;
    //public GameObject bullet;
    PlayerController controls;

    void Awake()
    {
        GunPU.SetActive(true);
        HiddenGun.SetActive(false);

        controls = new PlayerController();

        controls.Gameplay.Shoot.performed += ctx => Shoot();
        controls.Gameplay.PickUp.performed += ctx => PickUp();

    }
    void Shoot()
    {
        
        
    }

    void PickUp()
    {
        GunPU.SetActive(false);
        HiddenGun.SetActive(true);
    }
    void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}