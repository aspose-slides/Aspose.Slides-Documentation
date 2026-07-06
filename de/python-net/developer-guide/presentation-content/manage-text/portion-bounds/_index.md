---
title: Textportion-Grenzen aus Präsentationen in Python ermitteln
linktitle: Portion-Grenzen
type: docs
weight: 47
url: /de/python-net/portion-bounds/
keywords:
- Grenzen von Textportionen
- Textportion
- Textteil
- Textkoordinaten
- Textposition
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Python via .NET die Grenzen von Textportionen in PowerPoint- und OpenDocument‑Präsentationen abrufen."
---
## **Überblick**

Eine Textportion stellt ein bestimmtes Fragment von Text innerhalb eines Absatzes dar und ermöglicht es Ihnen, mit diesem Fragment unabhängig vom umgebenden Inhalt zu arbeiten. In Aspose.Slides können Portionen verwendet werden, wenn Sie die Begrenzungen eines Textfragments abrufen, Formatierungen nur auf einen Teil eines Absatzes anwenden oder das Textverhalten auf einer detaillierteren Ebene steuern müssen.

Dieser Artikel zeigt, wie Sie das Begrenzungsrechteck einer Portion mittels [Portion.get_rect](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/get_rect/) erhalten. Er zeigt außerdem, wie Sie die Koordinaten des Beginns einer Portion mit [Portion.get_coordinates](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/get_coordinates/) ermitteln. Darüber hinaus werden typische Szenarien im Zusammenhang mit Portionen hervorgehoben, wie das Anwenden eines Hyperlinks auf ein einzelnes Textfragment, das Verständnis, wie Formatierungen über Portion, Absatz, Textfeld und Themenvererbung aufgelöst werden, und der Umgang mit Fällen, in denen eine angegebene Schriftart nicht verfügbar ist.

## **Grenzen einer Textportion ermitteln**

Verwenden Sie [Portion.get_rect](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/get_rect/) um das Begrenzungsrechteck einer Textportion abzurufen:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **Koordinaten einer Textportion ermitteln**

Verwenden Sie [Portion.get_coordinates](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/get_coordinates/) um die Koordinaten des Beginns einer Textportion zu erhalten:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **FAQ**

**Kann ich einen Hyperlink nur auf einen Teil des Textes innerhalb eines einzelnen Absatzes anwenden?**

Ja, Sie können einem einzelnen Portion einen [Hyperlink zuweisen](/slides/de/python-net/manage-hyperlinks/); nur dieses Fragment wird anklickbar sein, nicht der gesamte Absatz.

**Wie funktioniert die Stilvererbung: Was überschreibt eine Portion und was wird von einem Absatz oder Textfeld übernommen?**

Eigenschaften auf Portionsebene haben die höchste Priorität. Wenn eine Eigenschaft nicht auf der [Portion](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/) festgelegt ist, übernimmt Aspose.Slides sie vom [Paragraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/). Ist sie dort ebenfalls nicht gesetzt, verwendet Aspose.Slides den Stil des [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) oder des [theme](https://reference.aspose.com/slides/de/python-net/aspose.slides.theme/theme/).

**Was passiert, wenn die für eine Portion angegebene Schriftart auf dem Zielcomputer oder Server fehlt?**

[Regeln zur Schriftartsubstitution](/slides/de/python-net/font-selection-sequence/) gelten. Der Text kann umfließen: Metriken, Silbentrennung und Breite können sich ändern, was für eine präzise Positionierung wichtig ist.

**Kann ich die Fülltransparenz oder einen Farbverlauf des Textes auf Portionsebene unabhängig vom Rest des Absatzes festlegen?**

Ja, Textfarbe, Füllung und Transparenz auf der [Portion](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/) Ebene können von benachbarten Fragmenten abweichen.