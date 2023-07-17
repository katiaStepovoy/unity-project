using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class gunShooting : MonoBehaviour
{
    public GameObject gunInHand;
    public GameObject mainCamera;
    public GameObject target;
    private LineRenderer lr;
    public GameObject muzzle;
    private AudioSource sound;
    public ParticleSystem flash;
    public GameObject enemy1;
    public GameObject enemy2;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        sound = gunInHand.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("touch") && gunInHand.activeSelf)
        {
            RaycastHit hit;
            if(Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit))
            {
                target.transform.position = hit.point;
                StartCoroutine(ShowShot());
                if (hit.transform.gameObject.name == enemy1.gameObject.name)
                {
                    Animator a = enemy1.GetComponent<Animator>();
                    a.SetInteger("NPCstate", 2);
                    NavMeshAgent nma1 = enemy1.GetComponent<NavMeshAgent>();
                    nma1.enabled = false;
                }
                if (hit.transform.gameObject.name == enemy2.gameObject.name)
                {
                    Animator a = enemy2.GetComponent<Animator>();
                    a.SetInteger("NPCstate", 2);                    
                    NavMeshAgent nma2 = enemy2.GetComponent<NavMeshAgent>();
                    nma2.enabled = false;
                    LineRenderer lr2 = enemy2.GetComponent<LineRenderer>();
                    lr2.enabled = false;
                }
            }
        }
    }

    public IEnumerator ShowShot()
    {
        lr.SetPosition(0, muzzle.transform.position);
        lr.SetPosition(1, target.transform.position);
        lr.enabled = true;
        target.SetActive(true);
        flash.Play();
        sound.Play();
        yield return new WaitForSeconds(0.1f);
        lr.enabled = false;
        target.SetActive(false);
    }
}
