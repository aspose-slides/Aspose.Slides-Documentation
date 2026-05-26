---
title: Exigences du système
type: docs
weight: 60
url: /fr/net/system-requirements/
keywords:
- exigences système
- système d'exploitation
- installation
- dépendances
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez les exigences système d'Aspose.Slides pour .NET. Assurez une prise en charge fluide de PowerPoint et OpenDocument sur Windows, Linux et macOS."
---
## **Introduction**

Aspose.Slides for .NET ne nécessite pas l'installation de Microsoft PowerPoint car Aspose.Slides est un moteur indépendant de création, de conversion, de mise en page et de rendu de documents Microsoft PowerPoint.

## **Systèmes d'exploitation pris en charge**

Aspose.Slides for .NET prend en charge tout système d'exploitation 32 bits ou 64 bits où le framework .NET ou Mono est installé, y compris (mais sans s’y limiter) :

### **Windows**

- Microsoft Windows 2000 Server (x64, x86)
- Microsoft Windows 2003 Server (x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)
- Microsoft Windows 11 (x64, x86)
- Microsoft Azure

### **Linux**

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine et autres)

### **Mac**

- Mac OS X

## **Frameworks pris en charge**

Aspose.Slides for .NET prend en charge les frameworks .NET et Mono :

### **.NET Frameworks**

- .NET Framework 2.0
- .NET Framework 3.5
- .NET Framework 4.0
- .NET Framework 4.0_ClientProfile
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.5.2
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.7
- .NET Framework 4.7.2
- .NET 5
- .NET 6
- .NET 7
- .NET 8
- .NET 9
- .NET Core
- Prise en charge de COM Interop (COM, C++, VBScript)

### **Framework Mono**

- Prise en charge de MONO sur les plateformes MAC et Linux

## **Environnements de développement**

Aspose.Slides for .NET peut être utilisé pour développer des applications dans n’importe quel environnement de développement ciblant la plateforme .NET, mais les environnements suivants sont explicitement pris en charge :

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Principales versions d'Aspose.Slides**

Actuellement, il existe deux principales versions d'Aspose.Slides — Aspose.Slides.NET et Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Ceci est la version principale du produit. Elle utilise le moteur graphique standard de .NET.
- Sur les plateformes non Windows, il peut être nécessaire d'installer la bibliothèque `libgdiplus` et ses dépendances.
- Avant la version Aspose.Slides 25.3, sur les plateformes non Windows, il était nécessaire d'utiliser le DLL .NET Standard 2.0 du paquet ZIP Aspose.Slides.
- À partir de la version Aspose.Slides 25.3, le package NuGet peut être utilisé directement même sur des systèmes non Windows.
- Lors de l'exécution sur des systèmes non Windows, votre application doit inclure la ligne suivante au démarrage :
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **À partir de la version 25.3, vous pouvez utiliser ce package sur les plateformes qui prennent en charge .NET, comme Linux aarch64 (ARM64).**

#### **Packages supplémentaires pour Linux Alpine**

Lors de l'exécution d'Aspose.Slides for .NET dans un conteneur Alpine Linux, l'installation seule de `libgdiplus` peut ne pas être suffisante. Les conteneurs Alpine n'incluent généralement pas de polices par défaut. Si aucune police n'est disponible, les opérations de rendu ou de conversion peuvent échouer avec une erreur similaire à :

```text
System.ArgumentException: Font '?' cannot be found
```
Pour utiliser Aspose.Slides sur Alpine, installez `libgdiplus` avec au moins un paquet de polices.

**Option 1 : Polices DejaVu**

L'option recommandée consiste à installer le paquet ttf-dejavu :

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Le paquet `ttf-dejavu` installe automatiquement les dépendances liées aux polices requises, telles que `fontconfig`, `encodings`, `mkfontscale` et `mkfontdir`. Aucun paquet de police supplémentaire n'est nécessaire pour la plupart des cas d'utilisation.

**Option 2 : Polices Microsoft Core**

Si vos présentations utilisent des polices spécifiques à Microsoft, comme Arial, Times New Roman, Courier New ou Verdana, installez les Microsoft Core Fonts à la place :

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

N'utilisez cette option que lorsque les présentations traitées nécessitent les polices Microsoft. Dans la plupart des cas, installer `ttf-dejavu` est plus simple et plus fiable.

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Ceci est la version d'Aspose.Slides utilisant un moteur graphique multiplateforme personnalisé développé par l'équipe Aspose.Slides.  
Sur les plateformes non Windows, la bibliothèque `fontconfig` peut être requise.

**Plateformes prises en charge**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Plateformes non prises en charge**
- *Windows 11 ARM* (ARM64) — *Pas actuellement envisagé*

{{%  alert  title="Notes"  color="primary"  %}}  
Pour Linux x64, GLIBC 2.23+ est requis ; pour Linux ARM64, GLIBC 2.39+ est requis. Des systèmes tels que CentOS 7 (GLIBC 2.14) ne sont pas pris en charge. Si vous devez exécuter Aspose.Slides sur CentOS 7 ou d'autres systèmes incompatibles (par exemple, Alpine), veuillez utiliser le package standard : [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **FAQ**

**Ai-je besoin de Microsoft PowerPoint installé pour les conversions et le rendu ?**

Non, PowerPoint n'est pas requis ; Aspose.Slides est un moteur autonome pour [créer](/slides/fr/net/create-presentation/), modifier, [convertir](/slides/fr/net/convert-presentation/) et [rendre](/slides/fr/net/convert-powerpoint-to-png/) les présentations.

**Quelles polices sont nécessaires pour un rendu correct ?**

Les polices utilisées dans la présentation, ou des substituts appropriés, doivent être disponibles dans le système d'exploitation. Sous Linux et macOS, installez des paquets de polices courants pour garantir un rendu cohérent.

Pour les conteneurs Alpine Linux, installez au moins un paquet de polices en plus de `libgdiplus`. La configuration minimale recommandée est `libgdiplus` avec `ttf-dejavu`. Si les polices Microsoft telles qu'Arial, Times New Roman, Courier New ou Verdana sont requises, utilisez `msttcorefonts-installer` avec `fontconfig`.

**Pourquoi une police personnalisée s'affiche-t-elle comme une police de secours ou du texte manquant sous Linux ?**

Si le fichier de police comporte des entrées de table de noms incohérentes ou corrompues, la pile d'appariement de polices Linux (FreeType/fontconfig) peut sélectionner un enregistrement invalide, ce qui entraîne une police non résolue. L'utilisation d'une version de police avec des tables de noms corrigées ou l'installation d'un remplacement cohérent résout le problème.