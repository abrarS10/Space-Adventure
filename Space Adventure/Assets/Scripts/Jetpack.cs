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
    CapsuleCollider2D myCollider;
    public float fuelAmount = 100.0f;
    public float fuelPerSecond = 1.0f;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
        myCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        checkGround();
        if (fuelAmount > 0.0f){
            FuelConsumption();
            Fly();
        }
    }

    void OnFlying(InputValue value){
        flyInput = value.Get<float>();
    }

    void checkGround(){
        if(myCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            isGrounded = true;
            myAnimator.SetBool("isFlying", false);
        } else {
            isGrounded = false;
        }
        myAnimator.SetBool("isGrounded", isGrounded);
    }

    void Fly(){

        changeMovementSpeed();
        isFlying = checkFlyInput();

        Vector2 playerVelocity = new Vector2((myRigidbody.velocity.x / 2f), flyInput * flySpeed);
        myRigidbody.AddForce(playerVelocity);

        myAnimator.SetBool("isFlying", isFlying);
    }

    void changeMovementSpeed(){
        if(!isGrounded){ 
            movement.runSpeed = 2.5f;
        } else {
            movement.runSpeed = 5f;
        }
    }

    bool checkFlyInput(){
        if(flyInput == 1){
            return true;
        } else {
            return false;
        }
    }
    void FuelConsumption(){
        if(flyInput == 1){
            fuelAmount -= fuelPerSecond * Time.deltaTime;
        }
    }
}
