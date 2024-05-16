using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] recuerdos;
    public Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        exitButton = exitButton.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.Q))
        {
            exitButton.onClick.Invoke();
        }
    }

    public void OnApplicationQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
    public void NextScene(string nombre)
    {
        SceneManager.LoadScene(nombre); 
    }

   /* public void QuitScene()
    {
        Application.Quit();
    }*/


}
