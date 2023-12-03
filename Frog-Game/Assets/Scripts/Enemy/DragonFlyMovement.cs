using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DragonflyMovement : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] Transform NextPos;
    int NextPosIndex;
    [SerializeField] float speed;
    // bool dragonflyHit = false;
    [SerializeField] bool isFacingRight = true;
    private Animator dragonflyAnimation;
    public int scorePoints = 0;
    // bool dragonflyHitEffect = false;

    [SerializeField] public float timer = 0f;
    [SerializeField] public float growthTime = 10f;
    [SerializeField] public float maxSize = 8f;
    [SerializeField] public bool isMaxSize = false;
    [SerializeField] GameObject controller;

    void Start()
    {
        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
        rigid = GetComponent<Rigidbody2D>();
        dragonflyAnimation = GetComponent<Animator>();
        NextPos = Positions[0];
        if (isMaxSize == false)
        {
            StartCoroutine(Grow());
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveDragonfly();
        dragonflyMaxed();
    }
    void MoveDragonfly()
    {
        if (transform.position == NextPos.position)
        {
            NextPosIndex++;
            if (NextPosIndex >= Positions.Length)
            {
                NextPosIndex = 0;
            }
            NextPos = Positions[NextPosIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, NextPos.position, speed * Time.deltaTime);
        }
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
    private IEnumerator Grow()
    {
        Vector2 startSize = transform.localScale;
        Vector2 maxScale = new Vector2(maxSize, maxSize);

        do
        {
            transform.localScale = Vector3.Lerp(startSize, maxScale, timer / growthTime);
            timer += Time.deltaTime;
            yield return null;
        }
        while (timer < growthTime);

        isMaxSize = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }

        if (collision.gameObject.CompareTag("Shoot"))
        {
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
            Destroy(collision.gameObject);
            Die();
        }
    }
    public void dragonflyHit()
    {
        Die();
        Invoke("dragonflyBehavior", 0.1f);

    }
    public void Die()
    {
        dragonflyAnimation.SetBool("IsHit", true);
        Destroy(gameObject, 0.3f);
    }
    public void dragonflyBehavior()
    {
        if (transform.localScale.x < 2.0f)
        {
            scorePoints = 10;
            Debug.Log("current points: " + scorePoints);
            controller.GetComponent<Scorekeeper>().AddPointsBonus();
        }
        else
        {
            scorePoints = 5;
            Debug.Log("current points: " + scorePoints);
            controller.GetComponent<Scorekeeper>().AddPoints();
        }
        controller.GetComponent<Scorekeeper>().AdvanceScene();
    }
    public void dragonflyMaxed()
    {
        if (isMaxSize == true)
        {
            dragonflyAnimation.SetBool("IsHit", true);
            Destroy(gameObject, 0.3f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}