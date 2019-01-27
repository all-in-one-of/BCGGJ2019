using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour {
    private Rigidbody _rigidbody;

    private void Awake() {
        _rigidbody = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        var bounds = Camera.main.NominalScreenAt(transform);
        Quaternion target = Quaternion.identity;
        if (Input.GetKey(KeyCode.A)) {
            target = Quaternion.Euler(0, 0, 23f);
        } else if (Input.GetKey(KeyCode.D)) {
            target = Quaternion.Euler(0, 0, -23f);
        }
        
        transform.localRotation = Quaternion.Lerp(
            transform.localRotation, 
            target,
            3 * Time.deltaTime
        );
    }
}
