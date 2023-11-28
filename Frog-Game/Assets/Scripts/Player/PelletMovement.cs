using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletMovement : MonoBehaviour
{
    [SerializeField] public const int SPEED = 10;
    [SerializeField] Rigidbody2D rigid;

    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();

        rigid.velocity = transform.right * SPEED;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //When Pellet hits enemies, invoke scripts
        Destroy(gameObject);
    }

}