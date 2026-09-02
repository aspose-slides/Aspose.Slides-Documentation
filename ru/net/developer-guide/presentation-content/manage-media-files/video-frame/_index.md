---
title: Управление видеокадрами в презентациях на .NET
linktitle: Видеокадр
type: docs
weight: 10
url: /ru/net/video-frame/
keywords:
- добавление видео
- создание видео
- встраивание видео
- извлечение видео
- получение видео
- видеокадр
- веб-источник
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для .NET. Быстрое практическое руководство."
---
## **Введение**

Хорошо расположенное видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлечённости вашей аудитории. 

PowerPoint позволяет добавлять видео на слайд в презентации двумя способами:

* Добавить или вставить локальное видео (хранящееся на вашем компьютере)
* Добавить онлайн‑видео (из веб‑источника, например YouTube).

Чтобы дать возможность добавлять видео (видеосредства) в презентацию, Aspose.Slides предоставляет интерфейсы [IVideo](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideo/) и [IVideoFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/), а также другие соответствующие типы. 

## **Создать встроенный видеокадр**

Если видеофайл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр, чтобы встроить видео в презентацию. 

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation)class.
1. Получите ссылку на слайд по его индексу. 
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideo/) и передайте путь к видеофайлу, чтобы встроить видео в презентацию. 
1. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/) , чтобы создать кадр для видео.  
1. Сохраните изменённую презентацию. 

Этот код C# показывает, как добавить локально хранимое видео в презентацию:

```c#
// Создает экземпляр класса Presentation
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Загружает видео
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // Получает первый слайд и добавляет видеокадр
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // Сохраняет презентацию на диск
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
В качестве альтернативы вы можете добавить видео, передав путь к его файлу напрямую методу [AddVideoFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/addvideoframe/) :

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Создать видеокадр с видео из веб‑источника**
Новые версии Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) поддерживают онлайн‑видео в презентациях. Если нужное вам видео доступно онлайн (например, на YouTube), вы можете добавить его в презентацию по его веб‑ссылке.

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation)class
1. Получите ссылку на слайд по его индексу. 
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideo/) и передайте ссылку на видео.
1. Установите миниатюру для видеокадра. 
1. Сохраните презентацию. 

Этот код C# показывает, как добавить видео из веба на слайд в презентации PowerPoint:

```c#
public static void Run()
{
    // Создает объект Presentation, представляющий файл презентации 
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // Добавляет видеокадр
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // Загружает миниатюру
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **Обрезать видеокадр**

Aspose.Slides позволяет управлять тем, какая часть видео воспроизводится, задавая значения trim-from-start и trim-from-end через [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/trimfromstart/) и [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/trimfromend/). Оба значения указаны в миллисекундах и определяют, сколько времени пропускается соответственно с начала и конца видео. Эти настройки изменяют параметры воспроизведения видео в презентации; они не обрезают и не изменяют бинарные данные встроенного видео.

**Установить параметры обрезки**

Чтобы создать видеокадр и задать его параметры обрезки:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) .
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideo/) в презентацию.
1. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/) на слайд.
1. Задайте значения trim-from-start и trim-from-end через [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/trimfromstart/) и [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/trimfromend/) .
1. Сохраните изменённую презентацию.

В следующем примере кода пропускаются первые 2,5 секунды и последняя секунда встроенного видео при воспроизведении:

```cs
using var presentation = new Presentation();

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var slide = presentation.Slides[0];
var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);

videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Прочитать параметры обрезки**

Чтобы просмотреть существующие параметры обрезки, загрузите презентацию, найдите объект [IVideoFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/) среди фигур на первом слайде и прочитайте значения через [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/trimfromstart/) и [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/trimfromend/) .

В следующем примере кода находится первый видеокадр на первом слайде и выводятся его параметры обрезки в миллисекундах:

```cs
using var presentation = new Presentation("video_with_trim.pptx");

