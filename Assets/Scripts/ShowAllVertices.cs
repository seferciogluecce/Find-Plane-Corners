using System.Collections.Generic;
using UnityEngine;

public class ShowAllVertices : MonoBehaviour
{

    List<Vector3> VerticeList = new List<Vector3>();
    List<Vector3> VerticeListToShow = new List<Vector3>();
    public float sphereSize = 0.5f;

    List<Color> Colors = new List<Color>() { Color.red, Color.blue, Color.yellow, Color.green, Color.cyan, Color.magenta,Color.gray,Color.black,Color.white,Color.red,Color.blue }; //each color for each column
    void OnDrawGizmos()
    {
        int b = 0; //b is used to divide points into columns 
        if (VerticeList.Count > 0)
            for (int a = 0; a < VerticeListToShow.Count; a ++)
            {
                Gizmos.color = Colors[b++ % Colors.Count]; 
                Gizmos.DrawSphere(VerticeListToShow[a], sphereSize);
            }
    }

    void Start()
    {
        VerticeList = new List<Vector3>(GetComponent<MeshCollider>().sharedMesh.vertices); //get vertice points from the mesh of the object
        foreach (Vector3 point in VerticeList) //all the points are added to be shown on the editor
        {
            VerticeListToShow.Add(transform.TransformPoint(point)); 
        }
    }

}
