using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int score;
    public TMP_Text scoreBoardText;
    public TMP_Text gameoverScoreText;

    public float gameSpeed = 2f;

    public int blockValue=10;
    public float blocksDistance =10f;
    public float damageTime = 0.1f;

    public float foodDistance = 12f;
    public Vector2 foodValueRange;
    public Vector2 foodSpawnTimeRange;

    public GameObject startPanel;
    public GameObject scoreBoard;
    public GameObject gameOverPanel;

    public GameObject game;


    private void Awake()
    {
        Instance = this;
        game.SetActive(false);
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreBoardText.text = score.ToString();
    }

    public void StartGame()
    {
        scoreBoard.SetActive(true);
        startPanel.SetActive(false);
        game.SetActive(true);
    }

    public void GameOver()
    {
        gameoverScoreText.text = score.ToString();
        gameOverPanel.SetActive(true);
        game.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

}