var slide = presentation.Slides[0];
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        var trimFromStart = videoFrame.TrimFromStart;
        var trimFromEnd = videoFrame.TrimFromEnd;

        Console.WriteLine($"Trim from start: {trimFromStart} ms");
        Console.WriteLine($"Trim from end: {trimFromEnd} ms");

        break;
    }
}
```

## **Управление субтитрами видео**

Aspose.Slides позволяет управлять закрытыми субтитрами для видеокадров в презентациях PowerPoint. Субтитры хранятся в формате WebVTT и доступны через свойство [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/captiontracks/) .

**Добавить субтитры к видеокадру**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) .
1. Добавьте видео в презентацию.
1. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/) на слайд.
1. Используйте коллекцию [CaptionTracks](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/captiontracks/) , чтобы добавить дорожку субтитров WebVTT.
1. Сохраните изменённую презентацию.

В следующем коде показано, как добавить субтитры к видеокадру:

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // Добавляет новую дорожку субтитров из файла WebVTT.
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

Интерфейс [ICaptionsCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/icaptionscollection/) также предоставляет перегрузку, позволяющую добавлять субтитры из потока.

**Извлечь субтитры из видеокадра**

1. Загрузите презентацию, содержащую видео.
1. Найдите целевой объект [IVideoFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/) .
1. Итерируйтесь по коллекции [CaptionTracks](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/captiontracks/) .
1. Сохраните каждую дорожку субтитров в файл `.vtt` .

В следующем коде показано, как извлечь субтитры из видеокадра:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            foreach (ICaptions captionTrack in videoFrame.CaptionTracks)
            {
                // Сохраняет дорожку субтитров в файл WebVTT.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

Каждый объект [ICaptions](https://reference.aspose.com/slides/ru/net/aspose.slides/icaptions/) раскрывает идентификатор субтитров, метку, бинарные данные и текст субтитров в виде строки UTF-8.

**Удалить субтитры из видеокадра**

1. Загрузите презентацию, содержащую видео.
1. Получите целевой объект [IVideoFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/) .
1. Удалите дорожки субтитров из коллекции [CaptionTracks](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/captiontracks/) .
1. Сохраните изменённую презентацию.

В следующем коде показано, как удалить все субтитры из видеокадра:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Удаляет все субтитры из видеокадра.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

Если необходимо удалить только одну дорожку субтитров, используйте методы [Remove](https://reference.aspose.com/slides/ru/net/aspose.slides/captionscollection/remove/) или [RemoveAt](https://reference.aspose.com/slides/ru/net/aspose.slides/captionscollection/removeat/) , вместо [Clear](https://reference.aspose.com/slides/ru/net/aspose.slides/captionscollection/clear/) .

## **Извлечь видео со слайда**
Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать встроенные в презентации видео.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation) для загрузки презентации, содержащей видео. 
2. Пройдитесь по всем объектам [ISlide](https://reference.aspose.com/slides/ru/net/aspose.slides/islide) .
3. Пройдитесь по всем объектам [IShape](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape) , чтобы найти [VideoFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/videoframe) .
4. Сохраните видео на диск.

Этот код C# показывает, как извлечь видео со слайда презентации:

```c#
// Создает объект Presentation, представляющий файл презентации 
Presentation presentation = new Presentation("Video.pptx");

// Итерируется по слайдам
foreach (ISlide slide in presentation.Slides)
{
    // Итерируется по фигурам
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Сохраняет видео на диск, как только найден VideoFrame, содержащий видео
        if (shape is VideoFrame)
        {
            IVideoFrame vf = shape as IVideoFrame;
            String type = vf.EmbeddedVideo.ContentType;
            int ss = type.LastIndexOf('/');
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            Byte[] buffer = vf.EmbeddedVideo.BinaryData;
            using (FileStream stream = new FileStream("NewVideo_out." + type, FileMode.Create, FileAccess.Write, FileShare.Read))
            {                                                     
                stream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
```

## **FAQ**

**Какие параметры воспроизведения видео можно изменить для VideoFrame?**

Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/ru/net/aspose.slides/videoframe/playmode/) (авто или по щелчку) и [зацикливанием](https://reference.aspose.com/slides/ru/net/aspose.slides/videoframe/playloopmode/) . Эти параметры доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/videoframe/) .

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео его бинарные данные включаются в документ, поэтому размер презентации увеличивается пропорционально размеру файла. При добавлении онлайн‑видео в презентацию встраиваются ссылка и миниатюра, поэтому увеличение размера менее заметно.

**Могу ли я заменить видео в существующем VideoFrame, не меняя его позицию и размер?**

Да. Вы можете заменить [видеоконтент](https://reference.aspose.com/slides/ru/net/aspose.slides/videoframe/embeddedvideo/) внутри кадра, сохранив геометрию фигуры; это распространённый сценарий обновления медиа в существующем макете.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. Встроенное видео имеет [тип содержимого](https://reference.aspose.com/slides/ru/net/aspose.slides/video/contenttype/) , который можно прочитать и использовать, например при сохранении на диск.