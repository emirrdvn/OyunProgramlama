using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSC : MonoBehaviour
{
    bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && isGameOver)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0); // Current Game Scene
        }
    }
    public void GameOver()
    {
        isGameOver = true;
    }
}
