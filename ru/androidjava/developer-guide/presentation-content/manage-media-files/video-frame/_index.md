---
title: Управление видеокадрами в презентациях на Android
linktitle: Видеокадр
type: docs
weight: 10
url: /ru/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "Узнайте, как программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для Android на Java. Быстрое руководство."
---
## **Введение**

Хорошо размещённое видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлечённости аудитории.

PowerPoint позволяет добавлять видео на слайд в презентации двумя способами:

* Добавить или встроить локальное видео (хранящееся на вашем компьютере)
* Добавить онлайн‑видео (из веб‑источника, например YouTube).

Для того чтобы добавить видео‑объекты в презентацию, Aspose.Slides предоставляет интерфейс [IVideo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideo/), интерфейс [IVideoFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideoframe/) и другие соответствующие типы.

## **Создание встроенного кадра видео**

Если файл видео, который вы хотите добавить на слайд, хранится локально, вы можете создать кадр видео для встраивания в презентацию.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation).
1. Получите ссылку на слайд через его индекс.
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideo/) и передайте путь к файлу видео, чтобы встроить его в презентацию.
1. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideoframe/) для создания кадра видео.
1. Сохраните изменённую презентацию.

Этот Java‑код показывает, как добавить локальное видео в презентацию:

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

В качестве альтернативы можно добавить видео, передав путь к файлу напрямую в метод [addVideoFrame(float x,float y,float width,float height,IVideo video)](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-):

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Создание кадра видео с видео из веб‑источника**

Новые версии Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) поддерживают онлайн‑видео в презентациях. Если нужное вам видео доступно в интернете (например, на YouTube), вы можете добавить его в презентацию по ссылке.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation).
1. Получите ссылку на слайд через его индекс.
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideo/) и передайте ссылку на видео.
1. Установите миниатюру для кадра видео.
1. Сохраните презентацию.

Этот Java‑код показывает, как добавить видео из интернета на слайд в презентации PowerPoint:

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

## **Обрезка кадра видео**

Aspose.Slides позволяет управлять тем, какая часть видео будет воспроизводиться, задавая значения trim‑from‑start и trim‑from‑end через методы [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) и [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-). Оба значения указываются в миллисекундах и определяют, сколько времени пропускается с начала и с конца видео соответственно. Эти параметры меняют настройку воспроизведения видео в презентации; они не обрезают и не изменяют бинарные данные встроенного видео.

**Установка параметров обрезки**

Для создания кадра видео и задания ему параметров обрезки:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideo/) в презентацию.
1. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideoframe/) на слайд.
1. Задайте значения trim‑from‑start и trim‑from‑end через методы [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) и [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-).
1. Сохраните изменённую презентацию.

Следующий пример кода пропускает первые 2,5 секунды и последнюю секунду встроенного видео при воспроизведении:

```java
Presentation presentation = new Presentation();
try {
    FileInputStream videoStream = new FileInputStream("video.mp4");
    try {
        IVideo video = presentation.getVideos().addVideo(
                videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
        ISlide slide = presentation.getSlides().get_Item(0);
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500f);
        videoFrame.setTrimFromEnd(1000f);

        presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**Чтение параметров обрезки**

Чтобы получить текущие параметры обрезки, загрузите презентацию, найдите объект [IVideoFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideoframe/) среди фигур на первом слайде и прочитайте значения через методы [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideoframe/#getTrimFromStart--) и [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideoframe/#getTrimFromEnd--).

Следующий пример кода находит первый кадр видео на первом слайде и выводит его параметры обрезки в миллисекундах:

```java
Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            float trimFromStart = videoFrame.getTrimFromStart();
            float trimFromEnd = videoFrame.getTrimFromEnd();

            System.out.println("Trim from start: " + trimFromStart + " ms");
            System.out.println("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Управление субтитрами видео**

Aspose.Slides позволяет управлять закрытыми субтитрами для видеокадров в презентациях PowerPoint. Субтитры хранятся в формате WebVTT и доступны через метод [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).

**Добавление субтитров к кадру видео**

Чтобы добавить субтитры к видеокадру:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
1. Добавьте видео в презентацию.
1. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideoframe/) на слайд.
1. Используйте объект [ICaptionsCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icaptionscollection/), возвращаемый методом [getCaptionTracks](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--), чтобы добавить дорожку субтитров WebVTT.
1. Сохраните изменённую презентацию.

Следующий код показывает, как добавить субтитры к видеокадру:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
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

Интерфейс [ICaptionsCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icaptionscollection/) также предоставляет перегрузку, позволяющую добавить субтитры из потока.

**Извлечение субтитров из кадра видео**

Чтобы извлечь субтитры из видеокадра:

1. Загрузите презентацию, содержащую видео.
1. Найдите целевой объект [IVideoFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideoframe/).
1. Пройдитесь по дорожкам субтитров, возвращаемым методом [getCaptionTracks](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. Сохраните каждую дорожку в файл с расширением `.vtt`.

Следующий код показывает, как извлечь субтитры из видеокадра:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Сохраняет дорожку субтитров в файл WebVTT.
                FileOutputStream outputStream = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                outputStream.write(captionTrack.getBinaryData());
                outputStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Каждый объект [ICaptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icaptions/) раскрывает идентификатор субтитров, метку, бинарные данные и текст субтитров в виде строки UTF‑8.

**Удаление субтитров из кадра видео**

Чтобы удалить субтитры из видеокадра:

1. Загрузите презентацию, содержащую видео.
1. Получите целевой объект [IVideoFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideoframe/).
1. Удалите дорожки субтитров из коллекции, возвращаемой методом [getCaptionTracks](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. Сохраните изменённую презентацию.

Следующий код показывает, как удалить все субтитры из видеокадра:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // Удаляет все субтитры из видеокадра.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Если нужно удалить только одну дорожку субтитров, используйте методы [remove](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) или [removeAt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) вместо [clear](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icaptionscollection/#clear--).

## **Извлечение видео со слайда**

Кроме добавления видео на слайды, Aspose.Slides позволяет извлекать видео, встроенное в презентации.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation) для загрузки презентации, содержащей видео.
2. Пройдитесь по всем объектам [ISlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islide/).
3. Пройдитесь по всем объектам [IShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/) в поиске [VideoFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/videoframe/).
4. Сохраните видео на диск.

Этот Java‑код показывает, как извлечь видео со слайда презентации:

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

Можно управлять [режимом воспроизведения](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (авто или по щелчку) и [цикличностью](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Эти параметры доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/videoframe/).

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео его бинарные данные включаются в документ, поэтому размер презентации растёт пропорционально размеру файла. При добавлении онлайн‑видео встраивается только ссылка и миниатюра, что приводит к меньшему увеличению размера.

**Можно ли заменить видео в существующем VideoFrame, не меняя его позицию и размер?**

Да. Можно заменить [содержимое видео](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) внутри кадра, сохранив геометрию формы; это распространённый сценарий обновления медиа в уже существующем макете.

**Можно ли определить тип контента (MIME) встроенного видео?**

Да. У встроенного видео есть [тип контента](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/video/#getContentType--), который можно прочитать и использовать, например, при сохранении на диск.