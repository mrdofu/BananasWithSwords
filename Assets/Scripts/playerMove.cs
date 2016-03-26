using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	bool facingRight = true;
	public float maxSpeed = 10f;

	Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.05f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;

	// Use this for initialization
	void Start () {
		// we'll be changing its parameters
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");

		// left and right movement
		anim.SetFloat ("Speed", Mathf.Abs (move * maxSpeed));
		rigidbody2D.velocity = new Vector2 (move*maxSpeed, rigidbody2D.velocity.y);

		// jumping check for grounded
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
		anim.SetFloat ("vSpeed", Mathf.Abs (rigidbody2D.velocity.y));

		// left or right facing
		if (move > 0 && !facingRight) 
			flip ();
		else if (move < 0 && facingRight)
			flip ();
	}

	void Update(){
		// jumping
		if (grounded && Input.GetAxis ("Vertical")>0) {
			anim.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}

		// attack
		if (!anim.GetBool ("Attack") && Input.GetKeyDown ("f")) {
			anim.SetBool("Attack", true);
		}
	}

	void flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}