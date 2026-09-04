---
title: Matematisk text
type: docs
weight: 160
url: /sv/python-java/examples/elements/math-text/
keywords:
- kodexempel
- matematisk text
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Utforska Aspose.Slides for Python via Java exempel på matematisk text: skapa och formatera ekvationer, bråk, matriser och symboler i PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur du arbetar med matematiska textformer och formaterar ekvationer med **Aspose.Slides for Python via Java**.

Installera paketet enligt beskrivningen i [Installation](/slides/sv/python-java/installation/). Varje exempel importerar `asposeslides` innan JVM:n startas, och importerar sedan API:et när JVM:n körs.

## **Lägg till matematiktext**

Skapa en matematisk form som innehåller en bråkdel och Pythagoras formel.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpave.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en matematisk form på bilden.
    math_shape = slide.getShapes().addMathShape(0, 0, 720, 150)

    # Åtkomst till det matematiska stycket.
    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()

    # Lägg till ett enkelt bråk: x / y.
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    # Lägg till ekvation: c² = a² + b².
    math_block = MathematicalText("c").setSuperscript("2").join("=").join(MathematicalText("a").setSuperscript("2")).join("+").join(MathematicalText("b").setSuperscript("2"))
    math_paragraph.add(math_block)
finally:
    presentation.dispose()
```

## **Åtkomst till matematiktext**

Lokalisera en form som innehåller ett matematiskt stycke på bilden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, MathBlock, MathematicalText, MathPortion, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en matematisk form som kan hittas nedan.
    created_math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)
    created_paragraph = created_math_shape.getTextFrame().getParagraphs().get_Item(0)
    created_portion = created_paragraph.getPortions().get_Item(0)
    created_math_paragraph = created_portion.getMathParagraph()
    created_fraction = MathematicalText("x").divide("y")
    created_math_paragraph.add(MathBlock(created_fraction))

    # Hitta den första formen som innehåller ett matematiskt stycke.
    math_shape = None
    for shape in slide.getShapes():
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None:
                has_math = False
                for paragraph in text_frame.getParagraphs():
                    for portion in paragraph.getPortions():
                        if isinstance(portion, MathPortion):
                            has_math = True
                            break
                    if has_math:
                        break
                if has_math:
                    math_shape = shape
                    break

    if math_shape is not None:
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        text_portion = paragraph.getPortions().get_Item(0)
        math_paragraph = text_portion.getMathParagraph()

        # Exempel: skapa ett bråk (ej tillagt här).
        fraction = MathematicalText("x").divide("y")

        # Använd math_paragraph eller fraction efter behov.
finally:
    presentation.dispose()
```

## **Ta bort matematiktext**

Ta bort en matematisk form från bilden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)

    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    # Ta bort den matematiska formen.
    slide.getShapes().remove(math_shape)
finally:
    presentation.dispose()
```

## **Formatera matematiktext**

Ange teckensnittsegenskaper för en matematisk del.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)
    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    text_portion.getPortionFormat().setFontHeight(20)
finally:
    presentation.dispose()
```