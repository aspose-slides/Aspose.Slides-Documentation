---
title: Видеокадр
type: docs
weight: 10
url: /ru/net/video-frame/
keywords: "Добавить видео, создать видеокадр, извлечь видео, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Добавить видеокадр в презентацию PowerPoint на C# или .NET"
---

Хорошо размещённое видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлечённости аудитории. 

PowerPoint позволяет добавлять видео на слайд в презентации двумя способами:

* Добавить или встроить локальное видео (хранящееся на вашем компьютере)
* Добавить онлайн‑видео (из веб‑источника, например YouTube).

Чтобы добавить видео (объекты видео) в презентацию, Aspose.Slides предоставляет интерфейс [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/), интерфейс [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) и другие соответствующие типы. 

## **Создание встроенного видеокадра**

Если видеофайл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр, чтобы встроить видео в вашу презентацию. 

1. Создайте экземпляр [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class. 
1. Получите ссылку на слайд по его индексу. 
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) и передайте путь к видеофайлу, чтобы встроить видео в презентацию. 
1. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) для создания кадра видео.  
1. Сохраните изменённую презентацию. 

Этот код C# показывает, как добавить локально хранимое видео в презентацию:
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

В качестве альтернативы вы можете добавить видео, передав путь к файлу напрямую методу [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/):
``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```



## **Создание видеокадра с видео из веб‑источника**
Microsoft [PowerPoint 2013 и новее](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) поддерживает видео с YouTube в презентациях. Если нужное вам видео доступно онлайн (например, на YouTube), вы можете добавить его в презентацию через его веб‑ссылку. 

1. Создайте экземпляр [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class 
1. Получите ссылку на слайд по его индексу. 
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) и передайте ссылку на видео. 
1. Установите миниатюру для видеокадра. 
1. Сохраните презентацию. 

Этот код C# показывает, как добавить видео из веба на слайд в презентации PowerPoint:
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


## **Извлечение видео со слайда**
Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать встроенные в презентацию видео.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) для загрузки презентации, содержащей видео. 
2. Переберите все объекты [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide). 
3. Переберите все объекты [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape), чтобы найти [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe). 
4. Сохраните видео на диск.

Этот код C# показывает, как извлечь видео со слайда презентации:
```c#
// Создает объект Presentation, представляющий файл презентации 
Presentation presentation = new Presentation("Video.pptx");

// Перебирает слайды
foreach (ISlide slide in presentation.Slides)
{
    // Перебирает формы
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

Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (авто или по щелчку) и [цикличностью](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Эти параметры доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео двоичные данные включаются в документ, поэтому размер презентации увеличивается пропорционально размеру файла. При добавлении онлайн‑видео встраиваются только ссылка и миниатюра, поэтому прирост размера меньше.

**Могу ли я заменить видео в существующем VideoFrame, не изменяя его положение и размер?**

Да. Вы можете заменить [видеоконтент](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) в кадре, сохранив геометрию формы; это распространённый сценарий обновления медиа в уже существующем макете.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. Встроенное видео имеет [тип содержимого](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/), который вы можете прочитать и использовать, например при сохранении его на диск.