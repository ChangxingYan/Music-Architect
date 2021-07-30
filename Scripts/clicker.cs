using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clicker : MonoBehaviour
{


    List<Transform> transformRecord = new List<Transform>();


    public LineRenderer lineRend;
    private Vector3 mousePos;
    private Vector3 startMousePos;
    public Instantiator instantiator;
    public int lightUpNum = 0;

    private void Start()
    {
        lineRend = GetComponent<LineRenderer>();
    }
    

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
        }

    }

    public void OnMouseDown()
    {
       
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "node")
                {
                    transformRecord.Add(hit.transform);
                    LightUp(hit.transform.gameObject);
                /*lineRend.positionCount = counter;
                lineRend.SetPosition(counter, new Vector3(startMousePos.x, startMousePos.y, 0f));*/
            }
            }





}

    public void OnMouseUp()
     {
         RaycastHit hit;
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

         if (Physics.Raycast(ray, out hit))
         {
             if (hit.collider.tag == "node" && !this.gameObject)
             {
                 transformRecord.Add(hit.transform);
                 LightUp(hit.transform.gameObject);

                 //lineRend.positionCount = counter;
                 //lineRend.SetPosition(counter, new Vector3(startMousePos.x, startMousePos.y, 0f));
             }
         }
     }

   

        
    public void LightUp(GameObject node)
    {

        transformRecord.Add(node.transform);
        Debug.Log(transformRecord);
        //play sound effect here

    }
}
