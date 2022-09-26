using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    CapsuleCollider2D myCollider;

    void Start(){
        myCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(myCollider.IsTouchingLayers(LayerMask.GetMask("Hazard"))){
            health--;
        }

        if(health > numOfHearts){
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++){

            if(i < health) {
                hearts[i].sprite = fullHeart;
            } else { 
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts){
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }
}
