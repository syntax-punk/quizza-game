using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI ChallengeText;

    [SerializeField]
    QuestionSO Challenge;

    [SerializeField]
    GameObject[] AnswerButtons;

    [SerializeField]
    Sprite DefaultButtonSprite;

    [SerializeField]
    Sprite SuccessButtonSprite;

    void Start()
    {
        ChallengeText.text = Challenge.GetChallenge();

        for (int i = 0; i < AnswerButtons.Length; i++)
        {
            var buttonText = AnswerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = Challenge.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index)
    {
        Image buttonImage;
        var correctAnswerIndex = Challenge.GetCorrectAnswerIndex();

        if (index == correctAnswerIndex)
        {
            ChallengeText.text = "Correct!";
            buttonImage = AnswerButtons[index]
                .GetComponent<Image>();

            buttonImage.sprite = SuccessButtonSprite;
        }
        else
        {
            var correctAnswer = Challenge.GetAnswer(correctAnswerIndex);
            ChallengeText.text = "Opps! Correct answer is: \n" + correctAnswer;

            buttonImage = AnswerButtons[correctAnswerIndex]
                .GetComponent<Image>();
            buttonImage.sprite = SuccessButtonSprite;
        }
    }
}
