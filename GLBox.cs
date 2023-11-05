using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class GLBox : MonoBehaviour
{
    public bool IsShow;

    private Collider col;
    [Header("线段长度")]
    public float offset = 0.2f;
    [Header("线段宽度")]
    [Range(0, 50)]
    public int thick;
    [Header("线的颜色")]
    public Color lineColor = new Color(1, 237 / 255f, 1, 1);
    public float sizeX = 0;
    public float sizeY = 0;
    public float sizeZ = 0;

    private void Start()
    {
        col = GetComponent<Collider>();
    }

    void OnRenderObject()
    {
        if (!IsShow || col == null) return;

        //创建并设置线条材质
        CreateLineMaterial();
        lineMaterial.SetPass(0);

        //获取本物体对象在世界范围内的中心点位置 col.center是本地坐标位置
        var c = col.bounds.center;
        //collider大小
        var size = col.bounds.size;
        float rx = size.x / 2f + sizeX;
        float ry = size.y / 2f + sizeY;
        float rz = size.z / 2f + sizeZ;

        GL.PushMatrix();

        //获取collider边界的8个顶点位置
        Vector3 pa, pa1, pa2, pa3, pb, pb1, pb2, pb3, pc, pc1, pc2, pc3, pd, pd1, pd2, pd3, pe, pe1, pe2, pe3, pf, pf1, pf2, pf3, pg, pg1, pg2, pg3, ph, ph1, ph2, ph3;

        for (int i = -thick / 2; i < thick / 2; i++)
        {
            pa = (c + new Vector3(-rx, -ry, rz)) * (1 + 0.0001f * i);
            pa1 = (c + new Vector3(-rx + offset, -ry, rz)) * (1 + 0.0001f * i);
            pa2 = (c + new Vector3(-rx, -ry, rz - offset)) * (1 + 0.0001f * i);
            pa3 = (c + new Vector3(-rx, -ry + offset, rz)) * (1 + 0.0001f * i);

            pb = (c + new Vector3(rx, -ry, rz)) * (1 + 0.0001f * i);
            pb1 = (c + new Vector3(rx, -ry, rz - offset)) * (1 + 0.0001f * i);
            pb2 = (c + new Vector3(rx, -ry + offset, rz)) * (1 + 0.0001f * i);
            pb3 = (c + new Vector3(rx - offset, -ry, rz)) * (1 + 0.0001f * i);

            pc = (c + new Vector3(rx, -ry, -rz)) * (1 + 0.0001f * i);
            pc1 = (c + new Vector3(rx, -ry, -rz + offset)) * (1 + 0.0001f * i);
            pc2 = (c + new Vector3(rx - offset, -ry, -rz)) * (1 + 0.0001f * i);
            pc3 = (c + new Vector3(rx, -ry + offset, -rz)) * (1 + 0.0001f * i);

            pd = (c + new Vector3(-rx, -ry, -rz)) * (1 + 0.0001f * i);
            pd1 = (c + new Vector3(-rx, -ry, -rz + offset)) * (1 + 0.0001f * i);
            pd2 = (c + new Vector3(-rx, -ry + offset, -rz)) * (1 + 0.0001f * i);
            pd3 = (c + new Vector3(-rx + offset, -ry, -rz)) * (1 + 0.0001f * i);

            pe = (c + new Vector3(-rx, ry, rz)) * (1 + 0.0001f * i);
            pe1 = (c + new Vector3(-rx, ry, rz - offset)) * (1 + 0.0001f * i);
            pe2 = (c + new Vector3(-rx + offset, ry, rz)) * (1 + 0.0001f * i);
            pe3 = (c + new Vector3(-rx, ry - offset, rz)) * (1 + 0.0001f * i);

            pf = (c + new Vector3(rx, ry, rz)) * (1 + 0.0001f * i);
            pf1 = (c + new Vector3(rx, ry, rz - offset)) * (1 + 0.0001f * i);
            pf2 = (c + new Vector3(rx - offset, ry, rz)) * (1 + 0.0001f * i);
            pf3 = (c + new Vector3(rx, ry - offset, rz)) * (1 + 0.0001f * i);

            pg = (c + new Vector3(rx, ry, -rz)) * (1 + 0.0001f * i);
            pg1 = (c + new Vector3(rx, ry, -rz + offset)) * (1 + 0.0001f * i);
            pg2 = (c + new Vector3(rx - offset, ry, -rz)) * (1 + 0.0001f * i);
            pg3 = (c + new Vector3(rx, ry - offset, -rz)) * (1 + 0.0001f * i);

            ph = (c + new Vector3(-rx, ry, -rz)) * (1 + 0.0001f * i);
            ph1 = (c + new Vector3(-rx, ry, -rz + offset)) * (1 + 0.0001f * i);
            ph2 = (c + new Vector3(-rx + offset, ry, -rz)) * (1 + 0.0001f * i);
            ph3 = (c + new Vector3(-rx, ry - offset, -rz)) * (1 + 0.0001f * i);

            //画线

            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(pa);
            GL.Vertex(pa1);
            GL.End();

            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(pa);
            GL.Vertex(pa2);
            GL.End();

            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(pa);
            GL.Vertex(pa3);
            GL.End();

            //pb
            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(pb);
            GL.Vertex(pb1);
            GL.End();

            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(pb);
            GL.Vertex(pb2);
            GL.End();

            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(pb);
            GL.Vertex(pb3);
            GL.End();

            //pc
            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(pc);
            GL.Vertex(pc1);
            GL.End();

            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(pc);
            GL.Vertex(pc2);
            GL.End();

            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(pc);
            GL.Vertex(pc3);
            GL.End();
            //pd
            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(pd);
            GL.Vertex(pd1);
            GL.End();

            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(pd);
            GL.Vertex(pd2);
            GL.End();

            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(pd);
            GL.Vertex(pd3);
            GL.End();
            //pe
            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(pe);
            GL.Vertex(pe1);
            GL.End();

            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(pe);
            GL.Vertex(pe2);
            GL.End();

            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(pe);
            GL.Vertex(pe3);
            GL.End();
            //pf
            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(pf);
            GL.Vertex(pf1);
            GL.End();

            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(pf);
            GL.Vertex(pf2);
            GL.End();

            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(pf);
            GL.Vertex(pf3);
            GL.End();
            //pg
            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(pg);
            GL.Vertex(pg1);
            GL.End();

            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(pg);
            GL.Vertex(pg2);
            GL.End();

            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(pg);
            GL.Vertex(pg3);
            GL.End();
            //ph
            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(ph);
            GL.Vertex(ph1);
            GL.End();

            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(ph);
            GL.Vertex(ph2);
            GL.End();

            GL.Begin(GL.LINES);
            GL.Color(lineColor);
            GL.Vertex(ph);
            GL.Vertex(ph3);
            GL.End();
        }


        GL.PopMatrix();
    }

    static Material lineMaterial;
    static void CreateLineMaterial()
    {
        if (!lineMaterial)
        {
            // Unity3d使用该默认的Shader作为线条材质 
            Shader shader = Shader.Find("Hidden/Internal-Colored");
            lineMaterial = new Material(shader);
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            // 开启 alpha blending 
            lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            // 开启背面遮挡 
            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
            // Turn off depth writes 
            lineMaterial.SetInt("_ZWrite", 0);
        }
    }
}

