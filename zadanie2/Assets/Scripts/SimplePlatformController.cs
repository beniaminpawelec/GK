using UnityEngine;

public class SimplePlatformController : MonoBehaviour
{
    [HideInInspector] public bool FacingRight = true; //Infinite scroller we move in one direction
    [HideInInspector] public bool Jump = true;        // Has our character jumped?
    public float MoveForce = 365f;                    // movement Force multiplier
    public float MaxSpeed = 5f;                       // Max velocity
    public float JumpForce = 1000f;                   // y Velocity of Jumping
    public Transform GroundCheck;                     // Used to compute if our character is touching the ground.
                                                      // Essentially casting a ray downwards onto the ground plane

    private bool Grounded = false;                    // Are we on the ground or not?
    private Animator Anim;                            // Store our animations for our character
    private Rigidbody2D Rb2d;

    // For initialization
    void Awake()
    {
        Anim = GetComponent<Animator>();
        Rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Grounded = Physics2D.Linecast(
                    transform.position,
                    GroundCheck.position,
                    1 << LayerMask.NameToLayer("Ground")
                );

        if(Input.GetButtonDown("Jump") && Grounded)
        {
            Jump = true;
        }
    }

    // Function for turning our player left or right
    void Flip()
    {
        FacingRight = !FacingRight;
        var tempScale = transform.localScale;
        tempScale.x = -1;
        transform.localScale = tempScale;
    }

    void FixedUpdate()
    {
        var h = Input.GetAxis("Horizontal"); // h is a value 0 to 1
        Anim.SetFloat("Speed", Mathf.Abs(h)); // Set our animation speed to a value of h

        // Accelerate our character of they are under our max speed.
        if (h * Rb2d.velocity.x < MaxSpeed)
        {
            Rb2d.AddForce(Vector2.right * h * MoveForce);
        }

        // If we're greater than our max speed, then keep moving us oa max speed.
        if (Mathf.Abs(Rb2d.velocity.x) > MaxSpeed)
        {
            Rb2d.velocity = new Vector2(Mathf.Sign(Rb2d.velocity.x) * MaxSpeed, Rb2d.velocity.y);
        }

        // Turn our character to face the right direction.
        if (h > 0 && !FacingRight)
        {
            Flip();
        } else if (h < 0 && FacingRight)
        {
            Flip();
        }

        // If we are jumping, change the animation, add a force
        if (Jump)
        {
            Anim.SetTrigger("Jump");
            Rb2d.AddForce(new Vector2(0f, JumpForce));
            Jump = false;
        }
    }
}
