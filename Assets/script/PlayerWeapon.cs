using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

    [SerializeField]
    GameObject projectile;
    [SerializeField]
    GameObject playerWeapon;

    //PlayerBehaviour playerData;

    Vector3 angle;

    float weaponDistance;

    void Start()
    {
        // playerData = GetComponentInParent<PlayerBehaviour>();
        weaponDistance = 0.3f; // Raio de distancia entre a arma e o player
    }

    // Update is called once per frame
    void Update() {
        updateWeaponPosition();

        if(Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(projectile, playerWeapon.transform.position, Quaternion.Euler(0,0,Mathf.Atan2(angle.y,angle.x) * Mathf.Rad2Deg));
        }
    }

    void calcAngle()
    {
        angle = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle /= Mathf.Sqrt(angle.x * angle.x + angle.y * angle.y);
    }
    void updateWeaponPosition()
    {
        calcAngle();
        // Arma do player rotacionar em direcao ao mouse
        playerWeapon.transform.localPosition = new Vector2(angle.x * weaponDistance, angle.y * weaponDistance);
    }
}
