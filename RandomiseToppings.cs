using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomiseToppings : MonoBehaviour
{
    //public GameObject[] RandomToppings;

    //public int minToppings = 1;
    //public int maxToppings = 5;

    //void Start()
    //{
    //    for (int i = 0; i < 3; i++)
    //    {
    //        int rnd = Random.Range(0, RandomToppings.Length);
    //        if (!RandomToppings[rnd].activeSelf) RandomToppings[rnd].SetActive(true);
    //        else i--;
    //    }
    //}

    public List<GameObject> toppingGameObjects = new List<GameObject>();
    public int minToppings = 1; 
    public int maxToppings = 5;

    public Toppings toppingsScript;

    public List<Toppings.Topping> randomlySelectedToppings { get; private set; } = new List<Toppings.Topping>();

    void Start()
    {
        RandomizeToppingSelection();
    }

    public void LessIngredients()
    {
        minToppings = 2;
    }

    public void LesserIngredients()
    {
        minToppings = 3;
    }

    public void RandomizeToppingSelection()
    {
        toppingGameObjects.ForEach(deactivateTopping => deactivateTopping.SetActive(false));

        int numberOfToppings = Random.Range(minToppings, maxToppings);

        List<int> theToppings = new List<int>();

        for (int i = 0; i < toppingGameObjects.Count; i++)
        {
            theToppings.Add(i);
        }

        for (int i = 0; i < theToppings.Count; i++)
        {
            int temp = theToppings[i];
            int randomIndex = Random.Range(0, theToppings.Count);
            theToppings[i] = theToppings[randomIndex];
            theToppings[randomIndex] = temp;
        }

        List<Toppings.Topping> selectedToppings = new List<Toppings.Topping>();

        for (int i = 0; i < numberOfToppings; i++)
        {
            toppingGameObjects[theToppings[i]].SetActive(true);
            selectedToppings.Add((Toppings.Topping)theToppings[i]);
        }

        randomlySelectedToppings = selectedToppings;

        Debug.Log("Randomly Selected Toppings: " + string.Join(", ", randomlySelectedToppings));
    }

    public List<Toppings.Topping> GetRandomlySelectedToppings()
    {
        return randomlySelectedToppings;
    }
}
