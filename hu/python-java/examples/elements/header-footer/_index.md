---
title: Fejléc és lábléc
type: docs
weight: 220
url: /hu/python-java/examples/elements/header-footer/
keywords:
- kódrészlet
- fejléc
- lábléc
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Python via Java segítségével szabályozhatja a dia fejléceit és lábléceit: adjon hozzá dátumokat, diaszámokat és egyedi szöveget PPT, PPTX és ODP prezentációkban."
---
Ez a cikk bemutatja, hogyan adhat hozzá lábléceket, és frissítheti a dátum- és időhelyőrzőket az **Aspose.Slides for Python via Java** használatával.

Telepítse a csomagot a [Installation](/slides/hu/python-java/installation/) útmutató szerint. Minden példában a JVM indítása előtt importálja a `asposeslides`-t, majd a JVM futásával importálja az API-t.

## **Lábléc hozzáadása**

Adjon szöveget a dia lábléc területéhez, és tegye láthatóvá.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setFooterText("My footer")
    slide.getHeaderFooterManager().setFooterVisibility(True)
finally:
    presentation.dispose()
```

## **Dátum és idő frissítése**

Módosítsa a dátum- és időhelyőrzőt egy dián.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setDateTimeText("01/01/2024")
    slide.getHeaderFooterManager().setDateTimeVisibility(True)
finally:
    presentation.dispose()
```