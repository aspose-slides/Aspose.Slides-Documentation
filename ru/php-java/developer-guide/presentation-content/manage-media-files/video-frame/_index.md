---
title: Управление видеокадрами в презентациях с помощью PHP
linktitle: Видеокадр
type: docs
weight: 10
url: /ru/php-java/video-frame/
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
- PHP
- Aspose.Slides
description: "Узнайте, как программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для PHP через Java. Быстрый практический справочник."
---
## **Введение**

Видео может помочь объяснить идеи и привлечь аудиторию. Aspose.Slides for PHP via Java позволяет добавлять видеокадры на слайды, настраивать параметры воспроизведения, управлять субтитрами и извлекать встроенные видеоданные.

PowerPoint поддерживает локальные видео и ссылки на онлайн‑видео, такие как видео YouTube.

Для представления видеоданных и видеокадров Aspose.Slides предоставляет класс [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/), класс [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) и другие соответствующие типы.

## **Создание встроенного видеокадра**

Если видеофайл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр для встраивания видео в презентацию.

В этом примере встраивается локальное видео на первый слайд существующей презентации и сохраняется результат. Координаты и размеры кадра указаны в пунктах. Поток остаётся открытым до завершения сохранения, поскольку [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) удерживает его, пока презентация использует его.

```php
use aspose\slides\LoadingStreamBehavior;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $slide = $presentation->getSlides()->get_Item(0);

    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::KeepLocked);
    $slide->getShapes()->addVideoFrame(10, 10, 150, 250, $video);

    $presentation->save("embedded_video.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

Вы также можете передать путь к локальному видео напрямую в [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame). Этот пример встраивает видео на первый слайд новой презентации. Видео должно оставаться доступным до момента сохранения презентации.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addVideoFrame(50, 150, 300, 150, "video.avi");

    $presentation->save("video_from_path.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Создание видеокадра с видео из веб‑источника**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) поддерживает онлайн‑видео в презентациях. Вы можете создать видеокадр, который будет ссылаться на онлайн‑видео, например, видео YouTube.

В этом примере добавляется ссылка на видео YouTube и миниатюра на первый слайд. Замените идентификатор видео, чтобы использовать другое видео. Метод [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) запрашивает автоматическое воспроизведение. Загрузка миниатюры и воспроизведение видео требуют доступа к Интернету. Просмотрщик презентаций также должен поддерживать воспроизведение онлайн‑видео.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoId = "aqz-KE-bpKQ";
    $videoUrl = "https://www.youtube.com/embed/" . $videoId;
    $videoFrame = $slide->getShapes()->addVideoFrame(10, 10, 427, 240, $videoUrl);
    $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

    $thumbnailUrl = "https://img.youtube.com/vi/" . $videoId . "/hqdefault.jpg";
    $thumbnailLocation = new Java("java.net.URL", $thumbnailUrl);
    $thumbnailStream = $thumbnailLocation->openStream();
    try {
        $thumbnail = $presentation->getImages()->addImage($thumbnailStream);
        $videoFrame->getPictureFormat()->getPicture()->setImage($thumbnail);
    } finally {
        $thumbnailStream->close();
    }

    $presentation->save("online_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Воспроизведение видео в полноэкранном режиме**

В обучающей презентации вы можете воспроизводить демонстрацию программного обеспечения в полноэкранном режиме, чтобы аудитория видела детали. Вызовите [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) со значением `true`, чтобы включить такое поведение во время воспроизведения.

В этом примере открывается презентация, находится первый [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) на первом слайде и включается полноэкранное воспроизведение. Входная презентация должна содержать хотя бы один слайд с уже существующим видеокадром на первом слайде.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setFullScreenMode(true);
            break;
        }
    }

    $presentation->save("full_screen_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Полноэкранное воспроизведение управляет тем, как видео отображается. Независимо от этого, [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) контролирует, начинается ли оно автоматически или по щелчку, а [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) управляет повторением. Чтобы выбрать поведение запуска, установите режим воспроизведения на [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/). Пример сохраняет существующие настройки запуска и зацикливания.

## **Перемотка видео после воспроизведения**

В обучающей презентации возврат демонстрационного видео к началу делает его готовым к повторному воспроизведению. Вызовите [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) со значением `true`, чтобы вернуть видео к началу после завершения воспроизведения.

В этом примере открывается презентация, находится первый [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) на первом слайде и включается перемотка. Цикл отключён, чтобы воспроизведение могло завершиться, и установлен запуск по щелчку. Входная презентация должна содержать хотя бы один слайд с уже существующим видеокадром на первом слайде.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setRewindVideo(true);
            $videoFrame->setPlayLoopMode(false);
            $videoFrame->setPlayMode(VideoPlayModePreset::OnClick);
            break;
        }
    }

    $presentation->save("rewind_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Перемотка возвращает видео к началу без повторного запуска. В отличие от этого, вызов [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) со значением `true` автоматически повторяет воспроизведение. Оставляйте цикл отключённым, когда требуется, чтобы видео закончилось и было готово к повторному запуску. [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) независимо контролирует автоматический или щелчковый запуск; в примере используется [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/), чтобы презентатор контролировал начало воспроизведения. Устанавливайте режим воспроизведения после настройки цикла, как показано в примере. Перемотка работает независимо от [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode).

## **Обрезка видеокадра**

Используйте [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) и [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd), чтобы пропустить часть начала или конца видео во время воспроизведения. Оба значения указываются в миллисекундах. Обрезка меняет параметры воспроизведения без изменения встроенных видеоданных.

**Установка параметров обрезки**

В этом примере встраивается локальное видео и пропускаются первые 2,5 секунды и последняя секунда во время воспроизведения. Используйте видео длиной более 3,5 секунд, чтобы оставался воспроизводимый отрезок.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);
    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Чтение параметров обрезки**

Этот пример выводит значения обрезки первого видеокадра на первом слайде в миллисекундах. Презентация должна содержать хотя бы один слайд. Если на этом слайде нет видеокадра, ничего не выводится. Предыдущий пример выдаёт значения 2500 и 1000.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            echo "Trim from start: " . java_values($videoFrame->getTrimFromStart()) . " ms\n";
            echo "Trim from end: " . java_values($videoFrame->getTrimFromEnd()) . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Управление субтитрами видео**

Aspose.Slides позволяет управлять закрытыми субтитрами для видеокадров в презентациях PowerPoint. Субтитры хранятся в формате WebVTT и доступны через метод [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks).

### **Добавление субтитров к видеокадру**

В этом примере встраивается локальное видео и добавляется дорожка субтитров WebVTT с меткой English. Временные метки субтитров должны соответствовать видео. Сохранённая презентация включает как видео, так и его субтитры.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Класс [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) также предоставляет перегрузку, позволяющую добавить субтитры из потока.

### **Извлечение субтитров из видеокадра**

Этот пример сохраняет все дорожки субтитров из видеокадров на первом слайде в отдельные файлы WebVTT. Последовательные номера делают файлы вывода различимыми. Консоль выводит количество извлечённых дорожек. Презентация должна содержать хотя бы один слайд.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $trackCount = 0;
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $captionCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $captionCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                $trackCount++;
                $outputStream = new Java("java.io.FileOutputStream", "captions_" . $trackCount . ".vtt");
                try {
                    $outputStream->write($captionTrack->getBinaryData());
                } finally {
                    $outputStream->close();
                }
            }
        }
    }

    echo "Caption tracks extracted: " . $trackCount . "\n";
} finally {
    $presentation->dispose();
}
```

