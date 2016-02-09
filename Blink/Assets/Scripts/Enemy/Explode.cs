using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

	public GameObject enemy;

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			
			Destroy (enemy);
		}
	}

	void OnTriggerOverlap(Collider2D other) {
		if (other.tag == "Player") {
			//Change to different animation, disable movement, or none of the above.
		}

	}
}
