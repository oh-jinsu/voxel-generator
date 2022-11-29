using UnityEngine;

public static class Voxel
{
    public const int COUNT = 6;

    public static readonly Vector3[] VERTICES = new Vector3[8]
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

    public static readonly Vector3[] FACE_CHECKS = new Vector3[6] {
        new Vector3(0.0f, 0.0f, -1.0f),
        new Vector3(0.0f, 0.0f, 1.0f),
        new Vector3(0.0f, 1.0f, 0.0f),
        new Vector3(0.0f, -1.0f, 0.0f),
        new Vector3(-1.0f, 0.0f, 0.0f),
        new Vector3(1.0f, 0.0f, 0.0f),
    };

    public static readonly int[,] TRIANGLES = new int[6, 4]
    {
        { 0, 3, 1, 2 },
        { 5, 6, 4, 7 },
        { 3, 7, 2, 6 },
        { 1, 5, 0, 4 },
        { 4, 7, 0, 3 },
        { 1, 2, 5, 6 },
    };

    public static readonly Vector2[] UV = new Vector2[4]
    {
        new Vector2(0.0f, 0.0f),
        new Vector2(0.0f, 1.0f),
        new Vector2(1.0f, 0.0f),
        new Vector2(1.0f, 1.0f),
    };

    public class Texture
    {
        public const int ATLAS_SIZE = 4;

        public const float BLOCK_SIZE = 1f / ATLAS_SIZE;
    }
}
