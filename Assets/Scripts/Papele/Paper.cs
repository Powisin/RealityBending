using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;
using TMPro;
using Input = UnityEngine.Input;

public class Paper : MonoBehaviour
{

    [SerializeField] GameObject[] papel;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        

        if (Input.GetKeyDown(KeyCode.E)) 
        {

            if (other.CompareTag("Paper0"))
            {
                //PressE();
                
                papel[0].SetActive(true);

            }
            if (other.CompareTag("Paper1"))
            {
                //PressE();
                
                papel[1].SetActive(true);

            }
            if (other.CompareTag("Paper2"))
            {
                //PressE();
                
                papel[2].SetActive(true);

            }
            if (other.CompareTag("Paper3"))
            {
                //PressE();
                
                papel[3].SetActive(true);

            }
            if (other.CompareTag("Prueba1"))
            {
                papel[4].SetActive(true);
            }
            if (other.CompareTag("Prueba2"))
            {
                papel[5].SetActive(true);
            }
            if (other.CompareTag("Paper5"))
            {
                papel[6].SetActive(true);
            }
        }
        //textoPapel.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Paper0")) 
        {
            papel[0].SetActive(false);
            

        }
        if (other.CompareTag("Paper1"))
        {
            papel[1].SetActive(false);
            

        }
        if (other.CompareTag("Paper2"))
        {
            papel[2].SetActive(false);
            

        }
        if (other.CompareTag("Paper3"))
        {
            papel[3].SetActive(false);

        }
        if (other.CompareTag("Prueba1"))
        {
            papel[4].SetActive(false);
        }
        if (other.CompareTag("Prueba2"))
        {
            papel[5].SetActive(false);
        }
        if (other.CompareTag("Paper5"))
        {
            papel[6].SetActive(false);
        }

    }

    /*private void PressE()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            papel1[1].SetActive(true);

            Debug.Log("h");
        }*/
}
