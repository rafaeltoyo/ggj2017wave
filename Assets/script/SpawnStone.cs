using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStone : MonoBehaviour {

    public GameObject prefab;
    private GameObject stone;
    private float resetTime;

	// Use this for initialization
	void Start () {
        resetTime = 4f;
        spawn();
	}
	
	// Update is called once per frame
	void Update () {
        resetTime -= Time.deltaTime;

        if(resetTime <= 0) {
            resetTime = 4f;
            spawn();
        }
	}

    void spawn() {
        stone = Instantiate(prefab, transform.position, Quaternion.Euler(0, 0, -90));
        stone.GetComponent<SpriteRenderer>().sortingOrder = 1;
        Destroy(stone, 1.5f);
    }
}
