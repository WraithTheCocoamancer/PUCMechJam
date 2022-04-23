using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTracker : MonoBehaviour
{
    [SerializeField]
    private GameObject currentCheckpoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetCheckpoint(GameObject checkpoint)
    {
        if (checkpoint.tag == "checkpoint")
        {
            if (currentCheckpoint != null)
            {
                currentCheckpoint.GetComponent<Checkpoint>().DeactivateNet();
            }

            currentCheckpoint = checkpoint;
        }
    }
}
