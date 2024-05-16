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

    public void PreguntaMal(int i)
    {
        i = 0;
        if (pregunta[i] = pregunta[0])
        {
            points = points + 10;
            pregunta[1].SetActive(true);
            pregunta[0].SetActive(false);
            i++;
        }
        if (pregunta[i] = pregunta[1])
        {
            points = points + 10;
            pregunta[2].SetActive(true);
            pregunta[1].SetActive(false);
            i++;
        }
        if (pregunta[i] = pregunta[2])
        {
            points = points + 10;
            pregunta[3].SetActive(true);
            pregunta[2].SetActive(false);
            i++;
        }
        if (pregunta[i] = pregunta[3] )
        {
            if (points < 40)
            {
                SceneManager.LoadScene(4);
            }
        }
    }

    public void PreguntaAñañin(int q)
    {
        q = 0;
        if (pregunta[q] = pregunta[0])
        {
            points = points + 15;
            pregunta[1].SetActive(true);
            pregunta[0].SetActive(false);
            q++;
        }
        if (pregunta[q] = pregunta[1])
        {
            points = points + 15;
            pregunta[2].SetActive(true);
            pregunta[1].SetActive(false);
            q++;
        }
        if (pregunta[q] = pregunta[2])
        {
            points = points + 15;
            pregunta[3].SetActive(true);
            pregunta[2].SetActive(false);
            q++;
        }
        if (pregunta[q] = pregunta[3])
        {
            if (points <= 45)
            {
                SceneManager.LoadScene(7);
            }
        }
    }

    public void PreguntaBuena(int w)
    {
        w = 0;
        if (pregunta[w] = pregunta[0])
        {
            points = points + 45;
            pregunta[1].SetActive(true);
            pregunta[0].SetActive(false);
            w++;
        }
        if (pregunta[w] = pregunta[1])
        {
            points = points + 45;
            pregunta[2].SetActive(true);
            pregunta[1].SetActive(false);
            w++;
        }
        if (pregunta[w] = pregunta[2])
        {
            points = points + 45;
            pregunta[3].SetActive(true);
            pregunta[2].SetActive(false);
            w++;
        }
        if (pregunta[w] = pregunta[3])
        {
            if (points <= 135)
            {
                SceneManager.LoadScene(6);
            }
        }
    }
}
