using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 3f;
    private float xMovement;
    public float jumpForce = 10f;
    private bool isJumping = true;
    private int jumpCount = 0;  //no of jumps performed already
    public int allowedJumpCount = 2;
    public float fallMultiplier = 2.5f;  //how faster the object should fall

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if object is grounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            jumpCount = 0;
        }
    }

    void jump()
    {
        //should jump if not jumping already or allowed jumps not exceeded
        if (!isJumping || jumpCount <= allowedJumpCount)
        {
            isJumping = true;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void Start() => rb = GetComponent<Rigidbody2D>();

    private void Update()
    {
        xMovement = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            jumpCount++;
            jump();
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(xMovement, 0f), ForceMode2D.Impulse); //force for horizontal movement

        //if the object starts falling, then increase gravityScale for it
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
    }
}