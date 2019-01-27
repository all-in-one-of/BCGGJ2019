using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerChicks : MonoBehaviour {
    public static HungerChicks Instance;

    public float ChickHunger;

    private void Awake() {
        if (Instance != null) {
            Destroy(Instance.gameObject);
        }

        Instance = this;
        ChickHunger = 100;
    }

    void AddFood(float value) {
        ChickHunger += value;
        ChickHunger = Mathf.Clamp(ChickHunger, 0, 100);
    }

    // Update is called once per frame
    void Update() {
        ChickHunger -= 100/(4 * 60f) * Time.deltaTime;
        if (ChickHunger <= 0) {
            //TODO GameOver
        }
    }
}
