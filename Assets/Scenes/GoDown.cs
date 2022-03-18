using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDown : MonoBehaviour
{
    public float speed;
    
    GameObject getter;

    bool done;

    Spawner sp;

    private void Start()
    {
        getter = GameObject.Find("Getter");
        sp = GameObject.Find("Spawner").GetComponent<Spawner>();
        speed = sp.fallSpeed;
    }

    void Update()
    {
        transform.position = new Vector3(0, transform.position.y - speed * Time.deltaTime, 0);

        if (!done)
        {
            if (transform.position.y < -2)
            {
                SpriteRenderer gt = getter.GetComponent<SpriteRenderer>();
                SpriteRenderer nt = gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();

                if (gt.sprite.name == nt.sprite.name)
                {
                    sp.score++;
                    Destroy(gameObject);
                }
                else
                {
                    sp.gameOver = true;
                }

                done = true;
            }
 
        }

        if (sp.gameOver) Destroy(gameObject);

        if (transform.position.y < -11f) Destroy(gameObject);

    }
}
