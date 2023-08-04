using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OyuncuKontol : MonoBehaviour
{
    public Transform mermipos;
    public GameObject mermi;
    public GameObject patlama;
    public Image canImaj;
    public OyunKontrol okontrol;
    private float candegeri=100f;
    public AudioClip atissesi, olmesesi, cansesi, yarasesi;
    private AudioSource asource;
    // Start is called before the first frame update
    void Start()
    {
        asource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            asource.PlayOneShot(atissesi, 1f);
            GameObject go=Instantiate(mermi,mermipos.position,mermipos.rotation) as GameObject;
            GameObject gopat = Instantiate(patlama, mermipos.position, mermipos.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = mermipos.transform.forward * 10f;
            Destroy(go.gameObject, 2f);
            Destroy(gopat.gameObject, 2f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag.Equals("zombi"))
        {
            asource.PlayOneShot(yarasesi, 1f);
            Debug.Log("zombi saldýrdý");
            candegeri -= 10f;
            float x = candegeri / 100f;
            canImaj.fillAmount = x;
            canImaj.color = Color.Lerp(Color.red, Color.green, x);

            if (candegeri <=0)
            {
                asource.PlayOneShot(olmesesi, 1f);
                okontrol.OyunBitti();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("kalp"))
        {
            asource.PlayOneShot(cansesi, 1f);
            if (candegeri < 100)
            Debug.Log("can alýndý");
            candegeri += 10f;
            float x = candegeri / 100f;
            canImaj.fillAmount = x;
            canImaj.color = Color.Lerp(Color.red, Color.green, x);

            Destroy(other.gameObject);

        }
    }
}
