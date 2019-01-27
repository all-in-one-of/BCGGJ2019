using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour { 
    GameObject[] iSlots;
    public List<Food> foods;
    public Slider meter;
    public int depletionRate;
    public int depletionAmount;
    // Start is called before the first frame update
    void Start()
    {
        foods= new List<Food>();
       // iSlots = GameObject.FindGameObjectsWithTag("ISlot");
    }

    // Update is called once per frame
    void Update()
    {
        meter.value = HungerChicks.Instance.ChickHunger;
    }   
    
    public void AddToUI(Sprite foodSprite)
    {
        //foreach (GameObject slot in iSlots)
        //{
        //if (slot.GetComponent<Image>().sprite == null)
        //{
        //slot.GetComponent<Image>().sprite = foodSprite;
        //}

        //}
    }

    public void EatFood()
    {
        foreach (Food food in foods)
            HungerChicks.Instance.AddFood(food.nourishment);
    }
        
}
