using UnityEngine;
using System.Collections;

[ExecuteInEditMode()]
public class DrawAabb : MonoBehaviour
{
    public Color color = Color.magenta;
    private Vector3[] vectors;
    //0: FrontTopLeft;
    //1: FrontTopRight;
    //2: FrontBottomLeft;
    //3: FrontBottomRight;
    //4: BackTopLeft;
    //5: BackTopRight;
    //6: BackBottomLeft;
    //7: BackBottomRight;

    void Update()
    {
        CalcPositons();
        DrawBox();
    }

    private void _AllocateVectors()
    {
        vectors = new Vector3[8];
    }

    private void _GetAabb(ref Vector3[] v_, Vector3 center, Vector3 extents)
    {
        v_[0] = new Vector3(center.x - extents.x, center.y + extents.y, center.z - extents.z);  // Front top left corner
        v_[1] = new Vector3(center.x + extents.x, center.y + extents.y, center.z - extents.z);  // Front top right corner
        v_[2] = new Vector3(center.x - extents.x, center.y - extents.y, center.z - extents.z);  // Front bottom left corner
        v_[3] = new Vector3(center.x + extents.x, center.y - extents.y, center.z - extents.z);  // Front bottom right corner
        v_[4] = new Vector3(center.x - extents.x, center.y + extents.y, center.z + extents.z);  // Back top left corner
        v_[5] = new Vector3(center.x + extents.x, center.y + extents.y, center.z + extents.z);  // Back top right corner
        v_[6] = new Vector3(center.x - extents.x, center.y - extents.y, center.z + extents.z);  // Back bottom left corner
        v_[7] = new Vector3(center.x + extents.x, center.y - extents.y, center.z + extents.z);  // Back bottom right corner
    }

    void CalcPositons()
    {
        // get untransformed AABB
        Bounds bounds = GetComponent<MeshFilter>().mesh.bounds;

        //Bounds bounds;
        //BoxCollider bc = GetComponent<BoxCollider>();
        //if (bc != null)
        //    bounds = bc.bounds;

        if (vectors == null)
            _AllocateVectors();

        Vector3 v3Center = bounds.center;
        Vector3 v3Extents = bounds.extents;

        // World transform AABB
        //
        _GetAabb(ref vectors, v3Center, v3Extents);
        for (int i = 0; i < 8; ++i)
        {
            vectors[i] = transform.TransformPoint(vectors[i]);
        }

        // get transformed AABB
        //
        Vector3 min = vectors[0];
        Vector3 max = vectors[0];
        for (int i = 1; i < 8; ++i)
        {
            min = Vector3.Min(min, vectors[i]);
            max = Vector3.Max(max, vectors[i]);
        }
        _GetAabb(ref vectors, transform.position, (max - min)/2 );
    }

    void DrawBox()
    {
        Debug.DrawLine(vectors[0], vectors[1], color);
        Debug.DrawLine(vectors[1], vectors[3], color);
        Debug.DrawLine(vectors[3], vectors[2], color);
        Debug.DrawLine(vectors[2], vectors[0], color);

        Debug.DrawLine(vectors[4], vectors[5], color);
        Debug.DrawLine(vectors[5], vectors[7], color);
        Debug.DrawLine(vectors[7], vectors[6], color);
        Debug.DrawLine(vectors[6], vectors[4], color);

        Debug.DrawLine(vectors[0], vectors[4], color);
        Debug.DrawLine(vectors[1], vectors[5], color);
        Debug.DrawLine(vectors[3], vectors[7], color);
        Debug.DrawLine(vectors[2], vectors[6], color);
    }
}