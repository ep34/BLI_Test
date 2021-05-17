using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{

    public Transform _plane;
    public GameObject spawnablePrefab;
    public GameObject spawnableSphere;
    public GameObject buttonHandler;

    public bool itsCube;
    public bool itsSphere;
  

    public int count;
    public int countforSp;

    
    void Start()
    {
       
        Vector3 planesize = GetComponent<MeshCollider>().bounds.size;
       
    }

     void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out hit))
            {
                if(hit.transform.name == "Plane")
                {
                    //spawn cube
                    if (buttonHandler.GetComponent<buttonManager>().isCube == true)
                    {
                        GameObject gg;
                       gg = Instantiate(spawnablePrefab, hit.point, Quaternion.identity);

                        gg.name = "cube" + countforSp;
                        gg.GetComponent<rotate>().objname = gg.name;
                        countforSp++;
                        itsCube = true;
                        itsSphere = false;

                        saveSystem.cubes.Add(gg.GetComponent<rotate>());
                        print(gg.name);
                    }
                   
                    //spawn sphere
                    if (buttonHandler.GetComponent<buttonManager>().isSphere == true)
                    {
                        GameObject spheregg;
                       spheregg =  Instantiate(spawnableSphere, hit.point, Quaternion.identity);
                        spheregg.name = "sphere" + count;
                        spheregg.GetComponent<rotate>().objname = spheregg.name;
                        count++;
                        print(spheregg.name);
                        itsSphere = true;
                        itsCube = false;
                        saveSystem.spheres.Add(spheregg.GetComponent<rotate>());
                        print(spheregg.name);
                    }
                    
                }

                

            }
        }
    }

   
}
