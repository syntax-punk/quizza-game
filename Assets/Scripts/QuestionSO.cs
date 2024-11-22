using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Challenge", fileName = "New Challenge")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField]
    string Challenge = "Enter your question here";

    [SerializeField]
    string[] Answers = new string[4];

    [SerializeField]
    int CorrectAnswerIndex;

    public string GetChallenge()
    {
        return Challenge;
    }

    public string GetAnswer(int index)
    {
        return Answers[index];
    }

    public int GetCorrectAnswerIndex()
    {
        return CorrectAnswerIndex;
    }
}
