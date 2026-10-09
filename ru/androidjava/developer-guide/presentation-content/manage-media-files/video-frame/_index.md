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
- веб‑источник
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для Android через Java. Быстрое руководство."
---
## **Введение**

Видео могут помочь объяснить идеи и привлечь аудиторию. Aspose.Slides for Android через Java позволяет добавлять видеокадры на слайды, настраивать параметры воспроизведения, управлять субтитрами и извлекать встроенные видеоданные.

PowerPoint поддерживает локальные видео и ссылки на онлайн‑видео, такие как видео с YouTube.

Для представления видеоданных и видеокадров Aspose.Slides предоставляет интерфейсы [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) , [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) , а также другие соответствующие типы.

## **Создание встроенного видеокадра**

Если видеофайл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр, чтобы внедрить видео в презентацию.

В этом примере локальное видео внедряется на первый слайд существующей презентации и сохраняется. Координаты и размеры кадра указаны в пунктах. Поток остаётся открытым до завершения сохранения, потому что [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) удерживает его, пока презентация использует его.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.KeepLocked);
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

    presentation.save("embedded_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Вы также можете передать путь к локальному видео напрямую в [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). В этом примере видео внедряется на первый слайд новой презентации. Видео должно оставаться доступным до сохранения презентации.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Создание видеокадра с видео из веб‑источника**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) поддерживает онлайн‑видео в презентациях. Вы можете создать видеокадр, который ссылается на онлайн‑видео, например, видео с YouTube.

В этом примере добавляется ссылка на видео YouTube и миниатюра на **первый** слайд. Замените идентификатор видео, чтобы использовать другое видео. Метод [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) запрашивает автоматическое воспроизведение. Скачивание миниатюры и воспроизведение видео требуют доступа к интернету. Просмотрщик презентаций также должен поддерживать воспроизведение онлайн‑видео.

```java
import com.aspose.slides.*;
import java.io.InputStream;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    String videoId = "aqz-KE-bpKQ";
    String videoUrl = "https://www.youtube.com/embed/" + videoId;
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    String thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    URL thumbnailLocation = new URL(thumbnailUrl);
    try (InputStream thumbnailStream = thumbnailLocation.openStream()) {
        IPPImage thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    }

    presentation.save("online_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Воспроизведение видео в полноэкранном режиме**

В обучающей презентации вы можете воспроизводить демонстрацию программного обеспечения в полноэкранном режиме, чтобы аудитория могла увидеть детали. Вызовите [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) с `true`, чтобы включить это поведение во время воспроизведения.

В этом примере открывается презентация, находится первый [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) на первом слайде и включается полноэкранное воспроизведение. Входная презентация должна содержать как минимум один слайд с существующим видеокадром на первом слайде.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Полноэкранное воспроизведение определяет, как отображается видео. Отдельно, [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) управляет тем, начинается ли оно автоматически или по щелчку, а [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) определяет, будет ли оно повторяться. Чтобы выбрать поведение при запуске, установите режим воспроизведения в [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/). Пример сохраняет существующие настройки запуска и повторения.

## **Перемотка видео после воспроизведения**

В обучающей презентации возврат демонстрационного видео в начало делает его готовым к повторному воспроизведению. Вызовите [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) с `true`, чтобы вернуть видео в начало после завершения воспроизведения.

В этом примере открывается презентация, находится первый [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) на первом слайде и включается перемотка. Отключается повтор, чтобы воспроизведение могло завершиться, и задаётся запуск воспроизведения по щелчку. Входная презентация должна содержать как минимум один слайд с существующим видеокадром на первом слайде.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Перемотка возвращает видео в начало, не запуская его повторно. В отличие от этого, вызов [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) с `true` автоматически повторяет воспроизведение. Отключайте повтор, когда хотите, чтобы видео завершилось и было готово к повторному воспроизведению. [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) независимо управляет автоматическим запуском или запуском по щелчку; в этом примере используется [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) , чтобы презентатор контролировал начало воспроизведения. Устанавливайте режим воспроизведения после настройки повторения, как показано в примере. Перемотка работает независимо от [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Обрезка видеокадра**

Используйте [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) и [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-), чтобы пропускать часть начала или конца видео во время воспроизведения. Оба значения задаются в миллисекундах. Обрезка меняет настройки воспроизведения без изменения встроенных видеоданных.

**Установить параметры обрезки**

В этом примере локальное видео внедряется, а при воспроизведении пропускаются первые 2,5 секунды и последняя секунда. Используйте видео длиной более 3,5 секунды, чтобы оставался воспроизводимый фрагмент.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Прочитать параметры обрезки**

В этом примере выводятся значения обрезки первого видеокадра на первом слайде в миллисекундах. Презентация должна содержать как минимум один слайд. Если у этого слайда нет видеокадра, ничего не выводится. В предыдущем примере получены значения 2500 и 1000.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            System.out.println("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            System.out.println("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Управление субтитрами видео**

Aspose.Slides позволяет управлять закрытыми субтитрами для видеокадров в презентациях PowerPoint. Субтитры хранятся в формате WebVTT и доступны через метод [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**Добавить субтитры к видеокадру**

В этом примере локальное видео внедряется и добавляется дорожка WebVTT с субтитрами, помеченная как English. Метки времени субтитров должны соответствовать видео. Сохранённая презентация включает как видео, так и его субтитры.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Интерфейс [ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) также предоставляет перегрузку, позволяющую добавлять субтитры из потока.

**Извлечь субтитры из видеокадра**

В этом примере все дорожки субтитров из видеокадров на первом слайде сохраняются в отдельные файлы WebVTT. Последовательные номера делают файлы уникальными. Консоль выводит количество извлечённых дорожек. Презентация должна содержать как минимум один слайд.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                try (FileOutputStream outputStream = new FileOutputStream("captions_" + trackCount + ".vtt")) {
                    outputStream.write(captionTrack.getBinaryData());
                }
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Каждый объект [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) раскрывает идентификатор субтитров, метку, бинарные данные и текст субтитров в виде строки UTF‑8.

**Удалить субтитры из видеокадра**

В этом примере удаляются все субтитры из видеокадра, находящегося в первой позиции фигуры на первом слайде, и сохраняется результат. Предполагается, что слайд и фигура существуют и что фигура является видеокадром.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Если необходимо удалить только одну дорожку субтитров, используйте методы [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) или [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) , а не [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--) .

## **Извлечение видео со слайда**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать встроенные в презентацию видео.

В этом примере из каждого слайда извлекаются встроенные видео в отдельные пронумерованные бинарные файлы. Связанные видео пропускаются, так как у них нет встроенных данных. Консоль выводит MIME‑тип каждого видео и общее количество. Выходные файлы используют обобщённое расширение `.bin`; при необходимости измените его в соответствии с указанным типом медиа.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation_with_videos.pptx");
try {
    int videoCount = 0;
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                IVideoFrame videoFrame = (IVideoFrame) shape;
                IVideo video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    System.out.println("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                try (FileOutputStream outputStream = new FileOutputStream("extracted_video_" + videoCount + ".bin")) {
                    outputStream.write(video.getBinaryData());
                }
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **Часто задаваемые вопросы**

**Какие параметры воспроизведения видео можно изменить для видеокадра?**  
Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (авто или по щелчку) и [повтором](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Эти параметры доступны через методы объекта [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/) .

**Влияет ли добавление видео на размер файла PPTX?**  
Да. При внедрении локального видео двоичные данные включаются в документ, поэтому размер презентации растёт пропорционально размеру файла. При ссылке на онлайн‑видео и добавлении миниатюры презентация сохраняет только ссылку и изображение‑превью, а не сами видеоданные, поэтому увеличение размера обычно меньше.

**Могу ли я заменить видео в существующем видеокадре, не меняя его позицию и размеры?**  
Да. Вы можете заменить [видеоконтент](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) внутри кадра, сохранив геометрию фигуры; это распространённый сценарий обновления медиа в существующем макете.

**Можно ли определить тип содержимого (MIME) встроенного видео?**  
Да. Встроенное видео имеет [тип содержимого](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) который вы можете прочитать и использовать, например при сохранении его на диск.