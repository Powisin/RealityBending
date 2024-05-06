using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallcontroll : MonoBehaviour
{
    // Start is called before the first frame update


    public int fallLimit = -12;

    private void Update()
    {
        FallRespawn();
    }
    void FallRespawn()
    {
        if (transform.position.y < fallLimit)
        {
            Destroy(gameObject);
        }
    }
}
