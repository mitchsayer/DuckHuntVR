using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractGUN : MonoBehaviour
{
    public GameObject Hand, Gun;
    private bool hasGun;
    PlayerController controls;

    void Awake()
    {
        hasGun = false;
        controls = new PlayerController();
        controls.Gameplay.PickUp.performed += ctx => PickupGun();
    }

    public void PickupGun()
    {
        Gun.transform.parent = Hand.transform;
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
