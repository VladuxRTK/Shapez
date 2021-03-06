﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject randomWaveSpawner;
    public Text counter;
    public TextMeshProUGUI scorelText;
    public Image healthBar;
    private float startTime;
    private Player player;
    private static float incrementCooldown = 15.0f;
    private static int scorelIncrement = 10;
    public static int scorel = 0;
    public Image explosionStreak;


    private float nextIncrement;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        Time.timeScale = 1;
        nextIncrement = incrementCooldown;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        explosionStreak.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
        
        UpdateScore();

    
    }

    private void UpdateUI()
    {
        /*float time = Time.time - startTime;
        string minutes = ((int)time / 60).ToString();
        string seconds = ((int)time % 60).ToString("f0");
        counter.text = minutes + ":" + seconds;*/
        counter.text = WaveSpawner.currentWaveNumber.ToString();
        scorelText.text = "Score: " + scorel;

        // healthBar.fillAmount = player.GetHealthRatio();
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, player.GetHealthRatio(), 5f * Time.deltaTime);
        if(Player.streak >=3)
        {
            explosionStreak.enabled = true;
        }
        else
        {
            explosionStreak.enabled = false;
        }
    }

    private void UpdateScore()
    {
        if (Time.time >= nextIncrement)
        {
            scorel += scorelIncrement;
            nextIncrement = Time.time + incrementCooldown;
        }
    }

    public void UpdateHighScore()
    {
        if (scorel > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", scorel);
        }

    }

   

}
