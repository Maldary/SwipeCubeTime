using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public float initialTime = 7f;

    private float currentTime;

    public TextMeshProUGUI timerDisplay;

    void Start()
    {
        currentTime = initialTime;
        UpdateTimerDisplay();

        StartCoroutine(DecreaseTimer());
    }

    void UpdateTimerDisplay()
    {
        timerDisplay.text = currentTime.ToString("F1");
    }

    IEnumerator DecreaseTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            currentTime -= 0.1f;
            UpdateTimerDisplay();

            if (currentTime <= 0f)
            {
                currentTime = initialTime;
                UpdateTimerDisplay();
            }
        }
    }

    public void UpdateTimer()
    {
        initialTime -= 0.1f;
        currentTime = initialTime;
        UpdateTimerDisplay();
    }
}