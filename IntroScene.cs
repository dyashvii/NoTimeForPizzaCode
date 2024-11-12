using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour
{
    public VideoPlayer IntroVideoPlayer;
    public RawImage videoDisplay;
    public GameObject Intro;
    public Button Yes;
    public Button No;
    public VideoPlayer countdownVideoPlayer;
    public RawImage countdownDisplay;
    public GameObject countdown;
    public GameObject Dialogue;
    public GameObject DialogueBubble;
    public GameObject Pizza;
    public GameObject Timer;
    public AudioSource ClickButton;
    public AudioSource DialogueAudio;

    void Start()
    {
        SetupVideoPlayers();

        Intro.SetActive(true);
        countdown.SetActive(false);
        videoDisplay.gameObject.SetActive(true);
        IntroVideoPlayer.Play();
        IntroVideoPlayer.loopPointReached += OnIntroVideoFinished;
        Yes.onClick.AddListener(OnYesClick);
        No.onClick.AddListener(OnNoClick);
        Dialogue.SetActive(false);
        DialogueBubble.SetActive(false);
        Pizza.SetActive(false);
        Timer.SetActive(false);
    }

    private void SetupVideoPlayers()
    {
        string introVideoPath = System.IO.Path.Combine(Application.streamingAssetsPath, "frame1_1.mp4");
        IntroVideoPlayer.url = introVideoPath;

        string countdownVideoPath = System.IO.Path.Combine(Application.streamingAssetsPath, "3three.mp4");
        countdownVideoPlayer.url = countdownVideoPath;

        IntroVideoPlayer.targetTexture = new RenderTexture(1920, 1080, 0);
        videoDisplay.texture = IntroVideoPlayer.targetTexture;
    }

    private void OnIntroVideoFinished(VideoPlayer vp)
    {
        StartCoroutine(ShowResultsAfterDelay());
        Intro.SetActive(false);
        Pizza.SetActive(true);
        Timer.SetActive(true);
    }

    private IEnumerator ShowResultsAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        //Intro.SetActive(false);
        DialogueAudio.Play();
        Dialogue.SetActive(true);
        DialogueBubble.SetActive(true);
        //Pizza.SetActive(true);
    }

    void OnYesClick()
    {
        countdown.SetActive(true);
        countdownDisplay.gameObject.SetActive(true);
        countdownVideoPlayer.Play();
        countdownVideoPlayer.loopPointReached += OnCountdownFinished;
        Dialogue.SetActive(false);
        DialogueBubble.SetActive(false);
    }

    void OnNoClick()
    {
        ClickButton.Play();
        SceneManager.LoadScene("Result");
    }

    private void OnCountdownFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene("MainGame");
    }
}
