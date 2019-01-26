using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

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
	
	public static Bounds NominalScreenAt(this Camera c, Transform t) {
		var v = t.localPosition;
		var depth = v.z  - c.gameObject.transform.localPosition.z;
		var bottomPoint = c.ScreenToWorldPoint(new Vector3(0, 0, depth));
		var topPoint = c.ScreenToWorldPoint(new Vector3(c.pixelWidth, c.pixelHeight, depth));
		var bounds = new Bounds();
		bounds.SetMinMax(
			t.parent.worldToLocalMatrix.MultiplyPoint3x4(bottomPoint), 
			t.parent.worldToLocalMatrix.MultiplyPoint3x4(topPoint)
			);
		return bounds;
	}

	public static void CameraGizmos(this Camera c, Transform t) {
		var v = t.localPosition;
		var depth = v.z  - c.gameObject.transform.localPosition.z;
		var bottomPoint = c.ScreenToWorldPoint(new Vector3(0, 0, depth));
		var topPoint = c.ScreenToWorldPoint(new Vector3(c.pixelWidth, c.pixelHeight, depth));
		var bounds = new Bounds();
		Gizmos.matrix = t.parent.worldToLocalMatrix;
		bounds.SetMinMax(bottomPoint, topPoint);
		bounds.center = t.position;
		Gizmos.color = Color.red;
//		Gizmos.DrawCube(bounds.center, bounds.extents*2);
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(bottomPoint, 1);
		Gizmos.DrawSphere(topPoint, 1);
		;
	}
}
