using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerGameOver : MonoBehaviour {

    [SerializeField]
    float duracaoTela;

    bool flag = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        ControllerGameOver cont = Camera.main.GetComponent<ControllerGameOver>();
        cont.duracaoTela -= Time.deltaTime;
        if (cont.duracaoTela <= 0 && flag)
        {
            flag = false;
            SceneManager.LoadScene("Menu");
        }
	}
}
