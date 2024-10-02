---
title: Аудио Фрейм
type: docs
weight: 10
url: /ru/python-net/audio-frame/
keywords: "Добавить аудио, Аудио фрейм, Свойства аудио, Извлечь аудио, Python, Aspose.Slides для Python через .NET"
description: "Добавление аудио в презентацию PowerPoint на Python"
---

## **Создание Аудио Фрейма**
Aspose.Slides для Python через .NET позволяет добавлять аудиофайлы на слайды. Аудиофайлы встраиваются в слайды в виде аудиофреймов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Загрузите поток аудиофайла, который вы хотите встроить в слайд.
4. Добавьте встроенный аудиофрейм (содержащий аудиофайл) на слайд.
5. Установите [PlayMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioplaymodepreset) и `Volume`, предоставленные объектом [IAudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/).
6. Сохраните измененную презентацию.

Этот код на Python показывает, как добавить встроенный аудиофрейм на слайд:

```python
import aspose.slides as slides

# Создайте класс презентации, который представляет файл презентации
with slides.Presentation() as pres:
    # Получите первый слайд
    sld = pres.slides[0]

    # Загрузите wav аудиофайл в поток
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Добавьте Аудио Фрейм
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Установите режим воспроизведения и громкость аудио
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # Запишите файл PowerPoint на диск
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Изменение Миниатюры Аудио Фрейма**

Когда вы добавляете аудиофайл в презентацию, аудио отображается как рамка со стандартным изображением по умолчанию (см. изображение в разделе ниже). Вы можете изменить миниатюру аудиофрейма (установить свое предпочтительное изображение).

Этот код на Python показывает, как изменить миниатюру или изображение предварительного просмотра аудиофрейма:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавляет аудиофрейм на слайд с заданной позицией и размером.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # Добавьте изображение в ресурсы презентации.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # Установите изображение для аудиофрейма.
        audioFrame.picture_format.picture.image = audioImage
        
        # Сохраните измененную презентацию на диск
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Изменение Параметров Воспроизведения Аудио**

Aspose.Slides для Python через .NET позволяет изменять параметры, которые контролируют воспроизведение или свойства аудио. Например, вы можете настроить громкость аудио, установить его воспроизведение в цикле или даже скрыть значок аудио.

Панель **Параметры Аудио** в Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Параметры аудио PowerPoint, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/):
- Выпадающий список **Начало** в Попробный Параметры Аудио соответствует свойству [AudioFrame.PlayMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 
- Параметры Аудио **Громкость** соответствуют свойству [AudioFrame.Volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 
- Параметры Аудио **Воспроизвести на всех слайдах** соответствуют свойству [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 
- Параметры Аудио **Цикл до остановки** соответствуют свойству [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 
- Параметры Аудио **Скрыть во время показа** соответствуют свойству [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 
- Параметры Аудио **Перемотать после воспроизведения** соответствуют свойству [AudioFrame.RewindAudio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 

Вот как вы можете изменить параметры воспроизведения аудио:

1. [Создайте](#create-audio-frame) или получите Аудио Фрейм.
2. Установите новые значения для свойств Аудио Фрейма, которые вы хотите изменить.
3. Сохраните измененный файл PowerPoint.

Этот код на Python демонстрирует операцию, в которой параметры аудио изменены:

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Получите форму AudioFrame
    audioFrame = pres.slides[0].shapes[0]

    # Установите режим воспроизведения на воспроизведение по клику
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Установите громкость на Низкую
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Установите аудио на воспроизведение на всех слайдах
    audioFrame.play_across_slides = True

    # Отключите цикл для аудио
    audioFrame.play_loop_mode = False

    # Скрыть AudioFrame во время показа слайдов
    audioFrame.hide_at_showing = True

    # Перемотка аудио в начало после воспроизведения
    audioFrame.rewind_audio = True

    # Сохраните файл PowerPoint на диск
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Извлечь Аудио**
Aspose.Slides для Python через .NET позволяет вам извлекать звук, используемый в переходах слайдов. Например, вы можете извлечь звук, используемый на конкретном слайде.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию, содержащую аудио.
2. Получите ссылку на нужный слайд по его индексу.
3. Получите доступ к переходам слайдов для слайда.
4. Извлеките звук в байтовых данных.

Этот код на Python показывает, как извлечь аудио, использованное на слайде:

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # Получает нужный слайд
    slide = pres.slides[0]  

    # Получает эффекты перехода для слайда
    transition = slide.slide_show_transition

    # Извлекает звук в массиве байтов
    audio = transition.sound.binary_data

    print("Длина: " + str(len(audio)))
```