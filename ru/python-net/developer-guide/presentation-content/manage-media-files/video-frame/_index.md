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
- веб‑источник
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Научитесь программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET. Быстрое руководство."
---

Хорошо размещённое видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлечённости аудитории.  

PowerPoint позволяет добавить видео на слайд презентации двумя способами:

* Добавить или встроить локальное видео (хранящееся на вашем компьютере)
* Добавить онлайн‑видео (из веб‑источника, например, YouTube).

Чтобы вы могли добавлять видео‑объекты в презентацию, Aspose.Slides предоставляет интерфейс [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/), интерфейс [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) и другие соответствующие типы.  

## **Создание встроенного видеокадра**

Если видеофайл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр для встраивания видео в презентацию.  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте объект [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) и передайте путь к видеофайлу для встраивания видео в презентацию.  
4. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) для создания кадра видео.  
5. Сохраните изменённую презентацию.  

Этот пример кода на Python показывает, как добавить локально хранимое видео в презентацию:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Получаем первый слайд и добавляем видеокадр
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Сохраняем презентацию на диск
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

В качестве альтернативы можно добавить видео, передав путь к файлу непосредственно в метод `add_video_frame(x, y, width, height, fname)`:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **Создание видеокадра с видео из веб‑источника**

Microsoft [PowerPoint 2013 и новее](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) поддерживают видео с YouTube в презентациях. Если нужное вам видео доступно онлайн (например, на YouTube), вы можете добавить его в презентацию по веб‑ссылке.  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте объект [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) и передайте ссылку на видео.  
4. Установите миниатюру для видеокадра.  
5. Сохраните презентацию.  

Этот пример кода на Python показывает, как добавить видео из веба на слайд PowerPoint‑презентации:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Добавляем видеокадр
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # Загружаем миниатюру
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())

with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Извлечение видео со слайда**

Помимо добавления видео в слайды, Aspose.Slides позволяет извлекать видео, встроенные в презентации.  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) для загрузки презентации, содержащей видео.  
2. Пройдите по всем объектам [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).  
3. Пройдите по всем объектам [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) в поисках [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).  
4. Сохраните видео на диск.  

Этот пример кода на Python показывает, как извлечь видео со слайда презентации:

```python
import aspose.slides as slides

# Создаёт объект Presentation, представляющий файл презентации
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

Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (авто или по щелчку) и [циклическим воспроизведением](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). Эти параметры доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).  

**Влияет ли добавление видео на размер файла PPTX?**  

Да. При встраивании локального видео бинарные данные включаются в документ, поэтому размер презентации растёт пропорционально размеру файла. При добавлении онлайн‑видео встраиваются только ссылка и миниатюра, поэтому увеличение размера меньше.  

**Можно ли заменить видео в существующем VideoFrame, не меняя его позицию и размер?**  

Да. Вы можете заменить [видеоконтент](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) внутри кадра, сохранив геометрию формы; это распространённый сценарий обновления медиа в существующей раскладке.  

**Можно ли определить тип содержимого (MIME) встроенного видео?**  

Да. Встроенное видео имеет [тип содержимого](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/), который можно прочитать и использовать, например, при сохранении его на диск.