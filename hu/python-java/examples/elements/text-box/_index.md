---
title: Szövegdoboz
type: docs
weight: 40
url: /hu/python-java/examples/elements/text-box/
keywords:
- kódpélda
- szövegdoboz
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Szövegdobozok kezelése az Aspose.Slides for Python via Java‑ban: szöveg hozzáadása, formázása, keresése és eltávolítása PowerPoint és OpenDocument prezentációkban."
---
Az **Aspose.Slides for Python via Java**‑ban egy szövegdoboz egy automatikus alakzat, amely szöveget tartalmaz. Szinte bármely alakzat tartalmazhat szöveget, de egy tipikus szövegdoboznak nincs kitöltése vagy szegélye, és csak a szöveget jeleníti meg.

Ez az útmutató bemutatja, hogyan lehet programból hozzáadni, elérni és eltávolítani a szövegdobozokat.

Telepítse a csomagot a [Telepítés](/slides/hu/python-java/installation/) leírása szerint. Minden példa a `asposeslides` modult importálja a JVM indítása előtt, majd a JVM futása közben importálja az API-t.

## **Szövegdoboz hozzáadása**

Hozzon létre egy téglalapot, távolítsa el a kitöltését és szegélyét, majd rendelje hozzá a formázott szöveget.

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

    # Hozzon létre egy téglalap alakzatot.
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)

    # Távolítsa el a kitöltést és a szegélyt, hogy csak a szöveg jelenjen meg.
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    # Állítsa be az alapértelmezett szövegformázást.
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    text_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
    text_format.getFillFormat().setFillType(FillType.Solid)
    text_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    text_box.getTextFrame().setText("Some text...")
finally:
    presentation.dispose()
```

## **Szövegdobozok elérése tartalom alapján**

Adjon hozzá egy mintaszövegdobozt, majd keresse meg azokat az alakzatokat, amelyek szövege tartalmazza a "Slide" kulcsszót.

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
                # Használd a megfelelő szövegdobozt.
                print(text_frame.getText())
finally:
    presentation.dispose()
```

## **Szövegdobozok eltávolítása tartalom alapján**

Keresse meg és törölje az első dián található szövegdobozokat, amelyek egy adott kulcsszót tartalmaznak.

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
Gyűjtse a megfelelő alakzatokat egy külön listába, mielőtt eltávolítaná őket, hogy elkerülje a forma gyűjtemény módosítását az iteráció során.
{{% /alert %}}