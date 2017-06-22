using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class AnimatedQuad : MonoBehaviour {
    public int frames = 7;

    public Texture2D texture;

    void SetupMesh(int count)
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        Mesh mesh = new Mesh();

        mesh.vertices = new Vector3[]
        {
            new Vector3(-0.5f, -0.5f, 0),
                new Vector3(-0.5f, 0.5f, 0),
                new Vector3(0.5f, 0.5f, 0),
                new Vector3(0.5f, -0.5f, 0)
        };

        float w = 1 / (float)frames;
        float x = count / (float)frames;

        mesh.uv = new Vector2[]
        {
            new Vector2(x, 0),
            new Vector2(x, 1),
            new Vector2(x + w, 1),
            new Vector2(x + w, 0)
        };

        mesh.triangles = new int[]
        {
            0, 1, 2,
            0, 2, 3
        };

        meshFilter.sharedMesh = mesh;

    }

    private void Start()
    {
        StartCoroutine("ChangeFrame");
    }

    IEnumerator ChangeFrame ()
    {
        while (enabled)
        {
            for (int i = 0; i < frames; ++i)
            {
                SetupMesh(i);
                yield return new WaitForSeconds(.1f);
            }
        }
    }
}
