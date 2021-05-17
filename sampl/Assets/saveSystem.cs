using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class saveSystem : MonoBehaviour
{
    public static List<rotate> cubes = new List<rotate>();
    public static List<rotate> spheres = new List<rotate>();
   

    const string OBJ_SUB = "/pref";
    const string OBJ_COUNT_SUB = "/pref.count";
    [SerializeField] rotate sPrefab;
    [SerializeField] rotate spherePrefab;
    public GameObject spawn;

    void Awake()
    {
        spawn.GetComponent<spawn>().count = 0;
        spawn.GetComponent<spawn>().countforSp = 0;
        loadObj();
    }

     void OnApplicationQuit()
    {
        cubes.RemoveAll(i => i == null);
        spheres.RemoveAll(i => i == null);
         cubes.AddRange(spheres);
        saveObj(cubes);
        
    }

    void saveObj(List<rotate> lists)
    {
        
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + OBJ_SUB + SceneManager.GetActiveScene().buildIndex;
        
        string Countpath = Application.persistentDataPath + OBJ_COUNT_SUB + SceneManager.GetActiveScene().buildIndex;
      

        FileStream countStream = new FileStream(Countpath, FileMode.Create);
        formatter.Serialize(countStream, lists.Count);
        countStream.Close();
        print("List Count " + lists.Count);
        for(int i=0;i<lists.Count;i++)
        {
            FileStream stream = new FileStream(path + i, FileMode.Create);
            objectData data = new objectData(lists[i]);
            print("Saving " + data.objname+" "+lists[i].objname);
            formatter.Serialize(stream, data);
            stream.Close();

        }

    }

    void loadObj()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + OBJ_SUB + SceneManager.GetActiveScene().buildIndex;
    
         string Countpath = Application.persistentDataPath + OBJ_COUNT_SUB + SceneManager.GetActiveScene().buildIndex;
      
        int objCount = 0;

        if(File.Exists(Countpath))
        {
            FileStream countStream = new FileStream(Countpath,FileMode.Open);
            objCount = (int) formatter.Deserialize(countStream);
          
            print(spawn.GetComponent<spawn>().countforSp);
            countStream.Close();
            print(objCount);
        }
        else
        {
            Debug.LogError("Path not found " + Countpath);
        }
        print("objCount " + objCount);
        for (int i=0;i<objCount;i++)
        {
            if(File.Exists(path+i))
            {
                FileStream stream = new FileStream(path + i, FileMode.Open);
                objectData data = formatter.Deserialize(stream) as objectData;
                stream.Close();
                print("data objname "+data.objname);
      
                if (data.objname.Contains("sphere"))
                {
                    print("eter");
                    Vector3 positionSphere = new Vector3(data.position[0], data.position[1], data.position[2]);
                    rotate spHere = Instantiate(spherePrefab, positionSphere, Quaternion.identity);
                    spHere.name = data.objname;
                    spHere.objname = spHere.name;
                    spawn.GetComponent<spawn>().count++;
                    spheres.Add(spHere);
                }

                if(data.objname.Contains("cube"))
                {
                   
                    Vector3 position = new Vector3(data.position[0], data.position[1], data.position[2]);

                   
                    
                    rotate sp = Instantiate(sPrefab, position,Quaternion.Euler(data.rotation[0] * 100f, data.rotation[1] * 100, data.rotation[2]));
                    print("rotate"+data.rotation[1]);
                    
                    sp.name = data.objname;
                    sp.objname = sp.name;
                    spawn.GetComponent<spawn>().countforSp++;
                    cubes.Add(sp);
                }
                
              

            }
            else
            {
                Debug.LogError("Path not found " + path + i);
            }
            
        }
    }
}
