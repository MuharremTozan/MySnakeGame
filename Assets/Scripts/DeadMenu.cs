using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    private TextMeshProUGUI deadScoreText;
    private int scoreCount;
    private TextMeshProUGUI highscoreText;
    private int highscore = 0;

    private void Start()
    {
        scoreCount = PlayerPrefs.GetInt("scoreCount");
        deadScoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        deadScoreText.text = scoreCount.ToString();

        highscore = PlayerPrefs.GetInt("highscore");
        highscoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
        highscoreText.text = highscore.ToString();

        if (scoreCount > highscore)
        {
            highscore = scoreCount;
            PlayerPrefs.SetInt("highscore", highscore);
            highscoreText.text = highscore.ToString();
        }
    }
    public void Play()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
