using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilador : MonoBehaviour
{

    [SerializeField] private GameObject objectToAddForce;
    [SerializeField] private float maxForce;
    [SerializeField] private float minForce;
    [SerializeField] private Vector3 forceDirectionVector;

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
        if (other.CompareTag("Player"))
        {
            float forceMafnitude = Random.Range(minForce, maxForce);

            Vector3 force = Vector3.Normalize(forceDirectionVector) * forceMafnitude;

            objectToAddForce.GetComponent<Rigidbody>().AddForce(force);

            
        }
    }


}
