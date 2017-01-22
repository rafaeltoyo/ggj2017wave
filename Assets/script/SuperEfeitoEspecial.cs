using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperEfeitoEspecial : MonoBehaviour {

    [SerializeField]
    [Range(1,10)]
    float luminosidade;
    [SerializeField]
    [Range(0.1f, 1f)]
    float desvioLuminosidade;
    [SerializeField]
    [Range(0.05f,0.1f)]
    float desvioPosicao;

    Vector3 posicaoPadrao;

	// Use this for initialization
	void Start () {
        posicaoPadrao = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector3(posicaoPadrao.x+Random.Range(-desvioPosicao, desvioPosicao), posicaoPadrao.y+Random.Range(-desvioPosicao, desvioPosicao));
        GetComponent<Light>().intensity = Random.Range(luminosidade, luminosidade+desvioLuminosidade);
    }
}
