---
title: У管理ление видеокадрами в презентациях на Python
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
description: "Узнайте, как программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET. Быстрое руководство."
---
## **Введение**

Видео может помочь объяснить идеи и привлечь аудиторию. Aspose.Slides for Python via .NET позволяет добавлять видеокадры на слайды, менять настройки воспроизведения, управлять субтитрами и извлекать встроенные видеоданные.

PowerPoint поддерживает локальные видео и ссылки на онлайн‑видео, такие как видео YouTube.

Для представления видеоданных и видеокадров Aspose.Slides предоставляет класс [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) , класс [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) и другие соответствующие типы.

## **Создание встроенного видеокадра**

Если видеофайл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр, чтобы встроить видео в презентацию.

В этом примере локальное видео встраивается на первый слайд существующей презентации и сохраняется результат. Координаты и размеры кадра указаны в пунктах. Поток остаётся открытым до завершения сохранения, потому что [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) удерживает его, пока презентация его использует.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

Вы также можете передать путь к локальному видео непосредственно в [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/). В этом примере видео встраивается на первый слайд новой презентации. Видео должно оставаться доступным до сохранения презентации.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **Создание видеокадра с видео из веб‑источника**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) поддерживает онлайн‑видео в презентациях. Вы можете создать видеокадр, который ссылается на онлайн‑видео, например, видео YouTube.

В этом примере добавляется ссылка на видео YouTube и миниатюра на первый слайд. Замените идентификатор видео, чтобы использовать другое видео. Параметр [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) задаёт автоматическое воспроизведение. Загрузка миниатюры и воспроизведение видео требуют доступа к интернету. Просмотрщик презентаций также должен поддерживать онлайн‑воспроизведение видео.

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

## **Воспроизведение видео в полноэкранном режиме**

В обучающей презентации вы можете воспроизводить демонстрацию программного обеспечения в полноэкранном режиме, чтобы аудитория могла видеть детали. Установите [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) в `True`, чтобы включить это поведение во время воспроизведения.

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

Полноэкранное воспроизведение управляет тем, как отображается видео. Независимо от этого, [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) управляет тем, начинается ли воспроизведение автоматически или по щелчку, а [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) — повторяется ли оно. Чтобы выбрать поведение запуска, задайте режим воспроизведения [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/). Пример сохраняет существующие настройки запуска и цикла.

## **Перемотка видео после воспроизведения**

В обучающей презентации возврат демонстрационного видео в начало готовит его к повторному воспроизведению. Установите [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) в `True`, чтобы вернуть видео в начало после завершения воспроизведения.

В этом примере открывается презентация, находится первый [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) на первом слайде и включается перемотка. Он отключает зацикливание, чтобы воспроизведение могло завершиться, и задаёт запуск по щелчку. Входная презентация должна содержать как минимум один слайд с существующим видеокадром на первом слайде.

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

Перемотка возвращает видео в начало без повторного запуска. В отличие от этого, включение [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) автоматически повторяет воспроизведение. Оставляйте зацикливание отключённым, когда нужно, чтобы видео закончилось и было готово к повторному запуску. [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) независимо контролирует автоматический или по‑щелчку старт; в этом примере используется [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/), чтобы презентатор сам выбирал, когда начать воспроизведение. Устанавливайте режим воспроизведения после настройки зацикливания, как показано в примере. Перемотка работает независимо от [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/).

## **Обрезка видеокадра**

Используйте [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) и [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) для пропуска части начала или конца видео во время воспроизведения. Обе величины задаются в миллисекундах. Обрезка меняет параметры воспроизведения без изменения встроенных видеоданных.

**Установка параметров обрезки**

В этом примере локальное видео встраивается и пропускаются первые 2,5 секунды и последняя секунда во время воспроизведения. Используйте видео длиной более 3,5 секунды, чтобы оставался воспроизводимый сегмент.

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

**Чтение параметров обрезки**

В этом примере выводятся значения обрезки первого видеокадра на первом слайде в миллисекундах. Презентация должна содержать как минимум один слайд. Если на этом слайде нет видеокадра, ничего не выводится. Предыдущий пример дает значения 2500 и 1000.

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

### **Добавление субтитров к видеокадру**

В этом примере локальное видео встраивается и добавляется дорожка субтитров WebVTT с меткой English. Временные метки субтитров должны соответствовать видео. Сохранённая презентация включает и видео, и его субтитры.

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

Класс [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) также предоставляет перегрузку, позволяющую добавить субтитры из потока.

### **Извлечение субтитров из видеокадра**

В этом примере все дорожки субтитров из видеокадров на первом слайде сохраняются в отдельные файлы WebVTT. Последовательные номера делают файлы различимыми. Консоль выводит количество извлечённых дорожек. Презентация должна содержать как минимум один слайд.

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

Каждый объект [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) раскрывает идентификатор субтитров, метку, двоичные данные и текст субтитров в виде строки UTF‑8.

### **Удаление субтитров из видеокадра**

В этом примере удаляются все субтитры из видеокадра, находящегося на первой позиции фигуры первого слайда, и результат сохраняется. Предполагается, что слайд и фигура существуют и что фигура является видеокадром.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Если нужно удалить только одну дорожку субтитров, используйте методы [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) или [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) вместо [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/).

### **Поиск субтитров видео**

[Captions.data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) возвращает всю дорожку WebVTT, включая заголовок, строки тайминга и текст субтитров. Например, английская дорожка на слайде 2 может содержать такой cue:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

В этом примере открывается `captioned_media.pptx` и читаются [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) каждого видеокадра верхнего уровня на всех слайдах. Для каждого простого текста cue находят строку тайминга, содержащую `-->`, и собирают строки субтитров до следующей пустой строки или конца дорожки. Выполняется поиск текста субтитров на наличие слова “café” без учёта регистра, и выводятся номер слайда, метка дорожки, оригинальная строка тайминга и полный субтитр для каждого совпадения.

```python
import aspose.slides as slides

with slides.Presentation("captioned_media.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.VideoFrame):
                continue

            for track in shape.caption_tracks:
                lines = iter(track.data_as_string.splitlines())
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
                        print(f"Slide {slide.slide_number} | {track.label} | {timing}")
                        print(caption)
```

Образцовая дорожка даёт одно совпадение. “Café” в заголовке находится вне текста субтитров, а вывод сохраняет настройку тайминга и обе строки субтитров.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Извлечение видео со слайда**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать встроенные в презентацию видео.

В этом примере из каждого слайда извлекаются встроенные видео в отдельные нумерованные бинарные файлы. Связанные видео пропускаются, так как у них нет встроенных данных. Консоль выводит тип MIME каждого видео и общее количество. Вывод использует обобщённое расширение `.bin`; при необходимости замените его на соответствующее типу медиа.

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

Вы можете управлять [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (авто или по щелчку) и [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). Эти параметры доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео бинарные данные включаются в документ, поэтому размер презентации увеличивается пропорционально размеру файла. При ссылке на онлайн‑видео и добавлении миниатюры презентация хранит лишь ссылку и изображение‑превью, а не сами видеоданные, поэтому увеличение размера обычно меньше.

**Можно ли заменить видео в существующем видеокадре, не меняя его положение и размер?**

Да. Вы можете заменить [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) внутри кадра, сохранив геометрию фигуры; это распространённый сценарий обновления медиа в уже существующей раскладке.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. Встроенное видео имеет [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/), который можно прочитать и использовать, например, при сохранении файла на диск.