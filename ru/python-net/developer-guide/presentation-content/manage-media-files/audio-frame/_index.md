---
title: Управление аудио в презентациях с помощью Python
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
- цикл до остановки
- скрыть во время показа
- перемотка после воспроизведения
- громкость аудио
- изображение по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Легко добавлять, извлекать и управлять аудио‑кадрами в PPT, PPTX и ODP с помощью Aspose.Slides для Python через .NET. Изучайте примеры кода и улучшайте свои презентации уже сегодня."
---

## **Создание аудио‑кадров**

Aspose.Slides for Python via .NET позволяет добавлять аудиофайлы на слайды. Аудиофайлы встраиваются в слайды в виде аудио‑кадров. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Загрузите поток аудиофайла, который хотите встроить в слайд.
4. Добавьте встроенный аудио‑кадр (содержащий аудиофайл) на слайд.
5. Установите [PlayMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioplaymodepreset) и `Volume`, предоставляемые объектом [IAudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/).
6. Сохраните изменённую презентацию.

Этот пример кода на Python показывает, как добавить встроенный аудио‑кадр на слайд:
```python
import aspose.slides as slides

# Создайте экземпляр класса презентации, представляющего файл презентации
with slides.Presentation() as pres:
    # Получает первый слайд
    sld = pres.slides[0]

    # Загружает wav звуковой файл в поток
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Добавляет аудио‑кадр
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Устанавливает режим воспроизведения и громкость аудио
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # Записывает файл PowerPoint на диск
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Изменение миниатюры аудио‑кадра**

Когда вы добавляете аудиофайл в презентацию, он отображается как кадр со стандартным изображением по умолчанию (см. изображение в разделе ниже). Вы можете изменить миниатюру аудио‑кадра (установив желаемое изображение).

Этот пример кода на Python показывает, как изменить миниатюру или изображение предварительного просмотра аудио‑кадра:
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


## **Изменение параметров воспроизведения аудио**

Aspose.Slides for Python via .NET позволяет изменять параметры, управляющие воспроизведением или свойствами аудио. Например, вы можете отрегулировать громкость аудио, установить воспроизведение в цикле или даже скрыть значок аудио.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) properties:
- **Start** выпадающий список соответствует свойству [AudioFrame.play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/).
- **Volume** соответствует свойству [AudioFrame.volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/).
- **Play Across Slides** соответствует свойству [AudioFrame.play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/).
- **Loop until Stopped** соответствует свойству [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/).
- **Hide During Show** соответствует свойству [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/).
- **Rewind after Playing** соответствует свойству [AudioFrame.rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/).

PowerPoint **Editing** options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) properties:
- **Fade In** соответствует свойству [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/).
- **Fade Out** соответствует свойству [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/).
- **Trim Audio Start Time** соответствует свойству [AudioFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/).
- **Trim Audio End Time** значение равно длительности аудио минус значение свойства [AudioFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/).

Ползунок **Volume** на панели управления аудио в PowerPoint соответствует свойству [AudioFrame.volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/). Он позволяет изменять громкость аудио в процентах.

Вот как изменить параметры воспроизведения аудио:
1. [Создать](#create-audio-frame) или получить аудио‑кадр.
2. Установите новые значения свойств аудио‑кадра, которые необходимо изменить.
3. Сохраните изменённый файл PowerPoint.

Этот пример кода на Python демонстрирует операцию, в которой изменяются параметры аудио:
```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Получает форму AudioFrame
    audioFrame = pres.slides[0].shapes[0]

    # Устанавливает режим воспроизведения на «по щелчку»
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Устанавливает громкость на низкую
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Устанавливает воспроизведение аудио на всех слайдах
    audioFrame.play_across_slides = True

    # Отключает зацикливание аудио
    audioFrame.play_loop_mode = False

    # Скрывает AudioFrame во время показа
    audioFrame.hide_at_showing = True

    # Перематывает аудио в начало после воспроизведения
    audioFrame.rewind_audio = True

    # Сохраняет файл PowerPoint на диск
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```


Этот пример кода на Python показывает, как добавить новый аудио‑кадр со встроенным аудио, обрезать его и установить длительность затухания:
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

    # Устанавливает продолжительность плавного появления в 200 мс
    audio_frame.fade_in_duration = 200.0
    # Устанавливает продолжительность плавного исчезания в 500 мс
    audio_frame.fade_out_duration = 500.0

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```


Следующий пример кода показывает, как получить аудио‑кадр со встроенным аудио и установить его громкость на 85%:
```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Получает форму аудио‑кадра
    audio_frame = pres.slides[0].shapes[0]

    # Устанавливает громкость аудио на 85%
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Извлечение аудио**

Aspose.Slides for Python via .NET позволяет извлекать звук, используемый в переходах слайдшоу. Например, вы можете извлечь звук, использованный в конкретном слайде.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию, содержащую аудио.
2. Получите ссылку на соответствующий слайд по его индексу.
3. Получите переходы слайдшоу для этого слайда.
4. Извлеките звук в виде байтовых данных.

Этот пример кода на Python показывает, как извлечь аудио, использованное в слайде:
```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # Доступ к нужному слайду
    slide = pres.slides[0]  

    # Получает эффекты перехода слайд-шоу для слайда
    transition = slide.slide_show_transition

    #Извлекает звук в массив байтов
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```


## **FAQ**

**Могу ли я использовать один и тот же аудио‑файл на нескольких слайдах, не увеличивая размер файла?**

Да. Добавьте аудио один раз в общую [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) презентации и создайте дополнительные аудио‑кадры, которые ссылаются на этот существующий ресурс. Это предотвращает дублирование медиа‑данных и позволяет контролировать размер презентации.

**Могу ли я заменить звук в существующем аудио‑кадре, не воссоздавая форму?**

Да. Для связанного звука обновите [link path](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/), указав путь к новому файлу. Для встроенного звука замените объект [embedded audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) на другой из [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) презентации. Форматирование кадра и большинство настроек воспроизведения сохраняются.

**Изменяет ли обрезка исходные аудио‑данные, хранящиеся в презентации?**

Нет. Обрезка изменяет только границы воспроизведения. Исходные аудио‑байты остаются нетронутыми и доступны через встроенный аудио‑объект или коллекцию аудио презентации.