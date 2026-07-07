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
description: "Ontdek de systeemvereisten van Aspose.Slides for .NET. Zorg voor naadloze ondersteuning voor PowerPoint en OpenDocument op Windows, Linux en macOS."
---
## **Inleiding**

Aspose.Slides for .NET vereist geen Microsoft PowerPoint geïnstalleerd omdat Aspose.Slides een onafhankelijke engine is voor het maken, converteren, paginalay-out en weergeven van Microsoft PowerPoint‑documenten.

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

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine en andere)

### **Mac**

- Mac OS X

## **Ondersteunde frameworks**

Aspose.Slides for .NET ondersteunt .NET‑ en Mono‑frameworks:

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
- COM Interop‑ondersteuning (COM, C++, VBScript)

### **Mono Framework**

- MONO‑ondersteuning op MAC‑ en Linux‑platforms

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

## **Aspose.Slides hoofdbuilds**

Momenteel zijn er twee hoofd‑builds van Aspose.Slides — Aspose.Slides.NET en Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Dit is de hoofdversie van het product. Het gebruikt de standaard .NET‑grafische engine.  
- Op niet‑Windows platformen moet u mogelijk de `libgdiplus`‑bibliotheek en de bijbehorende afhankelijkheden installeren.  
- Voor versie Aspose.Slides 25.3 was het voor niet‑Windows platformen nodig om de .NET Standard 2.0‑DLL uit het Aspose.Slides‑ZIP‑pakket te gebruiken.  
- Vanaf versie Aspose.Slides 25.3 kan het NuGet‑pakket rechtstreeks worden gebruikt, zelfs op niet‑Windows systemen.  
- Bij uitvoering op niet‑Windows systemen moet uw applicatie de volgende regel bij het opstarten opnemen:  
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```  
- **Vanaf versie 25.3 kunt u dit pakket gebruiken op platformen die .NET ondersteunen, zoals Linux aarch64 (ARM64).**

#### **Aanvullende pakketten voor Linux Alpine**

Wanneer Aspose.Slides for .NET wordt uitgevoerd in een Alpine‑Linux‑container, is het installeren van alleen `libgdiplus` mogelijk niet voldoende. Alpine‑containers bevatten doorgaans standaard geen lettertypen. Als er geen lettertypen beschikbaar zijn, kunnen render‑ of conversie‑operaties mislukken met een fout die lijkt op:  
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

Het `ttf-dejavu`‑pakket installeert automatisch de benodigde lettertype‑afhankelijkheden, zoals `fontconfig`, `encodings`, `mkfontscale` en `mkfontdir`. Voor de meeste gebruikssituaties zijn geen extra lettertype‑pakketten vereist.

**Optie 2: Microsoft Core Fonts**

Als uw presentaties Microsoft‑specifieke lettertypen gebruiken, zoals Arial, Times New Roman, Courier New of Verdana, installeer dan Microsoft Core Fonts:  
```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```  

Gebruik deze optie alleen wanneer de te verwerken presentaties Microsoft‑lettertypen nodig hebben. Voor de meeste scenario’s is het installeren van `ttf-dejavu` eenvoudiger en betrouwbaarder.

**Aanvullende vereisten voor globalisering**

Om correcte globaliseringsondersteuning op Alpine mogelijk te maken, installeer het `icu-libs`‑pakket en schakel invariant‑modus uit:  
```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Dit is de versie van Aspose.Slides die een aangepaste cross‑platform grafische engine gebruikt, ontwikkeld door het Aspose.Slides‑team.  
Op niet‑Windows platformen kan de `fontconfig`‑bibliotheek vereist zijn.

**Ondersteunde platformen**  
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)  
- *macOS*: x86_64, ARM64 (aarch64)

**Niet‑ondersteunde platformen**  
- *Windows 11 ARM* (ARM64) — *Momenteel niet in overweging*

{{%  alert  title="Opmerkingen"  color="primary"  %}}  
Voor Linux x64 is GLIBC 2.23+ vereist; voor Linux ARM64 is GLIBC 2.39+ vereist. Systemen zoals CentOS 7 (GLIBC 2.14) worden niet ondersteund. Als u Aspose.Slides moet draaien op CentOS 7 of andere incompatibele systemen (bijv. Alpine), gebruik dan het standaardpakket: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}}

## **FAQ**

**Heb ik Microsoft PowerPoint geïnstalleerd nodig voor conversies en weergave?**

Nee, PowerPoint is niet vereist; Aspose.Slides is een zelfstandige engine voor [maken](/slides/nl/net/create-presentation/), [bewerken](/slides/nl/net/convert-presentation/), [converteren](/slides/nl/net/convert-presentation/) en [renderen](/slides/nl/net/convert-powerpoint-to-png/) van presentaties.

**Welke lettertypen zijn nodig voor correcte weergave?**

De lettertypen die in de presentatie worden gebruikt, of geschikte vervangers, moeten beschikbaar zijn in het besturingssysteem. Installeer op Linux en macOS gangbare lettertype‑pakketten om consistente weergave te garanderen.

Voor Alpine‑Linux‑containers moet u naast `libgdiplus` ten minste één lettertype‑pakket installeren. De aanbevolen minimale configuratie is `libgdiplus` met `ttf-dejavu`. Als Microsoft‑lettertypen zoals Arial, Times New Roman, Courier New of Verdana vereist zijn, gebruik dan `msttcorefonts-installer` samen met `fontconfig`.

**Waarom wordt een aangepast lettertype op Linux weergegeven als fallback of ontbrekende tekst?**

Als het lettertype‑bestand inconsistente of corrupte naam‑tabel‑records bevat, kan de Linux‑lettertype‑matching‑stack (FreeType/fontconfig) een ongeldig record selecteren, waardoor het lettertype niet wordt gevonden. Het gebruik van een versie van het lettertype met correcte naam‑tabelrecords of het installeren van een consistente vervanging lost het probleem op.