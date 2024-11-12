using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;

    public List<GameObject> CharacterSprites;
    public GameObject Character;
    private bool isPaused = false;
    public AudioSource Boom;
    private bool hasExploded = false;

    void Start()
    {
        Character = CharacterSprites[0];
        CharacterSprites[0].SetActive(true);
    }

    void Update()
    {
        if (!isPaused)
        {
            UpdateTimer();
        }
    }

    void UpdateTimer()
    {
        if (remainingTime > 90)
        {
            remainingTime = 90;
        }
        if (remainingTime > 0 && remainingTime > 45) //100
        {
            remainingTime -= Time.deltaTime;
            //Debug.Log("Happy");
            Character = CharacterSprites[0];
            CharacterSprites[0].SetActive(true);
        }
        if (remainingTime < 45 && remainingTime > 30) //50
        {
            remainingTime -= Time.deltaTime;
            //Debug.Log("Annoyed");
            Character = CharacterSprites[1];
            CharacterSprites[0].SetActive(false);
            CharacterSprites[1].SetActive(true);
        }
        if (remainingTime < 30 && remainingTime > 15) //10
        {
            remainingTime -= Time.deltaTime;
            //Debug.Log("Angry");
            Character = CharacterSprites[2];
            CharacterSprites[1].SetActive(false);
            CharacterSprites[2].SetActive(true);
        }
        if (remainingTime < 15 && remainingTime > 1)
        {
            remainingTime -= Time.deltaTime;
            timerText.color = Color.red;
            //Debug.Log("RAGE");
            Character = CharacterSprites[3];
            CharacterSprites[2].SetActive(false);
            CharacterSprites[3].SetActive(true);
        }
        else if (remainingTime < 1 && !hasExploded)
        {
            Boom.Play();
            hasExploded = true;
            remainingTime = 0;
            timerText.color = Color.red;
            //Debug.Log("BOOM");
            Character = CharacterSprites[4];
            CharacterSprites[3].SetActive(false);
            CharacterSprites[4].SetActive(true);
            Invoke("YouDied", 0.5f);
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void Addtime()
    {
        Debug.Log("Time has been added");
        remainingTime = remainingTime + 3;
        hasExploded = false;
        ResetSprites();
    }

    public void AddLessTime()
    {
        remainingTime = remainingTime + 2;
        hasExploded = false;
        ResetSprites();
    }

    public void AddLeastTime()
    {
        remainingTime = remainingTime + 1;
        hasExploded = false;
        ResetSprites();
    }

    public void Losetime()
    {
        Debug.Log("Time has been lost");
        remainingTime = remainingTime - 5;
        hasExploded = false;
        ResetSprites();
    }

    public void LoseMoreTime()
    {
        remainingTime = remainingTime - 6;
        hasExploded = false;
        ResetSprites();
    }

    public void LoseMostTime()
    {
        remainingTime = remainingTime - 7;
        hasExploded = false;
        ResetSprites();
    }

    void ResetSprites()
    {
        foreach (GameObject sprite in CharacterSprites)
        {
            sprite.SetActive(false);
        }
    }

    public void ResetTime()
    {
        ResetSprites();
        remainingTime = 60;
    }

    public void PauseGame()
    {
        isPaused = true;
    }

    public void ResumeGame()
    {
        isPaused = false;
    }

    void YouDied()
    {
        SceneManager.LoadScene("Result");
    }
}
