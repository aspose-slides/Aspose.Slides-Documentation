---
title: Управление видеокадрами в презентациях в .NET
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
- веб‑источник
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с использованием Aspose.Slides для .NET. Быстрое пошаговое руководство."
---
Хорошо размещённое видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлечённости аудитории. 

PowerPoint позволяет добавлять видео на слайд в презентации двумя способами:

* Добавить или встроить локальное видео (хранящееся на вашем компьютере)
* Добавить онлайн‑видео (из веб‑источника, например YouTube).

Чтобы вы могли добавлять видео (объекты видео) в презентацию, Aspose.Slides предоставляет интерфейсы [IVideo](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideo/) и [IVideoFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/) и другие соответствующие типы. 

## **Создание встроенного видеокадра**

Если видеофайл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр, чтобы встроить видео в свою презентацию. 

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation)class.
1. Получите ссылку на слайд по его индексу. 
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideo/) и укажите путь к файлу видео, чтобы встроить его в презентацию. 
1. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/) для создания кадра для видео.  
1. Сохраните изменённую презентацию. 

Этот код на C# показывает, как добавить локально хранимое видео в презентацию:

```c#
// Создаёт экземпляр класса Presentation
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
Альтернативно, вы можете добавить видео, передав путь к файлу напрямую методу [AddVideoFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/addvideoframe/):

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Создание видеокадра с видео из веб‑источника**
Microsoft [PowerPoint 2013 и новее](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) поддерживает видео с YouTube в презентациях. Если нужное вам видео доступно онлайн (например, на YouTube), вы можете добавить его в презентацию по его веб‑ссылке. 

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation)class
1. Получите ссылку на слайд по его индексу. 
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideo/) и укажите ссылку на видео.
1. Установите миниатюру для видеокадра. 
1. Сохраните презентацию. 

Этот код на C# показывает, как добавить видео из интернета на слайд в презентации PowerPoint:

```c#
public static void Run()
{
    // Создаёт объект Presentation, представляющий файл презентации 
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

## **Управление субтитрами видео**

Aspose.Slides позволяет управлять закрытыми субтитрами для видеокадров в презентациях PowerPoint. Субтитры хранятся в формате WebVTT и доступны через свойство [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/captiontracks/).

**Добавление субтитров к видеокадру**

Чтобы добавить субтитры к видеокадру:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) .
1. Добавьте видео в презентацию.
1. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/) на слайд.
1. Используйте коллекцию [CaptionTracks](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/captiontracks/) для добавления WebVTT‑трека субтитров.
1. Сохраните изменённую презентацию.

Следующий код показывает, как добавить субтитры к видеокадру:

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

**Извлечение субтитров из видеокадра**

Чтобы извлечь субтитры из видеокадра:

1. Загрузите презентацию, содержащую видео.
1. Найдите целевой объект [IVideoFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/).
1. Пройдитесь по коллекции [CaptionTracks](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/captiontracks/).
1. Сохраните каждый трек субтитров в файл `.vtt`.

Следующий код показывает, как извлечь субтитры из видеокадра:

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

Каждый объект [ICaptions](https://reference.aspose.com/slides/ru/net/aspose.slides/icaptions/) предоставляет идентификатор субтитров, метку, бинарные данные и текст субтитров в виде UTF‑8 строки.

**Удаление субтитров из видеокадра**

Чтобы удалить субтитры из видеокадра:

1. Загрузите презентацию, содержащую видео.
1. Получите целевой объект [IVideoFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/).
1. Удалите треки субтитров из коллекции [CaptionTracks](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/captiontracks/).
1. Сохраните изменённую презентацию.

Следующий код показывает, как удалить все субтитры из видеокадра:

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

Если нужно удалить только один трек субтитров, используйте методы [Remove](https://reference.aspose.com/slides/ru/net/aspose.slides/captionscollection/remove/) или [RemoveAt](https://reference.aspose.com/slides/ru/net/aspose.slides/captionscollection/removeat/) вместо [Clear](https://reference.aspose.com/slides/ru/net/aspose.slides/captionscollection/clear/).

## **Извлечение видео со слайда**
Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать встроенные в презентацию видео.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation) для загрузки презентации, содержащей видео. 
2. Пройдитесь по всем объектам [ISlide](https://reference.aspose.com/slides/ru/net/aspose.slides/islide).
3. Пройдитесь по всем объектам [IShape](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape), чтобы найти [VideoFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/videoframe). 
4. Сохраните видео на диск.

Этот код на C# показывает, как извлечь видео со слайда презентации:

```c#
// Создаёт объект Presentation, представляющий файл презентации 
Presentation presentation = new Presentation("Video.pptx");

// Перебирает слайды
foreach (ISlide slide in presentation.Slides)
{
    // Перебирает фигуры
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

Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/ru/net/aspose.slides/videoframe/playmode/) (авто или по щелчку) и [цикличностью](https://reference.aspose.com/slides/ru/net/aspose.slides/videoframe/playloopmode/). Эти параметры доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/videoframe/).

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео бинарные данные включаются в документ, поэтому размер презентации увеличивается пропорционально размеру файла. При добавлении онлайн‑видео в документ встраиваются ссылка и миниатюра, поэтому увеличение размера оказывается меньше.

**Можно ли заменить видео в существующем VideoFrame, не меняя его положения и размеров?**

Да. Вы можете заменить [видеоконтент](https://reference.aspose.com/slides/ru/net/aspose.slides/videoframe/embeddedvideo/) внутри кадра, сохранив геометрию фигуры; это типичный сценарий обновления медиа в уже существующей раскладке.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. Встроенное видео имеет [тип содержимого](https://reference.aspose.com/slides/ru/net/aspose.slides/video/contenttype/), который можно прочитать и использовать, например при сохранении на диск.