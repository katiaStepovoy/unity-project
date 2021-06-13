using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpMotion : MonoBehaviour
{
    public GameObject playerCamera;
    private CharacterController controller;
    private float speed = 0.2f;
    private float rx = 0, ry;
    private float angularSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); // gets player controller
    }

    // Update is called once per frame
    void Update()
    {
        float dx, dz;

        // Mouse to rotate
        rx -= Input.GetAxis("Mouse Y") * angularSpeed;
        ry = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * angularSpeed;
        playerCamera.transform.localEulerAngles = new Vector3(rx, 0, 0);
        transform.localEulerAngles = new Vector3(0, ry, 0); // sets new orientation of player
         
        // Keyboard to move
        dx = Input.GetAxis("Horizontal") * speed; // Horizontal means A/D
        dz = Input.GetAxis("Vertical") * speed; // Vertical meand W/S

        Vector3 motion = new Vector3(dx, 0, dz);

        motion = transform.TransformDirection(motion); // in global coordinates
        controller.Move(motion);
    }
}
