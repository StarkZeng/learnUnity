using UnityEngine;
using System.Collections;


//设置
//1.摄像机到地面的默认距离
public class CameraView : MonoBehaviour
{
    public float cameraZ{ get; set; }
    void Awake()
    {

        Camera camera = Camera.main;
        float w = (float)Screen.width;
        float h = (float)Screen.height;

        print(w);
        print(h);

        float fov = camera.fieldOfView;
        float near = camera.nearClipPlane;
        float far = camera.farClipPlane;

        cameraZ = ((float)h / 2) / Mathf.Tan(fov / 2 * Mathf.Deg2Rad)  / 100 - near;

        camera.transform.position = new Vector3(0, 0, -cameraZ);
        camera.aspect = w / h;

    }
}