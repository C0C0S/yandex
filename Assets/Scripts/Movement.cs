using UnityEngine;

public class Movement : MonoBehaviour
{
    public float walkAcceleration = 105f;
    public float groundDeceleration = 100f;
    public float speed = 20f;
    public float jumpHeight = 100f;
    private float horizontalInput = 0f;
    private float verticalInput = 0f;
    private Vector2 velocity;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded = false;
    private BoxCollider2D boxCollider;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        verticalInput = Input.GetAxis("Jump");

        if (isGrounded)
        {
            velocity.y = 0;

            if (verticalInput != 0)
            {
                if (isGrounded)
                {
                    velocity.y = Mathf.Sqrt(2 * jumpHeight);
                }

            }
        }

        if (TryGetComponent<DistanceJoint2D>(out DistanceJoint2D joint))
        {
            if (joint.enabled == false && isGrounded == false)
            {
                velocity.y += Physics2D.gravity.y * Time.deltaTime;
            }
        }

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
        transform.Translate(velocity * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        //Debug.LogError(isGrounded);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        //Debug.LogError(isGrounded);
    }
}
