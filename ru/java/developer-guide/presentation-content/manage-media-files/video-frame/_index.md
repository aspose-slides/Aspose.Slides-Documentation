---
title: Управление видеокадрами в презентациях с помощью Java
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
- веб-источник
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Научитесь программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для Java. Быстрое руководство."
---

Хорошо размещённое видео в презентации может сделать ваше сообщение более убедительным и увеличить уровень вовлечённости аудитории. 

PowerPoint позволяет добавлять видео на слайд в презентации двумя способами:

* Добавить или встроить локальное видео (хранящееся на вашем компьютере)
* Добавить онлайн‑видео (из веб‑источника, например YouTube).

Чтобы добавить видео (видеобъекты) в презентацию, Aspose.Slides предоставляет интерфейс [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) , интерфейс [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) и другие соответствующие типы. 

## **Создание встроенных видеокадров**

Если видеофайл, который вы хотите добавить на свой слайд, хранится локально, вы можете создать видеокадр, чтобы встроить видео в презентацию. 

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу. 
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) , передав путь к видеофайлу, чтобы встроить видео в презентацию. 
1. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) , чтобы создать кадр для видео.  
1. Сохраните изменённую презентацию. 

Этот Java‑код демонстрирует, как добавить локально хранящееся видео в презентацию:
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


Кроме того, вы можете добавить видео, передав путь к файлу непосредственно в метод [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-):
``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```



## **Создание видеокадров с видео из веб‑источников**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) поддерживают видео YouTube в презентациях. Если нужное вам видео доступно онлайн (например, на YouTube), вы можете добавить его в презентацию по веб‑ссылке. 

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу. 
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) , передав ссылку на видео.
1. Установите миниатюру для видеокадра. 
1. Сохраните презентацию. 

Этот Java‑код демонстрирует, как добавить видео из интернета на слайд в презентации PowerPoint:
```java
// Создает объект Presentation, представляющий файл презентации
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


## **Извлечение видео со слайдов**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать встроенные в презентацию видео.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) для загрузки презентации, содержащей видео. 
2. Пройдитесь по всем объектам [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/). 
3. Пройдитесь по всем объектам [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/), чтобы найти [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/). 
4. Сохраните видео на диск.

Этот Java‑код демонстрирует, как извлечь видео со слайда презентации:
```java
// Создает объект Presentation, представляющий файл презентации 
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


## **Часто задаваемые вопросы**

**Какие параметры воспроизведения видео можно изменить для VideoFrame?**

Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (авто или по щелчку) и [повтором](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Эти варианты доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/).

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео двоичные данные включаются в документ, поэтому размер презентации увеличивается пропорционально размеру файла. При добавлении онлайн‑видео встраиваются только ссылка и миниатюра, поэтому рост размера меньше.

**Можно ли заменить видео в существующем VideoFrame, не меняя его позицию и размер?**

Да. Вы можете заменить [видеоконтент](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) в кадре, сохранив геометрию фигуры; это распространённый сценарий обновления медиа в существующей разметке.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. Встроенное видео имеет [тип содержимого](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) , который можно прочитать и использовать, например, при сохранении на диск.