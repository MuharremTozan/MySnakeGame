using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    private Vector2 direction;
    [SerializeField] Transform tailPrefab;
    private List<Transform> tails;
    private int firstTail;
    private int tailsCountLast;
    private int scoreCount = 0;
    private int lifeCount = 3;
    private TextMeshProUGUI lifeCountText;
    private TextMeshProUGUI scoreCountText;
    [SerializeField] AudioSource foodSoundEffect;
    [SerializeField] AudioSource eatTailEffect;
    private int grow = 0;



    private void Start()
    {
        lifeCountText = GameObject.Find("LifeCount").GetComponent<TextMeshProUGUI>();
        scoreCountText = GameObject.Find("ScoreCount").GetComponent<TextMeshProUGUI>();
        tails = new List<Transform>();
        tails.Add(this.transform);
    }

    private void Update()
    {
        InputKeys();

    }

    private void FixedUpdate()
    {
        TailMove();
        MoveMath();
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
    }
    private void InputKeys()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && direction != Vector2.down)
        {
            direction = Vector2.up;
        }
        else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && direction != Vector2.up)
        {
            direction = Vector2.down;
        }
        else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && direction != Vector2.right)
        {
            direction = Vector2.left;
        }
        else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && direction != Vector2.left)
        {
            direction = Vector2.right;
        }
        Wait();
    }

    private void MoveMath()
    {
        transform.position = new Vector3(
            Mathf.Round(transform.position.x) + direction.x,
            Mathf.Round(transform.position.y) + direction.y,
            0f
        );
    }

    private void TailMove()
    {
        for (int i = tails.Count - 1; i > 0; i--)
        {
            tails[i].position = tails[i - 1].position;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Apple")
        {
            Grow();
            scoreCount++;
            ScoreCount();
            foodSoundEffect.Play();
        }
        else if (collision.tag == "Death Zone")
        {
            ScoreCount();
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (collision.tag == "Tail")
        {
            eatTailEffect.Play();
            firstTail = tails.IndexOf(collision.transform);
            tailsCountLast = tails.Count - firstTail;
            TailRemove();
            lifeCount = lifeCount - 1;
            lifeCountText.text = lifeCount.ToString();
            if (lifeCount < 1) 
            { 
                ScoreCount();
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    private void ScoreCount()
    {
        scoreCountText.text = scoreCount.ToString();
        PlayerPrefs.SetInt("scoreCount", scoreCount);
    }
    private void Grow()
    {
        Transform tail = Instantiate(tailPrefab);
        tail.name = "Tail";
        
        tail.position = tails[tails.Count - 1].position;
        tails.Add(tail);
    }

    private void TailRemove()
    {
        for(int i = firstTail; i <= tails.Count-1; i++)
        {
            tails[i].tag = "Death Zone";
        }
        tails.RemoveRange(firstTail,tailsCountLast);
    }

}