using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instancia;
    [SerializeField]
    private GameObject TelaPause;
    [SerializeField]
    private GameObject Player;

    private bool jogoPausado = false;

    public void Start()
    {
        instancia = this;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !SceneManager.GetActiveScene().name.Equals("Menu") && !jogoPausado)
            pausarJogo();
        else if (Input.GetKeyDown(KeyCode.Escape) && jogoPausado)
            voltarJogo();

        if (Player != null)
        {
            PlayerBehavior playerBehavior = Player.GetComponent<PlayerBehavior>();
            if (playerBehavior != null && playerBehavior.tookhit)
                SceneManager.LoadScene("GameOver");
            
        }
    }

    public void clickNovoJogo()
    {
        SceneManager.LoadScene("Inicial");
    }

    public void clickSair()
    {
        Application.Quit();
    }

    public void pausarJogo()
    {
        jogoPausado = true;
        TelaPause.SetActive(true);
        Time.timeScale = 0;
    }

    public void voltarJogo()
    {
        jogoPausado = false;
        TelaPause.SetActive(false);
        Time.timeScale = 1;
    }
}
