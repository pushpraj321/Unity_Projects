using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator ani;
    private float dirX;
    private SpriteRenderer sprit;

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private float speed = 7f;
    [SerializeField] private float jump = 14f;

    private enum movementstate{idling , running , jumping , falling}

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        sprit = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed , rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded() )
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x , jump);
        }

        updateAnimationState();

    }

    private void updateAnimationState()
    {
        movementstate state;
        if (dirX < 0)
        {
            state = movementstate.running;
            sprit.flipX = true;
        }

        else if (dirX > 0)
        {
            state = movementstate.running;
            sprit.flipX = false;
        }

        else
        {
            state = movementstate.idling;
        }
        if (rb.velocity.y > 0.1f)
        {
            state = movementstate.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = movementstate.falling;
        }

        ani.SetInteger("state",(int)state);

    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center , coll.bounds.size , 0f , Vector2.down , .1f , jumpableGround);
    }
}
