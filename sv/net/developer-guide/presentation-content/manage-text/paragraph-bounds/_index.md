---
title: Hämta styckesgränser från presentationer i .NET
linktitle: Styckesgränser
type: docs
weight: 43
url: /sv/net/paragraph-bounds/
keywords:
- styckesgränser
- styckeskoordinat
- styckestorlek
- textram
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du hämtar styckesgränser i Aspose.Slides för .NET för att optimera textplacering i PowerPoint-presentationer."
---
## **Översikt**

Denna artikel förklarar hur man får gränser, storlek och koordinater för stycken i Aspose.Slides. Den visar hur man hämtar en styckesrektangel från ett [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/) genom att använda [IParagraph.GetRect](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/getrect/), hur man får styckekoordinater inuti en tabellcells textram och belyser viktiga detaljer som mätenheter, hur textomslag påverkar gränser, pixelkonvertering och effektiva formateringsvärden för stycket.

## **Hämta rektangulära koordinater för ett stycke**

Använd [IParagraph.GetRect](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/getrect/) för att få styckets inneslutande rektangel.

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **Hämta storleken på ett stycke i en tabellcells TextFrame**

För att få storlek och koordinater för ett [IParagraph](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/) i en tabellcells textram, använd [IParagraph.GetRect](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/getrect/). Den returnerade rektangeln är relativ till tabellcellens textram, så lägg till tabellens position och cellens offset när du behöver koordinater på bildnivå.

Följande exempel hämtar styckesgränser i en tabellcell och ritar rektanglar på bilden för att visualisera dessa gränser:

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

**I vilka enheter mäts styckeskoordinater?**

De mäts i punkter, där 1 tum motsvarar 72 punkter. Detta gäller för alla koordinater och dimensioner på bilden.

**Påverkar radbrytning styckets gränser?**

Ja. Om [TextFrameFormat.WrapText](https://reference.aspose.com/slides/sv/net/aspose.slides/textframeformat/wraptext/) är aktiverat för [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/), bryts texten för att passa områdets bredd, vilket förändrar styckets faktiska gränser.

**Kan styckeskoordinater på ett tillförlitligt sätt mappar till pixlar i den exporterade bilden?**

Ja. Konvertera punkter till pixlar med formeln: pixlar = punkter × (DPI / 72). Resultatet beror på DPI som valts för rendering eller export.

**Hur får jag de "effektiva" formateringsparametrarna för ett stycke, med hänsyn till stilarv?**

Använd den [effektiva styckeformateringsdatatypen](/slides/sv/net/shape-effective-properties/); den returnerar de slutgiltiga sammanslagna värdena för indrag, avstånd, omslag, RTL och mer.