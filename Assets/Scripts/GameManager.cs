using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Customization
    public Sprite blueTail = null;
    public Sprite greenTail = null;
    public Sprite yellowTail = null;
    private int button;

    private void Update()
    {
        SpriteCustomization();
    }
    private void SpriteCustomization()
    {
        button = PlayerPrefs.GetInt("button");
        GameObject prefab = GameObject.Find("Snake");
        GameObject[] prefabtail = GameObject.FindGameObjectsWithTag("Tail");
        
        switch (button)
        {
            case 1:
                greenTail = Resources.Load<Sprite>("Sprites/green_tail");
                prefab.GetComponent<SpriteRenderer>().sprite = greenTail;
                foreach (GameObject obj in prefabtail)
                {
                    obj.GetComponent<SpriteRenderer>().sprite = greenTail;
                }
                break;
            case 2:
                blueTail = Resources.Load<Sprite>("Sprites/blue_tail");
                prefab.GetComponent<SpriteRenderer>().sprite = blueTail;
                foreach (GameObject obj in prefabtail)
                {
                    obj.GetComponent<SpriteRenderer>().sprite = blueTail;
                }
                break;
            case 3:
                yellowTail = Resources.Load<Sprite>("Sprites/yellow_tail");
                prefab.GetComponent<SpriteRenderer>().sprite = yellowTail;
                foreach (GameObject obj in prefabtail)
                {
                    obj.GetComponent<SpriteRenderer>().sprite = yellowTail;
                }
                break;
            default:
                greenTail = Resources.Load<Sprite>("Sprites/green_tail");
                prefab.GetComponent<SpriteRenderer>().sprite = greenTail;
                foreach (GameObject obj in prefabtail)
                {
                    obj.GetComponent<SpriteRenderer>().sprite = greenTail;
                }
                break;
        }

    }
}
