using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private int playerScore;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Image[] lives;
    private int livesLeft;
    // Start is called before the first frame update
    void Start()
    {
        livesLeft = 3;
        playerScore = 0;
        scoreText.text = "Score: " + playerScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore(int points)
    {
        playerScore += points;
        scoreText.text = "Score: " + playerScore.ToString();
    }
    public void UpdateLives()
    {
        if (livesLeft > 0)
        {
            Destroy(lives[livesLeft - 1]);
            livesLeft -= 1;
        }
        else
        {
            //game over, reset
            SceneManager.LoadSceneAsync(3);
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
