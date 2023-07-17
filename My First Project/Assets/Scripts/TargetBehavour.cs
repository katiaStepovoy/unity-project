using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavour : MonoBehaviour
{

    public GameObject npc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == npc.name)
        {
            float x, y, z;
            x = Random.Range(0, 124);
            z = Random.Range(0,20);
            y = Random.Range(0,-2);
            this.transform.position = new Vector3(x,0,z);
        }
    }
}
