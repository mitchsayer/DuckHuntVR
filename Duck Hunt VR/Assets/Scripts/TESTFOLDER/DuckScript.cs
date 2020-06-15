using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckScript : MonoBehaviour
{
    public float score;

    public float speed = 0;

    public Transform destinationPos;
    public float despawnDistance;

    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        float destDistance = (destinationPos.position - transform.position).magnitude;
        if (destDistance < despawnDistance)
        {
            Destroy(gameObject);
        }
    }

    public void Move()
    {
        if (destinationPos)
        {
            Vector3 moveDir = (destinationPos.position - transform.position).normalized;
            transform.position += moveDir * speed * Time.deltaTime;
        } 
    }

    public bool TakeDamage()
    {
        if(!isDead)
        {
            Universe.Instance.Score += (int)score;
        }
        return !isDead;
    }

    
}
