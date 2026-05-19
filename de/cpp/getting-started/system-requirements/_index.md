---
title: Systemanforderungen
type: docs
weight: 80
url: /de/cpp/system-requirements/
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
- C++
- Aspose.Slides
description: "Entdecken Sie die Systemanforderungen von Aspose.Slides für C++. Stellen Sie nahtlose PowerPoint- und OpenDocument-Unterstützung unter Windows, Linux und macOS sicher."
---
## **Einleitung**

Aspose.Slides erfordert nicht, dass Microsoft PowerPoint installiert ist, weil Aspose.Slides eine eigenständige Engine für die Erstellung, Konvertierung, Seitenlayout und das Rendern von Microsoft PowerPoint‑Dokumenten ist.

## **Unterstützte Betriebssysteme**
Aspose.Slides für C++ ist eine native C++‑Bibliothek. Aspose.Slides für C++ unterstützt die folgenden 64‑Bit‑ und 32‑Bit‑Betriebssysteme und Plattformen:

### **Windows**
- Microsoft Windows Server 2008 (x64, x86)
- Microsoft Windows Server 2012 (x64, x86)
- Microsoft Windows Server 2012 R2 (x64, x86)
- Microsoft Windows Server 2016 (x64, x86)
- Microsoft Windows Server 2019 (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)

### **Linux**
- OS Ubuntu 16.04 oder höher.
- CentOS 8 oder höher.
- Fedora 24 oder höher.
- Und andere Linux x86_64 mit glibc 2.23 oder höher.

### **macOS**
- macOS Monterey 12.1 oder höher.

## **Entwicklungsumgebungen**
Sie können Aspose.Slides für C++ verwenden, wenn Sie Anwendungen für Windows, Linux oder macOS entwickeln.

### **Windows**
- Microsoft Visual Studio 2017 oder höher.
- CMake 3.18 oder höher.

### **Linux**
- Clang 3.9 oder höher.
- GCC 6.1 oder höher.
- CMake 3.18 oder höher.

### **macOS**
- Xcode 13.4 oder höher.

## **FAQ**

**Muss ich Microsoft PowerPoint für Konvertierungen und das Rendern installiert haben?**

Nein, PowerPoint ist nicht erforderlich; Aspose.Slides ist eine eigenständige Engine zum [Erstellen](/slides/de/cpp/create-presentation/), Ändern, [Konvertieren](/slides/de/cpp/convert-presentation/) und [Rendern](/slides/de/cpp/convert-powerpoint-to-png/) von Präsentationen.

**Welche Schriftarten werden für korrektes Rendern benötigt?**

In der Praxis müssen die in der Präsentation verwendeten Schriftarten oder geeignete [Ersatzschriften](/slides/de/cpp/font-substitution/) verfügbar sein. Um konsistentes Rendern auf Linux/macOS sicherzustellen, wird empfohlen, gängige Schriftpakete zu installieren.

**Warum wird eine benutzerdefinierte Schriftart unter Linux als Ersatz oder fehlender Text angezeigt?**

Wenn die Schriftdatei inkonsistente oder beschädigte Name‑Tabelleneinträge enthält, kann der Linux‑Font‑Matching‑Stack (FreeType/fontconfig) einen ungültigen Eintrag auswählen, was dazu führt, dass die Schriftart nicht aufgelöst wird. Die Verwendung einer Schriftartversion mit korrigierten Name‑Tabelleneinträgen oder die Installation eines konsistenten Ersatzes löst das Problem.