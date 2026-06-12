---
title: Alinea‑grenzen ophalen uit presentaties in .NET
linktitle: Alinea
type: docs
weight: 60
url: /nl/net/paragraph/
keywords:
- alinea‑grenzen
- tekstgedeelte‑grenzen
- alinea‑coördinaat
- gedeelte‑coördinaat
- alinea‑grootte
- tekstgedeelte‑grootte
- tekstkader
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u alinea‑ en tekstgedeelte‑grenzen kunt ophalen in Aspose.Slides voor .NET om de tekstplaatsing in PowerPoint‑presentaties te optimaliseren."
---
## **Overzicht**

Dit artikel legt uit hoe u de grenzen, grootte en coördinaten van alinea&#39;s en tekstgedeelten in Aspose.Slides kunt verkrijgen. Het toont hoe u het rechthoek van een alinea in een `TextFrame` kunt ophalen met `GetRect()`, hoe u de coördinaten van alinea&#39;s en gedeelten binnen een tekstkader van een tabelcel kunt krijgen, en belicht belangrijke details zoals meeteenheden, het effect van tekstomloop op de grenzen, pixelconversie en de effectieve alinea‑opmaakwaarden.

## **Coördinaten van alinea en gedeelte in een TextFrame**

Met Aspose.Slides voor .NET kunnen ontwikkelaars nu de rechthoekige coördinaten van een alinea binnen de alinea‑collectie van een TextFrame ophalen. Het stelt u ook in staat de coördinaten van een gedeelte binnen de gedeelte‑collectie van een alinea te verkrijgen. In dit onderwerp demonstreren we met een voorbeeld hoe u de rechthoekige coördinaten van een alinea kunt krijgen, samen met de positie van een gedeelte binnen een alinea.

## **Rechthoekige coördinaten van een alinea ophalen**

De nieuwe methode **GetRect()** is toegevoegd. Hiermee kunt u het rechthoek van de alinea‑grenzen ophalen.

```c#
// Maak een Presentation‑object aan dat een presentatie‑bestand vertegenwoordigt
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **De grootte van een alinea en gedeelte binnen een TextFrame van een tabelcel ophalen**

Om de grootte en coördinaten van een [Portion](https://reference.aspose.com/slides/nl/net/aspose.slides/portion) of [Paragraph](https://reference.aspose.com/slides/nl/net/aspose.slides/paragraph) in een tekstkader van een tabelcel te verkrijgen, kunt u de methoden [IPortion.GetRect](https://reference.aspose.com/slides/nl/net/aspose.slides/iportion/methods/getrect) en [IParagraph.GetRect](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph/methods/getrect) gebruiken.

Deze voorbeeldcode toont de beschreven bewerking:

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

## **Veelgestelde vragen**

**In welke eenheden worden de coördinaten van een alinea en tekstgedeelten geretourneerd?**

In punten, waarbij 1 inch = 72 punten. Dit geldt voor alle coördinaten en afmetingen op de dia.

**Heeft woordomloop invloed op de grenzen van een alinea?**

Ja. Als [wrapping](https://reference.aspose.com/slides/nl/net/aspose.slides/textframeformat/wraptext/) is ingeschakeld in de [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/), wordt de tekst afgebroken om binnen de breedte van het gebied te passen, waardoor de werkelijke grenzen van de alinea veranderen.

**Kunnen alinea‑coördinaten betrouwbaar naar pixels in de geëxporteerde afbeelding worden omgezet?**

Ja. Converteer punten naar pixels met: pixels = points × (DPI / 72). Het resultaat hangt af van de DPI die gekozen is voor het renderen/exporteren.

**Hoe krijg ik de \"effectieve\" alinea‑opmaakparameters, rekening houdend met de erfenis van stijlen?**

Gebruik de [effective paragraph formatting data structure](/slides/nl/net/shape-effective-properties/); deze retourneert de uiteindelijke geconsolideerde waarden voor inspringingen, afstand, omloop, RTL en meer.