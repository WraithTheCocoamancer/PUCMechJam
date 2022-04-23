using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private CheckpointTracker checkpointTracker;

    [SerializeField]
    private bool wasVisited = false;

    [SerializeField]
    private GameObject resetNet;

    // Start is called before the first frame update
    void Start()
    {
        resetNet.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            wasVisited = true;
            checkpointTracker.SetCheckpoint(gameObject);
            resetNet.SetActive(true);
        }
    }

    public void DeactivateNet()
    {
        resetNet.SetActive(false);
    }
}
