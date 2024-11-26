using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    float TimeToAnswer = 30f;

    [SerializeField]
    float TimeToDisplayAnswer = 10f;

    public bool IsAnsweringQuestion = false;

    public bool LoadNextQuestion = true;

    public float TimerImageFillFraction;

    private float _timerValue;

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        _timerValue = 0;
    }

    private void UpdateTimer()
    {
        _timerValue -= Time.deltaTime;

        if (IsAnsweringQuestion)
        {
            if (_timerValue > 0)
            {
                TimerImageFillFraction = _timerValue / TimeToAnswer;
            }
            else
            {
                _timerValue = TimeToDisplayAnswer;
                IsAnsweringQuestion = false;
            }
        }
        else
        {
            if (_timerValue > 0)
            {
                TimerImageFillFraction = _timerValue / TimeToDisplayAnswer;
            }
            else
            {
                _timerValue = TimeToAnswer;
                IsAnsweringQuestion = true;
                LoadNextQuestion = true;
            }
        }
    }
}
