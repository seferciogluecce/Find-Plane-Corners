using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CylinderPoints: ObjectPoints
{

    protected override void CalculateRandomPoint() //random point is chosen from the side plane of the cylinder
    {                                               //TODO add random point finding for the whole of the side plane                                            
        base.CalculateRandomPoint();                //TODO add random point finding for circle faces
        int idx = Random.Range(0, (ObjectUniqueVertices.Count - 2)/2  ); //index of the first circle's vertex
        float DistanceWeight = Random.Range(0.0f, 1.0f); //distance weighted from the first circle's vertex

        Vector3 Direction = ObjectUniqueVertices[idx + (ObjectUniqueVertices.Count / 2) - 1] - ObjectUniqueVertices[idx];//direction of the side of the cylinder on chosen vertex
        RandomPoint = Direction * DistanceWeight + ObjectUniqueVertices[idx];
    }



}
