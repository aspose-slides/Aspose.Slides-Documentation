---
title: Textfeld
type: docs
weight: 40
url: /de/python-java/examples/elements/text-box/
keywords:
- Codebeispiel
- Textfeld
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Arbeiten Sie mit Textfeldern in Aspose.Slides für Python via Java: Hinzufügen, Formatieren, Suchen und Entfernen von Text in PowerPoint- und OpenDocument-Präsentationen."
---
In **Aspose.Slides for Python via Java** ist ein Textfeld ein AutoShape, das Text enthält. Fast jede Form kann Text enthalten, aber ein typisches Textfeld hat keine Füllung oder keinen Rand und zeigt nur Text an.

Dieser Leitfaden erklärt, wie man Textfelder programmgesteuert hinzufügt, darauf zugreift und sie entfernt.

Installieren Sie das Paket wie in [Installation](/slides/de/python-java/installation/) beschrieben. Jedes Beispiel importiert `asposeslides` bevor die JVM gestartet wird und importiert die API, nachdem die JVM läuft.

## **Textfeld hinzufügen**

Erstellen Sie ein Rechteck, entfernen Sie dessen Füllung und Rand und weisen Sie formatierten Text zu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Erstelle eine Rechteckform.
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)

    # Entferne die Füllung und den Rand, um nur Text anzuzeigen.
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    # Setze die Standard-Textformatierung.
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    text_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
    text_format.getFillFormat().setFillType(FillType.Solid)
    text_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    text_box.getTextFrame().setText("Some text...")
finally:
    presentation.dispose()
```

## **Zugriff auf Textfelder nach Inhalt**

Fügen Sie ein Beispiel-Textfeld hinzu und suchen Sie anschließend nach Formen, deren Text das Schlüsselwort "Slide" enthält.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                # Verwende das passende Textfeld.
                print(text_frame.getText())
finally:
    presentation.dispose()
```

## **Entfernen von Textfeldern nach Inhalt**

Suchen und löschen Sie Textfelder auf der ersten Folie, die ein bestimmtes Schlüsselwort enthalten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    shapes_to_remove = []
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}}
Sammeln Sie passende Formen in einer separaten Liste, bevor Sie sie entfernen, um zu verhindern, dass die Formensammlung während der Iteration geändert wird.
{{% /alert %}}