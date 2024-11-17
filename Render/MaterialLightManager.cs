using OpenTK;

namespace MoeMikuManage
{
    public partial class ModelViewer
    {
        private void SetDefaultMaterialAndLight()
        {
            modelMat.ambient = new Vector3(0.5f, 0.5f, 0.5f);
            modelMat.diffuse = new Vector3(0.7f, 0.7f, 0.7f);
            modelMat.specular = new Vector3(0.9f, 0.9f, 0.9f);
            modelMat.shininess = 10;

            light.ambient = new Vector3(0.5f, 0.5f, 0.5f);
            light.diffuse = new Vector3(0.7f, 0.7f, 0.7f);
            light.specular = new Vector3(0.9f, 0.9f, 0.9f);
            light.direction = new Vector3(0, -1, 0);
            light.intensity = 4;
        }
    }
}
