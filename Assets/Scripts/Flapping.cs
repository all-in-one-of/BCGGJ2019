using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Flapping : MonoBehaviour {
	private Rigidbody _rigidbody;

	[Range(0,100)]
	public float FuckedUpMeter;

	public float SideForces;
	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		_rigidbody.mass = (FuckedUpMeter / 100) + 0.1f;
		_rigidbody.drag = (1 - (FuckedUpMeter / 100) + 0.1f) * 5f;
		
		var bounds = Camera.main.NominalScreenAt(transform.position);
		
		if (Input.GetKeyDown(KeyCode.Space)) {
			_rigidbody.AddForce(Vector3.up * 100, ForceMode.Impulse);
		}

		if (Input.GetKey(KeyCode.A) && transform.position.x > bounds.min.x) {
			_rigidbody.AddForce(Vector3.left * SideForces);
		}
		
		if (Input.GetKey(KeyCode.D) && transform.position.x < bounds.max.x) {
			_rigidbody.AddForce(Vector3.right * SideForces);
		}
		
		transform.ClampX(bounds.min.x, bounds.max.x);
		transform.ClampY(bounds.min.y, bounds.max.y);

		// ReSharper disable CompareOfFloatsByEqualityOperator
		if (transform.position.x == bounds.min.x|| transform.position.x == bounds.max.x) {
			_rigidbody.velocity = Vector3.zero;
		}
		
	}
}
