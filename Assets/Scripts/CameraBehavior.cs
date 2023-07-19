using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private Vector3 _previousPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    _previousPosition = _camera.ScreenToViewportPoint(Input.mousePosition);
        //}
        //if (Input.GetMouseButton(0))
        //{
        //    Vector3 direction = _previousPosition - _camera.ScreenToViewportPoint(Input.mousePosition);

        //    _camera.transform.RotateAround(new Vector3(), new Vector3(1, 0, 0), direction.z * 100);
        //    _camera.transform.RotateAround(new Vector3(), new Vector3(0, 1, 0), -direction.x * 100);
        //    _previousPosition = _camera.ScreenToViewportPoint(Input.mousePosition);
        //}
    }
}
