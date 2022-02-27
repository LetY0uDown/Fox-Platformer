using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isFacingRight = true;
    private float moveInput;

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private Animator anim;
    
    [SerializeField] private LayerMask whatIsGround;

    public float speed = 250f;
    public float jumpForce = 12f;
    public float climbSpeed = 100f;    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (PauseMenu.isGamePaused)
            return;

        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && CanJump())
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        anim.SetFloat("Speed", Mathf.Abs(moveInput));

        if (moveInput > 0 && !isFacingRight) Flip();
        if (moveInput < 0 && isFacingRight) Flip();        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * speed * Time.fixedDeltaTime, rb.velocity.y);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector2(rb.velocity.x, climbSpeed * Time.deltaTime);
                anim.SetBool("IsClimbing", true);
            }
            else
                anim.SetBool("IsClimbing", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("IsClimbing", false);
    }

    private bool CanJump()
    {
        float extraDistance = .1f;

        Vector2 rightPos = new Vector2(bc.bounds.center.x - bc.bounds.extents.x, bc.bounds.center.y);
        Vector2 leftPos = new Vector2(bc.bounds.center.x + bc.bounds.extents.x, bc.bounds.center.y);

        RaycastHit2D rightRaycastHit = Physics2D.Raycast(rightPos, Vector2.down, bc.bounds.extents.y + extraDistance, whatIsGround);
        RaycastHit2D leftRaycastHit = Physics2D.Raycast(leftPos, Vector2.down, bc.bounds.extents.y + extraDistance, whatIsGround);

        return rightRaycastHit.collider != null || leftRaycastHit.collider != null;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
