---
title: Управление видеокадрами в презентациях на Python
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
description: "Изучите, как программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET. Быстрое руководство."
---
## **Введение**

Видео может помочь объяснить идеи и заинтересовать аудиторию. Aspose.Slides for Python via .NET позволяет добавлять видеокадры на слайды, настраивать параметры воспроизведения, управлять субтитрами и извлекать встроенные видеоданные.

PowerPoint поддерживает локальные видео и ссылки на онлайн‑видео, такие как видео YouTube.

Для представления видеоданных и видеокадров Aspose.Slides предоставляет класс [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/), класс [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) и другие соответствующие типы.

## **Создать встроенный видеокадр**

Если видеофайл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр, чтобы встроить видео в презентацию.

В этом примере локальное видео встраивается на первый слайд существующей презентации и сохраняется результат. Координаты и размеры кадра указаны в пунктах. Поток остаётся открытым до завершения сохранения, потому что [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) удерживает его, пока презентация использует его.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

Вы также можете передать путь к локальному видео напрямую в [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/). В этом примере видео встраивается на первый слайд новой презентации. Видео должно оставаться доступным до сохранения презентации.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **Создать видеокадр с видео из веб‑источника**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) поддерживает онлайн‑видео в презентациях. Вы можете создать видеокадр, который ссылается на онлайн‑видео, например, видео YouTube.

В этом примере добавляются ссылка на видео YouTube и миниатюра на первый слайд. Замените идентификатор видео, чтобы использовать другое видео. Параметр [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) запрашивает автоматическое воспроизведение. Загрузка миниатюры и воспроизведение видео требуют доступа к интернету. Просмотрщик презентаций также должен поддерживать воспроизведение онлайн‑видео.

```python
from urllib.request import urlopen
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    video_id = "aqz-KE-bpKQ"
    video_url = f"https://www.youtube.com/embed/{video_id}"
    video_frame = slide.shapes.add_video_frame(10, 10, 427, 240, video_url)
    video_frame.play_mode = slides.VideoPlayModePreset.AUTO

    thumbnail_url = f"https://img.youtube.com/vi/{video_id}/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    thumbnail = presentation.images.add_image(thumbnail_data)
    video_frame.picture_format.picture.image = thumbnail

    presentation.save("online_video.pptx", slides.export.SaveFormat.PPTX)
```

## **Воспроизвести видео в полноэкранном режиме**

В учебной презентации вы можете воспроизводить демонстрацию программного обеспечения в полноэкранном режиме, чтобы аудитория могла увидеть детали. Установите [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) в `True`, чтобы включить это поведение во время воспроизведения.

В этом примере открывается презентация, находится первый [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) на первом слайде и включается полноэкранное воспроизведение. Входная презентация должна содержать как минимум один слайд с существующим видеокадром на первом слайде.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.full_screen_mode = True
            break

    presentation.save("full_screen_video.pptx", slides.export.SaveFormat.PPTX)
```

Полноэкранное воспроизведение управляет отображением видео. Независимо от этого, [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) определяет, начинается ли воспроизведение автоматически или по щелчку, а [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) управляет повторением. Чтобы выбрать поведение при запуске, установите режим воспроизведения на [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/). Пример сохраняет существующие настройки запуска и цикла.

## **Перемотать видео после воспроизведения**

В учебной презентации возвращение демонстрационного видео к началу готовит его к повторному воспроизведению презентером. Установите [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) в `True`, чтобы вернуть видео к началу после завершения воспроизведения.

В этом примере открывается презентация, находится первый [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) на первом слайде и включается перемотка. Отключается зацикливание, чтобы воспроизведение могло завершиться, и устанавливается запуск воспроизведения по щелчку. Входная презентация должна содержать как минимум один слайд с существующим видеокадром на первом слайде.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.rewind_video = True
            shape.play_loop_mode = False
            shape.play_mode = slides.VideoPlayModePreset.ON_CLICK
            break

    presentation.save("rewind_video.pptx", slides.export.SaveFormat.PPTX)
```

Перемотка возвращает видео к началу без повторного запуска. Напротив, включение [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) автоматически повторяет воспроизведение. Отключайте зацикливание, когда хотите, чтобы видео завершилось и было готово к повторному воспроизведению. [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) независимо управляет автоматическим запуском или запуском по щелчку; в этом примере используется [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/), чтобы презентер контролировал начало воспроизведения. Устанавливайте режим воспроизведения после настройки цикла, как показано в примере. Перемотка работает независимо от [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/).

