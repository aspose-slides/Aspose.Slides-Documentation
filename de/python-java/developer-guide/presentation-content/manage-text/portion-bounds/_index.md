---
title: Textabschnittsbegrenzungen aus Präsentationen in Python über Java abrufen
linktitle: Abschnittsbegrenzungen
type: docs
weight: 47
url: /de/python-java/portion-bounds/
keywords:
- Textabschnittsbegrenzungen
- Textabschnitt
- Textteil
- Textkoordinaten
- Textposition
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Textabschnittsbegrenzungen in PowerPoint‑Präsentationen mit Aspose.Slides für Python über Java abrufen."
---
## **Übersicht**

Ein Textabschnitt stellt ein bestimmtes Fragment von Text innerhalb eines Absatzes dar und ermöglicht es Ihnen, mit diesem Fragment unabhängig vom umgebenden Inhalt zu arbeiten. In Aspose.Slides können Abschnitte verwendet werden, wenn Sie die Begrenzungsrechtecke eines Textfragments abrufen, Formatierungen nur für einen Teil eines Absatzes anwenden oder das Textverhalten auf einer detaillierteren Ebene steuern müssen.

Dieser Artikel zeigt, wie man das Begrenzungsrechteck eines Abschnitts mit [Portion.getRect](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/#getRect) erhält. Er zeigt außerdem, wie man die Koordinaten des Beginns eines Abschnitts mit [Portion.getCoordinates](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/#getCoordinates) ermittelt. Zusätzlich werden gängige Szenarien im Zusammenhang mit Abschnitten hervorgehoben, z. B. das Hinzufügen eines Hyperlinks zu einem einzelnen Textfragment, das Verständnis der Formatauflösung über Abschnitt-, Absatz-, TextFrame- und Theme-Vererbung sowie der Umgang mit Fällen, in denen eine angegebene Schriftart nicht verfügbar ist.

## **Begrenzungsrechteck eines Textabschnitts abrufen**

Verwenden Sie [Portion.getRect](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/#getRect), um das Begrenzungsrechteck eines Textabschnitts abzurufen:

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

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **Koordinaten eines Textabschnitts abrufen**

Verwenden Sie [Portion.getCoordinates](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/#getCoordinates), um die Koordinaten des Beginns eines Textabschnitts abzurufen:

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

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich einen Hyperlink nur auf einen Teil des Textes innerhalb eines einzelnen Absatzes anwenden?**

Ja, Sie können [einen Hyperlink zuweisen](/slides/de/python-java/manage-hyperlinks/) zu einem einzelnen Abschnitt; nur dieses Fragment wird anklickbar sein, nicht der gesamte Absatz.

**Wie funktioniert die Stilvererbung: Was überschreibt ein Abschnitt und was wird von einem Absatz oder TextFrame übernommen?**

Eigenschaften auf Abschnittsebene haben die höchste Priorität. Wenn eine Eigenschaft nicht auf dem [Portion](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/) festgelegt ist, übernimmt Aspose.Slides sie vom [Paragraph](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraph/). Ist sie dort ebenfalls nicht gesetzt, verwendet Aspose.Slides den Stil des [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/) oder des [theme](https://reference.aspose.com/slides/de/python-java/aspose.slides/theme/).

**Was passiert, wenn die für einen Abschnitt angegebene Schriftart auf der Zielmaschine oder dem Server fehlt?**

[Font substitution rules](/slides/de/python-java/font-selection-sequence/) werden angewendet. Der Text kann neu umfließen: Metriken, Silbentrennung und Breite können sich ändern, was für präzise Positionierung wichtig ist.

**Kann ich die Transparenz oder einen Farbverlauf der Textfüllung für einen Abschnitt unabhängig vom Rest des Absatzes festlegen?**

Ja, Textfarbe, Füllung und Transparenz auf [Portion](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/)-Ebene können sich von benachbarten Fragmenten unterscheiden.