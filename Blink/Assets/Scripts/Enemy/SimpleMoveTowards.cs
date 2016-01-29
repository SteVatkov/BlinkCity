using UnityEngine;
using System.Collections;

public class SimpleMoveTowards : MonoBehaviour {

	private Vector2 Position1;
	private bool IsWalking = false;
	public GameObject target;
	public float speed;
	public float DistanceFromTarget;

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
	}
}
