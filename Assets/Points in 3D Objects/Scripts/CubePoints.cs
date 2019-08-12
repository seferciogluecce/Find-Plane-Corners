using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePoints : ObjectPoints
{

    int FaceCount = 6;
    int FaceVertexCount = 4;
    List<List<Vector3>> Faces = new List<List<Vector3>>();
  
    private int GetRandomFaceIndex()
    {
        return Random.Range(0, FaceCount - 1);
    }

    protected  override void CalculateCornerPoints()
    {
        base.CalculateCornerPoints();
        List<Vector3> OneFace = new List<Vector3>();

        for (int i = 0; i< ObjectVertices.Count;i++)
        {
            OneFace.Add(ObjectVertices[i]);
            if ((i + 1) % FaceVertexCount == 0)
            {
                Faces.Add(OneFace);
                OneFace = new List<Vector3>();
            }          
        }
        CornerPoints = ObjectUniqueVertices;
    }


    protected override void CalculateEdgeVectors(int VectorCornerIdx,int faceIndex)
    {
        base.CalculateEdgeVectors(VectorCornerIdx,faceIndex);
        EdgeVectors.Add(Faces[faceIndex][3] - Faces[faceIndex][VectorCornerIdx]);
        EdgeVectors.Add(Faces[faceIndex][1] - Faces[faceIndex][VectorCornerIdx]);
    }

    protected override void CalculateRandomPoint()
    {
        int randomCornerIdx = Random.Range(0, 2) == 0 ? 0 : 2;
        int randomFaceIdx = GetRandomFaceIndex();
        CalculateEdgeVectors(randomCornerIdx, randomFaceIdx);

        float u = Random.Range(0.0f, 1.0f);
        float v = Random.Range(0.0f, 1.0f);

        if (v + u > 1) //sum of coordinates should be smaller than 1 for the point be inside the triangle
        {
            v = 1 - v;
            u = 1 - u;
        }

        RandomPoint = Faces[randomFaceIdx][randomCornerIdx] + u * EdgeVectors[0] + v * EdgeVectors[1]; 
    }



}
