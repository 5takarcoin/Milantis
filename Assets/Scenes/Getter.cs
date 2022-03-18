using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Getter : MonoBehaviour
{
    public GameObject spawner;
    
    int numberOfColors;
    public int currentSprite;

    float coolDown = 0;
    public float coolDownTime = 0.1f;

    Spawner sp;

    void Start()
    {
        sp = spawner.GetComponent<Spawner>();

        numberOfColors = sp.types.Length;
        currentSprite = 0;
        DoThis();
    }

    void Update()
    {
        coolDown += Time.deltaTime;

        int temp = currentSprite;

        if(!sp.gameOver && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 yo = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (yo.x < 0)
            {
                currentSprite--;
                if (currentSprite < 0) currentSprite = numberOfColors - 1;
            }
            if (yo.x > 0)
            {
                currentSprite++;
                if (currentSprite == numberOfColors) currentSprite = 0;
            }
        }
        

        if(temp != currentSprite)
        {
            coolDown = 0;
            DoThis();
        }
    }

    private void DoThis()
    {
        GetComponent<SpriteRenderer>().sprite = sp.types[currentSprite].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;

        Transform tr = sp.types[currentSprite].transform.GetChild(0).GetComponent<Transform>();

        transform.position = tr.position;
        transform.localScale = tr.localScale;

        Vector3 tempo = transform.position;
        tempo.y -= 4;
        transform.position = tempo;

        transform.localScale *= 2;
    }
}
