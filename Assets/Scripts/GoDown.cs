using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDown : MonoBehaviour
{
    public float speed;

    public Sprite bodleDao;
    
    GameObject getter;

    Getter getget;
    Transform pospos;

    bool done;

    Spawner sp;

    SpriteRenderer gt;
    SpriteRenderer kochu;
    string saveName;

    public GameObject thisParticle;
    public GameObject otherParticle;

    private void Start()
    {
        getter = GameObject.Find("Getter");
        sp = GameObject.Find("Spawner").GetComponent<Spawner>();
        speed = sp.fallSpeed;
        gt = getter.GetComponent<SpriteRenderer>();

        //getget = getter.GetComponent<Getter>();

        pospos = getter.transform;
        kochu = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();

        saveName = kochu.sprite.name;
        kochu.sprite = bodleDao;

        Instantiate(otherParticle, sp.transform);


    }

    void Update()
    {
        if(!done) transform.position = new Vector3(0, transform.position.y - speed * Time.deltaTime, 0);
        
        if (sp.gameOver) Destroy(gameObject);

        if (!done)
        {
            if (transform.position.y < -4)
            {
                //SpriteRenderer nt = gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();

                if (saveName == gt.sprite.name)
                {
                    sp.score++;
                    Destroy(gameObject);

                    Instantiate(thisParticle, pospos);

                    //getget.currentParticle = thisParticle;
                    //getget.PlayParticle();
                    //Particle uprerta
                    //StartCoroutine("edaeda");
                }
                else
                {
                    sp.gameOver = true;
                    sp.GameOver();
                }

                done = true;
            }
 
        }
    }

    IEnumerator edaeda()
    {
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);

        //Particle nicherta
    }
}
