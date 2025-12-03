---
title: Управление видеокадрами в презентациях с использованием Java
linktitle: Видеокадр
type: docs
weight: 10
url: /ru/java/video-frame/
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
- Java
- Aspose.Slides
description: "Научитесь программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с использованием Aspose.Slides для Java. Быстрое руководство."
---

Хорошо размещённое видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлечённости аудитории. 

PowerPoint позволяет добавлять видео на слайд презентации двумя способами:

* Добавить или встроить локальное видео (хранящееся на вашем компьютере)
* Добавить онлайн‑видео (из веб‑источника, например YouTube).

Чтобы вы могли добавлять видео (объекты video) в презентацию, Aspose.Slides предоставляет интерфейсы [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) и [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/), а также другие соответствующие типы. 

## **Create Embedded Video Frames**

Если файл видео, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр, чтобы встроить видео в презентацию. 

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу. 
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) и передайте путь к файлу видео, чтобы встроить его в презентацию. 
1. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) для создания кадра видео.  
1. Сохраните изменённую презентацию. 

Этот код на Java показывает, как добавить локальное видео в презентацию:
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


В качестве альтернативы вы можете добавить видео, передав путь к файлу напрямую в метод [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-):
``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```



## **Create Video Frames with Video from Web Sources**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) поддерживает видео YouTube в презентациях. Если нужное вам видео доступно в интернете (например, на YouTube), вы можете добавить его в презентацию по веб‑ссылке. 

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу. 
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) и передайте ссылку на видео.
1. Установите миниатюру для видеокадра. 
1. Сохраните презентацию. 

Этот код на Java показывает, как добавить видео из интернета на слайд PowerPoint‑презентации:
```java
// Создаёт объект Presentation, который представляет файл презентации
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
    // Добавляет videoFrame
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


## **Extract Video From Slides**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать встроенные в презентацию видеоматериалы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), чтобы загрузить презентацию, содержащую видео. 
2. Переберите все объекты [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/). 
3. Переберите все объекты [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/), чтобы найти [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/). 
4. Сохраните видео на диск.

Этот код на Java показывает, как извлечь видео со слайда презентации:
```java
// Создаёт объект Presentation, представляющий файл презентации 
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

                // Получает расширение файла
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

Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (авто или по щелчку) и [циклическим воспроизведением](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Эти параметры доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/).

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео бинарные данные включаются в документ, поэтому размер презентации увеличивается пропорционально размеру файла. При добавлении онлайн‑видео встраиваются только ссылка и миниатюра, поэтому рост размера меньше.

**Можно ли заменить видео в существующем VideoFrame, не меняя его позицию и размер?**

Да. Вы можете заменить [видео‑контент](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) внутри кадра, сохранив геометрию формы; это частый сценарий обновления медиа в уже существующем макете.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. Встроенное видео имеет [тип содержимого](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--), который можно прочитать и использовать, например, при сохранении на диск.