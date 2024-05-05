using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement1 : MonoBehaviour
{
    public void CambiarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void QuitarEscea()
    {
        Application.Quit();
    }
}
