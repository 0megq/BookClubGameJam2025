using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class BakeNormalsToVertexColors : MonoBehaviour
{
    void Start()
    {
        BakeNormals();
    }

    void BakeNormals()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        Dictionary<Vector3, HashSet<int>> dupes = new Dictionary<Vector3, HashSet<int>>();

        // Get all duplicated vertices at the same point
        for (int i = 0; i < vertices.Length; i++)
        {
            for (int j = i + 1; j < vertices.Length; j++)
            {
                if (vertices[i] == vertices[j])
                {
                    Vector3 pos = vertices[i];
                    if (!dupes.ContainsKey(pos))
                    {
                        dupes.Add(pos, new HashSet<int>());
                    }
                    dupes[pos].Add(i);
                    dupes[pos].Add(j);
                }
            }
        }

        Vector3[] normals = mesh.normals;
        Color[] colors = new Color[normals.Length];

        // initalize the colors
        for (int i = 0; i < normals.Length; i++)
        {
            Vector3 temp = (normals[i] + Vector3.one) / 2;
            colors[i] = new Color(temp.x, temp.y, temp.z);
        }

        // for each set of dupes update the color to be the averaged normals
        foreach (HashSet<int> key in dupes.Values)
        {
            // average the normal across the dupes
            Vector3 normal = Vector3.zero;
            foreach (int index in key)
            {
                normal += normals[index];
            }
            normal = normal.normalized;

            // prep normal to be stored as a color
            normal += Vector3.one; // so we stay positive
            normal /= 2;           // 0 - 2 -> 0 - 1

            // set the normal of each to the average
            foreach (int index in key)
            {
                colors[index] = new Color(normal.x, normal.y, normal.z);
            }
        }
        mesh.colors = colors;
    }
}