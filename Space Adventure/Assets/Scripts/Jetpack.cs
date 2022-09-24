using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Jetpack : MonoBehaviour
{
    float flyInput;
    public bool isFlying;
    [SerializeField] float flySpeed = 2.5f;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    PlayerMovement movement;
    CapsuleCollider2D collider;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
        collider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Fly();
        checkGround();
    }

    void OnFlying(InputValue value){
        flyInput = value.Get<float>();
    }

    void checkGround(){
        if(collider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            isGrounded = true;
        } else {
            isGrounded = false;
        }
        myAnimator.SetBool("isGrounded", isGrounded);
    }

    void Fly(){
        //TODO changes based on in air
        if(!isGrounded){ 
            movement.runSpeed = 2.5f;
        } else {
            movement.runSpeed = 5f;
        }

        isFlying = checkFlyInput();

        Vector2 playerVelocity = new Vector2((myRigidbody.velocity.x / 2f), flyInput * flySpeed);
        myRigidbody.AddForce(playerVelocity);

        myAnimator.SetBool("isFlying", isFlying);
    }

    bool checkFlyInput(){
        if(flyInput == 1){
            return true;
        } else {
            return false;
        }
    }
}
