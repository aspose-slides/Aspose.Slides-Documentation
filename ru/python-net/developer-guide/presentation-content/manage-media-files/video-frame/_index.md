---
title: Добавляйте видео в презентации на Python
linktitle: Видеокадр
type: docs
weight: 10
url: /ru/python-net/video-frame/
keywords:
- добавление видео
- создание видео
- встраивание видео
- извлечение видео
- получение видео
- видеокадр
- веб-источник
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как программно добавлять и извлекать видеокадры на слайдах PowerPoint и OpenDocument с использованием Aspose.Slides for Python via .NET. Краткое практическое руководство."
---

Хорошо размещенное видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлеченности вашей аудитории.

PowerPoint позволяет добавлять видео на слайд в презентации двумя способами:

* Добавить или встроить локальное видео (хранящееся на вашем компьютере)
* Добавить онлайн-видео (из веб-источника, такого как YouTube).

Для того чтобы вам было удобно добавлять видео (видеоуроки) в презентацию, Aspose.Slides предоставляет интерфейс [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/), интерфейс [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) и другие соответствующие типы.

## **Создать встроенный видеофрейм**

Если видеофайл, который вы хотите добавить на свой слайд, хранится локально, вы можете создать видеофрейм, чтобы встроить видео в вашу презентацию.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд через его индекс.
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) и передайте путь к видеофайлу для встраивания видео в презентацию.
1. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) для создания рамки для видео.
1. Сохраните измененную презентацию.

Этот код на Python показывает, как добавить видео, хранящееся локально, в презентацию:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Получаем первый слайд и добавляем видеофрейм
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Сохраняем презентацию на диск
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

В качестве альтернативы вы можете добавить видео, передав его путь к файлу напрямую в метод `add_video_frame(x, y, width, height, fname)`:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **Создать видеофрейм с видео из веб-источника**

Microsoft [PowerPoint 2013 и новее](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) поддерживает видео с YouTube в презентациях. Если видео, которое вы хотите использовать, доступно в интернете (например, на YouTube), вы можете добавить его в свою презентацию через веб-ссылку.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд через его индекс.
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) и передайте ссылку на видео.
1. Установите миниатюру для видеофрейма.
1. Сохраните презентацию.

Этот код на Python показывает, как добавить видео из интернета на слайд в презентации PowerPoint:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Добавляет видеофрейм
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

## **Извлечь видео со слайда**

Кроме добавления видео на слайды, Aspose.Slides позволяет извлекать видео, встроенные в презентации.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), чтобы загрузить презентацию, содержащую видео.
2. Проитерируйте все объекты [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
3. Проитерируйте все объекты [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/), чтобы найти [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).
4. Сохраните видео на диск.

Этот код на Python показывает, как извлечь видео из презентации на слайде:

```python
import aspose.slides as slides

# Создает объект Presentation, который представляет файл презентации
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```