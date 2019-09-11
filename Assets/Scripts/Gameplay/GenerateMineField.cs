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

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
    }

    /** 
        Upon start, there's a 15% chance that this gameobject could be 
        instantiated as a mine
    */
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

    /** 
        If this gameobject is a mine, this gameobjects sprite will be replaced
        with the mine image
    */
    public void ShowMine(){
        if(isMine){
            sr.sprite = mineImage;
        }
    }

    /** 
        This function will replace this gameobjects sprite with the sprite equal
        to the number of mines nearby. This is done by setting up the images
        array indexes to match the near mines images.

        @params {int} # of mines that are near by this current gameobject.
    */
    public void ShowNearMinesCount(int nearMines){
        print("images length " + images.Length);
        print("nearMines " + nearMines);
        sr.sprite = images[nearMines];
    }

    /** 
        This function will return true if this gameobject's sprite is equal to
        Hidden Element
    */
    public bool IsClick(){
        return sr.sprite.texture.name == "Hidden Element";
    }

    /** 
        This function will dictate what happens depending on whether or not this
        gameobject is a mine or not. If so, show all mines and print game over,
        else show how many mines are near and if game is finished, print you won
        to the console.
    */
    private void OnMouseDown() {
        if(isMine){
            MatrixGrid.ShowAllMines();
            print("Game Over");
        }else{
            print("click on mine: " +gameObject.name);
            string[] index = gameObject.name.Split('-');
            int x = int.Parse(index[0]);
            int y = int.Parse(index[1]);
            print("x: " + x + " y: "+ y);
            ShowNearMinesCount(MatrixGrid.NearMines(x, y));
            print("Investigating mines");
            MatrixGrid.InvestigateMines(x, y, new bool[GameManager.instance.rows, GameManager.instance.cols]);
            if(MatrixGrid.IfGameIsFinished()){
                print("you won");
            }
        }
    }
}
