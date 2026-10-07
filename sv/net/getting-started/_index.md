---
title: Kom igång
type: docs
weight: 10
url: /sv/net/getting-started/
keywords:
- kom igång
- systemkrav
- installation
- första presentationen
- NuGet
- PPT-behandling
- PPTX-behandling
- ODP-behandling
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Vägen från ett nytt .NET-projekt till en första sparad presentation med Aspose.Slides: kontrollera kraven, installera paketet, kör ett första program och fortsätt med vanliga uppgifter."
---
## **Översikt**

Gå igenom de fyra stegen nedan i ordning. Varje steg anger vad som ska göras och länkar till artikeln med detaljerna. Utvärdering, licensiering och support behandlas efter stegen.

## **Steg 1: Kontrollera systemkraven**

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) körs på Windows, Linux och macOS. [Systemkrav](/slides/sv/net/system-requirements/) listar operativsystemen och .NET-versionerna som varje paket stödjer, samt de bibliotek som Linux behöver utöver.

## **Steg 2: Installera paketet**

Aspose.Slides for .NET distribueras via NuGet som två paket som tillhandahåller samma klasser. Lägg till ett av dem i ditt projekt:

- På Windows: `dotnet add package Aspose.Slides.NET`
- På Linux och macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform`. På Linux installeras biblioteket `fontconfig` först.
- På Alpine Linux och på Linux‑system vars glibc är äldre än 2.23 (x64) eller 2.39 (ARM64): Aspose.Slides.NET, med biblioteket `libgdiplus` installerat.

[Installation](/slides/sv/net/installation/) ger Linux-kommandona, den extra startinställning som Aspose.Slides.NET behöver på Linux, och stegen för Visual Studio.

## **Steg 3: Skapa din första presentation**

[snabbstart på Aspose.Slides för .NET:s hemsida](/slides/sv/net/#your-first-presentation) är ett komplett konsolprogram: det lägger till en textruta på en bild och sparar presentationen som en PPTX‑fil. [Skapa presentationer](/slides/sv/net/create-presentation/) förklarar samma steg mer i detalj och visar hur man öppnar en befintlig presentation och sparar den i ett annat format.

## **Steg 4: Fortsätt med vanliga uppgifter**

- [Öppna en presentation](/slides/sv/net/open-presentation/)
- [Spara en presentation](/slides/sv/net/save-presentation/)
- [Konvertera en presentation till PDF](/slides/sv/net/convert-powerpoint-to-pdf/)
- [Rendera bildspel som bilder](/slides/sv/net/convert-slide/)
- [Redigera presentationstext](/slides/sv/net/manage-text/)
- [Exempel per bildobjekt](/slides/sv/net/examples/)

## **Utvärdera och licensiera**

Utan en licens kör Aspose.Slides i utvärderingsläge: den lägger till ett vattenstämpel på varje bild den sparar och trunkerar text som läses från presentationer.

- [Utvärdera Aspose.Slides](/slides/sv/net/evaluate-aspose-slides/) beskriver utvärderingsbegränsningarna och hur man begär en tillfällig licens.
- [Licensiering](/slides/sv/net/licensing/) visar hur man tillämpar en licens från en fil, en ström eller en inbäddad resurs.
- [Måttbaserad licensiering](/slides/sv/net/metered-licensing/) behandlar licensiering som faktureras efter användning.
- [Filformat som stöds](/slides/sv/net/supported-file-formats/) listar de format som Aspose.Slides kan läsa och skriva.

## **Få hjälp**

[Produktstöd](/slides/sv/net/product-support/) förklarar hur man ställer en fråga på [gratis supportforum](https://forum.aspose.com/c/slides/11) och vad som bör inkluderas när du rapporterar ett problem.

## **FAQ**

**Behöver jag Microsoft PowerPoint installerat?**

Nej. Aspose.Slides läser och skriver presentationsfiler själv och använder inte PowerPoint, så den kan också köras på servrar och på Linux.

**Vilket paket ska jag använda för ett .NET Framework‑program?**

Aspose.Slides.NET. Det inkluderar byggen för .NET Framework 4.6.2 och senare, .NET 6 och senare, samt .NET Standard 2.0. Aspose.Slides.NET6.CrossPlatform kräver .NET 6 eller senare.