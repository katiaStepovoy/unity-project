using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class playersBehaviour : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent agent;
    public GameObject target;
    private LineRenderer lr;
    public Text lifeText;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("NPCstate", 0);
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetInteger("NPCstate") == 2)
        {
            lifeText.text = "0";
            agent.enabled = false;
        }

        if (agent.enabled)
        {
            agent.SetDestination(target.transform.position);
            lr.positionCount = agent.path.corners.Length;
            for (int i =0; i< agent.path.corners.Length; i++)
            {
                lr.SetPosition(i, agent.path.corners[i]);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "good" || other.tag == "Player")
        {
            anim.SetInteger("NPCstate", 3);
        }

        if (other.tag == "grenade")
        {
            anim.SetInteger("NPCstate", 2);
            lifeText.text = "0";
        }

    }
}
