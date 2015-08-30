using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour
{

    Vector3 startPos;
    bool isTouches = false;

    // Use this for initialization
    void Start()
    {
    }
	
    // Update is called once per frame
    void Update()
    {
        // TODO raycast飛ばして何もなかったらカメラを移動させる
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            isTouches = true;
            return;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isTouches = false;
            return;
        }

        if (isTouches)
        {
            var screenPos = Input.mousePosition;
            var pos = screenPos - startPos;
            var camera = Camera.main;
            // 移動しすぎるので、適当に間引く
            // TODO あとで調整する
            pos.Scale(new Vector3(0.05f, 0.05f, 0.05f));
            pos.z = 0;
            pos.y = 0;
            camera.transform.Translate(pos);
            startPos = screenPos;

        }
    }
}
