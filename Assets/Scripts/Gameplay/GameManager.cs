﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private GameObject mineField;
    [HideInInspector]
    public int rows, cols;
    [HideInInspector]
    public float cameraX, cameraY;

    public enum Level {
        Easy, Medium, Hard
    };
    [HideInInspector]
    public Level level;
    private int easyMineCount = 14, medMineCount = 20, hardMineCount = 30;
    [HideInInspector]
    public int mineCount;
    // Start is called before the first frame update
    void Start()
    {
        rows = 9;
        cols = 11;
        cameraX = 4f;
        cameraY = 7f;
        mineCount = 0;
        level = Level.Medium;
    }

    private void Awake() {
        MakeSingleton();
    }
    
    /** 
        Creates singleton that persists through out the game
    */
    void MakeSingleton(){
        if(instance != null){
            Destroy(gameObject);
        }else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    /** 
        On level load, if the active scene is the Gameplay scene, a call to the
        generateMinefield object is called, and a new minefield object is 
        instantiated.
    */
    void OnLevelWasLoaded(){
        if(SceneManager.GetActiveScene().name == "Gameplay"){
            MatrixGrid.mineFields = new GenerateMineField[rows, cols];
            Camera.main.transform.position = new Vector3(
                cameraX, 
                cameraY, 
                Camera.main.transform.position.z
            );
            for(int x = 0; x < rows; x++){
                for(int y = 0; y < cols; y++){
                    GameObject mine = Instantiate(mineField, new Vector3(x,y, 0), Quaternion.identity) as GameObject;
                    mine.name = x + "-" + y;
                    MatrixGrid.mineFields[x,y] = mine.GetComponent<GenerateMineField>();
                }
            }
        }else{

        }
    }

    /** 
        Depending on the level difficulty chosen, for each level there is a max
        number of mines that can be present on the mine field
    */
    public bool CanBeMine(){
        switch(level){
            case Level.Easy:
                if(mineCount < easyMineCount){
                    return true;
                }else{
                    return false;
                }
                break;
            case Level.Medium:
                if(mineCount < medMineCount){
                    return true;
                }else{
                    return false;
                }
                break;
            case Level.Hard:
                if(mineCount < hardMineCount){
                    return true;
                }else{
                    return false;
                }
                break;
            default:
                return false;
        }
    }

    /** 
        When a new mine is generated, this function will increment the total
        mine count
    */
    public void IncrementMines(){
        mineCount++;
    }
}
