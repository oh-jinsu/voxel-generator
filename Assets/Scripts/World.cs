using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField]
    private Material material;

    [SerializeField]
    private Block[] blocks;

    public Block[] Blocks { get { return blocks; } }
}

[Serializable]
public class Block
{
    public string Name;

    public bool IsSolid;

    [Header("Texture Values")]
    public int[] textures;

    public int GetTextureId(int faceIndex)
    {
        return textures[faceIndex];
    }
}
