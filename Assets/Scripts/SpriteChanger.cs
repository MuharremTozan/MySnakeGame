using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    private int buttonSnake;
    private int buttonFood;
    public void GreenTail()
    {
        buttonSnake = 1;
        PlayerPrefs.SetInt("button", buttonSnake);
    }
    public void BlueTail()
    {
        buttonSnake = 2;
        PlayerPrefs.SetInt("button", buttonSnake);
    }
    public void YellowTail()
    {
        buttonSnake = 3;
        PlayerPrefs.SetInt("button", buttonSnake);
    }
    public void RedFood()
    {
        buttonFood = 4;
        PlayerPrefs.SetInt("buttonFood", buttonFood);
    }
    public void GreenFood()
    {
        buttonFood = 5;
        PlayerPrefs.SetInt("buttonFood", buttonFood);
    }
    public void YellowFood()
    {
        buttonFood = 6;
        PlayerPrefs.SetInt("buttonFood", buttonFood);
    }
    public void WatermelonFood()
    {
        buttonFood = 7;
        PlayerPrefs.SetInt("buttonFood", buttonFood);
    }
}
