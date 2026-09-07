---
title: SmartArt
type: docs
weight: 140
url: /hu/python-java/examples/elements/smart-art/
keywords:
- kódrészlet
- SmartArt
- SmartArt hozzáadása
- SmartArt elérése
- SmartArt eltávolítása
- SmartArt elrendezés
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "SmartArt használata az Aspose.Slides for Python via Java-ban: SmartArt hozzáadása, elérése, eltávolítása és diagramelrendezések módosítása PowerPoint és OpenDocument bemutatókban."
---
Ez a cikk bemutatja, hogyan lehet SmartArt grafikonokat hozzáadni, elérni, eltávolítani és elrendezéseket módosítani a **Aspose.Slides for Python via Java** segítségével.

Telepítse a csomagot a [Installation](/slides/hu/python-java/installation/) oldal szerint leírtak szerint. Minden példa a `asposeslides`-t importálja a JVM indítása előtt, majd a JVM futása közben importálja az API-t.

## **SmartArt hozzáadása**

Illesszen be egy SmartArt grafikont egy a beépített elrendezések közül.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)
finally:
    presentation.dispose()
```

## **SmartArt elérése**

Szerezze meg az első SmartArt objektumot egy dián.

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    first_smart_art = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, SmartArt):
            first_smart_art = shape
            break
finally:
    presentation.dispose()
```

## **SmartArt eltávolítása**

Töröljön egy SmartArt alakzatot a diáról.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    slide.getShapes().remove(smart_art)
finally:
    presentation.dispose()
```

## **SmartArt elrendezés módosítása**

Frissítse egy meglévő SmartArt grafikon elrendezésének típusát.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.VerticalPictureList)
finally:
    presentation.dispose()
```