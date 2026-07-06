---
title: Absatzgrenzen aus Präsentationen in Python ermitteln
linktitle: Absatzgrenzen
type: docs
weight: 43
url: /de/python-net/paragraph-bounds/
keywords:
- Absatzgrenzen
- Absatzkoordinate
- Absatzgröße
- Textfeld
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Absatzgrenzen in Aspose.Slides für Python über .NET abrufen, um die Textpositionierung in PowerPoint- und OpenDocument-Präsentationen zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man die Grenzen, Größe und Koordinaten von Absätzen in Aspose.Slides erhält. Er zeigt, wie man ein Absatzrechteck aus einem [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) über [Paragraph.get_rect](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/get_rect/) abruft, wie man Absatzkoordinaten innerhalb eines Tabellenzellen‑TextFrames erhält und hebt wichtige Details hervor, wie Messeinheiten, die Auswirkung von Textumbruch auf die Grenzen, die Pixelumrechnung und effektive Absatzformatierungswerte.

## **Rechteckige Koordinaten eines Absatzes erhalten**

Verwenden Sie [Paragraph.get_rect](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/get_rect/), um das Begrenzungsrechteck eines Absatzes zu erhalten.

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    paragraph = shape.text_frame.paragraphs[0]
    rectangle = paragraph.get_rect()
```

## **Größe eines Absatzes in einem Tabellenzellen‑TextFrame erhalten**

Um die Größe und Koordinaten eines [Paragraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/) in einem Tabellenzellen‑TextFrame zu erhalten, verwenden Sie [Paragraph.get_rect](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/get_rect/). Das zurückgegebene Rechteck ist relativ zum Tabellenzellen‑TextFrame, sodass Sie die Tabellenposition und den Zellenversatz hinzufügen müssen, wenn Sie Folien‑Koordinaten benötigen.

Das folgende Beispiel ermittelt die Absatzgrenzen innerhalb einer Tabellenzelle und zeichnet Rechtecke auf der Folie, um diese Grenzen zu visualisieren:

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

## **FAQ**

**In welchen Einheiten werden die Absatzkoordinaten gemessen?**

Sie werden in Punkten gemessen, wobei 1 Zoll 72 Punkten entspricht. Dies gilt für alle Koordinaten und Abmessungen auf der Folie.

**Beeinflusst der Zeilenumbruch die Grenzen eines Absatzes?**

Ja. Wenn [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/wrap_text/) für das [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) aktiviert ist, bricht der Text um die Breite des Bereichs anzupassen, wodurch sich die tatsächlichen Grenzen des Absatzes ändern.

**Können Absatzkoordinaten zuverlässig in Pixel im exportierten Bild umgerechnet werden?**

Ja. Konvertieren Sie Punkte in Pixel mit folgender Formel: pixels = points x (DPI / 72). Das Ergebnis hängt vom für das Rendern oder den Export gewählten DPI ab.

**Wie kann ich die „effektiven“ Absatzformatierungsparameter erhalten, die die Vererbung von Stilen berücksichtigen?**

Verwenden Sie die [effective paragraph formatting data structure](/slides/de/python-net/shape-effective-properties/); sie gibt die endgültigen konsolidierten Werte für Einzüge, Abstand, Umbruch, RTL und mehr zurück.