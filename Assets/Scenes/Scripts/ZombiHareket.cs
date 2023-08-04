using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ZombiHareket : MonoBehaviour
{
    public GameObject kalp;
    private GameObject oyuncu;
    private int zombipuan = 10;
    private int zombican = 3;
    private float mesafe;
    private OyunKontrol okontrol;
    private AudioSource asource;
    private bool zombiol=false;
    // Start is called before the first frame update
    void Start()
    {
        oyuncu = GameObject.Find("FPSController");
        okontrol = GameObject.Find("_.Scripts").GetComponent<OyunKontrol>();
        GetComponent<NavMeshAgent>().enabled = true;
        asource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = oyuncu.transform.position;
        mesafe = Vector3.Distance(transform.position, oyuncu.transform.position);
        if (mesafe < 10f)
        {
            if (!asource.isPlaying)
            {
                asource.Play();
            }
            if (!zombiol)
            {
                GetComponentInChildren<Animation>().Play("Zombie_Attack_01");
            }
            
        }
        else
        {
            if (asource.isPlaying)
            {
                asource.Stop();
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag.Equals("mermi"))
        {
            zombican--;
            if (zombican == 0)
            {
                zombiol = true;
                okontrol.puanarttir(zombipuan);
                Instantiate(kalp, transform.position, Quaternion.identity);
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");
                Destroy(this.gameObject, 1.667f);
            }
        }
    }
}
