using System;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path;
    [SerializeField] private GameObject prefab;
    [SerializeField] private List<GameObject> prefabPoints;
    
    private int currentPointIndex;

    public List<Waypoint> GetPath()
    {
        return path ??= new List<Waypoint>();
    }

    public void CreateAddPoint()
    {
        Waypoint go = new Waypoint();
        path.Add(go);
    }
    
    public Waypoint GetNextTarget()
    {
        int nextPointIndex = (currentPointIndex + 1) % (path.Count);
        currentPointIndex = nextPointIndex;
        return path[nextPointIndex];
    }

    public void Start()
    {
        prefabPoints = new List<GameObject>();
        foreach (Waypoint p in path)
        {
            GameObject go = Instantiate(prefab);
            go.transform.position = p.GetPos();
            prefabPoints.Add(go);
        }
    }

    public void Update()
    {
        for (int i = 0; i < path.Count; i++)
        {
            Waypoint p = path[i];
            GameObject g = prefabPoints[i];
            g.transform.position = p.GetPos();
        }
    }
}