---
title: Jegyzet
type: docs
weight: 240
url: /hu/python-java/examples/elements/note/
keywords:
- kódpélda
- jegyzet
- előadó jegyzet
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Dolgozz a diák jegyzeteivel az Aspose.Slides for Python via Java használatával: adj hozzá, olvasd, távolítsd el és frissítsd a előadó jegyzeteit PowerPoint és OpenDocument prezentációkban."
---
Ez a cikk bemutatja, hogyan lehet hozzáadni, olvasni, eltávolítani és frissíteni a jegyzetdiákot az **Aspose.Slides for Python via Java** használatával.

Telepítsd a csomagot a [Installation](/slides/hu/python-java/installation/) szakaszban leírtak szerint. Minden példában a `asposeslides` importálása a JVM indítása előtt történik, majd a JVM futása után importáljuk az API-t.

## **Jegyzetdia hozzáadása**

Hozz létre egy jegyzetdiát, és rendelj hozzá szöveget.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")
finally:
    presentation.dispose()
```

## **Jegyzetdia elérése**

Olvasd ki a szöveget egy meglévő jegyzetdiáról.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")

    notes = notes_slide.getNotesTextFrame().getText()
    print(notes)
finally:
    presentation.dispose()
```

## **Jegyzetdia eltávolítása**

Távolítsd el a diával kapcsolatos jegyzetdiát.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getNotesSlideManager().addNotesSlide()
    slide.getNotesSlideManager().removeNotesSlide()
finally:
    presentation.dispose()
```

## **Jegyzet szövegének frissítése**

Módosítsd egy jegyzetdia szövegét.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("Old")
    notes_slide.getNotesTextFrame().setText("Updated")
finally:
    presentation.dispose()
```