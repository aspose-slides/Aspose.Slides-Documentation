---
title: Textové pole
type: docs
weight: 40
url: /cs/python-java/examples/elements/text-box/
keywords:
- příklad kódu
- textové pole
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Pracujte s textovými poli v Aspose.Slides for Python via Java: přidávejte, formátujte, vyhledávejte a odstraňujte text v prezentacích PowerPoint a OpenDocument."
---
V **Aspose.Slides for Python via Java** je textové pole automatický tvar, který obsahuje text. Téměř jakýkoli tvar může obsahovat text, ale typické textové pole nemá výplň ani ohraničení a zobrazuje pouze text.

Tento průvodce vysvětluje, jak programově přidávat, přistupovat k a odstraňovat textová pole.

Balíček nainstalujte podle popisu v [Installation](/slides/cs/python-java/installation/). Každý příklad nejprve naimportuje `asposeslides` před spuštěním JVM a poté naimportuje API po spuštění JVM.

## **Přidat textové pole**

Vytvořte obdélník, odstraňte jeho výplň a ohraničení a přiřaďte formátovaný text.

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

    # Vytvořte obdélníkový tvar.
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)

    # Odstraňte výplň a okraj, aby se zobrazoval pouze text.
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    # Nastavte výchozí formátování textu.
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    text_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
    text_format.getFillFormat().setFillType(FillType.Solid)
    text_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    text_box.getTextFrame().setText("Some text...")
finally:
    presentation.dispose()
```

## **Přístup k textovým polím podle obsahu**

Přidejte ukázkové textové pole a poté najděte tvary, jejichž text obsahuje klíčové slovo "Slide".

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
                # Použijte odpovídající textové pole.
                print(text_frame.getText())
finally:
    presentation.dispose()
```

## **Odstranit textová pole podle obsahu**

Najděte a odstraňte textová pole na první snímku, která obsahují konkrétní klíčové slovo.

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
Shromážděte odpovídající tvary do samostatného seznamu před jejich odstraněním, abyste se vyhnuli úpravě kolekce tvarů během iterace.
{{% /alert %}}