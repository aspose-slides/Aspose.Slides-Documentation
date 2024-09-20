---
title: Видеокадр
type: docs
weight: 10
url: /net/video-frame/
keywords: "Добавить видео, создать видеокадр, извлечь видео, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Добавьте видеокадр в презентацию PowerPoint на C# или .NET"
---

Правильно размещенное видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлеченности вашей аудитории.

PowerPoint позволяет добавлять видео на слайд в презентации двумя способами:

* Добавить или встроить локальное видео (сохраненное на вашем компьютере)
* Добавить онлайн-видео (из веб-источника, такого как YouTube).

Чтобы предоставить возможность добавления видео (видеобъектов) в презентацию, Aspose.Slides предоставляет интерфейс [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/), интерфейс [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) и другие соответствующие типы.

## **Создание встроенного видеокадра**

Если файл видео, который вы хотите добавить на свой слайд, хранится локально, вы можете создать видеокадр для встраивания видео в вашу презентацию.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд через его индекс.
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) и передайте путь к видеофайлу, чтобы встроить видео в презентацию.
1. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/), чтобы создать рамку для видео.
1. Сохраните измененную презентацию.

Этот код C# показывает, как добавить видео, хранящееся локально, в презентацию:

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
В качестве альтернативы вы можете добавить видео, передав его путь к файлу напрямую в метод [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/):

```csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **Создание видеокадра с видео из веб-источника**
Microsoft [PowerPoint 2013 и новее](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) поддерживают видео YouTube в презентациях. Если видео, которое вы хотите использовать, доступно онлайн (например, на YouTube), вы можете добавить его в свою презентацию через его веб-ссылку.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)
1. Получите ссылку на слайд через его индекс.
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) и передайте ссылку на видео.
1. Установите миниатюру для видеокадра.
1. Сохраните презентацию.

Этот код C# показывает, как добавить видео из интернета на слайд в презентации PowerPoint:

```c#
public static void Run()
{
    // Создает экземпляр объекта Presentation, который представляет файл презентации 
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

## **Извлечение видео из слайда**
Кроме добавления видео на слайды, Aspose.Slides позволяет извлекать видео, встроенные в презентации.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), чтобы загрузить презентацию, содержащую видео.
2. Пройдите через все объекты [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).
3. Пройдите через все объекты [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape), чтобы найти [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe).
4. Сохраните видео на диск.

Этот код C# показывает, как извлечь видео со слайда презентации:

```c#
// Создает экземпляр объекта Presentation, который представляет файл презентации 
Presentation presentation = new Presentation("Video.pptx");

// Проходит через слайды
foreach (ISlide slide in presentation.Slides)
{
    // Проходит через фигуры
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