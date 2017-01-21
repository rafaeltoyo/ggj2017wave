﻿using UnityEngine;
using System.Collections;

public class CharacterBase : MonoBehaviour {

    protected int currentLife;
    [SerializeField]
    protected int maxLife;

    public bool tookhit = false;

    protected BoxCollider2D characterCollider;

    void Awake ()
    {
        currentLife = maxLife;
    }

	// Use this for initialization
	void Start () {
        //characterCollider = GetComponent<BoxCollider2D>();
	}

    public int getLife() { return currentLife; }
    public int getMaxLife() { return maxLife; }

    public void onDamage (int damage)
    {
        if (currentLife <= damage)
            //morreu
            onDestroy();
        else
            currentLife -= damage;
    }

    public void onDestroy ()
    {
        if (tag == "Player")
        {
            tookhit = true;

            return;
        }
        // morreu
        Destroy(gameObject);
    }
}
