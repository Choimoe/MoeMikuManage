using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMikuManage.RayTracing
{
    public enum MaterialType { DIFFUSE }

    public abstract class RayObject
    {
        public Vector3 Color { get; set; }
        public MaterialType MaterialType { get; set; }
        public float Shininess { get; set; }

        public abstract float Intersect(Ray ray);
        public abstract Vector3 GetNormal(Vector3 point);
    }

    public class SpherePrimitive : RayObject
    {
        public Vector3 Center { get; set; }
        public float Radius { get; set; }

        public SpherePrimitive(Vector3 center, float radius, Vector3 color, MaterialType materialType, float shininess)
        {
            Center = center;
            Radius = radius;
            Color = color;
            MaterialType = materialType;
            Shininess = shininess;
        }

        public override float Intersect(Ray ray)
        {
            Vector3 oc = ray.Origin - Center;
            float a = Vector3.Dot(ray.Direction, ray.Direction);
            float b = 2.0f * Vector3.Dot(oc, ray.Direction);
            float c = Vector3.Dot(oc, oc) - Radius * Radius;
            float discriminant = b * b - 4 * a * c;

            if (discriminant < 0) return float.PositiveInfinity;

            float t1 = (-b - (float)Math.Sqrt(discriminant)) / (2.0f * a);
            float t2 = (-b + (float)Math.Sqrt(discriminant)) / (2.0f * a);

            return t1 > 0 ? t1 : (t2 > 0 ? t2 : float.PositiveInfinity);
        }

        public override Vector3 GetNormal(Vector3 point)
        {
            return Vector3.Normalize(point - Center);
        }
    }

    public class PlanePrimitive : RayObject
    {
        public Vector3 Point { get; set; }
        public Vector3 Normal { get; set; }

        public PlanePrimitive(Vector3 point, Vector3 normal, Vector3 color, MaterialType materialType, float shininess)
        {
            Point = point;
            Normal = Vector3.Normalize(normal);
            Color = color;
            MaterialType = materialType;
            Shininess = shininess;
        }

        public override float Intersect(Ray ray)
        {
            float denom = Vector3.Dot(Normal, ray.Direction);
            if (Math.Abs(denom) < 1e-6) return float.PositiveInfinity;

            float t = Vector3.Dot(Normal, Point - ray.Origin) / denom;
            return t > 0 ? t : float.PositiveInfinity;
        }

        public override Vector3 GetNormal(Vector3 point)
        {
            return Normal;
        }
    }
    public class Light
    {
        public Vector3 Position { get; set; }
        public Vector3 Intensity { get; set; }

        public Light(Vector3 position, Vector3 intensity)
        {
            Position = position;
            Intensity = intensity;
        }
    }

    public class Ray
    {
        public Vector3 Origin { get; set; }
        public Vector3 Direction { get; set; }

        public Ray(Vector3 origin, Vector3 direction)
        {
            Origin = origin;
            Direction = Vector3.Normalize(direction);
        }
    }

}
