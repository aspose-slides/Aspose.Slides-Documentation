---
title: Hämta styckesgränser från presentationer i Python
linktitle: Styckesgränser
type: docs
weight: 43
url: /sv/python-net/paragraph-bounds/
keywords:
- styckesgränser
- styckeskoordinat
- styckestorlek
- textram
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du hämtar styckesgränser i Aspose.Slides för Python via .NET för att optimera textpositionering i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Denna artikel förklarar hur man får gränserna, storleken och koordinaterna för stycken i Aspose.Slides. Den visar hur man hämtar en styckerektangel från en [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) genom att använda [Paragraph.get_rect](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/get_rect/), hur man får styckekoordinater i en tabellcells textram, och lyfter fram viktiga detaljer som mätenheter, effekten av textbrytning på gränser, pixelkonvertering och effektiva styckeformatvärden.

## **Hämta rektangulära koordinater för ett stycke**

Använd [Paragraph.get_rect](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/get_rect/) för att få den omgivande rektangeln för ett stycke.

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    paragraph = shape.text_frame.paragraphs[0]
    rectangle = paragraph.get_rect()
```

## **Hämta storleken på ett stycke i en tabellcells TextFrame**

För att få storlek och koordinater för ett [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/) i en tabellcells textram, använd [Paragraph.get_rect](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/get_rect/). Den returnerade rektangeln är relativ till tabellcellens textram, så lägg till tabellens position och cellens förskjutning när du behöver koordinater på bildnivå.

Följande exempel hämtar styckets gränser i en tabellcell och ritar rektanglar på bilden för att visualisera dessa gränser:

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

## **Vanliga frågor**

**I vilka enheter mäts styckekoordinater?**

De mäts i punkter, där 1 tum motsvarar 72 punkter. Detta gäller för alla koordinater och mått på bilden.

**Påverkar ordbrytning ett styckes gränser?**

Ja. Om [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/wrap_text/) är aktiverat för [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/), bryts texten för att passa områdets bredd, vilket förändrar styckets faktiska gränser.

**Kan styckekoordinater på ett tillförlitligt sätt mappas till pixlar i den exporterade bilden?**

Ja. Konvertera punkter till pixlar med denna formel: pixlar = punkter x (DPI / 72). Resultatet beror på vilken DPI som valts för renderingen eller exporten.

**Hur får jag de "effektiva" styckeformatparametrarna med hänsyn till stilarv?**

Använd [effective paragraph formatting data structure](/slides/sv/python-net/shape-effective-properties/); den returnerar de slutgiltiga konsoliderade värdena för indrag, avstånd, radbrytning, RTL och mer.