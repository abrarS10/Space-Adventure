using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    public int materialCount = 0;
    public const int requiredMaterials = 2;
    public bool triggerActive = false;
    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Interactable"){
            triggerActive = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.tag == "Interactable"){
            triggerActive = false;
        }
    }

    void OnInteract(InputValue input){
        if(triggerActive && input.isPressed){
            if(materialCount >= requiredMaterials){
                Debug.Log("You won!!!");
            } else {
                Debug.Log("Not enough materials");
            }
        }
           
    }
}
