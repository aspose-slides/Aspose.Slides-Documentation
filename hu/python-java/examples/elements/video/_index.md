---
title: Videó
type: docs
weight: 80
url: /hu/python-java/examples/elements/video/
keywords:
- kódrészlet példa
- videó
- videokeret
- videó hozzáadása
- videó elérése
- videó eltávolítása
- videolejátszás
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Használja az Aspose.Slides for Python via Java-t videokeretek hozzáadásához, eléréséhez, eltávolításához és konfigurálásához PowerPoint és OpenDocument prezentációkban."
---
Ez a cikk bemutatja, hogyan lehet videokereteket hozzáadni és lejátszási beállításokat megadni a **Aspose.Slides for Python via Java** használatával.

Telepítse a csomagot a [Installation](/slides/hu/python-java/installation/) útmutató szerint. Minden példában a `asposeslides` importálása a JVM indítása előtt történik, majd a JVM futása után importálják az API-t.

## **Videokeret hozzáadása**
Helyezzen be egy videokeretet, amely egy külső videofájlra hivatkozik.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Videokeret hozzáadása, amely egy videofájlra hivatkozik.
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")
finally:
    presentation.dispose()
```

## **Videokeret elérése**
Szerezze be az első, a diára hozzáadott videokeretet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # A diára helyezett első videokeret elérése.
    first_video = None
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            first_video = shape
            break

    if first_video is None:
        print("The slide contains no video frames.")
finally:
    presentation.dispose()
```

## **Videokeret eltávolítása**
Törölje a videokeretet a diáról.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # Videokeret eltávolítása.
    slide.getShapes().remove(video_frame)
finally:
    presentation.dispose()
```

## **Videolejátszás beállítása**
Állítsa be a videót, hogy automatikusan lejátszódjon, amikor a dia megjelenik.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # A videó automatikus lejátszásának beállítása.
    video_frame.setPlayMode(VideoPlayModePreset.Auto)
finally:
    presentation.dispose()
```