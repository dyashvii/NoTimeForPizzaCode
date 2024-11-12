using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public Button ResumeButton;
    public Button RestartButton;
    public Button ExitButton;
    public Button SoundButton;
    public Button ReturnButton;
    public GameObject SoundMenu;
    public GameObject PauseMenu;
    public GameObject pauseScreenUI;
    public static bool GameIsPaused = false;

    public Timer timer;

    void Start()
    {
        ResumeButton.onClick.AddListener(OnResumeButtonClick);
        RestartButton.onClick.AddListener(OnRestartButtonClick);
        ExitButton.onClick.AddListener(OnExitButtonClick);
        SoundButton.onClick.AddListener(OnSoundButtonClick);
        ReturnButton.onClick.AddListener(OnReturnButtonClick);
        PauseMenu.SetActive(true);
        SoundMenu.SetActive(false);
    }

    void OnResumeButtonClick()
    {
        Resume();
    }

    void OnRestartButtonClick()
    {
        timer.ResetTime();
        Serve.CorrectPizza = 0;
        Serve.WrongPizza = 0;
        Trash.trashUsed = 0;
        Resume();
    }

    void OnSoundButtonClick()
    {
        PauseMenu.SetActive(false);
        SoundMenu.SetActive(true);

        ResumeButton.interactable = false;
        ExitButton.interactable = false;
        SoundButton.interactable = false;
    }

    void OnReturnButtonClick()
    {
        PauseMenu.SetActive(true);
        SoundMenu.SetActive(false);

        ResumeButton.interactable = true;
        ExitButton.interactable = true;
        SoundButton.interactable = true;
    }

    void OnExitButtonClick()
    {
        Exit();
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

    void Exit()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
