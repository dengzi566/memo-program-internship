using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleController : MonoBehaviour
{
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        angle = Vector3.Angle(new Vector3(0,1,0), transform.position);
        if (transform.localPosition.x <= 0)
            angle = 360 - angle;
        //Debug.Log(angle);
        /*if (transform.localPosition.x>=0)*/
        transform.rotation = Quaternion.Euler(Vector3.back * angle);
        /*else
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);*/

    }
    public float GetAngle()
    {
        float angle = Vector3.Angle(new Vector3(0, 1, 0), transform.position);
        if (transform.localPosition.x <= 0)
            angle = -angle;
        return angle;
    }
}
