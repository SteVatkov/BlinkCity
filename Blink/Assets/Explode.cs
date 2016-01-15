using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

	public GameObject enemy;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			Destroy (enemy);
		}
	}
}
