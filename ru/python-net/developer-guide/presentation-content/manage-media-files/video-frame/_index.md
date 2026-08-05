---
title: Добавление видео в презентации на Python
linktitle: Видеокадр
type: docs
weight: 10
url: /ru/python-net/video-frame/
keywords:
- добавить видео
- создать видео
- встроить видео
- извлечь видео
- получить видео
- видеокадр
- веб-источник
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET. Краткое практическое руководство."
---
## **Введение**

Хорошо размещённое видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлечённости аудитории. 

PowerPoint позволяет добавлять видео на слайд презентации двумя способами:

* Добавить или встроить локальное видео (хранящееся на вашем компьютере)
* Добавить онлайн‑видео (из веб‑источника, например YouTube).

Чтобы вы могли добавлять видео (объекты video) в презентацию, Aspose.Slides предоставляет классы [Video](https://reference.aspose.com/slides/ru/python-net/aspose.slides/video/) , [VideoFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/) и другие соответствующие типы. 

## **Создание встроенного видео‑кадра**

Если видеофайл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр для встраивания видео в презентацию. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу. 
3. Добавьте объект [Video](https://reference.aspose.com/slides/ru/python-net/aspose.slides/video/) и передайте путь к файлу видео для встраивания его в презентацию. 
4. Добавьте объект [VideoFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/) , чтобы создать кадр для видео.  
5. Сохраните изменённую презентацию. 

Этот код на Python показывает, как добавить локальное видео в презентацию:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Получает первый слайд и добавляет видеокадр
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Сохраняет презентацию на диск
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

В качестве альтернативы можно добавить видео, передав путь к файлу напрямую в метод `add_video_frame(x, y, width, height, fname)`:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```


## **Создание видеокадра с видео из веб‑источника**

Новые версии Microsoft [PowerPoint](https://support.microsoft.com/en-us/office/insert-a-video-from-youtube-or-another-site-8340ec69-4cee-4fe1-ab96-4849154bc6db) поддерживают онлайн‑видео в презентациях. Если нужное вам видео доступно в интернете (например, на YouTube), вы можете добавить его в презентацию по веб‑ссылке.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу. 
3. Добавьте объект [Video](https://reference.aspose.com/slides/ru/python-net/aspose.slides/video/) и передайте ссылку на видео.
4. Установите миниатюру для видеокадра. 
5. Сохраните презентацию. 

Этот код на Python показывает, как добавить видео из интернета на слайд в презентации PowerPoint:

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

## **Обрезка видеокадра**

Aspose.Slides позволяет контролировать, какая часть видео воспроизводится, задавая значения trim‑from‑start и trim‑from‑end через [VideoFrame.trim_from_start](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/trim_from_start/) и [VideoFrame.trim_from_end](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/trim_from_end/). Оба значения указываются в миллисекундах и определяют, сколько времени пропускается с начала и конца видео соответственно. Эти настройки меняют параметры воспроизведения видео в презентации; они не обрезают и иным способом не изменяют бинарные данные встроенного видео.

**Установка параметров обрезки**

Чтобы создать видеокадр и задать ему параметры обрезки:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) .
2. Добавьте объект [Video](https://reference.aspose.com/slides/ru/python-net/aspose.slides/video/) в презентацию.
3. Добавьте объект [VideoFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/) на слайд.
4. Установите значения trim‑from‑start и trim‑from‑end через [VideoFrame.trim_from_start](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/trim_from_start/) и [VideoFrame.trim_from_end](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/trim_from_end/) .
5. Сохраните изменённую презентацию.

В следующем примере кода пропускаются первые 2,5 секунды и последняя секунда встроенного видео при воспроизведении:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)

    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**Чтение параметров обрезки**

Чтобы просмотреть существующие параметры обрезки, загрузите презентацию, найдите объект [VideoFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/) среди фигур на первом слайде и прочитайте значения через [VideoFrame.trim_from_start](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/trim_from_start/) и [VideoFrame.trim_from_end](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/trim_from_end/) .

В следующем примере кода находится первый видеокадр на первом слайде и выводятся его параметры обрезки в миллисекундах:

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            video_frame = shape
            trim_from_start = video_frame.trim_from_start
            trim_from_end = video_frame.trim_from_end

            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
```

## **Управление субтитрами видео**

Aspose.Slides позволяет управлять закрывающими субтитрами для видеокадров в презентациях PowerPoint. Субтитры хранятся в формате WebVTT и доступны через свойство [VideoFrame.caption_tracks](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/caption_tracks/) .

**Добавление субтитров к видеокадру**

Чтобы добавить субтитры к видеокадру:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) .
2. Добавьте видео в презентацию.
3. Добавьте объект [VideoFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/) на слайд.
4. Используйте [CaptionsCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/captionscollection/) , возвращаемую через [caption_tracks](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/caption_tracks/) , чтобы добавить дорожку субтитров в формате WebVTT.
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

**Извлечение субтитров из видеокадра**

Чтобы извлечь субтитры из видеокадра:

1. Загрузите презентацию, содержащую видео.
2. Найдите целевой объект [VideoFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/) .
3. Пройдитесь по коллекции [caption_tracks](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/caption_tracks/) .
4. Сохраните каждую дорожку субтитров в файл с расширением `.vtt` .

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

Каждый объект [Captions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/captions/) раскрывает идентификатор субтитра, метку, бинарные данные и текст субтитра в виде строки UTF-8.

**Удаление субтитров из видеокадра**

Чтобы удалить субтитры из видеокадра:

1. Загрузите презентацию, содержащую видео.
2. Получите целевой объект [VideoFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/) .
3. Удалите дорожки субтитров из [CaptionsCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/captionscollection/) .
4. Сохраните изменённую презентацию.

Следующий код показывает, как удалить все субтитры из видеокадра:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # тип: slides.VideoFrame

    # Удаляет все субтитры из видеокадра.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Если необходимо удалить только одну дорожку субтитров, используйте методы [remove](https://reference.aspose.com/slides/ru/python-net/aspose.slides/captionscollection/remove/) или [remove_at](https://reference.aspose.com/slides/ru/python-net/aspose.slides/captionscollection/remove_at/) вместо [clear](https://reference.aspose.com/slides/ru/python-net/aspose.slides/captionscollection/clear/) .

## **Извлечение видео со слайда**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать видео, встроенное в презентации.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) , чтобы загрузить презентацию, содержащую видео. 
2. Пройдитесь по всем объектам [Slide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/) .
3. Пройдитесь по всем объектам [Shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/) в поиске [VideoFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/) . 
4. Сохраните видео на диск.

Этот код на Python показывает, как извлечь видео со слайда презентации:

```python
import aspose.slides as slides

# Создает объект Presentation, представляющий файл презентации
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

Можно управлять [режимом воспроизведения](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/play_mode/) (авто или по щелчку) и [цикличностью](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/play_loop_mode/) . Эти варианты доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/) .

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео бинарные данные включаются в документ, поэтому размер презентации растёт пропорционально размеру файла. При добавлении онлайн‑видео встраиваются только ссылка и миниатюра, поэтому увеличение объёма меньше.

**Могу ли я заменить видео в существующем VideoFrame, не меняя его положение и размер?**

Да. Можно заменить [видеоконтент](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/embedded_video/) внутри кадра, сохранив геометрию фигуры; это типичная ситуация при обновлении медиа в уже существующей раскладке.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. Встроенное видео имеет [тип содержимого](https://reference.aspose.com/slides/ru/python-net/aspose.slides/video/content_type/) , который можно прочитать и использовать, например, при сохранении на диск.