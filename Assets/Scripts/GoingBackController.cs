using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingBackController : MonoBehaviour {

    private GoingBackAnimaton _animaton;

    private BirdMovement _birdMovement;

    public float TargetTimer;
    public float timer;
    
    // Start is called before the first frame update
    void Start() {
        _animaton = GetComponent<GoingBackAnimaton>();
        _birdMovement = GetComponentInChildren<BirdMovement>();
    }

    // Update is called once per frame
    void Update() {
        var bounds = Camera.main.NominalScreenAt(_birdMovement.gameObject.transform);

        if (
            Math.Abs(_birdMovement.gameObject.transform.localPosition.y - bounds.max.y) < 3
            && Input.GetKey(KeyCode.W)
            ) {
            timer += Time.deltaTime;
        } else {
            timer = 0;
        }

        if (timer > TargetTimer) {
            _animaton.enabled = true;
            _birdMovement.enabled = false;
        }
        
    }
}
