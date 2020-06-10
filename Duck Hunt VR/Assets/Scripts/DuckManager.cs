using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckManager : MonoBehaviour
{
    public Transform m_duckManagerObject;

    private List<Duck> m_duckList;
    public float speed;
    public Transform originPos;
    public Transform destPos;

    // Start is called before the first frame update
    void Start()
    {
        m_duckList = new List<Duck>();

        foreach (Transform duck in m_duckManagerObject)
        {
            m_duckList.Add(duck.gameObject.GetComponent<Duck>());
        }

        foreach (Duck duck in m_duckList)
        {
            if (duck == null)
            {
                m_duckList.Remove(duck);
            }
        }
    }

    private void Update()
    {
        MoveDucks();
    }

    public void DeleteDucks()
    {
        foreach (Duck duck in m_duckList)
        {
            duck.gameObject.SetActive(false);
        }
    }

    public void MoveDucks()
    {
        foreach (Duck duck in m_duckList)
        {
            if ( duck != null)
                duck.Move(speed, originPos, destPos);
        }
    }
}
