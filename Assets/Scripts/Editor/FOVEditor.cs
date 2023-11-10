using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Credits to Comp-3 Interactive for the detection code. Link to Youtube video: https://www.youtube.com/watch?v=j1-OyLo77ss
[CustomEditor(typeof(GuardController))]
public class FOVEditor : Editor
{
    private void OnSceneGUI()
    {
        GuardController fov = (GuardController)target;

        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.detectionRadius);

        Vector3 leftViewAngle = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.viewAngle / 2);
        Vector3 rightViewAngle = DirectionFromAngle(fov.transform.eulerAngles.y, fov.viewAngle / 2);

        Handles.color = Color.yellow;
        Handles.DrawLine(fov.transform.position, fov.transform.position + leftViewAngle * fov.detectionRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + rightViewAngle * fov.detectionRadius);

        if (fov.canSeePlayer)
        {
            Handles.color = Color.red;
            Handles.DrawLine(fov.transform.position, GameManager.Instance.Player.transform.position);
        }
    }

    Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
