using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    InventoryScript iScript;
    public Food foodType;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        iScript = other.GetComponent<InventoryScript>();

        Food pickedUpFood = ScriptableObject.CreateInstance("Food") as Food;
        pickedUpFood.init(foodType);
        iScript.foods.Add(pickedUpFood);
        iScript.AddToUI(foodType.sprite);
        //PLAY PICK UP AUDIO HERE
        Destroy(gameObject);
    }
}
