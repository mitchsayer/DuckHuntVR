using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractGUN : MonoBehaviour
{
    public GameObject HG;
    public GameObject SG;

    void Awake()
    {
        HG.SetActive(false);
        SG.SetActive(true);
    }
    public void PickupGun()
    {
        HG.SetActive(true);
        SG.SetActive(false);
    }

    public void PutdownGun()
    {
        HG.SetActive(false);
        SG.SetActive(true);
    }
}