## **Обрезать видеокадр**

Используйте [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) и [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/), чтобы пропустить часть начала или конца видео во время воспроизведения. Оба значения указаны в миллисекундах. Обрезка изменяет параметры воспроизведения без изменения встроенных видеоданных.

**Установить параметры обрезки**

В этом примере локальное видео встраивается, и во время воспроизведения пропускаются первые 2,5 секунды и последняя секунда. Используйте видео длинее 3,5 секунды, чтобы оставался воспроизводимый сегмент.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)
    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**Прочитать параметры обрезки**

В этом примере выводятся значения обрезки первого видеокадра на первом слайде в миллисекундах. Презентация должна содержать минимум один слайд. Если у этого слайда нет видеокадра, ничего не выводится. Предыдущий пример дает значения 2500 и 1000.

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            print(f"Trim from start: {shape.trim_from_start} ms")
            print(f"Trim from end: {shape.trim_from_end} ms")
            break
```

## **Управление субтитрами видео**

Aspose.Slides позволяет управлять закрытыми субтитрами для видеокадров в презентациях PowerPoint. Субтитры хранятся в формате WebVTT и доступны через свойство [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/).

**Добавить субтитры к видеокадру**

В этом примере локальное видео встраивается и добавляется дорожка субтитров WebVTT с меткой English. Временные метки субтитров должны соответствовать видео. Сохранённая презентация включает как видео, так и его субтитры.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

Класс [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) также предоставляет перегрузку, позволяющую добавлять субтитры из потока.

**Извлечь субтитры из видеокадра**

В этом примере все дорожки субтитров из видеокадров на первом слайде сохраняются как отдельные файлы WebVTT. Последовательные номера делают выходные файлы различимыми. Консоль выводит количество извлечённых дорожек. Презентация должна содержать минимум один слайд.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    track_count = 0
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                track_count += 1
                output_path = f"captions_{track_count}.vtt"
                with open(output_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))

    print(f"Caption tracks extracted: {track_count}")
```

Каждый объект [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) раскрывает идентификатор субтитров, метку, двоичные данные и текст субтитров как строку UTF-8.

**Удалить субтитры из видеокадра**

В этом примере удаляются все субтитры из видеокадра, который находится в первой позиции фигуры на первом слайде, и сохраняется результат. Предполагается, что слайд и фигура существуют, и что фигура является видеокадром.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Если необходимо удалить только одну дорожку субтитров, используйте методы [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) или [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) вместо [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/).

## **Извлечь видео со слайда**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать встроенные в презентацию видео.

В этом примере встроенные видео извлекаются с каждого слайда в отдельные нумерованные бинарные файлы. Связанные видео пропускаются, так как они не содержат встроенных данных. Консоль выводит тип MIME каждого видео и общее количество. Вывод использует общее расширение `.bin`; при необходимости измените его, чтобы соответствовать указанному типу медиа.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_videos.pptx") as presentation:
    video_count = 0
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.VideoFrame):
                video = shape.embedded_video
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = f"extracted_video_{video_count}.bin"
                with open(output_path, "wb") as video_stream:
                    video_stream.write(bytes(video.binary_data))
                print(f"Video {video_count}: {video.content_type}")

    print(f"Embedded videos extracted: {video_count}")
```

## **Часто задаваемые вопросы**

**Какие параметры воспроизведения видео можно изменить для видеокадра?**

Вы можете управлять [playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (авто или по щелчку) и [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). Эти параметры доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео двоичные данные включаются в документ, поэтому размер презентации увеличивается пропорционально размеру файла. При ссылке на онлайн‑видео и добавлении миниатюры презентация сохраняет только ссылку и изображение превью, а не данные видео, поэтому увеличение размера обычно меньше.

**Можно ли заменить видео в существующем видеокадре, не меняя его позицию и размер?**

Да. Вы можете заменить [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) внутри кадра, сохраняя геометрию фигуры; такой сценарий часто используется для обновления медиа в существующей раскладке.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. Встроенное видео имеет [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/), который можно прочитать и использовать, например, при сохранении на диск.