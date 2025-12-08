---
title: Управление аудио в презентациях с использованием C#
linktitle: Аудиокадр
type: docs
weight: 10
url: /ru/net/audio-frame/
keywords:
- аудио
- аудио кадр
- миниатюра
- добавить аудио
- свойства аудио
- параметры аудио
- извлечь аудио
- .NET
- C#
- Aspose.Slides
description: "Создавайте и управляйте аудиокадрами в Aspose.Slides для .NET — примеры на C# для встраивания, обрезки, зацикливания и настройки воспроизведения в презентациях PPT, PPTX и ODP."
---

## **Создать аудио‑кадры**

Aspose.Slides для .NET позволяет добавлять аудиофайлы на слайды. Аудиофайлы встраиваются в слайды как аудио‑кадры. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд по его индексу.
3. Загрузите поток аудиофайла, который вы хотите встроить в слайд.
4. Добавьте встроенный аудио‑кадр (содержащий аудиофайл) на слайд.
5. Установите [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioplaymodepreset) и `Volume`, предоставляемые объектом [IAudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe).
6. Сохраните изменённую презентацию.

Этот C# код показывает, как добавить встроенный аудио‑кадр на слайд:
```c#
// Создает экземпляр класса Presentation, представляющий файл презентации
using (Presentation pres = new Presentation())
{
    // Получает первый слайд
    ISlide sld = pres.Slides[0];
    
    // Загружает wav аудиофайл в поток
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Добавляет аудио‑кадр
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Устанавливает режим воспроизведения и громкость аудио
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // Записывает файл PowerPoint на диск
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```


## **Изменить миниатюру аудио‑кадра**

Когда вы добавляете аудиофайл в презентацию, он отображается как кадр со стандартным изображением по умолчанию (см. изображение ниже). Вы можете изменить миниатюру аудио‑кадра (установить своё изображение).

Этот C# код показывает, как изменить миниатюру или изображение предварительного просмотра аудио‑кадра:
```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // Добавляет аудио‑кадр на слайд с указанными позицией и размером.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // Добавляет изображение в ресурсы презентации.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // Устанавливает изображение для аудио‑кадра.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----

	//Сохраняет изменённую презентацию на диск
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```


## **Изменить параметры воспроизведения аудио**

Aspose.Slides для .NET позволяет менять параметры, управляющие воспроизведением аудио или его свойствами. Например, можно отрегулировать громкость, установить воспроизведение в цикле или скрыть значок аудио.

Окно **Audio Options** в Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Параметры **Audio Options** в PowerPoint, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe):

- **Start** выпадающее меню соответствует свойству [AudioFrame.PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playmode) 
- **Volume** соответствует свойству [AudioFrame.Volume](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/volume) 
- **Play Across Slides** соответствует свойству [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playacrossslides) 
- **Loop until Stopped** соответствует свойству [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playloopmode) 
- **Hide During Show** соответствует свойству [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/hideatshowing) 
- **Rewind after Playing** соответствует свойству [AudioFrame.RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/rewindaudio) 

Параметры **Editing** в PowerPoint, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe):

- **Fade In** соответствует свойству [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeinduration/) 
- **Fade Out** соответствует свойству [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeoutduration/) 
- **Trim Audio Start Time** соответствует свойству [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromstart/) 
- **Trim Audio End Time** соответствует длительности аудио минус значение свойства [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromend/) 

Ползунок **Volume** на панели управления аудио в PowerPoint соответствует свойству [AudioFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/audioframe/volumevalue/) и позволяет менять громкость аудио в процентах.

Как изменить параметры воспроизведения аудио:

1. [Создать](#create-audio-frame) или получить аудио‑кадр.
2. Установите новые значения свойств аудио‑кадра, которые нужно изменить.
3. Сохраните изменённый файл PowerPoint.

Этот C# код демонстрирует операцию, в которой изменяются параметры аудио:
``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Получает форму AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Устанавливает режим воспроизведения на воспроизведение по щелчку
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Устанавливает громкость на низкую
    audioFrame.Volume = AudioVolumeMode.Low;

    // Устанавливает воспроизведение аудио во всех слайдах
    audioFrame.PlayAcrossSlides = true;

    // Отключает зацикливание аудио
    audioFrame.PlayLoopMode = false;

    // Скрывает AudioFrame во время показа слайдов
    audioFrame.HideAtShowing = true;

    // Перематывает аудио к началу после воспроизведения
    audioFrame.RewindAudio = true;

    // Сохраняет файл PowerPoint на диск
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```


Этот C# пример показывает, как добавить новый аудио‑кадр с встроенным аудио, обрезать его и задать длительности затухания:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Устанавливает начальное смещение обрезки в 1.5 секунды
    audioFrame.TrimFromStart = 1500f;
    // Устанавливает конечное смещение обрезки в 2 секунды
    audioFrame.TrimFromEnd = 2000f;

    // Устанавливает длительность fade-in в 200 мс
    audioFrame.FadeInDuration = 200f;
    // Устанавливает длительность fade-out в 500 мс
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```


Следующий пример кода показывает, как получить аудио‑кадр с встроенным аудио и установить его громкость на 85 %:
```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Получает форму аудио‑кадра
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // Устанавливает громкость аудио на 85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```


## **Извлечь аудио**
Aspose.Slides для .NET позволяет извлекать звук, используемый в переходах слайд‑шоу. Например, можно извлечь звук, использованный в конкретном слайде.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и загрузите презентацию, содержащую аудио.
2. Получите ссылку на нужный слайд по его индексу.
3. Получите доступ к переходам слайд‑шоу для этого слайда.
4. Извлеките звук в виде байтовых данных.

Этот C# код показывает, как извлечь аудио, используемое в слайде:
```c#
string presName = "AudioSlide.pptx";

// Создаёт экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation(presName);

// Получает доступ к слайду
ISlide slide = pres.Slides[0];

// Получает эффекты переходов слайд-шоу для слайда
ISlideShowTransition transition = slide.SlideShowTransition;

//Извлекает звук в массив байтов
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```


## **FAQ**

**Можно ли повторно использовать один и тот же аудио‑ресурс на нескольких слайдах без увеличения размера файла?**

Да. Добавьте аудио один раз в общую [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) презентации и создайте дополнительные аудио‑кадры, которые ссылаются на этот существующий ресурс. Это избегает дублирования медиа‑данных и держит размер презентации под контролем.

**Можно ли заменить звук в существующем аудио‑кадре без пересоздания формы?**

Да. Для связанного звука обновите [link path](https://reference.aspose.com/slides/net/aspose.slides/audioframe/linkpathlong/), указывающий на новый файл. Для встроенного звука замените объект [embedded audio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/embeddedaudio/) другим из [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) презентации. Форматирование кадра и большинство настроек воспроизведения останутся неизменными.

**Изменяет ли обрезка фактические аудио‑данные, хранящиеся в презентации?**

Нет. Обрезка изменяет только границы воспроизведения. Исходные аудио‑байты остаются нетронутыми и доступны через встроенное аудио или коллекцию аудио презентации.