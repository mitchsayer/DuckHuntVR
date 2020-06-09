using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSHOOT : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public GameObject HG;
    public GameObject bRay;
    public Camera fpsCam;

    void Awake()
    {
        bRay.SetActive(false);

    }
    void Update()
    {
        if (Input.GetButtonDown("Mouse0"))
        {
            Shoot();
            bRay.SetActive(true);
        }
        if(Input.GetButtonUp("Mouse0"))
        {
            bRay.SetActive(false);
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
            }
        }
    }

}
