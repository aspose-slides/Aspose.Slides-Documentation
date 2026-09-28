---
title: Package multiplateforme pour .NET 6 et versions ultérieures
linktitle: Package multiplateforme
type: docs
weight: 235
url: /fr/net/net6/
keywords:
- Aspose.Slides.NET6.CrossPlatform
- multi-plateforme
- prise en charge .NET 6
- Linux
- macOS
- fontconfig
- libgdiplus
- System.Drawing.Common
- CS0433
- AWS Lambda
- .NET
- C#
- Aspose.Slides
description: "Découvrez quand utiliser le package Aspose.Slides.NET6.CrossPlatform : pourquoi il existe, sur quelles plateformes il fonctionne et ce qu’il nécessite sous Linux à la place de libgdiplus."
---
## **Introduction**

Aspose.Slides for .NET est publié sous forme de deux packages NuGet. [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) dessine les diapositives via la bibliothèque System.Drawing.Common de Microsoft. [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) les dessine avec son propre moteur graphique. Cet article explique pourquoi le second package existe, où il s’exécute, ce dont il a besoin sous Linux et comment il coexiste avec System.Drawing.Common dans un même projet.

## **Pourquoi un package distinct**

À partir de .NET 6, Microsoft ne prend en charge System.Drawing.Common [que sous Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). Par conséquent, sous Linux Aspose.Slides.NET a besoin du commutateur `System.Drawing.EnableUnixSupport` en plus de la bibliothèque `libgdiplus`, et il échoue si le projet référence System.Drawing.Common 7 ou une version ultérieure. [System Requirements](/slides/fr/net/system-requirements/) décrit ces conditions.

Aspose.Slides.NET6.CrossPlatform n’utilise pas System.Drawing.Common ni `libgdiplus`. Son moteur graphique est une bibliothèque native incluse dans le package pour chaque plateforme prise en charge. Les deux packages fournissent les mêmes espaces de noms et classes Aspose.Slides, de sorte que le passage de l’un à l’autre ne change que la référence du package, pas votre code.

|  | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| Graphiques | System.Drawing.Common | Moteur graphique natif inclus dans le package |
| Frameworks cibles | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| Exigences Linux | `libgdiplus` et le commutateur `System.Drawing.EnableUnixSupport` | `fontconfig` |
| Alpine Linux | Pris en charge | Non pris en charge |

## **Plateformes prises en charge**

Aspose.Slides.NET6.CrossPlatform fonctionne avec .NET 6 et les versions ultérieures sur les plateformes suivantes :

- **Windows** : x86 et x64. La bibliothèque native utilise le runtime Microsoft Visual C++; voir [System Requirements](/slides/fr/net/system-requirements/).
- **Linux** : x64 avec glibc 2.23 ou ultérieur, et ARM64 avec glibc 2.39 ou ultérieur.
- **macOS** : x64 (Intel) et ARM64 (Apple silicon).

Il ne fonctionne pas sous Windows sur ARM64, sous Alpine Linux ou d’autres distributions basées sur musl au lieu de glibc, ni sur des distributions avec une glibc plus ancienne, comme CentOS 7. Utilisez Aspose.Slides.NET sur ces systèmes.

## **Installation sous Linux**

Sous Linux, le package nécessite la bibliothèque `fontconfig`, mais pas `libgdiplus`. Sous Debian et Ubuntu, installez `fontconfig` puis ajoutez le package à votre projet :

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

Sous Debian et Ubuntu, `libfontconfig1` installe également les polices DejaVu, de sorte que le texte s’affiche sans packages de polices supplémentaires. Sans `fontconfig`, la création d’une [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) échoue avec une `TypeInitializationException` dont l’exception interne `DllNotFoundException` indique que `libfontconfig.so.1` ne peut pas être ouvert. [System Requirements](/slides/fr/net/system-requirements/) inclut un petit programme qui vérifie la configuration.

## **Hébergement cloud et conteneurs**

Comme il n’a pas besoin de `libgdiplus`, Aspose.Slides.NET6.CrossPlatform est le package à utiliser sur les hôtes Linux où l’installation de `libgdiplus` n’est pas possible. Il a toutefois besoin de `fontconfig` et de polices, que les images de base minimales peuvent ne pas contenir. L’image de base AWS Lambda pour .NET 8, par exemple, ne contient aucun des deux. Dans une image de conteneur construite à partir de celle‑ci, exécutez `dnf install -y fontconfig`, ce qui installe également les polices Noto Sans.

Pour des guides spécifiques aux plateformes cloud, consultez [Aspose.Slides on Cloud Platforms](/slides/fr/net/slides-on-cloud-platforms/).

## **Utilisation de System.Drawing.Common dans le même projet (CS0433)**

Un projet qui utilise Aspose.Slides.NET6.CrossPlatform peut également référencer System.Drawing.Common, directement ou via un autre package. La version actuelle d’Aspose.Slides n’expose aucun type public dans les espaces de noms `System`, de sorte que les deux bibliothèques ne sont pas en conflit, et vous pouvez importer les espaces de noms `Aspose.Slides` et `System.Drawing` dans le même fichier.

Si le compilateur signale l’erreur CS0433 parce qu’un type tel que `Image` ou `Graphics` existe à la fois dans Aspose.Slides et System.Drawing.Common, votre projet utilise une version plus ancienne d’Aspose.Slides. Mettez à jour le package vers la version la plus récente. Aspose.Slides renvoie les images rendues sous forme d’objets [IImage](https://reference.aspose.com/slides/fr/net/aspose.slides/iimage/), décrits dans [Modern API](/slides/fr/net/modern-api/).

## **FAQ**

**Dois‑je modifier mon code lorsque je passe de Aspose.Slides.NET à Aspose.Slides.NET6.CrossPlatform ?**

Non. Les deux packages fournissent les mêmes espaces de noms et classes Aspose.Slides, vous ne remplacez que la référence du package. Aspose.Slides.NET6.CrossPlatform n’a pas besoin du commutateur `System.Drawing.EnableUnixSupport`. Ajoutez uniquement l’un des deux packages à un projet.

**Puis‑je utiliser Aspose.Slides.NET6.CrossPlatform dans un projet .NET Framework ?**

Non. Le package cible uniquement .NET 6 et les versions ultérieures. Pour .NET Framework 4.6.2 et ultérieur, utilisez Aspose.Slides.NET.