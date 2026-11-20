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
description: "Изучите, как программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для Java. Быстрое руководство‑по‑шагам."
---
## **Введение**

Видео могут помочь объяснить идеи и заинтересовать аудиторию. Aspose.Slides for Java позволяет добавлять видеокадры на слайды, настраивать параметры воспроизведения, управлять субтитрами и извлекать встроенные видеоданные.

PowerPoint поддерживает локальные видео и ссылки на онлайн‑видео, такие как видео YouTube.

Для представления видеоданных и видеокадров Aspose.Slides предоставляет интерфейсы [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) и [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) , а также другие соответствующие типы.

## **Создать встроенный видеокадр**

Если видеофайл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр для встраивания видео в презентацию.

Этот пример внедряет локальное видео на первый слайд существующей презентации и сохраняет результат. Координаты и размеры кадра задаются в пунктах. Поток остаётся открытым до завершения сохранения, потому что [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) удерживает его заблокированным, пока презентация его использует.

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

Вы также можете передать путь к локальному видео напрямую в [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Этот пример встраивает видео на первый слайд новой презентации. Видео должно оставаться доступным до тех пор, пока презентация не будет сохранена.

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

## **Создать видеокадр с видео из веб‑источника**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) поддерживает онлайн‑видео в презентациях. Вы можете создать видеокадр, который ссылается на онлайн‑видео, например, видео с YouTube.

Этот пример добавляет ссылку на YouTube‑видео и миниатюру на первый слайд. Замените идентификатор видео, чтобы использовать другое видео. Метод [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) запрашивает автоматическое воспроизведение. Загрузка миниатюры и воспроизведение видео требуют доступа к Интернету. Просмотрщик презентаций также должен поддерживать онлайн‑воспроизведение видео.

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

## **Воспроизвести видео в полноэкранном режиме**

В учебной презентации вы можете воспроизводить демонстрацию программного обеспечения в полноэкранном режиме, чтобы аудитория могла увидеть детали. Вызовите [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) с `true`, чтобы включить это поведение во время воспроизведения.

Этот пример открывает презентацию, ищет первый [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) на первом слайде и включает полноэкранное воспроизведение. Входная презентация должна содержать как минимум один слайд с существующим видеокадром на первом слайде.

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

Полноэкранное воспроизведение управляет тем, как отображается видео. Независимо от этого, [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) контролирует, начинается ли оно автоматически или по щелчку, а [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) контролирует, будет ли оно повторяться. Чтобы выбрать поведение запуска, установите режим воспроизведения в [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/). Пример сохраняет существующие параметры запуска и зацикливания.

## **Перемотать видео после воспроизведения**

В учебной презентации возвращение демонстрационного видео в начало делает его готовым к повторному воспроизведению. Вызовите [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) с `true`, чтобы вернуть видео в начало после завершения воспроизведения.

Этот пример открывает презентацию, ищет первый [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) на первом слайде и включает перемотку. Он отключает зацикливание, чтобы воспроизведение могло завершиться, и устанавливает запуск воспроизведения по щелчку. Входная презентация должна содержать как минимум один слайд с существующим видеокадром на первом слайде.

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

Перемотка возвращает видео к началу без повторного запуска. В отличие от этого, вызов [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) с `true` автоматически повторяет воспроизведение. Оставляйте зацикливание отключённым, когда хотите, чтобы видео закончилось и было готово к повтору. [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) независимо контролирует автоматический или по‑клику запуск; в примере используется [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/), чтобы презентатор управлял началом воспроизведения. Установите режим воспроизведения после настройки зацикливания, как показано в примере. Перемотка работает независимо от [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Обрезать видеокадр**

Используйте [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) и [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) чтобы пропустить часть начала или конца видео во время воспроизведения. Оба значения указываются в миллисекундах. Обрезка изменяет параметры воспроизведения без изменения встроенных видеоданных.

**Установить параметры обрезки**

Этот пример внедряет локальное видео и пропускает первые 2,5 секунды и последнюю секунду во время воспроизведения. Используйте видео длиннее 3,5 секунд, чтобы оставался воспроизводимый сегмент.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Прочитать параметры обрезки**

Этот пример выводит значения обрезки первого видеокадра на первом слайде в миллисекундах. Презентация должна содержать хотя бы один слайд. Если на этом слайде нет видеокадра, ничего не будет выведено. Предыдущий пример даёт значения 2500 и 1000.

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

Aspose.Slides позволяет управлять закрытыми субтитрами для видеокадров в презентациях PowerPoint. Субтитры хранятся в формате WebVTT и доступны через метод [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--).

### **Добавить субтитры к видеокадру**

Этот пример внедряет локальное видео и добавляет дорожку субтитров WebVTT с меткой English. Метки времени субтитров должны соответствовать видео. Сохранённая презентация включает как видео, так и его субтитры.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Интерфейс [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) также предоставляет перегрузку, позволяющую добавлять субтитры из потока.

### **Извлечь субтитры из видеокадра**

Этот пример сохраняет все дорожки субтитров из видеокадров первого слайда в отдельные файлы WebVTT. Последовательные номера делают файлы различимыми. Консоль выводит количество извлечённых дорожек. Презентация должна содержать хотя бы один слайд.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                Path outputPath = Paths.get("captions_" + trackCount + ".vtt");
                Files.write(outputPath, captionTrack.getBinaryData());
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Каждый объект [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) раскрывает идентификатор субтитров, метку, двоичные данные и текст субтитров как строку UTF‑8.

### **Удалить субтитры из видеокадра**

Этот пример удаляет все субтитры из видеокадра, расположенного в первой позиции фигуры на первом слайде, и сохраняет результат. Предполагается, что слайд и фигура существуют и что фигура является видеокадром.

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

Если нужно удалить только одну дорожку субтитров, используйте методы [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) или [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) вместо [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--).

### **Поиск субтитров видео**

[ICaptions.getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) возвращает полную дорожку WebVTT, включая заголовок, строки с таймингом и текст субтитров. Можно искать подсказки в памяти, чтобы найти произнесённую фразу и её метку времени. Например, английская дорожка на слайде 2 может содержать следующий текст.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Пример открывает `captioned_media.pptx` и использует [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) для чтения дорожек каждого видеокадра верхнего уровня на всех слайдах. В текстовой подсказке строка тайминга содержит `-->`, а пустая строка завершает подсказку. Когда субтитры содержат слово «café» в любом регистре, пример выводит номер слайда, метку дорожки, оригинальную строку тайминга и полный текст субтитров.

```java
import com.aspose.slides.*;
import java.util.Locale;
import java.util.Scanner;
import java.util.StringJoiner;

Presentation presentation = new Presentation("captioned_media.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IVideoFrame)) {
                continue;
            }
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions track : videoFrame.getCaptionTracks()) {
                try (Scanner reader = new Scanner(track.getDataAsString())) {
                    while (reader.hasNextLine()) {
                        String timing = reader.nextLine();
                        if (!timing.contains("-->")) {
                            continue;
                        }
                        StringJoiner caption = new StringJoiner(System.lineSeparator());
                        while (reader.hasNextLine()) {
                            String line = reader.nextLine();
                            if (line.isEmpty()) {
                                break;
                            }
                            caption.add(line);
                        }
                        if (caption.toString().toLowerCase(Locale.ROOT).contains("café")) {
                            System.out.printf("Slide %d | %s | %s%n", slide.getSlideNumber(), track.getLabel(), timing);
                            System.out.println(caption);
                        }
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Поиск «café» даёт одно совпадение для образцовой дорожки. Поиск исключает заголовок дорожки и сохраняет настройки тайминга в выводе.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Извлечь видео со слайда**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать видео, встроенные в презентации.

Этот пример извлекает встроенные видео со всех слайдов в отдельные пронумерованные двоичные файлы. Связанные видео пропускаются, так как у них нет встроенных данных. Консоль выводит MIME‑тип каждого видео и общее количество. Вывод использует общий расширение `.bin`; при необходимости измените его в соответствии с обнаруженным типом медиа.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
                Path outputPath = Paths.get("extracted_video_" + videoCount + ".bin");
                Files.write(outputPath, video.getBinaryData());
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **ЧаВо**

**Какие параметры воспроизведения видео можно изменить для видеокадра?**

Можно управлять [режимом воспроизведения](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (авто или по щелчку) и [зацикливанием](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Эти возможности доступны через методы объекта [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/).

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео его двоичные данные включаются в документ, поэтому размер презентации растёт пропорционально размеру файла. При ссылке на онлайн‑видео и добавлении миниатюры презентация сохраняет только ссылку и изображение‑превью, а не сами видеоданные, поэтому увеличение размера обычно меньше.

**Могу ли я заменить видео в существующем видеокадре, не меняя его положение и размер?**

Да. Вы можете заменить [видеоконтент](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) внутри кадра, сохранив геометрию фигуры; это распространённый сценарий обновления медиа в уже существующей раскладке.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. Встроенное видео имеет [тип содержимого](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) , который можно прочитать и использовать, например, при сохранении его на диск.