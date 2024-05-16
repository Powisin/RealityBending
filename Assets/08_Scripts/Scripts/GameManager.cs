using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] recuerdos;
    public Button exitButton;
    [SerializeField] GameObject videoBoss;

    [Header("Eleccione")]
    [SerializeField] GameObject[] pregunta;
    [SerializeField] int points;


    // Start is called before the first frame update
    void Start()
    {
        exitButton = exitButton.GetComponent<Button>();
        points = 0;
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

    public void CerrarScreamer()
    {
        GetComponent<GameRespawn>().Scream.SetActive(false);
    }

    public void CerrarVideoBoss()
    {
        videoBoss.SetActive(false);
    }

   /* public void QuitScene()
    {
        Application.Quit();
    }*/

    public void PreguntaMal1(int i)
    {
        i = 0;
        if (pregunta[i] == pregunta[0])
        {
            points = points + 10;
            pregunta[1].SetActive(true);
            pregunta[0].SetActive(false);
        }
    }
    public void PreguntaMal2(int i)
    {
        i = 1;
        if (pregunta[i] == pregunta[1])
        {
            points = points + 10;
            pregunta[2].SetActive(true);
            pregunta[1].SetActive(false);
        }
    }
    public void PreguntaMal3(int i)
    {
        i = 2;
        if (pregunta[i] == pregunta[2])
        {
            points = points + 10;
            pregunta[3].SetActive(true);
            pregunta[2].SetActive(false);
        }
    }
    public void Preguntaañañin1(int i)
    {
        i = 0;
        if (pregunta[i] == pregunta[0])
        {
            points = points + 15;
            pregunta[1].SetActive(true);
            pregunta[0].SetActive(false);
        }
    }
    public void PreguntaAñañin2(int i)
    {
        i = 1;
        if (pregunta[i] == pregunta[1])
        {
            points = points + 15;
            pregunta[2].SetActive(true);
            pregunta[1].SetActive(false);
        }
    }
    public void PreguntaAñañin3(int i)
    {
        i = 2;
        if (pregunta[i] == pregunta[2])
        {
            points = points + 15;
            pregunta[3].SetActive(true);
            pregunta[2].SetActive(false);
        }
    }
    public void PreguntaBine1(int i)
    {
        i = 0;
        if (pregunta[i] == pregunta[0])
        {
            points = points + 45;
            pregunta[1].SetActive(true);
            pregunta[0].SetActive(false);
        }
    }
    public void PreguntaBien2(int i)
    {
        i = 1;
        if (pregunta[i] == pregunta[1])
        {
            points = points + 45;
            pregunta[2].SetActive(true);
            pregunta[1].SetActive(false);
        }
    }
    public void PreguntaBien3(int i)
    {
        i = 2;
        if (pregunta[i] == pregunta[2])
        {
            points = points + 45;
            pregunta[3].SetActive(true);
            pregunta[2].SetActive(false);
        }
    }
    public void Final()
    {
        if (points < 40)
        {
            SceneManager.LoadScene(4);
        }
        else if (points == 45)
        {
            SceneManager.LoadScene(6);
        }
        else
        {
            SceneManager.LoadScene(7);
        }
    }
}
