using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBlock : MonoBehaviour
{
    public float forceAmout = 500;
    public bool hasPoints = false;
    Rigidbody selectedRigibody;
    Camera targetCamera;
    Vector3 originalScreenTargetPosition;
    Vector3 originalRigibodyPos;
    float selectionDistance;
    // Start is called before the first frame update
    void Start()
    {
        targetCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetCamera) return;
        if (Input.GetMouseButtonDown(0))
        {
            selectedRigibody = GetRigibodyFromMouseClick();
        }
        if (Input.GetMouseButtonUp(0) && selectedRigibody)
        {
            selectedRigibody = null;
        }
    }
    void FixedUpdate()
    {
        if (selectedRigibody)
        {
            Vector3 mousePositionOffset = targetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance)) - originalScreenTargetPosition;
            selectedRigibody.velocity = (originalRigibodyPos + mousePositionOffset - selectedRigibody.transform.position) * forceAmout * Time.deltaTime;
        }
    }
    Rigidbody GetRigibodyFromMouseClick()
    {
        RaycastHit hitInfo = new RaycastHit();
        Ray ray = targetCamera.ScreenPointToRay(Input.mousePosition);
        bool hit = Physics.Raycast(ray, out hitInfo);
        if (hit)
        {
            if (hitInfo.collider.gameObject.GetComponent<Rigidbody>())
            {
                selectionDistance = Vector3.Distance(ray.origin, hitInfo.point);
                originalScreenTargetPosition = targetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance));
                originalRigibodyPos = hitInfo.collider.transform.position;
                return hitInfo.collider.gameObject.GetComponent<Rigidbody>();
            }
        }
        return null;
    }




    //private Rigidbody getRigidbody()
    //{
    //    RaycastHit raycastHit = new RaycastHit();

    //    if (true)
    //    {
    //        return raycastHit.collider.gameObject.GetComponent<Rigidbody>();
    //    }
    //    return null;
    //}
    private Vector3 _position;
    private Quaternion _rotation;
    private Vector3 _lastMousepos;
    private float _dragSpeed = 5;
    private int mark = 0;
    public void OnMouseDown()
    {
        _position = transform.position;
        _rotation = transform.rotation;
        _lastMousepos = Input.mousePosition;
    }
    public void OnMouseDrag()
    {
        Vector3 delta = Input.mousePosition - _lastMousepos;
        if (Math.Round(_rotation.y) == 0)
        {
            _position.z += _dragSpeed * delta.x;
            transform.position = _position;
        }
        else if (Math.Round(_rotation.y) == 1)
        {
            _position.x += _dragSpeed * delta.x;
            transform.position = _position;
        }
        _lastMousepos = Input.mousePosition;
    }

    private void OnTriggerEnter()
    {
        mark += 1;
        Debug.Log(mark);
    }
}
