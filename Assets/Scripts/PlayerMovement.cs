
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool grounded;
    private Rigidbody2D body;
    private Animator anim;
    private float horz = 0f;
    // Start is called before the first frame update
    void Start()
    {
        speed = 15.0f;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horz = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horz*speed,body.velocity.y);
        if (Input.GetKey(KeyCode.Z) && grounded)
        {
            Jump();
        }
        if(horz > 0.01f)
        {
            transform.localScale = Vector3.one;
        } else if(horz < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKey(KeyCode.X))
        {
            Attack();
        }
        UpdateAnimState();
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    private void UpdateAnimState()
    {
        if (horz > 0f)
        {
            anim.SetBool("isRunning", true);
        }
        else if (horz < 0f)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        } 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    private void Attack()
    {
        
    }
}
