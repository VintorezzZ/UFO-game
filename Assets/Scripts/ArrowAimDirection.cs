using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArrowAimDirection : MonoBehaviour
{
    public Rigidbody ufo_rb;
    //public GameObject ufo_gm;
    //public Transform ufo;
    //public GameObject arrow;
    public RectTransform pointer;
    //public RectTransform rectTranArrow;

    private void Start()
    {
        //rectTranArrow = gameObject.GetComponent<RectTransform>();
    }
    void FixedUpdate()
    {
        //arrow.localRotation = Quaternion.Euler(0, 0, ufo.velocity.x * 10);
 
        pointer.anchoredPosition = new Vector2(ufo_rb.velocity.x * 1.5f, ufo_rb.velocity.y * 1.5f);

        //// Get Angle in Radians
        //float AngleRad = Mathf.Atan2(ufo_gm.transform.position.y - rectTranArrow.transform.position.y, ufo_gm.transform.position.x - rectTranArrow.transform.position.x);
        //// Get Angle in Degrees
        //float AngleDeg = (180 / Mathf.PI) * AngleRad;
        //// Rotate Object
        //this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);






        //Vector3 fromPosition = Camera.main.WorldToScreenPoint(ufo_gm.transform.position);
        //fromPosition.z = 0;
        //Vector3 toPosition = ufo_gm.transform.position;
        //Vector3 directionToFace = (fromPosition - toPosition).normalized;
        //transform.rotation = Quaternion.LookRotation(directionToFace);

        ////Debug.DrawRay(transform.position, directionToFace, Color.green);
        //Vector3 direction = (ufo.position - transform.position).normalized;

        //float angleRad = Mathf.Atan2(direction.y, direction.x);
        //float angleDeg = angleRad * 57.2957795f;
        //transform.localEulerAngles = new Vector3(0, 0, angleDeg);


        //Vector3 direction = Camera.main.ScreenToWorldPoint(ufo.position);
        //var screenVec = new Vector3(direction.x - Screen.width/2, Screen.height - direction.y - Screen.height / 2, 0);
        //float angle = (Mathf.Atan2(screenVec.y, screenVec.x) * Mathf.Rad2Deg) + 90;
        ////Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        ////transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5 * Time.deltaTime);
        //if (angle < 0) 
        //    angle += 360;
        //if (angle != 0) transform.RotateAround(transform.position, transform.forward, -angle);


        //Vector3 up = ufo.up;
        //float dist = Vector3.Magnitude(ufo.position - Camera.main.transform.position);
        //Vector3 over = ufo.position - (Camera.main.transform.position + Camera.main.transform.forward * dist);
        //float ang = Vector3.Angle(up, over);
        //if (over.x < 0)
        //    this.transform.localRotation = Quaternion.Euler(0, 0, ang);
        //else
        //    this.transform.localRotation = Quaternion.Euler(0, 0, -ang);


        //Vector3 dist = transform.InverseTransformDirection(ufo.position - transform.position);
        //float angle = Mathf.Atan2(-dist.x, dist.z) * Mathf.Rad2Deg;
        //transform.eulerAngles = new Vector3(0, 0, angle);


        //Vector3 v = ufo.position;

        ////z is meaningless

        //v.z = 0;

        ////arrow always looks forward so it will show correctly to viewer, and world-up changes the rotation

        //transform.LookAt(transform.position + transform.forward, v - transform.position);
    }
}
