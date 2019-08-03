using System.Collections.Generic;
using UnityEngine;

public class ShowCorners : MonoBehaviour
{

    List<Vector3> VerticeList = new List<Vector3>();
    List<Vector3> VerticeListToShow = new List<Vector3>();
    public int sphereSize = 1;

    List<Color> CornerColors = new List<Color>() { Color.red, Color.blue, Color.yellow, Color.green };
    void OnDrawGizmos()
    {
        int b = 0;
        if (VerticeList.Count > 0)
            for (int a = 0; a < VerticeListToShow.Count; a++)
            {
                Gizmos.color = CornerColors[b++];
                Gizmos.DrawSphere(VerticeListToShow[a], sphereSize);
            }
    }


    // Start is called before the first frame update
    void Start()
    {
        VerticeList = new List<Vector3>(GetComponent<MeshCollider>().sharedMesh.vertices);

        SetCornerPoints();  
    }

    void Update()
    {
        SetCornerPoints();
    }

    public void SetCornerPoints()
    {
        VerticeListToShow.Clear();

        VerticeListToShow.Add(transform.TransformPoint(VerticeList[0]));
        VerticeListToShow.Add(transform.TransformPoint(VerticeList[10]));
        VerticeListToShow.Add(transform.TransformPoint(VerticeList[110]));
        VerticeListToShow.Add(transform.TransformPoint(VerticeList[120]));
    }

}
