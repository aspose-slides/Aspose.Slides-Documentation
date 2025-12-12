---
title: Управление видеокадрами в презентациях на Android
linktitle: Видеокадр
type: docs
weight: 10
url: /ru/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "Узнайте, как программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для Android на Java. Быстрое руководство."
---

Хорошо размещённое видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлечённости аудитории.  

PowerPoint позволяет добавлять видео на слайд в презентации двумя способами:

* Добавить или встроить локальное видео (хранящееся на вашем компьютере)
* Добавить онлайн‑видео (из веб‑источника, например YouTube).

Чтобы вы могли добавлять видео (объекты видео) в презентацию, Aspose.Slides предоставляет интерфейсы [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) и [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/), а также другие соответствующие типы.

## **Создание встроенного видеокадра**

Если видеофайл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр, чтобы встроить видео в презентацию.  

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)class.  
1. Получите ссылку на слайд через его индекс.  
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) и передайте путь к файлу видео, чтобы встроить видео в презентацию.  
1. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) для создания кадра для видео.  
1. Сохраните изменённую презентацию.  

Этот код Java показывает, как добавить локальное видео в презентацию:
```java
// Создаёт экземпляр класса Presentation
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


В качестве альтернативы вы можете добавить видео, передав путь к файлу непосредственно в метод [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :
``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```


## **Создание видеокадра с видео из веб‑источника**

Microsoft [PowerPoint 2013 и новее](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) поддерживает видео YouTube в презентациях. Если видео, которое вы хотите использовать, доступно онлайн (например, на YouTube), вы можете добавить его в презентацию через веб‑ссылку.  

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)class  
1. Получите ссылку на слайд через его индекс.  
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) и передайте ссылку на видео.  
1. Установите миниатюру для видеокадра.  
1. Сохраните презентацию.  

Этот код Java показывает, как добавить видео из веба на слайд в презентации PowerPoint:
```java
// Создаёт объект Presentation, представляющий файл презентации 
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


## **Извлечение видео со слайда**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать видео, встроенные в презентации.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) для загрузки презентации, содержащей видео.  
2. Переберите все объекты [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/).  
3. Переберите все объекты [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) для поиска [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/).  
4. Сохраните видео на диск.  

Этот код Java показывает, как извлечь видео со слайда презентации:
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


## **FAQ**

**Какие параметры воспроизведения видео можно изменить для VideoFrame?**

Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (авто или по клику) и [циклом воспроизведения](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Эти параметры доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/).

**Влияет ли добавление видео на размер файла PPTX?**

Да. Когда вы встраиваете локальное видео, бинарные данные включаются в документ, поэтому размер презентации возрастает пропорционально размеру файла. При добавлении онлайн‑видео встраивается ссылка и миниатюра, поэтому увеличение размера меньше.

**Можно ли заменить видео в существующем VideoFrame, не меняя его положение и размер?**

Да. Вы можете заменить [видео‑контент](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) внутри кадра, сохранив геометрию формы; это обычный сценарий обновления медиа в существующей раскладке.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. Встроенное видео имеет [тип содержимого](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) , который можно прочитать и использовать, например, при сохранении его на диск.