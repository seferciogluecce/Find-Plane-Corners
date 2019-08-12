﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoints : MonoBehaviour
{
    protected List<Vector3> ObjectVertices;
    protected List<Vector3> ObjectUniqueVertices;
    protected List<Vector3> ObjectLocalVertices;
    protected List<Vector3> CornerPoints;
    protected List<Vector3> EdgeVectors;
    protected Vector3 RandomPoint;

     void Start()
    {
        ObjectVertices = new List<Vector3>();
        ObjectUniqueVertices = new List<Vector3>();
        ObjectLocalVertices = new List<Vector3>();
        CornerPoints = new List<Vector3>();
        EdgeVectors = new List<Vector3>();
        CalculateObjectVertices();
        Debug.Log("Hello! " + gameObject.name + " speaking. Total number of vertices:" + ObjectVertices.Count + ", Total number of distinct vertices: " + ObjectUniqueVertices.Count);
    }

    public List<Vector3> GetCornerPoints()
    {
        CalculateCornerPoints();
        return CornerPoints;
    }

    public List<Vector3> GetObjectGlobalVertices()
    {
        CalculateObjectVertices();
        return ObjectVertices;
    }

    public List<Vector3> GetObjectLocalVertices()
    {
        CalculateObjectVertices();
        return ObjectLocalVertices;
    }

    public Vector3 GetRandomPoint()
    {
        CalculateRandomPoint();
        return RandomPoint;
    }

    private void CalculateObjectVertices()
    {
        ObjectLocalVertices.Clear();
        ObjectVertices.Clear();
        ObjectUniqueVertices.Clear();
        ObjectLocalVertices = new List<Vector3>(GetComponent<MeshFilter>().sharedMesh.vertices); //get vertice points with local coordinates from the mesh of the object
        foreach (Vector3 point in ObjectLocalVertices) //all the points are transformed into global points
        {
            ObjectVertices.Add(transform.TransformPoint(point));
        }
        ObjectUniqueVertices = ObjectVertices.Distinct().ToList();
    }

    protected virtual void CalculateEdgeVectors(int VectorCornerIdx)
    {
        CalculateCornerPoints();
        EdgeVectors.Clear();
        //It is up to child to fill the vectors
    }

    protected virtual void CalculateEdgeVectors(int VectorCornerIdx, int vectorfaceidx)
    {
        CalculateCornerPoints();
        EdgeVectors.Clear();
        //It is up to child to fill the vectors
    }

    protected virtual void CalculateRandomPoint(){}

    protected virtual void CalculateCornerPoints()
    {
        CalculateObjectVertices();
        CornerPoints.Clear(); //in case of transform changes corner points are reset
        //It is up to child to how to calculate corner points
    }

}
