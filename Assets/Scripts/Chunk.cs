using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer meshRenderer;

    [SerializeField]
    private MeshFilter meshFilter;

    private void Start()
    {
        var vertices = new List<Vector3>();

        var triangles = new List<int>();

        var uv = new List<Vector2>();

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j ++)
            {
                int index = Voxel.tris[i, j];

                vertices.Add(Voxel.verts[index]);

                uv.Add(Voxel.uvs[j]);

                triangles.Add(i * 6 + j);
            }
        }

        var mesh = new Mesh()
        {
            vertices = vertices.ToArray(),
            triangles = triangles.ToArray(),
            uv = uv.ToArray(),
        };

        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;
    }
}
