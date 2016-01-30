using UnityEngine;
using System.Collections;

public class SimpleMoveTowards : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
	private Vector2 Position1;
	private bool IsWalking = false;
	public GameObject target;
	public float speed;
	public float DistanceFromTarget;

	private Vector3 prevloc = Vector2.zero;
	private Vector3 curVel;

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}


	void Update () 
	{
		Position1 = target.transform.position;
		if(Vector2.Distance(transform.position, Position1) < DistanceFromTarget){
			IsWalking = true;
			transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), Position1, speed * Time.deltaTime);

		}
		else IsWalking = false;
		animator.SetBool ("Walking", IsWalking);
	
		//Checks previous location with current location to see which direction it's headed in
		curVel = (transform.position - prevloc) / Time.deltaTime;
		prevloc = transform.position;

		//Flips it according to x value of curVel
		if (curVel.x > 0 && facingRight)
			Flip();
		else if (curVel.x < 0 && !facingRight)
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
