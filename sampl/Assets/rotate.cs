using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;
    public bool rotating;
    public bool editMode = false;
    float rotSpeed = 20;
    private GameObject select;
    public string objname;
   // public GameObject saveSystem;

    void Start()
    {
        select = GameObject.Find("selct"); 
    }

    /*
     void Awake()
    {
        if(objname.Contains("sphere"))
        {
            print("new sphere");
            saveSystem.spheres.Add(this);
        }
        else
        {
            print("new cube");
            saveSystem.cubes.Add(this);
        }
       
      // saveSystem.GetComponent<saveSystem>()
    }
    */
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            print("r pressed");
            rotating = !rotating;
                      
        
            
         

        }
       
        if(rotating && (select.GetComponent<selct>().editNow == this.gameObject.name))
        {
           
            rotateCube(); 
        }
        if(select.GetComponent<selct>().editNow == this.gameObject.name)
        {
            editMode = true;
            this.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            editMode = false;
            rotating = false;
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
            
        }

        print("rotate code er rotate "+this.transform.localRotation.y);
    }

    private void OnMouseDown()
    {
        // editMode = !editMode;
        if (select.GetComponent<selct>().editNow != this.gameObject.name)
        {
            select.GetComponent<selct>().editNow = this.gameObject.name;
        }
        else
        {
            select.GetComponent<selct>().editNow = null;
        }
       
        print(this.gameObject.name);
    }
    void rotateCube()
    {

        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

        transform.RotateAround(Vector3.up, -rotX);
        transform.RotateAround(Vector3.down, rotY);
       
    }
}
