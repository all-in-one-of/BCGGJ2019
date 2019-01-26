using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class UpDownCamera : MonoBehaviour
{
	// Update is called once per frame

	private void Update() {
		var bounds = Camera.main.NominalScreenAt(transform);
		var distanceToBottom =  Mathf.Abs(transform.localPosition.y - bounds.min.y);
		var distanceToTop = Mathf.Abs(transform.localPosition.y - bounds.max.y);
		var threshold = 0.3f * bounds.size.y;

		if (distanceToBottom < threshold) {
			Camera.main.transform.localPosition =
				Vector3.Lerp(
					Camera.main.transform.localPosition,
					Camera.main.transform.localPosition.AddY(-distanceToBottom),
					(threshold - distanceToBottom) / threshold
				);
		}
        
		if (distanceToTop < threshold) {
			Camera.main.transform.localPosition =
				Vector3.Lerp(
					Camera.main.transform.localPosition,
					Camera.main.transform.localPosition.AddY(distanceToTop),
					(threshold - distanceToTop) / threshold
				);
		}
	}

}
