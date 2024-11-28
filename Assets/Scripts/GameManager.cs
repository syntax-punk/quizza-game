using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndScreen endScreen;

    void Awake()
    {
        quiz = FindFirstObjectByType<Quiz>();
        endScreen = FindFirstObjectByType<EndScreen>();
    }

    void Start()
    {
        quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
    }

    void Update()
    {
        if (quiz.IsComplete)
        {
            quiz.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
            endScreen.DisplayFinalScore();
        }
    }

    public void OnReplayLevel()
    {
        SceneManager
            .LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
