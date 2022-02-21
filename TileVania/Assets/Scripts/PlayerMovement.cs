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
    [SerializeField] float climbSpeed =5f;
    float defaultGravityScale;
    float climbingGravityScale = 0f;
    bool hasClimbing;
    SpriteRenderer spriteChanger;
    [SerializeField] Sprite defaultPlayerSprite;
    [SerializeField] Sprite climbingPlayerSprite;
    void Start()
    {
        spriteChanger = GetComponent<SpriteRenderer>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        defaultGravityScale = myRigidbody.gravityScale;
    }
    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
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

    void ClimbLadder()
    {
        bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if(myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            Vector2 climbVelocity = new Vector2 (myRigidbody.velocity.x, moveInput.y * climbSpeed);
            myRigidbody.velocity = climbVelocity;
            myRigidbody.gravityScale = climbingGravityScale;
            hasClimbing=true;
            spriteChanger.sprite = climbingPlayerSprite;
            if(playerHasVerticalSpeed || playerHasHorizontalSpeed)
            {
                myAnimator.SetBool("isClimbing",true);
                myAnimator.enabled = true;
            }
            else
            {
                myAnimator.SetBool("isClimbing",false);
                myAnimator.enabled = false;        
            }

        }
        else
        {
            myAnimator.enabled = true;
            myRigidbody.gravityScale = defaultGravityScale;
            hasClimbing=false;
            myAnimator.SetBool("isClimbing",false);
            spriteChanger.sprite = defaultPlayerSprite;
        }
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > 1f;
        if(playerHasHorizontalSpeed && !hasClimbing)
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
