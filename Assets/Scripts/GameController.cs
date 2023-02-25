using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public float xMinMax;

    public float zMin;
    public GameObject rock;

    public int count;

    public float cloneWait;
    public float startWait;
    public float waveWait;

    private int score;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI gameOverText;

    private bool gameOver;
    private bool restart;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;

        scoreText.text = "";
        gameOverText.text = "";
        restartText.text = "";

        gameOver = restart = false;

        StartCoroutine(Waves());
    }

    private void Update()
    {
        if (restart && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator Waves()
    {
        while(true)
        {
            yield return new WaitForSeconds(startWait);
            for (int i = 0; i < count; i++)
            {
                Instantiate(rock, new Vector3(Random.Range(-xMinMax, xMinMax), 0, zMin), Quaternion.identity);
                yield return new WaitForSeconds(cloneWait);
            }
            if (gameOver)
            {
                restart = true;
                restartText.text = "Press 'R' to restart";
                break;
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void addScore(int sc)
    {
        score += sc;
        scoreText.text = "Score: " + score;
        Debug.Log(score);
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
        Debug.Log("Test");
    }
}
