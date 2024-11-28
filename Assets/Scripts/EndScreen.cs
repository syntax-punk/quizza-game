using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI finalScoreText;

    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }

    public void DisplayFinalScore()
    {
        finalScoreText.text = $"Congratulations!\n You scored {scoreKeeper.GetCalculatedScore()}%";
    }
}
