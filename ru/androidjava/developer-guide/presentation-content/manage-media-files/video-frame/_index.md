---
title: Видеокадр
type: docs
weight: 10
url: /ru/androidjava/video-frame/
keywords: "Добавить видео, создать видеокадр, извлечь видео, презентация PowerPoint, Java, Aspose.Slides для Android через Java"
description: "Добавьте видеокадр в презентацию PowerPoint на Java"
---

Хорошо размещенное видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлеченности вашей аудитории.

PowerPoint позволяет добавлять видео на слайд в презентации двумя способами:

* Добавить или встроить локальное видео (сохраненное на вашем компьютере)
* Добавить онлайн-видео (из веб-источника, такого как YouTube).

Чтобы вы могли добавлять видео (видеобъекты) в презентацию, Aspose.Slides предоставляет интерфейс [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/), интерфейс [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) и другие актуальные типы.

## **Создание встроенного видеокадра**

Если виде файл, который вы хотите добавить на свой слайд, хранится локально, вы можете создать видеокадр для встраивания видео в вашу презентацию.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите ссылку на слайд через его индекс.
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) и передайте путь к виде файлу для встраивания видео в презентацию.
1. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) для создания рамки для видео.
1. Сохраните измененную презентацию.

Этот код на Java показывает, как добавить видео, хранящееся локально, в презентацию:

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

В качестве альтернативы вы можете добавить видео, передав его путь к файлу напрямую в метод [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-):

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Создание видеокадра с видео из веб-источника**

Microsoft [PowerPoint 2013 и новее](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) поддерживает видео YouTube в презентациях. Если видео, которое вы хотите использовать, доступно онлайн (например, на YouTube), вы можете добавить его в вашу презентацию через его веб-ссылку.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите ссылку на слайд через его индекс.
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) и передайте ссылку на видео.
1. Установите миниатюру для видеокадра.
1. Сохраните презентацию.

Этот код на Java показывает, как добавить видео из интернета на слайд в презентации PowerPoint:

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

## **Извлечение видео из слайда**

Кроме добавления видео на слайды, Aspose.Slides позволяет извлекать видео, встроенные в презентации.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) для загрузки презентации, содержащей видео.
2. Пройдите через все объекты [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/).
3. Пройдите через все объекты [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/), чтобы найти [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/).
4. Сохраните видео на диск.

Этот код на Java показывает, как извлечь видео из слайда презентации:

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