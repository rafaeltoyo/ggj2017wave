using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBehavior : CharacterBase
{

    [SerializeField]
    float velocidade;

    bool goLeft = true;
    Rigidbody2D rigidBody;
    [SerializeField]
    string[] TagsParaIgnorar;
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
            enemyTransform.rotation = new Quaternion(0, 0, 0, 0);
            rigidBody.velocity = new Vector2(-velocidade, rigidBody.velocity.y);
        }
        else
        {
            enemyTransform.rotation = new Quaternion(0, 180, 0, 0);
            rigidBody.velocity = new Vector2(velocidade, rigidBody.velocity.y);
        }
        if (goLeft && !possivelIrEsquerda())
            goLeft = false;
        else if(!goLeft && !possivelIrDireita())
            goLeft = true;
    }

    public bool possivelIrDireita()
    {
        Vector3 origem = transform.position;
        origem.y -= (characterCollider2.bounds.size.y / 2 + 0.01f);
        Vector3 origemChao = origem;
        origemChao.x += (characterCollider2.bounds.size.x / 2 + 0.15f);
        Vector3 origemCentro = transform.position;
        origemCentro.x += characterCollider2.bounds.size.x / 2 + 0.01f;
        Vector3 origemBaixo = origemCentro;
        origemBaixo.y -= characterCollider2.bounds.size.y / 2;
        Vector3 origemSuperior = origemCentro;
        origemSuperior.y += characterCollider2.bounds.size.y / 2;

        Debug.DrawRay(origemChao, Vector3.down, Color.red);
        Debug.DrawRay(origemBaixo, Vector3.right, Color.yellow);
        Debug.DrawRay(origemCentro, Vector3.right, Color.yellow);
        Debug.DrawRay(origemSuperior, Vector3.right, Color.yellow);

        RaycastHit2D hitChao = Physics2D.Raycast(origemChao, Vector3.down, 0.1f);
        RaycastHit2D hitInferior = Physics2D.Raycast(origemBaixo, Vector3.right, 0.1f);
        RaycastHit2D hitCentral = Physics2D.Raycast(origemCentro, Vector3.right, 0.1f);
        RaycastHit2D hitSuperior = Physics2D.Raycast(origemSuperior, Vector3.right, 0.1f);

        if (hitChao.transform != null
         && (hitInferior.transform == null
         && hitCentral.transform == null
         && hitSuperior.transform == null))
        {
            return true;
        }
        else
        {
            if (hitChao.transform != null
             && (validarTag(hitInferior)
             && validarTag(hitCentral)
             && validarTag(hitSuperior)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool possivelIrEsquerda()
    {
        Vector3 origem = transform.position;
        origem.y -= (characterCollider2.bounds.size.y / 2 + 0.01f);
        Vector3 origemChao = origem;
        origemChao.x -= (characterCollider2.bounds.size.x / 2 + 0.15f);
        Vector3 origemCentro = transform.position;
        origemCentro.x -= characterCollider2.bounds.size.x / 2 + 0.01f;
        Vector3 origemBaixo = origemCentro;
        origemBaixo.y -= characterCollider2.bounds.size.y / 2;
        Vector3 origemSuperior = origemCentro;
        origemSuperior.y += characterCollider2.bounds.size.y / 2;

        Debug.DrawRay(origemChao, Vector3.down, Color.red);
        Debug.DrawRay(origemBaixo, Vector3.left, Color.yellow);
        Debug.DrawRay(origemCentro, Vector3.left, Color.yellow);
        Debug.DrawRay(origemSuperior, Vector3.left, Color.yellow);

        RaycastHit2D hitChao = Physics2D.Raycast(origemChao, Vector3.down, 0.1f);
        RaycastHit2D hitInferior = Physics2D.Raycast(origemBaixo, Vector3.left, 0.1f);
        RaycastHit2D hitCentral = Physics2D.Raycast(origemCentro, Vector3.left, 0.1f);
        RaycastHit2D hitSuperior = Physics2D.Raycast(origemSuperior, Vector3.left, 0.1f);

        if (hitChao.transform != null
         && (hitInferior.transform == null
         && hitCentral.transform == null
         && hitSuperior.transform == null))
        {
            return true;
        }
        else
        {
            if (hitChao.transform != null
             && (validarTag(hitInferior)
             && validarTag(hitCentral)
             && validarTag(hitSuperior)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool validarTag(RaycastHit2D hit)
    {
        string tag = (hit.transform != null ? hit.collider.gameObject.tag : string.Empty);
        foreach (string iTag in TagsParaIgnorar)
        {
            if (iTag.Equals(tag))
            {
                return true;
            }
        }
        return false;
    }

}
