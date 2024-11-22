using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Challenge", fileName = "New Challenge")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField]
    string Challenge = "Enter your question here";

    public string GetChallenge()
    {
        return Challenge;
    }

}
