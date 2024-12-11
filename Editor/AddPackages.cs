using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;

namespace JamStarter.Editor
{
    public static class AddPackages
    {
        private static readonly string PackagesDirectoryPath = Path.Join(Application.dataPath, "..","Packages");
        private static readonly string PackagesManifestPath = Path.Join(PackagesDirectoryPath, "manifest.json");
    
        private static readonly string[] Packages = {
            "com.dbrizov.naughtyattributes",
            "com.gitamend.unityutils",
        };
    
        private static readonly string[] PackageUrLs = {
            "https://github.com/dbrizov/NaughtyAttributes.git#upm",
            "https://github.com/adammyhre/Unity-Utils.git",
        };
    
        [InitializeOnLoadMethod]
        private static void TryAddPackages()
        {
            //Debug.Log("Checking Packages...");

            CheckHasPackages();

            var dependencies = GetPackageDependencies();

            var didChangeDependencies = false;
            for (var i = 0; i < Packages.Length; i++)
            {
                var packageId = Packages[i];
                if (dependencies.ContainsKey(packageId))
                {
                    //Debug.Log($"Contains {packageId}");
                    continue;
                }

                didChangeDependencies = true;
                dependencies.Add(packageId, PackageUrLs[i]);
                //Debug.Log($"Added {packageId}");
            }

            if (didChangeDependencies == false)
                return;

            UpdatePackageDependencies(dependencies);
        }

        private static void CheckHasPackages()
        {
            if (Directory.Exists(PackagesDirectoryPath) == false)
                throw new DirectoryNotFoundException(PackagesDirectoryPath + " does not exist!");

            if (File.Exists(PackagesManifestPath) == false)
                throw new FileNotFoundException(PackagesManifestPath + " does not exist!");
        }

        private static Dictionary<string, string> GetPackageDependencies()
        {
            var jsonFileContents = File.ReadAllText(PackagesManifestPath);

            var manifestContents = JObject.Parse(jsonFileContents);

            if (manifestContents.HasValues == false)
                throw new Exception();
        
            return manifestContents["dependencies"].ToObject<Dictionary<string, string>>();
        }

        private static void UpdatePackageDependencies(Dictionary<string, string> newDependencies)
        {
            var updatedDependencies = JsonConvert.SerializeObject(
                new
                {
                    dependencies = newDependencies
                }, Formatting.Indented);
        
            File.WriteAllText(PackagesManifestPath, updatedDependencies);
        }
    }
}
