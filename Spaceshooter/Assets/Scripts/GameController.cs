using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    private int score;
    private bool gameOver;
    private bool restart;

    void Start()
    {
        restartText.text = "";
        gameOverText.text = "";
        gameOver = false;
        restart = false;

        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWave());

    }
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel (Application.loadedLevel);
            }
        }
        if (gameOver)
        {
            restart = true;
            restartText.text = "Press 'R' to Restart";

        }
    }

        IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)

            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x),
                                                    spawnValues.y,
                                                    spawnValues.z);

                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);

            }

            yield return new WaitForSeconds(waveWait);


        }
    }

    public void AddScore(int newScoreValues)
    {
        score += newScoreValues;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score" + score;
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over!!!";
        gameOver = true;

    }
}
