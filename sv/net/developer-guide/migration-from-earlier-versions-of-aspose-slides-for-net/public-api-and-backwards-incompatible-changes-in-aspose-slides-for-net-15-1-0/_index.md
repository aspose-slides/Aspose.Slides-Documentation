---
title: Offentligt API och bakåtinkompatibla förändringar i Aspose.Slides för .NET 15.1.0
linktitle: Aspose.Slides för .NET 15.1.0
type: docs
weight: 130
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- migrering
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Granska offentliga API‑uppdateringar och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint‑PPT, PPTX och ODP‑presentationslösningar."
---
{{% alert color="primary" %}} 

Den här sidan listar alla [tillsatta](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) eller [borttagna](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) klasser, metoder, egenskaper osv., samt andra förändringar som införts med Aspose.Slides for .NET 15.1.0 API.

{{% /alert %}} 
## **Offentliga API-förändringar**
#### **Funktionalitet för teckensnittssubstitution har lagts till**
Möjlighet att ersätta teckensnitt globalt i hela presentationen och temporärt för rendering har lagts till.

Ny egenskap "FontsManager" i Presentation-klassen har introducerats. FontsManager-klassen har följande medlemmar:

**IFontSubstRuleCollection FontSubstRuleList** Property  
Denna samling av IFontSubstRule‑instanser används för att ersätta teckensnitt under rendering. IFontSubstRule har SourceFont‑ och DestFont‑egenskaper som implementerar IFontData‑gränssnittet och ReplaceFontCondition‑egenskap som gör det möjligt att välja ersättningsvillkor ("WhenInaccessible" eller "Always").

**IFontData[] GetFonts()** Method  
Används för att hämta alla teckensnitt som används i den aktuella presentationen.

**ReplaceFont** Methods  
Används för att beständigt ersätta teckensnitt i presentationen.

Följande exempel visar hur man ersätter teckensnitt i presentationen:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Ett annat exempel demonstrerar teckensnittssubstitution för rendering när teckensnittet är otillgängligt:

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Arial-teckensnittet kommer att användas istället för SomeRareFont när det är otillgängligt

            pres.Slides[0].GetThumbnail();

```