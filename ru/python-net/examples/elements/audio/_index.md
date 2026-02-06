---
title: Аудио
type: docs
weight: 70
url: /ru/python-net/examples/elements/audio/
keywords:
- аудио
- аудиофрейм
- добавить аудио
- доступ к аудио
- удалить аудио
- воспроизведение аудио
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Работайте с аудио в Python с использованием Aspose.Slides: добавляйте, заменяйте, извлекайте и обрезайте звуки, задавайте громкость и воспроизведение для слайдов и фигур в PowerPoint и OpenDocument."
---
Иллюстрирует, как встраивать аудиофреймы и управлять воспроизведением с помощью **Aspose.Slides for Python via .NET**. Следующие примеры показывают базовые операции с аудио.

## **Add an Audio Frame**
Пример кода ниже добавляет аудиофрейм на слайд презентации.

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **Access an Audio Frame**
Этот код извлекает первый аудиофрейм со слайда.

```py
def access_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        first_audio_frame = None
        for shape in slide.shapes:
            if isinstance(shape, slides.AudioFrame):
                first_audio_frame = shape
                break
```

## **Remove an Audio Frame**
Удаляет ранее добавленный аудиофрейм.

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Предполагаем, что первая фигура — AudioFrame.
        audio_frame = slide.shapes[0]

        # Удаляем аудио-фрейм.
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Audio Playback**
Настройте аудиофрейм, чтобы он воспроизводился автоматически при появлении слайда.

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Предполагаем, что первая фигура — AudioFrame.
        audio_frame = slide.shapes[0]

        # Воспроизводить автоматически при появлении слайда.
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```