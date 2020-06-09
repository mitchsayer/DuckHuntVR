using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunSHOOT : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public GameObject HG;
    public GameObject bRay;
    public Camera fpsCam;
    public GameObject impactEffect;
    PlayerController controls;
    
    void Awake()
    {
        controls = new PlayerController();
        bRay.SetActive(false);
        controls.Gameplay.Shoot.performed += ctx => Shoot();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
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

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            if (hit.rigidbody != null)
            {
                //hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }

}
