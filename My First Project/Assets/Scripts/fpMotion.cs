using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class fpMotion : MonoBehaviour
{
    public GameObject playerCamera;
    private CharacterController controller;
    private float speed = 0.2f;
    private float rx = 0f, ry;
    private float angularSpeed = 1f;
    private AudioSource stepSound;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject friend;
    public Text life;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); // gets player controller
        stepSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float dx=0, dz=0;

        // Mouse to rotate
        rx -= Input.GetAxis("Mouse Y") * angularSpeed;
        ry = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * angularSpeed;
        playerCamera.transform.localEulerAngles = new Vector3(rx, 0, 0);
        transform.localEulerAngles = new Vector3(0, ry, 0); // sets new orientation of player
         
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            // Keyboard to move
            dx = Input.GetAxis("Horizontal") * speed; // Horizontal means A/D
            dz = Input.GetAxis("Vertical") * speed; // Vertical meand W/S

            NavMeshAgent nma1 = enemy1.GetComponent<NavMeshAgent>();
            NavMeshAgent nma2 = enemy2.GetComponent<NavMeshAgent>();
            NavMeshAgent nma3 = friend.GetComponent<NavMeshAgent>();

            Animator a1 = enemy1.GetComponent<Animator>();
            Animator a2 = enemy2.GetComponent<Animator>();
            Animator a3 = friend.GetComponent<Animator>();

            if (!nma1.enabled && a1.GetInteger("NPCstate") != 2)
            {
                nma1.enabled = true;
                a1.SetInteger("NPCstate", 1);
            }

            if (!nma2.enabled && a2.GetInteger("NPCstate") != 2)
            {
                nma2.enabled = true;
                a2.SetInteger("NPCstate", 1);
            }

            if (!nma3.enabled && a3.GetInteger("NPCstate") != 2)
            {
                nma3.enabled = true;
                a3.SetInteger("NPCstate", 1);
            }
        }

        Vector3 motion = new Vector3(dx, -0.1f, dz);

        motion = transform.TransformDirection(motion); // in global coordinates
        controller.Move(motion);

        // add sound
        if(!stepSound.isPlaying && controller.velocity.magnitude > 0.1f)
            stepSound.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "weapon")
        {
            life.text = "0";
        }
    }
}
