using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(SplineCreator))]
public class TrackHandler : MonoBehaviour
{

    private SplineCreator sc;
    private GameObject track;

    private void Awake()
    {
        sc = GetComponent<SplineCreator>();
        sc.GenerateVoronoi();
        if (sc.Spline == null)
        {
            sc.Spline = new Spline();
        }
        sc.GenerateSpline();
        track = sc.CreateTrack();


        String path = Application.dataPath + "/CenterLine.txt";
        Debug.Log(path);
        using (StreamWriter sw = File.CreateText(path))
        {
            sw.WriteLine("[");
            foreach (var pos in sc.Spline.AllRawPoints)
            {
                sw.WriteLine(string.Format("({0}, {1}),", pos.x, pos.z));
            }
            sw.WriteLine("]");
        }
    }
}
