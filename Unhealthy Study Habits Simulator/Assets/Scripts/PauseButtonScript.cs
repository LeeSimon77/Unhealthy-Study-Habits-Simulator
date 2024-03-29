﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonScript : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerStats player;
    public bool textVisible = false;
    public double nextTextVisibleToggle;
    public GameObject pauseText;
    public double textInterval = 0.5;

    public AudioSource bgMusic;
    public AudioSource pauseMusic;
    public AudioSource pauseEffect;

    // Start is called before the first frame update
    void Start()
    {
        nextTextVisibleToggle = Time.time + textInterval;
        Button btn = GameObject.Find("PauseButton").GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void Update()
    {
        if ((player.getPaused() && Time.time >= nextTextVisibleToggle) || (!player.getPaused() && textVisible))
        {
            textVisible = !textVisible;
            nextTextVisibleToggle += textInterval;
            pauseText.SetActive(textVisible);   
        }
    }

    private void TaskOnClick()
    {
        player.togglePause();
        playerMovement.pause();

        if (player.getPaused()) // pause
        {
            Debug.Log("Pause");
            nextTextVisibleToggle = Time.time;
            StartPauseMusic();
            
        } else // unpause
        {
            Debug.Log("Unpause");
            EndPauseMusic();
        }
    }

    void StartPauseMusic()
    {
        bgMusic.Pause();
        pauseEffect.Play();
        pauseMusic.PlayDelayed(pauseEffect.clip.length + 0.35f);
    }

    void EndPauseMusic()
    {
        pauseMusic.Stop();
        pauseEffect.Play();
        bgMusic.PlayDelayed(pauseEffect.clip.length);
    }
}
