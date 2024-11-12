using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Serve : MonoBehaviour
{
    public Button ServeButton;
    public GameObject ServeLight;
    public GameObject ServeDark;

    public Toppings toppingsScript;
    public RandomiseToppings randomiseToppingsScript;
    public Timer timerScript;

    public static int CorrectPizza = 0;
    public static int WrongPizza = 0;

    public AudioSource correctAudio;
    public AudioSource wrongAudio;

    void Start()
    {
        ServeButton.onClick.AddListener(OnHUDButtonClick);
        ServeLight.SetActive(true);
        ServeDark.SetActive(false);
    }

    void OnHUDButtonClick()
    {
        ServeLight.SetActive(false);
        ServeDark.SetActive(true);
        Invoke("ServeUndo", 1.0f);

        List<Toppings.Topping> randomlySelectedToppings = randomiseToppingsScript.GetRandomlySelectedToppings();

        CheckMatchingToppings(randomlySelectedToppings);
    }

    private void CheckMatchingToppings(List<Toppings.Topping> randomlySelectedToppings)
    {
        var activeToppings = toppingsScript.activeToppings;

        //Debug.Log("Randomly Selected Toppings: " + string.Join(", ", randomlySelectedToppings));
        Debug.Log("Active Toppings: " + string.Join(", ", activeToppings));

        if (new HashSet<Toppings.Topping>(randomlySelectedToppings).SetEquals(activeToppings))
        {
            Debug.Log("The randomly selected toppings match the activated toppings!");
            randomiseToppingsScript.RandomizeToppingSelection();
            toppingsScript.activeToppings.Clear();
            toppingsScript.RemoveToppings();

            correctAudio.Play();

            CorrectPizza++;
            Debug.Log(CorrectPizza);

            if (CorrectPizza <= 50) //50
            {
                timerScript.Addtime();
            }
            if (CorrectPizza > 50 && CorrectPizza <= 75) // > 50 < 75
            {
                timerScript.AddLessTime();
                randomiseToppingsScript.LessIngredients();
            }
            if (CorrectPizza > 75) //75
            {
                timerScript.AddLeastTime();
                randomiseToppingsScript.LesserIngredients();
            }
        }
        else
        {
            Debug.Log("The randomly selected toppings do NOT match the activated toppings.");
            toppingsScript.activeToppings.Clear();
            toppingsScript.RemoveToppings();

            wrongAudio.Play();

            WrongPizza++;
            Debug.Log(WrongPizza);

            if (CorrectPizza <= 50)
            {
                timerScript.Losetime();
            }
            if (CorrectPizza > 50 && CorrectPizza <= 75)
            {
                timerScript.LoseMoreTime();
                randomiseToppingsScript.LessIngredients();
            }
            if (CorrectPizza > 75)
            {
                timerScript.LoseMostTime();
                randomiseToppingsScript.LesserIngredients();
            }
        }
    }

    void ServeUndo()
    {
        ServeLight.SetActive(true);
        ServeDark.SetActive(false);
    }
}
