using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillCountDestroy : MonoBehaviour
{
    float timer;
    SpriteRenderer spriter;
    Rigidbody2D rigid;
    public Rigidbody2D target;


    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        target = GameObject.Find("PenguinPlayer").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3f)
        {
            Destroy(gameObject);
        }
    }

}
