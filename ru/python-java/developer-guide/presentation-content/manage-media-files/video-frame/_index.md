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
- веб-источник
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Научитесь программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides for Python via Java. Быстрое руководство."
---
## **Введение**

Видео может помочь объяснить идеи и привлечь аудиторию. Aspose.Slides for Python via Java позволяет добавлять видеокадры на слайды, настраивать параметры воспроизведения, управлять субтитрами и извлекать встроенные видеоданные.

PowerPoint поддерживает локальные видеоролики и ссылки на онлайн‑видео, такие как видео YouTube.

Для представления видеоданных и видеокадров Aspose.Slides предоставляет классы [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/), [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) и другие соответствующие типы.

## **Создание встроенного видеокадра**

Если видеофайл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр, чтобы встроить видео в презентацию.

В этом примере локальное видео встраивается в первый слайд существующей презентации и сохраняется результат. Координаты и размеры кадра задаются в пунктах. Python читает байты видео с диска, а JPype преобразует их в массив байтов Java перед добавлением видео в презентацию.

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

Вы также можете передать локальный путь к видео напрямую в [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame). В этом примере видео встраивается в первый слайд новой презентации. Видео должно оставаться доступным до сохранения презентации.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

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

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) поддерживает онлайн‑видео в презентациях. Вы можете создать видеокадр, который ссылается на онлайн‑видео, например видео YouTube.

В этом примере добавляется ссылка на видео YouTube и миниатюра на первый слайд. Замените идентификатор видео, чтобы использовать другое видео. Метод [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) запрашивает автоматическое воспроизведение. Скачивание миниатюры и воспроизведение видео требуют доступа к Интернету. Просмотрщик презентаций также должен поддерживать воспроизведение онлайн‑видео.

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

В учебной презентации вы можете показать демонстрацию программного обеспечения в полноэкранном режиме, чтобы аудитория могла видеть детали. Вызовите [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) с `True`, чтобы включить это поведение во время воспроизведения.

В этом примере открывается презентация, находится первый [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) на первом слайде и включается полноэкранное воспроизведение. Исходная презентация должна содержать хотя бы один слайд с существующим видеокадром на первом слайде.

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

Полноэкранное воспроизведение управляет тем, как отображается видео. Независимо от этого, [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) определяет, будет ли воспроизведение начинаться автоматически или по щелчку, а [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) управляет повторением. Чтобы выбрать способ запуска, задайте режим воспроизведения [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/). Пример сохраняет существующие настройки начала и повторения.

## **Перемотка видео после воспроизведения**

В учебной презентации возврат демонстрационного видео в начало делает его готовым для повторного воспроизведения. Вызовите [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) с `True`, чтобы вернуть видео в начало после завершения воспроизведения.

В этом примере открывается презентация, находится первый [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) на первом слайде и включается перемотка. Он отключает повтор, чтобы воспроизведение могло завершиться, и устанавливает запуск воспроизведения по щелчку. Исходная презентация должна содержать хотя бы один слайд с существующим видеокадром на первом слайде.

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

Перемотка возвращает видео в начало без повторного запуска. Напротив, вызов [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) с `True` автоматически повторяет воспроизведение. Оставляйте повтор выключенным, когда необходимо, чтобы видео завершилось и было готово к повторному запуску. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) независимо управляет автоматическим запуском или запуском по щелчку; в этом примере используется [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/), чтобы презентер контролировал, когда начать воспроизведение. Устанавливайте режим воспроизведения после настройки повторения, как показано в примере. Перемотка работает независимо от [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode).

## **Обрезка видеокадра**

Используйте [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) и [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd), чтобы пропускать часть начала или конца видео во время воспроизведения. Оба значения указываются в миллисекундах. Обрезка меняет настройки воспроизведения без изменения встроенных видеоданных.

**Настройки обрезки**

В этом примере встраивается локальное видео и пропускаются первые 2,5 секунды и последняя секунда во время воспроизведения. Используйте видео длительностью более 3,5 секунд, чтобы остался воспроизводимый сегмент.

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

**Чтение настроек обрезки**

В этом примере выводятся значения обрезки первого видеокадра на первом слайде в миллисекундах. Презентация должна содержать как минимум один слайд. Если у этого слайда нет видеокадра, ничего не выводится. Предыдущий пример дает значения 2500 и 1000.

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

**Добавление субтитров к видеокадру**

В этом примере встраивается локальное видео и добавляется дорожка субтитров WebVTT с меткой English. Метки времени субтитров должны соответствовать видео. Сохранённая презентация содержит как видео, так и его субтитры.

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

    # Добавить новую дорожку субтитров из файла WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Класс [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) также предоставляет перегрузку, позволяющую добавлять субтитры из потока.

**Извлечение субтитров из видеокадра**

В этом примере все дорожки субтитров из видеокадров на первом слайде сохраняются в отдельные файлы WebVTT. Последовательные номера делают файлы вывода различимыми. Консоль выводит количество извлечённых дорожек. Презентация должна содержать как минимум один слайд.

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

Каждый объект [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) предоставляет идентификатор субтитров, метку, бинарные данные и текст субтитров в виде строки UTF-8.

**Удаление субтитров из видеокадра**

В этом примере удаляются все субтитры из видеокадра, находящегося в первой позиции фигуры на первом слайде, и сохраняется результат. Предполагается, что слайд и фигура существуют и что фигура является видеокадром.

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

Если необходимо удалить только одну дорожку субтитров, используйте методы [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) или [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) вместо [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear).

## **Извлечение видео со слайда**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать встроенные в презентацию видеоролики.

В этом примере извлекаются встроенные видеоролики со всех слайдов в отдельные нумерованные бинарные файлы. Связанные видео пропускаются, поскольку не содержат встроенных данных. Консоль выводит тип MIME каждого видео и общее количество. Вывод использует общее расширение `.bin`; при необходимости измените его в соответствии с указанным типом медиа.

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

## **Часто задаваемые вопросы**

**Какие параметры воспроизведения видео можно изменять для видеокадра?**

Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (авто или по щелчку) и [повтором](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode). Эти параметры доступны через методы объекта [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/).

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео двоичные данные включаются в документ, поэтому размер презентации увеличивается пропорционально размеру файла. При ссылке на онлайн‑видео и добавлении миниатюры презентация сохраняет только ссылку и изображение‑превью, а не видеоданные, поэтому увеличение размера обычно меньше.

**Можно ли заменить видео в существующем видеокадре, не меняя его положение и размер?**

Да. Вы можете заменить [видеоконтент](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) внутри кадра, сохраняя геометрию фигуры; это распространённый сценарий обновления медиа в существующей раскладке.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. Встроенное видео имеет [тип содержимого](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType), который можно прочитать и использовать, например, при сохранении его на диск.