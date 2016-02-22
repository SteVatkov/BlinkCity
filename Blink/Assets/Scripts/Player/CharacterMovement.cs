using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
	private float dx;
	private float dy;
	private float x;
	private float y;
	private float dxy;
	public float speed;
	private Rigidbody2D rb;
	public float Energy = 100;
	private float EnergyUsed = 60;
	private float MaxEn = 100;
	private float MinEn = 0;
	public float RegenRate = 10f;
	public bool Inside = false;
	public bool EnterIsDone = false;

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

		gameObject.GetComponent<BoxCollider2D> ().isTrigger = false;
		speed = 4;

		//Grabs hor and ver input values, turns them into positive numbers, then adds them together to play the walk cycle anytime the player has directional input.
		//PROBABLY have to redo later, must be a better way to do it.
		x = dx * dx;
		y = dy * dy;
		dxy = x + y;
		animator.SetFloat("Move",dxy);
		animator.SetBool ("MousePressed", Input.GetMouseButton (0));


		// Energy regenerates by RegenRate when below max value
		if (Energy < MaxEn) {
			Energy += RegenRate * Time.deltaTime;
		}
		// Cannot blink if not enough energy
		if (Energy >= EnergyUsed) {
			if (Input.GetMouseButtonUp (0)) {
				//if(EnterIsDone == true){
				//Teleport();
				Energy = Energy - EnergyUsed;
				//}
			}
		}
		// Energy cannot exceed max value
		if (Energy > MaxEn) {
			Energy = MaxEn;
		}
		// Energy cannot exceed min value
		if (Energy < MinEn) {
			Energy = MinEn;
		}

		//Flips it according to value of dx
		if (dx < 0 && !facingRight)
			Flip();
		else if (dx > 0 && facingRight)
			Flip();

		if (Inside == true) {
			Debug.Log ("Hello");
			gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;
			speed = 0;
		}

	}

	void Teleport()
	{
		var mousePos = Input.mousePosition;
		mousePos.z = 10;
		transform.position = Camera.main.ScreenToWorldPoint (mousePos);
	}

	//Handles flipping of sprite
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Enemy") {
			Inside = true;
		} 
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Enemy") {
			Inside = false;
		}
	}
}
