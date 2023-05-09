using UnityEngine;

public class Apple : MonoBehaviour
{
    public Sprite redFood;
    public Sprite yellowFood;
    public Sprite greenFood;
    public Sprite watermelonFood;
    private int button;
    private void Start()
    {
        SpriteCustomization();
        RandomLocation();
    }
    private void RandomLocation()
    {
        float x = Mathf.Round(Random.Range(-17f, 17f));
        float y = Mathf.Round(Random.Range(-9f, 9f));
        transform.position = new Vector3(x, y, 0f);
        TagController();
    }

    private void TagController()
    {
        GameObject[] tailTags = GameObject.FindGameObjectsWithTag("Tail");
        GameObject[] deathZoneTags = GameObject.FindGameObjectsWithTag("Death Zone");
        foreach (GameObject tailTag in tailTags)
        {
            if (tailTag.transform.position == this.transform.position)
            {
                RandomLocation();
            }
        }
        foreach (GameObject deathZoneTag in deathZoneTags)
        {
            if (deathZoneTag.transform.position == this.transform.position)
            {
                RandomLocation();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            RandomLocation();
        }
        else if (collision.tag == "Death Zone")
            RandomLocation();
        else if (collision.tag == "Tail")
            RandomLocation();
        
    }

    private void SpriteCustomization()
    {
        button = PlayerPrefs.GetInt("buttonFood");
        GameObject prefab = GameObject.Find("Apple");
        switch (button)
        {
            case 4:
                redFood = Resources.Load<Sprite>("Sprites/red_food");
                prefab.GetComponent<SpriteRenderer>().sprite = redFood;
                break;
            case 5:
                greenFood = Resources.Load<Sprite>("Sprites/green_food");
                prefab.GetComponent<SpriteRenderer>().sprite = greenFood;
                break;
            case 6:
                yellowFood = Resources.Load<Sprite>("Sprites/yellow_food");
                prefab.GetComponent<SpriteRenderer>().sprite = yellowFood;
                break;
            case 7:
                watermelonFood = Resources.Load<Sprite>("Sprites/watermelon_food");
                prefab.GetComponent<SpriteRenderer>().sprite = watermelonFood;
                break;
            default:
                redFood = Resources.Load<Sprite>("Sprites/red_food");
                prefab.GetComponent<SpriteRenderer>().sprite = redFood;
                break;
        }

    }
}
