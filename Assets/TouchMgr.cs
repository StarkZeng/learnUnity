using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class TouchMgr : MonoBehaviour {
    public float _moveSacle = 1.0f;
    public float _cameraZSpeed = 0.3f;


    private float _cameraDefaultZ;
    private float _cameraCurZ;
    private float _scale = 1.0f;
    // Use this for initialization
    void Start () {
        _cameraDefaultZ = Camera.main.GetComponent<CameraView>().cameraZ;
        _cameraCurZ = _cameraDefaultZ;
        print(_cameraCurZ);
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKey("mouse 0"))
        {
            float moveX = Input.GetAxis("Mouse X");
            float moveY = Input.GetAxis("Mouse Y");
            print("moveX :" + moveX);
            print("moveY :" + moveY);
            Camera.main.transform.position -= new Vector3(moveX , moveY, 0)  * _moveSacle / _scale;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Camera.main.transform.position -= new Vector3(0,0, _cameraZSpeed);

            _cameraCurZ -= _cameraZSpeed;
            calcScale();
        }
        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Camera.main.transform.position += new Vector3(0, 0, _cameraZSpeed);
            _cameraCurZ += _cameraZSpeed;
            calcScale();
        }
    }

    private void calcScale()
    {
        _scale = _cameraCurZ/_cameraDefaultZ;
        Debug.Log("scale :" + _scale);
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

