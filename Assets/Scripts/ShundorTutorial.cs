using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShundorTutorial : MonoBehaviour
{
    [SerializeField]
    public GameObject menu;

    public void Back()
    {
        this.gameObject.SetActive(false);
        menu.SetActive(true);
    }
}
