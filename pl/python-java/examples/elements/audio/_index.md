---
title: Dźwięk
type: docs
weight: 70
url: /pl/python-java/examples/elements/audio/
keywords:
- przykład kodu
- dźwięk
- ramka dźwiękowa
- dodaj dźwięk
- dostęp do dźwięku
- usuń dźwięk
- odtwarzanie dźwięku
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Użyj Aspose.Slides for Python via Java, aby dodać, uzyskać dostęp, usunąć i skonfigurować ramki dźwiękowe w prezentacjach PowerPoint i OpenDocument."
---
Ten artykuł demonstruje, jak osadzić ramki dźwiękowe i kontrolować odtwarzanie przy użyciu **Aspose.Slides for Python via Java**. Poniższe przykłady pokazują podstawowe operacje audio.

Zainstaluj pakiet zgodnie z opisem w [Installation](/slides/pl/python-java/installation/). Każdy przykład importuje `asposeslides` przed uruchomieniem JVM, a następnie importuje API po uruchomieniu JVM.

## **Dodaj ramkę audio**

Wstaw pustą ramkę audio, która później może zawierać osadzone dane dźwiękowe.

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

    # Utwórz pustą ramkę audio (dźwięk zostanie osadzony później).
finally:
    presentation.dispose()
```

## **Uzyskaj dostęp do ramki audio**

Ten kod pobiera pierwszą ramkę audio na slajdzie.

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

    # Uzyskaj dostęp do pierwszej ramki audio na slajdzie.
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

## **Usuń ramkę audio**

Usuń wcześniej dodaną ramkę audio.

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

    # Usuń ramkę audio.
    slide.getShapes().remove(audio_frame)
finally:
    presentation.dispose()
```

## **Ustaw odtwarzanie audio**

Skonfiguruj ramkę audio, aby odtwarzała się automatycznie, gdy slajd się pojawi.

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

    # Odtwarzaj automatycznie, gdy slajd się pojawi.
    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
finally:
    presentation.dispose()
```