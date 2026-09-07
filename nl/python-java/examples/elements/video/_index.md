---
title: Video
type: docs
weight: 80
url: /nl/python-java/examples/elements/video/
keywords:
- codevoorbeeld
- video
- video-frame
- video toevoegen
- video openen
- video verwijderen
- video-afspelen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Gebruik Aspose.Slides voor Python via Java om video-frames toe te voegen, te openen, te verwijderen en te configureren in PowerPoint- en OpenDocument-presentaties."
---
Dit artikel laat zien hoe u video‑frames toevoegt en afspeelopties instelt met **Aspose.Slides for Python via Java**.

Installeer het pakket zoals beschreven in [Installatie](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides` voordat de JVM wordt gestart, en importeert daarna de API nadat de JVM draait.

## **Video‑frame toevoegen**

Voeg een video‑frame in dat verwijst naar een extern videobestand.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Voeg een video-frame toe dat gekoppeld is aan een videobestand.
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")
finally:
    presentation.dispose()
```

## **Toegang tot een video‑frame**

Haal het eerste video‑frame op dat aan een dia is toegevoegd.

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

    # Toegang tot het eerste video-frame op de dia.
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

## **Video‑frame verwijderen**

Verwijder een video‑frame van de dia.

```python
import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # Verwijder het video-frame.
    slide.getShapes().remove(video_frame)
finally:
    presentation.dispose()
```

## **Video‑afspelen instellen**

Stel in dat de video automatisch wordt afgespeeld wanneer de dia wordt weergegeven.

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

    # Configureer de video om automatisch te worden afgespeeld.
    video_frame.setPlayMode(VideoPlayModePreset.Auto)
finally:
    presentation.dispose()
```