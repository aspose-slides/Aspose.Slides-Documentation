---
title: Exigences du système
type: docs
weight: 60
url: /fr/net/system-requirements/
keywords:
- exigences du système
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
description: "Découvrez les exigences système d'Aspose.Slides pour .NET. Assurez une prise en charge transparente de PowerPoint et OpenDocument sous Windows, Linux et macOS."
---
## **Aperçu**
Aspose.Slides pour .NET ne nécessite pas l'installation de Microsoft PowerPoint car Aspose.Slides est un moteur autonome de création, conversion, mise en page et rendu de documents Microsoft PowerPoint.

## **Systèmes d'exploitation pris en charge**
Aspose.Slides pour .NET prend en charge tout système d'exploitation 32 bits ou 64 bits où le framework .NET ou Mono est installé, y compris (mais sans s'y limiter) :

### **Windows**
- Microsoft Windows 2000 Server ( x64, x86)
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)
- Microsoft Windows 11 ( x64, x86)
- Microsoft Azure

### **Linux**
- Linux (Ubuntu, OpenSUSE, CentOS, Alpine, et autres)

### **Mac**
- Mac OS X

## **Frameworks pris en charge**
Aspose.Slides pour .NET prend en charge les frameworks .NET et Mono :

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
- COM Interop support (COM, C++, VBScript)

### **Mono Framework**
- Prise en charge de MONO sur les plateformes MAC et Linux

## **Environnements de développement**
Aspose.Slides pour .NET peut être utilisé pour développer des applications dans n'importe quel environnement de développement ciblant la plateforme .NET, mais les environnements suivants sont explicitement pris en charge :
- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Principaux builds d'Aspose.Slides**
Actuellement, il existe deux builds principaux d'Aspose.Slides — Aspose.Slides.NET et Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**
Ceci est la version principale du produit. Elle utilise le moteur graphique .NET standard.
- Sur les plateformes non Windows, il peut être nécessaire d'installer la bibliothèque `libgdiplus` ainsi que ses dépendances.
- Avant la version Aspose.Slides 25.3, sur les plateformes non Windows, il était nécessaire d'utiliser le DLL .NET Standard 2.0 provenant du package ZIP Aspose.Slides.
- À partir de la version Aspose.Slides 25.3, le package NuGet peut être utilisé directement même sur les systèmes non Windows.
- Lors de l'exécution sur des systèmes non Windows, votre application doit inclure la ligne suivante au démarrage :
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **À partir de la version 25.3, vous pouvez utiliser ce package sur les plateformes qui supportent .NET, comme Linux aarch64 (ARM64).**

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**
Il s'agit de la version d'Aspose.Slides utilisant un moteur graphique multiplateforme personnalisé développé par l'équipe Aspose.Slides.  
Sur les plateformes non Windows, la bibliothèque `fontconfig` peut être requise.

**Plateformes prises en charge**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Plateformes non prises en charge**
- *Windows 11 ARM* (ARM64) — *Pas actuellement envisagé*

{{%  alert  title="Notes"  color="primary"  %}}  
Pour Linux x64, GLIBC 2.23+ est requis ; pour Linux ARM64, GLIBC 2.39+ est requis. Les systèmes tels que CentOS 7 (GLIBC 2.14) ne sont pas pris en charge. Si vous devez exécuter Aspose.Slides sur CentOS 7 ou d’autres systèmes incompatibles (par ex., Alpine), veuillez utiliser le package standard : [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **FAQ**

**Do I need Microsoft PowerPoint installed for conversions and rendering?**

Non, PowerPoint n’est pas requis ; Aspose.Slides est un moteur autonome pour [créer](/slides/fr/net/create-presentation/), modifier, [convertir](/slides/fr/net/convert-presentation/), et [rendre](/slides/fr/net/convert-powerpoint-to-png/) les présentations.

**Which fonts are needed for correct rendering?**

En pratique, les polices utilisées dans la présentation ou les [substituts](/slides/fr/net/font-substitution/) appropriés doivent être disponibles. Pour garantir un rendu cohérent sur Linux/macOS, il est conseillé d'installer les paquets de polices courants.

**Why does a custom font render as a fallback or missing text on Linux?**

Si le fichier de police contient des entrées de table de noms incohérentes ou corrompues, la pile de correspondance de polices Linux (FreeType/fontconfig) peut sélectionner un enregistrement invalide, ce qui rend la police non résolue. L’utilisation d’une version de police avec des tables de noms corrigées ou l’installation d’un remplacement cohérent résout le problème.