using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateEnergyBar : MonoBehaviour {

    public GameObject greenBar;

    private PlayerBehavior character;
    private float maxEnergy;
    private float curEnergy;

    // Use this for initialization
    void Start () {
        character = GetComponent<PlayerBehavior>();
        maxEnergy = character.getMaxEnergy();
        curEnergy = character.getEnergy();
	}
	
	// Update is called once per frame
	void Update () {
        curEnergy = character.getEnergy();
        greenBar.transform.localScale = new Vector3(curEnergy / maxEnergy, greenBar.transform.localScale.y, greenBar.transform.localScale.z);
    }
}
