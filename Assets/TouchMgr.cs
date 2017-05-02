using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class TouchMgr : MonoBehaviour {



    public float moveSacle = 0.23f;
    public float cameraDefaultZ = -6.6757f;
    public float zSpeed = 0.3f;
    public GameObject layerScane;


    private Vector3 zMoveVec;
    private float cameraZ;
    private float scale = 1.0f;
    // Use this for initialization
    void Start () {
        if(!layerScane)
            layerScane = GameObject.Find("layerScane");

        Assert.IsNotNull(layerScane);
        zMoveVec = new Vector3(0, 0, zSpeed);
        cameraZ = cameraDefaultZ;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKey("mouse 0"))
        {
            float moveX = Input.GetAxis("Mouse X");
            float moveY = Input.GetAxis("Mouse Y");
            Camera.main.transform.position -= new Vector3(moveX , moveY, 0)  * moveSacle / scale;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Camera.main.transform.position -= zMoveVec;

            cameraZ -= zMoveVec.z;
            calcScale();
        }
        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Camera.main.transform.position += zMoveVec;
            cameraZ += zMoveVec.z;
            calcScale();
        }
    }

    private void calcScale()
    {
        scale = cameraDefaultZ/cameraZ;
        Debug.Log("scale :" + scale);
    }
}

//var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//var hit : RaycastHit;
//if (Physics.Raycast (ray, hit, 100)) {
//    var target: GameObject = hit.collider.gameObject//获得点击的物体
//       if(Input.getMouseButtonDown("0"))
//       {
//        target.transform.position = (Input.mousePosition);
//       }
//}

