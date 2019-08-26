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
        print("images length " + images.Length);
        print("nearMines " + nearMines);
        sr.sprite = images[nearMines];
    }

    public bool IsClick(){
        return sr.sprite.texture.name == "Hidden Element";
    }

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
