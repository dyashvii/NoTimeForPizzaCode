using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toppings : MonoBehaviour
{
    public List<Button> buttonList = new List<Button>();

    public AudioSource MeatButton;

    public GameObject CheeseTopping;
    public GameObject MeatTopping;
    public GameObject OlivesTopping;
    public GameObject PepperoniTopping;
    public GameObject PineappleTopping;
    public GameObject ScrewsTopping;
    public GameObject TomatoTopping;

    public enum Topping
    {
        Cheese,
        Meat,
        Olives,
        Pepperoni,
        Pineapple,
        Screws,
        Tomato
    }

    public List<Topping> activeToppings = new List<Topping>();

    void Start()
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            int index = i;
            buttonList[i].onClick.AddListener(() => ButtonClicked(index));
        }

        CheeseTopping.SetActive(false);
        MeatTopping.SetActive(false);
        OlivesTopping.SetActive(false);
        PepperoniTopping.SetActive(false);
        PineappleTopping.SetActive(false);
        ScrewsTopping.SetActive(false);
        TomatoTopping.SetActive(false);
    }

    void ButtonClicked(int index)
    {
        Topping selectedTopping = (Topping)index;
        ActivateTopping(selectedTopping);
    }

    void ActivateTopping(Topping theTopping)
    {
        switch (theTopping)
        {
            case Topping.Cheese:
                CheeseTopping.SetActive(true);
                activeToppings.Add(Topping.Cheese);
                break;
            case Topping.Meat:
                MeatTopping.SetActive(true);
                MeatButton.Play();
                activeToppings.Add(Topping.Meat);
                break;
            case Topping.Olives:
                OlivesTopping.SetActive(true);
                activeToppings.Add(Topping.Olives);
                break;
            case Topping.Pepperoni:
                PepperoniTopping.SetActive(true);
                activeToppings.Add(Topping.Pepperoni);
                break;
            case Topping.Pineapple:
                PineappleTopping.SetActive(true);
                activeToppings.Add(Topping.Pineapple);
                break;
            case Topping.Screws:
                ScrewsTopping.SetActive(true);
                activeToppings.Add(Topping.Screws);
                break;
            case Topping.Tomato:
                TomatoTopping.SetActive(true);
                activeToppings.Add(Topping.Tomato);
                break;
            default:
                break;
        }
    }

    public void RemoveToppings()
    {
        CheeseTopping.SetActive(false);
        MeatTopping.SetActive(false);
        OlivesTopping.SetActive(false);
        PepperoniTopping.SetActive(false);
        PineappleTopping.SetActive(false);
        ScrewsTopping.SetActive(false);
        TomatoTopping.SetActive(false);
    }
}