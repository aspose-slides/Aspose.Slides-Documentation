---
title: Publieke API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 15.1.0
linktitle: Aspose.Slides voor .NET 15.1.0
type: docs
weight: 130
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- migratie
- legacycode
- moderne code
- legacy aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de updates van de publieke API en breaking changes in Aspose.Slides voor .NET om soepel uw PowerPoint PPT-, PPTX- en ODP-presentatie-oplossingen te migreren."
---
{{% alert color="primary" %}} 
Deze pagina geeft een overzicht van alle [toegevoegde](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) of [verwijderde](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) klassen, methoden, eigenschappen enz., en andere wijzigingen die geïntroduceerd zijn met de Aspose.Slides for .NET 15.1.0 API.
{{% /alert %}} 
## **Openbare API-wijzigingen**
#### **Lettertype‑substitutiefunctionaliteit is toegevoegd**
Er is de mogelijkheid toegevoegd om lettertypen globaal in de hele presentatie te vervangen en tijdelijk voor het renderen.

De nieuwe eigenschap "FontsManager" van de Presentation‑klasse is geïntroduceerd. De FontsManager‑klasse heeft de volgende leden:

**IFontSubstRuleCollection FontSubstRuleList** eigenschap

Deze verzameling van IFontSubstRule‑instanties wordt gebruikt om lettertypen tijdens het renderen te substitueren. IFontSubstRule heeft de eigenschappen SourceFont en DestFont die de IFontData‑interface implementeren, en de eigenschap ReplaceFontCondition waarmee de vervangingsconditie kan worden gekozen ("WhenInaccessible" of "Always").

**IFontData[] GetFonts()** methode

Wordt gebruikt om alle lettertypen op te halen die in de huidige presentatie worden gebruikt.

**ReplaceFont** methoden

Wordt gebruikt om een lettertype blijvend in de presentatie te vervangen.

Het volgende voorbeeld toont hoe een lettertype in de presentatie te vervangen:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Een ander voorbeeld toont lettertype‑substitutie voor rendering wanneer het niet toegankelijk is:

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Arial-lettertype wordt gebruikt in plaats van SomeRareFont wanneer het ontoegankelijk is

            pres.Slides[0].GetThumbnail();
```