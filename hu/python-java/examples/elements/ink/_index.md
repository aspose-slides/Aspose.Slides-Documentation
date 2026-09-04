---
title: Tinta
type: docs
weight: 180
url: /hu/python-java/examples/elements/ink/
keywords:
- kódrészlet
- tinta
- tinta elérése
- tinta eltávolítása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Tinta alakzatok elérése és eltávolítása az Aspose.Slides for Python via Java prezentációkban, beleértve a PPT, PPTX és ODP fájlokat."
---
Ez a cikk példákat mutat be a meglévő tinta alakzatok elérésére és eltávolítására a **Aspose.Slides for Python via Java** használatával.

Telepítsd a csomagot a [Installation](/slides/hu/python-java/installation/) útmutató szerint. Minden példa a JVM indítása előtt importálja a `asposeslides`-t, majd a JVM futása közben importálja az API-t.

{{% alert color="info" title="Megjegyzés" %}}
A tinta alakzatok a speciális eszközök felhasználói bemenetét képviselik. Az Aspose.Slides programkódból nem képes új tinta vonalakat létrehozni, de a meglévő tintákat olvashatod és módosíthatod.
{{% /alert %}}

## **Tintához hozzáférés**

Olvasd ki a címkéket az első tinta alakzatról a dián.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().get_Item(0)
    if isinstance(shape, Ink):
        tags = shape.getCustomData().getTags()
        if tags.size() > 0:
            tag_name = tags.getNameByIndex(0)
            # Használd a tag_name-et szükség szerint.
finally:
    presentation.dispose()
```

## **Tinták eltávolítása**

Töröld a tinta alakzatot a diáról, ha létezik.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    ink = None
    for shape in slide.getShapes():
        if isinstance(shape, Ink):
            ink = shape
            break

    if ink is not None:
        slide.getShapes().remove(ink)
finally:
    presentation.dispose()
```