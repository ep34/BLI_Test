using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonManager : MonoBehaviour
{
    public bool isCube;
    public bool isSphere;

    public void spawnCube()
    {
        isCube = true;
        isSphere = false;
    }
    public void spawnSphere()
    {
        isSphere = true;
        isCube = false;
    }

}
