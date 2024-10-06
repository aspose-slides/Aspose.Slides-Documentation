---
title: Aspose.Slides pour .NET 6 Multiplateforme
type: docs
weight: 237
url: /net/slides-for-net-6-cross-platform
keywords: Aspose.Slides, .NET, Multiplateforme
description: Aspose.Slides pour .NET 6 Multiplateforme
---

1. Aspose.Slides pour .NET6 multiplateforme peut être utilisé pour .NET 7 et les futures versions de .NET.

2. **Prérequis** : Pour utiliser la version multiplateforme d'Aspose.Slides pour .NET 6, vous devez télécharger le package Aspose.Slides à partir de la [Page de version](https://releases.aspose.com/slides/net/). Le package NuGet d'Aspose.Slides n'est pas adapté car il ne propose un support multiplateforme que pour le .NET Standard.

3. **Exigences** : [Exigences système](https://docs.aspose.com/slides/net/system-requirements/). Veuillez noter qu'Aspose.Slides pour .NET 6 et .NET 7 nécessite Linux x86_x64 avec GLIBC 2.23 ou supérieur. **CentOS** 7 (dont la version GLIBC est 2.14) n'est pas pris en charge. Pour utiliser Slides sous CentOS 7 ou d'autres systèmes (comme Alpine) qui ne remplissent pas les critères, veuillez obtenir Aspose.Slides pour .NETStandard.

## **Obtenir et utiliser Aspose.Slides multiplateforme**

1. Téléchargez le package ZIP des dernières versions d'Aspose.Slides à partir de la [Page de version](https://releases.aspose.com/slides/net/). 

2. Décompressez les fichiers de *\Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* et placez-les dans le dossier qui sera utilisé pour les dépendances dans votre projet.

3. Ajoutez une référence à Aspose.Slides.dll

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   Dans notre exemple (ci-dessous), les bibliothèques se trouvent dans le dossier du projet le long de ce chemin : *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. Placez les fichiers restants (dont Aspose.Slides dépend) dans le répertoire de sortie en ajoutant des instructions au fichier de projet csproj de cette manière :
```
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

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
                  <TargetPath>libaspose.slides.drawing.capi_appleclang.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
                  <TargetPath>libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so</TargetPath>
   </None>

</ItemGroup>
```

5. Faites attention à TargetPath. 

   Par défaut, `<CopyToOutputDirectory>` copie des fichiers tout en préservant leur chemin relatif, mais nous avons besoin que les bibliothèques dépendantes aillent dans le même dossier où la sortie est générée (emplacement de Aspose.Slides.dll).

## Notes

### **Support de System.Drawing.Common uniquement pour Windows**

À partir de .NET 6, le support de System.Drawing.Common (qui fournissait un support GDI+) est disponible [uniquement sous Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). Aspose.Slides pour .NET dépend de GDI+. De plus, l'API publique d'Aspose.Slides contient des types (Bitmap, Metafile, Graphics, etc.) du package System.Drawing.Common.

### **Sous-système graphique propriétaire**

Pour résoudre le problème de changement majeur (qui annule le support multiplateforme pour System.Drawing.Common), Aspose.Slides— à partir de la version 23.6—utilise sa propre implémentation de sous-système graphique.

Voici les systèmes pris en charge : **Windows**, **Linux**, et **macOS**.

Aspose.Slides multiplateforme est une collection de bibliothèques :

| Aspose.Slides.dll                                          | Assemblage principal .NET responsable de toute la logique d'Aspose.Slides    |
| ---------------------------------------------------------- | ------------------------------------------------------------ |
| aspose.slides.drawing.capi_vc14x64.dll                     | Dépendance : implémentation du sous-système graphique pour Win x64    |
| aspose.slides.drawing.capi_vc14x86.dll                     | Dépendance : implémentation du sous-système graphique pour Win x64    |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Dépendance : implémentation du sous-système graphique pour Linux (x86/x64) |
| libaspose.slides.drawing.capi_appleclang.dylib             | Dépendance : implémentation du sous-système graphique pour macOS      |

Aspose.Slides.dll utilise la bibliothèque que le système sur lequel il tourne nécessite. Les bibliothèques se trouvent généralement au même emplacement qu'Aspose.Slides.dll dans n'importe quel système de fichiers.

### **API publique d'Aspose.Slides et types de System.Drawing.Common. Solution au problème de conflits de noms**

L'API publique d'Aspose.Slides utilise des types de System.Drawing.Common (Bitmap, Metafile, Graphics, et bien d'autres). Pour faciliter la transition fluide vers le nouveau produit Aspose.Slides multiplateforme et éviter l'introduction de nombreux changements majeurs dans l'API publique de Slides, l'implémentation propriétaire du sous-système graphique **duplique** les types et les espaces de noms de System.Drawing.Common.

Par conséquent, si vous développez ou travaillez dans un environnement Linux, vous n'avez qu'à utiliser Aspose.Slides comme dépendance—et l'ensemble de l'API reste le même.

**Problème potentiel** : La configuration décrite a ses inconvénients. Par exemple, si vous développez sur Windows et que vous avez des projets utilisant l'original System.Drawing.Common, vous pourriez rencontrer des conflits avec les types d'Aspose.Slides.

**Solution** : Vous pouvez utiliser un alias extern pour résoudre le problème. Voir [**Utilisation du package System.Drawing.Common et des classes Slides pour .NET6 (CS0433 : Le type existe à la fois dans Slides et System.Drawing.Common erreur)**](https://docs.aspose.com/slides/net/net6/#using-the-systemdrawingcommon-package-and-slides-for-net6-classes-cs0433-the-type-exists-in-both-slides-and-systemdrawingcommon-error).

L'équipe Slides travaille sur des tâches qui aboutiront à une API publique simplifiée et unifiée.

### **Packages NuGet et ZIP**

* Le package NuGet Aspose.Slides pour .NET manque actuellement de support pour Aspose.Slides multiplateforme pour .NET 6.

* Le package NuGet Aspose.Slides pour .NET prend en charge le multiplateforme pour le .NET Standard mais pas pour le .NET 6.

* La version multiplateforme d'Aspose.Slides est disponible sous forme de packages zip fournis sur la [page des versions](https://releases.aspose.com/slides/net/).

* Le package ZIP contient cette structure de dossier :

  ├───net2.0

  ├───net3.5

  ├───net3.5_ClientProfile

  ├───net4.0

  ├───net4.0_ClientProfile

  ├───net6.0

  │  ├───crossplatform

  │  └───win

  ├───netstandard2.0

  └───netstandard2.1

* Chaque dossier contient des assemblies pour leur version .NET correspondante. Il y a deux versions pour net6.0 : win et crossplatform. La dernière contient le fichier Aspose.Slides.dll multiplateforme et toutes ses dépendances. Le contenu décompressé de ce dossier peut être utilisé comme ajout de dépendance dans un projet pour le développement multiplateforme et autres instances d'utilisation d'Aspose.Slides.