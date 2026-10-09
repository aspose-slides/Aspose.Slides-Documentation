---
title: Управление видеокадрами в презентациях с использованием Node.js
linktitle: Видеокадр
type: docs
weight: 10
url: /ru/nodejs-java/video-frame/
keywords:
- добавить видео
- создать видео
- внедрить видео
- извлечь видео
- получить видео
- видеокадр
- веб-источник
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Изучите, как программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument, используя Aspose.Slides for Node.js via Java. Быстрое руководство."
---
## **Введение**

Видео может помочь объяснить идеи и привлечь аудиторию. Aspose.Slides for Node.js via Java позволяет добавлять видеокадры на слайды, настраивать параметры воспроизведения, управлять субтитрами и извлекать встроенные видеоданные.

PowerPoint поддерживает локальные видео и ссылки на онлайн‑видео, такие как видео YouTube.

Для представления видеоданных и видеокадров Aspose.Slides предоставляет класс [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/), класс [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) и другие соответствующие типы.

## **Создать встроенный видеокадр**

Если видеофайл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр, чтобы встроить видео в презентацию.

В этом примере локальное видео встраивается на первый слайд существующей презентации и сохраняется результат. Координаты и размеры кадра указаны в пунктах. Поток остаётся открытым до завершения сохранения, потому что [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) удерживает его, пока презентация его использует.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const slide = presentation.getSlides().get_Item(0);

        const video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

        presentation.save("embedded_video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

Вы также можете передать путь к локальному видео напрямую в [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/). В этом примере видео встраивается на первый слайд новой презентации. Видео должно оставаться доступным до сохранения презентации.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Создать видеокадр с видео из веб‑источника**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) поддерживает онлайн‑видео в презентациях. Вы можете создать видеокадр, который ссылается на онлайн‑видео, например видео YouTube.

В этом примере добавляется ссылка на видео YouTube и миниатюра на первый слайд. Замените идентификатор видео, чтобы использовать другое видео. Метод [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) запрашивает автоматическое воспроизведение. Скачивание миниатюры и воспроизведение видео требуют доступа к Интернету. Приложение для просмотра презентаций также должно поддерживать воспроизведение онлайн‑видео.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoId = "aqz-KE-bpKQ";
    const videoUrl = "https://www.youtube.com/embed/" + videoId;
    const videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    const thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    const thumbnailLocation = java.newInstanceSync("java.net.URL", thumbnailUrl);
    const thumbnailStream = thumbnailLocation.openStream();
    try {
        const thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    } finally {
        thumbnailStream.close();
    }

    presentation.save("online_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Воспроизвести видео в полноэкранном режиме**

В учебной презентации вы можете воспроизводить демонстрацию программного обеспечения в полноэкранном режиме, чтобы аудитория видела детали. Вызовите [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) с `true`, чтобы включить это поведение во время воспроизведения.

В этом примере открывается презентация, находится первый [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) на первом слайде и включается полноэкранное воспроизведение. Входная презентация должна содержать хотя бы один слайд с существующим видеокадром на первом слайде.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Полноэкранное воспроизведение определяет, как отображается видео. Независимо от этого [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) управляет тем, начинается ли воспроизведение автоматически или по щелчку, а [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) управляет повтором. Чтобы выбрать поведение запуска, задайте режим воспроизведения [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/). Пример сохраняет существующие настройки запуска и цикла.

## **Перемотать видео после воспроизведения**

В учебной презентации возвращение демонстрационного видео к началу делает его готовым к повторному воспроизведению. Вызовите [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) с `true`, чтобы вернуть видео к началу после завершения воспроизведения.

В этом примере открывается презентация, находится первый [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) на первом слайде и включается перемотка. Отключается цикл, чтобы воспроизведение могло завершиться, и задаётся запуск воспроизведения по щелчку. Входная презентация должна содержать хотя бы один слайд с существующим видеокадром на первом слайде.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Перемотка возвращает видео к началу без повторного запуска. В отличие от этого, вызов [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) с `true` автоматически повторяет воспроизведение. Оставляйте цикл отключённым, когда нужно, чтобы видео завершилось и было готово к повторному воспроизведению. [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) независимо управляет автоматическим запуском или запуском по щелчку; в этом примере используется [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/), чтобы презентер контролировал, когда начинается воспроизведение. Устанавливайте режим воспроизведения после настройки цикла, как показано в примере. Перемотка работает независимо от [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/).

## **Обрезать видеокадр**

Используйте [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) и [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/), чтобы пропустить часть начала или конца видео во время воспроизведения. Оба значения указываются в миллисекундах. Обрезка меняет настройки воспроизведения без изменения встроенных видеоданных.

**Настройка обрезки**

В этом примере встраивается локальное видео и пропускаются первые 2,5 секунды и последняя секунда во время воспроизведения. Используйте видео длиннее 3,5 секунды, чтобы оставался воспроизводимый сегмент.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500);
    videoFrame.setTrimFromEnd(1000);

    presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Чтение настроек обрезки**

