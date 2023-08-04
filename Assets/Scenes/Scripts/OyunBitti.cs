using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OyunBitti : MonoBehaviour
{
    public Text puan;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        puan.text ="Puanýnýz:"+PlayerPrefs.GetInt("puan");
    }

    // Update is called once per frame
    public void YenidenOyna()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("Oyun");
    }
}
