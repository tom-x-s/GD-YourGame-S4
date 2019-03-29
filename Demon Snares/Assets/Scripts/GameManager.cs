﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Stat health;

    private bool hpCheck;

    [SerializeField]
    private Animator playerAnim;

    public AudioSource theMusic;

    public bool startPlaying;
    
    //public BeatScroller theBS;  / used in 2D
    public BeatScroller3D theBS3D;
    public GameTimer theGT;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;

    public Text scoreText;
    public Text multiText;
    public Text timeText;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    private void Awake()
    {
        health.Initialize();
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
        currentMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(health.CurrentVal == 0)
        {
            SceneManager.LoadScene("Result");
        }

        if (!startPlaying) //start het nummer en de chart
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button9) || Input.GetKeyDown("e"))
            {
                startPlaying = true;
                theBS3D.hasStarted = true;

                theMusic.Play();
            }
        }

        if (playerAnim)
        {
            if (Input.GetKeyDown("a") || Input.GetKeyDown("s") || Input.GetKeyDown("d") || Input.GetKeyDown("f") || Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button3))
            {
                playerAnim.SetBool("HittingNote", true);
            }
            else
            {
                playerAnim.SetBool("HittingNote", false);
            }
        }

    }

    public void NoteHit()
    {
        Debug.Log("Hit on time");

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = "Multiplier: x" + currentMultiplier;

        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");
        //health.CurrentVal -= 10;

        currentMultiplier = 1;
        multiplierTracker = 0;

        multiText.text = "Multiplier: x" + currentMultiplier;

        scoreText.text = "Score: " + currentScore;
    }

    public void HitNothing()
    {
        Debug.Log("Spam");

        currentMultiplier = 1;
        multiplierTracker = 0;

        multiText.text = "Multiplier: x" + currentMultiplier;

        scoreText.text = "Score: " + currentScore;
    }
}
