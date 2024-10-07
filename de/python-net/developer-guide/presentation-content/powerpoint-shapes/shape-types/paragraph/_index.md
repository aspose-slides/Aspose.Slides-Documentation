---
title: Absatz
type: docs
weight: 60
url: /python-net/paragraph/
keywords: "Absatz, Portion, Absatzkoordinate, Portionskoordinate, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Absatz und Portion in PowerPoint-Präsentation in Python"
---

## **Abrufen von Absatz- und Portionskoordinaten im TextFrame**
Mit Aspose.Slides für Python über .NET können Entwickler jetzt die rechteckigen Koordinaten für Absätze innerhalb der Absatzsammlung eines TextFrames abrufen. Es ermöglicht auch, die Koordinaten der Portion innerhalb der Portionssammlung eines Absatzes zu erhalten. In diesem Thema werden wir mithilfe eines Beispiels demonstrieren, wie die rechteckigen Koordinaten für einen Absatz zusammen mit der Position der Portion innerhalb eines Absatzes abgerufen werden können.

## **Abrufen der rechteckigen Koordinaten des Absatzes**
Die neue Methode **GetRect()** wurde hinzugefügt. Sie ermöglicht es, das Rechteck der Absatzgrenzen zu erhalten.

```py
import aspose.slides as slides

# Erstellen Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Abrufen der Größe des Absatzes und der Portion innerhalb des Tabellenzellen-TextFrames** ##

Um die [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) oder die [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) Größe und Koordinaten in einem Tabellenzellen-TextFrame zu erhalten, können Sie die [IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) und [IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) Methoden verwenden.

Dieser Beispielcode demonstriert die beschriebene Operation:

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