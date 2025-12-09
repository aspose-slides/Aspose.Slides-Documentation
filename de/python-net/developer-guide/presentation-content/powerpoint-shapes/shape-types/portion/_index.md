---
title: Textabschnitte in Präsentationen mit Python verwalten
linktitle: Textabschnitt
type: docs
weight: 70
url: /de/python-net/portion/
keywords:
- Textabschnitt
- Textteil
- Textkoordinaten
- Textposition
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Textabschnitte in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python über .NET verwalten, um Leistung und Anpassungsmöglichkeiten zu verbessern."
---

## **Koordinaten von Textabschnitten abrufen**

Die Methode [get_coordinates](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_coordinates/) wurde zur Klasse [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) hinzugefügt, die das Abrufen der Koordinaten von Textabschnitten ermöglicht:
```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```


## **FAQ**

**Kann ich einem einzelnen Teil des Textes innerhalb eines Absatzes einen Hyperlink zuweisen?**

Ja, Sie können einem einzelnen Abschnitt einen [Hyperlink zuweisen](/slides/de/python-net/manage-hyperlinks/); nur dieses Fragment ist anklickbar, nicht der gesamte Absatz.

**Wie funktioniert die Stilvererbung: Was überschreibt ein Portion und was wird von Paragraph/TextFrame übernommen?**

Eigenschaften auf Portion‑Ebene haben die höchste Priorität. Wenn eine Eigenschaft nicht auf der [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) festgelegt ist, übernimmt die Engine sie vom [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/); ist sie dort ebenfalls nicht gesetzt, wird sie vom [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) oder vom [Theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/theme/)-Stil übernommen.

**Was passiert, wenn die für eine Portion angegebene Schriftart auf dem Zielrechner/Server fehlt?**

[Font substitution rules](/slides/de/python-net/font-selection-sequence/) werden angewendet. Der Text kann umfließen: Metriken, Silbentrennung und Breite können sich ändern, was für präzises Positionieren wichtig ist.

**Kann ich für einen Portion einen eigenen Textfüllungs‑Transparenzwert oder Farbverlauf festlegen, unabhängig vom Rest des Absatzes?**

Ja, Textfarbe, Füllung und Transparenz auf der [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)-Ebene können von benachbarten Fragmenten abweichen.