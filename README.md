# Jam Starter Kit
This package is meant to include an ever-growing library of scripts, tools, systems & basic textures that help to kick off
projects & Game jams.

### `v0.0.1` - Dec 12, 2024

## Included packages:
- [Unity Feature 2d](https://docs.unity3d.com/6000.0/Documentation/Manual/2DFeature.html)
- [Cinemachine](https://docs.unity3d.com/Packages/com.unity.cinemachine@2.3/manual/CinemachineOverview.html)
- [TextMeshPro](https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/TextMeshPro/index.html)
- [New Input System](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.11/manual/index.html)
- [Newtonsoft JSON](https://docs.unity3d.com/Packages/com.unity.nuget.newtonsoft-json@3.2/manual/index.html)
- [Naughty Attributes](https://github.com/dbrizov/NaughtyAttributes)
- [Unity Utils](https://github.com/ayellowpaper/SerializedDictionary)
---
 
## Features
### VFX Manager
> **_NOTE You will want to create a prefab variant of the VFX Manager prefab, to ensure that your changes are maintained!_**

The intention of the VFX Manager is to allow you to easily create library of effect prefabs, that can then be easily called
anywhere within your code, without needing to worry about managing the lifespan of that newly created GameObject. This
also avoids needing to find `VFXManager.cs` within the scene, so long as the prefab exists within the scene.

![VFX Manager](Documentation~/Images/vfx_manager.PNG)

You can add new enum values into `VFX.cs`, as this will operate in two locations:

1. The `VFX MANAGER` prefab, can then add a new entry
   - ```csharp
      public enum VFX
      {
         NONE = 0,
         MY_EFFECT = 1
      }      
2. You can then use that enum value in code to instantiate the prefab 
   - ```csharp
      VFX.MY_EFFECT.PlayAtLocation(transform.position, scale: 1f, keepAlive: false);

> `keepAlive`: This will ignore the specified lifetime set on the `VFX MANAGER` prefab