using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MantisMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] public GameObject edgeA;
    [SerializeField] public GameObject edgeB;
    [SerializeField] public const int SPEED = 2;
    [SerializeField] bool isFacingRight = true;
    private Animator mantisAnimation;
    private Transform currentPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();

        if (mantisAnimation == null)
            mantisAnimation = GetComponent<Animator>();

        currentPoint = edgeB.transform;
    }

    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;

        if (currentPoint == edgeB.transform)
        {
            rigid.velocity = new Vector2(SPEED, 0);
        }
        else
        {
            rigid.velocity = new Vector2(-SPEED, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == edgeB.transform)
        {
            Flip();
            currentPoint = edgeA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == edgeA.transform)
        {
            Flip();
            currentPoint = edgeB.transform;
        }
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    
}