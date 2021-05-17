using UnityEngine;

[System.Serializable]
public class objectData 
{
    public float[] position;
    public float[] rotation;
   
    public string objname;
    public objectData(rotate sp)
    {

        Vector3 objectPos = sp.transform.position;
        Quaternion objectRot = sp.transform.rotation;
        objname = sp.objname;

            position = new float[]
            {
            objectPos.x,objectPos.y,objectPos.z
            };
         rotation = new float[]
           {
            objectRot.x,objectRot.y,objectRot.z
           };



    }
    
   
}
