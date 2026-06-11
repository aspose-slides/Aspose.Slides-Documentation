---
title: Systemkrav
type: docs
weight: 80
url: /sv/cpp/system-requirements/
keywords:
- systemkrav
- operativsystem
- installation
- beroenden
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Upptäck systemkraven för Aspose.Slides för C++. Säkerställ sömlöst stöd för PowerPoint och OpenDocument på Windows, Linux och macOS."
---
## **Introduktion**

Aspose.Slides kräver inte att Microsoft PowerPoint är installerat eftersom Aspose.Slides är en fristående motor för skapande, konvertering, sidlayout och rendering av Microsoft PowerPoint‑dokument.

## **Stödda operativsystem**
Aspose.Slides for C++ är ett inbyggt C++‑bibliotek. Aspose.Slides for C++ stödjer följande 64‑bit‑ och 32‑bit‑operativsystem och plattformar:

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
- OS Ubuntu 16.04 eller senare.
- CentOS 8 eller senare.
- Fedora 24 eller senare.
- Och andra Linux x86_64 med glibc 2.23 eller senare.

### **macOS**
- macOS Monterey 12.1 eller senare.

## **Utvecklingsmiljöer**
Du kan använda Aspose.Slides for C++ när du utvecklar applikationer för Windows, Linux eller macOS.

### **Windows**
- Microsoft Visual Studio 2017 eller senare.
- CMake 3.18 eller senare.

### **Linux**
- Clang 3.9 eller senare.
- GCC 6.1 eller senare.
- CMake 3.18 eller senare.

### **macOS**
- Xcode 13.4 eller senare.

## **FAQ**

**Behöver jag ha Microsoft PowerPoint installerat för konverteringar och rendering?**

Nej, PowerPoint krävs inte; Aspose.Slides är en fristående motor för [skapa](/slides/sv/cpp/create-presentation/), modifiera, [konvertera](/slides/sv/cpp/convert-presentation/) och [rendera](/slides/sv/cpp/convert-powerpoint-to-png/) presentationer.

**Vilka teckensnitt behövs för korrekt rendering?**

I praktiken måste de teckensnitt som används i presentationen eller lämpliga [ersättningar](/slides/sv/cpp/font-substitution/) finnas tillgängliga. För att säkerställa konsekvent rendering på Linux/macOS är det rekommenderat att installera vanliga teckensnittspaket.

**Varför renderas ett anpassat teckensnitt som en reserv eller saknad text på Linux?**

Om teckensnittsfilen har inkonsekventa eller korrupta namn‑tabellsposter kan Linux‑font‑matchningsstacken (FreeType/fontconfig) välja en ogiltig post, vilket gör att teckensnittet blir olöst. Att använda en teckensnittsversion med korrigerade namn‑tabellposter eller installera ett konsistent ersättnings‑teckensnitt löser problemet.