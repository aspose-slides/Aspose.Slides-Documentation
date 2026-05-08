---
title: Systemanforderungen
type: docs
weight: 60
url: /de/net/system-requirements/
keywords:
- system requirements
- operating system
- installation
- dependencies
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie die Systemanforderungen von Aspose.Slides für .NET. Stellen Sie nahtlose Unterstützung für PowerPoint und OpenDocument unter Windows, Linux und macOS sicher."
---
## **Übersicht**
Aspose.Slides für .NET erfordert nicht, dass Microsoft PowerPoint installiert ist, da Aspose.Slides eine eigenständige Engine für die Erstellung, Konvertierung, Seitenlayout und das Rendering von Microsoft PowerPoint‑Dokumenten ist.

## **Unterstützte Betriebssysteme**
Aspose.Slides für .NET unterstützt jedes 32‑Bit‑ oder 64‑Bit‑Betriebssystem, auf dem das .NET‑ oder Mono‑Framework installiert ist, einschließlich (aber nicht beschränkt auf):

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
- Linux (Ubuntu, OpenSUSE, CentOS, Alpine und andere)

### **Mac**
- Mac OS X

## **Unterstützte Frameworks**
Aspose.Slides für .NET unterstützt .NET‑ und Mono‑Frameworks:

### **.NET-Frameworks**
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
- COM Interop-Unterstützung (COM, C++, VBScript)

### **Mono-Framework**
- MONO-Unterstützung auf MAC‑ und Linux‑Plattformen

## **Entwicklungsumgebungen**
Aspose.Slides für .NET kann in jeder Entwicklungsumgebung verwendet werden, die die .NET‑Plattform adressiert, jedoch werden folgende Umgebungen explizit unterstützt:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Aspose.Slides-Hauptbuilds**
Derzeit gibt es zwei Haupt‑Builds von Aspose.Slides — Aspose.Slides.NET und Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides für .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**
Dies ist die Hauptversion des Produkts. Sie verwendet die standardmäßige .NET‑Grafik‑Engine.
- Auf Nicht‑Windows‑Plattformen müssen Sie möglicherweise die Bibliothek `libgdiplus` und deren Abhängigkeiten installieren.
- Vor Version Aspose.Slides 25.3 war es für Nicht‑Windows‑Plattformen notwendig, die .NET Standard 2.0‑DLL aus dem Aspose.Slides‑ZIP‑Paket zu verwenden.
- Ab Version Aspose.Slides 25.3 kann das NuGet‑Paket direkt auch auf Nicht‑Windows‑Systemen verwendet werden.
- Beim Ausführen auf Nicht‑Windows‑Systemen muss Ihre Anwendung beim Start die folgende Zeile einbinden:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **Ab Version 25.3 können Sie dieses Paket auf Plattformen verwenden, die .NET unterstützen, z. B. Linux aarch64 (ARM64).**

### **[Aspose.Slides für .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**
Dies ist die Version von Aspose.Slides, die eine von dem Aspose.Slides‑Team entwickelte benutzerdefinierte plattformübergreifende Grafik‑Engine verwendet.  
Auf Nicht‑Windows‑Plattformen kann die Bibliothek `fontconfig` erforderlich sein.

**Unterstützte Plattformen**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Nicht unterstützte Plattformen**
- *Windows 11 ARM* (ARM64) — *Derzeit nicht in Planung*

{{%  alert  title="Hinweise"  color="primary"  %}}  
Für Linux x64 ist GLIBC 2.23+ erforderlich; für Linux ARM64 ist GLIBC 2.39+ erforderlich. Systeme wie CentOS 7 (GLIBC 2.14) werden nicht unterstützt. Wenn Sie Aspose.Slides auf CentOS 7 oder anderen inkompatiblen Systemen (z. B. Alpine) ausführen müssen, verwenden Sie bitte das Standardpaket: [Aspose.Slides für .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **FAQ**

**Muss Microsoft PowerPoint für Konvertierungen und Rendering installiert sein?**

Nein, PowerPoint wird nicht benötigt; Aspose.Slides ist eine eigenständige Engine für das [Erstellen](/slides/de/net/create-presentation/), Ändern, [Konvertieren](/slides/de/net/convert-presentation/) und [Rendern](/slides/de/net/convert-powerpoint-to-png/) von Präsentationen.

**Welche Schriftarten werden für korrektes Rendering benötigt?**

In der Praxis müssen die in der Präsentation verwendeten Schriftarten bzw. geeignete [Ersatzschriften](/slides/de/net/font-substitution/) verfügbar sein. Um ein einheitliches Rendering unter Linux/macOS sicherzustellen, empfiehlt es sich, gängige Schriftpakete zu installieren.

**Warum wird eine benutzerdefinierte Schriftart unter Linux als Ersatzschrift oder fehlender Text angezeigt?**

Wenn die Schriftdatei inkonsistente oder beschädigte Name‑Table‑Einträge enthält, kann der Linux‑Font‑Matching‑Stack (FreeType/fontconfig) einen ungültigen Eintrag auswählen, wodurch die Schriftart nicht aufgelöst wird. Die Verwendung einer Schriftart‑Version mit korrigierten Name‑Table‑Einträgen oder das Installieren eines konsistenten Ersatzes behebt das Problem.