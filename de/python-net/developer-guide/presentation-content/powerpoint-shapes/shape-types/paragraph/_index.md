---
title: Absätzebegrenzungen aus Präsentationen in Python abrufen
linktitle: Absatz
type: docs
weight: 60
url: /de/python-net/paragraph/
keywords:
- Absatzbegrenzungen
- Textabschnittsbegrenzungen
- Absatzkoordinaten
- Abschnittskoordinaten
- Absatzgröße
- Textabschnittsgröße
- Textfeld
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Absatz‑ und Textabschnittsbegrenzungen in Aspose.Slides für Python via .NET ermitteln, um die Textpositionierung in PowerPoint‑ und OpenDocument‑Präsentationen zu optimieren."
---

## **Absatz‑ und Abschnittskoordinaten im Textfeld ermitteln**
Mit Aspose.Slides für Python via .NET können Entwickler nun die rechteckigen Koordinaten für einen Absatz innerhalb der Absatzsammlung eines Textfeldes erhalten. Außerdem können Sie die Koordinaten eines Abschnitts innerhalb der Abschnittssammlung eines Absatzes ermitteln. In diesem Thema demonstrieren wir anhand eines Beispiels, wie man die rechteckigen Koordinaten für einen Absatz zusammen mit der Position eines Abschnitts innerhalb dieses Absatzes erhält.

## **Rechteckige Koordinaten eines Absatzes erhalten**
Die neue Methode **GetRect()** wurde hinzugefügt. Sie ermöglicht das Abrufen des Begrenzungsrechtecks eines Absatzes.

```py
import aspose.slides as slides

# Instanziieren eines Presentation‑Objekts, das eine Präsentationsdatei darstellt
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Größe von Absatz und Abschnitt in einem Textfeld einer Tabellenzelle ermitteln** ##

Um die Größe und Koordinaten eines [Abschnitts](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) oder eines [Absatzes](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) in einem Textfeld einer Tabellenzelle zu erhalten, können Sie die Methoden [IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) und [IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) verwenden.

Dieser Beispielcode demonstriert die beschriebene Vorgehensweise:

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

**In welchen Einheiten werden die Koordinaten für einen Absatz und Textabschnitte zurückgegeben?**

In Punkten, wobei 1 Zoll = 72 Punkte entspricht. Dies gilt für alle Koordinaten und Maße auf der Folie.

**Beeinflusst das Zeilenumbruch‑Verhalten die Begrenzungen eines Absatzes?**

Ja. Wenn das [Umbruch‑Verhalten](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) im [Textfeld](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) aktiviert ist, wird der Text umbrochen, um die Breite des Bereichs zu füllen, wodurch sich die tatsächlichen Begrenzungen des Absatzes ändern.

**Können Absatzkoordinaten zuverlässig in Pixel des exportierten Bildes umgerechnet werden?**

Ja. Punkte in Pixel umrechnen mit: pixels = points × (DPI / 72). Das Ergebnis hängt vom für die Darstellung/den Export gewählten DPI ab.

**Wie erhalte ich die „effektiven“ Absatzformatierungsparameter unter Berücksichtigung von Stilvererbung?**

Verwenden Sie die [effektive Absatzformatierungs‑Datenstruktur](/slides/de/python-net/shape-effective-properties/); sie gibt die letztendlichen konsolidierten Werte für Einzüge, Abstand, Umbruch, Rechts‑nach‑Links‑Richtung und mehr zurück.