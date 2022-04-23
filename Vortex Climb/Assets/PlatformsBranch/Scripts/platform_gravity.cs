using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_gravity : MonoBehaviour
{
    [SerializeField]
    private Vector3 gravityDirection;
    [SerializeField]
    private float currentRotation_Z;
    [SerializeField]
    private Quaternion rotation;

    [SerializeField]
    private Quaternion rotationQ;
    [SerializeField]
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
        rotationQ = gameObject.transform.rotation;



        //gravityDirection = transform.rotation * Vector3.up;// *  -transform.up;
        currentRotation_Z = gameObject.transform.rotation.eulerAngles.z;
        //gravityDirection = gameObject.transform.up;

        //gravityDirection = (rotationQ * Vector3.up);

        rotation = Quaternion.AngleAxis(-currentRotation_Z, new Vector3(0.0f, 0.0f, 1.0f));

        gravityDirection = rotation * new Vector3(0.0f, 1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //rotationQ = gameObject.transform.rotation;
        //currentRotation_Z = gameObject.transform.rotation.eulerAngles.z;
        //gravityDirection = -gameObject.transform.up;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out player_gravity otherGrav))
        {
            otherGrav.SetGravity(gravityDirection);
        }
    }
}
