using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	private float dx;
	private float dy;
	public float speed;
	private Rigidbody2D rb;
	private 

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		dx = Input.GetAxis("Horizontal");
		dy = Input.GetAxis("Vertical");
		rb.velocity = new Vector2(dx * speed,dy * speed);
		var mousePos = Input.mousePosition;
		mousePos.z = 10;
		if (Input.GetMouseButtonDown(0)){
			transform.position = Camera.main.ScreenToWorldPoint(mousePos);
		}
	}
}
