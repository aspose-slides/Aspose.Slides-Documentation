---
title: Аудио Кадр - Вставка и Извлечение Аудио в PowerPoint с использованием C#
linktitle: Аудио Кадр
type: docs
weight: 10
url: /net/audio-frame/
keywords: "аудио эскиз изображения, Добавить аудио, Аудио кадр, Свойства аудио, Извлечь аудио, C#, Csharp, Aspose.Slides для .NET"
description: "Добавьте аудио в презентацию PowerPoint на C# или .NET"
---

## **Создание Аудио Кадра**
Aspose.Slides для .NET позволяет добавлять аудиофайлы на слайды. Аудиофайлы встраиваются в слайды в виде аудиокадров.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд через его индекс.
3. Загрузите поток аудиофайла, который вы хотите встроить в слайд.
4. Добавьте встроенный аудиокадр (содержащий аудиофайл) на слайд.
5. Установите [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioplaymodepreset) и `Volume`, предоставленные объектом [IAudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe).
6. Сохраните измененную презентацию.

Этот код на C# показывает, как добавить встроенный аудиокадр на слайд:

```c#
// Создает экземпляр класса presentation, который представляет файл презентации
using (Presentation pres = new Presentation())
{
    // Получает первый слайд
    ISlide sld = pres.Slides[0];
    
    // Загружает wav аудиофайл в поток
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Добавляет Аудио Кадр
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Устанавливает Режим Воспроизведения и Громкость Аудио
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // Записывает файл PowerPoint на диск
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **Изменение Эскиза Аудио Кадра**

Когда вы добавляете аудиофайл в презентацию, аудио отображается в виде кадра со стандартным изображением по умолчанию (см. изображение в разделе ниже). Вы можете изменить эскиз аудиокадра (установить ваше предпочтительное изображение).

Этот код на C# показывает, как изменить эскиз аудиокадра или изображение-превью:

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // Добавляет аудиокадр на слайд с заданной позицией и размером.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // Добавляет изображение в ресурсы презентации.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // Устанавливает изображение для аудиокадра.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
	// Сохраняет измененную презентацию на диск
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **Изменение Параметров Воспроизведения Аудио**

Aspose.Slides для .NET позволяет изменять параметры, которые управляют воспроизведением аудио или его свойствами. Например, вы можете настроить громкость аудио, установить воспроизведение в цикле или даже скрыть значок аудио.

Панель **Параметры Аудио** в Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Параметры аудио PowerPoint, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe):

- Выпадающее меню **Начало** параметров Аудио соответствует свойству [AudioFrame.PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playmode) 
- **Громкость** параметров Аудио соответствует свойству [AudioFrame.Volume](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/volume) 
- **Воспроизведение на нескольких слайдах** соответствует свойству [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playacrossslides) 
- **Цикл до остановки** соответствует свойству [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playloopmode) 
- **Скрыть во время показа** соответствует свойству [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/hideatshowing) 
- **Перемотка после воспроизведения** соответствует свойству [AudioFrame.RewindAudio ](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/rewindaudio) 

Таким образом, вы можете изменить параметры Воспроизведения Аудио:

1. [Создайте](#create-audio-frame) или получите Аудио Кадр.
2. Установите новые значения для свойств Аудио Кадра, которые вы хотите изменить.
3. Сохраните измененный файл PowerPoint.

Этот код на C# демонстрирует операцию, при которой настраиваются параметры аудио:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Получает форму AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Устанавливает режим воспроизведения на "воспроизводить по щелчку"
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Устанавливает громкость на "низкий"
    audioFrame.Volume = AudioVolumeMode.Low;

    // Устанавливает воспроизведение на нескольких слайдах
    audioFrame.PlayAcrossSlides = true;

    // Отключает цикл для аудио
    audioFrame.PlayLoopMode = false;

    // Скрывает AudioFrame во время показа слайдов
    audioFrame.HideAtShowing = true;

    // Перематывает аудиофайл в начало после воспроизведения
    audioFrame.RewindAudio = true;

    // Сохраняет файл PowerPoint на диск
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

## **Извлечение Аудио**
Aspose.Slides для .NET позволяет извлекать звук, используемый в переходах слайдов. Например, вы можете извлечь звук, используемый на конкретном слайде.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и загрузите презентацию, содержащую аудио.
2. Получите ссылку на соответствующий слайд через его индекс.
3. Получите доступ к переходам слайдов для слайда.
4. Извлеките звук в байтовые данные.

Этот код на C# показывает, как извлечь аудио, использованное на слайде:

```c#
string presName = "AudioSlide.pptx";

// Создает экземпляр класса Presentation, который представляет файл презентации
Presentation pres = new Presentation(presName);

// Получает доступ к слайду
ISlide slide = pres.Slides[0];

// Получает эффекты переходов слайдов для слайда
ISlideShowTransition transition = slide.SlideShowTransition;

// Извлекает звук в байтовый массив
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Длина: " + audio.Length);
```