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

    private Vector3 WholeCoverageRandomPoint()
    {
        Vector3 DirectionVector = new Vector3(  Random.Range(-1.0f, 1.0f),
                                                Random.Range(-1.0f, 1.0f),
                                                Random.Range(-1.0f, 1.0f));
        DirectionVector.Normalize();
        float HalfRadius = GetComponent<Renderer>().bounds.extents.magnitude / 2;
        return transform.position + DirectionVector * ( HalfRadius + SphereSize );
    }

    private Vector3 QuickRandomPoint()
    {
        return ObjectUniqueVertices[Random.Range(0, ObjectUniqueVertices.Count)];
    }

}
