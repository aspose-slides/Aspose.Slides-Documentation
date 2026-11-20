---
title: Управление видеофреймами в презентациях на .NET
linktitle: Видео фрейм
type: docs
weight: 10
url: /ru/net/video-frame/
keywords:
- добавить видео
- создать видео
- внедрить видео
- извлечь видео
- получить видео
- видеофрейм
- веб-источник
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Изучите, как программно добавлять и извлекать видеофреймы в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides for .NET. Быстрое руководство‑как‑делать."
---
## **Введение**

Видео могут помочь объяснить идеи и привлечь аудиторию. Aspose.Slides for .NET позволяет добавлять видеофреймы на слайды, настраивать параметры воспроизведения, управлять субтитрами и извлекать встроенные видеоданные.

PowerPoint поддерживает локальные видео и ссылки на онлайн‑видео, такие как видео YouTube.

Для представления видеоданных и видеофреймов Aspose.Slides предоставляет интерфейсы [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) и [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/), а также другие соответствующие типы.

## **Создание встроенного видеофрейма**

Если видеофайл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеофрейм для встраивания видео в презентацию.

В этом примере локальное видео встраивается на первый слайд существующей презентации и сохраняется результат. Координаты и размеры фрейма указаны в пунктах. Поток остаётся открытым до завершения сохранения, потому что [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) удерживает его, пока презентация использует его.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

using var videoStream = File.OpenRead("video.mp4");
var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
slide.Shapes.AddVideoFrame(10, 10, 150, 250, video);

presentation.Save("embedded_video.pptx", SaveFormat.Pptx);
```

Вы также можете передать путь к локальному видео непосредственно в [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). В этом примере видео встраивается на первый слайд новой презентации. Видео должно оставаться доступным до сохранения презентации.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Точное регулирование громкости видео**

В Aspose.Slides for .NET 26.11 и выше [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) задаёт процент в виде числа с плавающей точкой от 0 до 100. Используйте его, когда предустановки [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) слишком грубы. Например, `75.5f` задаёт громкость 75,5 %.

Этот пример требует [Aspose.Slides for .NET](/slides/ru/net/installation/) 26.11 или новее и локальный `video.mp4`. Он встраивает видео, явно инициализирует воспроизведение, сохраняет презентацию и читает сохранённый процент обратно.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

var volume = 75.5f;
if (float.IsNaN(volume) || float.IsInfinity(volume) || volume < 0 || volume > 100)
{
    Console.WriteLine("Use a finite volume from 0 to 100.");
    return;
}

using (var presentation = new Presentation())
{
    var videoBytes = File.ReadAllBytes("video.mp4");
    var video = presentation.Videos.AddVideo(videoBytes);
    var frame = presentation.Slides[0].Shapes.AddVideoFrame(50, 50, 320, 180, video);
    frame.PlayMode = VideoPlayModePreset.Auto;
    frame.VolumeValue = volume;
    presentation.Save("video-volume.pptx", SaveFormat.Pptx);
}

using var saved = new Presentation("video-volume.pptx");
var savedFrame = saved.Slides[0].Shapes.OfType<IVideoFrame>().First();
Console.WriteLine(savedFrame.VolumeValue);
```

Проверяйте ввод самостоятельно; не полагайтесь на сеттер, отбрасывающий значения вне документированного диапазона. Предустановки Low, Medium и Loud соответствуют 20, 50 и 80 в версии 26.11. Установка предустановки может заменить ранее заданный процент, поэтому присваивайте процент последним, когда нужен точный уровень. Для явного отключения звука используйте [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/), числовой ноль и перечисление предустановки не являются взаимозаменяемыми состояниями.

Явно задавайте [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) при конфигурации связанного видео и держите его медиафайл доступным для просмотра. Сохранение и повторное открытие подтверждают сохранённую настройку; фактическое воспроизведение и громкость зависят от проигрывателя презентаций и его аудио‑настроек.

## **Создание видеофрейма с видео из веб‑источника**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) поддерживает онлайн‑видео в презентациях. Вы можете создать видеофрейм, который ссылается на онлайн‑видео, например видео YouTube.

В этом примере на первый слайд добавляется ссылка на видео YouTube и миниатюра. Замените идентификатор видео, чтобы использовать другое видео. Настройка [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) запрашивает автоматическое воспроизведение. Скачивание миниатюры и воспроизведение видео требуют доступа к интернету. Средство просмотра презентаций также должно поддерживать онлайн‑воспроизведение видео.

