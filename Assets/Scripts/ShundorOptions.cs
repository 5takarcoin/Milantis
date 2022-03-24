using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShundorOptions : MonoBehaviour
{
    public GameObject soundSwitch;
    public GameObject music;
    public GameObject menu;
    public GameObject tuto;

    AudioSource ano;
    Spawner sp;

    private void Start()
    {
        ano = music.GetComponent<AudioSource>();
        sp = GameObject.Find("Spawner").GetComponent<Spawner>();
    }

    private void Update()
    {
        soundSwitch.SetActive(!sp.music);
        ano.mute = !sp.music;
    }

    public void Sound()
    {
        sp.music = !sp.music;
        SaveSystem.Save(sp);
    }

    public void Back()
    {
        this.gameObject.SetActive(false);
        menu.SetActive(true);
    }

    public void Help()
    {
        this.gameObject.SetActive(false);
        tuto.SetActive(true);
    }
}
