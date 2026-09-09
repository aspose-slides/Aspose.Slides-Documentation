---
title: Управление видеокадрами в презентациях с использованием Python
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
description: "Узнайте, как программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для Python через Java. Краткое практическое руководство."
---
## **Введение**

Хорошо размещённое видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлечённости аудитории.

PowerPoint позволяет добавить видео на слайд в презентации двумя способами:

* Добавить или встроить локальное видео (хранящееся на вашем компьютере)
* Добавить онлайн‑видео (из веб‑источника, например YouTube).

Чтобы добавить видео (объекты video) в презентацию, Aspose.Slides предоставляет класс [Video](https://reference.aspose.com/slides/ru/python-java/aspose.slides/video/) , класс [VideoFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/) и другие соответствующие типы.

## **Создание встроенных видеокадров**

Если видеофайл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр для встраивания видео в презентацию.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте объект [Video](https://reference.aspose.com/slides/ru/python-java/aspose.slides/video/) и передайте данные видеофайла, чтобы встроить видео в презентацию.
1. Добавьте объект [VideoFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/) , чтобы создать кадр для видео.
1. Сохраните изменённую презентацию.

Этот код на Python показывает, как добавить локально хранимое видео в презентацию:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    video_data = Path("Wildlife.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video)
    presentation.save("pres-with-video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

В качестве альтернативы вы можете добавить видео, передав путь к файлу напрямую в метод [addVideoFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addVideoFrame) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi")
finally:
    presentation.dispose()
```

## **Создание видеокадров с видео из веб‑источников**

Microsoft [PowerPoint 2013 и новее](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) поддерживает видео YouTube в презентациях. Если нужное вам видео доступно онлайн (например, на YouTube), вы можете добавить его в презентацию по веб‑ссылке.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте объект [VideoFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/) , передав ссылку на видео.
1. Установите миниатюру для видеокадра.
1. Сохраните презентацию.

Этот код на Python показывает, как добавить видео из веба на слайд в презентацию PowerPoint:

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

video_id = "Tj75Arhq5ho"
presentation = Presentation()
try:
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + video_id)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    # Загрузить миниатюру.
    thumbnail_uri = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    try:
        with urlopen(thumbnail_uri) as response:
            thumbnail_data = response.read()
        java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
        thumbnail = presentation.getImages().addImage(java_thumbnail_data)
        video_frame.getPictureFormat().getPicture().setImage(thumbnail)
    except OSError as error:
        print("Could not load the thumbnail:", error)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Обрезка видеокадра**

Aspose.Slides позволяет контролировать, какая часть видео будет воспроизводиться, задавая значения trim-from-start и trim-from-end через [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/#setTrimFromStart) и [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/#setTrimFromEnd) . Оба значения указываются в миллисекундах и определяют, сколько времени пропустить в начале и в конце видео соответственно. Эти настройки изменяют параметры воспроизведения видео в презентации; они не обрезают и не изменяют бинарные данные встроенного видео.

**Установка параметров обрезки**

Чтобы создать видеокадр и задать параметры обрезки:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) .
2. Добавьте объект [Video](https://reference.aspose.com/slides/ru/python-java/aspose.slides/video/) в презентацию.
3. Добавьте объект [VideoFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/) на слайд.
4. Задайте значения trim-from-start и trim-from-end с помощью [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/#setTrimFromStart) и [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/#setTrimFromEnd) .
5. Сохраните изменённую презентацию.

Следующий пример кода пропускает первые 2,5 секунды и последнюю секунду встроенного видео при воспроизведении:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)
    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Чтение параметров обрезки**

Чтобы просмотреть существующие параметры обрезки, загрузите презентацию, найдите объект [VideoFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/) среди фигур на первом слайде и считайте значения через [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/#getTrimFromStart) и [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/#getTrimFromEnd) .

Следующий пример кода находит первый видеокадр на первом слайде и выводит его параметры обрезки в миллисекундах:

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

Aspose.Slides позволяет управлять закрытыми субтитрами для видеокадров в презентациях PowerPoint. Субтитры хранятся в формате WebVTT и доступны через метод [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/#getCaptionTracks) .

**Добавление субтитров к видеокадру**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) .
2. Добавьте видео в презентацию.
3. Добавьте объект [VideoFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/) на слайд.
4. Используйте объект [CaptionsCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/captionscollection/) , возвращаемый методом [getCaptionTracks](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/#getCaptionTracks) , чтобы добавить дорожку субтитров WebVTT.
5. Сохраните изменённую презентацию.

Следующий код показывает, как добавить субтитры к видеокадру:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Добавить новую дорожку субтитров из файла WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Класс [CaptionsCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/captionscollection/) также предоставляет перегрузку, позволяющую добавить субтитры из потока.

**Извлечение субтитров из видеокадра**

1. Загрузите презентацию, содержащую видео.
2. Найдите целевой объект [VideoFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/) .
3. Пройдите по дорожкам субтитров в [CaptionsCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/captionscollection/) .
4. Сохраните каждую дорожку субтитров в файл с расширением `.vtt` .

Следующий код показывает, как извлечь субтитры из видеокадра:

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
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                # Сохранить дорожку субтитров в файл WebVTT.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

Каждый объект [Captions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/captions/) раскрывает идентификатор субтитра, метку, бинарные данные и текст субтитра в виде строки UTF‑8.

**Удаление субтитров из видеокадра**

1. Загрузите презентацию, содержащую видео.
2. Получите целевой объект [VideoFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/) .
3. Удалите дорожки субтитров из [CaptionsCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/captionscollection/) .
4. Сохраните изменённую презентацию.

Следующий код показывает, как удалить все субтитры из видеокадра:

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

Если необходимо удалить только одну дорожку субтитров, используйте методы [remove](https://reference.aspose.com/slides/ru/python-java/aspose.slides/captionscollection/#remove) или [removeAt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/captionscollection/#removeAt) вместо [clear](https://reference.aspose.com/slides/ru/python-java/aspose.slides/captionscollection/#clear) .

## **Извлечение видео из слайдов**

Кроме добавления видео в слайды, Aspose.Slides позволяет извлекать видео, встроенное в презентации.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) для загрузки презентации, содержащей видео.
2. Пройдите по всем объектам [Slide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/) .
3. Пройдите по всем объектам [Shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/) , чтобы найти [VideoFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/) .
4. Сохраните видео на диск.

Этот код на Python показывает, как извлечь видео со слайда презентации:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("VideoSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is not None:
                    content_type = str(video.getContentType())
                    file_extension = content_type.split("/", 1)[-1]
                    video_data = bytes(video.getBinaryData())
                    Path("testing2." + file_extension).write_bytes(video_data)
                else:
                    print("The video frame has no embedded video.")
finally:
    presentation.dispose()
```

## **FAQ**

**Какие параметры воспроизведения видео можно изменить для VideoFrame?**

Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/#setPlayMode) (авто или по щелчку) и [цикличностью](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/#setPlayLoopMode). Эти параметры доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/) .

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео его бинарные данные включаются в документ, поэтому размер презентации растёт пропорционально размеру файла. При добавлении онлайн‑видео в презентацию встраиваются только ссылка и миниатюра, поэтому увеличение размера значительно меньше.

**Можно ли заменить видео в существующем VideoFrame, не меняя его позицию и размер?**

Да. Вы можете заменить [видеоконтент](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/#setEmbeddedVideo) внутри кадра, сохранив геометрию фигуры; это типичный сценарий обновления медиа в уже существующей разметке.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. Встроенное видео имеет [тип содержимого](https://reference.aspose.com/slides/ru/python-java/aspose.slides/video/#getContentType), который можно считать и использовать, например, при сохранении его на диск.