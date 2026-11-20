---
title: Управление аудио‑фреймами в презентациях с помощью Python
linktitle: Аудио‑фрейм
type: docs
weight: 10
url: /ru/python-java/audio-frame/
keywords:
- аудио
- аудио фрейм
- миниатюра
- добавить аудио
- свойства аудио
- опции аудио
- извлечение аудио
- Python
- Aspose.Slides
description: "Встраивание аудио в слайды, изменение значка аудио, настройка воспроизведения, управление WebVTT‑подписями и извлечение звуков переходов слайдов с помощью Aspose.Slides for Python via Java."
---
## **Обзор**

Аудиофрейм позволяет воспроизводить звук на слайде. С помощью Aspose.Slides for Python via Java вы можете внедрять аудиоклип, выбирать изображение, представляющее его, регулировать воспроизведение и прикреплять субтитры. Также можно получить звук, назначенный переходу слайда.

## **Создание аудио‑фреймов**

Добавьте байты из `audio.wav` в коллекцию аудио презентации, затем используйте [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) для встраивания локального аудиоклипа на первый слайд. Первые две координаты задают позицию фрейма на слайде, а следующие два значения задают его ширину и высоту в пунктах. В этом примере вызывается [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) для автоматического запуска клипа и [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) для выбора предустановленного громкого уровня.

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

## **Изменение миниатюры аудио‑фрейма**

По умолчанию аудио‑фрейм отображает значок динамика. Чтобы показать пользовательскую миниатюру, добавьте изображение в презентацию с помощью [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) и установите его в картинку фрейма через [setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage). В примере используется JPEG в качестве миниатюры для встроенного аудиоклипа.

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

    audio_data = Path("audio.wav").read_bytes()
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

Элементы управления **Audio Options** в PowerPoint определяют, когда начинается клип, насколько громко он звучит и как он ведет себя во время показа слайдов.

![Элементы управления Audio Options PowerPoint для аудио‑фрейма](audio_frame_0.png)

| Элемент управления PowerPoint | Метод Aspose.Slides for Python via Java |
| --- | --- |
| Start | [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) |
| Volume preset | [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) |
| Play Across Slides | [setPlayAcrossSlides](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Loop until Stopped | [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Hide During Show | [setHideAtShowing](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setHideAtShowing) |
| Rewind after Playing | [setRewindAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setRewindAudio) |
| Fade In | [setFadeInDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeInDuration) |
| Fade Out | [setFadeOutDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Trim Audio start time | [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) |
| Trim Audio end time | [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Volume slider | [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) |

В примере находится первый аудио‑фрейм на первом слайде, вызывается [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) для запуска воспроизведения по щелчку и выбирается предустановка низкой громкости. Клип продолжается сквозь слайды с отключённым зацикливанием. Значок скрыт во время показа, а после воспроизведения клип перематывается назад.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        # Воспроизвести по щелчку при низкой громкости, на всех слайдах, без зацикливания.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Скрыть фрейм во время показа слайдов и перемотать назад после воспроизведения.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)

        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

Для клипа длительностью более 3,5 секунды этот пример пропускает первые 1,5 секунды и последние 2 секунды. [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) принимает длительность, которую следует исключить из конца клипа. Чтобы получить конечное время, показанное в PowerPoint, вычтите это смещение из полной длительности клипа. Обрезанный клип плавно появляется за 200 мс и исчезает за 500 мс. Все четыре метода принимают значения в миллисекундах.

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

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # Обрезать 1.5 секунды с начала и 2 секунды с конца.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Установить плавное появление на 200 мс и плавное исчезновение на 500 мс.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Чтобы установить громкость воспроизведения в определённый процент, используйте [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue). В этом примере первый аудио‑фрейм на первом слайде устанавливается на 85 %.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

## **Управление аудио‑подписями**

Каждый аудио‑фрейм предоставляет доступ к своим дорожкам подписей через [getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getCaptionTracks). Используйте коллекцию для прикрепления WebVTT‑подписей к клипу, экспорта существующих дорожек или их удаления.

### **Добавление аудио‑подписей**

В примере встраивается аудио‑клип на первый слайд и с помощью [add](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#add) прикрепляется локальная WebVTT‑дорожка. Первый аргумент задаёт метку дорожки, а второй указывает файл, содержащий тайм‑коды подписи.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # Добавить новую дорожку подписей из файла WebVTT.
    audio_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Извлечение аудио‑подписей**

Этот пример экспортирует каждую дорожку подписи, прикреплённую к аудио‑фрейму на первом слайде. Он записывает байты, возвращённые [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getBinaryData), в файл WebVTT и использует идентификатор, возвращённый [getCaptionId](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getCaptionId), в качестве имени файла, чтобы каждая дорожка имела отдельный вывод.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            for caption_track in shape.getCaptionTracks():
                # Сохранить дорожку субтитров как файл .vtt.
                file_path = Path(f"{caption_track.getCaptionId()}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

### **Удаление аудио‑подписей**

Используйте [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) или [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) для удаления отдельной дорожки. В примере применяется [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) для удаления всех подписей из первого аудио‑фрейма на первом слайде при сохранении клипа.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

### **Поиск строки в аудио‑подписях**

Чтобы найти строку в аудио‑подписях на первом слайде, выполните поиск текста, возвращённого [getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString), в памяти. В простом текстовом WebVTT‑cue строка времени содержит `-->`, за ней следуют строки подписи, а пустая строка завершает cue. В этом примере выводятся метка дорожки и каждая строка подписи, содержащая «café».

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, AudioFrame):
            continue
        for track in shape.getCaptionTracks():
            in_cue = False
            captions = str(track.getDataAsString())
            for line in captions.splitlines():
                if not line:
                    in_cue = False
                elif "-->" in line:
                    in_cue = True
                elif in_cue and "café" in line.casefold():
                    print(f"{track.getLabel()}: {line}")
finally:
    presentation.dispose()
```

## **Извлечение аудио**

Переход слайда может иметь собственный звук. Чтобы получить его, вызовите [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSound) у перехода слайда. Пример получает байты, возвращённые [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData), и выводит их количество. Если у первого слайда нет звука перехода, выводится соответствующее сообщение.

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
        print(f"Transition sound: {len(audio_data)} bytes.")
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **FAQ**

**Могу ли я повторно использовать один и тот же аудио‑клип на нескольких слайдах без его дублирования?**

Да. Добавьте клип один раз в [audio collection](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAudios) презентации и передайте тот же объект аудио в [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) для каждого слайда.

**Можно ли заменить звук в уже существующем аудио‑фрейме?**

Да. Для связанного звука используйте [setLinkPathLong](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setLinkPathLong), чтобы указать заменяющий файл. Для встроенного звука выберите другой клип из коллекции аудио презентации с помощью [setEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setEmbeddedAudio). Оба подхода сохраняют существующий фрейм.

**Изменит ли обрезка аудио‑данные, хранящиеся в презентации?**

Нет. [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) и [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) задают границы воспроизведения. Вы всё равно можете получить полный клип через [getEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getEmbeddedAudio).