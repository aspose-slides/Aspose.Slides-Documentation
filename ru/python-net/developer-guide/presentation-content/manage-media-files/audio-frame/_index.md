---
title: Управление аудио в презентациях с использованием Python
linktitle: Аудио‑кадр
type: docs
weight: 10
url: /ru/python-net/audio-frame/
keywords:
- добавить аудио
- встроить аудио
- аудио‑кадр
- аудиофайл
- свойства аудио
- извлечь аудио
- получить аудио
- изменить аудио
- параметры воспроизведения
- режим воспроизведения
- воспроизведение на всех слайдах
- зацикливание до остановки
- скрыть во время показа
- перемотать после воспроизведения
- громкость аудио
- изображение по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Легко добавляйте, извлекайте и управляйте аудио‑кадрами в PPT, PPTX и ODP с помощью Aspose.Slides for Python via .NET. Исследуйте примеры кода и улучшайте свои презентации уже сегодня."
---
## **Создать аудио‑кадры**

Aspose.Slides for Python via .NET позволяет добавлять аудиофайлы на слайды. Аудиофайлы встраиваются в слайды как аудио‑кадры. 

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Загрузите поток аудиофайла, который хотите встроить в слайд.
4. Добавьте встроенный аудио‑кадр (содержащий аудиофайл) на слайд.
5. Установите [PlayMode](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audioplaymodepreset) и `Volume`, доступные через объект [IAudioFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audioframe/).
6. Сохраните изменённую презентацию.

Этот пример кода на Python показывает, как добавить встроенный аудио‑кадр на слайд:

```python
import aspose.slides as slides

# Создайте экземпляр класса презентации, представляющего файл презентации
with slides.Presentation() as pres:
    # Получает первый слайд
    sld = pres.slides[0]

    # Загружает wav‑звуковой файл в поток
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Добавляет аудио‑кадр
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Устанавливает режим воспроизведения и громкость аудио
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # Записывает файл PowerPoint на диск
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Изменить миниатюру аудио‑кадра**

При добавлении аудиофайла в презентацию он отображается как кадр со стандартным изображением по умолчанию (см. изображение в разделе ниже). Вы можете изменить миниатюру аудио‑кадра (установить своё изображение).

Этот пример кода на Python показывает, как изменить миниатюру или превью‑изображение аудио‑кадра:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавляет аудио‑кадр на слайд с указанными позицией и размером.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # Добавляет изображение в ресурсы презентации.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # Устанавливает изображение для аудио‑кадра.
        audioFrame.picture_format.picture.image = audioImage
        
        #Сохраняет изменённую презентацию на диск
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Изменить параметры воспроизведения аудио**

Aspose.Slides for Python via .NET позволяет менять параметры, управляющие воспроизведением аудио. Например, можно отрегулировать громкость, задать зацикливание или скрыть значок аудио.

Область **Audio Options** в Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Параметры PowerPoint **Audio Options**, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audioframe/):

- **Start** — выпадающий список соответствует свойству [AudioFrame.play_mode](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audioframe/play_mode/) 
- **Volume** — соответствует свойству [AudioFrame.volume](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audioframe/volume/) 
- **Play Across Slides** — соответствует свойству [AudioFrame.play_across_slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audioframe/play_across_slides/) 
- **Loop until Stopped** — соответствует свойству [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audioframe/play_loop_mode/) 
- **Hide During Show** — соответствует свойству [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audioframe/hide_at_showing/) 
- **Rewind after Playing** — соответствует свойству [AudioFrame.rewind_audio](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audioframe/rewind_audio/) 

Параметры PowerPoint **Editing**, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audioframe/):

- **Fade In** — соответствует свойству [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audioframe/fade_in_duration/) 
- **Fade Out** — соответствует свойству [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audioframe/fade_out_duration/) 
- **Trim Audio Start Time** — соответствует свойству [AudioFrame.trim_from_start](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audioframe/trim_from_start/) 
- **Trim Audio End Time** — значение равно длительности аудио минус значение свойства [AudioFrame.trim_from_end](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audioframe/trim_from_end/) 

Ползунок **Volume control** на панели управления аудио в PowerPoint соответствует свойству [AudioFrame.volume_value](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audioframe/volume_value/). Он позволяет менять громкость аудио в процентах.

Как изменить параметры воспроизведения аудио:

1. [Создайте](#create-audio-frame) или получите аудио‑кадр.
2. Установите новые значения нужных свойств аудио‑кадра.
3. Сохраните изменённый файл PowerPoint.

Этот пример кода на Python демонстрирует операцию, в которой изменяются параметры аудио:

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Получает форму AudioFrame
    audioFrame = pres.slides[0].shapes[0]

    # Устанавливает режим воспроизведения на воспроизведение по щелчку
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Устанавливает громкость на Низкую
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Устанавливает воспроизведение аудио на всех слайдах
    audioFrame.play_across_slides = True

    # Отключает зацикливание аудио
    audioFrame.play_loop_mode = False

    # Скрывает AudioFrame во время показа
    audioFrame.hide_at_showing = True

    # Перематывает аудио к началу после воспроизведения
    audioFrame.rewind_audio = True

    # Сохраняет файл PowerPoint на диск
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

Этот пример кода на Python показывает, как добавить новый аудио‑кадр со встроенным аудио, обрезать его и задать длительности затухания:

```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # Устанавливает смещение начала обрезки в 1.5 секунды
    audio_frame.trim_from_start = 1500.0
    # Устанавливает смещение конца обрезки в 2 секунды
    audio_frame.trim_from_end = 2000.0

    # Устанавливает длительность плавного появления в 200 мс
    audio_frame.fade_in_duration = 200.0
    # Устанавливает длительность плавного затухания в 500 мс
    audio_frame.fade_out_duration = 500.0

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

