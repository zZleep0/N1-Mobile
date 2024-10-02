using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    //Menu Inicial

    public void ModoTempo()
    {
        SceneManager.LoadScene("Game");
    }

    public void ModoSobrevivencia()
    {
        SceneManager.LoadScene("Sobrevivencia");
    }

    public void Sair()
    {
        Application.Quit();
    }

    //In game

    public void Menu()
    {
        SceneManager.LoadScene("Menu inicial");
    }
}
