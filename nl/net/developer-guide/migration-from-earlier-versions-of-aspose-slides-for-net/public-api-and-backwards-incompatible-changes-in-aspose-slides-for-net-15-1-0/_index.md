---
title: Openbare API en terugwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 15.1.0
linktitle: Aspose.Slides voor .NET 15.1.0
type: docs
weight: 130
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- migratie
- verouderde code
- moderne code
- verouderde aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de updates van de openbare API en de breaking changes in Aspose.Slides voor .NET om uw PowerPoint PPT-, PPTX- en ODP-presentatieoplossingen soepel te migreren."
---
{{% alert color="info" %}} 
Deze pagina geeft een overzicht van alle [added](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) of [removed](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) klassen, methoden, eigenschappen enz., en andere wijzigingen die zijn geïntroduceerd met de Aspose.Slides for .NET 15.1.0 API.
{{% /alert %}} 
## **Openbare API‑wijzigingen**
#### **Functionaliteit voor lettertypevervanging toegevoegd**
Mogelijkheid om lettertype globaal in de presentatie en tijdelijk voor weergave te vervangen is toegevoegd.

Nieuwe eigenschap "FontsManager" van de Presentation‑klasse is geïntroduceerd. De FontsManager‑klasse heeft de volgende leden:

**IFontSubstRuleCollection FontSubstRuleList** Property  
Deze collectie van IFontSubstRule‑instanties wordt gebruikt om lettertypen tijdens het renderen te vervangen. IFontSubstRule heeft de eigenschappen SourceFont en DestFont die de IFontData‑interface implementeren en de eigenschap ReplaceFontCondition waarmee de vervangingsconditie kan worden gekozen ("WhenInaccessible" of "Always").

**IFontData[] GetFonts()** Method  
Wordt gebruikt om alle lettertypen op te halen die in de huidige presentatie worden gebruikt.

**ReplaceFont** Methods  
Worden gebruikt om lettertype blijvend in de presentatie te vervangen.

Het volgende voorbeeld toont hoe een lettertype in de presentatie kan worden vervangen:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Een ander voorbeeld demonstreert lettertypevervanging voor weergave wanneer niet toegankelijk:

``` csharp
using Aspose.Slides;


             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Arial lettertype wordt gebruikt in plaats van SomeRareFont wanneer niet toegankelijk

            pres.Slides[0].GetImage();

```