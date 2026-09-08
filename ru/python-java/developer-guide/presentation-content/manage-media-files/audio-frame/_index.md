---
title: Управление аудио в презентациях с использованием Python
linktitle: Аудио‑кадр
type: docs
weight: 10
url: /ru/python-java/audio-frame/
keywords:
- аудио
- аудио кадр
- миниатюра
- добавить аудио
- свойства аудио
- параметры аудио
- извлечь аудио
- Python
- Aspose.Slides
description: "Создавайте и управляйте аудио‑кадрами в Aspose.Slides for Python via Java — примеры кода для вставки, обрезки, зацикливания и настройки воспроизведения в презентациях PPT, PPTX и ODP."
---
## **Обзор**

В этой статье объясняется, как работать с аудио‑кадрами в Aspose.Slides. Она показывает, как добавить встроенный аудио в слайды, настроить миниатюру аудио‑кадра, сконфигурировать параметры воспроизведения, такие как громкость, зацикливание, скрытие, обрезка и длительности затухания, а также извлечь аудио, используемое в переходах слайд‑шоу.

## **Создание аудио‑кадров**

Aspose.Slides for Python via Java позволяет добавлять аудиофайлы в слайды. Аудиофайлы встраиваются в слайды в виде аудио‑кадров. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Считайте аудиофайл, который нужно встроить в слайд.
4. Добавьте встроенный аудио‑кадр (содержащий аудиофайл) на слайд.
5. Установите методы [setPlayMode](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audioframe/#setPlayMode) и [setVolume](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audioframe/#setVolume), предоставляемые объектом [AudioFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audioframe/).
6. Сохраните изменённую презентацию.

Этот код на Python показывает, как добавить встроенный аудио‑кадр на слайд:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audio)

    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
    audio_frame.setVolume(AudioVolumeMode.Loud)
    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Изменение миниатюры аудио‑кадра**

Когда вы добавляете аудиофайл в презентацию, аудио отображается как кадр со стандартным изображением по умолчанию (см. изображение в разделе ниже). Вы можете изменить изображение предварительного просмотра аудио‑кадра (установить желаемое изображение).

Этот код на Python показывает, как изменить миниатюру или изображение предварительного просмотра аудио‑кадра:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sample2.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audio)

    image = Images.fromFile("eagle.jpeg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    audio_frame.getPictureFormat().getPicture().setImage(picture)
    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Изменение параметров воспроизведения аудио**

Aspose.Slides for Python via Java позволяет изменять параметры, управляющие воспроизведением аудио или его свойствами. Например, вы можете отрегулировать громкость аудио, установить зацикливание воспроизведения или даже скрыть значок аудио.

Панель **Audio Options** в Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Параметры PowerPoint **Audio Options**, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audioframe/) properties:

