using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
	private float dx;
	private float dy;
	private float dxy;
	public float speed;
	private Rigidbody2D rb;
	public bool inside;

	Animator animator;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		dx = Input.GetAxis("Horizontal");
		dy = Input.GetAxis("Vertical");
		rb.velocity = new Vector2(dx * speed,dy * speed);

		dxy = dx + dy;
		//animator.SetFloat("MoveX",dx);
		//animator.SetFloat("MoveY",dy);
		animator.SetFloat("Move",dxy);
		animator.SetBool ("MousePressed", Input.GetMouseButton (0));

		var mousePos = Input.mousePosition;
		mousePos.z = 10;
		if (Input.GetMouseButtonUp(0)){
			transform.position = Camera.main.ScreenToWorldPoint(mousePos);
		}

		//Flips it according to value of dx
		if (dx < 0 && !facingRight)
			Flip();
		else if (dx > 0 && facingRight)
			Flip();
	}

	//Handles flipping of sprite
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
		
}
