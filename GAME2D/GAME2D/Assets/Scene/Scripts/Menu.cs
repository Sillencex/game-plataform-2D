using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void novoJogo()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void Credito()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Controle()
    {
        SceneManager.LoadScene("Controles");
    }

    public void VoltandoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
