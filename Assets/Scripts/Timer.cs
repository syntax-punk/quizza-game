using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    float TimeToAnswer = 30f;

    [SerializeField]
    float TimeToDisplayAnswer = 10f;

    public bool IsAnsweringQuestion = false;

    float timerValue;

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (IsAnsweringQuestion)
        {
            if (timerValue <= 0)
            {
                timerValue = TimeToDisplayAnswer;
                IsAnsweringQuestion = false;
            }
        }
        else
        {
            if (timerValue <= 0)
            {
                timerValue = TimeToAnswer;
                IsAnsweringQuestion = true;
            }
        }
    }
}
