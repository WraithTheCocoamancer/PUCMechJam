using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody Player;
    public Transform LaunchPoint;

    private Camera Cam;
    private bool Mousepress = false;

    private Vector3 LaunchVelocity;

    [SerializeField]
    private bool isGrounded = false;

    private void Start()
    {
        Cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mousedown");
            Mousepress = true;
        }

        if (Input.GetMouseButtonUp(0) && isGrounded)
        {
            Fire();
            Mousepress = false;
                
        }

        if (Mousepress)
        {

            Vector3 mousePos = Cam.ScreenToWorldPoint(Input.mousePosition);


            Debug.Log(mousePos);
            mousePos.z = 0;
            //transform.LookAt(mousePos);
            LaunchVelocity = mousePos - Player.position;
            
                
        }

            


        

    }

    void Fire()
    {
        Debug.Log("Fire");
        Rigidbody rb = Player.GetComponent<Rigidbody>();
        rb.AddForce(LaunchVelocity * 2, ForceMode.Impulse);

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isGrounded = false;
        }
    }
}
