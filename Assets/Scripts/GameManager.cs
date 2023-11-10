using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] TargetChanger targetChanger;

    [SerializeField] GameObject playerObject;

    private void Awake()
    {
        #region SINGLETON
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;
        #endregion

        if (playerObject == null)
        {
            playerObject = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public TargetChanger TargetChanger { get { return targetChanger; } }

    public GameObject Player { get { return playerObject; } }
}
