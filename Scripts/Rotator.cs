using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private Vector3 previousPosition;
    [SerializeField] private Vector3 oriPosition;
    [SerializeField] private Transform target;


    // public float speed;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);

        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = previousPosition -cam.ScreenToViewportPoint(Input.mousePosition);

            cam.transform.position = target.position;
            cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
            cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
            cam.transform.Translate(oriPosition);
            
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);

        }
        //  transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
