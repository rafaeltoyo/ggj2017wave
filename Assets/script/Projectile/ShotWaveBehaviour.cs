using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotWaveBehaviour : MonoBehaviour {

    [SerializeField]
    GameObject projectile;

    // Use this for initialization
    void Start () {
        Instantiate(projectile, transform.position, Quaternion.AngleAxis(30, transform.rotation.eulerAngles));
        Destroy(gameObject, 2);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
