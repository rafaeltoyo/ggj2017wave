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
    BoxCollider2D colliderPlayer;
    Vector3 positionRight;
    Vector3 positionLeft;
   

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
        colliderPlayer = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        #region Movimentação

        if (Input.GetKey(KeyCode.D))
        {
            rigidbodyPlayer.velocity = new Vector2(playerSpeed, rigidbodyPlayer.velocity.y);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigidbodyPlayer.velocity = new Vector2(-playerSpeed, rigidbodyPlayer.velocity.y);
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKey(KeyCode.S) && isPlataform())
        {
            colliderPlayer.isTrigger = true;
        }
        else
        {
            colliderPlayer.isTrigger = false;
        }

        #endregion

        #region Pulo

        if (Input.GetKeyDown(KeyCode.W))
        {
            rigidbodyPlayer.AddForce(new Vector2(0, playerJumpForce * Time.deltaTime));
        }

        #endregion

    }
    
    public bool isPlataform()
    {
        Vector3 originCenter = transform.position;
        originCenter.y -= colliderPlayer.bounds.size.y / 2 + 0.01f;

        RaycastHit2D centralHit = Physics2D.Raycast(originCenter, Vector3.down, 0.1f);

        if (centralHit.collider.gameObject.tag.Equals("Plataform"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}
