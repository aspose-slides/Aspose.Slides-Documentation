---
title: Abrufen von Absatzgrenzen aus Präsentationen in Python
linktitle: Absatz
type: docs
weight: 60
url: /de/python-net/paragraph/
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
description: "Erfahren Sie, wie Sie Absatz- und Textabschnittsgrenzen in Aspose.Slides für Python via .NET abrufen, um die Textpositionierung in PowerPoint- und OpenDocument-Präsentationen zu optimieren."
---

## **Absatz- und Abschnittskoordinaten im Textfeld erhalten**
Mit Aspose.Slides für Python via .NET können Entwickler jetzt die rechteckigen Koordinaten für einen Absatz innerhalb der Absatzsammlung eines Textfelds erhalten. Außerdem lässt sich die Position eines Abschnitts innerhalb der Abschnittssammlung eines Absatzes bestimmen. In diesem Thema demonstrieren wir anhand eines Beispiels, wie man die rechteckigen Koordinaten für einen Absatz zusammen mit der Position des Abschnitts innerhalb des Absatzes ermittelt.

## **Rechteckige Koordinaten des Absatzes erhalten**
Die neue Methode **GetRect()** wurde hinzugefügt. Sie ermöglicht das Abrufen des Absatzgrenzen-Rechtecks.

```py
import aspose.slides as slides

# Instanziiere ein Presentation-Objekt, das eine Präsentationsdatei darstellt
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Größe von Absatz und Abschnitt innerhalb eines Tabellenzellen-Textfeldes erhalten** ##

Um die [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)‑ oder [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)-Größe und -Koordinaten in einem Tabellenzellen‑Textfeld zu erhalten, können Sie die Methoden [IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) und [IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) verwenden.

Dieses Beispiel demonstriert die beschriebene Vorgehensweise:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziiere ein Presentation-Objekt, das eine Präsentationsdatei darstellt
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

In Punkten, wobei 1 Zoll = 72 Punkte entspricht. Dies gilt für alle Koordinaten und Abmessungen auf der Folie.

**Wirkt sich das Zeilenumbruchverhalten auf die Grenzen eines Absatzes aus?**

Ja. Wenn das Zeilenumbruch‑Verhalten im [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) aktiviert ist, bricht der Text um, um die Breite des Bereichs anzupassen, wodurch sich die tatsächlichen Grenzen des Absatzes ändern.

**Können Absatzkoordinaten zuverlässig in Pixel des exportierten Bildes umgerechnet werden?**

Ja. Konvertiere Punkte in Pixel mit: pixels = points × (DPI / 72). Das Ergebnis hängt vom für die Darstellung/den Export gewählten DPI ab.

**Wie erhalte ich die „effektiven“ Absatzformatierungsparameter unter Berücksichtigung der Stilvererbung?**

Verwende die Datenstruktur für effektive Absatzformatierung; sie gibt die endgültigen zusammengefassten Werte für Einzüge, Abstand, Zeilenumbruch, Rechts‑nach‑Links und mehr zurück.