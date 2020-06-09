using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckKill : MonoBehaviour
{
    public GameObject Duck;

    public void Kill()
    {
        Object.Destroy(Duck);
    }
}
