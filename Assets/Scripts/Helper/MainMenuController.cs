﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private MainMenuController instance;

    private void Awake() {

    }

    public void LoadDifficultySelectScreen(){
        SceneManager.LoadScene("DifficultySelect");
    }
}
