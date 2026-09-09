---
title: Haal alinea-grenzen op uit presentaties in Python via Java
linktitle: Alinea-grenzen
type: docs
weight: 43
url: /nl/python-java/paragraph-bounds/
keywords:
- alinea-grenzen
- alinea-coördinaat
- alinea-grootte
- tekstkader
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u alinea-grenzen kunt ophalen in Aspose.Slides voor Python via Java om de tekstpositionering in PowerPoint-presentaties te optimaliseren."
---
## **Overzicht**

Dit artikel legt uit hoe u de grenzen, grootte en coördinaten van alinea's in Aspose.Slides kunt ophalen. Het laat zien hoe u een alinea‑rectangle kunt ophalen uit een [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/) met behulp van [Paragraph.getRect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/#getRect), hoe u de alinea‑coördinaten binnen een tabelcel‑tekstframe kunt krijgen, en belicht belangrijke details zoals meeteenheden, het effect van tekstomslag op de grenzen, pixelconversie en effectieve alinea‑opmaakwaarden.

## **Haal rechthoekige coördinaten van een alinea op**

Gebruik [Paragraph.getRect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/#getRect) om de begrenzende rechthoek van een alinea op te halen.

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

## **Haal de grootte van een alinea op binnen een tabelcel‑tekstframe**

Om de grootte en coördinaten van een [Paragraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/) in een tabelcel‑tekstframe te krijgen, gebruikt u [Paragraph.getRect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/#getRect). De geretourneerde rechthoek is relatief ten opzichte van het tabelcel‑tekstframe, dus voeg de tabelpositie en celoffset toe wanneer u coördinaten op dia‑niveau nodig hebt.

Het volgende voorbeeld haalt de alinea‑grenzen op binnen een tabelcel en tekent rechthoeken op de dia om die grenzen te visualiseren:

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

## **Veelgestelde vragen**

**In welke eenheden worden de alinea‑coördinaten gemeten?**

Ze worden gemeten in punten, waarbij 1 inch gelijk is aan 72 punten. Dit geldt voor alle coördinaten en afmetingen op de dia.

**Heeft tekstomslag invloed op de grenzen van een alinea?**

Ja. Als [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#setWrapText) is ingeschakeld voor het [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/), breekt de tekst om binnen de breedte van het gebied, waardoor de werkelijke grenzen van de alinea wijzigen.

**Kunnen alinea‑coördinaten betrouwbaar worden omgezet naar pixels in de geëxporteerde afbeelding?**

Ja. Zet punten om naar pixels met deze formule: pixels = points × (DPI / 72). Het resultaat hangt af van de DPI die is gekozen voor renderen of exporteren.

**Hoe krijg ik de “effectieve” alinea‑opmaakparameters, rekening houdend met stijl‑overerving?**

Gebruik de [effective paragraph formatting data structure](/slides/nl/python-java/shape-effective-properties/); deze geeft de uiteindelijke geconsolideerde waarden terug voor inspringingen, spatiëring, omhulling, RTL en meer.