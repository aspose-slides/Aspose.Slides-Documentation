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
description: "Upptäck Aspose.Slides för .NET systemkrav. Säkerställ sömlöst stöd för PowerPoint och OpenDocument på Windows, Linux och macOS."
---
## **Introduction**

Aspose.Slides för .NET kräver inte att Microsoft PowerPoint är installerat eftersom Aspose.Slides är en självständig motor för Microsoft PowerPoint‑dokument skapande, konvertering, sidlayout och rendering.

## **Supported Operating Systems**

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

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine, och andra)

### **Mac**

- Mac OS X

## **Supported Frameworks**

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
- Stöd för COM Interop (COM, C++, VBScript)

### **Mono Framework**

- MONO-stöd på MAC- och Linux-plattformar

## **Development Environments**

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Aspose.Slides Main Builds**

För närvarande finns det två huvudbyggen av Aspose.Slides — Aspose.Slides.NET och Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Detta är huvudversionen av produkten. Den använder den standard .NET‑grafikmotorn.
- På icke‑Windows‑plattformar kan det vara nödvändigt att installera biblioteket `libgdiplus` och dess beroenden.
- Före version Aspose.Slides 25.3 krävdes för icke‑Windows‑plattformar .NET Standard 2.0‑DLL från Aspose.Slides‑ZIP‑paketet.
- Från och med version Aspose.Slides 25.3 kan NuGet‑paketet användas direkt även på icke‑Windows‑system.
- När du kör på icke‑Windows‑system måste din applikation inkludera följande rad vid start:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **Från och med version 25.3 kan du använda detta paket på plattformar som stödjer .NET, t.ex. Linux aarch64 (ARM64).**

#### **Additional Packages for Linux Alpine**

När du kör Aspose.Slides för .NET i en Alpine‑Linux‑container kan enbart installation av `libgdiplus` vara otillräcklig. Alpine‑containrar inkluderar vanligtvis inga teckensnitt som standard. Om inga teckensnitt finns tillgängliga kan renderings‑ eller konverteringsoperationer misslyckas med ett fel som liknar:

```text
System.ArgumentException: Font '?' cannot be found
```

För att använda Aspose.Slides på Alpine, installera `libgdiplus` tillsammans med minst ett teckensnittspaket.

**Option 1: DejaVu Fonts**

Det rekommenderade alternativet är att installera paketet `ttf-dejavu`:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Paketet `ttf-dejavu` installerar automatiskt de erforderliga teckensnittsberoenden, såsom `fontconfig`, `encodings`, `mkfontscale` och `mkfontdir`. Ytterligare teckensnittspaket behövs vanligtvis inte.

**Option 2: Microsoft Core Fonts**

Om dina presentationer använder Microsoft‑specifika teckensnitt, t.ex. Arial, Times New Roman, Courier New eller Verdana, installera Microsoft Core Fonts istället:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Använd detta alternativ endast när de presentationer som bearbetas kräver Microsoft‑teckensnitt. För de flesta scenarier är installation av `ttf-dejavu` enklare och mer pålitligt.

**Additional requirements for globalization**

För att möjliggöra korrekt globaliseringsstöd på Alpine, installera paketet `icu-libs` och inaktivera invariant‑läge:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Detta är versionen av Aspose.Slides som använder en egenutvecklad cross‑platform‑grafikmotor skapad av Aspose.Slides‑teamet.  
På icke‑Windows‑plattformar kan biblioteket `fontconfig` behövas.

**Supported Platforms**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Unsupported Platforms**
- *Windows 11 ARM* (ARM64) — *Ej för närvarande under övervägning*

{{%  alert  title="Notes"  color="primary"  %}}  
För Linux x64 krävs GLIBC 2.23+; för Linux ARM64 krävs GLIBC 2.39+. System som CentOS 7 (GLIBC 2.14) stöds inte. Om du behöver köra Aspose.Slides på CentOS 7 eller andra inkompatibla system (t.ex. Alpine), använd standardpaketet: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}}

## **FAQ**

**Behöver jag ha Microsoft PowerPoint installerat för konverteringar och rendering?**

Nej, PowerPoint krävs inte; Aspose.Slides är en fristående motor för [skapa](/slides/sv/net/create-presentation/), modifiera, [konvertera](/slides/sv/net/convert-presentation/) och [rendera](/slides/sv/net/convert-powerpoint-to-png/) presentationer.

**Vilka teckensnitt behövs för korrekt rendering?**

Teckensnitten som används i presentationen, eller lämpliga ersättningar, måste finnas tillgängliga i operativsystemet. På Linux och macOS bör du installera vanliga teckensnittspaket för att säkerställa konsekvent rendering.

För Alpine‑Linux‑containrar, installera minst ett teckensnittspaket utöver `libgdiplus`. Den rekommenderade minimala konfigurationen är `libgdiplus` med `ttf-dejavu`. Om Microsoft‑teckensnitt som Arial, Times New Roman, Courier New eller Verdana krävs, använd `msttcorefonts-installer` ihop med `fontconfig`.

**Varför renderas ett anpassat teckensnitt som reserv eller saknas på Linux?**

Om teckensnittsfilen har inkonsekventa eller korrupta namn‑tabellsposter kan Linux‑teckensnittsmatchningsstacken (FreeType/fontconfig) välja en ogiltig post, vilket gör att teckensnittet blir olöst. Att använda en teckensnittsversion med korrigerade namn‑tabellposter eller installera en konsekvent ersättning löser problemet.