using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingBackAnimaton : MonoBehaviour {

    public AnimationCurve ZPosition;

    public AnimationCurve YPosition;

    public AnimationCurve RotationCurve;

    public float AnimationDuration;
    
    private float _currentTime;
    private Vector3 _startingPosition;

    private void Start() {
        _startingPosition = transform.position;
    }

    // Update is called once per frame
    private void LateUpdate() {
        _currentTime += Time.deltaTime;
        var progess = _currentTime / AnimationDuration;

        if (progess > 1) {
            
        } else {
            transform.position = new Vector3(
                _startingPosition.x    ,
                _startingPosition.y + YPosition.Evaluate(progess) * 100, 
                _startingPosition.z + ZPosition.Evaluate(progess) * 100);
            
            transform.Rotate(Vector3.left    , RotationCurve.Evaluate(progess) * 100);
            
        }
    }
}
