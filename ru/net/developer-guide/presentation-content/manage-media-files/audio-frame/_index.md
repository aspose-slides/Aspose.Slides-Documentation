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
- извлечение аудио
- .NET
- C#
- Aspose.Slides
description: "Встраивание аудио в слайды, изменение значка аудио, настройка воспроизведения, управление WebVTT‑подписями и извлечение звуков переходов слайдов с помощью Aspose.Slides для .NET."
---
## **Обзор**

Аудио‑кадр позволяет воспроизводить звук на слайде. С помощью Aspose.Slides для .NET вы можете встроить аудиоклип, выбрать изображение, которое его представляет, настроить воспроизведение и добавить подписи. Также можно получить звук, назначенный переходу слайда.

## **Создание аудио‑кадров**

Используйте [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) для встраивания локального аудиоклипа на первый слайд. Первые две координаты задают положение кадра на слайде, а следующие два значения задают его ширину и высоту, всё в пунктах. В этом примере свойству [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) задаётся автоматический запуск клипа, а [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) — громкая предустановка.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame.PlayMode = AudioPlayModePreset.Auto;
audioFrame.Volume = AudioVolumeMode.Loud;

presentation.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
```

## **Изменение миниатюры аудио‑кадра**

По умолчанию аудио‑кадр отображает значок динамика. Чтобы показать пользовательскую миниатюру, добавьте изображение в презентацию с помощью [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) и присвойте его свойству [Picture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) кадра. В примере в качестве миниатюры для встроенного аудиоклипа используется JPEG.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var imageStream = File.OpenRead("eagle.jpeg");
var thumbnail = presentation.Images.AddImage(imageStream);

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

## **Изменение параметров воспроизведения аудио**

PowerPoint’s **Audio Options** controls determine when a clip starts, how loud it sounds, and how it behaves during a slide show.

![Элементы управления Audio Options в PowerPoint для аудио‑кадра](audio_frame_0.png)

| Элемент управления PowerPoint | Свойство Aspose.Slides |
| --- | --- |
| Запуск | [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) |
| Предустановка громкости | [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) |
| Воспроизведение на всех слайдах | [PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playacrossslides/) |
| Повторять до остановки | [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playloopmode/) |
| Скрывать во время показа | [HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/hideatshowing/) |
| Перемотка после воспроизведения | [RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/rewindaudio/) |
| Появление (Fade In) | [FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeinduration/) |
| Исчезновение (Fade Out) | [FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeoutduration/) |
| Обрезать время начала аудио | [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) |
| Обрезать время окончания аудио | [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) |
| Регулятор громкости | [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) |

В примере находится первый аудио‑кадр на первом слайде, свойству [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) задаётся запуск воспроизведения по щелчку, и выбирается предустановка низкой громкости. Клип продолжает воспроизводиться на всех слайдах при отключённом цикле. Значок остаётся скрытым во время показа, а клип перематывается после воспроизведения.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.PlayMode = AudioPlayModePreset.OnClick;
audioFrame.Volume = AudioVolumeMode.Low;
audioFrame.PlayAcrossSlides = true;
audioFrame.PlayLoopMode = false;
audioFrame.HideAtShowing = true;
audioFrame.RewindAudio = true;

presentation.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
```

Для клипа длиной более 3,5 секунды этот пример пропускает первые 1,5 секунды и последние 2 секунды. [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) измеряет длительность, которую необходимо исключить в конце клипа. Чтобы получить конечное время, отображаемое в PowerPoint, вычтите этот смещение из полной длительности клипа. Обрезанный клип плавно появляется в течение 200 миллисекунд и исчезает в течение 500 миллисекунд. Все четыре свойства принимают значения в миллисекундах.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame.TrimFromStart = 1500f;
audioFrame.TrimFromEnd = 2000f;
audioFrame.FadeInDuration = 200f;
audioFrame.FadeOutDuration = 500f;

presentation.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
```

Чтобы задать громкость воспроизведения в конкретный процент, используйте [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/). В этом примере первый аудио‑кадр на первом слайде устанавливается на 85 %.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.VolumeValue = 85f;

presentation.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
```

## **Управление аудио‑подписями**

У каждого аудио‑кадра есть коллекция [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/captiontracks/). Используйте её, чтобы прикрепить к клипу подписи WebVTT, экспортировать существующие дорожки или удалить их.

### **Добавление аудио‑подписей**

В примере встраивается аудио‑клип на первый слайд и используется [ICaptionsCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/add/) чтобы присоединить локальную дорожку WebVTT. Первый аргумент задаёт метку дорожки, второй указывает файл с тайм‑квипами.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
```

### **Извлечение аудио‑подписей**

В этом примере экспортируется каждая дорожка подписи, прикреплённая к аудио‑кадру на первом слайде. Данные дорожки [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/icaptions/binarydata/) записываются в файл WebVTT, а её [CaptionId](https://reference.aspose.com/slides/net/aspose.slides/icaptions/captionid/) используется как имя файла, чтобы каждая дорожка имела отдельный вывод.

```csharp
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var audioFrame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in audioFrame.CaptionTracks)
    {
        File.WriteAllBytes($"{track.CaptionId}.vtt", track.BinaryData);
    }
}
```

### **Удаление аудио‑подписей**

Для удаления отдельной дорожки используйте [Remove](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/remove/) или [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/removeat/). В примере применяется [Clear](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/clear/) чтобы удалить все подписи из первого аудио‑кадра на первом слайде, сохранив при этом клип.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.CaptionTracks.Clear();

presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
```

### **Поиск строки в аудио‑подписях**

Чтобы найти строку в аудио‑подписях на первом слайде, прочитайте в памяти [DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) каждой дорожки. В простом текстовом WebVTT‑cue строка тайминга содержит `-->`, за ней следуют строки подписи, а пустая строка завершает cue. В этом примере выводятся метка дорожки и каждая строка подписи, содержащая «café».

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var frame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in frame.CaptionTracks)
    {
        using var reader = new StringReader(track.DataAsString);
        var inCue = false;
        while (reader.ReadLine() is string line)
        {
            if (line.Length == 0)
                inCue = false;
            else if (line.Contains("-->"))
                inCue = true;
            else if (inCue && line.Contains("café", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"{track.Label}: {line}");
        }
    }
}
```

## **Извлечение аудио**

У перехода слайда может быть собственный звук. Чтобы получить его, прочитайте свойство [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) перехода. В примере доступ к [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) звука и выводится его размер в байтах. Если у первого слайда нет звука перехода, выводится сообщение.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AudioSlide.pptx");
var slide = presentation.Slides[0];

var sound = slide.SlideShowTransition.Sound;
if (sound == null)
{
    Console.WriteLine("The first slide has no transition sound.");
    return;
}

var audioData = sound.BinaryData;
Console.WriteLine($"Transition sound: {audioData.Length} bytes.");
```

## **Часто задаваемые вопросы**

**Могу ли я использовать один и тот же аудио‑клип на нескольких слайдах без дублирования?**

Да. Добавьте клип один раз в [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) презентации и передайте тот же аудио‑объект в [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) для каждого слайда.

**Могу ли я заменить звук в существующем аудио‑кадре?**

Да. Для связанного звука обновите [LinkPathLong](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/linkpathlong/) , указав путь к файлу‑заменителю. Для встроенного звука назначьте другой клип из аудио‑коллекции презентации свойству [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/). Оба подхода сохраняют существующий кадр.

**Изменяет ли обрезка аудио‑данные, хранящиеся в презентации?**

Нет. [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) и [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) задают границы воспроизведения. Полный клип всё ещё можно получить из [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/).