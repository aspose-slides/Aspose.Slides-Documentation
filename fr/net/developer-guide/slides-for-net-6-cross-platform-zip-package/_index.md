---
title: Aspose.Slides pour .NET 6 Cross-Platform (Package ZIP)
type: docs
weight: 237
url: /fr/net/slides-for-net-6-cross-platform-zip-package/
aliases:
  - /net/slides-for-net-6-cross-platform/
keywords:
- multi-plateforme
- .NET 6
- GLIBC
- csproj
- chemin cible
- bibliothèque dépendante
- Aspose.Slides.dll
- System.Drawing.Common
- conflit de noms
- alias externe
- CS0433
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Utilisez Aspose.Slides pour .NET 6 afin de créer des applications C# multiplateformes sous Windows, Linux et macOS qui créent, modifient et convertissent des fichiers PowerPoint PPT, PPTX et ODP."
---
## **Vue d'ensemble**

Cet article explique comment utiliser Aspose.Slides pour .NET 6 Cross-Platform à partir d’un package ZIP. Il décrit comment télécharger le package, extraire les fichiers du dossier `net6.0/crossplatform`, ajouter une référence à `Aspose.Slides.dll` et configurer le fichier projet afin que les bibliothèques dépendantes requises soient copiées dans le répertoire de sortie de l’application.

L’article décrit également le contenu du package cross‑platform, notamment l’assembly principal Aspose.Slides .NET et les bibliothèques du sous‑système graphique spécifiques à chaque plateforme pour Windows, Linux et macOS.

{{% alert title="Remarque" color="primary" %}}

Aspose.Slides pour .NET 6 Cross-Platform est également disponible sur [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform).

{{% /alert %}}

## **Utilisation de Aspose.Slides Cross‑Platform à partir d’un package ZIP**

1. Téléchargez le package ZIP de la dernière version d’Aspose.Slides depuis la [Page de versions](https://releases.aspose.com/slides/fr/net/).

2. Extrayez les fichiers de *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* et placez‑les dans le dossier qui servira aux dépendances de votre projet.

3. Ajoutez une référence à Aspose.Slides.dll.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   Dans notre exemple (ci‑dessous), les bibliothèques se trouvent dans le dossier du projet suivant : *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. Placez les fichiers restants (dont Aspose.Slides dépend) dans le répertoire de sortie en ajoutant les instructions au fichier csproj du projet de cette manière :

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

   Par défaut, `<CopyToOutputDirectory>` copie les fichiers en conservant leur chemin relatif, mais nous devons que les bibliothèques dépendantes se retrouvent dans le même dossier que le fichier de sortie (emplacement d’Aspose.Slides.dll).

## **Notes**

### **Sous‑système graphique propriétaire**

Aspose.Slides cross‑platform est un ensemble de bibliothèques :

| Aspose.Slides.dll                                          | Assembly .NET principal responsable de toute la logique Aspose.Slides |
| ---------------------------------------------------------- | ---------------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | Dépendance : implémentation du sous‑système graphique pour Win x64     |
| aspose.slides.drawing.capi_vc14x86.dll                     | Dépendance : implémentation du sous‑système graphique pour Win x86     |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Dépendance : implémentation du sous‑système graphique pour Linux (x86/x64) |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Dépendance : implémentation du sous‑système graphique pour macOS AMD64 (x86-64/x64) |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Dépendance : implémentation du sous‑système graphique pour macOS ARM64 (AArch64) |

Aspose.Slides.dll utilise la bibliothèque requise par le système sur lequel il s’exécute. Les bibliothèques sont généralement situées au même emplacement que Aspose.Slides.dll dans n’importe quel système de fichiers.

### **Structure du package ZIP**

Le package ZIP contient la structure de dossiers suivante :

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* Chaque dossier contient les assemblies correspondant à la version .NET concernée. Il existe deux versions pour net6.0 : default et crossplatform. Cette dernière contient Aspose.Slides.dll cross‑platform et toutes ses dépendances. Le contenu décompressé de ce dossier peut être utilisé comme ajout de dépendance dans un projet pour le développement cross‑platform et d’autres cas d’utilisation d’Aspose.Slides.

## **Voir aussi**

- [Exigences système](/slides/fr/net/system-requirements/)