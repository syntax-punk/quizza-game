using TMPro;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI ChallengeText;

    [SerializeField]
    QuestionSO Challenge;

    void Start()
    {
        ChallengeText.text = Challenge.GetChallenge();
    }
}
