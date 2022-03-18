using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public GameObject[] types;
    public float timeToSpawn;
    public float fastestSpawn;

    public float multiplier;
    public float fallSpeed = 2;

    public int score = 0;
    public bool gameOver;

    public TextMeshProUGUI text;
    public TextMeshProUGUI textBot;

    public float spawnTemp;

    void Start()
    {
        gameOver = true;
        CheckGameOver();
    }

    private void Update()
    {
        CheckGameOver();

        text.text = score.ToString();
        timeToSpawn -= Time.deltaTime * multiplier;
        if (timeToSpawn < fastestSpawn) timeToSpawn = fastestSpawn;

        fallSpeed += Time.deltaTime * 0.02f;
    }

    IEnumerator SpawnRandom()
    {
        int num = Random.Range(0, types.Length);

        Instantiate(types[num], transform.position, transform.rotation);

        yield return new WaitForSeconds(timeToSpawn);

        StartCoroutine("SpawnRandom");
    }

    void CheckGameOver()
    {
        if (gameOver)
        {
            GameOver();
        }
    }

    void Restart()
    {
        if (gameOver && Input.GetKey(KeyCode.Mouse0))
        {
            StartCoroutine("SpawnRandom");
            textBot.text = "";
            gameOver = false;

            score = 0;
            fallSpeed = 2;
            timeToSpawn = spawnTemp;
        }
    }

    void GameOver()
    {
        StopCoroutine("SpawnRandom");
        textBot.text = "Tap to Play";
        Restart();
    }
}
