---
title: Systemkrav
type: docs
weight: 60
url: /sv/net/system-requirements/
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
- .NET
- C#
- Aspose.Slides
description: "Upptäck systemkraven för Aspose.Slides for .NET. Säkerställ sömlöst stöd för PowerPoint och OpenDocument på Windows, Linux och macOS."
---
## **Introduktion**

Aspose.Slides for .NET kräver inte att Microsoft PowerPoint är installerat eftersom Aspose.Slides är en oberoende Microsoft PowerPoint-dokument skapande, konverterings-, sidlayout- och renderingsmotor.

## **Stödda operativsystem**

Aspose.Slides for .NET stödjer alla 32‑bitars eller 64‑bitars operativsystem där .NET‑ eller Mono‑ramverket är installerat, inklusive (men inte begränsat till):

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

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine och andra)

### **Mac**

- Mac OS X

## **Stödda ramverk**

Aspose.Slides for .NET stödjer .NET‑ och Mono‑ramverken:

### **.NET‑ramverk**

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

### **Mono‑ramverk**

- MONO Support in MAC and Linux platforms

## **Utvecklingsmiljöer**

Aspose.Slides for .NET kan användas för att utveckla applikationer i vilken utvecklingsmiljö som helst som riktar sig mot .NET‑plattformen, men dessa miljöer stöds uttryckligen:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Aspose.Slides huvudbyggen**

För närvarande finns det två huvudbyggen av Aspose.Slides — Aspose.Slides.NET och Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Detta är huvudversionen av produkten. Den använder den standard .NET‑grafikmotorn.
- På icke‑Windows‑plattformar kan du behöva installera biblioteket `libgdiplus` och dess beroenden.
- Före version Aspose.Slides 25.3 var det för icke‑Windows‑plattformar nödvändigt att använda .NET Standard 2.0‑DLL från Aspose.Slides ZIP‑paketet.
- Från och med version Aspose.Slides 25.3 kan NuGet‑paketet användas direkt även på icke‑Windows‑system.
- När du kör på icke‑Windows‑system måste din applikation inkludera följande rad vid start:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **Från och med version 25.3 kan du använda detta paket på plattformar som stödjer .NET, såsom Linux aarch64 (ARM64).**

#### **Ytterligare paket för Linux Alpine**

När du kör Aspose.Slides for .NET i en Alpine‑Linux‑container kan installation av `libgdiplus` ensam vara otillräcklig. Alpine‑containrar inkluderar vanligtvis inte teckensnitt som standard. Om inga teckensnitt finns tillgängliga kan renderings‑ eller konverteringsoperationer misslyckas med ett fel som liknar:

```text
System.ArgumentException: Font '?' cannot be found
```
För att använda Aspose.Slides på Alpine, installera `libgdiplus` tillsammans med minst ett teckensnittspaket.

**Alternativ 1: DejaVu‑typsnitt**

Det rekommenderade alternativet är att installera paketet ttf-dejavu:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Paketet `ttf-dejavu` installerar automatiskt de nödvändiga teckensnittsberoenden, såsom `fontconfig`, `encodings`, `mkfontscale` och `mkfontdir`. Inga ytterligare teckensnittspaket krävs för de flesta användningsfall.

**Alternativ 2: Microsoft Core Fonts**

Om dina presentationer använder Microsoft‑specifika typsnitt, såsom Arial, Times New Roman, Courier New eller Verdana, installera Microsoft Core Fonts istället:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Använd detta alternativ endast när de presentationer som bearbetas kräver Microsoft‑typsnitt. För de flesta scenarier är det enklare och mer pålitligt att installera `ttf-dejavu`.

**Ytterligare krav för globalisering**

För att möjliggöra korrekt globaliseringsstöd på Alpine, installera paketet `icu-libs` och inaktivera invariant‑läget:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Detta är versionen av Aspose.Slides som använder en anpassad tvärplattformsgrafikmotor utvecklad av Aspose.Slides‑teamet. På icke‑Windows‑plattformar kan biblioteket `fontconfig` krävas.

**Stödda plattformar**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Ej stödda plattformar**
- *Windows 11 ARM* (ARM64) — *Not currently under consideration*

{{%  alert  title="Notes"  color="info"  %}}  
För Linux x64 krävs GLIBC 2.23+; för Linux ARM64 krävs GLIBC 2.39+. System som CentOS 7 (GLIBC 2.14) stöds inte. Om du behöver köra Aspose.Slides på CentOS 7 eller andra inkompatibla system (t.ex. Alpine), använd standardpaketet: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **FAQ**

### Behöver jag ha Microsoft PowerPoint installerat för konverteringar och rendering?

Nej, PowerPoint behövs inte; Aspose.Slides är en fristående motor för [skapa](/slides/sv/net/create-presentation/), modifiera, [konvertera](/slides/sv/net/convert-presentation/), och [rendera](/slides/sv/net/convert-powerpoint-to-png/) presentationer.

### Vilka typsnitt behövs för korrekt rendering?

De typsnitt som används i presentationen, eller lämpliga ersättningar, måste finnas tillgängliga i operativsystemet. På Linux och macOS, installera vanliga teckensnittspaket för att säkerställa konsekvent rendering.

För Alpine‑Linux‑containrar, installera minst ett teckensnittspaket utöver `libgdiplus`. Den rekommenderade minimala konfigurationen är `libgdiplus` med `ttf-dejavu`. Om Microsoft‑typsnitt såsom Arial, Times New Roman, Courier New eller Verdana krävs, använd `msttcorefonts-installer` tillsammans med `fontconfig`.

### Varför renderas ett anpassat typsnitt som reserv eller saknad text på Linux?

Om typsnittsfilen har inkonsekventa eller korrupta namn‑tabellsposter, kan Linux‑typsnittsmatchningsstacken (FreeType/fontconfig) välja en ogiltig post, vilket gör att typsnittet blir olöst. Att använda en version av typsnittet med korrigerade namn‑tabellsposter eller installera en konsekvent ersättningsfil löser problemet.