using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickGun : MonoBehaviour
{
    private bool isTriggeredHit;
    public AudioSource pickSound;
    public static int gunCount;
    public Text textGun;
    public GameObject cross;
    public GameObject crossTouch;
    public GameObject mainCamera;
    public GameObject gunInHand;
    public GameObject gunIndrawer;

    // Start is called before the first frame update
    void Start()
    {
        gunCount = 0;
        gunInHand.SetActive(false);
        isTriggeredHit = false;
    }

    // Update is called once per frame
    void Update()
    {
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
                    gunCount++;
                    pickSound.Play();
                    gunInHand.SetActive(true);
                    Destroy(gunIndrawer, 0.1f);
                    textGun.GetComponent<Text>().text = "Guns: " + gunCount;
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
}
