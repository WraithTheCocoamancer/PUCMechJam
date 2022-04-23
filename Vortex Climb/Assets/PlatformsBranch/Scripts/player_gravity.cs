using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_gravity : MonoBehaviour
{
    [SerializeField]
    private Vector3 currentGravity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGravity(Vector3 gravity)
    {
        currentGravity = gravity;
    }
}
