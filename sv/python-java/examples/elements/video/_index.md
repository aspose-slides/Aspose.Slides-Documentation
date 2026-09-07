---
title: Video
type: docs
weight: 80
url: /sv/python-java/examples/elements/video/
keywords:
- kodexempel
- video
- videoram
- lägga till video
- åtkomst till video
- ta bort video
- videouppspelning
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Använd Aspose.Slides för Python via Java för att lägga till, få åtkomst till, ta bort och konfigurera videoramar i PowerPoint- och OpenDocument-presentationer."
---
Den här artikeln demonstrerar hur man lägger till videoramar och ställer in uppspelningsalternativ med **Aspose.Slides for Python via Java**.

Installera paketet enligt beskrivningen i [Installation](/slides/sv/python-java/installation/). Varje exempel importerar `asposeslides` innan JVM startas, och importerar sedan API:t när JVM körs.

## **Lägg till en videoram**

Infoga en videoram som refererar till en extern videofil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en videoram länkad till en videofil.
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")
finally:
    presentation.dispose()
```

## **Åtkomst till en videoram**

Hämta den första videoramen som lagts till på en bild.

```python
import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # Åtkomst till den första videoramen på bilden.
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

## **Ta bort en videoram**

Ta bort en videoram från bilden.

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

    # Ta bort videoramen.
    slide.getShapes().remove(video_frame)
finally:
    presentation.dispose()
```

## **Ställ in videouppspelning**

Konfigurera videon så att den spelas upp automatiskt när bilden visas.

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

    # Konfigurera videon för att spelas upp automatiskt.
    video_frame.setPlayMode(VideoPlayModePreset.Auto)
finally:
    presentation.dispose()
```