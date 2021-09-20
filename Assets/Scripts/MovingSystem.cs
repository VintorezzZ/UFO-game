﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSystem : MonoBehaviour
{
    public Transform[] points;
    public Transform obj;
    public float speed;

    private Transform targetPoint;
    private int currentPoint;

    private bool forward = true;
    public bool cycle;
    void Start()
    {
        currentPoint = 0;
        targetPoint = points[currentPoint];
    }

    
    void Update()
    {
        if (obj.position == targetPoint.position)
        {
            if (forward == true)
                currentPoint++;
            else
                currentPoint--;

            if (currentPoint >= points.Length && cycle)            
                currentPoint = 0;
            else if (currentPoint >= points.Length && !cycle)
            {
                forward = false;
                currentPoint = points.Length - 2;
            }
            else if (currentPoint < 0)
            {
                forward = true;
                currentPoint = 1;
            }        

            targetPoint = points[currentPoint];
        }

        obj.position = Vector3.MoveTowards(obj.position, targetPoint.position, speed * Time.deltaTime);
    }
}
