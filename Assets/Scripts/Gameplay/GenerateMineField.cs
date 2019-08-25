using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMineField : MonoBehaviour
{
    [HideInInspector]
    public bool isMine;
    [SerializeField]
    private GameObject hiddenObject;
    private SpriteRenderer sr;
    [SerializeField]
    private Sprite[] images;
    [SerializeField]
    private Sprite mineImage;

    private void Start() {
        isMine = Random.value < 0.15f;

        if(isMine){
            if(GameManager.instance.CanBeMine()){
                GameManager.instance.IncrementMines();
            }else{
                isMine = false;
            }
        }
    }

    public void ShowMine(){
        if(isMine){
            sr.sprite = mineImage;
        }
    }

    public void ShowNearMinesCount(int nearMines){
        sr.sprite = images[nearMines];
    }

    public bool IsClick(){
        return sr.sprite.texture.name == "Hidden Element";
    }

    private void OnMouseDown() {
        Debug.Log("clicked a mine: " + gameObject.name);    
    }
}
