using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetChanger : MonoBehaviour
{
    [SerializeField] List<Vector3> positionList;

    [SerializeField] int nextPosition = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (positionList.Count == 0)
        {
            positionList.Add(transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Guard"))
        {
            transform.position = positionList[nextPosition];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Guard")) {
            nextPosition++;
        }
    }

    public void FindSuspiciousPlayer(Vector3 playerPosition)
    {
        transform.position = playerPosition;
    } 
}
