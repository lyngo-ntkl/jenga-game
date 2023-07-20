using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainBehavior : MonoBehaviour
{
    private int mark;
    // Start is called before the first frame update
    void Start()
    {
        mark = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.collider.gameObject;
        WoodenBlockBehavior woodenBlockBehavior = gameObject.GetComponent<WoodenBlockBehavior>();
        if (gameObject.tag.Equals("woodenBlock") && !woodenBlockBehavior.IsTouch)
        {
            mark++;
            woodenBlockBehavior.IsTouch = true;
            Debug.Log($"Mark: {mark}");
        }
    }
}