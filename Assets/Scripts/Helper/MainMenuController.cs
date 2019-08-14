using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private MainMenuController instance;

    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }
    public void LoadMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    
    public void LoadDifficultySelectScreen(){
        SceneManager.LoadScene("DifficultySelect");
    }

    public void LoadEasyLevel(){
        SceneManager.LoadScene("Gameplay");
    }

    public void LoadMedLevel(){
        SceneManager.LoadScene("Gameplay");
    }

    public void LoadHardLevel(){
        SceneManager.LoadScene("Gameplay");
    }
}
