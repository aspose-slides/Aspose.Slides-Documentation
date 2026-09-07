---
title: Video
type: docs
weight: 80
url: /cs/python-java/examples/elements/video/
keywords:
- ukázka kódu
- video
- video rámec
- přidat video
- přístup k videu
- odstranit video
- přehrávání videa
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Použijte Aspose.Slides pro Python přes Java k přidání, přístupu, odstranění a konfiguraci video rámců v prezentacích PowerPoint a OpenDocument."
---
Tento článek demonstruje, jak přidat video rámečky a nastavit možnosti přehrávání pomocí **Aspose.Slides for Python via Java**.

Nainstalujte balíček podle popisu v [Installation](/slides/cs/python-java/installation/). Každý příklad importuje `asposeslides` před spuštěním JVM a poté importuje API po spuštění JVM.

## **Přidat video rámeček**

Vložte video rámec, který odkazuje na externí video soubor.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Přidejte video rámec odkazovaný na video soubor.
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")
finally:
    presentation.dispose()
```

## **Přístup k video rámečku**

Získejte první video rámec přidaný do snímku.

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

    # Přístup k prvnímu video rámci na snímku.
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

## **Odstranit video rámeček**

Odstraňte video rámec ze snímku.

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

    # Odstraňte video rámec.
    slide.getShapes().remove(video_frame)
finally:
    presentation.dispose()
```

## **Nastavit přehrávání videa**

Nakonfigurujte video tak, aby se přehrávalo automaticky při zobrazení snímku.

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

    # Nakonfigurujte video tak, aby se přehrávalo automaticky.
    video_frame.setPlayMode(VideoPlayModePreset.Auto)
finally:
    presentation.dispose()
```