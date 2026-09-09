---
title: Absatzgrenzen aus Präsentationen in Python über Java abrufen
linktitle: Absatzgrenzen
type: docs
weight: 43
url: /de/python-java/paragraph-bounds/
keywords:
- Absatzgrenzen
- Absatzkoordinate
- Absatzgröße
- Textrahmen
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Absatzgrenzen in Aspose.Slides für Python über Java abrufen, um die Textpositionierung in PowerPoint-Präsentationen zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man die Grenzen, die Größe und die Koordinaten von Absätzen in Aspose.Slides ermittelt. Er zeigt, wie man ein Absatzrechteck aus einem [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/) über [Paragraph.getRect](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraph/#getRect) abruft, wie man Absatzkoordinaten innerhalb eines TextFrames einer Tabellenzelle erhält und hebt wichtige Details wie Messeinheiten, den Einfluss von Textumbruch auf die Grenzen, die Pixelumrechnung und effektive Absatzformatierungswerte hervor.

## **Rechteckige Koordinaten eines Absatzes abrufen**

Verwenden Sie [Paragraph.getRect](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraph/#getRect), um das begrenzende Rechteck eines Absatzes zu erhalten.

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

## **Größe eines Absatzes in einem TextFrame einer Tabellenzelle ermitteln**

Um die Größe und die Koordinaten eines [Paragraph](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraph/) in einem TextFrame einer Tabellenzelle zu erhalten, verwenden Sie [Paragraph.getRect](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraph/#getRect). Das zurückgegebene Rechteck ist relativ zum TextFrame der Tabellenzelle, sodass Sie die Tabellenposition und den Zellenoffset hinzufügen müssen, wenn Sie Folien‑bezogene Koordinaten benötigen.

Das folgende Beispiel ermittelt die Absatzgrenzen innerhalb einer Tabellenzelle und zeichnet Rechtecke auf der Folie, um diese Grenzen zu visualisieren:

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

**In welchen Einheiten werden Absatzkoordinaten gemessen?**

Sie werden in Punkten gemessen, wobei 1 Zoll 72 Punkten entspricht. Dies gilt für alle Koordinaten und Abmessungen auf der Folie.

**Wirkt sich der Textumbruch auf die Grenzen eines Absatzes aus?**

Ja. Wenn [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setWrapText) für den [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/) aktiviert ist, wird der Text umbrochen, um die Breite des Bereichs zu füllen, wodurch sich die tatsächlichen Grenzen des Absatzes ändern.

**Können Absatzkoordinaten zuverlässig in Pixel im exportierten Bild umgerechnet werden?**

Ja. Punkte können mit folgender Formel in Pixel umgerechnet werden: pixel = punkte × (DPI / 72). Das Ergebnis hängt vom für die Darstellung oder den Export gewählten DPI ab.

**Wie erhalte ich die „effektiven“ Absatzformatierungsparameter unter Berücksichtigung der Stilvererbung?**

Verwenden Sie die [effective paragraph formatting data structure](/slides/de/python-java/shape-effective-properties/); sie gibt die endgültigen zusammengefassten Werte für Einzüge, Abstand, Umbruch, RTL und mehr zurück.