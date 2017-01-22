using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField]
    GameObject[] creditos;

    int i = 0;
    float currentTime = 0;
    float maxDuration = 3;

    // Use this for initialization
    void Start()
    {
        foreach (GameObject item in creditos)
        {
            item.SetActive(false);
        }
        if (creditos.Length > 0)
            creditos[0].SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= maxDuration)
        {
            if (i >= creditos.Length - 1)
                SceneManager.LoadScene("Menu");
            
            currentTime = 0;
            creditos[i++].SetActive(false);
            creditos[i].SetActive(true);
        }
    }

}
