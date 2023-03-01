using UnityEngine;

public class Empty : MonoBehaviour
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
                velocity.y += Physics2D.gravity.y * Time.fixedDeltaTime * 0.01f;
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

    }
    private void OnCollisionExit2D(Collision2D collision)
    {

            isGrounded = false;
  
    }
    void a()
    {
        verticalInput = Input.GetAxis("Jump");

        if (!isGrounded)
        {
            velocity.y = 0;

            if (verticalInput != 0)
            {
                if (isGrounded)
                {
                    velocity.y = Mathf.Sqrt(jumpHeight);
                }

            }
        }
    }
}

