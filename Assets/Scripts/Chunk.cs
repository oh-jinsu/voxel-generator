using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    const int SIZE_X = 64;

    const int SIZE_Y = 3;

    const int SIZE_Z = 64;

    [SerializeField]
    private World world;

    [SerializeField]
    private MeshRenderer meshRenderer;

    [SerializeField]
    private MeshFilter meshFilter;

    private int vertexIndex = 0;

    private readonly List<Vector3> vertices = new();

    private readonly List<int> triangles = new();

    private readonly List<Vector2> uv = new();

    private readonly byte[,,] voxelMap = new byte[SIZE_X, SIZE_Y, SIZE_Z];

    private void Start()
    {
        PopulateVoxelmap();

        CreateChunk();

        CreateMesh();
    }

    void PopulateVoxelmap()
    {
        for (int y = 0; y < SIZE_Y; y++)
        {
            for (int x = 0; x < SIZE_X; x++)
            {
                for (int z = 0; z < SIZE_Z; z++)
                {
                    voxelMap[x, y, z] = 0;
                }
            }
        }
    }

    void CreateChunk()
    {
        for (int y = 0; y < SIZE_Y; y++)
        {
            for (int x = 0; x < SIZE_X; x++)
            {
                for (int z = 0; z < SIZE_Z; z++)
                {
                    AddVoxelDataToChunk(new Vector3(x, y, z));
                }
            }
        }
    }

    bool CheckVoxel (Vector3 position)
    {
        var x = Mathf.FloorToInt(position.x);

        if (x < 0 || x > SIZE_X - 1)
        {
            return false;
        }

        var y = Mathf.FloorToInt(position.y);

        if (y < 0 || y > SIZE_Y - 1)
        {
            return false;
        }

        var z = Mathf.FloorToInt(position.z);

        if (z < 0 || z > SIZE_Z - 1)
        {
            return false;
        }

        return world.Blocks[voxelMap[x, y, z]].IsSolid;
    }

    private void AddVoxelDataToChunk(Vector3 position)
    {
        for (int i = 0; i < Voxel.COUNT; i++)
        {
            if (CheckVoxel(position + Voxel.FACE_CHECKS[i]))
            {
                continue;
            }

            vertices.Add(position + Voxel.VERTICES[Voxel.TRIANGLES[i, 0]]);
            vertices.Add(position + Voxel.VERTICES[Voxel.TRIANGLES[i, 1]]);
            vertices.Add(position + Voxel.VERTICES[Voxel.TRIANGLES[i, 2]]);
            vertices.Add(position + Voxel.VERTICES[Voxel.TRIANGLES[i, 3]]);

            AddTexture(9);

            triangles.Add(vertexIndex);
            triangles.Add(vertexIndex + 1);
            triangles.Add(vertexIndex + 2);
            triangles.Add(vertexIndex + 2);
            triangles.Add(vertexIndex + 1);
            triangles.Add(vertexIndex + 3);

            vertexIndex += 4;
        }
    }

    private void CreateMesh()
    {
        var mesh = new Mesh()
        {
            vertices = vertices.ToArray(),
            triangles = triangles.ToArray(),
            uv = uv.ToArray(),
        };

        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;
    }

    void AddTexture(int id)
    {
        float x = (id % Voxel.Texture.ATLAS_SIZE) * Voxel.Texture.BLOCK_SIZE;

        float y = 1 - (Mathf.Floor(id / Voxel.Texture.ATLAS_SIZE) + 1) * Voxel.Texture.BLOCK_SIZE;

        Debug.Log(x + "," + y);

        uv.Add(new Vector2(x, y));
        uv.Add(new Vector2(x, y + Voxel.Texture.BLOCK_SIZE));
        uv.Add(new Vector2(x + Voxel.Texture.BLOCK_SIZE, y));
        uv.Add(new Vector2(x + Voxel.Texture.BLOCK_SIZE, y + Voxel.Texture.BLOCK_SIZE));
    }
}
