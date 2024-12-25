using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManagerSC : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI gameOverText;
    [SerializeField]
    TextMeshProUGUI restartText;
    [SerializeField]
    Sprite[] livesSprite;
    [SerializeField]
    Image livesImage;
    GameManagerSC gameManager;
    void Start()
    {
        scoreText.text = "Score: " + 0;
        gameOverText.gameObject.SetActive(false);
        restartText.gameObject.SetActive(false);
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManagerSC>();
    }
    void Update()
    {
       
    }
    public void UpdateScore()
    {
        scoreText.text = "Score: " + FindObjectOfType<PlayerSC>().score;
    }
    public void UpdateLivesImg(int currentLives)
    {
        livesImage.sprite = livesSprite[currentLives];
        if (currentLives == 0)
        {
            GameOverSequence();
            StartCoroutine(GameOverFlicker());
        }
    }
    IEnumerator GameOverFlicker()
    {
        while (true)
        {
            gameOverText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            gameOverText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
    void GameOverSequence()
    {
        gameManager.GameOver();
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
    }
}
