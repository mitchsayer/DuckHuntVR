using UnityEngine;
using UnityEngine.UI;

public class Duck : MonoBehaviour
{
    public Text Score;
    public int Points = 10;
    private bool hgIsActive;


    public void RollDice ()
    {
        print(this.name);

        hgIsActive = Universe.Instance.HasGun;

        if (hgIsActive)
        {
            Universe.Instance.Score += Points;

            Score.text = Universe.Instance.Score.ToString();
        }
        //Universe.Instance.Score += Points;

        //Score.text = Universe.Instance.Score.ToString();
    }

    public void Die()
    {
        this.gameObject.SetActive(false);
    }
}
