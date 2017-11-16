using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float maxSpeed = 10f;
    private bool facingRight = true;
    public float jumpStr = 800f;

    private Rigidbody2D rb;
    private Animator anim;
    private bool grounded = false;
    public Transform groundCheck;
    private float groundRadius = 0.2f;
    public LayerMask whatIsGround;

	private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("isGrounded", grounded);
        anim.SetFloat("verticalSpeed", rb.velocity.y);
        if (!grounded)
            return;

        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(move));

        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
    }

    private void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isGrounded", false);
            rb.AddForce(new Vector2(0, jumpStr));
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
