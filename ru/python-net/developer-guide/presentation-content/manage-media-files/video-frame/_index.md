---
title: Добавление видео в презентации на Python
linktitle: Видеокадр
type: docs
weight: 10
url: /ru/python-net/video-frame/
keywords:
- добавить видео
- создать видео
- вставить видео
- извлечь видео
- получить видео
- видеокадр
- веб-источник
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Научитесь программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET. Быстрое руководство."
---
Грамотно размещённое видео в презентации делает ваше сообщение более убедительным и повышает уровень вовлечённости аудитории. 

PowerPoint позволяет добавлять видео на слайд в презентации двумя способами:

* Добавить или вставить локальное видео (хранящееся на вашем компьютере)
* Добавить онлайн‑видео (из веб‑источника, например YouTube).

Чтобы вы могли добавлять видео (видеобъекты) в презентацию, Aspose.Slides предоставляет класс [Video](https://reference.aspose.com/slides/ru/python-net/aspose.slides/video/), класс [VideoFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/) и другие соответствующие типы. 

## **Создать встроенный видеокадр**

Если файл видео, который вы хотите добавить на слайд, находится локально, вы можете создать видеокадр, чтобы встроить видео в презентацию. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте объект [Video](https://reference.aspose.com/slides/ru/python-net/aspose.slides/video/) и передайте путь к файлу видео, чтобы встроить его в презентацию.  
4. Добавьте объект [VideoFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/), чтобы создать кадр для видео.  
5. Сохраните изменённую презентацию.  

Этот пример кода на Python показывает, как добавить локальное видео в презентацию:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Получает первый слайд и добавляет видеокадр
        # Сохраняет презентацию на диск
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

Кроме того, вы можете добавить видео, передав путь к файлу непосредственно в метод `add_video_frame(x, y, width, height, fname)`:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **Создать видеокадр с видео из веб‑источника**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) поддерживает видео YouTube в презентациях. Если нужное вам видео доступно онлайн (например, на YouTube), вы можете добавить его в презентацию по веб‑ссылке. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/)  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте объект [Video](https://reference.aspose.com/slides/ru/python-net/aspose.slides/video/) и передайте ссылку на видео.  
4. Установите миниатюру для видеокадра.  
5. Сохраните презентацию.  

Этот пример кода на Python показывает, как добавить видео из интернете на слайд в презентации PowerPoint:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Добавляет видеокадр
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # Загружает миниатюру
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Управление субтитрами видео**

Aspose.Slides позволяет управлять закрытыми субтитрами для видеокадров в презентациях PowerPoint. Субтитры хранятся в формате WebVTT и доступны через свойство [VideoFrame.caption_tracks](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/caption_tracks/).  

**Добавить субтитры к видеокадру**

Чтобы добавить субтитры к видеокадру:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).  
2. Добавьте видео в презентацию.  
3. Добавьте объект [VideoFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/) на слайд.  
4. Используйте объект [CaptionsCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/captionscollection/), возвращаемый свойством [caption_tracks](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/caption_tracks/), чтобы добавить дорожку субтитров WebVTT.  
5. Сохраните изменённую презентацию.  

Следующий код показывает, как добавить субтитры к видеокадру:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # Добавляет новую дорожку субтитров из файла WebVTT.
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

Класс [CaptionsCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/captionscollection/) также предоставляет перегрузку, позволяющую добавлять субтитры из потока.  

**Извлечь субтитры из видеокадра**

Чтобы извлечь субтитры из видеокадра:

1. Загрузите презентацию, содержащую видео.  
2. Найдите целевой объект [VideoFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/).  
3. Пройдитесь по коллекции [caption_tracks](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/caption_tracks/).  
4. Сохраните каждую дорожку субтитров в файл с расширением `.vtt`.  

Следующий код показывает, как извлечь субтитры из видеокадра:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # Сохраняет дорожку субтитров в файл WebVTT.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

Каждый объект [Captions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/captions/) раскрывает идентификатор субтитров, метку, бинарные данные и текст субтитров в виде строки UTF‑8.  

**Удалить субтитры из видеокадра**

Чтобы удалить субтитры из видеокадра:

1. Загрузите презентацию, содержащую видео.  
2. Получите целевой объект [VideoFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/).  
3. Удалите дорожки субтитров из [CaptionsCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/captionscollection/).  
4. Сохраните изменённую презентацию.  

Следующий код показывает, как удалить все субтитры из видеокадра:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # type: slides.VideoFrame

    # Удаляет все субтитры из видеокадра.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Если нужно удалить только одну дорожку субтитров, используйте методы [remove](https://reference.aspose.com/slides/ru/python-net/aspose.slides/captionscollection/remove/) или [remove_at](https://reference.aspose.com/slides/ru/python-net/aspose.slides/captionscollection/remove_at/) вместо [clear](https://reference.aspose.com/slides/ru/python-net/aspose.slides/captionscollection/clear/).  

## **Извлечь видео со слайда**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать встроенные в презентацию видео.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) для загрузки презентации, содержащей видео.  
2. Пройдитесь по всем объектам [Slide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/).  
3. Пройдитесь по всем объектам [Shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/) в поисках [VideoFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/).  
4. Сохраните видео на диск.  

Этот пример кода на Python показывает, как извлечь видео со слайда презентации:

```python
import aspose.slides as slides

# Создаёт объект Presentation, который представляет файл презентации
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **FAQ**

**Какие параметры воспроизведения видео можно изменить для VideoFrame?**

Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/play_mode/) (авто или по щелчку) и [цикличностью](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/play_loop_mode/). Эти параметры доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/).  

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео бинарные данные включаются в документ, поэтому размер презентации растёт пропорционально размеру файла. При добавлении онлайн‑видео встраиваются только ссылка и миниатюра, поэтому увеличение размера меньше.  

**Можно ли заменить видео в существующем VideoFrame, не меняя его позицию и размеры?**

Да. Вы можете заменить [video content](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/embedded_video/) внутри кадра, сохранив геометрию формы; это часто используется для обновления медиа в уже существующем макете.  

**Можно ли определить тип контента (MIME) встроенного видео?**

Да. Встроенное видео имеет [content type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/video/content_type/), который можно считать и использовать, например, при сохранении его на диск.