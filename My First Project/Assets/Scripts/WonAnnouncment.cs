using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WonAnnouncment : MonoBehaviour
{
    public Text enemy1;
    public Text enemy2;
    public GameObject announcment;
    public GameObject player;
    private RawImage ri;
    public Text announce;

    // Start is called before the first frame update
    void Start()
    {
        ri = announcment.GetComponent<RawImage>();
        ri.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy1.text.Equals("0") && enemy2.text.Equals("0"))
        {
            ri.enabled = true;
            announce.text = "Congratulations! You Won!";
        }


    }
}
