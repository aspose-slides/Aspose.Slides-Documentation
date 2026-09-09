---
title: Textruta
type: docs
weight: 40
url: /sv/python-java/examples/elements/text-box/
keywords:
  - kodexempel
  - textruta
  - PowerPoint
  - OpenDocument
  - presentation
  - Python
  - Java
  - Aspose.Slides
description: "Arbeta med textrutor i Aspose.Slides för Python via Java: lägg till, formatera, hitta och ta bort text i PowerPoint- och OpenDocument-presentationer."
---
I **Aspose.Slides for Python via Java** är en textruta en autoshape som innehåller text. Nästan alla former kan innehålla text, men en typisk textruta har ingen fyllning eller kant och visar endast text.

Denna guide förklarar hur man lägger till, får åtkomst till och tar bort textrutor programatiskt.

Installera paketet enligt beskrivningen i [Installation](/slides/sv/python-java/installation/). Varje exempel importerar `asposeslides` innan JVM startas, och importerar sedan API:n efter att JVM körs.

## **Lägg till en textruta**

Skapa en rektangel, ta bort dess fyllning och kant, och tilldela formaterad text.

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

    # Skapa en rektangelform.
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)

    # Ta bort fyllning och kant för att endast visa text.
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    # Ange standardformatering för text.
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    text_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
    text_format.getFillFormat().setFillType(FillType.Solid)
    text_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    text_box.getTextFrame().setText("Some text...")
finally:
    presentation.dispose()
```

## **Få åtkomst till textrutor efter innehåll**

Lägg till en exempeltextruta, och hitta sedan former vars text innehåller nyckelordet "Slide".

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
                # Använd den matchande textrutan.
                print(text_frame.getText())
finally:
    presentation.dispose()
```

## **Ta bort textrutor efter innehåll**

Hitta och radera textrutor på den första bilden som innehåller ett specifikt nyckelord.

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
Samla matchande former i en separat lista innan du tar bort dem för att undvika att modifiera formsamlingen under iteration.
{{% /alert %}}