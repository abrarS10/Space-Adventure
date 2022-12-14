using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    CapsuleCollider2D myCollider;
    Rigidbody2D myRigidbody;
    SpriteRenderer playerSprite;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Vector2 damageKickback = new Vector2(10f, 3f);
    public int health;
    public int numOfHearts;
    public bool isInvincible = false;
    public GameObject endMenu;
    public TMP_Text gameOverText;

    public 

    void Start(){
        myCollider = GetComponent<CapsuleCollider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        checkHazardContact();
        updateHearts();       
        Die();
    }

    void checkHazardContact(){
        if(myCollider.IsTouchingLayers(LayerMask.GetMask("Hazard"))){
            takeDamage();
        }
    }

    void updateHearts(){
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

    void takeDamage(){
        if(!isInvincible){
            health--;
            StartCoroutine(damageColor());
        }
        // FindObjectOfType<AudioManager>().Play("playerDeath");
        myRigidbody.velocity = damageKickback;
        StartCoroutine(enableInvincibility());
    }

    public void takeFallDamage(){
        health--;
        StartCoroutine(damageColor());
    }

    void Die(){
        if (health <= 0){
            //TODO
            //Play death animation
            Time.timeScale = 0f;
            gameOverText.text = "GAME OVER";
            // FindObjectOfType<AudioManager>().Play("playerDeath");
            endMenu.SetActive(true);
        }
    }

    IEnumerator enableInvincibility(){
        isInvincible = true;
        yield return new WaitForSeconds(1);
        isInvincible = false;
    }

     IEnumerator damageColor(){
        playerSprite.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        playerSprite.color = Color.white;
    }
}
