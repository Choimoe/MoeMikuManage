using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMikuManage.Render
{
    public class RayTracing
    {
        // 场景数据
        private List<Vector3> vertices = new List<Vector3>();
        private List<Vector3> normals = new List<Vector3>();
        private List<int[]> faces = new List<int[]>();

        // 光源和相机参数
        private Vector3 lightPos;
        private Vector3 cameraPos;
        private Vector3 cameraDir;

        // 图像参数
        private const int Width = 800;
        private const int Height = 600;
        private const float AspectRatio = (float)Width / Height;

        public RayTracing(
            List<Vector3> vertices,
            List<Vector3> normals,
            List<int[]> faces,
            Vector3 lightPos,
            Vector3 cameraPos,
            Vector3 cameraDir)
        {
            this.vertices = vertices;
            this.normals = normals;
            this.faces = faces;

            this.lightPos = lightPos;
            this.cameraPos = cameraPos;
            this.cameraDir = Vector3.Normalize(cameraDir);
        }

        // 光线与三角形求交函数
        private bool RayTriangleIntersection(Vector3 rayOrigin, Vector3 rayDir,
            Vector3 v0, Vector3 v1, Vector3 v2, out float distance)
        {
            distance = float.MaxValue;
            Vector3 edge1 = v1 - v0;
            Vector3 edge2 = v2 - v0;
            Vector3 h = Vector3.Cross(rayDir, edge2);
            float a = Vector3.Dot(edge1, h);

            if (Math.Abs(a) < 1e-6)
                return false;

            float f = 1.0f / a;
            Vector3 s = rayOrigin - v0;
            float u = f * Vector3.Dot(s, h);

            if (u < 0.0f || u > 1.0f)
                return false;

            Vector3 q = Vector3.Cross(s, edge1);
            float v = f * Vector3.Dot(rayDir, q);

            if (v < 0.0f || u + v > 1.0f)
                return false;

            distance = f * Vector3.Dot(edge2, q);
            return distance > 0;
        }

        // 获取最近的相交三角形
        private bool GetNearestIntersection(Vector3 rayOrigin, Vector3 rayDir,
            out Vector3 intersectionPoint, out Vector3 intersectionNormal)
        {
            float minDistance = float.MaxValue;
            intersectionPoint = Vector3.Zero;
            intersectionNormal = Vector3.Zero;
            bool intersected = false;

            for (int i = 0; i < faces.Count; i++)
            {
                int[] face = faces[i];
                Vector3 v0 = vertices[face[0]];
                Vector3 v1 = vertices[face[3]];
                Vector3 v2 = vertices[face[6]];

                float distance;
                if (RayTriangleIntersection(rayOrigin, rayDir, v0, v1, v2, out distance))
                {
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        intersectionPoint = rayOrigin + rayDir * distance;
                        intersectionNormal = Vector3.Normalize(normals[face[0]] +
                            normals[face[3]] + normals[face[6]]) / 3f;
                        intersected = true;
                    }
                }
            }

            return intersected;
        }

        // 光线追踪着色函数
        private Vector3 TraceRay(Vector3 rayOrigin, Vector3 rayDir, int depth = 3)
        {
            if (depth <= 0) return Vector3.Zero;

            Vector3 intersectionPoint, intersectionNormal;
            if (GetNearestIntersection(rayOrigin, rayDir, out intersectionPoint, out intersectionNormal))
            {
                // 材质颜色
                Vector3 materialColor = getPosColor(intersectionPoint);

                // 漫反射光照计算
                Vector3 lightDir = Vector3.Normalize(lightPos - intersectionPoint);
                float diffuse = Math.Max(Vector3.Dot(intersectionNormal, lightDir), 0);

                // 阴影判断
                Vector3 shadowRayOrigin = intersectionPoint + intersectionNormal * 0.001f;
                Vector3 shadowRayDir = lightDir;
                Vector3 shadowIntersectionPoint, shadowIntersectionNormal;
                bool inShadow = GetNearestIntersection(shadowRayOrigin, shadowRayDir,
                    out shadowIntersectionPoint, out shadowIntersectionNormal) &&
                    Vector3.Distance(shadowRayOrigin, shadowIntersectionPoint) <
                    Vector3.Distance(shadowRayOrigin, lightPos);

                // 最终颜色计算
                Vector3 color = materialColor * (inShadow ? 0.3f : diffuse);

                // 反射
                Vector3 reflectionDir = MathExtensions.Reflect(rayDir, intersectionNormal);
                Vector3 reflectionColor = TraceRay(intersectionPoint + intersectionNormal * 0.001f,
                    reflectionDir, depth - 1);

                return color + reflectionColor * 0.5f;
            }

            // 背景色
            return new Vector3(0.1f, 0.1f, 0.2f);
        }

        // 材质颜色获取（由用户实现）
        private Vector3 getPosColor(Vector3 pos)
        {
            // 这里需要用户根据具体场景实现材质颜色逻辑
            return new Vector3(1, 0, 0); // 默认红色
        }

        // 渲染主函数
        public void RenderScene()
        {
            // 创建位图
            Bitmap bitmap = new Bitmap(Width, Height);

            // 计算相机的上向量和右向量
            Vector3 up = new Vector3(0, 1, 0);
            Vector3 right = Vector3.Normalize(Vector3.Cross(cameraDir, up));
            up = Vector3.Normalize(Vector3.Cross(right, cameraDir));

            // 视锥参数
            float aspectRatio = (float)Width / Height;
            float viewPlaneWidth = 2f;
            float viewPlaneHeight = viewPlaneWidth / aspectRatio;

            // 遍历每个像素
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    // 计算像素在视平面上的位置
                    float px = (x / (float)Width - 0.5f) * viewPlaneWidth;
                    float py = (0.5f - y / (float)Height) * viewPlaneHeight;

                    // 使用相机方向、右向量和上向量构建射线方向
                    Vector3 rayDir = Vector3.Normalize(
                        cameraDir +
                        right * px +
                        up * py
                    );

                    // 追踪光线
                    Vector3 color = TraceRay(cameraPos, rayDir);

                    // 颜色转换和写入
                    Color pixelColor = Color.FromArgb(
                        MathExtensions.Clamp((int)(color.X * 255), 0, 255),
                        MathExtensions.Clamp((int)(color.Y * 255), 0, 255),
                        MathExtensions.Clamp((int)(color.Z * 255), 0, 255)
                    );
                    bitmap.SetPixel(x, y, pixelColor);
                }
            }

            // 保存图片
            bitmap.Save("RayTracedImage.png");
            Console.WriteLine("渲染完成，图片已保存为 RayTracedImage.png");
        }
    }
}
