using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    public Button PauseButton;
    public Button Ketchup;
    public Button Mustard;
    public GameObject pauseScreenUI;
    public static bool GameIsPaused = false;

    public Timer timer;
    public AudioSource ButtonAudio;
    public AudioSource SquirtAudio;

    void Start()
    {
        PauseButton.onClick.AddListener(OnPauseButtonClick);
        Ketchup.onClick.AddListener(OnKetchupClick);
        Mustard.onClick.AddListener(OnMustardClick);
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape)) 
    //    {
    //        if (GameIsPaused)
    //        {
    //            Resume();
    //        }
    //        else
    //        {
    //            Pause();
    //        }
    //    }
    //}

    void OnPauseButtonClick()
    {
        //if (GameIsPaused)
        //{
        //    Resume();
        //}
        //else
        //{
        //    Pause();
        //}

        Pause();

        ButtonAudio.Play();
    }

    void OnKetchupClick()
    {
        SquirtAudio.Play();
    }

    void OnMustardClick()
    {
        SquirtAudio.Play();
    }

    void Pause()
    {
        pauseScreenUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        if (timer != null)
        {
            timer.PauseGame();
        }
    }

    void Resume()
    {
        pauseScreenUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        if (timer != null)
        {
            timer.ResumeGame();
        }
    }
}
