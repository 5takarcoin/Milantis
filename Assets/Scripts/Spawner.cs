using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public GameObject spawnedItems;

    public GameObject[] types;
    public float timeToSpawn;
    public float fastestSpawn;

    public float multiplier;
    public float fallSpeed = 2;

    public int score = 0;
    public bool gameOver;

    public TextMeshProUGUI text;
    public TextMeshProUGUI textBot;
    public TextMeshProUGUI congrats;
    public TextMeshProUGUI current;
    public TextMeshProUGUI showScore;
    public GameObject tutorial;

    public TextMeshProUGUI scoreInOpt;

    public float spawnTemp;

    public GameObject panel;
    public TextMeshProUGUI buttonText;

    public bool playDone;

    public int highScore;
    public bool music;

    public GameObject pauseMenu;
    public GameObject pauseB;

    int agerHS;

    public AudioSource ano;

    GameObject spit;

    Getter gttt;

    void Start()
    {
        GetData();

        gttt = GameObject.Find("Getter").GetComponent<Getter>();
        ano.mute = !music;
        congrats.gameObject.SetActive(false);
        tutorial.SetActive(true);
        showScore.text = highScore.ToString();
        text.text = "";
        text.text = "";
        gameOver = true;
        playDone = false;
        buttonText.text = "Play";
        CheckGameOver();
    }

    public void ResetScore()
    {
        highScore = 0;
        SaveSystem.Save(this);
    }

    public void PutData(int lastScore)
    {       
        if (lastScore > highScore)
        {
            agerHS = highScore;
            highScore = lastScore;
            showScore.text = highScore.ToString();
            congrats.gameObject.SetActive(true);
            current.gameObject.SetActive(false);
        }
        else
        {
            if(highScore != 0) current.gameObject.SetActive(true);
        }

        SaveSystem.Save(this);
    }

    public void GetData()
    {
        SaveHighScore save = SaveSystem.Load();

        if (save != null)
        {
            highScore = save.highScore;
            music = save.music;
        }
        else
        {
            highScore = 0;
            music = true;
        }
    }

    private void Update()
    {
        scoreInOpt.text = highScore.ToString();

        CheckGameOver();

        if (playDone)
        {
            text.gameObject.SetActive(true);
            text.text = score.ToString();
        }
        else
        {
            text.gameObject.SetActive(false);
        }

        if (!gameOver)
        {
            timeToSpawn -= Time.deltaTime * multiplier;
            if (timeToSpawn < fastestSpawn) timeToSpawn = fastestSpawn;

            fallSpeed += Time.deltaTime * 0.02f;
        }
    }

    IEnumerator SpawnRandom()
    {
        int num = Random.Range(0, types.Length);

        Instantiate(types[num], transform).transform.parent = spit.transform;

        yield return new WaitForSeconds(timeToSpawn);

        StartCoroutine("SpawnRandom");
    }

    void CheckGameOver()
    {
        //if (gameOver)
        //{
        //    GameOver();
        //}
        if (gameOver) pauseB.SetActive(false);

        if (playDone) panel.SetActive(gameOver);
        else panel.SetActive(false);
        RectTransform rt = text.GetComponent<RectTransform>();
        Vector3 eda = rt.localPosition;
        //Debug.Log(eda);
        eda.y = gameOver ? -50f: 300f;
        //Debug.Log(eda);
        rt.localPosition = eda;
    }

    public void Restart()
    {
        ResumeThis();
        GameOver();

        if (!playDone)
        {
            playDone = true;
            buttonText.text = "Retry";
        }

        pauseB.SetActive(true);
        congrats.gameObject.SetActive(false);
        current.gameObject.SetActive(false);
        tutorial.SetActive(false);
        textBot.text = "";
        gameOver = false;

        score = 0;
        fallSpeed = 3;
        timeToSpawn = spawnTemp;

        spit = Instantiate(spawnedItems, transform);
        StartCoroutine("SpawnRandom");
    }

    public void GameOver()
    {
        Destroy(spit);
        PutData(score);
        StopCoroutine("SpawnRandom");
        textBot.text = "Tap to Play";
    }

    public void PauseThis()
    {
        gttt.pause = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        pauseB.SetActive(false);
    }

    public void ResumeThis()
    {
        gttt.pause = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        pauseB.SetActive(true);
    }

}