Каждый объект [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) раскрывает идентификатор субтитров, метку, бинарные данные и текст субтитров как строку UTF‑8.

### **Удаление субтитров из видеокадра**

В этом примере удаляются все субтитры из видеокадра, находящегося в первой позиции формы на первом слайде, и сохраняется результат. Предполагается, что слайд и форма существуют и что форма является видеокадром.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFrame = $slide->getShapes()->get_Item(0);
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Если нужно удалить только одну дорожку субтитров, используйте методы [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) или [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) вместо [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear).

### **Поиск субтитров видео**

[Captions::getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) возвращает полную дорожку WebVTT, включая заголовок, строки с таймингом и текст субтитров. Вы можете искать подсказки в памяти, чтобы найти произнесённую фразу и её временную метку. Например, английская дорожка на слайде 2 может содержать следующий текст.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Пример открывает `captioned_media.pptx` и использует [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) для чтения дорожек каждого видеокадра верхнего уровня на каждом слайде. В простом текстовом подсказке строка тайминга содержит `-->`, а пустая строка завершает подсказку. Когда субтитры содержат слово «café» в любом регистре, пример выводит номер слайда, метку дорожки, оригинальную строку тайминга и полный текст субтитров.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("captioned_media.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                continue;
            }
            $trackCount = java_values($shape->getCaptionTracks()->getCount());
            for ($index = 0; $index < $trackCount; $index++) {
                $track = $shape->getCaptionTracks()->get_Item($index);
                $lines = preg_split('/\r\n|\n|\r/', java_values($track->getDataAsString()));
                $lineCount = count($lines);
                for ($i = 0; $i < $lineCount; $i++) {
                    $timing = $lines[$i];
                    if (strpos($timing, "-->") === false) {
                        continue;
                    }
                    $captionLines = [];
                    while (++$i < $lineCount && $lines[$i] !== "") {
                        $captionLines[] = $lines[$i];
                    }
                    $caption = implode("\n", $captionLines);
                    if (preg_match('/café/iu', $caption)) {
                        printf("Slide %d | %s | %s\n", java_values($slide->getSlideNumber()), java_values($track->getLabel()), $timing);
                        echo $caption, "\n";
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Поиск «café» даёт одно совпадение для образцовой дорожки. Поиск исключает заголовок дорожки и сохраняет настройку тайминга в выводе.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Извлечение видео со слайда**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать видео, встроенное в презентации.

В этом примере извлекаются встроенные видео со всех слайдов в отдельные пронумерованные бинарные файлы. Связанные видео пропускаются, так как у них нет встроенных данных. Консоль выводит MIME‑тип каждого видео и общее количество. Вывод использует универсальное расширение `.bin`; при необходимости измените его в соответствии с типом медиаданных.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_videos.pptx");
try {
    $videoCount = 0;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $videoFrame = $shape;
                $video = $videoFrame->getEmbeddedVideo();
                if (java_is_null($video)) {
                    echo "Skipped a linked video: no embedded data is available.\n";
                    continue;
                }

                $videoCount++;
                $outputStream = new Java("java.io.FileOutputStream", "extracted_video_" . $videoCount . ".bin");
                try {
                    $outputStream->write($video->getBinaryData());
                } finally {
                    $outputStream->close();
                }
                echo "Video " . $videoCount . ": " . java_values($video->getContentType()) . "\n";
            }
        }
    }

    echo "Embedded videos extracted: " . $videoCount . "\n";
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Какие параметры воспроизведения видео можно изменить для видеокадра?**

Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (авто или по щелчку) и [зацикливанием](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode). Эти параметры доступны через методы объекта [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео бинарные данные включаются в документ, поэтому размер презентации увеличивается пропорционально размеру файла. При ссылке на онлайн‑видео и добавлении миниатюры презентация сохраняет только ссылку и изображение‑превью, а не видеоданные, поэтому увеличение размера обычно меньше.

**Можно ли заменить видео в существующем видеокадре, не меняя его положение и размер?**

Да. Вы можете заменить [видеоконтент](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) внутри кадра, сохранив геометрию формы; это распространённый сценарий обновления медиа в уже существующей раскладке.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. Встроенное видео имеет [тип содержимого](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType), который можно прочитать и использовать, например, при сохранении его на диск.