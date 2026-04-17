---
title: Управление аудио‑кадрами в презентациях на .NET
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
- параметры аудио
- извлечь аудио
- .NET
- C#
- Aspose.Slides
description: "Создавайте и управляйте аудио‑кадрами в Aspose.Slides для .NET — примеры на C# по встраиванию, обрезке, зацикливанию и настройке воспроизведения в презентациях PPT, PPTX и ODP."
---
## **Создание аудио‑кадров**

Aspose.Slides для .NET позволяет добавлять аудиофайлы на слайды. Аудиофайлы встраиваются в слайды в виде аудио‑кадров. 

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation).
2. Получите ссылку на слайд по его индексу.
3. Загрузите поток аудиофайла, который вы хотите встроить в слайд.
4. Добавьте встроенный аудио‑кадр (содержит аудиофайл) на слайд.
5. Установите [PlayMode](https://reference.aspose.com/slides/ru/net/aspose.slides/audioplaymodepreset) и `Volume`, доступные через объект [IAudioFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/audioframe).
6. Сохраните изменённую презентацию.

Этот код на C# показывает, как добавить встроенный аудио‑кадр на слайд:

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

    // Записывает файл PowerPoint на диск
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **Изменение миниатюры аудио‑кадра**

Когда вы добавляете аудиофайл в презентацию, аудио отображается как кадр со стандартным изображением по умолчанию (см. изображение в разделе ниже). Вы можете изменить миниатюру аудио‑кадра (установить своё изображение).

Этот код на C# показывает, как изменить миниатюру или изображение предварительного просмотра аудио‑кадра:

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // Добавляет аудио‑кадр на слайд с указанным положением и размером.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // Добавляет изображение в ресурсы презентации.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // Устанавливает изображение для аудио‑кадра.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
    // Сохраняет изменённую презентацию на диск
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **Изменение параметров воспроизведения аудио**

Aspose.Slides для .NET позволяет изменять параметры, управляющие воспроизведением аудио или его свойствами. Например, можно отрегулировать громкость, установить цикл воспроизведения или скрыть значок аудио.

Панель **Audio Options** в Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options**, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/audioframe):

