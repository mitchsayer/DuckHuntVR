using UnityEngine;
using UnityEngine.UI;

public class Duck : MonoBehaviour
{
    public Text Score;
    public int Points = 10;

    public void RollDice ()
    {
        Universe.Instance.Score += Points;

        Score.text = Universe.Instance.Score.ToString();
    }

    public void Die()
    {
        this.gameObject.SetActive(false);
    }
}
