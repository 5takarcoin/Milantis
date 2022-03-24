using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShundorMenu : MonoBehaviour
{
    public GameObject brishti;

    public GameObject sp;

    private void Start()
    {
        sp = GameObject.Find("Spawner");
    }

    public void khel()
    {
        Instantiate(brishti, sp.transform);
    }
}
