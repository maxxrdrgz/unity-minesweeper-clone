using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixGrid : MonoBehaviour
{
    public static GenerateMineField[,] mineFields;

    public static void ShowAllMines(){
        foreach (GenerateMineField mf in mineFields){
            mf.ShowMine();
        }
    }

    public static bool MineAtCoordinates(int x, int y){
        if(x >= 0 && y >= 0 && x < GameManager.instance.rows && y < GameManager.instance.cols){
            if(mineFields[x,y].isMine){
                return true;
            }else{
                return false;
            }
        }
        return false;
    }

    public static int NearMines(int x, int y){
        int count = 0;
        
        if(MineAtCoordinates(x, y+1)){ count++; }
        if(MineAtCoordinates(x+1, y+1)){ count++; }
        if(MineAtCoordinates(x+1, y)){ count++; }
        if(MineAtCoordinates(x+1, y-1)){ count++; }
        if(MineAtCoordinates(x, y-1)){ count++; }
        if(MineAtCoordinates(x-1, y-1)){ count++; }
        if(MineAtCoordinates(x-1, y)){ count++; }
        if(MineAtCoordinates(x-1, y+1)){ count++; }
        print("count is " + count);

        return count;
    }

    //floodfill algorithm
    public static void InvestigateMines(int x, int y, bool[,] visited){
        if(x >= 0 && y >= 0 && x < GameManager.instance.rows && y < GameManager.instance.cols){
            if(visited[x,y]){
                return;
            }
            mineFields[x,y].ShowMine();
            mineFields[x,y].ShowNearMinesCount(NearMines(x,y));

            if(NearMines(x,y) > 0){
                return;
            }

            visited[x,y] = true;

            InvestigateMines(x, y+1, visited);
            InvestigateMines(x+1, y+1, visited);
            InvestigateMines(x+1, y, visited);
            InvestigateMines(x+1, y-1, visited);
            InvestigateMines(x, y-1, visited);
            InvestigateMines(x-1, y-1, visited);
            InvestigateMines(x-1, y, visited);
            InvestigateMines(x-1, y+1, visited);
        }
    }

    public static bool IfGameIsFinished(){
        foreach(GenerateMineField mf in mineFields){
            if(mf.IsClick() && !mf.isMine){
                return false;
            }
        }
        return true;
    }
}
