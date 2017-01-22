using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomMapLimit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            PlayerBehavior playerBehavior = coll.gameObject.GetComponent<PlayerBehavior>();
            playerBehavior.onDamage(100);
        }
    }
}
