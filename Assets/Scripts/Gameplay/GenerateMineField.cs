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



    private void OnMouseDown() {
        Debug.Log("clicked a mine: " + gameObject.name);    
    }
}
