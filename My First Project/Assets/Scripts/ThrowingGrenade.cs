using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class ThrowingGrenade : MonoBehaviour
{
    private bool isThrown = false;
    public GameObject player;
    public GameObject explosion;
    public GameObject grenade;
    private AudioSource sound;
    public Text textGrenade;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q") && !isThrown)
        {
            Vector3 direction = player.transform.forward * 10;
            direction.y = 5;
            Rigidbody rb = GetComponent<Rigidbody>();
            //rb.useGravity = true;
            rb.AddForce(direction, ForceMode.Impulse);
            StartCoroutine(Explode());

            isThrown = true;
        }

    }

    IEnumerator Explode()
    {

        yield return new WaitForSeconds(1.5f);
        sound.Play();
        explosion.SetActive(true);
        Collider[] objecsCollider = Physics.OverlapSphere(transform.position, 20);
        for (int i=0 ; i<objecsCollider.Length ; i++)
        {
            if (objecsCollider[i] != null)
            {
                //Rigidbody rb = objecsCollider[i].GetComponent<Rigidbody>();
                GameObject rb = objecsCollider[i].GetComponent<GameObject>();
                if (rb != null && rb.tag == "bad")
                {
                    //rb.useGravity = true;
                    //rb.AddExplosionForce(200f, transform.position, 20);
                    Vector3 v3 = new Vector3(rb.transform.position.x+5, rb.transform.position.y+5, rb.transform.position.z+5);
                    //rb.MovePosition(v3);
                    rb.transform.position = v3;


                }
            }
        }

    }
}
