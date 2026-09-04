---
title: Аудио
type: docs
weight: 70
url: /ru/python-java/examples/elements/audio/
keywords:
- пример кода
- аудио
- звуковой кадр
- добавить аудио
- доступ к аудио
- удалить аудио
- воспроизведение аудио
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Используйте Aspose.Slides for Python via Java для добавления, доступа, удаления и настройки звуковых кадров в презентациях PowerPoint и OpenDocument."
---
Эта статья демонстрирует, как внедрять аудио‑кадры и управлять воспроизведением с помощью **Aspose.Slides for Python via Java**. Ниже приведены примеры базовых операций с аудио.

Установите пакет, как описано в [Установка](/slides/ru/python-java/installation/). Каждый пример импортирует `asposeslides` перед запуском JVM, а затем импортирует API после запуска JVM.

## **Добавить аудио‑кадр**

Вставьте пустой аудио‑кадр, который позже можно заполнить встроенными звуковыми данными.

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

    # Создайте пустой аудио-кадр (аудио будет внедрено позже).
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)
finally:
    presentation.dispose()
```

## **Получить доступ к аудио‑кадру**

Этот код извлекает первый аудио‑кадр на слайде.

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

    # Доступ к первому аудио-кадру на слайде.
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

## **Удалить аудио‑кадр**

Удалите ранее добавленный аудио‑кадр.

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

    # Удалить аудио-кадр.
    slide.getShapes().remove(audio_frame)
finally:
    presentation.dispose()
```

## **Настроить воспроизведение аудио**

Настройте аудио‑кадр так, чтобы он воспроизводился автоматически при появлении слайда.

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

    # Воспроизводить автоматически при появлении слайда.
    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
finally:
    presentation.dispose()
```