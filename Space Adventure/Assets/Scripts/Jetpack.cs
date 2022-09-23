using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Jetpack : MonoBehaviour
{
    float flyInput;
    [SerializeField] float flySpeed = 10f;
    Rigidbody2D myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Fly();
    }

    void OnFlying(InputValue value){
        flyInput = value.Get<float>();
        Debug.Log(flyInput);
    }

    void Fly(){
        Vector2 playerVelocity = new Vector2(myRigidbody.velocity.x / 2f, flyInput * flySpeed);
        myRigidbody.AddForce(playerVelocity);
    }
}
