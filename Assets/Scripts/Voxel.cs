using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Voxel
{
    public static readonly Vector3[] verts = new Vector3[8]
    {
        new Vector3(0.0f, 0.0f, 0.0f),
        new Vector3(1.0f, 0.0f, 0.0f),
        new Vector3(1.0f, 1.0f, 0.0f),
        new Vector3(0.0f, 1.0f, 0.0f),
        new Vector3(0.0f, 0.0f, 1.0f),
        new Vector3(1.0f, 0.0f, 1.0f),
        new Vector3(1.0f, 1.0f, 1.0f),
        new Vector3(0.0f, 1.0f, 1.0f),
    };

    public static readonly int[,] tris = new int[6, 6]
    {
        { 0, 3, 1, 1, 3, 2 },
        { 5, 6, 4, 4, 6, 7 },
        { 3, 7, 2, 2, 7, 6 },
        { 1, 5, 0, 0, 5, 4 },
        { 4, 7, 0, 0, 7, 3 },
        { 1, 2, 5, 5, 2, 6 },
    };

    public static readonly Vector2[] uvs = new Vector2[6]
    {
        new Vector2(0.0f, 0.0f),
        new Vector2(0.0f, 1.0f),
        new Vector2(1.0f, 0.0f),
        new Vector2(1.0f, 0.0f),
        new Vector2(0.0f, 1.0f),
        new Vector2(1.0f, 1.0f),
    };
}
