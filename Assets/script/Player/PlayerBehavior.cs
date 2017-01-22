using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : CharacterBase {

    [SerializeField]
    protected float currentEnergy;
    [SerializeField]
    protected float maxEnergy;
    [SerializeField]
    protected float energyRegen;

	// Use this for initialization
	void Start () {
        this.currentLife = this.maxLife;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (maxEnergy <= currentEnergy)
            currentEnergy = maxEnergy;
        if (currentEnergy < maxEnergy)
            currentEnergy += energyRegen;
	}

    public float getEnergy()
    {
        return currentEnergy;
    }

    public float getMaxEnergy()
    {
        return maxEnergy;
    }

    public bool useEnergy(int energy)
    {
        if (energy <= currentEnergy)
        {
            currentEnergy -= energy;
            return true;
        }
        return false;
    }
}