```csharp
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var httpClient = new HttpClient();

var videoId = "aqz-KE-bpKQ";
var videoUrl = $"https://www.youtube.com/embed/{videoId}";
var videoFrame = slide.Shapes.AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame.PlayMode = VideoPlayModePreset.Auto;

var thumbnailUrl = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
var thumbnailData = httpClient.GetByteArrayAsync(thumbnailUrl).GetAwaiter().GetResult();
var thumbnail = presentation.Images.AddImage(thumbnailData);
videoFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("online_video.pptx", SaveFormat.Pptx);
```

## **Воспроизведение видео в полноэкранном режиме**

В учебной презентации вы можете воспроизводить демонстрацию программного обеспечения в полноэкранном режиме, чтобы аудитория видела детали. Установите [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) в `true`, чтобы включить это поведение во время воспроизведения.

В этом примере открывается презентация, находится первый [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) на первом слайде и включается полноэкранное воспроизведение. Входная презентация должна содержать хотя бы один слайд с существующим видеофреймом на первом слайде.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.FullScreenMode = true;
        break;
    }
}

presentation.Save("full_screen_video.pptx", SaveFormat.Pptx);
```

Полноэкранное воспроизведение управляет отображением видео. Независимо от этого, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) определяет, начинается ли воспроизведение автоматически или по щелчку, а [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) — повторяется ли оно. Чтобы выбрать поведение запуска, задайте режим воспроизведения [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). Пример сохраняет существующие настройки начала и цикла.

## **Перемотка видео после воспроизведения**

В учебной презентации возврат демонстрационного видео к началу готовит его к повторному воспроизведению. Установите [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) в `true`, чтобы после завершения воспроизведения видео возвращалось к началу.

В этом примере открывается презентация, находится первый [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) на первом слайде и включается перемотка. Отключается цикл, чтобы воспроизведение могло завершиться, и устанавливается запуск воспроизведения по щелчку. Входная презентация должна содержать хотя бы один слайд с существующим видеофреймом на первом слайде.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.RewindVideo = true;
        videoFrame.PlayLoopMode = false;
        videoFrame.PlayMode = VideoPlayModePreset.OnClick;
        break;
    }
}

presentation.Save("rewind_video.pptx", SaveFormat.Pptx);
```

Перемотка возвращает видео к началу без повторного запуска. В отличие от этого, включение [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) автоматически повторяет воспроизведение. Отключайте цикл, когда хотите, чтобы видео закончилось и было готово к повторному воспроизведению. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) независимо управляет автоматическим запуском или запуском по щелчку; в этом примере используется [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/), чтобы докладчик контролировал начало воспроизведения. Устанавливайте режим воспроизведения после настройки цикла, как показано в примере. Перемотка работает независимо от [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Обрезка видеофрейма**

Используйте [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) и [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) чтобы пропустить часть начала или конца видео во время воспроизведения. Оба значения указываются в миллисекундах. Обрезка изменяет настройки воспроизведения без изменения встроенных видеоданных.

**Настройка обрезки**

В этом примере встраивается локальное видео, а во время воспроизведения пропускаются первые 2,5 секунды и последняя секунда. Используйте видео длинее 3,5 секунды, чтобы остался воспроизводимый сегмент.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);
videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Чтение настроек обрезки**

В этом примере выводятся значения обрезки первого видеофрейма на первом слайде в миллисекундах. Презентация должна содержать хотя бы один слайд. Если на этом слайде нет видеофрейма, ничего не выводится. Предыдущий пример дает значения 2500 и 1000.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("video_with_trim.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        Console.WriteLine($"Trim from start: {videoFrame.TrimFromStart} ms");
        Console.WriteLine($"Trim from end: {videoFrame.TrimFromEnd} ms");
        break;
    }
}
```

## **Управление субтитрами видео**

Aspose.Slides позволяет управлять скрытыми субтитрами для видеофреймов в презентациях PowerPoint. Субтитры хранятся в формате WebVTT и доступны через свойство [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

### **Добавление субтитров к видеофрейму**

В этом примере встраивается локальное видео и добавляется дорожка субтитров WebVTT с меткой English. Метки времени субтитров должны соответствовать видео. Сохранённая презентация содержит как видео, так и его субтитры.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);
videoFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
```

Интерфейс [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) также предоставляет перегрузку, позволяющую добавлять субтитры из потока.

### **Извлечение субтитров из видеофрейма**

