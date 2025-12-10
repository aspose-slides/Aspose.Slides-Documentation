---
title: Управление аудио‑кадрами в презентациях в .NET
linktitle: Аудио‑кадр
type: docs
weight: 10
url: /ru/net/audio-frame/
keywords:
- аудио
- аудио‑кадр
- миниатюра
- добавить аудио
- свойства аудио
- опции аудио
- извлечение аудио
- .NET
- C#
- Aspose.Slides
description: "Создавайте и управляйте аудио‑кадрами в Aspose.Slides для .NET — примеры на C# по встраиванию, обрезке, зацикливанию и настройке воспроизведения в PPT, PPTX и ODP презентациях."
---

## **Создать аудио‑кадры**

Aspose.Slides for .NET позволяет добавлять аудиофайлы на слайды. Аудиофайлы встраиваются в слайды как аудио‑кадры. 

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд по его индексу.
3. Загрузите поток аудиофайла, который нужно встроить в слайд.
4. Добавьте встроенный аудио‑кадр (содержащий аудиофайл) на слайд.
5. Установите свойства [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioplaymodepreset) и `Volume`, доступные через объект [IAudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe).
6. Сохраните изменённую презентацию.

Этот C#‑код демонстрирует, как добавить встроенный аудио‑кадр на слайд:
```c#
// Создаёт экземпляр класса презентации, представляющего файл презентации
using (Presentation pres = new Presentation())
{
    // Получает первый слайд
    ISlide sld = pres.Slides[0];
    
    // Загружает wav‑файл звука в поток
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Добавляет аудио‑кадр
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Устанавливает режим воспроизведения и громкость аудио
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // Сохраняет файл PowerPoint на диск
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```


## **Изменить миниатюру аудио‑кадра**

При добавлении аудиофайла в презентацию он отображается как кадр со стандартным изображением по умолчанию (см. изображение ниже). Вы можете изменить миниатюру аудио‑кадра (установить своё изображение).

Этот C#‑код показывает, как изменить миниатюру или предварительный просмотр аудио‑кадра:
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
    
	//Saves the modified presentation to disk
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```


## **Изменить параметры воспроизведения аудио**

Aspose.Slides for .NET позволяет менять параметры, управляющие воспроизведением аудио или его свойствами. Например, можно отрегулировать громкость, воспроизводить аудио в цикле или скрыть значок аудио.

Область **Audio Options** в Microsoft PowerPoint:

![пример_изображения](audio_frame_0.png)

Параметры PowerPoint **Audio Options**, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe):

- Выпадающий список **Start** соответствует свойству [AudioFrame.PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playmode) 
- **Volume** соответствует свойству [AudioFrame.Volume](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/volume) 
- **Play Across Slides** соответствует свойству [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playacrossslides) 
- **Loop until Stopped** соответствует свойству [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playloopmode) 
- **Hide During Show** соответствует свойству [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/hideatshowing) 
- **Rewind after Playing** соответствует свойству [AudioFrame.RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/rewindaudio) 

Параметры PowerPoint **Editing**, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe):

- **Fade In** соответствует свойству [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeinduration/) 
- **Fade Out** соответствует свойству [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeoutduration/) 
- **Trim Audio Start Time** соответствует свойству [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromstart/) 
- **Trim Audio End Time** равен длительности аудио минус значение свойства [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromend/) 

Ползунок **Volume** на панели управления аудио в PowerPoint соответствует свойству [AudioFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/audioframe/volumevalue/) . Он позволяет менять громкость аудио в процентах.

Как изменить параметры воспроизведения аудио:

1. [Create](#create-audio-frame) или получите аудио‑кадр.
2. Установите новые значения нужных вам свойств аудио‑кадра.
3. Сохраните изменённый файл PowerPoint.

Этот C#‑код демонстрирует операцию, в которой изменяются параметры аудио:
``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Получает форму AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Устанавливает режим воспроизведения на воспроизведение по щелчку
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Устанавливает громкость на низкую
    audioFrame.Volume = AudioVolumeMode.Low;

    // Устанавливает воспроизведение аудио на всех слайдах
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


Этот пример на C# показывает, как добавить новый аудио‑кадр со встроенным аудио, обрезать его и задать длительность затухания:
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


В следующем примере кода показано, как получить аудио‑кадр со встроенным аудио и установить его громкость на 85 %:
```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Получает форму AudioFrame
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // Устанавливает громкость аудио на 85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```


## **Извлечение аудио**
Aspose.Slides for .NET позволяет извлекать звук, используемый в переходах слайд‑шоу. Например, можно извлечь звук, использованный в конкретном слайде.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и загрузите презентацию, содержащую аудио.
2. Получите ссылку на нужный слайд по его индексу.
3. Получите переходы слайд‑шоу для этого слайда.
4. Извлеките звук в виде байтовых данных.

Этот C#‑код показывает, как извлечь аудио, использованное в слайде:
```c#
string presName = "AudioSlide.pptx";

// Создаёт экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation(presName);

// Получает доступ к слайду
ISlide slide = pres.Slides[0];

// Получает эффекты переходов слайд-шоу для слайда
ISlideShowTransition transition = slide.SlideShowTransition;

//Extracts the sound in byte array
//Извлекает звук в массив байтов
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```


## **FAQ**

**Можно ли использовать один и тот же аудио‑ресурс на нескольких слайдах, не увеличивая размер файла?**

Да. Добавьте аудио один раз в общую [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) презентации и создайте дополнительные аудио‑кадры, ссылающиеся на существующий ресурс. Это предотвращает дублирование медиа‑данных и позволяет контролировать размер презентации.

**Можно ли заменить звук в существующем аудио‑кадре без пересоздания формы?**

Да. Для связанного звука обновите [link path](https://reference.aspose.com/slides/net/aspose.slides/audioframe/linkpathlong/) на новый файл. Для встроенного звука замените объект [embedded audio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/embeddedaudio/) другим из [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) презентации. Форматирование кадра и большинство настроек воспроизведения останутся без изменений.

**Изменяет ли обрезка (trimming) исходные аудио‑данные, хранящиеся в презентации?**

Нет. Обрезка изменяет только границы воспроизведения. Исходные аудио‑байты остаются нетронутыми и доступны через встроенное аудио или коллекцию аудио презентации.