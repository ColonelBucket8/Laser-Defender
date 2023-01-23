using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private int scoreIncrement = 100;
    private int currentScore;


    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void SetCurrentScore(int score)
    {
        currentScore = score;
    }

    public void ModifyScore(int value)
    {
        currentScore += value;
        Mathf.Clamp(currentScore, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        currentScore = 0;
    }
}