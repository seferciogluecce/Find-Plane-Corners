using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CylinderPoints: ObjectPoints
{

    protected override void CalculateRandomPoint()
    {
        base.CalculateRandomPoint();
        int idx = Random.Range(0, (ObjectUniqueVertices.Count - 2)/2  );       
        float distance = Random.Range(0.0f, 1.0f);
        Debug.Log(idx + " " + (idx + (ObjectUniqueVertices.Count / 2) - 1));

        Vector3 vect = ObjectUniqueVertices[idx + (ObjectUniqueVertices.Count / 2) - 1] - ObjectUniqueVertices[idx];
        RandomPoint = vect * distance + ObjectUniqueVertices[idx];
    }



}
