using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public int Minutes = 0;
    public int Seconds = 0;

    private Text countdownText;
    private float m_leftTime;

    public bool startTimer = false;

    private void Awake()
    {
        countdownText = GetComponent<Text>();
        m_leftTime = GetInitialTime();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button9) || Input.GetKeyDown(KeyCode.E))
        {
            startTimer = true;
        }
            if (startTimer == true) {

                if (m_leftTime > 0f)
                {
                    //  Update countdown clock
                    m_leftTime -= Time.deltaTime;
                    Minutes = GetLeftMinutes();
                    Seconds = GetLeftSeconds();

                    //  Show current clock
                    if (m_leftTime > 0f)
                    {
                        countdownText.text = "Time left : " + Minutes + ":" + Seconds.ToString("00");
                    }
                   else
                   {
                         //  The countdown clock has finished
                        countdownText.text = "Time left : 0:00";
                        Debug.Log("het nummer is voorbij");
                        SceneManager.LoadScene("Result");
                }
                }
            }
    }

    private float GetInitialTime()
    {
        return Minutes * 60f + Seconds;
    }

    private int GetLeftMinutes()
    {
        return Mathf.FloorToInt(m_leftTime / 60f);
    }

    private int GetLeftSeconds()
    {
        return Mathf.FloorToInt(m_leftTime % 60f);
    }
}
