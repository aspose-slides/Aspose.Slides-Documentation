---
title: Alinea-grenzen ophalen uit presentaties in .NET
linktitle: Alinea-grenzen
type: docs
weight: 43
url: /nl/net/paragraph-bounds/
keywords:
- alinea-grenzen
- alinea-coordinaat
- alinea-grootte
- tekstframe
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u alinea-grenzen kunt ophalen in Aspose.Slides voor .NET om de tekstpositionering in PowerPoint-presentaties te optimaliseren."
---
## **Overzicht**

Dit artikel legt uit hoe u de grenzen, grootte en coördinaten van alinea’s in Aspose.Slides kunt verkrijgen. Het toont hoe u een alinea‑rechthoek kunt ophalen via een [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/) met behulp van [IParagraph.GetRect](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph/getrect/), hoe u alinea‑coördinaten binnen een tekstframe van een tabelcel kunt krijgen, en belicht belangrijke details zoals meeteenheden, het effect van tekstomloop op grenzen, pixelconversie en effectieve alinea‑opmaakwaarden.

## **Rechthoekige coördinaten van een alinea ophalen**

Gebruik [IParagraph.GetRect](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph/getrect/) om de begrenzende rechthoek van een alinea te krijgen.

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **De grootte van een alinea binnen een tekstframe van een tabelcel ophalen**

Om de grootte en coördinaten van een [IParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph/) in een tekstframe van een tabelcel te krijgen, gebruikt u [IParagraph.GetRect](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph/getrect/). De geretourneerde rechthoek is relatief ten opzichte van het tekstframe van de tabelcel, dus voeg de tabelpositie en celoffset toe wanneer u slide‑niveau coördinaten nodig hebt.

Het volgende voorbeeld haalt de grenzen van een alinea binnen een tabelcel op en tekent rechthoeken op de slide om die grenzen te visualiseren:

```csharp
using var presentation = new Presentation("source.pptx");
var slide = presentation.Slides[0];
var table = (ITable)slide.Shapes[0];
var cell = table.Rows[1][1];

var cellX = table.X + cell.OffsetX;
var cellY = table.Y + cell.OffsetY;

foreach (var paragraph in cell.TextFrame.Paragraphs)
{
    if (string.IsNullOrEmpty(paragraph.Text))
        continue;

    var paragraphRectangle = paragraph.GetRect();
    var paragraphRectangleX = paragraphRectangle.X + (float)cellX;
    var paragraphRectangleY = paragraphRectangle.Y + (float)cellY;

    var paragraphBoundsShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.Width,
        paragraphRectangle.Height);

    paragraphBoundsShape.FillFormat.FillType = FillType.NoFill;
    paragraphBoundsShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
    paragraphBoundsShape.LineFormat.FillFormat.FillType = FillType.Solid;
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **FAQ**

**In welke eenheden worden alinea‑coördinaten gemeten?**

Ze worden gemeten in punten, waarbij 1 inch gelijk is aan 72 punten. Dit geldt voor alle coördinaten en afmetingen op de slide.

**Heeft tekstomloop invloed op de grenzen van een alinea?**

Ja. Als [TextFrameFormat.WrapText](https://reference.aspose.com/slides/nl/net/aspose.slides/textframeformat/wraptext/) is ingeschakeld voor het [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/), wordt de tekst afgebroken om de breedte van het gebied te passen, waardoor de daadwerkelijke grenzen van de alinea veranderen.

**Kunnen alinea‑coördinaten betrouwbaar worden omgezet naar pixels in de geëxporteerde afbeelding?**

Ja. Converteer punten naar pixels met de formule: pixels = points × (DPI / 72). Het resultaat hangt af van de DPI die is gekozen voor renderen of exporteren.

**Hoe haal ik de “effectieve” alinea‑opmaakparameters op, rekening houdend met overerving van stijlen?**

Gebruik de [effective paragraph formatting data structure](/slides/nl/net/shape-effective-properties/); deze geeft de uiteindelijke geconsolideerde waarden terug voor inspringingen, spatiëring, omloop, RTL en meer.