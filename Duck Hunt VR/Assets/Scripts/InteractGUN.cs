using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractGUN : MonoBehaviour
{
    public GameObject HG;
    public GameObject SG;
    public bool hgIsActive;

    void Awake()
    {
        HG.SetActive(false);
        hgIsActive = false;
        SG.SetActive(true);
    }
    public void PickupGun()
    {
        HG.SetActive(true);
        hgIsActive = true;
        SG.SetActive(false);
        Universe.Instance.HasGun = true;
    }

    public void PutdownGun()
    {
        HG.SetActive(false);
        hgIsActive = false;
        SG.SetActive(true);
    }
}
