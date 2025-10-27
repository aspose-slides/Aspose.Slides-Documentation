---
title: Absatzgrenzen aus Präsentationen in Python ermitteln
linktitle: Absatz
type: docs
weight: 60
url: /de/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-types/paragraph/
keywords:
- Absatzgrenzen
- Textabschnittsgrenzen
- Absatzkoordinate
- Abschnittskoordinate
- Absatzgröße
- Textabschnittsgröße
- Textfeld
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie in Aspose.Slides für Python via .NET die Grenzen von Absätzen und Textabschnitten ermitteln, um die Textpositionierung in PowerPoint- und OpenDocument-Präsentationen zu optimieren."
---

## **Absatz- und Abschnittskoordinaten im TextFrame ermitteln**
Mit Aspose.Slides für Python via .NET können Entwickler nun die rechteckigen Koordinaten für einen Absatz innerhalb der Absatzsammlung eines TextFrames erhalten. Außerdem können Sie die Koordinaten eines Abschnitts innerhalb der Abschnittssammlung eines Absatzes abfragen. In diesem Thema zeigen wir anhand eines Beispiels, wie man die rechteckigen Koordinaten eines Absatzes sowie die Position eines Abschnitts innerhalb eines Absatzes ermittelt.

## **Rechteckige Koordinaten eines Absatzes ermitteln**
Die neue Methode **GetRect()** wurde hinzugefügt. Sie ermöglicht das Abrufen des Begrenzungsrechtecks eines Absatzes.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Größe von Absatz und Abschnitt innerhalb eines TextFrames in einer Tabellenzelle ermitteln** ##

Um die Größe und die Koordinaten von [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) oder [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) in einem TextFrame einer Tabellenzelle zu erhalten, können Sie die Methoden [IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) und [IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) verwenden.

Dieses Beispiel demonstriert die beschriebene Vorgehensweise:

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

**In welchen Einheiten werden die Koordinaten eines Absatzes und von Textabschnitten zurückgegeben?**

In Punkten, wobei 1 Zoll = 72 Punkte. Dies gilt für alle Koordinaten und Abmessungen auf der Folie.

**Beeinflusst Wortumbruch die Begrenzungen eines Absatzes?**

Ja. Wenn das [wrapping](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) im [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) aktiviert ist, wird der Text umgebrochen, um die Breite des Bereichs zu füllen, wodurch sich die tatsächlichen Begrenzungen des Absatzes ändern.

**Können Absatzkoordinaten zuverlässig in Pixel im exportierten Bild umgerechnet werden?**

Ja. Konvertieren Sie Punkte in Pixel mittels: pixels = points × (DPI / 72). Das Ergebnis hängt vom für das Rendern/Exportieren gewählten DPI ab.

**Wie erhalte ich die "effektiven" Absatzformatierungsparameter unter Berücksichtigung der Stilvererbung?**

Verwenden Sie die [effective paragraph formatting data structure](/slides/de/python-net/shape-effective-properties/); sie liefert die endgültigen konsolidierten Werte für Einzüge, Abstand, Umbruch, Rechts-nach-Links und mehr.