using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;
using TMPro;
using Input = UnityEngine.Input;

public class Paper : MonoBehaviour
{

    [SerializeField] GameObject[] papel1;
    [SerializeField] GameObject textoPapel;
    


    // Start is called before the first frame update
    void Start()
    {
        textoPapel.SetActive(false);
        papel1[0].SetActive(false);
        papel1[1].SetActive(false);
        papel1[2].SetActive(false);
        papel1[3].SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            
            if (other.CompareTag("Paper"))
            {
                //PressE();
                
                papel1[0].SetActive(true);

            }
            if (other.CompareTag("Paper1"))
            {
                //PressE();
                
                papel1[1].SetActive(true);

            }
            if (other.CompareTag("Paper2"))
            {
                //PressE();
                
                papel1[2].SetActive(true);

            }
            if (other.CompareTag("Paper3"))
            {
                //PressE();
                
                papel1[3].SetActive(true);

            }
        }
        textoPapel.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        textoPapel.SetActive(false);
        if (other.CompareTag("Paper")) 
        {
            papel1[0].SetActive(false);
            

        }
        if (other.CompareTag("Paper1"))
        {
            papel1[1].SetActive(false);
            

        }
        if (other.CompareTag("Paper2"))
        {
            papel1[2].SetActive(false);
            

        }
        if (other.CompareTag("Paper3"))
        {
            papel1[3].SetActive(false);
            

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
