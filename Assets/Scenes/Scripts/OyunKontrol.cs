using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OyunKontrol : MonoBehaviour
{
    public GameObject zombi;
    private float zamansayaci;
    private float olusumsureci = 10f;
    public Text puantext;
    private int puan;
    // Start is called before the first frame update
    void Start()
    {
        zamansayaci = olusumsureci;
        
    }

    // Update is called once per frame
    void Update()
    {
        zamansayaci -= Time.deltaTime;
        if (zamansayaci < 0)
        {
            Vector3 pos = new Vector3(Random.Range(220, 400), 23f, Random.Range(195, 365));
            Instantiate(zombi, pos, Quaternion.identity);
            zamansayaci = olusumsureci;
        }
    }

    public void puanarttir(int p)
    {
        puan += p;
        puantext.text = "" + puan;
    }

    public void OyunBitti()
    {
        PlayerPrefs.SetInt("puan",puan);
        SceneManager.LoadScene("OyunBitti");
    }
}
