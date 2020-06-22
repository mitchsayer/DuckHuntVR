using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractGUN : MonoBehaviour
{
    public GameObject HandPos, Gun, Hand;
    private bool hasGun;
    PlayerController2 controls;

    void Awake()
    {
        hasGun = false;
        controls = new PlayerController2();
        controls.Gameplay.PickUp.performed += ctx => PickupGun();
    }

    public void PickupGun()
    {
        Gun.transform.parent = HandPos.transform;
        Hand.transform.localRotation = new Quaternion(0, 90, 0, 0);
        Gun.transform.localPosition = new Vector3(0, 0, 0);
        Gun.transform.rotation = new Quaternion(0, 0, 0, 0);
        Gun.transform.localScale = new Vector3(1, 1, 1);

        hasGun = true;
        Universe.Instance.HasGun = hasGun;
        Universe.Instance.GameState = 1;
    }

    //public void PutdownGun()
    //{
    //    HG.SetActive(false);
    //    hgIsActive = false;
    //    SG.SetActive(true);
    //}
}
