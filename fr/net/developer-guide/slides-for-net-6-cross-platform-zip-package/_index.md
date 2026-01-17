---
title: Aspose.Slides pour .NET 6 Cross-Platform (Package ZIP)
type: docs
weight: 237
url: /fr/net/slides-for-net-6-cross-platform-zip-package/
keywords:
- multiplateforme
- .NET 6
- GLIBC
- csproj
- chemin cible
- bibliothèque dépendante
- Aspose.Slides.dll
- System.Drawing.Common
- conflit de nom
- alias externe
- CS0433
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Utilisez Aspose.Slides pour .NET 6 pour créer des applications C# multiplateformes sous Windows, Linux et macOS qui créent, modifient et convertissent des fichiers PowerPoint PPT, PPTX et ODP."
---

{{% alert title="Remarque" color="primary" %}}

Aspose.Slides for .NET 6 Cross-Platform est également disponible sur [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform).

{{% /alert %}}

## **Utilisation d'Aspose.Slides multiplateforme à partir d'un package ZIP**

1. Téléchargez le package ZIP de la dernière version d'Aspose.Slides depuis la [Page de publication](https://releases.aspose.com/slides/net/). 

2. Décompressez les fichiers de *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* et placez‑les dans le dossier qui servira aux dépendances de votre projet.

3. Ajoutez une référence à Aspose.Slides.dll.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   Dans notre exemple (ci‑dessous), les bibliothèques se trouvent dans le dossier du projet à ce chemin : *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. Placez les fichiers restants (dont Aspose.Slides dépend) dans le répertoire de sortie en ajoutant les instructions suivantes au fichier de projet csproj :
```xml
<ItemGroup>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x64.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x64.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x86.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x86.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\Aspose.Slides.xml">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>Aspose.Slides.xml</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_x86_64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_x86_64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_arm64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_arm64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so</TargetPath>
   </None>

</ItemGroup>
```


5. Faites attention à `TargetPath`. 

   Par défaut, `<CopyToOutputDirectory>` copie les fichiers en conservant leur chemin relatif, mais nous avons besoin que les bibliothèques dépendantes aillent dans le même dossier où la sortie est générée (emplacement d'Aspose.Slides.dll).

## **Notes**

### **Sous‑système graphique propriétaire**

Aspose.Slides multiplateforme est un ensemble de bibliothèques :

| Aspose.Slides.dll                                          | Assembly .NET principal responsable de toute la logique d'Aspose.Slides                 |
| ---------------------------------------------------------- | ---------------------------------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | Dépendance : implémentation du sous‑système graphique pour Windows x64                  |
| aspose.slides.drawing.capi_vc14x86.dll                     | Dépendance : implémentation du sous‑système graphique pour Windows x64                  |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Dépendance : implémentation du sous‑système graphique pour Linux (x86/x64)              |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Dépendance : implémentation du sous‑système graphique pour macOS AMD64 (x86‑64/x64)    |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Dépendance : implémentation du sous‑système graphique pour macOS ARM64 (AArch64)       |

Aspose.Slides.dll utilise la bibliothèque requise par le système sur lequel il s'exécute. Les bibliothèques se trouvent généralement au même emplacement que Aspose.Slides.dll dans tout système de fichiers.

### **Structure du package ZIP**

Le package ZIP contient la structure de dossiers suivante :

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* Chaque dossier contient les assemblées pour la version .NET correspondante. Il existe deux versions pour net6.0 : default et crossplatform. Cette dernière contient Aspose.Slides.dll multiplateforme et toutes ses dépendances. Le contenu décompressé de ce dossier peut être utilisé comme addition de dépendance dans un projet pour le développement multiplateforme et d'autres cas d'utilisation d'Aspose.Slides.

## **Voir aussi**

- [Exigences système](/slides/fr/net/system-requirements/)