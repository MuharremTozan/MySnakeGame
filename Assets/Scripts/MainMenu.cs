using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private TextMeshProUGUI highscoreText;
    private int highscore;
    public void Play()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit() 
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void Settings()
    {
        highscoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
        highscore = PlayerPrefs.GetInt("highscore");
        highscoreText.text = highscore.ToString();
    }
}
