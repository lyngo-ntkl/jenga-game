using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JengaBehavior : MonoBehaviour
{
    public GameObject prefabsObject;
    public Camera camera;

    const int DefaultNumberOfLayer = 10;
    const float CenterX = 0;
    const float StartY = 8;
    const float CenterZ= 0;

    private Vector3 _previousPosition;
    // Start is called before the first frame update
    void Start()
    {
        int numberOfLayers = PlayerPrefs.GetInt("NumberOfLayers");
        if(numberOfLayers == 0)
        {
            numberOfLayers = DefaultNumberOfLayer;
            PlayerPrefs.SetInt("NumberOfLayers", numberOfLayers);
        }
        GenerateJengaBlock(numberOfLayers);
    }

    private void GenerateJengaBlock(int numberOfLayers)
    {
        float prefabsObjectHeight = prefabsObject.transform.localScale.y;
        // a quick reminder: length = 3 * width
        float prefabsObjectWidth = prefabsObject.transform.localScale.z;
        float layerY = StartY;
        for (int i = 0; i < numberOfLayers; i++)
        {
            Quaternion quaternion;
            Vector3 transitionVector;
            Vector3 position;
            if(i % 2 != 0)
            {
                quaternion = Quaternion.identity;
                transitionVector = new Vector3(0, 0, prefabsObjectWidth);
                position = new Vector3(CenterX, layerY, CenterZ - prefabsObjectWidth);
            } else
            {
                quaternion = Quaternion.Euler(0, 90, 0);
                transitionVector = new Vector3(prefabsObjectWidth, 0, 0);
                position = new Vector3(CenterX - prefabsObjectWidth, layerY, CenterZ);
            }
            for(int j = 0; j < 3; j++)
            {
                GameObject gameObject = Instantiate(prefabsObject, position, quaternion);
                position += transitionVector;
            }
            layerY += prefabsObjectHeight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        RotateCameraAroundObject();
    }

    private void RotateCameraAroundObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _previousPosition = camera.ScreenToViewportPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = _previousPosition - camera.ScreenToViewportPoint(Input.mousePosition);

            camera.transform.RotateAround(new Vector3(), new Vector3(1, 0, 0), direction.z * 100);
            camera.transform.RotateAround(new Vector3(), new Vector3(0, 1, 0), -direction.x * 100);
            _previousPosition = camera.ScreenToViewportPoint(Input.mousePosition);
        }
    }

    private void MoveWoodenBlockOnClickTouch()
    {
        if(Input.GetMouseButtonDown(0) || Input.touchCount > 1)
        {

        }
    }
}
