using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

	public GameObject creditosProgramador;
    public GameObject creditosArtista;
    public GameObject creditosGameDesigner;
    public GameObject creditosStory;
    public GameObject creditosSound;

    int i = 0;
    float currentTime = 0;
    float maxDuration = 3;
    GameObject[] creditos;

    // Use this for initialization
    void Start () {
        creditosArtista.SetActive(true);
        creditosGameDesigner.SetActive(false);
        creditosProgramador.SetActive(false);
        creditosSound.SetActive(false);
        creditosStory.SetActive(false);

        creditos = new GameObject[5];

        creditos[0] = creditosArtista;
        creditos[1] = creditosGameDesigner;
        creditos[2] = creditosProgramador;
        creditos[3] = creditosSound;
        creditos[4] = creditosStory;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.anyKeyDown)
            i = 4;

        currentTime += Time.deltaTime;
        
        if (currentTime >= maxDuration)
        {
            if (i >= 4)
            {
                // terminou 
                SceneManager.LoadScene("menu");
            }
            currentTime = 0;
            creditos[i++].SetActive(false);
            creditos[i].SetActive(true);
        }
    }
    
}
