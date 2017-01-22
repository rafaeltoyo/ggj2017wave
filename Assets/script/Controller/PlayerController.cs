using UnityEngine;
using System.Collections;

public class PlayerController : CharacterBase
{
    // Movement
    [SerializeField]
    float playerSpeed;
    [SerializeField]
    float playerJumpForce;

    // Movement
    [SerializeField]
    Animator playerAnimator;
    Rigidbody2D rigidbodyPlayer;
    CapsuleCollider2D colliderPlayer;
    Vector3 positionRight;
    Vector3 positionLeft;
    bool IsGrounded = false;

    Transform groundcheck;

    #region Repositorio

    //Vector2 inputDirection = new Vector2(Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime, 0);

    //if (freeRight())
    //{
    //rigidbodyPlayer.velocity = new Vector2(inputDirection.x * playerSpeed, rigidbodyPlayer.velocity.y);
    //}

    #endregion

    // Use this for initialization
    void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody2D>();
        colliderPlayer = GetComponent<CapsuleCollider2D>();
        groundcheck = transform.Find("Groundcheck");
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        #region Pulo

        IsGrounded = Physics2D.Linecast(transform.position, groundcheck.position, 1 << LayerMask.NameToLayer("Ground"));
        playerAnimator.SetBool("grounded", IsGrounded);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.1f); ;
        if (Input.GetKey(KeyCode.W) && IsGrounded)
        {
            rigidbodyPlayer.AddForce(new Vector2(0, playerJumpForce));
        }

        #endregion

        #region Movimentação

        if (Input.GetKey(KeyCode.D))
        {
            rigidbodyPlayer.velocity = new Vector2(playerSpeed, rigidbodyPlayer.velocity.y);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbodyPlayer.velocity = new Vector2(-playerSpeed, rigidbodyPlayer.velocity.y);
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (rigidbodyPlayer.velocity.x != 0) playerAnimator.SetBool("moving", true);
        else playerAnimator.SetBool("moving", false);

        playerAnimator.SetFloat("velY", rigidbodyPlayer.velocity.y);

        //if (Input.GetKey(KeyCode.S) && isPlataform())
        //{
        //    colliderPlayer.isTrigger = true;
        //}
        //else
        //{
        //    colliderPlayer.isTrigger = false;
        //}

            #endregion
    }
    
    //public bool isPlataform()
    //{
    //    Vector3 originCenter = transform.position;
    //    originCenter.y -= colliderPlayer.bounds.size.y / 2 + 0.01f;

    //    RaycastHit2D centralHit = Physics2D.Raycast(originCenter, Vector3.down, 0.2f);
    //    Debug.DrawRay(originCenter, Vector3.down);

    //    if (centralHit.collider.gameObject.tag.Equals("Plataform"))
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    void OnCollisionEnter(Collision collisionInfo)
    {
        IsGrounded = true;
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        IsGrounded = false;
    }


}
