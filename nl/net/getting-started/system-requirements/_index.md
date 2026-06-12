---
title: Systeemvereisten
type: docs
weight: 60
url: /nl/net/system-requirements/
keywords:
- systeemvereisten
- besturingssysteem
- installatie
- afhankelijkheden
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek de systeemvereisten van Aspose.Slides for .NET. Zorg voor naadloze ondersteuning van PowerPoint en OpenDocument op Windows, Linux en macOS."
---
## **Inleiding**

Aspose.Slides for .NET vereist geen Microsoft PowerPoint-installatie, omdat Aspose.Slides een zelfstandige engine is voor het maken, converteren, paginalayouten en renderen van Microsoft PowerPoint‑documenten.

## **Ondersteunde besturingssystemen**

Aspose.Slides for .NET ondersteunt elk 32‑bit of 64‑bit besturingssysteem waarop het .NET‑ of Mono‑framework is geïnstalleerd, inclusief (maar niet beperkt tot):

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

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine en anderen)

### **Mac**

- Mac OS X

## **Ondersteunde frameworks**

Aspose.Slides for .NET ondersteunt .NET‑ en Mono‑frameworks:

### **.NET‑frameworks**

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

### **Mono‑framework**

- MONO-ondersteuning op MAC‑ en Linux‑platforms

## **Ontwikkelomgevingen**

Aspose.Slides for .NET kan worden gebruikt om applicaties te ontwikkelen in elke ontwikkelomgeving die zich richt op het .NET‑platform, maar de volgende omgevingen worden expliciet ondersteund:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Hoofd‑builds van Aspose.Slides**

Momenteel zijn er twee hoofd‑builds van Aspose.Slides — Aspose.Slides.NET en Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Dit is de hoofdversie van het product. Het maakt gebruik van de standaard .NET‑graphicsengine.  
- Op niet‑Windows‑platformen moet u mogelijk de bibliotheek `libgdiplus` en de bijbehorende afhankelijkheden installeren.  
- Voor versie Aspose.Slides 25.3 was het op niet‑Windows‑platformen noodzakelijk om de .NET Standard 2.0‑DLL uit het Aspose.Slides‑ZIP‑pakket te gebruiken.  
- Vanaf versie Aspose.Slides 25.3 kan het NuGet‑pakket rechtstreeks worden gebruikt, zelfs op niet‑Windows‑systemen.  
- Wanneer u op niet‑Windows‑systemen draait, moet uw applicatie de volgende regel bij het opstarten opnemen:  
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```  
- **Vanaf versie 25.3 kunt u dit pakket gebruiken op platformen die .NET ondersteunen, zoals Linux aarch64 (ARM64).**

#### **Aanvullende pakketten voor Linux Alpine**

Wanneer u Aspose.Slides for .NET uitvoert in een Alpine‑Linux‑container, kan het installeren van alleen `libgdiplus` ontoereikend zijn. Alpine‑containers bevatten meestal standaard geen lettertypen. Als er geen lettertypen beschikbaar zijn, kunnen render‑ of conversie‑bewerkingen mislukken met een fout die lijkt op:

```text
System.ArgumentException: Font '?' cannot be found
```  
Om Aspose.Slides op Alpine te gebruiken, installeert u `libgdiplus` samen met ten minste één lettertype‑pakket.

**Optie 1: DejaVu‑lettertypen**

De aanbevolen optie is het installeren van het `ttf-dejavu`‑pakket:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```  

Het `ttf-dejavu`‑pakket installeert automatisch de vereiste afhankelijkheden voor lettertypen, zoals `fontconfig`, `encodings`, `mkfontscale` en `mkfontdir`. Voor de meeste gebruikssituaties zijn geen extra lettertype‑pakketten nodig.

**Optie 2: Microsoft Core‑lettertypen**

Als uw presentaties specifieke Microsoft‑lettertypen gebruiken, zoals Arial, Times New Roman, Courier New of Verdana, installeer dan Microsoft Core‑lettertypen in plaats daarvan:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```  

Gebruik deze optie alleen wanneer de te verwerken presentaties Microsoft‑lettertypen vereisen. Voor de meeste scenario’s is het installeren van `ttf-dejavu` eenvoudiger en betrouwbaarder.

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Dit is de versie van Aspose.Slides die een aangepaste cross‑platform graphicsengine gebruikt, ontwikkeld door het Aspose.Slides‑team.  
Op niet‑Windows‑platformen kan de bibliotheek `fontconfig` vereist zijn.

**Ondersteunde platformen**  
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)  
- *macOS*: x86_64, ARM64 (aarch64)

**Niet‑ondersteunde platformen**  
- *Windows 11 ARM* (ARM64) — *Momenteel niet in overweging*

{{%  alert  title="Notes"  color="primary"  %}}  
Voor Linux x64 is GLIBC 2.23+ vereist; voor Linux ARM64 is GLIBC 2.39+ vereist. Systemen zoals CentOS 7 (GLIBC 2.14) worden niet ondersteund. Als u Aspose.Slides op CentOS 7 of andere incompatibele systemen (bijv. Alpine) wilt uitvoeren, gebruik dan het standaardpakket: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **FAQ**

**Moet ik Microsoft PowerPoint geïnstalleerd hebben voor conversies en rendering?**

Nee, PowerPoint is niet vereist; Aspose.Slides is een zelfstandige engine voor het [maken](/slides/nl/net/create-presentation/), wijzigen, [converteren](/slides/nl/net/convert-presentation/) en [renderen](/slides/nl/net/convert-powerpoint-to-png/) van presentaties.

**Welke lettertypen zijn nodig voor correcte weergave?**

De in de presentatie gebruikte lettertypen, of geschikte vervangers, moeten beschikbaar zijn in het besturingssysteem. Installeer op Linux en macOS algemene lettertype‑pakketten om consistente weergave te garanderen.

Voor Alpine‑Linux‑containers installeert u ten minste één lettertype‑pakket naast `libgdiplus`. De minimaal aanbevolen configuratie is `libgdiplus` met `ttf-dejavu`. Als Microsoft‑lettertypen zoals Arial, Times New Roman, Courier New of Verdana nodig zijn, gebruik dan `msttcorefonts-installer` samen met `fontconfig`.

**Waarom wordt een aangepast lettertype op Linux weergegeven als fallback‑ of missende tekst?**

Als het lettertype‑bestand ongeldige of inconsistente name‑table‑records bevat, kan de Linux‑font‑matching‑stack (FreeType/fontconfig) een ongeldig record selecteren, waardoor het lettertype niet wordt herkend. Het gebruik van een lettertype‑versie met gecorrigeerde name‑table‑records of het installeren van een consistente vervanging lost het probleem op.