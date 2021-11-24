using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PleaseRotate : MonoBehaviour
{
    public float rotateSpeedX;
    public float rotateSpeedY;
    public float rotateSpeedZ;
    // Update is called once per frame
    void Update()
    {
        Quaternion rotateTemp = transform.rotation;
        rotateTemp.x += rotateSpeedX * Time.deltaTime;
        rotateTemp.y += rotateSpeedY * Time.deltaTime;
        rotateTemp.z += rotateSpeedZ * Time.deltaTime;
        if (rotateTemp.x >= -182 && rotateTemp.x <= -180)
        {
            rotateTemp.x = -178;
        }
        if (rotateTemp.y >= -182 && rotateTemp.y <= -180)
        {
            rotateTemp.y = -178;
        }
        if (rotateTemp.z >= -182 && rotateTemp.z <= -180)
        {
            rotateTemp.z = -178;
        }
        transform.rotation = rotateTemp;
    }
}
