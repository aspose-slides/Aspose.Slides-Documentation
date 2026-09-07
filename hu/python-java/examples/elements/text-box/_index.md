---
title: Szövegdoboz
type: docs
weight: 40
url: /hu/python-java/examples/elements/text-box/
keywords:
- kód példa
- szövegdoboz
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Dolgozzon szövegdobozokkal az Aspose.Slides for Python via Java-ban: szöveget adjon hozzá, formázza, keresse meg és távolítsa el a PowerPoint és OpenDocument prezentációkban."
---
Az **Aspose.Slides for Python via Java**-ban a szövegdoboz egy automatikus alakzat, amely szöveget tartalmaz. Szinte bármely alakzat tartalmazhat szöveget, de egy tipikus szövegdoboz nem rendelkezik kitöltéssel vagy szegéllyel, és csak a szöveget jeleníti meg.

Ez az útmutató elmagyarázza, hogyan lehet programozottan szövegdobozokat hozzáadni, elérni és eltávolítani.

Telepítse a csomagot a [Installation](/slides/hu/python-java/installation/) oldalán leírtak szerint. Minden példa a `asposeslides` könyvtárat importálja a JVM indítása előtt, majd a JVM futása közben importálja az API-t.

## **Szövegdoboz hozzáadása**

Hozzon létre egy téglalapot, távolítsa el annak kitöltését és szegélyét, majd rendelje hozzá a formázott szöveget.

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

Adjon hozzá egy minta szövegdobozt, majd keresse meg azokat az alakzatokat, amelyek szövege tartalmazza a "Slide" kulcsszót.

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
                # Használja a megfelelő szövegdobozt.
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
Gyűjtse össze a megfelelő alakzatokat egy külön listába a törlésük előtt, hogy elkerülje a alakzatgyűjtemény módosítását iteráció közben.
{{% /alert %}}