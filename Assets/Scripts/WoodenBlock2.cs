using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WoodenBlock2 : MonoBehaviour
{
    public float force;
    public bool hasPoints = false;
    Rigidbody rigidbody;
    Camera camera;
    Vector3 originalScreenTargetPosition;
    Vector3 rigidbodyPos;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!camera) return;
        if(Input.GetMouseButtonDown(0))
        {
            rigidbody = GetRigidbody();
        }
    }

    void FixedUpdate()
    {
        if (rigidbody)
        {
            Vector3 mousePositionOffset = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance)) - originalScreenTargetPosition;
            rigidbody.velocity = (rigidbodyPos + mousePositionOffset - rigidbody.transform.position) * force * Time.deltaTime;
        }
    }

    Rigidbody GetRigidbody()
    {
        RaycastHit hitInfo = new RaycastHit();
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        bool hit = Physics.Raycast(ray, out hitInfo);
        if(hit)
        {
            if (hitInfo.collider.gameObject.GetComponent<Rigidbody>())
            {
                distance = Vector3.Distance(ray.origin, hitInfo.point);
                originalScreenTargetPosition = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));
                rigidbodyPos = hitInfo.collider.transform.position;
                return hitInfo.collider.gameObject.GetComponent<Rigidbody>();
            }
        }
        return null;
    }
}
