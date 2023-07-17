using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedroomDrawer : MonoBehaviour
{
    private Animator anim;
    private bool isDrawer;
    public GameObject cross;
    public GameObject crossTouch;
    public GameObject mainCamera;
    private bool isTriggeredHit;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isDrawer = true;
    }

    /*private void OnMouseDown()
    {
        anim.SetBool("open", isDrawer);
        isDrawer = !isDrawer;
    }*/

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit))
        {
            if (hit.transform.gameObject.name == this.gameObject.name)
            {
                if (!isTriggeredHit)
                {
                    isTriggeredHit = true;
                    cross.SetActive(false);
                    crossTouch.SetActive(true);
                }

                if (Input.GetButtonDown("touch"))
                {
                    anim.SetBool("open", isDrawer);
                    isDrawer = !isDrawer;
                }
            }
            else
            {
                if (isTriggeredHit)
                {
                    isTriggeredHit = false;
                    cross.SetActive(true);
                    crossTouch.SetActive(false);
                }
            }
        }
    }
}
