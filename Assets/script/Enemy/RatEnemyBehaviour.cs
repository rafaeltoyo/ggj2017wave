using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class RatEnemyBehaviour : EnemyBehavior
{

    bool goLeft = true;
    Rigidbody2D rigidBody;
    CapsuleCollider2D characterCollider2;
    Transform enemyTransform;

    // Use this for initialization
    void Start()
    {
        enemyTransform = GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();
        characterCollider2 = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (goLeft)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            rigidBody.velocity = new Vector2(-velocidade, rigidBody.velocity.y);
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
            rigidBody.velocity = new Vector2(velocidade, rigidBody.velocity.y);
        }
        // Flipar o personagem se possivel
        if (goLeft && checarFimDeCurso(-1))
            goLeft = false;
        else if (!goLeft && checarFimDeCurso(1))
            goLeft = true;
    }

    // direcao -1 = Dir / 1 = Esq
    public bool checarFimDeCurso(int direcao) // TRUE = FIM
    {
        Vector3 origemRaycast = transform.position;
        origemRaycast = new Vector3(origemRaycast.x + direcao * (characterCollider2.bounds.size.x / 2 + 0.1f), origemRaycast.y, origemRaycast.z);

        RaycastHit2D hitSuperior = Physics2D.Raycast(origemRaycast, Vector3.up, characterCollider2.bounds.size.y / 2 + 0.2f);
        RaycastHit2D hitInferior = Physics2D.Raycast(origemRaycast, Vector3.down, characterCollider2.bounds.size.y / 2 + 0.2f);
        RaycastHit2D hitFrente = Physics2D.Raycast(origemRaycast, new Vector3(direcao, 0, 0), 0.1f);

        Debug.DrawRay(origemRaycast, Vector3.up, Color.yellow);
        Debug.DrawRay(origemRaycast, Vector3.down, Color.yellow);
        Debug.DrawRay(origemRaycast, new Vector3(direcao, 0, 0), Color.yellow);

        if (hitSuperior.transform != null && !validarTag(hitSuperior))
            return true;
        if (hitInferior.transform == null || validarTag(hitInferior))
            return true;
        if (hitFrente.transform != null && !validarTag(hitFrente))
            return true;

        return false;
    }
}
