using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food", order = 1)]
public class Food : ScriptableObject
{
    public int nourishment;
    public string foodName;
    public Sprite sprite;

    public void init (Food foodType)
    {
        this.nourishment = foodType.nourishment;
        this.foodName = foodType.name;
        this.sprite = foodType.sprite;
    }
}
