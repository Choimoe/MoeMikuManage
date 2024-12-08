using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMikuManage.RayTracing
{
    public class RayTracingScene
    {
        private const float EPS = 1e-4f;
        private const float INF = float.PositiveInfinity;
        private Vector3 _cameraOrigin;

        public List<RayObject> Objects { get; } = new List<RayObject>();
        public List<Light> Lights { get; } = new List<Light>();

        public void setCamera(Vector3 cameraPos)
        {
            _cameraOrigin = cameraPos;
        }

        public Vector3 Trace(Ray ray, int depth = 0)
        {
            if (depth > 5) return Vector3.Zero;

            float tMin = INF;
            RayObject hitObject = null;

            foreach (var obj in Objects)
            {
                float t = obj.Intersect(ray);
                if (t < tMin)
                {
                    tMin = t;
                    hitObject = obj;
                }
            }

            if (hitObject == null) return new Vector3(0.5f, 0.5f, 0.5f);

            Vector3 hitPoint = ray.Origin + ray.Direction * tMin;
            Vector3 normal = hitObject.GetNormal(hitPoint);

            Vector3 color = Vector3.Zero;

            Vector3 ambient = new Vector3(0.1f, 0.1f, 0.1f);
            color += hitObject.Color * ambient;

            foreach (var light in Lights)
            {
                Vector3 lightDir = Vector3.Normalize(light.Position - hitPoint);
                Ray shadowRay = new Ray(hitPoint + normal * EPS, lightDir);

                bool inShadow = false;
                foreach (var obj in Objects)
                {
                    if (obj == hitObject) continue;
                    if (obj.Intersect(shadowRay) < INF)
                    {
                        inShadow = true;
                        break;
                    }
                }

                if (!inShadow)
                {
                    float diff = Math.Max(0.0f, Vector3.Dot(normal, lightDir));
                    Vector3 diffuse = hitObject.Color * light.Intensity * diff;

                    Vector3 viewDir = Vector3.Normalize(_cameraOrigin - hitPoint);
                    Vector3 halfDir = Vector3.Normalize(lightDir + viewDir);
                    float specAngle = Math.Max(0.0f, Vector3.Dot(normal, halfDir));
                    float spec = (float)Math.Pow(specAngle, hitObject.Shininess);
                    Vector3 specular = light.Intensity * spec;

                    color += diffuse + specular;
                }
            }

            color.X = Math.Min(1.0f, Math.Max(0.0f, color.X));
            color.Y = Math.Min(1.0f, Math.Max(0.0f, color.Y));
            color.Z = Math.Min(1.0f, Math.Max(0.0f, color.Z));

            return color;
        }
    }
}
