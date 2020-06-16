using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunSHOOT : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public GameObject Gun;
    public GameObject bRay;
    public Camera fpsCam;
    public float impactForce = 100f;
    public GameObject impactEffect;
    public ParticleSystem muzzleFlash;
    PlayerController controls;
    
    void Awake()
    {
        controls = new PlayerController();
        bRay.SetActive(false);
        controls.Gameplay.Shoot.performed += ctx => Shoot();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Universe.Instance.HasGun)
        {
            Shoot();
            bRay.SetActive(true);
        }
        if(Input.GetButtonUp("Fire1"))
        {
            bRay.SetActive(false);
        }

    }
    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            DuckScript target = hit.transform.GetComponent<DuckScript>();

            if (target != null)
            {
                target.TakeDamage();
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.isKinematic = false;
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }

}
