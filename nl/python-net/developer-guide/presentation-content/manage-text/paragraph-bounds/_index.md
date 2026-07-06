---
title: Alinea-grenzen ophalen uit presentaties in Python
linktitle: Alinea-grenzen
type: docs
weight: 43
url: /nl/python-net/paragraph-bounds/
keywords:
- alinea-grenzen
- alinea-coördinaat
- alinea-grootte
- tekstframe
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u alinea-grenzen kunt ophalen in Aspose.Slides voor Python via .NET om de tekstopstelling in PowerPoint- en OpenDocument-presentaties te optimaliseren."
---
## **Overzicht**

Dit artikel legt uit hoe u de grenzen, grootte en coördinaten van alinea's in Aspose.Slides kunt verkrijgen. Het laat zien hoe u een alinea‑rechthoek kunt ophalen uit een [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) met behulp van [Paragraph.get_rect](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/get_rect/), hoe u de coördinaten van een alinea binnen een tabelcel‑tekstframe kunt krijgen, en benadrukt belangrijke details zoals meeteenheden, het effect van tekstomloop op de grenzen, pixelconversie en effectieve alinea‑opmaakwaarden.

## **Rectangulaire coördinaten van een alinea**

Gebruik [Paragraph.get_rect](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/get_rect/) om de begrenzende rechthoek van een alinea op te halen.

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    paragraph = shape.text_frame.paragraphs[0]
    rectangle = paragraph.get_rect()
```

## **Grootte van een alinea binnen een tabelcel‑TextFrame ophalen**

Om de grootte en coördinaten van een [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/) in een tabelcel‑tekstframe te verkrijgen, gebruikt u [Paragraph.get_rect](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/get_rect/). De geretourneerde rechthoek is relatief ten opzichte van het tabelcel‑tekstframe, dus voeg de tabelpositie en cel‑offset toe wanneer u coördinaten op dia‑niveau nodig heeft.

Het volgende voorbeeld haalt de alinea‑grenzen op binnen een tabelcel en tekent rechthoeken op de dia om die grenzen te visualiseren:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("source.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]
    cell = table.rows[1][1]

    cell_x = table.x + cell.offset_x
    cell_y = table.y + cell.offset_y

    for paragraph in cell.text_frame.paragraphs:
        if paragraph.text == "":
            continue

        paragraph_rectangle = paragraph.get_rect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.shapes.add_auto_shape(
            slides.ShapeType.RECTANGLE,
            paragraph_rectangle_x,
            paragraph_rectangle_y,
            paragraph_rectangle.width,
            paragraph_rectangle.height)

        paragraph_bounds_shape.fill_format.fill_type = slides.FillType.NO_FILL
        paragraph_bounds_shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        paragraph_bounds_shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Veelgestelde vragen**

**In welke eenheden worden alinea‑coördinaten gemeten?**

Ze worden gemeten in points, waarbij 1 inch gelijk is aan 72 points. Dit geldt voor alle coördinaten en afmetingen op de dia.

**Heeft woordomloop invloed op de grenzen van een alinea?**

Ja. Als [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/wrap_text/) is ingeschakeld voor het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/), wordt de tekst afgebroken om binnen de breedte van het gebied te passen, waardoor de werkelijke grenzen van de alinea veranderen.

**Kunnen alinea‑coördinaten betrouwbaar naar pixels worden omgezet in de geëxporteerde afbeelding?**

Ja. Converteer points naar pixels met deze formule: pixels = points × (DPI / 72). Het resultaat hangt af van de DPI die gekozen is voor het renderen of exporteren.

**Hoe haal ik de "effectieve" alinea‑opmaakparameters op, rekening houdend met erfelijkheid van stijlen?**

Gebruik de [effective paragraph formatting data structure](/slides/nl/python-net/shape-effective-properties/); deze retourneert de uiteindelijke samengevoegde waarden voor inspringingen, spatiëring, omloop, RTL en meer.