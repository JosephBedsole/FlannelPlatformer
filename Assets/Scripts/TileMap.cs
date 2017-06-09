using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class TileMap : MonoBehaviour {

    public Texture2D texture;
    public int tileWidth;
    public int tileHeight;
    public int tileMargin;
    public int tileSpacing;

    public int height = 10;
    public int width = 10;

    [HideInInspector] public int[] tileArray;

    public void SetTile(int x, int y, int tile)
    {
        if (tileArray == null || tileArray.Length != (width * height))
        {
            tileArray = new int[width * height];
        }
        tileArray[x + y * width] = tile;
        SetupMesh();
    }
    
    Vector2[] LineUVs (int tile)
    { // index = 4;
        int columns = (texture.width / tileWidth);
        int rows = tile / columns;
        int cols = tile % columns;

        float uvX = (float)(tileMargin + cols * (tileWidth + tileSpacing)) / (float)texture.width;
        float uvY = (float)(tileMargin + rows * (tileHeight + tileSpacing)) / (float)texture.height;
        float w = ((float)tileWidth / (float)texture.width);
        float h = ((float)tileHeight / (float)texture.height);

        return new Vector2[]
        {
            new Vector2(uvX, uvY),
            new Vector2(uvX, uvY + h),
            new Vector2(uvX + w, uvY + h),
            new Vector2(uvX + h, uvY)
        };
    }

    void SetupMesh()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        List<Vector3> verts = new List<Vector3>();
        List<Vector2> uvs = new List<Vector2>();
        List<Color> colors = new List<Color>();
        List<int> tris = new List<int>();
        int index = 0;

        for (int x = 0; x < width; ++x)
        {
            for (int y = 0; y < height; ++y)
            {
                int tile = tileArray[x + y * width];
                if (tile < 0) continue;

                Vector3 pos = new Vector3(x, y, 0);
                verts.AddRange(new Vector3[]
                {
                pos,
                pos + Vector3.up,
                pos + new Vector3(1, 1, 0),
                pos + new Vector3(1, 0, 0)
                });

                uvs.AddRange(LineUVs(tile));

                colors.AddRange(new Color[]
                {
                Color.white,
                Color.white,
                Color.white,
                Color.white,
                });

                // Assign tris last or you will break things!
                
                tris.AddRange(new int[]
                {
                index, index + 1, index + 2,
                index, index + 2, index + 3
                });
                index += 4;
            }
        }

        Mesh mesh = new Mesh();
        mesh.name = "ProcMesh";
        mesh.vertices = verts.ToArray();
        mesh.uv = uvs.ToArray();
        mesh.colors = colors.ToArray();
        mesh.triangles = tris.ToArray();


        meshFilter.sharedMesh = mesh;

    }
}
