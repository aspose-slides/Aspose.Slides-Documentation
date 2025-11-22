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
- Aspose.Slides
description: "Découvrez les exigences du système d'Aspose.Slides pour .NET. Assurez une prise en charge transparente de PowerPoint et OpenDocument sous Windows, Linux et macOS."
---

## **Vue d'ensemble**
Aspose.Slides for .NET ne nécessite pas que Microsoft PowerPoint soit installé car Aspose.Slides est un moteur autonome de création, conversion, mise en page et rendu de documents Microsoft PowerPoint.

## **Systèmes d'exploitation pris en charge**
Aspose.Slides for .NET prend en charge tout système d'exploitation 32 bits ou 64 bits où le framework .NET ou Mono est installé, y compris (mais sans s'y limiter) :

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

{{%  alert  title="Notes"  color="primary"  %}} 
Comme CentOS 7 est fourni avec GLIBC 2.14 tandis qu'Aspose.Slides for .NET 6 et .NET 7 (y compris la version cross‑platform) nécessitent Linux x86_64 avec GLIBC 2.23 ou plus récent, vous pouvez utiliser Aspose.Slides for .NET Standard sur ce système.
{{% /alert %}} 

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
- COM Interop support (COM, C++, VBScript)

### **Mono Framework**
- MONO Support in MAC and Linux platforms

## **Environnements de développement**
Aspose.Slides for .NET peut être utilisé pour développer des applications dans n'importe quel environnement de développement ciblant la plateforme .NET, mais ces environnements sont explicitement pris en charge :

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Principales builds d'Aspose.Slides**
Actuellement, il existe deux builds principales d'Aspose.Slides — Aspose.Slides.NET et Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**
Il s'agit de la version principale du produit. Elle utilise le moteur graphique .NET standard.
- Sur les plates‑formes non Windows, il peut être nécessaire d'installer la bibliothèque `libgdiplus` ainsi que ses dépendances.
- Avant la version Aspose.Slides 25.3, pour les plates‑formes non Windows, il était nécessaire d'utiliser le DLL .NET Standard 2.0 du paquet ZIP Aspose.Slides.
- À partir de la version Aspose.Slides 25.3, le package NuGet peut être utilisé directement même sur les systèmes non Windows.
- Lors de l'exécution sur des systèmes non Windows, votre application doit inclure la ligne suivante au démarrage :
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```

- **À partir de la version 25.3, vous pouvez utiliser ce package sur les plates‑formes qui prennent en charge .NET, comme Linux aarch64 (ARM64).**

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**
Il s'agit de la version d'Aspose.Slides utilisant un moteur graphique multiplateforme personnalisé développé par l'équipe Aspose.Slides.  
Sur les plates‑formes non Windows, la bibliothèque `fontconfig` peut être requise.

**Plate‑formes prises en charge**
- *Windows*: x86, x86_64  
- *Linux*: x86_64  
- *macOS*: x86_64, ARM64

**Prévu pour prise en charge future**  
- *Linux*: aarch64 (ARM64) — *ETA: end of 2025*  

**Pas prévu**  
- *Windows 11 ARM* (ARM64) — *Not currently under consideration*

## **FAQ**

**Dois‑je installer Microsoft PowerPoint pour les conversions et le rendu ?**

Non, PowerPoint n’est pas requis ; Aspose.Slides est un moteur autonome pour [créer](/slides/fr/net/create-presentation/), modifier, [convertir](/slides/fr/net/convert-presentation/) et [rendre](/slides/fr/net/convert-powerpoint-to-png/) les présentations.

**Quelles polices sont nécessaires pour un rendu correct ?**

En pratique, les polices utilisées dans la présentation ou des [substituts](/slides/fr/net/font-substitution/) appropriés doivent être disponibles. Pour garantir un rendu cohérent sous Linux/macOS, il est conseillé d’installer les packages de polices courants.