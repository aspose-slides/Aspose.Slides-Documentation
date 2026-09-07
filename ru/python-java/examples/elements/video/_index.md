---
title: Видео
type: docs
weight: 80
url: /ru/python-java/examples/elements/video/
keywords:
- пример кода
- видео
- видеокадр
- добавить видео
- получить видео
- удалить видео
- воспроизведение видео
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Используйте Aspose.Slides for Python via Java для добавления, получения, удаления и настройки видеокадров в презентациях PowerPoint и OpenDocument."
---
В этой статье показано, как добавить видеокадры и настроить параметры воспроизведения с использованием **Aspose.Slides for Python via Java**.

Установите пакет, как описано в разделе [Installation](/slides/ru/python-java/installation/). В каждом примере сначала импортируется `asposeslides` перед запуском JVM, а затем импортируется API после запуска JVM.

## **Добавить видеокадр**

Вставьте видеокадр, указывающий на внешний видеофайл.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Добавьте видеокадр, связанный с видеофайлом.
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")
finally:
    presentation.dispose()
```

## **Получить видеокадр**

Получите первый видеокадр, добавленный на слайд.

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

    # Получить первый видеокадр на слайде.
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

## **Удалить видеокадр**

Удалите видеокадр со слайда.

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

    # Удалить видеокадр.
    slide.getShapes().remove(video_frame)
finally:
    presentation.dispose()
```

## **Настроить воспроизведение видео**

Настройте воспроизведение видео автоматически при отображении слайда.

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

    # Настроить автоматическое воспроизведение видео.
    video_frame.setPlayMode(VideoPlayModePreset.Auto)
finally:
    presentation.dispose()
```