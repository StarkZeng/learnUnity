using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class TouchMgr : MonoBehaviour
{
	public float _cameraZSpeed = 0.3f;

	private float _moveSacle = 0.01f;
	private float _cameraDefaultZ;
	private float _cameraCurZ;
	private float _scale = 1.0f;
	// Use this for initialization


	//注意点:
	//1.Unity中单位是1:100 pixel的比例 很多地方和像素交互要除去100 包括触摸和鼠标的输入
	//2.模拟器/真机触摸所获得的值是正确的 但是鼠标在Unity Editor中获得的X ,Y 输入是有偏差的
	//比如 通过 Input.GetAxis("Mouse X") 获得的 X方向上的移动和鼠标在X方向上的移动感觉是有偏差的
	//3.可以在Edit->Project Setting->Input 里面设置鼠标 灵敏度

	void Start()
	{
		_cameraDefaultZ = Camera.main.GetComponent<CameraView>().cameraZ;
		_cameraCurZ = _cameraDefaultZ;
		print(_cameraCurZ);
	}

	void Update()
	{
		UpdateMouseInput();
//		UpdateTouch();
	}

	private void UpdateMouseInput()
	{
		if (Input.GetKey("mouse 0"))
		{
			float moveX = Input.GetAxis("Mouse X");
			float moveY = Input.GetAxis("Mouse Y");
			Camera.main.transform.position -= new Vector3(moveX, moveY, 0) * _moveSacle / _scale;
		}

		if (Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			Camera.main.transform.position -= new Vector3(0, 0, _cameraZSpeed);

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

	private void UpdateTouch()
	{
		//there just right a litter,will complete when needed.
		int n = Input.touchCount;
		if (n > 0)
		{	
			//touch begin
			Touch touch0 = Input.GetTouch(0);
			if (touch0.phase == TouchPhase.Began)
			{

			}
			//drag
			if (n == 1)
			{
				if (touch0.phase == TouchPhase.Moved)
				{
					Vector2 move = touch0.deltaPosition;
					Debug.Log("move :" + move.x + "," + move.y);
					Camera.main.transform.position -= new Vector3(move.x, move.y, 0) / _scale / 100;
				}
			}

		}
	}

	private void calcScale()
	{
		_scale = _cameraDefaultZ / _cameraCurZ;

		Debug.Log("_cameraCurZ :" + _cameraCurZ);
		Debug.Log("_cameraDefaultZ :" + _cameraDefaultZ);
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

