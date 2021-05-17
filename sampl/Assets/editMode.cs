using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class editMode : MonoBehaviour
{

    private Vector3 mOffset;

    //public GameObject
    private float mZcoord;

     void OnMouseDown()
    {
        mZcoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZcoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = new Vector3(GetMouseWorldPos().x + mOffset.x, transform.position.y, GetMouseWorldPos().z + mOffset.z);   
    }


    void Start()
    {
        
    }
    void Update()
    {
         
    }
}
