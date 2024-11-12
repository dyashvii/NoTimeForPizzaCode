using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trash : MonoBehaviour
{
    public Button TrashButton;
    public List<GameObject> Toppings;
    public GameObject TrashClosed;
    public GameObject TrashOpen;

    public Toppings toppingsScript;

    public static int trashUsed = 0;

    public AudioSource trashAudio;

    void Start()
    {
        TrashButton.onClick.AddListener(OnHUDButtonClick);
        TrashClosed.SetActive(true);
        TrashOpen.SetActive(false);
    }

    void OnHUDButtonClick()
    {
        Toppings.ForEach(trash => trash.SetActive(false));
        toppingsScript.activeToppings.Clear();

        TrashClosed.SetActive(false);
        TrashOpen.SetActive(true);
        Invoke("OpenTrash", 1.0f);

        trashAudio.Play();

        trashUsed++;
        Debug.Log(trashUsed);
    }

    void OpenTrash()
    {
        TrashClosed.SetActive(true);
        TrashOpen.SetActive(false);
    }
}
