---
title: Absatzgrenzen aus Präsentationen in Python ermitteln
linktitle: Absatz
type: docs
weight: 60
url: /de/python-net/paragraph/
keywords:
- Absatzgrenzen
- Textabschnittsgrenzen
- Absatzkoordinate
- Portionskoordinate
- Absatzgröße
- Textabschnittsgröße
- Textfeld
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie in Aspose.Slides für Python via .NET Absatz- und Textportionen-Grenzen abrufen, um die Textpositionierung in PowerPoint- und OpenDocument-Präsentationen zu optimieren."
---

## **Koordinaten von Absatz und Portion in TextFrame erhalten**
Mit Aspose.Slides für Python via .NET können Entwickler jetzt die rechteckigen Koordinaten für einen Paragraphen innerhalb der Paragraphensammlung eines TextFrames abrufen. Außerdem können Sie die Koordinaten einer Portion innerhalb der Portionssammlung eines Paragraphen erhalten. In diesem Thema demonstrieren wir anhand eines Beispiels, wie man die rechteckigen Koordinaten für einen Paragraphen zusammen mit der Position einer Portion innerhalb eines Paragraphen erhält.

## **Rechteckige Koordinaten eines Absatzes erhalten**
Die neue Methode **GetRect()** wurde hinzugefügt. Sie ermöglicht das Abrufen des Begrenzungsrechtecks eines Paragraphen.
```py
import aspose.slides as slides

# Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```


## **Größe von Absatz und Portion innerhalb des TextFrames einer Tabellenzelle erhalten** ##

Um die Größe und die Koordinaten von [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) oder [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) in einem TextFrame einer Tabellenzelle zu erhalten, können Sie die Methoden [IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) und [IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) verwenden.

Dieses Beispielcode demonstriert die beschriebene Operation:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "source.pptx") as pres:
    tbl = pres.slides[0].shapes[0]

    cell = tbl.rows[1][1]


    x = tbl.X + tbl.rows[1][1].offset_x
    y = tbl.Y + tbl.rows[1][1].offset_y

    for para in cell.text_frame.paragraphs:
        if para.text == "":
            continue

        rect = para.get_rect()
        shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                rect.x + x, rect.y + y, rect.width, rect.height)

        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID

        for portion in para.portions:
            if "0" in portion.text:
                rect = portion.get_rect()
                shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                        rect.x + x, rect.y + y, rect.width, rect.height)

                shape.fill_format.fill_type = slides.FillType.NO_FILL
```


## **FAQ**

**In welchen Einheiten werden die Koordinaten eines Absatzes und Textportionen zurückgegeben?**

In Punkt, wobei 1 Zoll = 72 Punkt entspricht. Dies gilt für alle Koordinaten und Abmessungen auf der Folie.

**Beeinflusst das Textumbruch die Begrenzungen eines Absatzes?**

Ja. Wenn [wrapping](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) im [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) aktiviert ist, bricht der Text um, um die Breite des Bereichs zu füllen, wodurch sich die tatsächlichen Begrenzungen des Absatzes ändern.

**Können Absatzkoordinaten zuverlässig in Pixel im exportierten Bild umgewandelt werden?**

Ja. Konvertiere Punkt in Pixel mithilfe von: pixels = points × (DPI / 72). Das Ergebnis hängt vom für das Rendern/Exportieren gewählten DPI ab.

**Wie erhalte ich die "effektiven" Absatzformatierungsparameter unter Berücksichtigung der Stilvererbung?**

Verwende die [effective paragraph formatting data structure](/slides/de/python-net/shape-effective-properties/); sie gibt die endgültigen konsolidierten Werte für Einzüge, Abstand, Umbruch, RTL und mehr zurück.