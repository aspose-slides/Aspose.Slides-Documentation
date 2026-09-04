---
title: Audio
type: docs
weight: 70
url: /cs/python-java/examples/elements/audio/
keywords:
- ukázka kódu
- audio
- audio rámec
- přidat audio
- přístup k audiu
- odstranit audio
- přehrávání audia
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Použijte Aspose.Slides pro Python prostřednictvím Java k přidání, přístupu, odstranění a konfiguraci audio rámců v prezentacích PowerPoint a OpenDocument."
---
Tento článek ukazuje, jak vložit audio rámy a řídit jejich přehrávání pomocí **Aspose.Slides for Python via Java**. Následující příklady představují základní operace s audiem.

Nainstalujte balíček podle pokynů v sekci [Instalace](/slides/cs/python-java/installation/). Každý příklad importuje `asposeslides` před spuštěním JVM, poté importuje API po spuštění JVM.

## **Přidat audio rámec**

Vložte prázdný audio rámec, který může později obsahovat vložená zvuková data.

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

    # Vytvořte prázdný audio rámec (audio bude vloženo později).
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)
finally:
    presentation.dispose()
```

## **Přístup k audio rámci**

Tento kód získává první audio rámec na snímku.

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

    # Přístup k prvnímu audio rámci na snímku.
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

## **Odstranit audio rámec**

Odstraňte dříve přidaný audio rámec.

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

    # Odeberte audio rámec.
    slide.getShapes().remove(audio_frame)
finally:
    presentation.dispose()
```

## **Nastavit přehrávání audia**

Nastavte audio rámec tak, aby se přehrával automaticky, když se snímek zobrazí.

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

    # Přehrát automaticky při zobrazení snímku.
    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
finally:
    presentation.dispose()
```