using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour {

    public float TimeNeeded;
    private float _leftTime;
    private float _rightTime;
    
    void Update() {
        Quaternion target = Quaternion.identity;

        if (Input.GetKey(KeyCode.A)) {
            _leftTime += Time.deltaTime;
        } else {
            _leftTime = 0;
        }
        
        if (Input.GetKey(KeyCode.D)) {
            _rightTime += Time.deltaTime;
        } else {
            _rightTime = 0;
        }
            
         if(_leftTime > TimeNeeded) {  
            target = Quaternion.Euler(0, 0, 23f);
        } else if (_rightTime > TimeNeeded) {
            target = Quaternion.Euler(0, 0, -23f);
        }
        transform.localRotation = Quaternion.Lerp(
            transform.localRotation, 
            target,
            Time.deltaTime
        );
    }
}
