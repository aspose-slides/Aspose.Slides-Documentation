---
title: Tekstgedeeltegrenzen ophalen uit presentaties in .NET
linktitle: Gedeeltegrenzen
type: docs
weight: 47
url: /nl/net/portion-bounds/
keywords:
- tekstgedeeltegrenzen
- tekstgedeelte
- tekstdeel
- tekstcoördinaten
- tekstpositie
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u tekstgedeeltegrenzen kunt ophalen in PowerPoint-presentaties met Aspose.Slides voor .NET."
---
## **Overzicht**

Een tekstgedeelte vertegenwoordigt een specifiek fragment van tekst binnen een alinea en stelt u in staat om met dat fragment onafhankelijk van de omringende inhoud te werken. In Aspose.Slides kunnen gedeelten worden gebruikt wanneer u de grenzen van een tekstfragment wilt ophalen, opmaak alleen op een deel van een alinea wilt toepassen, of het gedrag van tekst op een meer gedetailleerd niveau wilt beheersen.

Dit artikel laat zien hoe u de begrenzende rechthoek van een gedeelte kunt verkrijgen met behulp van [IPortion.GetRect](https://reference.aspose.com/slides/nl/net/aspose.slides/iportion/getrect/). Het laat ook zien hoe u de coördinaten van het begin van een gedeelte kunt verkrijgen met behulp van [IPortion.GetCoordinates](https://reference.aspose.com/slides/nl/net/aspose.slides/iportion/getcoordinates/). Daarnaast belicht het veelvoorkomende scenario’s met betrekking tot gedeelten, zoals het toepassen van een hyperlink op een enkel tekstfragment, inzicht krijgen in hoe opmaak wordt bepaald via gedeelte, alinea, tekstframe en thema‑erfenis, en het afhandelen van gevallen waarin een opgegeven lettertype niet beschikbaar is.

## **Grenzen van een Tekstgedeelte Opvragen**

Gebruik [IPortion.GetRect](https://reference.aspose.com/slides/nl/net/aspose.slides/iportion/getrect/) om het begrenzende rechthoek van een tekstgedeelte op te halen:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var rectangle = portion.GetRect();
        Console.WriteLine($"X = {rectangle.X}; Y = {rectangle.Y}; Width = {rectangle.Width}; Height = {rectangle.Height}");
    }
}
```

## **Coördinaten van een Tekstgedeelte Opvragen**

Gebruik [IPortion.GetCoordinates](https://reference.aspose.com/slides/nl/net/aspose.slides/iportion/getcoordinates/) om de coördinaten van het begin van een tekstgedeelte op te halen:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var point = portion.GetCoordinates();
        Console.WriteLine($"X = {point.X}; Y = {point.Y}");
    }
}
```

## **FAQ**

**Kan ik een hyperlink toepassen op slechts een deel van de tekst binnen één alinea?**

Ja, u kunt een [hyperlink toewijzen](/slides/nl/net/manage-hyperlinks/) aan een individueel gedeelte; alleen dat fragment zal klikbaar zijn, niet de hele alinea.

**Hoe werkt stijl‑erfenis: wat overschrijft een gedeelte, en wat wordt overgenomen van een alinea of tekstframe?**

Eigenschappen op gedeelte‑niveau hebben de hoogste prioriteit. Als een eigenschap niet is ingesteld op de [IPortion](https://reference.aspose.com/slides/nl/net/aspose.slides/iportion/), haalt Aspose.Slides deze van de [IParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph/). Als die er ook niet is, gebruikt Aspose.Slides de stijl van het [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/) of van het [theme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/theme/).

**Wat gebeurt er als het voor een gedeelte gespecificeerde lettertype ontbreekt op de doelsysteem of server?**

[Lettertype‑vervangingsregels](/slides/nl/net/font-selection-sequence/) worden toegepast. De tekst kan opnieuw vloeien: metriek, woordafbreking en breedte kunnen veranderen, wat van belang is voor een precieze positionering.

**Kan ik op gedeelte‑niveau de doorzichtigheid van de tekstvulling of een verloop instellen, onafhankelijk van de rest van de alinea?**

Ja, tekstkleur, vulling en doorzichtigheid op het [IPortion](https://reference.aspose.com/slides/nl/net/aspose.slides/iportion/)-niveau kunnen verschillen van aangrenzende fragmenten.