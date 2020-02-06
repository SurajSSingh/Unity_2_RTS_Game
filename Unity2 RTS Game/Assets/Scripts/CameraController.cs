using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float speed = 0.25f;
    float zSpace = -10.0f;
    float maxHeight = 85f;
    float maxWidth = 90;
    float fullZoom = 25.0f;
    bool zoomedOut = false;
    Camera cam;
    
    void Start () 
    {
        cam = this.GetComponent<Camera>();
    }
        
    void Update () 
    {
        this.transform.position = NewPostion();
        if (Input.GetKeyDown(KeyCode.H))
        {
            this.transform.position = new Vector3(0.0f,0.0f,zSpace);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (zoomedOut)
            {
                zoomedOut = false;
                cam.orthographicSize -= fullZoom;
            }
            else
            {
                zoomedOut = true;
                cam.orthographicSize += fullZoom;
            }
        }

    }

    private Vector3 NewPostion()
    {
        Vector3 postion = this.transform.position;
        // Clamp x and y postions with in arena size
        float xPosChange = Mathf.Clamp(
            postion.x + Input.GetAxis("Horizontal") * speed,
            -maxHeight,
            maxHeight);
        float yPosChange = Mathf.Clamp(
            postion.y + Input.GetAxis("Vertical") * speed,
            -maxWidth,
            maxWidth);
        return new Vector3(xPosChange,yPosChange, zSpace);
    }
}
