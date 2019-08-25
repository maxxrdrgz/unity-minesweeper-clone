using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectController : MonoBehaviour
{

    public void SelectLevel(string level){
        switch (level)
        {
            case "Easy":
                if(GameManager.instance){
                    GameManager.instance.rows = 8;
                    GameManager.instance.cols = 9;
                    GameManager.instance.cameraX = 3.5f;
                    GameManager.instance.cameraY = 5.5f;
                    GameManager.instance.level = GameManager.Level.Easy;
                }
                break;
            case "Medium":
                if(GameManager.instance){
                    GameManager.instance.rows = 9;
                    GameManager.instance.cols = 11;
                    GameManager.instance.cameraX = 4;
                    GameManager.instance.cameraY = 7;
                    GameManager.instance.level = GameManager.Level.Medium;
                }
                break;
            case "Hard":
                if(GameManager.instance){
                    GameManager.instance.rows = 10;
                    GameManager.instance.cols = 13;
                    GameManager.instance.cameraX = 4.5f;
                    GameManager.instance.cameraY = 7;
                    GameManager.instance.level = GameManager.Level.Hard;
                }
                break;
        }
        LoadGameplay();
    }

    public void LoadMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    
    public void LoadDifficultySelectScreen(){
        SceneManager.LoadScene("DifficultySelect");
    }
    public void LoadGameplay(){
        SceneManager.LoadScene("Gameplay");
    }
}
