using UnityEngine;
using System.Collections;

public class SpherePoints : ObjectPoints
{
    float SphereSize = 1;

    public float GetSphereSize()
    {
        return SphereSize;
    }

    public void SetSphereSize(float size)
    {
        SphereSize = size;
    }

    protected override void CalculateRandomPoint()
    {
        RandomPoint = (Random.Range(0, 2) == 0) ? WholeCoverageRandomPoint() : QuickRandomPoint();
    }

    private Vector3 WholeCoverageRandomPoint()  //Random point chosen from any direction from the center of the sphere
    {
        Vector3 DirectionVector = new Vector3(  Random.Range(-1.0f, 1.0f),  //random direction vector
                                                Random.Range(-1.0f, 1.0f),
                                                Random.Range(-1.0f, 1.0f));
        DirectionVector.Normalize();
        float HalfRadius = GetComponent<Renderer>().bounds.extents.magnitude / 2; 
        return transform.position + DirectionVector * ( HalfRadius + SphereSize ); //center moved along the direction vector by radius
    }

    private Vector3 QuickRandomPoint() //random point chosen from the points on the sphere mesh
    {
        return ObjectUniqueVertices[Random.Range(0, ObjectUniqueVertices.Count)]; 
    }

}
