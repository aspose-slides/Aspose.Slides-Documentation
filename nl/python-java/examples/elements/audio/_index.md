---
title: Audio
type: docs
weight: 70
url: /nl/python-java/examples/elements/audio/
keywords:
- codevoorbeeld
- audio
- audioframe
- audio toevoegen
- audio benaderen
- audio verwijderen
- audio afspelen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Gebruik Aspose.Slides for Python via Java om audioframes toe te voegen, te benaderen, te verwijderen en te configureren in PowerPoint- en OpenDocument-presentaties."
---
Dit artikel toont hoe je audioframes kunt insluiten en de weergave kunt regelen met **Aspose.Slides for Python via Java**. De volgende voorbeelden laten basis audio-bewerkingen zien.

Installeer het pakket zoals beschreven in [Installation](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides` voordat de JVM wordt gestart, en importeert daarna de API nadat de JVM draait.

## **Audioframe toevoegen**

Voeg een lege audioframe toe die later ingebedde geluidsgegevens kan bevatten.

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

    # Maak een leeg audioframe (audio wordt later ingebed).
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)
finally:
    presentation.dispose()
```

## **Toegang tot een audioframe**

Deze code haalt het eerste audioframe op een dia op.

```python
import jpide
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

    # Toegang tot het eerste audioframe op de dia.
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

## **Audioframe verwijderen**

Verwijder een eerder toegevoegd audioframe.

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

    # Verwijder het audioframe.
    slide.getShapes().remove(audio_frame)
finally:
    presentation.dispose()
```

## **Audio-afspelen instellen**

Stel het audioframe in om automatisch af te spelen wanneer de dia verschijnt.

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

    # Speel automatisch af wanneer de dia verschijnt.
    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
finally:
    presentation.dispose()
```