---
title: Hämta styckesgränser från presentationer i Python via Java
linktitle: Styckesgränser
type: docs
weight: 43
url: /sv/python-java/paragraph-bounds/
keywords:
- styckesgränser
- styckeskoordinat
- styckesstorlek
- textram
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du hämtar styckesgränser i Aspose.Slides för Python via Java för att optimera textpositionering i PowerPoint-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur man får gränserna, storleken och koordinaterna för stycken i Aspose.Slides. Den visar hur man hämtar en styckesrektangel från en [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/) genom att använda [Paragraph.getRect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/#getRect), hur man får styckeskoordinater inom ett tabellcells‑textfält och lyfter fram viktiga detaljer såsom mätenheter, hur textbrytning påverkar gränserna, pixelkonvertering och effektiva styckeformateringsvärden.

## **Hämta rektangulära koordinater för ett stycke**

Använd [Paragraph.getRect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/#getRect) för att hämta det omgivande rektangeln för ett stycke.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    rectangle = paragraph.getRect()
finally:
    presentation.dispose()
```

## **Hämta storleken på ett stycke i ett tabellcells‑textfält**

För att få storleken och koordinaterna för ett [Paragraph](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/) i ett tabellcells‑textfält, använd [Paragraph.getRect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/#getRect). Den returnerade rektangeln är relativ till tabellcells‑textfältet, så lägg till tabellens position och cellens offset när du behöver koordinater på bildnivå.

Följande exempel hämtar styckesgränserna i en tabellcell och ritar rektanglar på bilden för att visualisera dessa gränser:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation("source.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)
    cell = table.getRows().get_Item(1).get_Item(1)

    cell_x = table.getX() + cell.getOffsetX()
    cell_y = table.getY() + cell.getOffsetY()

    for paragraph in cell.getTextFrame().getParagraphs():
        if not paragraph.getText():
            continue

        paragraph_rectangle = paragraph.getRect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, paragraph_rectangle_x, paragraph_rectangle_y, paragraph_rectangle.width, paragraph_rectangle.height)

        paragraph_bounds_shape.getFillFormat().setFillType(FillType.NoFill)
        paragraph_bounds_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
        paragraph_bounds_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**I vilka enheter mäts styckeskoordinater?**

De mäts i punkter, där 1 tum motsvarar 72 punkter. Detta gäller för alla koordinater och dimensioner på bilden.

**Påverkar radbrytning ett styckes gränser?**

Ja. Om [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#setWrapText) är aktiverat för [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/), bryts texten för att passa områdets bredd, vilket ändrar styckets faktiska gränser.

**Kan styckeskoordinater på ett pålitligt sätt mappas till pixlar i den exporterade bilden?**

Ja. Konvertera punkter till pixlar med formeln: pixlar = punkter x (DPI / 72). Resultatet beror på den DPI som valts för rendering eller export.

**Hur får jag de "effektiva" styckeformateringsparametrarna, med hänsyn till stilärvning?**

Använd [effective paragraph formatting data structure](/slides/sv/python-java/shape-effective-properties/); den returnerar de slutgiltiga sammanslagna värdena för indrag, avstånd, radbrytning, RTL och mer.