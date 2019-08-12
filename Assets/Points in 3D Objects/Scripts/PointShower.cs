using UnityEngine;

public class PointShower : MonoBehaviour
{

    GameObject SelectedPointSource; //Object that the points will be shown

    bool ShowAllPoints = true; 
    bool ShowRandomPoint = true;
    Vector3 RandomPoint;
    void OnDrawGizmos()
    {
        if (SelectedPointSource != null)
        {
            if (ShowAllPoints)
            {
                if (SelectedPointSource.GetComponent<ObjectPoints>().GetObjectUniqueVertices().Count > 0)
                {
                    for (int a = 0; a < SelectedPointSource.GetComponent<ObjectPoints>().GetObjectUniqueVertices().Count; a++) //unique points on the object mesh is shown
                    {

                        Gizmos.color = Color.red;
                        Gizmos.DrawSphere(SelectedPointSource.GetComponent<ObjectPoints>().GetObjectUniqueVertices()[a], 0.5f);
                    }

                }
            }

            if (ShowRandomPoint) //random point on the object is shown
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawSphere(RandomPoint, 0.75f);
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //the target object to show points is chosen by mouse click on it
        {
            RaycastHit hit; ;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.GetComponent<ObjectPoints>() != null ) //FIX everytime the selected object clicked on, new random point is calculated
                {
                        SelectedPointSource = hit.collider.gameObject;
                        GetRandomPoint();                   
                }
            }
        }

    }
    public void ToggleShowAllPoints()
    {
        ShowRandomPoint = !ShowRandomPoint;
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
