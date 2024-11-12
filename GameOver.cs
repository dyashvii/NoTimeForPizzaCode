using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public VideoPlayer gameOverVideoPlayer;
    public RawImage videoDisplay;
    public GameObject gameOverScreen;
    public GameObject resultScreen;
    public Button Continue;
    public Button Restart;

    void Start()
    {
        resultScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        videoDisplay.gameObject.SetActive(true);
        Continue.onClick.AddListener(OnContinueClick);
        Restart.onClick.AddListener(OnRestartClick);

        string gameOverVideoPath = System.IO.Path.Combine(Application.streamingAssetsPath, "agameisover.mp4");
        gameOverVideoPlayer.url = gameOverVideoPath;

        gameOverVideoPlayer.Play();
        gameOverVideoPlayer.loopPointReached += OnGameOverVideoFinished;
    }

    private void OnGameOverVideoFinished(VideoPlayer vp)
    {
        StartCoroutine(ShowResultsAfterDelay());
    }

    private IEnumerator ShowResultsAfterDelay()
    {
        yield return new WaitForSeconds(2f);

        gameOverScreen.SetActive(false);
        resultScreen.SetActive(true);
    }

    void OnContinueClick()
    {
        Serve.CorrectPizza = 0;
        Serve.WrongPizza = 0;
        Trash.trashUsed = 0;
        SceneManager.LoadScene("MainMenu");
    }

    void OnRestartClick()
    {
        Serve.CorrectPizza = 0;
        Serve.WrongPizza = 0;
        Trash.trashUsed = 0;
        SceneManager.LoadScene("MainGame");
    }
}