- **Start** выпадающий список соответствует методу [setPlayMode](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** соответствует методу [setVolume](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** соответствует методу [setPlayAcrossSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** соответствует методу [setPlayLoopMode](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** соответствует методу [setHideAtShowing](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** соответствует методу [setRewindAudio](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audioframe/#setRewindAudio)

Параметры PowerPoint **Editing**, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audioframe/) properties:

- **Fade In** соответствует методу [setFadeInDuration](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** соответствует методу [setFadeOutDuration](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** соответствует методу [setTrimFromStart](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time** значение равно длительности аудио минус значение, установленное методом [setTrimFromEnd](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audioframe/#setTrimFromEnd)

Ползунок **Volume control** на панели управления аудио в PowerPoint соответствует методу [setVolumeValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audioframe/#setVolumeValue). Он позволяет изменить громкость аудио в процентах.

Вот как изменить параметры воспроизведения аудио:

1. [Создайте](#create-audio-frames) или получите Audio Frame.
2. Установите новые значения свойств Audio Frame, которые необходимо изменить.
3. Сохраните изменённый файл PowerPoint.

Этот код на Python демонстрирует операцию, в которой регулируются параметры аудио:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    audio_frame = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        # Воспроизводить по щелчку с низкой громкостью, на всех слайдах, без зацикливания.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Скрыть кадр во время показа слайдов и перемотать после воспроизведения.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

Этот пример на Python показывает, как добавить новый аудио‑кадр со встроенным аудио, обрезать его и задать длительности затухания:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sampleaudio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # Обрезать 1,5 секунды от начала и 2 секунды от конца.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Установить fade-in 200 мс и fade-out 500 мс.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Следующий пример кода показывает, как получить аудио‑кадр со встроенным аудио и установить его громкость на 85%:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Управление субтитрами аудио**

Aspose.Slides позволяет добавлять закрытые субтитры к аудио‑кадру с помощью метода [getCaptionTracks](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audioframe/#getCaptionTracks). Этот метод возвращает объект [CaptionsCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/captionscollection/), который позволяет добавлять дорожки субтитров WebVTT, перебрать существующие дорожки и удалить их при необходимости.

**Добавление субтитров к аудио**

Используйте метод [getCaptionTracks](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audioframe/#getCaptionTracks), чтобы прикрепить одну или несколько дорожек субтитров к аудио‑кадру. В следующем примере аудиофайл добавляется на слайд, после чего новая дорожка субтитров загружается из файла `.vtt`.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # Добавить новую дорожку субтитров из файла WebVTT.
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Извлечение субтитров из аудио**

Вы можете перебрать дорожки субтитров, связанные с аудио‑кадром, и сохранить их как файлы `.vtt`. Каждая дорожка субтитров предоставляет свои двоичные данные и уникальный идентификатор, которые можно использовать при экспорте субтитров.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            for caption_track in shape.getCaptionTracks():
                # Сохранить дорожку субтитров как файл .vtt.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**Удаление субтитров из аудио**

Чтобы удалить субтитры из аудио‑кадра, используйте методы, предоставляемые объектом [CaptionsCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/captionscollection/), такие как [clear](https://reference.aspose.com/slides/ru/python-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/ru/python-java/aspose.slides/captionscollection/#remove), или [removeAt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/captionscollection/#removeAt). В следующем примере удаляются все дорожки субтитров из аудио‑кадра.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Извлечение аудио**

Aspose.Slides for Python via Java позволяет извлекать звук, используемый в переходах слайд‑шоу. Например, вы можете извлечь звук, использованный на конкретном слайде.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и загрузите презентацию, содержащую аудио.
2. Получите ссылку на соответствующий слайд по его индексу.
3. Получите доступ к [slideshow transitions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/#getSlideShowTransition) для слайда.
4. Извлеките звук в виде байтовых данных.

Этот код на Python показывает, как извлечь аудио, используемое на слайде:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AudioSlide.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    transition = slide.getSlideShowTransition()
    sound = transition.getSound()
    if sound is not None:
        audio_data = sound.getBinaryData()
        print("Length:", len(audio_data))
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **Часто задаваемые вопросы**

**Могу ли я использовать один и тот же аудио‑ресурс на нескольких слайдах без увеличения размера файла?**

Да. Добавьте аудио один раз в общую [audio collection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getAudios) презентации и создайте дополнительные аудио‑кадры, ссылающиеся на этот существующий ресурс. Это предотвращает дублирование медиа‑данных и позволяет контролировать размер презентации.

**Могу ли я заменить звук в существующем аудио‑кадре без пересоздания формы?**

Да. Для связанного звука обновите [link path](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audioframe/#setLinkPathLong), чтобы указать новый файл. Для встроенного звука замените объект [embedded audio](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audioframe/#setEmbeddedAudio) другим из [audio collection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getAudios) презентации. Форматирование кадра и большинство настроек воспроизведения сохраняются.

**Изменяет ли обрезка исходные аудио‑данные, хранящиеся в презентации?**

Нет. Обрезка изменяет только границы воспроизведения. Исходные байты аудио остаются нетронутыми и доступны через встроенный аудио‑объект или коллекцию аудио презентации.