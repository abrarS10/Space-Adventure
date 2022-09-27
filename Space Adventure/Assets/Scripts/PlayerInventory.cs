using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public int materialCount = 0;
    public const int requiredMaterials = 3;
    public TMP_Text numberOfMaterialsCollected;
    public TMP_Text gameWinText;

    public bool triggerActive = false;
    public GameObject endMenu;

    void Start(){
        UpdateText();
    }
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
                gameWinText.text = "YOU WON!";
                endMenu.SetActive(true);
            } else {
                Debug.Log("Not enough materials");
            }
        }  
    }

    public void UpdateText(){
        numberOfMaterialsCollected.text = materialCount.ToString() + " / " + requiredMaterials.ToString();
    }
}
