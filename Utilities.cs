using OpenTK;

namespace MoeMikuManage
{
    public partial class ModelViewer
    {
        private struct Material
        {
            public Vector3 ambient;
            public Vector3 diffuse;
            public Vector3 specular;
            public float shininess;
        }

        private struct DirectionalLight
        {
            public Vector3 direction;
            public Vector3 ambient;
            public Vector3 diffuse;
            public Vector3 specular;
            public float intensity;
        }
    }
}
