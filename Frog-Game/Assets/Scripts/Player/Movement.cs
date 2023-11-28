using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float movement;
    [SerializeField] public const int SPEED = 5;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] const float JUMPFORCE = 850.0f;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] bool isGrounded = true;

    //[SerializeField] Animator animator;
    private Animator frogAnimation;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();

        frogAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;

            frogAnimation.SetBool("IsHopping", movement > 0 || movement < 0);
    }

    //can be called potentially many times per frame -- best for physics
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(movement * SPEED, rigid.velocity.y);

        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
        {
            Flip();
        }
        if (jumpPressed && isGrounded)
            Jump();
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    private void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, JUMPFORCE));
        jumpPressed = false;
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            jumpPressed = false;
        }
    }
}