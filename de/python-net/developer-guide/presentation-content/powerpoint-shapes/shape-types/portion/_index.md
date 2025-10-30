---
title: Verwalten von Textabschnitten in Präsentationen mit Python
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
description: "Erfahren Sie, wie Sie Textabschnitte in PowerPoint- und OpenDocument‑Präsentationen mit Aspose.Slides für Python via .NET verwalten, um Leistung und Anpassungsfähigkeit zu steigern."
---

## **Koordinaten von Textabschnitten abrufen**

Die Methode `get_coordinates` wurde zur Klasse `Portion` hinzugefügt, die das Abrufen der Koordinaten von Textabschnitten ermöglicht:

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

**Kann ich einen Hyperlink nur auf einen Teil des Textes innerhalb eines einzelnen Absatzes anwenden?**

Ja, Sie können einen [Hyperlink zuweisen](/slides/de/python-net/manage-hyperlinks/) zu einem einzelnen Abschnitt; nur dieses Fragment ist anklickbar, nicht der gesamte Absatz.

**Wie funktioniert die Stilvererbung: Was überschreibt ein Portion und was wird vom Paragraph/TextFrame übernommen?**

Eigenschaften auf Portion‑Ebene haben die höchste Priorität. Wenn eine Eigenschaft nicht im `Portion` festgelegt ist, übernimmt die Engine sie vom `Paragraph`; ist sie dort ebenfalls nicht gesetzt, wird sie vom `TextFrame` oder vom `theme`‑Stil übernommen.

**Was passiert, wenn die für einen Portion angegebene Schriftart auf dem Zielrechner/Server fehlt?**

Die Regeln für die Schriftart‑Substitution werden angewendet. Der Text kann umfließen: Metriken, Silbentrennung und Breite können sich ändern, was für eine präzise Positionierung wichtig ist.

**Kann ich für einen Portion eine eigene Text‑Füll‑Transparenz oder einen Farbverlauf festlegen, unabhängig vom Rest des Absatzes?**

Ja, Textfarbe, Füllung und Transparenz auf `Portion`‑Ebene können von benachbarten Fragmenten abweichen.