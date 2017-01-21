using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotWaveBehaviour : MonoBehaviour {

    [SerializeField]
    GameObject projectile;

    // Use this for initialization
    void Start () {
        Instantiate(projectile, transform.position, transform.rotation);
        Destroy(gameObject, 2);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
