
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] Vector2 deathkick = new Vector2(10f, 10f);

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    bool isAlive = true;
    private Rigidbody2D body;
    private Animator anim;
    Vector2 moveInput;
    int health = 3;
    // Start is called before the first frame update
    private BoxCollider2D playerFeetCollider;

    //
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        speed = 15.0f;
        jumpSpeed = 20.0f;
        anim = GetComponent<Animator>();
        playerFeetCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive){
            return;
        }
        Run();
        FlipHorz();
        Fall();
        Die();
        IsGounded();
       
    }

    private void IsGounded(){
        //I fucking hate that im using this
        anim.SetBool("Grounded", playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")));
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value){
        if (!isAlive){
            return;
        }
        moveInput = value.Get<Vector2>();
    }

    void Run(){
        bool playerHasHSpeed = Mathf.Abs(body.velocity.x) > Mathf.Epsilon;

        Vector2 playerVelocity = new Vector2(moveInput.x*speed,body.velocity.y);
        body.velocity = playerVelocity;
        

        //anim.SetBool("isRunning", playerHasHSpeed);
        if(playerHasHSpeed){
            anim.SetInteger("AnimState", 1);
        } else {
            anim.SetInteger("AnimState", 0);
        }

    }

    void FlipHorz(){
        bool playerHasHSpeed = Mathf.Abs(body.velocity.x) > Mathf.Epsilon;
        if(playerHasHSpeed){
            transform.localScale = new Vector2 (Mathf.Sign(body.velocity.x), 1f);

        }
    }

    void Fall(){
        bool playerHasNegVSpeed = body.velocity.y < Mathf.Epsilon;
        if(playerHasNegVSpeed && !playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            anim.SetBool("isJumping", false); 
            anim.SetBool("isFalling", true);
            anim.SetFloat("AirSpeedY", body.velocity.y);
        } else {
            anim.SetBool("isFalling", false);
        }
    }

    void OnJump(InputValue value)
    {
        if (!isAlive){
            return;
        }
        if(!playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            return;
        }
       if(value.isPressed)
        {
            body.velocity = new Vector2(body.velocity.x/4, jumpSpeed);
            anim.SetBool("isJumping", true);
        } 
        
    }

    void OnAttack(InputValue value)
    {
        if (!isAlive){
            return;
        }
        if(value.isPressed){
           // anim.SetBool("isAttacking", true);
            anim.SetTrigger("Attack1");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log(enemy);
                Debug.Log("We Hit");
            }
            //isBlocking = true;
        }
        if(!value.isPressed){
          //  anim.SetBool("isAttacking", false);
            anim.ResetTrigger("Attack1");

            //isBlocking = false;
        }
    }

    void OnAttack2(InputValue value){
         if (!isAlive){
            return;
        }
        if(value.isPressed){
            anim.SetBool("isAttacking", true);
            anim.SetTrigger("Attack2");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("We Hit");
            }
            //isBlocking = true;
        }
        if(!value.isPressed){
            anim.SetBool("isAttacking", false);
            anim.ResetTrigger("Attack2");

            //isBlocking = false;
        }
    }

     void OnAttack3(InputValue value){
         if (!isAlive){
            return;
        }
        if(value.isPressed){
            //anim.SetBool("isAttacking", true);
            anim.SetTrigger("Attack3");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("We Hit");
            }
            //isBlocking = true;
        }
        if(!value.isPressed){
            //anim.SetBool("isAttacking", false);
            anim.ResetTrigger("Attack3");

            //isBlocking = false;
        }
    }

     void OnBlock(InputValue value){
        if (!isAlive){
            return;
        }
        if(value.isPressed){
            anim.SetBool("isBlocking", true);
            //isBlocking = true;
        }
        if(!value.isPressed){
            anim.SetBool("isBlocking", false);
            //isBlocking = false;
        }
    }

    void Die(){
        if(health == 0){
            isAlive = false;
            body.velocity = deathkick;
        }
    }

    void OnDrawGizmosSelected(){
        if(attackPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
