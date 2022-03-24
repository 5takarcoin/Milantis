using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShundorButton : MonoBehaviour
{
    Spawner sp;
    public GameObject kalo;
    public GameObject menu;
    public GameObject head;
    public GameObject srd;
    public GameObject options;

    public GameObject pauseB;
    public GameObject pauseMenu;

    private void Start()
    {
        sp = GameObject.Find("Spawner").GetComponent<Spawner>();
    }

    public void PlayButton()
    {
        sp.Restart();
        pauseB.SetActive(true);
        kalo.SetActive(false);
        menu.SetActive(false);
    }

    public void Home()
    {
        kalo.SetActive(true);
        menu.SetActive(true);
        sp.playDone = false;
        pauseMenu.SetActive(false);
        sp.GameOver();
        sp.ResumeThis();
        pauseB.SetActive(false);
    }

    public void AppQuito()
    {
        Application.Quit();
    }

    public void Options()
    {
        menu.SetActive(false);
        options.SetActive(true);
    }
}
