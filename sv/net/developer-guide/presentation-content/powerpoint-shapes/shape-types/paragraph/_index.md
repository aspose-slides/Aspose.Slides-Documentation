---
title: Hämta styckegränser från presentationer i .NET
linktitle: Stycke
type: docs
weight: 60
url: /sv/net/paragraph/
keywords:
- styckegränser
- textdelgränser
- styckekoordinat
- delkoordinat
- styckestorlek
- textdelstorlek
- textram
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du hämtar stycke- och textdelgränser i Aspose.Slides för .NET för att optimera textplacering i PowerPoint-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur man hämtar gränser, storlek och koordinater för stycken och textdelar i Aspose.Slides. Den visar hur man hämtar ett styckes rektangel i ett `TextFrame` med `GetRect()`, hur man får stycke- och delkoordinater i ett tabellcells‑TextFrame, och lyfter fram viktiga detaljer såsom mätenheter, effekten av textradbrytning på gränser, pixelförvandling och effektiva formateringsvärden för stycket.

## **Hämta stycke- och delkoordinater i ett TextFrame**

Med Aspose.Slides för .NET kan utvecklare nu hämta de rektangulära koordinaterna för ett Paragraph i Paragraph‑samlingen i ett TextFrame. Det gör det också möjligt att hämta koordinaterna för en Portion i Portion‑samlingen för ett Paragraph. I det här avsnittet kommer vi att demonstrera med ett exempel hur man får de rektangulära koordinaterna för ett Paragraph tillsammans med positionen för Portion i ett Paragraph.

## **Hämta rektangulära koordinater för ett Paragraph**

Den nya metoden **GetRect()** har lagts till. Den gör det möjligt att hämta ett Paragraph:s bounds‑rektangel.

```c#
// Instansiera ett Presentation-objekt som representerar en presentationsfil
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **Hämta storleken för ett Paragraph och en Portion i ett tabellcell‑TextFrame**

För att få storleken och koordinaterna för en [Portion](https://reference.aspose.com/slides/sv/net/aspose.slides/portion) eller ett [Paragraph](https://reference.aspose.com/slides/sv/net/aspose.slides/paragraph) i ett tabellcell‑TextFrame, kan du använda metoderna [IPortion.GetRect](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/methods/getrect) och [IParagraph.GetRect](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/methods/getrect).

Det här exempelprogrammet demonstrerar den beskrivna operationen:

```csharp
using (Presentation pres = new Presentation("source.pptx"))
{
    Table tbl = pres.Slides[0].Shapes[0] as Table;

    ICell cell = tbl.Rows[1][1];


    double x = tbl.X + tbl.Rows[1][1].OffsetX;
    double y = tbl.Y + tbl.Rows[1][1].OffsetY;

    foreach (IParagraph para in cell.TextFrame.Paragraphs)
    {
        if (para.Text == "")
            continue;

        RectangleF rect = para.GetRect();
        IAutoShape shape =
            pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
        shape.LineFormat.FillFormat.FillType = FillType.Solid;


        foreach (IPortion portion in para.Portions)
        {
            if (portion.Text.Contains("0"))
            {
                rect = portion.GetRect();
                shape =
                    pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                        rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

                shape.FillFormat.FillType = FillType.NoFill;
            }
        }
    }
}
```

## **Vanliga frågor**

**I vilka enheter anges koordinaterna för ett Paragraph och textdelar?**

I punkter, där 1 tum = 72 punkter. Detta gäller för alla koordinater och dimensioner på bilden.

**Påverkar radbrytning ett Paragraph:s gränser?**

Ja. Om [wrapping](https://reference.aspose.com/slides/sv/net/aspose.slides/textframeformat/wraptext/) är aktiverad i [TextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/textframe/), bryts texten för att passa områdets bredd, vilket ändrar det faktiska gränsvärdet för Paragraph.

**Kan Paragraph‑koordinater på ett pålitligt sätt omvandlas till pixlar i den exporterade bilden?**

Ja. Konvertera punkter till pixlar med: pixels = points × (DPI / 72). Resultatet beror på den DPI som valts för rendering/export.

**Hur får jag de “effektiva” formateringsparametrarna för ett Paragraph, med beaktande av stilarv?**

Använd [effective paragraph formatting data structure](/slides/sv/net/shape-effective-properties/); den returnerar de slutgiltiga sammanslagna värdena för indrag, avstånd, radbrytning, RTL och mer.