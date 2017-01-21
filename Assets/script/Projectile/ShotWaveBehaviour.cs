using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotWaveBehaviour : MonoBehaviour {

    [SerializeField]
    GameObject projectile;

    // Use this for initialization
    void Start () {
        
        for(int i = -7; i <= 7; i++)
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + i*1));
        }
        Destroy(gameObject, 2);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