- **Start** – выпадающий список соответствует свойству [AudioFrame.PlayMode](https://reference.aspose.com/slides/ru/net/aspose.slides/audioframe/properties/playmode)
- **Volume** соответствует свойству [AudioFrame.Volume](https://reference.aspose.com/slides/ru/net/aspose.slides/audioframe/properties/volume)
- **Play Across Slides** соответствует свойству [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/ru/net/aspose.slides/audioframe/properties/playacrossslides)
- **Loop until Stopped** соответствует свойству [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/ru/net/aspose.slides/audioframe/properties/playloopmode)
- **Hide During Show** соответствует свойству [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/ru/net/aspose.slides/audioframe/properties/hideatshowing)
- **Rewind after Playing** соответствует свойству [AudioFrame.RewindAudio ](https://reference.aspose.com/slides/ru/net/aspose.slides/audioframe/properties/rewindaudio)

PowerPoint **Editing**‑опции, соответствующие свойствам Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/audioframe):

- **Fade In** соответствует свойству [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/ru/net/aspose.slides/audioframe/fadeinduration/) 
- **Fade Out** соответствует свойству [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/ru/net/aspose.slides/audioframe/fadeoutduration/) 
- **Trim Audio Start Time** соответствует свойству [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/ru/net/aspose.slides/audioframe/trimfromstart/) 
- **Trim Audio End Time** значение равно продолжительности аудио минус значение свойства [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/ru/net/aspose.slides/audioframe/trimfromend/)

Контроллер **Volume** на панели управления аудио в PowerPoint соответствует свойству [AudioFrame.VolumeValue](https://reference.aspose.com/slides/ru/net/aspose.slides/audioframe/volumevalue/). Он позволяет изменять громкость аудио в процентах.

Так меняются параметры воспроизведения аудио:

1. [Создать](#create-audio-frame) или получить аудио‑кадр.
2. Установите новые значения свойств аудио‑кадра, которые вы хотите изменить.
3. Сохраните изменённый файл PowerPoint.

Этот код на C# демонстрирует операцию, в которой настраиваются параметры аудио:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Получает форму AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Устанавливает режим воспроизведения на воспроизведение по щелчку
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Устанавливает громкость в Low
    audioFrame.Volume = AudioVolumeMode.Low;

    // Устанавливает воспроизведение аудио на всех слайдах
    audioFrame.PlayAcrossSlides = true;

    // Отключает цикл воспроизведения для аудио
    audioFrame.PlayLoopMode = false;

    // Скрывает AudioFrame во время показа слайдов
    audioFrame.HideAtShowing = true;

    // Перематывает аудио к началу после воспроизведения
    audioFrame.RewindAudio = true;

    // Сохраняет файл PowerPoint на диск
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

Этот пример на C# показывает, как добавить новый аудио‑кадр с встроенным аудио, обрезать его и задать длительность затухания:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Устанавливает смещение начала обрезки в 1,5 секунды
    audioFrame.TrimFromStart = 1500f;
    // Устанавливает смещение конца обрезки в 2 секунды
    audioFrame.TrimFromEnd = 2000f;

    // Устанавливает длительность плавного появления в 200 мс
    audioFrame.FadeInDuration = 200f;
    // Устанавливает длительность плавного затухания в 500 мс
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```

Следующий образец кода показывает, как получить аудио‑кадр с встроенным аудио и установить его громкость на 85 %:

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Получает форму аудио‑кадра
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // Устанавливает громкость аудио в 85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```

## **Управление аудио‑подписями**

Aspose.Slides позволяет добавлять закрытые субтитры к аудио‑кадру через свойство [CaptionTracks](https://reference.aspose.com/slides/ru/net/aspose.slides/iaudioframe/captiontracks/). Это свойство возвращает [ICaptionsCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/icaptionscollection/), позволяя добавлять дорожки WebVTT, перебирать существующие дорожки и удалять их при необходимости.

**Добавить аудио‑подписи**

Используйте свойство [CaptionTracks](https://reference.aspose.com/slides/ru/net/aspose.slides/iaudioframe/captiontracks/) для присоединения одной или нескольких дорожек субтитров к аудио‑кадру. В примере ниже аудиофайл добавляется на слайд, после чего новая дорожка субтитров загружается из файла `.vtt`.

```cs
using (Presentation presentation = new Presentation())
{
    byte[] audioData = File.ReadAllBytes("audio.mp3");
    IAudio audio = presentation.Audios.AddAudio(audioData);

    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Добавьте новую дорожку субтитров из файла WebVTT.
    audioFrame.CaptionTracks.Add("New track", "track.vtt");

    presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
}
```

**Извлечение аудио‑субтитров**

Можно перебрать дорожки субтитров, связанные с аудио‑кадром, и сохранить их как файлы `.vtt`. Каждая дорожка раскрывает свои двоичные данные и уникальный идентификатор, которые можно использовать при экспорте субтитров.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAudioFrame audioFrame)
        {
            foreach (ICaptions captionTrack in audioFrame.CaptionTracks)
            {
                // Сохраните дорожку субтитров в файл .vtt.
                File.WriteAllBytes($"{captionTrack.CaptionId}.vtt", captionTrack.BinaryData);
            }
        }
    }
}
```

**Удаление аудио‑субтитров**

Чтобы удалить субтитры из аудио‑кадра, используйте методы, предоставляемые [ICaptionsCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/icaptionscollection/), такие как [Clear](https://reference.aspose.com/slides/ru/net/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/ru/net/aspose.slides/icaptionscollection/remove/) или [RemoveAt](https://reference.aspose.com/slides/ru/net/aspose.slides/icaptionscollection/removeat/). Пример ниже удаляет все дорожки субтитров из аудио‑кадра.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes[0] as IAudioFrame;

    // Удалить все дорожки субтитров из аудио‑кадра.
    audioFrame.CaptionTracks.Clear();

    presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
}
```

## **Извлечение аудио**

Aspose.Slides для .NET позволяет извлекать звук, используемый в переходах слайд‑шоу. Например, можно извлечь звук, использованный в конкретном слайде.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation) и загрузите презентацию, содержащую аудио.
2. Получите ссылку на соответствующий слайд по его индексу.
3. Доступ к переходам слайд‑шоу для этого слайда.
4. Извлеките звук в виде байтовых данных.

Этот код на C# показывает, как извлечь аудио, используемое в слайде:

```c#
string presName = "AudioSlide.pptx";

// Создаёт экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation(presName);

// Accesses the slide
ISlide slide = pres.Slides[0];

// Gets the slideshow transition effects for the slide
ISlideShowTransition transition = slide.SlideShowTransition;

//Extracts the sound in byte array
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```

## **FAQ**

**Можно ли использовать один и тот же аудио‑ресурс на нескольких слайдах без увеличения размера файла?**

Да. Добавьте аудио один раз в общую [audio collection](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/audios/) презентации и создайте дополнительные аудио‑кадры, которые ссылаются на этот существующий ресурс. Это предотвращает дублирование медиа‑данных и сохраняет размер презентации под контролем.

**Можно ли заменить звук в существующем аудио‑кадре без пересоздания формы?**

Да. Для связанного звука обновите [link path](https://reference.aspose.com/slides/ru/net/aspose.slides/audioframe/linkpathlong/) так, чтобы он указывал на новый файл. Для встроенного звука замените объект [embedded audio](https://reference.aspose.com/slides/ru/net/aspose.slides/audioframe/embeddedaudio/) другим из [audio collection](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/audios/) презентации. Форматирование кадра и большинство настроек воспроизведения сохраняются.

**Изменяет ли обрезка фактические аудио‑данные, хранящиеся в презентации?**

Нет. Обрезка меняет только границы воспроизведения. Исходные аудио‑байты остаются нетронутыми и доступны через встроенное аудио или коллекцию аудио презентации.