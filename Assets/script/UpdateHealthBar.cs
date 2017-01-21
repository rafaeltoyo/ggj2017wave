using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHealthBar : MonoBehaviour {

    public GameObject greenBar;

    private CharacterBase character;
    private float maxHealth;
    private float curHealth;

    // Use this for initialization
    void Start () {
        character = GetComponent<CharacterBase>();
        maxHealth = character.getMaxLife();
        curHealth = character.getLife();
	}
	
	// Update is called once per frame
	void Update () {
        curHealth = character.getLife();
        greenBar.transform.localScale = new Vector3(curHealth / maxHealth, greenBar.transform.localScale.y, greenBar.transform.localScale.z);
    }
}
