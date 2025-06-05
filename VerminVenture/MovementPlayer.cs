using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;          // The speed at which the character moves
    [SerializeField] private float jumpForce = 1f;         // The force with which the character jumps
    [SerializeField] private float climbSpeed = 3f;         // The speed at which the character climbs
    [SerializeField] private LayerMask whatIsClimbable;     // The layer mask for climbable objects
    [SerializeField] private Transform groundCheck;         // A transform that checks for ground underneath the character
    [SerializeField] private float groundCheckRadius = 0.1f; // The radius of the ground check
    [SerializeField] private LayerMask whatIsGround;         // The layer mask for ground objects
    [SerializeField] private AudioSource audioSourceJump;

    private Rigidbody2D rb;        // The Rigidbody2D component of the character
    private Animator anim;         // The Animator component of the character
    private bool facingRight = true;   // Whether or not the character is facing right
    private bool isGrounded;        // Whether or not the character is grounded
    private bool isClimbing;        // Whether or not the character is climbing
    private float horizontalInput;  // The horizontal input axis value
    private float verticalInput;    // The vertical input axis value
    private bool facingUp = true;


    bool isDead = false;

    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    PlayerStates m_CurrentState;
    public enum PlayerStates
    {
        IDLE,
        WALK,
        CLIMB,
        JUMP,
        DEATH
    }

    public PlayerStates CurrentState
    {
        set
        {
            m_CurrentState = value;
            switch (m_CurrentState)
            {
                case PlayerStates.IDLE:
                    anim.Play("Idle");
                    break;
                case PlayerStates.WALK:
                    anim.Play("Movement");
                    break;
                case PlayerStates.CLIMB:
                    anim.Play("Climb");
                    break;
                case PlayerStates.JUMP:
                    anim.Play("Idle");
                    break;
                case PlayerStates.DEATH:
                    anim.Play("Death");
                    break;
            }
        }

        }
    

        private void Update()
        {
        // Get the horizontal input axis value
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Get the vertical input axis value
        verticalInput = Input.GetAxisRaw("Vertical");

        // Check if the character is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        // Set the climbing flag based on whether or not the character is overlapping a climbable object
        isClimbing = Physics2D.OverlapCircle(transform.position, 0.2f, whatIsClimbable);


        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("verticalSpeed", rb.velocity.y);
        anim.SetBool("isClimbing", isClimbing);
     
        // Flip the character sprite based on the horizontal input axis value
        if (horizontalInput > 0 && !facingRight && !isDead)
        {
            Flip();
        }
        else if (horizontalInput < 0 && facingRight && !isDead)
        {
            Flip();
        }
        if(horizontalInput == 0 && !isClimbing && !isDead)
        {
            CurrentState = PlayerStates.IDLE;
        }
        else if (!isClimbing && !isDead)
        {
            CurrentState = PlayerStates.WALK;
        }

        // If the character is climbing, move them up or down based on the vertical input axis value
        if (isClimbing && !isDead)
        {
            rb.velocity = new Vector2(rb.velocity.x, verticalInput * climbSpeed);
            rb.gravityScale = 0;
            CurrentState = PlayerStates.CLIMB;
            if (verticalInput > 0 && !facingUp)
            {
                FlipVertical();
            }
            else if (verticalInput < 0 && facingUp)
            {
                FlipVertical();
            }

        }
        else
        {
            if(!facingUp)
            { FlipVertical(); }
            rb.gravityScale = 1;
        }

        // If the character is grounded and the jump button is pressed, make them jump
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x/2, jumpForce/2);
            audioSourceJump.Play();
        }
    }

    private void FixedUpdate()
    {
        if (!isDead)
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    private void Flip()
    {
        // Flip the character sprite and update the facingRight flag
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }  

    private void FlipVertical()
    {
        facingUp = !facingUp;
        transform.Rotate(180f, 0f, 0f);
    }

    public void PlayDead()
    {
        isDead = true;
        rb.velocity = new Vector2(0, 0);
        CurrentState = PlayerStates.DEATH;

    }
}
