---
title: Управление видеокадрами в презентациях с использованием Java
linktitle: Видеокадр
type: docs
weight: 10
url: /ru/java/video-frame/
keywords:
- добавление видео
- создание видео
- встраивание видео
- извлечение видео
- получение видео
- видеокадр
- веб‑источник
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для Java. Быстрое руководство."
---
Правильно размещённое видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлечённости вашей аудитории. 

PowerPoint позволяет добавлять видео на слайд в презентации двумя способами:

* Добавить или встроить локальное видео (хранящееся на вашем компьютере)
* Добавить онлайн‑видео (из веб‑источника, например YouTube).

Чтобы вы могли добавлять видео (видеοобъекты) в презентацию, Aspose.Slides предоставляет интерфейсы [IVideo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ivideo/) , [IVideoFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ivideoframe/) , а также другие соответствующие типы. 

## **Создать встроенные видеокадры**

Если файл видео, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр, чтобы встроить видео в вашу презентацию. 

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation) .
1. Получите ссылку на слайд по его индексу. 
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ivideo/) , указав путь к файлу видео, чтобы встроить его в презентацию. 
1. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ivideoframe/) , чтобы создать кадр для видео.  
1. Сохраните изменённую презентацию. 

Этот код на Java показывает, как добавить локально хранящееся видео в презентацию:

```java
// Создает экземпляр класса Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // Загружает видео
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Получает первый слайд и добавляет видеокадр
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Сохраняет презентацию на диск
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

В качестве альтернативы вы можете добавить видео, передав путь к файлу напрямую в метод [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```


## **Создать видеокадры с видео из веб‑источников**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) поддерживает видео YouTube в презентациях. Если желаемое видео доступно онлайн (например, на YouTube), вы можете добавить его в презентацию через веб‑ссылку. 

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation) .
1. Получите ссылку на слайд по его индексу. 
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ivideo/) , указав ссылку на видео.
1. Установите миниатюру для видеокадра. 
1. Сохраните презентацию. 

Этот код на Java показывает, как добавить видео из веба на слайд в презентации PowerPoint:

```java
// Создает объект Presentation, который представляет файл презентации 
Presentation pres = new Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
private static void addVideoFromYouTube(Presentation pres, String videoID)
{
    // Добавляет видеокадр
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // Загружает миниатюру
    String thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";
    URL url;

    try {
        url = new URL(thumbnailUri);
        videoFrame.getPictureFormat().getPicture().setImage(pres.getImages().addImage(url.openStream()));
    } catch (MalformedURLException e) {
        e.printStackTrace();
    } catch (IOException e) {
        e.printStackTrace();
    }
}
```

## **Управление субтитрами видео**

Aspose.Slides позволяет управлять закрытыми субтитрами для видеокадров в презентациях PowerPoint. Субтитры хранятся в формате WebVTT и доступны через метод [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**Добавить субтитры к видеокадру**

Чтобы добавить субтитры к видеокадру:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) .
1. Добавьте видео в презентацию.
1. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ivideoframe/) на слайд.
1. Используйте [ICaptionsCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icaptionscollection/) , возвращаемый методом [getCaptionTracks](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) , чтобы добавить дорожку субтитров WebVTT.
1. Сохраните изменённую презентацию.

Следующий код показывает, как добавить субтитры к видеокадру:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Добавляет новую дорожку субтитров из файла WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Интерфейс [ICaptionsCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icaptionscollection/) также предоставляет перегрузку, позволяющую добавлять субтитры из потока.

**Извлечь субтитры из видеокадра**

Чтобы извлечь субтитры из видеокадра:

1. Загрузите презентацию, содержащую видео.
1. Найдите целевой объект [IVideoFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ivideoframe/) .
1. Переберите дорожки субтитров в [ICaptionsCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icaptionscollection/) .
1. Сохраните каждую дорожку субтитров в файл с расширением `.vtt` .

Следующий код показывает, как извлечь субтитры из видеокадра:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Сохраняет дорожку субтитров в файл WebVTT.
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Каждый объект [ICaptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icaptions/) раскрывает идентификатор субтитров, метку, двоичные данные и текст субтитров как строку UTF‑8.

**Удалить субтитры из видеокадра**

Чтобы удалить субтитры из видеокадра:

1. Загрузите презентацию, содержащую видео.
1. Получите целевой объект [IVideoFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ivideoframe/) .
1. Удалите дорожки субтитров из [ICaptionsCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icaptionscollection/) .
1. Сохраните изменённую презентацию.

Следующий код показывает, как удалить все субтитры из видеокадра:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // Удаляет все субтитры из видеокадра.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Если необходимо удалить только одну дорожку субтитров, используйте методы [remove](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) или [removeAt](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icaptionscollection/#removeAt-int-) , а не [clear](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icaptionscollection/#clear--) .

## **Извлечь видео со слайдов**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать встраиваемое в презентацию видео.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation) , чтобы загрузить презентацию, содержащую видео. 
2. Переберите все объекты [ISlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islide/) .
3. Переберите все объекты [IShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/) , чтобы найти [VideoFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/videoframe/) . 
4. Сохраните видео на диск.

Этот код на Java показывает, как извлечь видео со слайда презентации:

```java
//Создаёт объект Presentation, который представляет файл презентации 
Presentation pres = new Presentation("VideoSample.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        for (IShape shape : slide.getShapes()) 
        {
            if (shape instanceof VideoFrame) 
            {
                IVideoFrame vf = (IVideoFrame) shape;
                String type = vf.getEmbeddedVideo().getContentType();
                int ss = type.lastIndexOf('-');
                byte[] buffer = vf.getEmbeddedVideo().getBinaryData();

                //Получает расширение файла
                int charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);

                FileOutputStream fop = new FileOutputStream("testing2." + type);
                fop.write(buffer);
                fop.flush();
                fop.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Какие параметры воспроизведения видео можно изменить для VideoFrame?**

Вы можете управлять [playback mode](https://reference.aspose.com/slides/ru/java/com.aspose.slides/videoframe/#setPlayMode-int-) (автоматически или по щелчку) и [looping](https://reference.aspose.com/slides/ru/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) . Эти параметры доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/videoframe/) .

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео двоичные данные включаются в документ, поэтому размер презентации растёт пропорционально размеру файла. При добавлении онлайн‑видео встраивается ссылка и миниатюра, поэтому увеличение размера меньше.

**Могу ли я заменить видео в существующем VideoFrame, не меняя его положение и размер?**

Да. Вы можете заменить [video content](https://reference.aspose.com/slides/ru/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) внутри кадра, сохраняя геометрию формы; это обычный сценарий обновления медиа в существующем макете.

**Можно ли определить тип контента (MIME) встроенного видео?**

Да. Встроенное видео имеет [content type](https://reference.aspose.com/slides/ru/java/com.aspose.slides/video/#getContentType--) , который можно прочитать и использовать, например при сохранении его на диск.