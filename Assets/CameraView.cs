using UnityEngine;
using System.Collections;


//设置
//1.摄像机到地面的默认距离
public class CameraView : MonoBehaviour
{
    void Start()
    {
        float w = (float)Screen.width;
        float h = (float)Screen.height;

        float fov = Camera.main.fov;
        float near = Camera.main.near;
        float far = Camera.main.far;

        print(Mathf.Tan(fov / 2 * Mathf.Deg2Rad));

        float z = ((float)h / 2) / 100 / Mathf.Tan(fov / 2 * Mathf.Deg2Rad);
        print(z);
    }


    void Update()
    {

    }
}