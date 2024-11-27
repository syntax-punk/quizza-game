using NUnit.Framework;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int correctAnswers = 0;
    int totalChallenges = 0;

    public int GetCorrectAnswers()
    {
        return correctAnswers;
    }

    public void IncrementCorrectAnswers()
    {
        correctAnswers++;
    }

    public int GetTotalChallenges()
    {
        return totalChallenges;
    }

    public void SetTotalChallenges(int total)
    {
        totalChallenges = total;
    }

    public int GetCalculatedScore()
    {
        var result = (float)correctAnswers / (float)totalChallenges * 100;
        return Mathf.RoundToInt(result);
    }
}
