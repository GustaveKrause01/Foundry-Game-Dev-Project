using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float speed;
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject Ninja;

    public float jumpForce = 10f;
    public float jumpAngle = 50f;
    public bool isJumping = false;


    public float jumpControlLockTime = 0.5f;
    private float controlLockTimer = 0f;

    public Transform playerDirection; // use this to get the facing direction

    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    float vx;
    private float vy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // Determine direction (-1 for left, 1 for right)
        float direction = playerDirection.localScale.x >= 0 ? 1f : -1f;

        // Convert angle to radians
        float radians = jumpAngle * Mathf.Deg2Rad;

        // Calculate launch velocity components
        vx = Mathf.Cos(radians) * jumpForce * direction;
        vy = Mathf.Sin(radians) * jumpForce;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        if (horizontal != 0)
        {
            anim.SetBool("Runing", true);
        }
        else
        {
            anim.SetBool("Runing", false);
        }
        if (horizontal < 0)
        {
            Ninja.transform.localScale = new Vector2(-1.5f, 1.5f);
            Debug.Log("Left");
        }
        else if (horizontal > 0)
        {
            Ninja.transform.localScale = new Vector2(1.5f, 1.5f);
            Debug.Log("Right");
        }



        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isJumping)
        {
            PerformArcJump();
            DrawJumpArc(); // ← This line is new
        }

        if (isJumping)
        {
            controlLockTimer -= Time.deltaTime;
            if (controlLockTimer <= 0f)
            {
                isJumping = false; // regain control
                //OnDrawGizmosSelected();
            }
        }
        DrawJumpArc(); // ← This line is new
        if (isGrounded)
        {
            anim.SetBool("Jumping", false);
        }
        else if (!isGrounded && isJumping || !isGrounded && !isJumping)
        {
            anim.SetBool("Jumping", true);
        }

        if (!isJumping && isGrounded)
        {

            rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);

        }
        else if (!isJumping && !isGrounded)
        {
            anim.SetBool("Jumping", true);
            rb.linearVelocity = (new Vector2(horizontal + (vx / 6) * speed, rb.linearVelocity.y));
        }
    }

    void PerformArcJump()
    {
        Debug.Log("Jump");
        isJumping = true;
        anim.SetBool("Jumping", true);

        controlLockTimer = jumpControlLockTime;



        // Apply velocity
        rb.linearVelocity = new Vector2(vx * 1.1f, vy);
    }


    void DrawJumpArc()
    {
        Vector2 startPos = rb.position;
        float direction = playerDirection.localScale.x >= 0 ? 1f : -1f;
        float radians = jumpAngle * Mathf.Deg2Rad;

        // Initial launch velocity
        Vector2 velocity = new Vector2(Mathf.Cos(radians) * jumpForce * direction, Mathf.Sin(radians) * jumpForce);
        Vector2 gravity = Physics2D.gravity * rb.gravityScale;

        Vector2 previous = startPos;
        float timeStep = 0.1f;
        int maxSteps = 100;

        bool apexReached = false;
        float apexY = startPos.y + (Mathf.Pow(velocity.y, 2) / (2 * Mathf.Abs(gravity.y))); // Y at apex

        for (int i = 1; i <= maxSteps; i++)
        {
            float t = i * timeStep;

            // Simulate horizontal speed increase after apex
            if (!apexReached)
            {
                float currentY = startPos.y + velocity.y * t + 0.5f * gravity.y * t * t;
                if (currentY >= apexY - 0.1f) // Allow small threshold
                {
                    apexReached = true;
                    velocity.x *= 1.1f; // Slightly stretch the arc
                }
            }

            // Calculate next position
            Vector2 next = startPos + velocity * t + 0.5f * gravity * t * t;

            // Check if we'd land on something
            RaycastHit2D hit = Physics2D.Linecast(previous, next, groundLayer);
            if (hit.collider != null)
            {
                Debug.DrawLine(previous, hit.point, Color.green);
                Debug.DrawRay(hit.point, Vector2.up * 0.5f, Color.yellow); // Landing marker
                break;
            }

            Debug.DrawLine(previous, next, Color.red);
            previous = next;
        }
    }
}
