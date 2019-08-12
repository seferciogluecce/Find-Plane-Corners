using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointShower : MonoBehaviour
{

    GameObject SelectedPointSource;
    bool ShowAllPoints = true;
    bool ShowRandomPoints = true;
    Vector3 RandomPoint;
    void OnDrawGizmos()
    {
        if (SelectedPointSource != null)
        {
            if (ShowAllPoints)
            {
                if (SelectedPointSource.GetComponent<ObjectPoints>().GetObjectGlobalVertices().Count > 0)
                {
                    for (int a = 0; a < SelectedPointSource.GetComponent<ObjectPoints>().GetObjectGlobalVertices().Count/* / 4 - 2*/; a++)
                    {

                        Gizmos.color = Color.red;
                        Gizmos.DrawSphere(SelectedPointSource.GetComponent<ObjectPoints>().GetObjectGlobalVertices()[a], 0.5f);
                    }

                }
            }

            if (ShowRandomPoints)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawSphere(RandomPoint, 0.75f);

            }
        }
    }

    void Update()
    {
        //check if the left mouse has been pressed down this frame
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit; ;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.GetComponent<ObjectPoints>() != null )
                {
                    if(SelectedPointSource.name != hit.collider.gameObject.name)
                    { 
                        SelectedPointSource = hit.collider.gameObject;
                        GetRandomPoint();
                    }
                }
            }
        }

    }
    public void ToggleShowAllPoints()
    {
        ShowRandomPoints = !ShowRandomPoints;
    }

    public void ToggleShowRandomPoints()
    {
        ShowAllPoints = !ShowAllPoints;
    }

    public void GetRandomPoint()
    {
        RandomPoint = SelectedPointSource.GetComponent<ObjectPoints>().GetRandomPoint();
    }

}
