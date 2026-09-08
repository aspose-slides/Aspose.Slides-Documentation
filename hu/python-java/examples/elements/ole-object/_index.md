---
title: OLE Objektum
type: docs
weight: 210
url: /hu/python-java/examples/elements/ole-object/
keywords:
- kódpélda
- OLE objektum
- OLE objektum hozzáadása
- OLE objektum elérése
- OLE objektum eltávolítása
- OLE objektum frissítése
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Python via Java használatával OLE objektumokat adhat hozzá, érhet el, távolíthat el és frissíthet PowerPoint és OpenDocument prezentációkban."
---
Ez a cikk bemutatja, hogyan lehet egy fájlt OLE objektumként beágyazni, és hogyan lehet annak adatait frissíteni a **Aspose.Slides for Python via Java** segítségével.

Telepítse a csomagot a [Telepítés](/slides/hu/python-java/installation/) leírása szerint. Minden példa a `asposeslides` modult importálja a JVM indítása előtt, majd a JVM futása közben importálja az API-t.

## **OLE objektum hozzáadása**

Ágyazzon be egy PDF fájlt a prezentációba.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Path("doc.pdf").read_bytes()
    java_pdf_data = jpype.JArray(jpype.JByte)(pdf_data)
    data_info = OleEmbeddedDataInfo(java_pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)
finally:
    presentation.dispose()
```

## **OLE objektum elérése**

Szerezze meg a dián található első OLE objektum keretet.

```python
from pathlib import Path

import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Path("doc.pdf").read_bytes()
    java_pdf_data = jpype.JArray(jpype.JByte)(pdf_data)
    data_info = OleEmbeddedDataInfo(java_pdf_data, "pdf")
    slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    first_ole_frame = None
    for shape in slide.getShapes():
        if isinstance(shape, OleObjectFrame):
            first_ole_frame = shape
            break

    if first_ole_frame is None:
        print("The slide contains no OLE object frames.")
finally:
    presentation.dispose()
```

## **OLE objektum eltávolítása**

Töröljön egy beágyazott OLE objektumot a diáról.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Path("doc.pdf").read_bytes()
    java_pdf_data = jpype.JArray(jpype.JByte)(pdf_data)
    data_info = OleEmbeddedDataInfo(java_pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    slide.getShapes().remove(ole_frame)
finally:
    presentation.dispose()
```

## **OLE objektum adatainak frissítése**

Cserélje le a meglévő OLE objektumban beágyazott adatokat.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Path("doc.pdf").read_bytes()
    java_pdf_data = jpype.JArray(jpype.JByte)(pdf_data)
    data_info = OleEmbeddedDataInfo(java_pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    new_data = Path("Picture.png").read_bytes()
    java_new_data = jpype.JArray(jpype.JByte)(new_data)
    new_data_info = OleEmbeddedDataInfo(java_new_data, "png")
    ole_frame.setEmbeddedData(new_data_info)
finally:
    presentation.dispose()
```