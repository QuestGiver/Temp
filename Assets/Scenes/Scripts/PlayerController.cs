using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables-------------
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private float speed = 100;
    [SerializeField]
    private float camSensativity = 3;

    private float xRotation;
    private Vector3 currentDirection;


    //---------------------
    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.Log("No character controller on:" + gameObject.name);
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        //reset direction collector
        currentDirection = Vector3.zero;
        //Input Collection------------------------------------------------
        if (Input.GetKey(KeyCode.W))
        {
            currentDirection.z += 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            currentDirection.z -= 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            currentDirection.x -= 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            currentDirection.x += 1;
        }



        //-----------------------------------------------------------------
        Vector3 cameraVector = transform.eulerAngles;

        cameraVector.y += Input.GetAxis("Mouse X") * camSensativity;
        xRotation -= Input.GetAxis("Mouse Y") * camSensativity;

        xRotation = Mathf.Clamp(xRotation, -89, 89);

        cameraVector.x = xRotation;

        transform.eulerAngles = cameraVector;

        

        



        




        //normalize direction
        currentDirection = currentDirection.normalized;



    }


    void FixedUpdate()
    {

        controller.SimpleMove( transform.forward * (currentDirection.z) * (speed * Time.deltaTime));
        controller.SimpleMove(transform.right * (currentDirection.x) * (speed * Time.deltaTime));




    }
}
