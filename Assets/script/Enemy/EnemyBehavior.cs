using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehavior : CharacterBase
{

    [SerializeField]
    protected float velocidade;
    [SerializeField]
    protected int dano;
    [SerializeField]
    protected string[] TagsParaIgnorar;


    // Use this for initialization
    void Start()
    {
        this.currentLife = this.maxLife;   
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

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            PlayerBehavior playerBehavior = coll.gameObject.GetComponent<PlayerBehavior>();
            playerBehavior.onDamage(dano);
        }
    }
}
