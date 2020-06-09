using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckManager : MonoBehaviour
{
    public Transform m_duckManagerObject;

    private List<GameObject> m_duckList;

    // Start is called before the first frame update
    void Start()
    {
        m_duckList = new List<GameObject>();

        foreach (Transform duck in m_duckManagerObject)
        {
            m_duckList.Add(duck.gameObject);
        }
    }

    public void DeleteDucks()
    {
        foreach (GameObject duck in m_duckList)
        {
            Duck d = duck.GetComponent<Duck>();
            d.Die();
        }
    }
}
