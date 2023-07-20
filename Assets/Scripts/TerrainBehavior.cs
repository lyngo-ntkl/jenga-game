using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainBehavior : MonoBehaviour
{
    public bool IsLose;
    private int mark;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        mark = 0;
        IsLose = false;
        time = Time.realtimeSinceStartup;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.collider.gameObject;
        WoodenBlockBehavior woodenBlockBehavior = gameObject.GetComponent<WoodenBlockBehavior>();
        if (gameObject.tag.Equals("woodenBlock") && !woodenBlockBehavior.IsTouch)
        {   
            mark++;
            woodenBlockBehavior.IsTouch = true;
            float deltaTime = Time.time - time;
            if(deltaTime < 1)
            {
                IsLose=true;
            }
        }
        time = Time.time;
    }
}