Следующий фрагмент кода демонстрирует, как получить аудио‑кадр со встроенным аудио и установить его громкость на 85 %:

```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Получает форму аудио‑кадра
    audio_frame = pres.slides[0].shapes[0]

    # Устанавливает громкость аудио на 85%
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Управление субтитрами аудио**

Aspose.Slides позволяет добавлять закрытые субтитры к аудио‑кадру через свойство [caption_tracks](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audioframe/caption_tracks/). Это свойство возвращает объект [CaptionsCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/captionscollection/), который даёт возможность добавлять треки WebVTT, перебрать существующие треки и удалять их при необходимости.

**Добавить субтитры к аудио**

Используйте свойство [caption_tracks](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audioframe/caption_tracks/), чтобы привязать один или несколько треков субтитров к аудио‑кадру. В примере ниже аудиофайл добавляется на слайд, после чего из файла `.vtt` загружается новый трек субтитров.

```py
with slides.Presentation() as presentation:
    with open("audio.mp3", "rb") as audio_stream:
        audio = presentation.audios.add_audio(audio_stream.read())

    slide = presentation.slides[0]
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio)

    # Добавьте новый трек субтитров из файла WebVTT.
    audio_frame.caption_tracks.add("New track", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

**Извлечь субтитры аудио**

Можно перебрать треки субтитров, связанные с аудио‑кадром, и сохранить их как файлы `.vtt`. Каждый трек предоставляет свои бинарные данные и уникальный идентификатор, который можно использовать при экспорте субтитров.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            audio_frame = shape
            for caption_track in audio_frame.caption_tracks:
                # Сохраните трек субтитров как файл .vtt.
                with open(f"{caption_track.caption_id}.vtt", "wb") as track_stream:
                    track_stream.write(caption_track.binary_data)
```

**Удалить субтитры аудио**

Чтобы удалить субтитры из аудио‑кадра, используйте методы, предоставляемые [CaptionsCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/captionscollection/), такие как [clear](https://reference.aspose.com/slides/ru/python-net/aspose.slides/captionscollection/clear/), [remove](https://reference.aspose.com/slides/ru/python-net/aspose.slides/captionscollection/remove/) или [remove_at](https://reference.aspose.com/slides/ru/python-net/aspose.slides/captionscollection/remove_at/). Пример ниже удаляет все треки субтитров из аудио‑кадра.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    audio_frame = slide.shapes[0]  # тип: slides.AudioFrame

    # Удалите все треки субтитров из аудио‑кадра.
    audio_frame.caption_tracks.clear()

    presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

## **Извлечение аудио**
Aspose.Slides for Python via .NET позволяет извлекать звук, используемый в переходах слайд‑шоу. Например, можно извлечь звук, применённый к конкретному слайду.

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) и загрузите презентацию, содержащую аудио.
2. Получите ссылку на нужный слайд по его индексу.
3. Получите доступ к переходам слайд‑шоу для этого слайда.
4. Извлеките звук в виде байтовых данных.

Этот пример кода на Python показывает, как извлечь аудио, используемое в слайде:

```python
import aspose.slides as slides

#with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # Получает нужный слайд
    slide = pres.slides[0]  

    # Получает эффекты перехода слайд‑шоу для слайда
    transition = slide.slide_show_transition

    #Извлекает звук в массив байтов
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```

## **FAQ**

**Можно ли использовать один и тот же аудио‑ресурс на нескольких слайдах без увеличения размера файла?**

Да. Добавьте аудио один раз в общую [коллекцию аудио](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/audios/) презентации и создайте дополнительные аудио‑кадры, которые ссылаются на этот существующий ресурс. Это предотвращает дублирование мультимедийных данных и сохраняет размер презентации под контролем.

**Можно ли заменить звук в существующем аудио‑кадре, не пересоздавая форму?**

Да. Для связанного звука обновите [link path](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audioframe/link_path_long/), чтобы он указывал на новый файл. Для встроенного звука замените объект [embedded audio](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audioframe/embedded_audio/) другим из [коллекции аудио](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/audios/) презентации. Форматирование кадра и большинство настроек воспроизведения останутся прежними.

**Меняется ли фактический аудиофайл в презентации при обрезке?**

Нет. Обрезка изменяет только границы воспроизведения. Исходные байты аудио остаются нетронутыми и доступны через встроенный аудио‑объект или коллекцию аудио презентации.