---
title: Видео
type: docs
weight: 80
url: /ru/python-net/examples/elements/video/
keywords:
- видео
- видеокадр
- добавить видео
- доступ к видео
- удалить видео
- воспроизведение видео
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Работайте с видео в Python с использованием Aspose.Slides: вставка, замена, обрезка, установка постеров и параметров воспроизведения, а также экспорт презентаций в формат PPT, PPTX и ODP."
---
Показывает, как внедрять видеокадры и задавать параметры воспроизведения с помощью **Aspose.Slides for Python via .NET**.

## **Добавить видеокадр**

Вставьте пустой видеокадр на слайд.

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Добавить видеокадр.
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **Доступ к видеокадру**

Получите первый видеокадр, добавленный на слайд.

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Доступ к первому видеокадру на слайде.
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **Удалить видеокадр**

Удалите видеокадр со слайда.

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Предполагая, что первая фигура — видеокадр.
        video_frame = slide.shapes[0]

        # Удалить видеокадр.
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Настроить воспроизведение видео**

Настройте видео на автоматическое воспроизведение при отображении слайда.

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Предполагая, что первая фигура — видеокадр.
        video_frame = slide.shapes[0]

        # Настроить видео для автоматического воспроизведения.
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```