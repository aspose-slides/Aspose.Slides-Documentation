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
description: "Aspose.Slides for Python via Java használatával vezérelheti a diafejléceket és lábléceket: adjon hozzá dátumokat, dia számokat és egyéni szöveget PPT, PPTX és ODP prezentációkban."
---
Ez a cikk bemutatja, hogyan lehet láblécet hozzáadni, valamint dátum- és időhelyőrzőket frissíteni a **Aspose.Slides for Python via Java** használatával.

Telepítse a csomagot a [Installation](/slides/hu/python-java/installation/) leírása szerint. Minden példa a JVM indítása előtt importálja a `asposeslides`-t, majd a JVM futása közben importálja az API-t.

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

Módosítsa a dia dátum- és időhelyőrzőjét.

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