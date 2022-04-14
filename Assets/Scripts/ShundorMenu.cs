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
        sp.transform.position = new Vector3(0, 1, 0);
        Instantiate(brishti, sp.transform);
    }
}
