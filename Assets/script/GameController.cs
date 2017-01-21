using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instancia;

    public void Start()
    {
        instancia = this;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !SceneManager.GetActiveScene().name.Equals("Menu"))
        {
            pausarJogo();
        }
    }

    public void clickNovoJogo()
    {
        SceneManager.LoadScene("TesteDiogo");
    }

    public void clickSair()
    {
        Application.Quit();
    }

    public void pausarJogo()
    {
        Time.timeScale = 0;
    }

    public void voltarJogo()
    {
        Time.timeScale = 1;
    }
}