В этом примере сохраняются все дорожки субтитров из видеофреймов первого слайда в отдельные файлы WebVTT. Последовательные номера делают файлы уникальными. Консоль выводит количество извлечённых дорожек. Презентация должна содержать хотя бы один слайд.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var trackCount = 0;
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        foreach (var captionTrack in videoFrame.CaptionTracks)
        {
            trackCount++;
            var outputPath = $"captions_{trackCount}.vtt";
            File.WriteAllBytes(outputPath, captionTrack.BinaryData);
        }
    }
}

Console.WriteLine($"Caption tracks extracted: {trackCount}");
```

Каждый объект [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) раскрывает идентификатор субтитров, метку, бинарные данные и текст субтитров как строку UTF‑8.

### **Удаление субтитров из видеофрейма**

В этом примере удаляются все субтитры из видеофрейма, находящегося в первой позиции фигур на первом слайде, и сохраняется результат. Предполагается, что слайд и фигура существуют, и что фигура является видеофреймом.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var videoFrame = (IVideoFrame) slide.Shapes[0];
videoFrame.CaptionTracks.Clear();

presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
```

Если необходимо удалить только одну дорожку субтитров, используйте методы [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) или [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) вместо [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

### **Поиск субтитров видео**

[ICaptions.DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) возвращает полную дорожку WebVTT, включая заголовок, строки тайминга и текст субтитров. Чтобы найти произнесённую фразу и её метку времени, прочитайте cue‑элементы в памяти. Например, английская дорожка на слайде 2 может содержать следующий текст:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Пример проходит по каждому слайду и читает дорожки его видеофреймов верхнего уровня через [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/). В простом текстовом cue строка тайминга содержит `-->`, а пустая строка завершает cue. Когда текст субтитров содержит «café», пример выводит номер слайда, метку дорожки, оригинальную строку тайминга и полный субтитр.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("captioned_media.pptx");
foreach (var slide in presentation.Slides)
{
    var tracks = slide.Shapes.OfType<IVideoFrame>().SelectMany(frame => frame.CaptionTracks);
    foreach (var track in tracks)
    {
        using var reader = new StringReader(track.DataAsString);
        while (reader.ReadLine() is string timing)
        {
            if (!timing.Contains("-->")) continue;

            var lines = new List<string>();
            while (reader.ReadLine() is string line && line.Length > 0)
                lines.Add(line);

            var caption = string.Join(Environment.NewLine, lines);
            if (caption.Contains("café", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Slide {slide.SlideNumber} | {track.Label} | {timing}");
                Console.WriteLine(caption);
            }
        }
    }
}
```

Поиск «café» даёт одно совпадение для образцовой дорожки. Заголовок и настройка тайминга находятся вне текста cue.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Извлечение видео со слайда**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать встроенное в презентации видео.

В этом примере из каждого слайда извлекаются встроенные видео в отдельные пронумерованные бинарные файлы. Связанные видео пропускаются, так как они не содержат встроенных данных. Консоль выводит MIME‑тип каждого видео и общее количество. Вывод использует обобщённое расширение `.bin`; при необходимости измените его в соответствии с определённым типом медиа.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_videos.pptx");

var videoCount = 0;
foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            var video = videoFrame.EmbeddedVideo;
            if (video == null)
            {
                Console.WriteLine("Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            var outputPath = $"extracted_video_{videoCount}.bin";
            File.WriteAllBytes(outputPath, video.BinaryData);
            Console.WriteLine($"Video {videoCount}: {video.ContentType}");
        }
    }
}

Console.WriteLine($"Embedded videos extracted: {videoCount}");
```

## **FAQ**

**Какие параметры воспроизведения видео можно изменить для видеофрейма?**

Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (автоматически или по клику) и [циклом](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Эти параметры доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео его бинарные данные включаются в документ, поэтому размер презентации растёт пропорционально размеру файла. При ссылке на онлайн‑видео и добавлении миниатюры презентация сохраняет только ссылку и изображение‑превью, а не данные видео, поэтому увеличение размера обычно меньше.

**Можно ли заменить видео в существующем видеофрейме, не меняя его положение и размеры?**

Да. Вы можете заменить [контент видео](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) внутри фрейма, сохранив геометрию фигуры; это распространённый сценарий обновления медиа в уже существующем макете.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. Встроенное видео имеет [тип содержимого](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/), который можно прочитать и использовать, например при сохранении его на диск.