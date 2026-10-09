---
title: Управление видеокадрами в презентациях с использованием PHP
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
- веб‑источник
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides for PHP via Java. Быстрое практическое руководство."
---
## **Введение**

Видео может помочь объяснить идеи и заинтересовать аудиторию. Aspose.Slides for PHP via Java позволяет добавлять видеокадры на слайды, настраивать параметры воспроизведения, управлять субтитрами и извлекать встроенные видеоданные.

PowerPoint поддерживает локальные видео и ссылки на онлайн‑видео, такие как видео YouTube.

Для представления видеоданных и видеокадров Aspose.Slides предоставляет класс [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) , класс [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) и другие соответствующие типы.

## **Создать встроенный видеокадр**

Если файл видео, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр, чтобы встроить видео в презентацию.

В этом примере локальное видео встраивается на первый слайд существующей презентации и сохраняется результат. Координаты и размеры кадра указаны в пунктах. Поток остаётся открытым до завершения сохранения, потому что [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) удерживает его, пока презентация его использует.

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

Вы также можете передать путь к локальному видео непосредственно в [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame). В этом примере видео встраивается на первый слайд новой презентации. Видео должно оставаться доступным до сохранения презентации.

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

## **Создать видеокадр с видео из веб‑источника**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) поддерживает онлайн‑видео в презентациях. Вы можете создать видеокадр, который ссылается на онлайн‑видео, например, видео YouTube.

В этом примере добавляются ссылка на видео YouTube и миниатюра на первый слайд. Замените идентификатор видео, чтобы использовать другое видео. Метод [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) запрашивает автоматическое воспроизведение. Загрузка миниатюры и воспроизведение видео требуют доступа к интернету. Просмотрщик презентаций также должен поддерживать онлайн‑воспроизведение видео.

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

## **Воспроизвести видео в полноэкранном режиме**

В учебной презентации вы можете воспроизводить демонстрацию программного обеспечения в полноэкранном режиме, чтобы аудитория могла увидеть детали. Вызовите [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) с `true`, чтобы включить это поведение во время воспроизведения.

В этом примере открывается презентация, находится первый [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) на первом слайде и включается полноэкранное воспроизведение. Входная презентация должна содержать хотя бы один слайд с существующим видеокадром на первом слайде.

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

Полноэкранное воспроизведение определяет, как отображается видео. Отдельно метод [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) управляет тем, начинается ли воспроизведение автоматически или по щелчку, а [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) управляет повторением. Чтобы выбрать поведение запуска, установите режим воспроизведения в [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/). Пример сохраняет существующие настройки запуска и цикла.

## **Перемотать видео после воспроизведения**

В учебной презентации возврат демонстрационного видео в начало делает его готовым к повторному воспроизведению. Вызовите [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) с `true`, чтобы вернуть видео в начало после завершения воспроизведения.

В этом примере открывается презентация, находится первый [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) на первом слайде и включается перемотка. Отключается цикл, чтобы воспроизведение могло завершиться, и устанавливается запуск воспроизведения по щелчку. Входная презентация должна содержать хотя бы один слайд с существующим видеокадром на первом слайде.

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

Перемотка возвращает видео в начало без повторного запуска. В отличие от этого, вызов [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) с `true` автоматически повторяет воспроизведение. Отключайте цикл, если хотите, чтобы видео завершилось и было готово к повторному воспроизведению. [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) независимо управляет автоматическим запуском или запуском по щелчку; в этом примере используется [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) , чтобы презентер контролировал, когда начинается воспроизведение. Устанавливайте режим воспроизведения после настройки цикла, как показано в примере. Перемотка работает независимо от [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode).

## **Обрезать видеокадр**

Используйте [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) и [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) , чтобы пропустить часть начала или конца видео во время воспроизведения. Оба значения задаются в миллисекундах. Обрезка изменяет настройки воспроизведения без изменения встроенных видеоданных.

**Настройки обрезки**

В этом примере встраивается локальное видео, и во время воспроизведения пропускаются первые 2,5 секунды и последняя секунда. Используйте видео длительностью более 3,5 секунды, чтобы оставался воспроизводимый сегмент.

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

**Чтение настроек обрезки**

В этом примере выводятся значения обрезки первого видеокадра на первом слайде в миллисекундах. Презентация должна содержать хотя бы один слайд. Если на этом слайде нет видеокадра, ничего не выводится. Предыдущий пример выдаёт значения 2500 и 1000.

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

**Добавить субтитры к видеокадру**

В этом примере встраивается локальное видео и добавляется дорожка субтитров WebVTT с меткой English. Метки времени субтитров должны соответствовать видео. Сохранённая презентация включает и видео, и его субтитры.

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

Класс [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) также предоставляет перегрузку, позволяющую добавлять субтитры из потока.

**Извлечь субтитры из видеокадра**

В этом примере все дорожки субтитров из видеокадров на первом слайде сохраняются как отдельные файлы WebVTT. Последовательные номера делают файлы вывода уникальными. Консоль выводит количество извлечённых дорожек. Презентация должна содержать хотя бы один слайд.

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

Каждый объект [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) раскрывает идентификатор субтитров, метку, бинарные данные и текст субтитров в виде строки UTF-8.

**Удалить субтитры из видеокадра**

В этом примере удаляются все субтитры из видеокадра, расположенного в первой фигуре на первом слайде, и сохраняется результат. Предполагается, что слайд и фигура существуют и что фигура является видеокадром.

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

Если необходимо удалить только одну дорожку субтитров, используйте методы [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) или [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) вместо [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear).

## **Извлечь видео со слайда**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать встроенные в презентацию видео.

В этом примере извлекаются встроенные видео со всех слайдов в отдельные пронумерованные бинарные файлы. Связанные видео пропускаются, так как они не содержат встроенных данных. Консоль выводит тип MIME каждого видео и общее количество. Вывод использует обобщённое расширение `.bin`; при необходимости измените его в соответствии с указанным типом медиа.

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

Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (авто или по щелчку) и [циклическим воспроизведением](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode). Эти параметры доступны через методы объекта [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) .

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео бинарные данные включаются в документ, поэтому размер презентации увеличивается пропорционально размеру файла. При ссылке на онлайн‑видео и добавлении миниатюры презентация сохраняет лишь ссылку и изображение превью, а не видеоданные, поэтому увеличение размера обычно меньше.

**Можно ли заменить видео в существующем видеокадре, не меняя его позицию и размер?**

Да. Вы можете заменить [видеоконтент](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) внутри кадра, сохранив геометрию фигуры; это обычный сценарий обновления медиа в существующей компоновке.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. Встроенное видео имеет [content type](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType) который можно считать и использовать, например при сохранении его на диск.