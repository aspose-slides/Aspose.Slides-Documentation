---
title: Aan de slag
type: docs
weight: 10
url: /nl/net/getting-started/
keywords:
- aan de slag
- systeemvereisten
- installatie
- eerste presentatie
- NuGet
- PPT verwerking
- PPTX verwerking
- ODP verwerking
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "De weg van een nieuw .NET-project naar een eerste opgeslagen presentatie met Aspose.Slides: controleer de vereisten, installeer het pakket, voer een eerste programma uit en ga door met algemene taken."
---
## **Overzicht**

Werk de vier onderstaande stappen in volgorde af. Elke stap benoemt wat je moet doen en linkt naar het artikel met de details. Evaluatie, licenties en ondersteuning worden behandeld na de stappen.

## **Stap 1: Controleer de systeemvereisten**

Aspose.Slides voor .NET draait op Windows, Linux en macOS. [Systeemvereisten](/slides/nl/net/system-requirements/) geeft een overzicht van de besturingssystemen en .NET‑versies die elk pakket ondersteunt, en van de extra bibliotheken die Linux nodig heeft.

## **Stap 2: Installeer het pakket**

Aspose.Slides voor .NET wordt gedistribueerd via NuGet als twee pakketten die dezelfde klassen leveren. Voeg er één toe aan je project:

- Op Windows: `dotnet add package Aspose.Slides.NET`
- Op Linux en macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform`. Installeer eerst de `fontconfig`‑bibliotheek op Linux.
- Op Alpine Linux, en op Linux‑systemen waarvan de glibc ouder is dan 2.23 (x64) of 2.39 (ARM64): Aspose.Slides.NET, met de geïnstalleerde `libgdiplus`‑bibliotheek.

[Installatie](/slides/nl/net/installation/) bevat de Linux‑commando’s, de extra opstartinstelling die Aspose.Slides.NET nodig heeft op Linux, en de stappen voor Visual Studio.

## **Stap 3: Maak je eerste presentatie**

De [quick start op de startpagina van Aspose.Slides voor .NET](/slides/nl/net/#your-first-presentation) is een volledig console‑programma: het voegt een tekstvak toe aan een dia en slaat de presentatie op als een PPTX‑bestand. [Presentaties maken](/slides/nl/net/create-presentation/) legt dezelfde stappen uitgebreider uit en toont hoe je een bestaande presentatie opent en opslaat in een ander formaat.

## **Stap 4: Ga door met algemene taken**

- [Open een presentatie](/slides/nl/net/open-presentation/)
- [Sla een presentatie op](/slides/nl/net/save-presentation/)
- [Converteer een presentatie naar PDF](/slides/nl/net/convert-powerpoint-to-pdf/)
- [Render dia’s als afbeeldingen](/slides/nl/net/convert-slide/)
- [Bewerk presentatie‑tekst](/slides/nl/net/manage-text/)
- [Voorbeelden per dia‑element](/slides/nl/net/examples/)

## **Evalueren en licentiëren**

Zonder licentie draait Aspose.Slides in evaluatiemodus: het voegt een watermerk toe aan elke dia die wordt opgeslagen en knipt de tekst af die uit presentaties wordt gelezen.

- [Aspose.Slides evalueren](/slides/nl/net/evaluate-aspose-slides/) beschrijft de beperkingen van de evaluatie en hoe je een tijdelijke licentie kunt aanvragen.
- [Licenties](/slides/nl/net/licensing/) laat zien hoe je een licentie toepast vanuit een bestand, een stream of een ingesloten bron.
- [Metered licentiëring](/slides/nl/net/metered-licensing/) behandelt licentiëring die per gebruik wordt gefactureerd.
- [Ondersteunde bestandsformaten](/slides/nl/net/supported-file-formats/) somt de formaten op die Aspose.Slides kan laden en opslaan.

## **Hulp krijgen**

[Productondersteuning](/slides/nl/net/product-support/) legt uit hoe je een vraag stelt op het [gratis ondersteuningsforum](https://forum.aspose.com/c/slides/11) en wat je moet vermelden wanneer je een probleem meldt.

## **FAQ**

**Moet ik Microsoft PowerPoint geïnstalleerd hebben?**

Nee. Aspose.Slides leest en schrijft presentatiebestanden zelf en maakt geen gebruik van PowerPoint, waardoor het ook op servers en op Linux draait.

**Welk pakket moet ik gebruiken voor een .NET Framework‑applicatie?**

Aspose.Slides.NET. Het bevat builds voor .NET Framework 4.6.2 en hoger, .NET 6 en hoger, en .NET Standard 2.0. Aspose.Slides.NET6.CrossPlatform vereist .NET 6 of hoger.