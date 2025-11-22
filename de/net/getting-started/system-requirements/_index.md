---
title: Systemanforderungen
type: docs
weight: 60
url: /de/net/system-requirements/
keywords:
- Systemanforderungen
- Betriebssystem
- Installation
- Abhängigkeiten
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- Präsentation
- Aspose.Slides
description: "Entdecken Sie die Systemanforderungen von Aspose.Slides für .NET. Stellen Sie nahtlose Unterstützung für PowerPoint und OpenDocument unter Windows, Linux und macOS sicher."
---

## **Übersicht**
Aspose.Slides für .NET erfordert nicht, dass Microsoft PowerPoint installiert ist, da Aspose.Slides eine eigenständige Microsoft PowerPoint‑Dokumenterstellungs‑, Konversions‑, Layout‑ und Rendering‑Engine ist.

## **Unterstützte Betriebssysteme**
Aspose.Slides für .NET unterstützt jedes 32‑Bit‑ oder 64‑Bit‑Betriebssystem, auf dem das .NET‑ oder Mono‑Framework installiert ist, einschließlich (aber nicht beschränkt auf):

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
- Linux (Ubuntu, OpenSUSE, CentOS, Alpine und andere)

{{%  alert  title="Hinweise"  color="primary"  %}} 

Da CentOS 7 mit GLIBC 2.14 ausgeliefert wird, während Aspose.Slides für .NET 6 und .NET 7 (einschließlich des plattformübergreifenden Builds) Linux x86_64 mit GLIBC 2.23 oder neuer benötigen, können Sie auf einem solchen System Aspose.Slides für .NET Standard verwenden.

{{% /alert %}} 

### **Mac**
- Mac OS X

## **Unterstützte Frameworks**
Aspose.Slides für .NET unterstützt .NET‑ und Mono‑Frameworks:

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
- COM‑Interop‑Unterstützung (COM, C++, VBScript)

### **Mono Framework**
- MONO‑Unterstützung auf MAC‑ und Linux‑Plattformen

## **Entwicklungsumgebungen**
Aspose.Slides für .NET kann in jeder Entwicklungsumgebung verwendet werden, die die .NET‑Plattform anvisiert, jedoch werden die folgenden Umgebungen explizit unterstützt:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Aspose.Slides Haupt-Builds**
Derzeit gibt es zwei Haupt‑Builds von Aspose.Slides — Aspose.Slides.NET und Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides für .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**
Dies ist die Hauptversion des Produkts. Sie verwendet die Standard‑.NET‑Grafikengine.
- Auf Nicht‑Windows‑Plattformen müssen Sie möglicherweise die Bibliothek `libgdiplus` und deren Abhängigkeiten installieren.
- Vor Version Aspose.Slides 25.3 war es für Nicht‑Windows‑Plattformen notwendig, die .NET Standard 2.0‑DLL aus dem Aspose.Slides‑ZIP‑Paket zu verwenden.
- Ab Version Aspose.Slides 25.3 kann das NuGet‑Paket direkt, sogar auf Nicht‑Windows‑Systemen, verwendet werden.
- Beim Ausführen auf Nicht‑Windows‑Systemen muss Ihre Anwendung die folgende Zeile beim Start einbinden:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```

- **Ab Version 25.3 können Sie dieses Paket auf Plattformen nutzen, die .NET unterstützen, z. B. Linux aarch64 (ARM64).**

### **[Aspose.Slides für .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**
Dies ist die Version von Aspose.Slides, die eine vom Aspose.Slides‑Team entwickelte benutzerdefinierte plattformübergreifende Grafikengine verwendet.  
Auf Nicht‑Windows‑Plattformen kann die Bibliothek `fontconfig` erforderlich sein.

**Unterstützte Plattformen**
- *Windows*: x86, x86_64  
- *Linux*: x86_64  
- *macOS*: x86_64, ARM64

**Geplante zukünftige Unterstützung**  
- *Linux*: aarch64 (ARM64) — *ETA: Ende 2025*  

**Nicht geplant**
- *Windows 11 ARM* (ARM64) — *Derzeit nicht in Betracht gezogen*

## **FAQ**

**Muss Microsoft PowerPoint für Konvertierungen und Rendering installiert sein?**

Nein, PowerPoint wird nicht benötigt; Aspose.Slides ist eine eigenständige Engine zum [Erstellen](/slides/de/net/create-presentation/), Ändern, [Konvertieren](/slides/de/net/convert-presentation/) und [Rendern](/slides/de/net/convert-powerpoint-to-png/) von Präsentationen.

**Welche Schriften werden für korrektes Rendering benötigt?**

In der Praxis müssen die in der Präsentation verwendeten Schriften oder geeignete [Ersatzschriften](/slides/de/net/font-substitution/) verfügbar sein. Um ein konsistentes Rendering unter Linux/macOS sicherzustellen, empfiehlt sich die Installation gängiger Schriftpakete.