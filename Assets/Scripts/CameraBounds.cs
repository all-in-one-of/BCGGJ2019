using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour {

	void OnDrawGizmosSelected()
	{
		// Draw a semitransparent blue cube at the transforms position
		var bounds = GetComponent<Camera>().NominalScreenAt(Vector3.zero);
		Gizmos.color = Color.red;
		Gizmos.DrawCube(bounds.center, bounds.extents);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public static class CameraExtensions
{
	public static Bounds OrthographicBounds(this Camera camera, Transform transform)
	{
		float screenAspect = (float)Screen.width / (float)Screen.height;
		float cameraHeight = camera.orthographicSize * 2;
		Bounds bounds = new Bounds(
			transform.position,
			new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
		return bounds;
	}
	
	public static Bounds NominalScreenAt(this Camera c, Vector3 v) {
		var depth = v.z - c.gameObject.transform.position.z;
		var bottomPoint = c.ScreenToWorldPoint(new Vector3(0, 0, depth));
		var topPoint = c.ScreenToWorldPoint(new Vector3(c.pixelWidth, c.pixelHeight, depth));
		Debug.Log(bottomPoint);
		var bounds = new Bounds();
		bounds.SetMinMax(bottomPoint, topPoint);
		return bounds;
	}
}
