using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player"){
            other.GetComponent<PlayerInventory>().materialCount++;
            other.GetComponent<PlayerInventory>().UpdateText();
            Destroy(gameObject);
        }
    }
}
