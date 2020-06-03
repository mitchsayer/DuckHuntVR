using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject duck;
    public void shoot()
    {
        Object.Destroy(duck);
    }

}
