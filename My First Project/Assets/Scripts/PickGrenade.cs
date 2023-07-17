using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickGrenade : MonoBehaviour
{
    public AudioSource pickSound;
    public int grenadeCount;
    public Text textGrenade;
    public GameObject mainCamera;
    public GameObject grenadeInHand;
    public GameObject grenadeIndrawer;
    public GameObject grenadeInBadHand;
    public GameObject cross;
    public GameObject crossTouch;
    private bool isTriggeredHit;

    // Start is called before the first frame update
    void Start()
    {
        grenadeCount = 0;
        grenadeInHand.SetActive(false);
        isTriggeredHit = false;
    }

    // Update is called once per frame
    void Update()
    {

        //grenadeInHand.GetComponent<Text>().text = "Grenades: " + grenadeCount;
        RaycastHit hit;

        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit))
        {
            if (hit.transform.gameObject.name == this.gameObject.name && hit.distance < 8)
            {
                if (!isTriggeredHit)
                {
                    isTriggeredHit = true;
                    cross.SetActive(false);
                    crossTouch.SetActive(true);
                }

                if (Input.GetButtonDown("touch"))
                {
                    grenadeCount++;
                    pickSound.Play();
                    grenadeInHand.SetActive(true);
                    //grenadeIndrawer.transform.position = grenadeInHand.transform.position;
                    Destroy(grenadeIndrawer, 0.1f);
                    textGrenade.GetComponent<Text>().text = grenadeCount + "";
                }
            }
            else if (isTriggeredHit)
            {
                isTriggeredHit = false;
                cross.SetActive(true);
                crossTouch.SetActive(false);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bad")
        {
            pickSound.Play();
            grenadeInBadHand.SetActive(true);
            Destroy(grenadeIndrawer, 0.1f);
        }        
    }
}

