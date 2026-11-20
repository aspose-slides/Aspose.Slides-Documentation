---
title: Управление видеокадрами в презентациях с помощью Python
linktitle: Видеокадр
type: docs
weight: 10
url: /ru/python-java/video-frame/
keywords:
- добавить видео
- создать видео
- встроить видео
- извлечь видео
- получить видео
- видеокадр
- веб‑источник
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides for Python via Java. Быстрое руководство."
---
## **Введение**

Видео может помочь объяснить идеи и привлечь аудиторию. Aspose.Slides for Python via Java позволяет добавлять видеокадры на слайды, настраивать параметры воспроизведения, управлять субтитрами и извлекать внедрённые видеоданные.

PowerPoint поддерживает локальные видео и ссылки на онлайн‑видео, такие как видео на YouTube.

Для представления видеоданных и видеокадров Aspose.Slides предоставляет класс [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/), класс [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) и другие соответствующие типы.

## **Создание встроенного видеокадра**

Если видеофайл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр, чтобы встроить видео в презентацию.

Этот пример внедряет локальное видео на первый слайд существующей презентации и сохраняет результат. Координаты и размеры кадра указаны в пунктах. Python читает байты видео с диска, а JPype преобразует их в массив байтов Java перед добавлением видео в презентацию.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video)

    presentation.save("embedded_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Вы также можете передать путь к локальному видео напрямую в метод [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame). Этот пример внедряет видео на первый слайд новой презентации. Видео должно оставаться доступным до сохранения презентации.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Создание видеокадра с видео из веб‑источника**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) поддерживает онлайн‑видео в презентациях. Вы можете создать видеокадр, который ссылается на онлайн‑видео, например на видео YouTube.

Этот пример добавляет ссылку на видео YouTube и миниатюру на первый слайд. Замените идентификатор видео, чтобы использовать другое видео. Метод [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) запрашивает автоматическое воспроизведение. Скачивание миниатюры и воспроизведение видео требуют доступа к Интернету. Средство просмотра презентаций также должно поддерживать воспроизведение онлайн‑видео.

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_id = "aqz-KE-bpKQ"
    video_url = "https://www.youtube.com/embed/" + video_id
    video_frame = slide.getShapes().addVideoFrame(10, 10, 427, 240, video_url)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    thumbnail_url = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
    thumbnail = presentation.getImages().addImage(java_thumbnail_data)
    video_frame.getPictureFormat().getPicture().setImage(thumbnail)

    presentation.save("online_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Воспроизведение видео в полноэкранном режиме**

В обучающей презентации вы можете воспроизводить демонстрацию программного обеспечения в полноэкранном режиме, чтобы аудитория видела детали. Вызовите [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) с `True`, чтобы включить это поведение во время воспроизведения.

Этот пример открывает презентацию, находит первый [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) на первом слайде и включает полноэкранное воспроизведение. Входная презентация должна содержать хотя бы один слайд с существующим видеокадром на первом слайде.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setFullScreenMode(True)
            break

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Полноэкранное воспроизведение управляет тем, как отображается видео. Независимо от этого, [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) определяет, будет ли оно запускаться автоматически или по щелчку, а [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) управляет повторением. Чтобы выбрать поведение запуска, задайте режим воспроизведения как [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/). Пример сохраняет существующие настройки запуска и цикла.

## **Перемотка видео после воспроизведения**

В обучающей презентации возвращение демонстрационного видео к его началу делает его готовым к повторному воспроизведению. Вызовите [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) с `True`, чтобы вернуть видео к началу после завершения воспроизведения.

Этот пример открывает презентацию, находит первый [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) на первом слайде и включает перемотку. Он отключает зацикливание, чтобы воспроизведение могло завершиться, и задает запуск воспроизведения по щелчку. Входная презентация должна содержать хотя бы один слайд с существующим видеокадром на первом слайде.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame, VideoPlayModePreset

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setRewindVideo(True)
            shape.setPlayLoopMode(False)
            shape.setPlayMode(VideoPlayModePreset.OnClick)
            break

    presentation.save("rewind_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Перемотка возвращает видео к началу без повторного запуска. В отличие от этого, вызов [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) с `True` автоматически повторяет воспроизведение. Оставляйте зацикливание отключённым, когда нужно, чтобы видео закончилось и осталось готовым к повторному запуску. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) независимо управляет автоматическим или по‑клику запуском; в примере используется [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/), чтобы presenter контролировал момент начала воспроизведения. Устанавливайте режим воспроизведения после настройки цикла, как показано в примере. Перемотка работает независимо от [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode).

## **Обрезка видеокадра**

Используйте [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) и [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd), чтобы пропустить часть начала или конца видео во время воспроизведения. Оба значения указываются в миллисекундах. Обрезка меняет настройки воспроизведения без изменения внедрённых видеоданных.

**Установить параметры обрезки**

Этот пример внедряет локальное видео и пропускает первые 2,5 секунды и последнюю секунду во время воспроизведения. Используйте видео длиннее 3,5 секунды, чтобы оставался воспроизводимый фрагмент.

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

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Прочитать параметры обрезки**

Этот пример выводит значения обрезки первого видеокадра на первом слайде в миллисекундах. Презентация должна содержать хотя бы один слайд. Если на этом слайде нет видеокадра, ничего не будет выведено. Предыдущий пример выдаёт значения 2500 и 1000.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_trim.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            trim_from_start = shape.getTrimFromStart()
            trim_from_end = shape.getTrimFromEnd()
            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
finally:
    presentation.dispose()
```

## **Управление субтитрами видео**

Aspose.Slides позволяет управлять закрытыми субтитрами для видеокадров в презентациях PowerPoint. Субтитры хранятся в формате WebVTT и доступны через метод [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks).

### **Добавление субтитров к видеокадру**

Этот пример внедряет локальное видео и добавляет дорожку субтитров WebVTT с меткой English. Метки времени субтитров должны соответствовать видео. Сохранённая презентация включает как видео, так и его субтитры.

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

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Добавьте новую дорожку субтитров из файла WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Класс [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) также предоставляет перегрузку, позволяющую добавлять субтитры из потока.

### **Извлечение субтитров из видеокадра**

Этот пример сохраняет все дорожки субтитров из видеокадров на первом слайде в отдельные файлы WebVTT. Последовательные номера делают файлы уникальными. Консоль сообщает количество извлечённых дорожек. Презентация должна содержать хотя бы один слайд.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    track_count = 0
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                track_count += 1
                output_path = Path(f"captions_{track_count}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                output_path.write_bytes(caption_data)

    print(f"Caption tracks extracted: {track_count}")
finally:
    presentation.dispose()
```

Каждый объект [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) раскрывает идентификатор субтитров, метку, бинарные данные и текст субтитров как строку UTF‑8.

### **Удаление субтитров из видеокадра**

Этот пример удаляет все субтитры из видеокадра первой формы на первом слайде и сохраняет результат. Предполагается, что слайд и форма существуют и что форма является видеокадром.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_frame = slide.getShapes().get_Item(0)
    if isinstance(video_frame, VideoFrame):
        # Удалить все субтитры из видеокадра.
        video_frame.getCaptionTracks().clear()
        
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Если нужно удалить только одну дорожку субтитров, используйте методы [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) или [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) вместо [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear).

### **Поиск субтитров видео**

[Captions.getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) возвращает полную дорожку WebVTT, включая заголовок, строки времени и текст субтитров. Вы можете искать субтитры в памяти, чтобы найти фразу и её временную метку. Например, английская дорожка на слайде 2 может содержать следующий текст.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Этот пример открывает `captioned_media.pptx` и использует [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) для чтения дорожек каждого верхнеуровневого видеокадра на всех слайдах. В простом текстовом cue строка времени содержит `-->`, а пустая строка завершает cue. Для каждой субтитровой дорожки, содержащей «café» в любом регистре, пример выводит номер слайда, метку дорожки, оригинальную строку времени и полные субтитры.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("captioned_media.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, VideoFrame):
                continue
            for track in shape.getCaptionTracks():
                track_text = str(track.getDataAsString())
                lines = iter(track_text.splitlines())
                for timing in lines:
                    if "-->" not in timing:
                        continue
                    caption_lines = []
                    for line in lines:
                        if not line:
                            break
                        caption_lines.append(line)
                    caption = "\n".join(caption_lines)
                    if "café" in caption.casefold():
                        print(f"Slide {slide.getSlideNumber()} | {track.getLabel()} | {timing}")
                        print(caption)
finally:
    presentation.dispose()
```

Поиск «café» дает одно совпадение для образцовой дорожки. Поиск исключает заголовок дорожки и сохраняет настройки времени и разрывы строк в выводе.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Извлечение видео со слайда**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать видео, внедрённые в презентации.

Этот пример извлекает внедрённые видео со всех слайдов в отдельные пронумерованные бинарные файлы. Связанные видео пропускаются, так как они не содержат встроенных данных. Консоль выводит тип MIME каждого видео и общее их количество. Вывод использует общий расширение `.bin`; при необходимости измените его, чтобы соответствовать обнаруженному типу медиа.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("presentation_with_videos.pptx")
try:
    video_count = 0
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = Path(f"extracted_video_{video_count}.bin")
                video_data = bytes(video.getBinaryData())
                output_path.write_bytes(video_data)
                print(f"Video {video_count}: {video.getContentType()}")

    print(f"Embedded videos extracted: {video_count}")
finally:
    presentation.dispose()
```

## **FAQ**

**Какие параметры воспроизведения видео можно изменить для видеокадра?**

Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (авто или по щелчку) и [циклическим воспроизведением](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode). Эти возможности доступны через методы объекта [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/).

**Влияет ли добавление видео на размер файла PPTX?**

Да. При внедрении локального видео бинарные данные включаются в документ, поэтому размер презентации растёт пропорционально размеру файла. При ссылке на онлайн‑видео и добавлении миниатюры презентация хранит ссылку и изображение‑превью вместо видеоданных, поэтому увеличение размера обычно меньше.

**Можно ли заменить видео в существующем видеокадре, не меняя его позицию и размер?**

Да. Вы можете заменить [видеоконтент](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) внутри кадра, сохраняя геометрию формы; это частый сценарий обновления медиа в существующей раскладке.

**Можно ли определить тип содержимого (MIME) внедрённого видео?**

Да. Внедрённое видео имеет [тип содержимого](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType), который можно прочитать и использовать, например, при сохранении его на диск.