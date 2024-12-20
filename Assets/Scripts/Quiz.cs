using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]

    [SerializeField]
    TextMeshProUGUI ChallengeText;

    [SerializeField]
    List<QuestionSO> Challenges = new();
    QuestionSO CurrentChallenge;

    [Header("Answers")]
    bool HasAnsweredEarly = true;

    [SerializeField]
    GameObject[] AnswerButtons;

    [Header("Button Colors")]

    [SerializeField]
    Sprite DefaultButtonSprite;

    [SerializeField]
    Sprite SuccessButtonSprite;

    [Header("Timer")]

    [SerializeField]
    Image TimerImage;

    Timer timer;

    [Header("Scoring")]

    [SerializeField]
    TextMeshProUGUI ScoreText;

    ScoreKeeper scoreKeeper;

    [Header("Progress Bar")]

    [SerializeField]
    Slider progressBar;

    public bool IsComplete { get; set; }

    void Awake()
    {
        timer = FindFirstObjectByType<Timer>();
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        scoreKeeper.SetTotalChallenges(Challenges.Count);
        progressBar.maxValue = Challenges.Count;
        progressBar.value = 0;
    }

    void Update()
    {
        TimerImage.fillAmount = timer.TimerImageFillFraction;

        if (timer.LoadNextQuestion)
        {

            if (progressBar.value == progressBar.maxValue)
            {
                IsComplete = true;
                return;
            }

            HasAnsweredEarly = false;
            GetNextChallenge();
            timer.LoadNextQuestion = false;
        }
        else if (!HasAnsweredEarly && !timer.IsAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonsState(false);
        }
    }

    public void OnAnswerSelected(int index)
    {
        DisplayAnswer(index);

        HasAnsweredEarly = true;
        SetButtonsState(false);
        timer.CancelTimer();

        ScoreText.text = "Score: " + scoreKeeper.GetCalculatedScore() + "%";
    }

    private void DisplayAnswer(int index)
    {
        Image buttonImage;
        var correctAnswerIndex = CurrentChallenge.GetCorrectAnswerIndex();

        if (index == correctAnswerIndex)
        {
            ChallengeText.text = "Correct!";
            buttonImage = AnswerButtons[index]
                .GetComponent<Image>();

            buttonImage.sprite = SuccessButtonSprite;
            scoreKeeper.IncrementCorrectAnswers();
        }
        else
        {
            var correctAnswer = CurrentChallenge.GetAnswer(correctAnswerIndex);
            ChallengeText.text = "Opps! Correct answer is: \n" + correctAnswer;

            buttonImage = AnswerButtons[correctAnswerIndex]
                .GetComponent<Image>();
            buttonImage.sprite = SuccessButtonSprite;
        }
    }

    private void DisplayQuestion()
    {
        ChallengeText.text = CurrentChallenge.GetChallenge();

        for (int i = 0; i < AnswerButtons.Length; i++)
        {
            var buttonText = AnswerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = CurrentChallenge.GetAnswer(i);
        }
    }

    private void GetRandomChallenge()
    {
        var index = Random.Range(0, Challenges.Count);
        CurrentChallenge = Challenges[index];

        if (Challenges.Contains(CurrentChallenge))
        {
            Challenges.Remove(CurrentChallenge);
        }
    }

    private void SetButtonsState(bool state)
    {
        foreach (var button in AnswerButtons)
        {
            button.GetComponent<Button>().interactable = state;
        }
    }

    private void SetDefaultButtonSprites()
    {
        foreach (var button in AnswerButtons)
        {
            button.GetComponent<Image>().sprite = DefaultButtonSprite;
        }
    }

    private void GetNextChallenge()
    {
        if (Challenges.Count == 0)
            return;

        SetButtonsState(true);
        SetDefaultButtonSprites();
        GetRandomChallenge();
        DisplayQuestion();
        progressBar.value++;
    }
}
