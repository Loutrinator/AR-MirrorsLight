using System.Collections.Generic;
using UnityEngine;

public class LaserSource : MonoBehaviour
{
    public int amountOfBounces = 2;
    public LineRenderer laserPrefab;
    private LineRenderer laser;

    private List<Vector3> positions;

    private void Start()
    {
        positions = new List<Vector3>();
        StartEmitting();
    }

    private void StartEmitting()
    {
        laser = Instantiate(laserPrefab, Vector3.zero, Quaternion.Euler(0, 90, 0), transform);
    }

    void FixedUpdate()
    {
        ComputeLaser();
    }
    void ComputeLaser()
    {
        positions.Clear();
        laser.positionCount = positions.Count;
        positions.Add(transform.position);

       
        
        Debug.Log( ShootRaycast(0,transform.forward));
        Debug.Log(positions);
        laser.positionCount = positions.Count;
        laser.SetPositions(positions.ToArray());
    }

    private bool ShootRaycast(int amountShot, Vector3 forward)
    {
        if (amountShot >= amountOfBounces)
        {
            return true;
        }
        
        RaycastHit hit;
        if (Physics.Raycast(positions[positions.Count-1], forward, out hit, 10f))
        {
            Debug.Log(hit);
            positions.Add(hit.point);
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Mirror"))
            {
                //v1 = -2 * (v0 . N) * N + v0
                Vector3 v0 = forward.normalized;
                Vector3 v1 = Vector3.Reflect(v0, hit.normal);//-2 * Vector3.Dot(v0,hit.normal) * hit.normal + v0;
                return ShootRaycast(amountShot++,v1);
            }
            
        }else //if(positions.Count <= 1)
        {
            
            positions.Add(forward*1000);
        }

        return false;
    }
}
