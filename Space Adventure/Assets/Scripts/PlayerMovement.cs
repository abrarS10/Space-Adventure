using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{ 
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    public float runSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
    }

    void Run(){
        //add new x value, dont change y
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, 
                                             myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        bool playerIsMoving = Mathf.Abs(moveInput.x) > Mathf.Epsilon;

        myAnimator.SetBool("isRunning", playerIsMoving);
    }

    void FlipSprite(){
        bool playerHasHorizontalSpeed = Mathf.Abs(moveInput.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed){
            transform.localScale = new Vector2(
                                   Mathf.Sign(myRigidbody.velocity.x) * Mathf.Abs(transform.localScale.x), 
                                   Mathf.Abs(transform.localScale.y));
        }
    }
}
