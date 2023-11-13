using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public bool inPrivateArea { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        inPrivateArea = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PrivateArea")
        {
            inPrivateArea = true;
            //Debug.Log("Entered Private Area");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PrivateArea")
        {
            inPrivateArea = false;
            //Debug.Log("Exited Private Area");
        }
    }
}
