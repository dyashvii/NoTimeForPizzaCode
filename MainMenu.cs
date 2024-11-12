using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource ClickButton;

    public void PlayGame()
    {
        ClickButton.Play();
        Invoke("SceneChange", 0.5f);
        Debug.Log("Play game");
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void QuitGame()
    {
        ClickButton.Play();
        Invoke("Quit", 0.5f);
    }
    
    public void Quit()
    {
        //Application.Quit();
        SceneManager.LoadScene("Result");
        Debug.Log("Quit");
    }
}
