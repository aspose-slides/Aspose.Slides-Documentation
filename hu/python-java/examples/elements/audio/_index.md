---
title: Hang
type: docs
weight: 70
url: /hu/python-java/examples/elements/audio/
keywords:
- kódrészlet
- hang
- hangkeret
- hang hozzáadása
- hang elérése
- hang eltávolítása
- hang lejátszása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Használja az Aspose.Slides for Python via Java könyvtárat hangkeretek hozzáadásához, eléréséhez, eltávolításához és konfigurálásához a PowerPoint és OpenDocument prezentációkban."
---
Ez a cikk bemutatja, hogyan lehet beágyazott hangkereteket létrehozni, és a lejátszást vezérelni a **Aspose.Slides for Python via Java** használatával. A következő példák az alapvető hangműveleteket mutatják be.

Telepítse a csomagot a [Installation](/slides/hu/python-java/installation/) leírása szerint. Minden példa a `asposeslides` könyvtárat importálja a JVM indítása előtt, majd a JVM futása után importálja az API-t.

## **Hangkeret hozzáadása**

Helyezzen be egy üres hangkeretet, amely később beágyazott hangadatokat tárolhat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)

    # Üres hangkeret létrehozása (a hang később be lesz ágyazva).
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)
finally:
    presentation.dispose()
```

## **Hangkeret elérése**

Ez a kód lekéri az első hangkeretet egy dián.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # Az első hangkeret elérése a dián.
    first_audio = None
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            first_audio = shape
            break

    if first_audio is None:
        print("The slide contains no audio frames.")
finally:
    presentation.dispose()
```

## **Hangkeret eltávolítása**

Töröl egy korábban hozzáadott hangkeretet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # A hangkeret eltávolítása.
    slide.getShapes().remove(audio_frame)
finally:
    presentation.dispose()
```

## **Hang lejátszás beállítása**

Állítsa be a hangkeretet, hogy automatikusan lejátszódjon, amikor a dia megjelenik.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioPlayModePreset, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # A dia megjelenésekor automatikus lejátszás.
    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
finally:
    presentation.dispose()
```