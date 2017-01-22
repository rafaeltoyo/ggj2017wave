using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BatEnemyBehaviour : EnemyBehavior {

    Rigidbody2D rigidBody;
    Vector3 direction;
    int currentTime;
    int maxTime;

	// Use this for initialization
	void Start () {
        currentTime = 0;
        maxTime = 1000;
        rigidBody = GetComponent<Rigidbody2D>();
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        

        if (currentTime >= maxTime)
        {
            randomDirection();
        }

        Vector2 origemRaycast = new Vector2(transform.position.x + direction.x * 0.4f, transform.position.y + direction.y * 0.4f);

        RaycastHit2D hitFrente = Physics2D.Raycast(origemRaycast, direction, 0.1f);
        Debug.DrawRay(origemRaycast, direction, Color.red);

        if (hitFrente.transform != null && !validarTag(hitFrente))
        {
            currentTime = maxTime;
        }
        else
        {
            currentTime++;
            rigidBody.velocity = new Vector2(direction.x * velocidade, direction.y * velocidade/2);
        }
    }

    void randomDirection ()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        playerPosition = playerPosition - transform.position;
        playerPosition = playerPosition.normalized;

        direction = new Vector3(Random.Range(-1f,1f) + 1.5f*playerPosition.x, Random.Range(-1f, 1f) + 1.5f*playerPosition.y, 0f);
        direction = direction.normalized;
    }
}
