using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody Player;
    public Transform LaunchPoint;
    public LineRenderer lineRenderer;

    private const int NoTrajectoryPoints = 10;
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
            lineRenderer.enabled = true;
            Mousepress = true;
        }

        if (Input.GetMouseButtonUp(0) && isGrounded)
        {
            lineRenderer.enabled = false;
            Fire();
            Mousepress = false;
                
        }

        if (Mousepress)
        {

            Vector3 mousePos = Cam.ScreenToWorldPoint(Input.mousePosition);


            Debug.Log(mousePos);
            mousePos.z = 0;
            //transform.LookAt(mousePos);
            LaunchVelocity = (mousePos - Player.position);

            LineRenderUpdate();    
        }

            


        

    }

    private void LineRenderUpdate()
    {
        float g = Physics.gravity.magnitude;
        float velocity = LaunchVelocity.magnitude;
        float angle = Mathf.Atan2(LaunchVelocity.y, LaunchVelocity.x);

        Vector3 start = Player.position;

        float timeStep = 0.1f;
        float fTime = 0f;
        for (int i = 0; i < NoTrajectoryPoints; i++)
        {
            float dx = velocity * fTime * Mathf.Cos(angle);
            float dy = velocity * fTime * Mathf.Sin(angle) - (g * fTime * fTime / 2f);
            Vector3 pos = new Vector3(start.x + dx, start.y + dy, 0);
            lineRenderer.SetPosition(i, pos);
            fTime += timeStep;
        }
    }
    void Fire()
    {
        Debug.Log("Fire");
        Rigidbody rb = Player.GetComponent<Rigidbody>();
        rb.AddForce(LaunchVelocity, ForceMode.Impulse);

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
