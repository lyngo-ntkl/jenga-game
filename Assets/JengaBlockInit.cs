using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JengaBlockInit : MonoBehaviour
{
    private int _numberOfLayers;
    public GameObject[] JengaBlock = null;
    public GameObject Layer1;
    public GameObject Layer2;
    // Start is called before the first frame update
    void Start()
    {
        _numberOfLayers = PlayerPrefs.GetInt("NumberOfLayers");
        int axisY = 8;
        for(int i = 0; i < _numberOfLayers; i++)
        {
            if(i % 2 == 0)
            {
                Vector3 vector3 = new Vector3(0, axisY, -10);
                Instantiate(Layer1, vector3, Quaternion.identity);
            }
            else
            {
                Vector3 vector3 = new Vector3(10, axisY, 0);
                Instantiate (Layer2, vector3, Quaternion.identity);
            }
            axisY += 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
