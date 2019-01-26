using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class BirdMovement : MonoBehaviour {
	private Rigidbody _rigidbody;
	private Animator _animator;

	[Range(0,1)]
	public float FuckedUpMeter;

	public float SideForces;
	public AnimationCurve FlapForce;
	private float _lastFlap = 0;

	private float _minY = 15;
	private float _maxY = 60;

	private Vector3 localVelocity;
	private Quaternion lastRotation;
	
	void Awake () {
		Physics.gravity = Vector3.down * 20f;
		_rigidbody = GetComponent<Rigidbody>();
		_animator = GetComponent<Animator>();
		lastRotation = transform.parent.rotation;
	}
	
	void OnDrawGizmosSelected() {
//		Camera.main.CameraGizmos(transform);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(transform.position, transform.position + transform.right * 10);
	}
	
	// Update is called once per frame
	void Update () {
		
		Physics.gravity = Vector3.down * (20f + FuckedUpMeter * 5);
//		
		_rigidbody.mass = FuckedUpMeter + 0.1f;
		_rigidbody.drag = (1 - FuckedUpMeter + 0.1f) * 5f;
//		
		Flap();
		
		var bounds = Camera.main.NominalScreenAt(transform);
;		if (Input.GetKey(KeyCode.A) ) {
			_rigidbody.AddForce(-transform.right * SideForces);
		}
		
		if (Input.GetKey(KeyCode.D) ) {
			_rigidbody.AddForce(transform.right * SideForces);
		}
		
		transform.localPosition = transform.localPosition.ClampX(bounds.min.x, bounds.max.x);
//		transform.localPosition = transform.localPosition.ClampY(_minY, _maxY);

	}

	private void FixedUpdate() {
		_rigidbody.velocity = (transform.parent.rotation * Quaternion.Inverse(lastRotation)) * _rigidbody.velocity;
		lastRotation = transform.parent.rotation;
	}

	private void Flap() {
		var flappingTimer = 0.5f - FuckedUpMeter * 0.2f;
		var flapForce = FlapForce.Evaluate(FuckedUpMeter);
		float flapTime = 0.3f;
		_animator.SetFloat("FlapSpeed", flappingTimer/flapTime);
		if (Time.time - _lastFlap > flappingTimer) {
			if (Input.GetKey(KeyCode.W)) {
				_animator.SetTrigger("Flap");
				_rigidbody.AddForce(Vector3.up * flapForce, ForceMode.Impulse);
				_lastFlap = Time.time;
			}
		}
	}
}
