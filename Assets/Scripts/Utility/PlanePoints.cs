//This script can be used for 
                            //Getting all the vertices on a plane
                            //Finding a random point on a plane
                            //Sharing the values to other game objects
//NOT TESTED
using System.Collections.Generic;
using UnityEngine;

public class PlanePoints : MonoBehaviour
{
    List<Vector3> EdgeVectors;
    List<Vector3> CornerPoints;
    List<Vector3> AllVertices;
    Vector3 RandomPoint;


    // Start is called before the first frame update
    void Start()
    {
        AllVertices = new List<Vector3>();
        CornerPoints = new List<Vector3>();
        EdgeVectors = new List<Vector3>();       
    }

    public List<Vector3> GetCornerPoints() {
        CalculateCornerPoints();
        return CornerPoints;
    }

    public List<Vector3> GetAllGlobalVertices() {
        FindAllVertices();
        return AllVertices;
    }

    public Vector3 GetRandomPoint()
    {
        CalculateRadomPoint();
        return RandomPoint;
    }

   void  CalculateEdgeVectors(int VectorCornerIdx)
    {
        CalculateCornerPoints();
        EdgeVectors.Clear();

        EdgeVectors.Add(CornerPoints[3] - CornerPoints[VectorCornerIdx]);
        EdgeVectors.Add(CornerPoints[1] - CornerPoints[VectorCornerIdx]);
    }

    void CalculateRadomPoint()
    {
        int randomCornerIdx = Random.Range(0, 2) == 0 ? 0 : 2; //there is two triangles in a plane, which tirangle contains the random point is chosen
                                                               //corner point is chosen for triangles as the variable

        CalculateEdgeVectors(randomCornerIdx);

        float u = Random.Range(0.0f, 1.0f);
        float v = Random.Range(0.0f, 1.0f);

        if (v + u > 1) //sum of coordinates should be smaller than 1 for the point be inside the triangle
        {
            v = 1 - v;
            u = 1 - u;
        }

        RandomPoint = CornerPoints[randomCornerIdx] + u * EdgeVectors[0] + v * EdgeVectors[1];

    }

    void CalculateCornerPoints()
    {
        FindAllVertices();
        CornerPoints.Clear(); //in case of transform changes corner points are reset

        CornerPoints.Add(AllVertices[0]); //corner points are added to show  on the editor
        CornerPoints.Add(AllVertices[10]);
        CornerPoints.Add(AllVertices[110]);
        CornerPoints.Add(AllVertices[120]);
    }

    void FindAllVertices()
    {
       List<Vector3> AllVerticesLocal = new List<Vector3>(GetComponent<MeshFilter>().sharedMesh.vertices); //get vertice points with local coordinates from the mesh of the object
        foreach (Vector3 point in AllVerticesLocal) //all the points are transformed into global points
        {
            AllVertices.Add(transform.TransformPoint(point));
        }
    }
}
