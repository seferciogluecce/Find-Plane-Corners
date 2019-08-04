using System.Collections.Generic;
using UnityEngine;

public class ShowCorners : MonoBehaviour
{

    List<Vector3> VerticeList = new List<Vector3>(); //List of global vertices on the plane
    List<Vector3> VerticeListToShow = new List<Vector3>();
    public int sphereSize = 1; 

    List<Color> CornerColors = new List<Color>() { Color.red, Color.blue, Color.yellow, Color.green }; //Different colors for different corners
    void OnDrawGizmos()
    {
        int b = 0;
        if (VerticeList.Count > 0)
            for (int a = 0; a < VerticeListToShow.Count; a++)
            {
                Gizmos.color = CornerColors[b++];
                Gizmos.DrawSphere(VerticeListToShow[a], sphereSize); //show coordinate as a sphere on editor
            }
    }


    // Start is called before the first frame update
    void Start()
    {
        VerticeList = new List<Vector3>(GetComponent<MeshCollider>().sharedMesh.vertices); //get vertice points from the mesh of the object

        SetCornerPoints();  
    }

    void Update()
    {
        SetCornerPoints();
    }

    public void SetCornerPoints()
    {
        VerticeListToShow.Clear(); //incase of transform changes corner points are reset

        VerticeListToShow.Add(transform.TransformPoint(VerticeList[0])); //corner points are added to show  on the editor
        VerticeListToShow.Add(transform.TransformPoint(VerticeList[10]));
        VerticeListToShow.Add(transform.TransformPoint(VerticeList[110]));
        VerticeListToShow.Add(transform.TransformPoint(VerticeList[120]));
    }

}
