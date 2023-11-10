using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetChanger : MonoBehaviour
{
    [SerializeField] List<Vector3> positionList;

    [SerializeField] int nextPositionIndex = 0;

    public GameObject targetObject { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        if (targetObject == null)
        {
            targetObject = gameObject;
        }

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
        if (other.CompareTag("Guard") == false)
        {
            return;
        }

        if (positionList.Count > 1)
        {
            transform.position = positionList[nextPositionIndex];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Guard")) {
            nextPositionIndex++;
        }
    }
}
