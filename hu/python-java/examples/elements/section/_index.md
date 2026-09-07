---
title: Szekció
type: docs
weight: 90
url: /hu/python-java/examples/elements/section/
keywords:
- kód példa
- szekció
- PowerPoint
- OpenDocument
- bemutató
- Python
- Java
- Aspose.Slides
description: "Kezelje a bemutató szekciókat az Aspose.Slides for Python via Java segítségével: szekciók hozzáadása, elérése, eltávolítása és átnevezése Python kódpéldákkal."
---
Példák a bemutató szekciók kezelésére — szekciók hozzáadása, elérése, eltávolítása és átnevezése programozott módon a **Aspose.Slides for Python via Java** segítségével.

Telepítse a csomagot a [Installation](/slides/hu/python-java/installation/) útmutató szerint. Minden példa importálja a `asposeslides`-t a JVM indítása előtt, majd a JVM futása közben importálja az API-t.

## **Szekció hozzáadása**

Hozzon létre egy szekciót, amely egy adott dián kezdődik.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Adja meg azt a diát, amely a szekció kezdetét jelöli.
    presentation.getSections().addSection("New Section", slide)
finally:
    presentation.dispose()
```

## **Szekció elérése**

Olvassa be a szekcióinformációkat egy bemutatóból.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("My Section", slide)

    # Szekció elérése index szerint.
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **Szekció eltávolítása**

Törölje a korábban hozzáadott szekciót.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    section = presentation.getSections().addSection("Temporary Section", slide)

    # Távolítsa el az első szekciót.
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **Szekció átnevezése**

Módosítsa egy meglévő szekció nevét.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("Old Name", slide)

    section = presentation.getSections().get_Item(0)
    section.setName("New Name")
finally:
    presentation.dispose()
```