using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {


	// Player Movement Variables
	 public int MoveSpeed = 10;
	 public float JumpHeight;

	//Player Grounded Variables
	public Transform GroundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
	grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}

	//Update is called once per frame
	void Update () {

		//this code makes the character jump
		if(Input.GetKeyDown (KeyCode.Space)&& grounded){
			Jump();
	}
}
public void Jump (){
	GetComponent<RigidBody2D>().velocity = new Vector2(GetComponent<RigidBody2D>()velocity.x, jumpHeight);
}
