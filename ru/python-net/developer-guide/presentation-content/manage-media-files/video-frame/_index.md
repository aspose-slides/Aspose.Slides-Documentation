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

Правильно размещённое видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлечённости аудитории. 

PowerPoint позволяет добавить видео на слайд в презентации двумя способами:

* Добавить или встроить локальное видео (хранящееся на вашем компьютере)
* Добавить онлайн‑видео (из веб‑источника, например YouTube).

Чтобы добавить видео (объекты video) в презентацию, Aspose.Slides предоставляет классы [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) , [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) и другие соответствующие типы. 

## **Создать встроенный видеокадр**

Если видеофайл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр, чтобы встроить видео в презентацию. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу. 
3. Добавьте объект [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) , передав путь к видеофайлу, чтобы встроить видео в презентацию. 
4. Добавьте объект [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) , чтобы создать кадр для видео.  
5. Сохраните изменённую презентацию. 

Этот пример на Python показывает, как добавить локальное видео в презентацию:
```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Получает первый слайд и добавляет видеокадр
        # Сохраняет презентацию на диск
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```


Кроме того, вы можете добавить видео, передав путь к файлу напрямую в метод `add_video_frame(x, y, width, height, fname)`:
``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```



## **Создать видеокадр с видео из веб‑источника**

Microsoft [PowerPoint 2013 и новее](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) поддерживает видео YouTube в презентациях. Если нужное вам видео доступно онлайн (например, на YouTube), вы можете добавить его в презентацию по веб‑ссылке. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу. 
3. Добавьте объект [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) , передав ссылку на видео.
4. Установите миниатюру для видеокадра. 
5. Сохраните презентацию. 

Этот пример на Python показывает, как добавить видео из веба на слайд в презентации PowerPoint:
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


## **Извлечь видео со слайда**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать встроенные в презентации видео.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) , чтобы загрузить презентацию, содержащую видео. 
2. Пройдите по всем объектам [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) .
3. Пройдите по всем объектам [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) , чтобы найти [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) .
4. Сохраните видео на диск.

Этот пример на Python показывает, как извлечь видео со слайда презентации:
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

Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (авто или по щелчку) и [повторением](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). Эти параметры доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) .

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео двоичные данные включаются в документ, поэтому размер презентации увеличивается пропорционально размеру файла. При добавлении онлайн‑видео встраивается ссылка и миниатюра, поэтому увеличение размера меньше.

**Можно ли заменить видео в существующем VideoFrame, не меняя его позицию и размеры?**

Да. Вы можете заменить [видеоконтент](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) , находящийся во фрейме, сохранив геометрию фигуры; это распространённый сценарий обновления медиа в существующей раскладке.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. У встроенного видео есть [тип содержимого](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) , который можно прочитать и использовать, например при сохранении на диск.