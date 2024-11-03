using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerInfoManager;
public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    Rigidbody2D rigid;
    public float speed;
    SpriteRenderer spriter;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        speed = PlayerManager.Instance.myPlayer._moveSpeed/50;
    }

    // Update is called once per frame
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed;
        rigid.MovePosition(rigid.position + nextVec);
    }
    private void LateUpdate()
    {
        if(inputVec.x != 0)
        {
            spriter.flipX = inputVec.x > 0;
        }
    }
}
