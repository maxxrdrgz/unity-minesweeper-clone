using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    
    public void LoadDifficultySelectScreen(){
        SceneManager.LoadScene("DifficultySelect");
    }

    public void ResetGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
