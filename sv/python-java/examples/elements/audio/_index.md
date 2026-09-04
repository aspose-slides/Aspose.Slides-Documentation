---
title: Ljud
type: docs
weight: 70
url: /sv/python-java/examples/elements/audio/
keywords:
- kodexempel
- ljud
- ljudram
- lägg till ljud
- åtkomst till ljud
- ta bort ljud
- ljuduppspelning
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Använd Aspose.Slides för Python via Java för att lägga till, komma åt, ta bort och konfigurera ljudramar i PowerPoint- och OpenDocument-presentationer."
---
Den här artikeln visar hur man bäddar in ljudramar och styr uppspelning med **Aspose.Slides for Python via Java**. Följande exempel visar grundläggande ljudoperationer.

Installera paketet enligt beskrivningen i [Installation](/slides/sv/python-java/installation/). Varje exempel importerar `asposeslides` innan JVM startas, och importerar sedan API:n när JVM körs.

## **Lägg till en ljudram**

Infoga en tom ljudram som senare kan innehålla inbäddade ljuddata.

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

    # Skapa en tom ljudram (ljudet kommer att bäddas in senare).
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)
finally:
    presentation.dispose()
```

## **Åtkomst till en ljudram**

Den här koden hämtar den första ljudramen på en bild.

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

    # Åtkomst till den första ljudramen på bilden.
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

## **Ta bort en ljudram**

Ta bort en tidigare tillagd ljudram.

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

    # Ta bort ljudramen.
    slide.getShapes().remove(audio_frame)
finally:
    presentation.dispose()
```

## **Ställ in ljuduppspelning**

Konfigurera ljudramen så att den spelas upp automatiskt när bilden visas.

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

    # Spela automatiskt när bilden visas.
    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
finally:
    presentation.dispose()
```