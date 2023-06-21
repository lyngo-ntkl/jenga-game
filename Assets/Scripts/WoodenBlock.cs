using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBlock : MonoBehaviour
{
    private Vector3 _position;
    private Quaternion _rotation;
    private Vector3 _lastMousepos;
    private float _dragSpeed = 5;
    public void OnMouseDown()
    {
        _position = transform.position;
        _rotation = transform.rotation;
        _lastMousepos = Input.mousePosition;
    }
    public void OnMouseDrag()
    {
        Vector3 delta = Input.mousePosition - _lastMousepos;
        if(Math.Round(_rotation.y) == 0)
        {
            _position.z += _dragSpeed * delta.z;
            transform.position = _position;
        }
        else
        {
            _position.x += _dragSpeed * delta.x;
            transform.position = _position;
        }
        _lastMousepos = Input.mousePosition;
    }
}
