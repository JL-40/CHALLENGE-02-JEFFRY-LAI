using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NavControl))]
public class GuardController : MonoBehaviour
{
    public float detectionRadius;

    [Range(0, 359)]
    public float viewAngle;
 
    [SerializeField] LayerMask playerMask;
    [SerializeField] LayerMask obstructionMask;

    public bool canSeePlayer { get; private set; } = false;

    [SerializeField] NavControl navControl;


    // Start is called before the first frame update
    void Start()
    {
        if (navControl == null)
        {
            navControl = GetComponent<NavControl>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        FOVCheck();
    }

    // Credits to Comp-3 Interactive for the detection code. Link to Youtube video: https://www.youtube.com/watch?v=j1-OyLo77ss
    void FOVCheck()
    {
        Collider[] collidersInRange = Physics.OverlapSphere(transform.position, detectionRadius, playerMask);

        if (collidersInRange.Length != 0)
        {
            Transform target = collidersInRange[0].transform;

            Vector3 targetDirection = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, targetDirection) >= viewAngle / 2)
            {
                canSeePlayer = false;
            }

            float targetDistance = Vector3.Distance(transform.position, target.position);

            if (Physics.Raycast(transform.position, targetDirection, targetDistance, obstructionMask) == true)
            {
                canSeePlayer = false;

            }

            canSeePlayer = true;

            navControl.SetTarget = target.gameObject;
        }
        else if (canSeePlayer == true)
        {
            canSeePlayer = false;
        }
    }
}
