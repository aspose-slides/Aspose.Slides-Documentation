---
title: Управление видеокадрами в презентациях на .NET
linktitle: Видеокадр
type: docs
weight: 10
url: /ru/net/video-frame/
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
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с использованием Aspose.Slides для .NET. Быстрое практическое руководство."
---
## **Введение**

Видео может помочь объяснить идеи и привлечь аудиторию. Aspose.Slides for .NET позволяет добавлять видеокадры на слайды, настраивать параметры воспроизведения, управлять субтитрами и извлекать вложенные видеоданные.

PowerPoint поддерживает локальные видео и ссылки на онлайн‑видео, такие как видео YouTube.

Для представления видеоданных и видеокадров Aspose.Slides предоставляет интерфейсы [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) , [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) , а также другие соответствующие типы.

## **Создание встроенного видеокадра**

Если видеофайл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр для встраивания видео в презентацию.

Этот пример встраивает локальное видео на первый слайд существующей презентации и сохраняет результат. Координаты и размеры кадра указаны в пунктах. Поток остаётся открытым до завершения сохранения, потому что [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) блокирует его, пока презентация использует его.

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

Вы также можете передать путь к локальному видео напрямую в [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). Этот пример встраивает видео на первый слайд новой презентации. Видео должно оставаться доступным до сохранения презентации.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Создание видеокадра с видео из веб‑источника**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) поддерживает онлайн‑видео в презентациях. Вы можете создать видеокадр, который ссылается на онлайн‑видео, например, видео YouTube.

Этот пример добавляет ссылку на видео YouTube и миниатюру на первый слайд. Замените идентификатор видео, чтобы использовать другое видео. Параметр [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) запрашивает автоматическое воспроизведение. Загрузка миниатюры и воспроизведение видео требуют доступа к интернету. Просмотрщик презентаций также должен поддерживать воспроизведение онлайн‑видео.

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

В обучающей презентации вы можете воспроизводить демонстрацию программного обеспечения в полноэкранном режиме, чтобы аудитория могла видеть детали. Установите [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) в `true`, чтобы включить это поведение во время воспроизведения.

Этот пример открывает презентацию, находит первый [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) на первом слайде и включает полноэкранное воспроизведение. Исходная презентация должна содержать как минимум один слайд с существующим видеокадром на первом слайде.

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

Полноэкранное воспроизведение управляет тем, как отображается видео. Отдельно [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) контролирует, начинается ли воспроизведение автоматически или по щелчку, а [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) определяет, будет ли оно повторяться. Чтобы выбрать поведение запуска, установите режим воспроизведения в [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). Пример сохраняет существующие настройки запуска и повторения.

## **Перемотка видео после воспроизведения**

В обучающей презентации возврат демонстрационного видео в начало делает его готовым к повторному воспроизведению. Установите [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) в `true`, чтобы вернуть видео к началу после завершения воспроизведения.

Этот пример открывает презентацию, находит первый [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) на первом слайде и включает перемотку. Он отключает повтор, чтобы воспроизведение могло завершиться, и устанавливает запуск воспроизведения по щелчку. Исходная презентация должна содержать как минимум один слайд с существующим видеокадром на первом слайде.

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

Перемотка возвращает видео к началу без повторного запуска. В противоположность этому включение [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) повторяет воспроизведение автоматически. Отключайте повтор, когда нужно, чтобы видео закончилось и было готово к повторному запуску. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) независимо управляет автоматическим или щелчковым запуском; в этом примере используется [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/), чтобы презентатор контролировал начало воспроизведения. Устанавливайте режим воспроизведения после настройки повторения, как показано в примере. Перемотка работает независимо от [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Обрезка видеокадра**

Используйте [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) и [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) для пропуска части начала или конца видео во время воспроизведения. Оба значения указываются в миллисекундах. Обрезка меняет параметры воспроизведения без изменения вложенных видеоданных.

**Установить параметры обрезки**

Этот пример встраивает локальное видео и пропускает первые 2,5 секунды и последнюю секунду во время воспроизведения. Используйте видео длительностью более 3,5 секунд, чтобы остался воспроизводимый сегмент.

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

**Прочитать параметры обрезки**

Этот пример выводит в консоль значения обрезки первого видеокадра на первом слайде в миллисекундах. Презентация должна содержать как минимум один слайд. Если на этом слайде нет видеокадра, ничего не будет выведено. Предыдущий пример выдаёт значения 2500 и 1000.

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

Aspose.Slides позволяет управлять закрытыми субтитрами для видеокадров в презентациях PowerPoint. Субтитры хранятся в формате WebVTT и доступны через свойство [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

**Добавить субтитры к видеокадру**

Этот пример встраивает локальное видео и добавляет дорожку субтитров WebVTT с меткой English. Временные метки субтитров должны соответствовать видео. Сохранённая презентация содержит как видео, так и его субтитры.

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

Интерфейс [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) также предоставляет перегрузку, позволяющую добавить субтитры из потока.

**Извлечь субтитры из видеокадра**

Этот пример сохраняет все дорожки субтитров с видеокадров на первом слайде в отдельные файлы WebVTT. Последовательные номера делают файлы уникальными. Консоль выводит количество извлечённых дорожек. Презентация должна содержать как минимум один слайд.

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

Каждый объект [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) раскрывает идентификатор субтитров, метку, бинарные данные и текст субтитров в виде строки UTF‑8.

**Удалить субтитры из видеокадра**

Этот пример удаляет все субтитры из видеокадра, находящегося в позиции первой фигуры на первом слайде, и сохраняет результат. Предполагается, что слайд и фигура существуют и что фигура является видеокадром.

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

Если нужно удалить только одну дорожку субтитров, используйте методы [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) или [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/), а не [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

## **Извлечение видео со слайда**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать вложенные в презентацию видео.

Этот пример извлекает встроенные видео со всех слайдов в отдельные пронумерованные бинарные файлы. Связанные видео пропускаются, потому что у них нет вложенных данных. Консоль выводит MIME‑тип каждого видео и общее количество. Выходные файлы используют общее расширение `.bin`; при необходимости измените его в соответствии с указанным типом медиа.

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

**Какие параметры воспроизведения видео можно изменить для видеокадра?**

Вы можете контролировать [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (авто или по щелчку) и [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Эти параметры доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео бинарные данные включаются в документ, поэтому размер презентации увеличивается пропорционально размеру файла. При ссылке на онлайн‑видео и добавлении миниатюры презентация хранит лишь ссылку и изображение‑превью, а не видеоданные, поэтому рост размера обычно меньше.

**Могу ли я заменить видео в существующем видеокадре, не меняя его позицию и размеры?**

Да. Вы можете заменить [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) внутри кадра, сохранив геометрию фигуры; это распространённый сценарий обновления медиа в существующей компоновке.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. Встроенное видео имеет [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/), который можно прочитать и использовать, например, при сохранении его на диск.