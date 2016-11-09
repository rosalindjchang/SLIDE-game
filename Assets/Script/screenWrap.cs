using UnityEngine;
using System.Collections;

public class screenWrap : MonoBehaviour {

	private Renderer[] renderers;
	private bool isWrappingX = false;
	private bool isWrappingY = false;

	void Start () {
		renderers = GetComponentsInChildren <Renderer>();
	}

	void FixedUpdate() {
		ScreenWrap ();
	}

	void ScreenWrap() {
		bool isVisible = CheckRenderers ();
		if (isVisible) {
			isWrappingX = false;
			isWrappingY = false;
			return;
		}

		if (isWrappingX && isWrappingY) {
			return;
		}

		Vector3 newPosition = transform.position;

		if (newPosition.x > 1 || newPosition.x < 0) {
			newPosition.x = -newPosition.x;
			isWrappingX = true;
		}

		if (newPosition.y > 1 || newPosition.y < 0) {
			newPosition.y = -newPosition.y;
			isWrappingY = true;
		}
		transform.position = newPosition;
			
	}

	bool CheckRenderers() {
		foreach (Renderer renderer in renderers) {
			if (renderer.isVisible) {
				return true;
			}
		}
		return false;
	}
}


