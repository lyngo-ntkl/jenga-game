using System;
using UnityEngine;

public class WoodenBlock : MonoBehaviour
{
    public float forceAmout = 500;
    public bool hasPoints = false;
    Rigidbody selectedRigibody;
    public Camera targetCamera;
    Vector3 originalScreenTargetPosition;
    Vector3 originalRigibodyPos;
    float selectionDistance;
    // Start is called before the first frame update
    void Start()
    {
        //targetCamera = GetComponent<Camera>();
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
        if (hit && hitInfo.collider.tag.Equals("woodenBlock"))
        {
            //if (hitInfo.collider.gameObject.GetComponent<Rigidbody>())
            //{
            //    selectionDistance = Vector3.Distance(ray.origin, hitInfo.point);
            //    originalScreenTargetPosition = targetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance));
            //    originalRigibodyPos = hitInfo.collider.transform.position;
            //    return hitInfo.collider.gameObject.GetComponent<Rigidbody>();
            //}
            if (hitInfo.rigidbody)
            {
                selectionDistance = Vector3.Distance(ray.origin, hitInfo.point);
                originalScreenTargetPosition = targetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance));
                originalRigibodyPos = hitInfo.rigidbody.position;
                return hitInfo.rigidbody;

            }
        }
        return null;
    }




    //private static System.Random Random = new System.Random();
    //private Rigidbody rigidbody;
    //private Vector3 _originPosition;
    //private Vector3 _transformDirection;
    //private Vector3 _rigidbodyPosition;
    //private Quaternion _rotation;
    //private Vector3 _lastMousepos;
    //private float _dragSpeed = 5;
    //private float _force;
    //private float _distance;

    //private void Start()
    //{

    //}

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        _rotation = transform.rotation;
    //        _lastMousepos = Input.mousePosition;
    //        _originPosition = transform.position;
    //        if (Math.Round(_rotation.y) == 0)
    //        {
    //            _transformDirection = transform.forward;
    //        }
    //        else if (Math.Round(_rotation.y) == 1)
    //        {
    //            _transformDirection = transform.right;
    //        }
    //        RaycastHit raycastHit;
    //        bool hitStatus = Physics.Raycast(_lastMousepos, _transformDirection, out raycastHit);
    //        if (hitStatus)
    //        {
    //            if (raycastHit.collider.gameObject.GetComponent<Rigidbody>() != null)
    //            {
    //                _distance = Vector3.Distance(_lastMousepos, raycastHit.point);
    //                _rigidbodyPosition = raycastHit.collider.transform.position;
    //            }
    //            rigidbody = raycastHit.collider.gameObject.GetComponent<Rigidbody>();
    //            rigidbody.velocity = (_rigidbodyPosition - _originPosition) * _force * Time.deltaTime;
    //        }
    //    }
    //}
    //private int mark = 0;
    //public void OnMouseDown()
    //{
    //    _originPosition = transform.position;
    //    _rotation = transform.rotation;
    //    _lastMousepos = Input.mousePosition;
    //    _force = (float)Random.NextDouble() * 20;
    //    rigidbody = gameObject.GetComponent<Rigidbody>();
    //}

    //public void OnMouseDrag()
    //{
    //    if (Math.Round(_rotation.y) == 0)
    //    {
    //        // Z axis
    //        _transformDirection = transform.forward;
    //    }
    //    else if (Math.Round(_rotation.y) == 1)
    //    {
    //        // X axis
    //        _transformDirection = transform.right;
    //    }
    //    RaycastHit raycastHit = new RaycastHit();
    //    bool hitState = Physics.Raycast(_originPosition, _transformDirection, out raycastHit);
    //    if (hitState)
    //    {
    //        rigidbody.velocity = raycastHit.collider.transform.position * _force * Time.deltaTime;
    //    }
    //    Vector3 delta = Input.mousePosition - _lastMousepos;

    //    _lastMousepos = Input.mousePosition;
    //}



    //public void OnMouseDrag()
    //{
    //    Vector3 delta = Input.mousePosition - _lastMousepos;
    //    if (Math.Round(_rotation.y) == 0)
    //    {
    //        _position.z += _dragSpeed * delta.x;
    //        transform.position = _position;
    //    }
    //    else if (Math.Round(_rotation.y) == 1)
    //    {
    //        _position.x += _dragSpeed * delta.x;
    //        transform.position = _position;
    //    }
    //    _lastMousepos = Input.mousePosition;
    //}

    //private void OnTriggerEnter()
    //{
    //    mark += 1;
    //    Debug.Log(mark);
    //}
}
