using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Rigidbody2D rb2D;
    public float walkAcceleration;
    public float groundDeceleration;
    public float speed;
    public float jumpHeight;
    private float horizontalInput = 0f;
    private float verticalInput = 0f;
    private Vector2 velocity;
    private bool isGrounded = false;

    private void Update()
    {
        Jump();
        Move();
    }
    private void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            spriteRenderer.flipX = horizontalInput < 0f;
            velocity.x = Mathf.MoveTowards(velocity.x, speed * horizontalInput, Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, Time.deltaTime);
        }
        //transform.Translate(velocity * Time.deltaTime);
        rb2D.MovePosition(rb2D.position + new Vector2(velocity.x, velocity.y * Time.deltaTime));
    }
    private void Jump()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (isGrounded)
            {
                rb2D.AddForce(Vector3.up * jumpHeight * 100);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.name == "Square2 (1)")
        {
            isGrounded = true;
        }
        
        Debug.LogError(collision.collider);
        Debug.LogError(isGrounded);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "Square2 (1)")
        {
            isGrounded = false;
        }
        Debug.LogError(isGrounded);
    }
    
}
