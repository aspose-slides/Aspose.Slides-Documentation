---
title: Wideo
type: docs
weight: 80
url: /pl/python-java/examples/elements/video/
keywords:
- przykład kodu
- wideo
- ramka wideo
- dodaj wideo
- dostęp do wideo
- usuń wideo
- odtwarzanie wideo
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Użyj Aspose.Slides dla Pythona poprzez Javę, aby dodać, uzyskać dostęp, usunąć i skonfigurować ramki wideo w prezentacjach PowerPoint oraz OpenDocument."
---
Ten artykuł demonstruje, jak dodawać ramki wideo i ustawiać opcje odtwarzania przy użyciu **Aspose.Slides for Python via Java**.

Zainstaluj pakiet zgodnie z opisem w [Installation](/slides/pl/python-java/installation/). Każdy przykład importuje `asposeslides` przed uruchomieniem JVM, a następnie importuje API po uruchomieniu JVM.

## **Dodaj ramkę wideo**

Wstaw ramkę wideo, która odwołuje się do zewnętrznego pliku wideo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Dodaj ramkę wideo powiązaną z plikiem wideo.
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")
finally:
    presentation.dispose()
```

## **Uzyskaj dostęp do ramki wideo**

Pobierz pierwszą ramkę wideo dodaną do slajdu.

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

    # Uzyskaj dostęp do pierwszej ramki wideo na slajdzie.
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

## **Usuń ramkę wideo**

Usuń ramkę wideo ze slajdu.

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

    # Usuń ramkę wideo.
    slide.getShapes().remove(video_frame)
finally:
    presentation.dispose()
```

## **Ustaw odtwarzanie wideo**

Skonfiguruj wideo, aby odtwarzało się automatycznie po wyświetleniu slajdu.

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

    # Skonfiguruj wideo, aby odtwarzało się automatycznie.
    video_frame.setPlayMode(VideoPlayModePreset.Auto)
finally:
    presentation.dispose()
```