using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour {

    // Player movement varlables
    public int moveSpeed;
    public float JumpHeight;
    private bool doubleJump;
    
    // Player grounded varlables
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;

    // Non-Slide Player
    private float moveVelocity;

    public Animator animator;

    // Use this for initialization
    void Start () {
        //Animation reset
        animator.SetBool("isWalking",false);
        animator.SetBool("isJumping",false);
    }
    
    void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Update is called once per fame
    void Update () {

        // This code makes the character jump
        if(Input.GetKeyDown (KeyCode.W)&& grounded){
            Jump();
        }

        // Double Jump code
        if(grounded){
            doubleJump = false;
            animator.SetBool("isJumping",false);
        }

        if(Input.GetKeyDown (KeyCode.W)&& !doubleJump && !grounded){
            Jump();
            doubleJump = true;
        }   
        // Non-Slide Player
        moveVelocity = 0f;

        // This code makes the character move from side to side using the A&D keys
        if(Input.GetKey (KeyCode.D)){
            // GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = moveSpeed;
            animator.SetBool("isWalking",true);
        }       
        
        else if(Input.GetKeyUp (KeyCode.D)){
            animator.SetBool("isWalking",false);
        }
        if(Input.GetKey (KeyCode.A)){
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = -moveSpeed;
            animator.SetBool("isWalking",true);
        }

        if(Input.GetKey (KeyCode.A)){
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = -moveSpeed;
            animator.SetBool("isWalking",false);
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        // Player Flip
        if(GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(3f,3f,1f);

        else if(GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale = new Vector3(-3f,3f,1f);

    }

    public void Jump(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
        animator.SetBool("isJumping",true);
    }
}