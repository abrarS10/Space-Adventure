using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;


public class Jetpack : MonoBehaviour
{
    float flyInput;
    public bool isFlying;
    [SerializeField] float flySpeed = 1f;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    PlayerMovement movement;
    CapsuleCollider2D myCollider;
    Health playerHealth;
    public float fuelAmount = 100.0f;
    public float fuelPerSecond = 1.0f;
    public bool isGrounded;
    public Slider slider;
    public float damageVelocity = -10.0f;
    public float maxVelocity = 6f;
    public bool takeFallDamage = false;
    public TMP_Text fuelPercentageText;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
        myCollider = GetComponent<CapsuleCollider2D>();
        playerHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        checkGround();
        if (fuelAmount > 0.0f){
            FuelConsumption();
            Fly();
        }
        checkVelocity();
    }

    void OnFlying(InputValue value){
        flyInput = value.Get<float>();
    }

    void checkGround(){
        if(myCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            isGrounded = true;
            changeMovementSpeed();
            myAnimator.SetBool("isFlying", false);
            if (takeFallDamage){
                playerHealth.takeFallDamage();
            }
        } else {
            isGrounded = false;
        }
        myAnimator.SetBool("isGrounded", isGrounded);
    }
    //TODO rename function (checkForFallDamage)
    void checkVelocity(){
        if (!isGrounded && myRigidbody.velocity.y <= damageVelocity){
            takeFallDamage = true;
        } else {
            takeFallDamage = false;
        }
    }

    void Fly(){

        changeMovementSpeed();
        isFlying = checkFlyInput() && fuelAmount > 0.0f;

        Vector2 playerVelocity = new Vector2((myRigidbody.velocity.x / 2f), flyInput * flySpeed);
        myRigidbody.AddForce(playerVelocity);

        if(myRigidbody.velocity.y > maxVelocity)
             {  
                myRigidbody.velocity *= 0.99f;
             }

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
        if(flyInput == 1 && fuelAmount >= 0){
            fuelAmount -= fuelPerSecond * Time.deltaTime;
            slider.value = fuelAmount;
            updateFuelText();
            //FindObjectOfType<AudioManager>().Play("flying");

        }
    }

    void updateFuelText(){
        if (fuelAmount <= 0.0f){ 
            fuelPercentageText.text = "0%";
        } else {
            fuelPercentageText.text = (fuelAmount).ToString("#.00") + "%";
        }
    }
}
