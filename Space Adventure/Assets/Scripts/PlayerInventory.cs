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
    public TMP_Text requiredMaterialsText;

    public bool triggerActive = false;
    public GameObject endMenu;
    public GameObject rocketMessage;

    void Start(){
        UpdateText();
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Interactable"){
            triggerActive = true;
            rocketMessage.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.tag == "Interactable"){
            triggerActive = false;
            rocketMessage.SetActive(false);
            requiredMaterialsText.text = "Press E to Interact";
        }
    }

    void OnInteract(InputValue input){
        if(triggerActive && input.isPressed){
            if(materialCount >= requiredMaterials){
                gameWinText.text = "YOU WON!";
                rocketMessage.SetActive(false);
                endMenu.SetActive(true);
            } else {
                requiredMaterialsText.text = "You need " + (requiredMaterials - materialCount).ToString() + " more materials before leaving";
            }
        }  
    }

    public void UpdateText(){
        numberOfMaterialsCollected.text = materialCount.ToString() + " / " + requiredMaterials.ToString();
    }
}
