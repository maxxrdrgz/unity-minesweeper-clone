using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixGrid : MonoBehaviour
{
    public static GenerateMineField[,] mineFields;

    /** 
        This function will call shoMine for each mf in the array minefields
    */
    public static void ShowAllMines(){
        foreach (GenerateMineField mf in mineFields){
            mf.ShowMine();
        }
    }

    /** 
        Checks if the gameobject given at the x and y coordinates is a mine

        @params {int} x coordinate of the mine
        @params {int} y coordinate of the mine
        @return {bool} Returns true if the gameobject at x,y is a mine
    */
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

    /** 
        In relation to this gameobject, this function will check the surrounding
        gameobjects to see if they're a mine. Then increments a count.

        @params {int} x coordinate of the mine
        @params {int} y coordinate of the mine
        @return {int} Returns the number of mines nearby
    */
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

    /** 
        This function replicates the floodfill algorithm to check the
        surrounding coordinates of a mine and updates the near mines as well

        @params {int} x coordinate of this gameobject
        @params {int} y coordinate of this gameobject
        @params {bool[,]} 2d array containing coordinates
    */
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

    /** 
        This function will check if a mine in the minefield has been clicked,
        if so returns true

        @returns {bool} Returns a boolean on whether or not the game has 
        finished
    */
    public static bool IfGameIsFinished(){
        foreach(GenerateMineField mf in mineFields){
            if(mf.IsClick() && !mf.isMine){
                return false;
            }
        }
        return true;
    }
}