В этом примере выводятся значения обрезки первого видеокадра на первом слайде в миллисекундах. Презентация должна содержать как минимум один слайд. Если у этого слайда нет видеокадра, ничего не выводится. Предыдущий пример выдаёт значения 2500 и 1000.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            console.log("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            console.log("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Управление субтитрами видео**

Aspose.Slides позволяет управлять закрытыми субтитрами для видеокадров в презентациях PowerPoint. Субтитры хранятся в формате WebVTT и доступны через метод [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

**Добавить субтитры к видеокадру**

В этом примере встраивается локальное видео и добавляется дорожка субтитров WebVTT с меткой English. Метки времени субтитров должны соответствовать видео. Сохранённая презентация содержит как видео, так и его субтитры.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Класс [CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) также предоставляет метод [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) для добавления субтитров из потока.

**Извлечь субтитры из видеокадра**

В этом примере сохраняются все дорожки субтитров из видеокадров на первом слайде в отдельные файлы WebVTT. Последовательные номера делают выходные файлы различимыми. Консоль выводит количество извлечённых дорожек. Презентация должна содержать как минимум один слайд.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let trackCount = 0;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            for (let trackIndex = 0; trackIndex < videoFrame.getCaptionTracks().getCount(); trackIndex++) {
                const captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                trackCount++;
                const outputPath = "captions_" + trackCount + ".vtt";
                const outputData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
            }
        }
    }

    console.log("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Каждый объект [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) раскрывает идентификатор субтитров, метку, бинарные данные и текст субтитров в виде строки UTF-8.

**Удалить субтитры из видеокадра**

В этом примере удаляются все субтитры из видеокадра, находящегося в первой позиции формы на первом слайде, и сохраняется результат. Предполагается, что слайд и форма существуют и что форма является видеокадром.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoFrame = slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Если нужно удалить только одну дорожку субтитров, используйте методы [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) или [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) вместо [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear).

## **Извлечь видео со слайда**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать встроенные в презентацию видео.

В этом примере извлекаются встроенные видео со всех слайдов в отдельные пронумерованные бинарные файлы. Связанные видео пропускаются, так как они не содержат встроенных данных. Консоль выводит тип MIME каждого видео и общее количество. Вывод использует общее расширение `.bin`; при необходимости измените его в соответствии с типом медиа.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("presentation_with_videos.pptx");
try {
    let videoCount = 0;
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shape;
                const video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    console.log("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                const outputPath = "extracted_video_" + videoCount + ".bin";
                const outputData = Buffer.from(video.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
                console.log("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    console.log("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Какие параметры воспроизведения видео можно изменить для видеокадра?**

Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (авто или по щелчку) и [циклическим воспроизведением](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Эти параметры доступны через методы объекта [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео бинарные данные включаются в документ, поэтому размер презентации увеличивается пропорционально размеру файла. При ссылке на онлайн‑видео и добавлении миниатюры презентация хранит только ссылку и изображение превью вместо видеоданных, поэтому увеличение размера обычно меньше.

**Могу ли я заменить видео в существующем видеокадре без изменения его положения и размеров?**

Да. Вы можете заменить [видеоконтент](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) внутри кадра, сохранив геометрию формы; это распространённый сценарий обновления медиа в существующей раскладке.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. Встроенное видео имеет [тип содержимого](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/), который можно прочитать и использовать, например при сохранении на диск.