using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_resetnet : MonoBehaviour
{
    [SerializeField]
    private Transform resetPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
            other.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
            other.gameObject.transform.position = resetPoint.position;
            other.gameObject.transform.rotation = resetPoint.rotation;
        }
    }
}
