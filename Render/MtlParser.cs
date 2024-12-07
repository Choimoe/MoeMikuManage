using OpenTK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMikuManage.Render
{
    internal class MtlParser
    {
        public class Material
        {
            public string Name;
            public Vector3 AmbientColor;
            public Vector3 DiffuseColor;
            public Vector3 SpecularColor;
            public float Shininess;
            public float Transparency;
            public int IlluminationModel;
        }

        private Dictionary<string, Material> materials = new Dictionary<string, Material>();

        public void Parse(string filePath)
        {
            Material currentMaterial = null;

            foreach (var line in File.ReadLines(filePath))
            {
                var tokens = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 0) continue;

                switch (tokens[0])
                {
                    case "newmtl":
                        currentMaterial = new Material { Name = tokens[1] };
                        materials[currentMaterial.Name] = currentMaterial;
                        break;

                    case "Ka":
                        if (currentMaterial != null)
                            currentMaterial.AmbientColor = new Vector3(float.Parse(tokens[1]), float.Parse(tokens[2]), float.Parse(tokens[3]));
                        break;

                    case "Kd":
                        if (currentMaterial != null)
                            currentMaterial.DiffuseColor = new Vector3(float.Parse(tokens[1]), float.Parse(tokens[2]), float.Parse(tokens[3]));
                        break;

                    case "Ks":
                        if (currentMaterial != null)
                            currentMaterial.SpecularColor = new Vector3(float.Parse(tokens[1]), float.Parse(tokens[2]), float.Parse(tokens[3]));
                        break;

                    case "Ns":
                        if (currentMaterial != null)
                            currentMaterial.Shininess = float.Parse(tokens[1]);
                        break;

                    case "d":
                    case "Tr":
                        if (currentMaterial != null)
                            currentMaterial.Transparency = float.Parse(tokens[1]);
                        break;

                    case "illum":
                        if (currentMaterial != null)
                            currentMaterial.IlluminationModel = int.Parse(tokens[1]);
                        break;
                }
            }
        }
        public Material GetMaterial(string name)
        {
            return materials.ContainsKey(name) ? materials[name] : null;
        }

        public List<Material> GetAllMaterials()
        {
            return new List<Material>(materials.Values);
        }
    }
}
