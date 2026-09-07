---
title: Video
type: docs
weight: 80
url: /de/python-java/examples/elements/video/
keywords:
- Codebeispiel
- Video
- Video-Frame
- Video hinzufügen
- Video abrufen
- Video entfernen
- Video-Wiedergabe
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Verwenden Sie Aspose.Slides für Python via Java, um Video-Frames in PowerPoint- und OpenDocument-Präsentationen hinzuzufügen, darauf zuzugreifen, sie zu entfernen und zu konfigurieren."
---
Dieser Artikel demonstriert, wie man Video‑Frames hinzufügt und Wiedergabeoptionen mit **Aspose.Slides for Python via Java** einstellt.

Installieren Sie das Paket wie im Abschnitt [Installation](/slides/de/python-java/installation/) beschrieben. Jedes Beispiel importiert `asposeslides` bevor die JVM gestartet wird und importiert anschließend die API, nachdem die JVM läuft.

## **Video‑Frame hinzufügen**

Fügen Sie einen Video‑Frame ein, der auf eine externe Videodatei verweist.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Video-Frame hinzufügen, das mit einer Videodatei verknüpft ist.
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")
finally:
    presentation.dispose()
```

## **Auf einen Video‑Frame zugreifen**

Rufen Sie den ersten zu einer Folie hinzugefügten Video‑Frame ab.

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

    # Greifen Sie auf das erste Video-Frame der Folie zu.
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

## **Video‑Frame entfernen**

Löschen Sie einen Video‑Frame von der Folie.

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

    # Video-Frame entfernen.
    slide.getShapes().remove(video_frame)
finally:
    presentation.dispose()
```

## **Video‑Wiedergabe festlegen**

Konfigurieren Sie das Video so, dass es automatisch abgespielt wird, wenn die Folie angezeigt wird.

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

    # Video so konfigurieren, dass es automatisch abgespielt wird.
    video_frame.setPlayMode(VideoPlayModePreset.Auto)
finally:
    presentation.dispose()
```