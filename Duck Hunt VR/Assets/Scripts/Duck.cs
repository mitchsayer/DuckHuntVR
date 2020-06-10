using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Duck : MonoBehaviour
{
    public Text Score;
    public int Points = 10;
    public float Health = 50;
    private bool hasGun;
    public float delay = 1;

    void Awake()
    {
        hasGun = false;
        transform.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void Shoot (float damage)
    {
        hasGun = Universe.Instance.HasGun;

        if (hasGun)
        {
            TakeDamage(damage);
        }
    }

    public void Move(float speed, Transform originPos, Transform destPos)
    {
        if (transform.localPosition.x < destPos.localPosition.x)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = originPos.localPosition;
            transform.rotation = originPos.rotation;
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        CollectPoints();
        IsDead();
    }

    public void CollectPoints()
    {
        Universe.Instance.Score += Points;
        Score.text = Universe.Instance.Score.ToString();
    }

    public void IsDead()
    {
        if (Health <= 0)
        {
            StartCoroutine(Die());
        }  
    }

    public IEnumerator Die()
    {
        yield return new WaitForSeconds(delay);
        this.gameObject.SetActive(false);
    }
}
