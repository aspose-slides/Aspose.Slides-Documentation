---
title: Audio
type: docs
weight: 70
url: /de/python-java/examples/elements/audio/
keywords:
- Codebeispiel
- Audio
- Audio-Frame
- Audio hinzufügen
- Audio zugreifen
- Audio entfernen
- Audio-Wiedergabe
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Verwenden Sie Aspose.Slides für Python via Java, um Audio-Frames in PowerPoint- und OpenDocument-Präsentationen hinzuzufügen, darauf zuzugreifen, sie zu entfernen und zu konfigurieren."
---
Dieser Artikel zeigt, wie man Audiodateien einbettet und die Wiedergabe mit **Aspose.Slides for Python via Java** steuert. Die folgenden Beispiele zeigen grundlegende Audio‑Operationen.

Installieren Sie das Paket wie in [Installation](/slides/de/python-java/installation/) beschrieben. Jeder Beispielcode importiert `asposeslides`, bevor die JVM gestartet wird, und importiert die API, nachdem die JVM läuft.

## **Audio‑Frame hinzufügen**

Fügen Sie einen leeren Audio‑Frame ein, der später eingebettete Audiodaten enthalten kann.

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

    # Erstelle einen leeren Audio-Frame (Audio wird später eingebettet).
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)
finally:
    presentation.dispose()
```

## **Zugriff auf einen Audio‑Frame**

Dieser Code ruft den ersten Audio‑Frame auf einer Folie ab.

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

    # Greifen Sie auf den ersten Audio-Frame auf der Folie zu.
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

## **Audio‑Frame entfernen**

Löscht einen zuvor hinzugefügten Audio‑Frame.

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

    # Entfernen Sie den Audio-Frame.
    slide.getShapes().remove(audio_frame)
finally:
    presentation.dispose()
```

## **Audio‑Wiedergabe festlegen**

Konfigurieren Sie den Audio‑Frame so, dass er automatisch abgespielt wird, wenn die Folie angezeigt wird.

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

    # Automatisch abspielen, wenn die Folie angezeigt wird.
    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
finally:
    presentation.dispose()
```