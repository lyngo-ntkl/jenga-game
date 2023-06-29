using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JengaBlockInit : MonoBehaviour
{
    private int _numberOfLayers;
    //public GameObject[] JengaBlock = null;
    public GameObject Layer1;
    public GameObject Layer2;
    private Vector3 _layerDefaultPosition = new Vector3(0, 8, 0);
    // Start is called before the first frame update
    void Start()
    {
        _numberOfLayers = PlayerPrefs.GetInt("NumberOfLayers");
        float height = Layer1.transform.localScale.y;
        if(_numberOfLayers == 0)
        {
            _numberOfLayers = 10;
            PlayerPrefs.SetInt("NumberOfLayers", _numberOfLayers);
        }
        //JengaBlock = new GameObject[_numberOfLayers];
        for(int i = 0; i < _numberOfLayers; i++)
        {
            GameObject gameObject;
            if(i % 2 == 0)
            {
                gameObject = Instantiate(Layer1, _layerDefaultPosition, Quaternion.identity);
            }
            else
            {
                gameObject = Instantiate (Layer2, _layerDefaultPosition, Quaternion.identity);
            }
            //JengaBlock[i] = gameObject;
            _layerDefaultPosition.y += 8;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
