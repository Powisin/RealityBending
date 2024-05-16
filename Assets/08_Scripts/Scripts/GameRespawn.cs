using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRespawn : MonoBehaviour
{
    public float threshold;
    [SerializeField] GameObject[] checkPoints;
    [SerializeField] GameObject checkPointsCanvas;
    public GameObject Scream;
    private GameObject checkPointCurrent;


    private void Start()
    {
        checkPointCurrent = checkPoints[0];
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       if (transform.position.y < threshold)
        {
            transform.position = new Vector3(checkPointCurrent.transform.position.x, checkPointCurrent.transform.position.y, checkPointCurrent.transform.position.z);
        }  
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BreakingDoor0"))
        {
            checkPointCurrent = checkPoints[1];
            checkPointsCanvas.SetActive(true);
        }
        if (other.CompareTag("Enemy"))
        {
            transform.position = new Vector3(checkPointCurrent.transform.position.x, checkPointCurrent.transform.position.y, checkPointCurrent.transform.position.z);
        }
        if (other.CompareTag("Screamer"))
        {
            Scream.SetActive(true);
            transform.position = new Vector3(checkPointCurrent.transform.position.x, checkPointCurrent.transform.position.y, checkPointCurrent.transform.position.z);
            Cursor.lockState = CursorLockMode.None;
        }
    }
    

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BreakingDoor0"))
        {
            checkPointsCanvas.SetActive(false);
        }
    }
}
