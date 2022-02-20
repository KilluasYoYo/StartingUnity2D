using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    Animator myAnimator;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    CapsuleCollider2D myCapsuleCollider;
    [SerializeField] float runSpeed;
    [SerializeField] float jumpSpeed = 5f;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
    }




    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log("Move Input");
    }

    // One more way to prevent double jump:
    /*
    bool isTouchingGround;
    void OnCollisionEnter2D(Collision2D other) 
    {
        isTouchingGround = true;   
    }
    void OnCollisionExit2D(Collision2D other) 
    {
        isTouchingGround = false;    
    }
    -> Add isTouchingGround to if statement in OnJump() with && operator.
    */

    void OnJump(InputValue value)
    {
        if(value.isPressed && myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x), 1f);
            myAnimator.SetBool("isRunning", true);
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }
    }
}
