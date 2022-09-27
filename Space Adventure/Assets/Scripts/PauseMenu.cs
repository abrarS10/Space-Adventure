using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public static bool isPaused = false;
    public GameObject pauseMenu;

    void Start(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (isPaused){
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void loadMenu(){
        //TODO Add menu scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
