---
title: SmartArt
type: docs
weight: 140
url: /cs/python-java/examples/elements/smart-art/
keywords:
- ukázka kódu
- SmartArt
- přidat SmartArt
- přístup k SmartArt
- odstranit SmartArt
- rozvržení SmartArt
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Práce se SmartArt v Aspose.Slides pro Python prostřednictvím Java: přidávat, přistupovat, odstraňovat a měnit rozvržení diagramů v prezentacích PowerPoint a OpenDocument."
---
Tento článek ukazuje, jak přidat grafiku SmartArt, získat k ní přístup, odstranit ji a změnit rozvržení pomocí **Aspose.Slides for Python via Java**.

Nainstalujte balíček podle pokynů v [Installation](/slides/cs/python-java/installation/). Každý příklad před spuštěním JVM importuje `asposeslides` a poté, co JVM běží, importuje API.

## **Add SmartArt**
Vložte grafiku SmartArt pomocí jednoho z vestavěných rozvržení.

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

## **Access SmartArt**
Získejte první objekt SmartArt na snímku.

```python
import jpype
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

## **Remove SmartArt**
Odstraňte tvar SmartArt ze snímku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpate.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    slide.getShapes().remove(smart_art)
finally:
    presentation.dispose()
```

## **Change SmartArt Layout**
Aktualizujte typ rozvržení existující grafiky SmartArt.

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