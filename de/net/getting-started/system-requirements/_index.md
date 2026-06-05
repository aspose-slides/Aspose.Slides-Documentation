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
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie die Systemanforderungen von Aspose.Slides für .NET. Stellen Sie nahtlose Unterstützung für PowerPoint und OpenDocument unter Windows, Linux und macOS sicher."
---
## **Einleitung**

Aspose.Slides für .NET erfordert keine Installation von Microsoft PowerPoint, da Aspose.Slides eine eigenständige Engine zur Erstellung, Konvertierung, Seitenlayout und Darstellung von Microsoft PowerPoint‑Dokumenten ist.

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
- COM Interop support (COM, C++, VBScript)

### **Mono Framework**

- MONO‑Unterstützung auf MAC‑ und Linux‑Plattformen

## **Entwicklungsumgebungen**

Aspose.Slides für .NET kann in jeder Entwicklungsumgebung verwendet werden, die die .NET‑Plattform anvisiert, aber die folgenden Umgebungen werden explizit unterstützt:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Haupt‑Builds von Aspose.Slides**

Derzeit gibt es zwei Haupt‑Builds von Aspose.Slides — Aspose.Slides.NET und Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides für .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Dies ist die Hauptversion des Produkts. Sie verwendet die standardmäßige .NET‑Grafikengine.
- Auf Nicht‑Windows‑Plattformen müssen Sie möglicherweise die Bibliothek `libgdiplus` und deren Abhängigkeiten installieren.
- Vor Version Aspose.Slides 25.3 war es für Nicht‑Windows‑Plattformen erforderlich, die .NET Standard 2.0‑DLL aus dem Aspose.Slides‑ZIP‑Paket zu verwenden.
- Ab Version Aspose.Slides 25.3 kann das NuGet‑Paket direkt auch auf Nicht‑Windows‑Systemen verwendet werden.
- Beim Ausführen auf Nicht‑Windows‑Systemen muss Ihre Anwendung die folgende Zeile beim Start einbinden:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **Ab Version 25.3 können Sie dieses Paket auf Plattformen verwenden, die .NET unterstützen, z. B. Linux aarch64 (ARM64).**

#### **Zusätzliche Pakete für Linux Alpine**

Beim Ausführen von Aspose.Slides für .NET in einem Alpine‑Linux‑Container reicht die Installation von `libgdiplus` allein möglicherweise nicht aus. Alpine‑Container enthalten standardmäßig normalerweise keine Schriftarten. Wenn keine Schriftarten vorhanden sind, können Rendering‑ oder Konvertierungs‑Operationen mit einem Fehler ähnlich dem folgenden fehlschlagen:

```text
System.ArgumentException: Font '?' cannot be found
```
Um Aspose.Slides auf Alpine zu verwenden, installieren Sie `libgdiplus` zusammen mit mindestens einem Schriftpaket.

**Option 1: DejaVu‑Schriften**

Die empfohlene Option ist die Installation des Pakets `ttf-dejavu`:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Das Paket `ttf-dejavu` installiert automatisch die erforderlichen Schrift‑Abhängigkeiten wie `fontconfig`, `encodings`, `mkfontscale` und `mkfontdir`. Für die meisten Anwendungsfälle sind keine zusätzlichen Schriftpakete nötig.

**Option 2: Microsoft Core Fonts**

Falls Ihre Präsentationen Microsoft‑spezifische Schriften wie Arial, Times New Roman, Courier New oder Verdana verwenden, installieren Sie stattdessen die Microsoft Core Fonts:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Verwenden Sie diese Option nur, wenn die zu verarbeitenden Präsentationen Microsoft‑Schriften benötigen. Für die meisten Szenarien ist die Installation von `ttf-dejavu` einfacher und zuverlässiger.

### **[Aspose.Slides für .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Dies ist die Version von Aspose.Slides, die eine vom Aspose.Slides‑Team entwickelte benutzerdefinierte plattformübergreifende Grafikengine nutzt.  
Auf Nicht‑Windows‑Plattformen kann die Bibliothek `fontconfig` erforderlich sein.

**Unterstützte Plattformen**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Nicht unterstützte Plattformen**
- *Windows 11 ARM* (ARM64) — *Derzeit nicht in Betracht gezogen*

{{%  alert  title="Notes"  color="primary"  %}}  
Für Linux x64 ist GLIBC 2.23+ erforderlich; für Linux ARM64 ist GLIBC 2.39+ erforderlich. Systeme wie CentOS 7 (GLIBC 2.14) werden nicht unterstützt. Wenn Sie Aspose.Slides auf CentOS 7 oder anderen inkompatiblen Systemen (z. B. Alpine) ausführen müssen, verwenden Sie bitte das Standardpaket: [Aspose.Slides für .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **FAQ**

**Muss Microsoft PowerPoint für Konvertierungen und Rendering installiert sein?**

Nein, PowerPoint ist nicht erforderlich; Aspose.Slides ist eine eigenständige Engine zum [Erstellen](/slides/de/net/create-presentation/), Ändern, [Konvertieren](/slides/de/net/convert-presentation/) und [Rendern](/slides/de/net/convert-powerpoint-to-png/) von Präsentationen.

**Welche Schriften werden für korrektes Rendering benötigt?**

Die in der Präsentation verwendeten Schriften oder geeignete Ersatzschriften müssen im Betriebssystem vorhanden sein. Auf Linux und macOS sollten gängige Schriftpakete installiert werden, um ein konsistentes Rendering sicherzustellen.

Für Alpine‑Linux‑Container installieren Sie mindestens ein Schriftpaket zusätzlich zu `libgdiplus`. Die empfohlene Minimalkonfiguration ist `libgdiplus` mit `ttf-dejavu`. Wenn Microsoft‑Schriften wie Arial, Times New Roman, Courier New oder Verdana benötigt werden, verwenden Sie `msttcorefonts-installer` zusammen mit `fontconfig`.

**Warum wird eine benutzerdefinierte Schrift auf Linux als Fallback oder fehlender Text dargestellt?**

Falls die Schriftdatei inkonsistente oder beschädigte Name‑Table‑Einträge enthält, kann der Linux‑Font‑Matching‑Stack (FreeType/fontconfig) einen ungültigen Eintrag auswählen, wodurch die Schrift nicht aufgelöst wird. Die Verwendung einer Schriftversion mit korrigierten Name‑Table‑Einträgen oder das Installieren einer konsistenten Ersatzschrift löst das Problem.