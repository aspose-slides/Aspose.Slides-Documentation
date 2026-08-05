---
title: Управление видеокадрами в презентациях с помощью PHP
linktitle: Видеокадр
type: docs
weight: 10
url: /ru/php-java/video-frame/
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
- PHP
- Aspose.Slides
description: "Изучите, как программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с использованием Aspose.Slides для PHP через Java. Быстрое практическое руководство."
---
## **Введение**

Хорошо размещённое видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлечённости аудитории. 

PowerPoint позволяет добавлять видео на слайд презентации двумя способами:

* Добавить или встроить локальное видео (хранится на вашем компьютере)
* Добавить онлайн‑видео (из веб‑источника, например YouTube).

Чтобы добавить видео (объекты video) в презентацию, Aspose.Slides предоставляет класс [Video](https://reference.aspose.com/slides/ru/php-java/aspose.slides/video/) , класс [VideoFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/) , а также другие соответствующие типы.

## **Создание встроенных видеокадров**

Если видеофайл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр, чтобы встроить видео в презентацию. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу. 
1. Добавьте объект [Video](https://reference.aspose.com/slides/ru/php-java/aspose.slides/video/) , передав путь к видеофайлу, чтобы встроить видео в презентацию.
1. Добавьте объект [VideoFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/) , чтобы создать кадр для видео.
1. Сохраните изменённую презентацию. 

Этот код PHP показывает, как добавить локально сохранённое видео в презентацию:

```php
  # Создаёт экземпляр класса Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # Загружает видео
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Получает первый слайд и добавляет видеокадр
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # Сохраняет презентацию на диск
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Кроме того, вы можете добавить видео, передав путь к файлу напрямую в метод [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/addvideoframe/) :

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $vf = $sld->getShapes()->addVideoFrame(50, 150, 300, 150, "video1.avi");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Создание видеокадров с видео из веб‑источников**

Microsoft [PowerPoint 2013 и новее](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) поддерживает видео с YouTube в презентациях. Если нужное вам видео доступно онлайн (например, на YouTube), вы можете добавить его в презентацию по веб‑ссылке. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу. 
1. Добавьте объект [Video](https://reference.aspose.com/slides/ru/php-java/aspose.slides/video/) , передав ссылку на видео.
1. Установите миниатюру для видеокадра. 
1. Сохраните презентацию. 

Этот код PHP показывает, как добавить видео из интернета на слайд PowerPoint презентации:

```php
  # Создаёт объект Presentation, представляющий файл презентации
  $pres = new Presentation();
  try {
    addVideoFromYouTube($pres, "Tj75Arhq5ho");
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```

## **Обрезка видеокадра**

Aspose.Slides позволяет управлять тем, какую часть видео воспроизводить, задавая значения trim‑from‑start и trim‑from‑end через [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/#setTrimFromStart) и [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/#setTrimFromEnd). Оба значения указываются в миллисекундах и определяют, сколько времени пропустить в начале и в конце видео соответственно. Эти настройки изменяют параметры воспроизведения видео в презентации; они не обрезают и не изменяют бинарные данные встроенного видео.

**Установить параметры обрезки**

Чтобы создать видеокадр и установить его параметры обрезки:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) .
1. Добавьте объект [Video](https://reference.aspose.com/slides/ru/php-java/aspose.slides/video/) в презентацию.
1. Добавьте объект [VideoFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/) на слайд.
1. Задайте значения trim‑from‑start и trim‑from‑end через [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/#setTrimFromStart) и [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/#setTrimFromEnd) .
1. Сохраните изменённую презентацию.

Следующий пример кода пропускает первые 2,5 секунды и последнюю секунду встроенного видео во время воспроизведения:

```php
$presentation = new Presentation();
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $video = $presentation->getVideos()->addVideo(
        $videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);

    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

**Чтение параметров обрезки**

Чтобы просмотреть существующие параметры обрезки, загрузите презентацию, найдите объект [VideoFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/) среди фигур на первом слайде и прочитайте значения через [VideoFrame::getTrimFromStart](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/#getTrimFromStart) и [VideoFrame::getTrimFromEnd](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/#getTrimFromEnd) .

Следующий пример кода находит первый видеокадр на первом слайде и выводит его параметры обрезки в миллисекундах:

```php
$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trimFromStart = java_values($videoFrame->getTrimFromStart());
            $trimFromEnd = java_values($videoFrame->getTrimFromEnd());

            echo "Trim from start: " . $trimFromStart . " ms\n";
            echo "Trim from end: " . $trimFromEnd . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Управление субтитрами видео**

Aspose.Slides позволяет управлять закрытыми субтитрами для видеокадров в PowerPoint‑презентациях. Субтитры хранятся в формате WebVTT и доступны через метод [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/#getCaptionTracks) .

**Добавление субтитров к видеокадру**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) .
1. Добавьте видео в презентацию.
1. Добавьте объект [VideoFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/) на слайд.
1. Используйте коллекцию [CaptionsCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/captionscollection/) , полученную через [getCaptionTracks](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/#getCaptionTracks) , чтобы добавить дорожку субтитров WebVTT.
1. Сохраните изменённую презентацию.

Следующий код показывает, как добавить субтитры к видеокадру:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // Добавляет новую дорожку субтитров из файла WebVTT.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Класс [CaptionsCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/captionscollection/) также предоставляет перегрузку, позволяющую добавлять субтитры из потока.

**Извлечение субтитров из видеокадра**

1. Загрузите презентацию, содержащую видео.
1. Найдите целевой объект [VideoFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/) .
1. Пройдитесь по коллекции, возвращаемой [getCaptionTracks](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/#getCaptionTracks) .
1. Сохраните каждую дорожку субтитров в файл с расширением `.vtt` .

Следующий код показывает, как извлечь субтитры из видеокадра:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trackCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                // Сохраняет дорожку субтитров в файл WebVTT.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Каждый объект [Captions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/captions/) раскрывает идентификатор субтитров, метку, бинарные данные и текст субтитров как строку UTF‑8.

**Удаление субтитров из видеокадра**

1. Загрузите презентацию, содержащую видео.
1. Получите целевой объект [VideoFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/) .
1. Удалите дорожки субтитров из коллекции, возвращаемой [getCaptionTracks](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/#getCaptionTracks) .
1. Сохраните изменённую презентацию.

Следующий код показывает, как удалить все субтитры из видеокадра:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // тип: VideoFrame

    // Удаляет все субтитры из видеокадра.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Если необходимо удалить только одну дорожку субтитров, используйте методы [remove](https://reference.aspose.com/slides/ru/php-java/aspose.slides/captionscollection/#remove) или [removeAt](https://reference.aspose.com/slides/ru/php-java/aspose.slides/captionscollection/#removeAt) вместо [clear](https://reference.aspose.com/slides/ru/php-java/aspose.slides/captionscollection/#clear) .

## **Извлечение видео со слайдов**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать видео, встроенное в презентации.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) , чтобы загрузить презентацию, содержащую видео.
2. Пройдитесь по всем объектам [Slide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/) .
3. Пройдитесь по всем объектам [Shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/) , чтобы найти [VideoFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/) .
4. Сохраните видео на диск.

Этот код PHP показывает, как извлечь видео со слайда презентации:

```php
  # Создаёт объект Presentation, представляющий файл презентации
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # Получает расширение файла
          $charIndex = $type->indexOf("/");
          $type = $type->substring($charIndex + 1);
          $fop = new Java("java.io.FileOutputStream", "testing2." . $type);
          $fop->write($buffer);
          $fop->flush();
          $fop->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Часто задаваемые вопросы**

**Какие параметры воспроизведения видео можно изменить для VideoFrame?**

Можно управлять [режимом воспроизведения](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/setplaymode/) (автоматически или по щелчку) и [цикличностью](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/setplayloopmode/) . Эти параметры доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/) .

**Влияет ли добавление видео на размер файла PPTX?**

Да. При встраивании локального видео бинарные данные включаются в документ, поэтому размер презентации растёт пропорционально размеру файла. При добавлении онлайн‑видео встраиваются лишь ссылка и миниатюра, поэтому увеличение размера меньше.

**Могу ли я заменить видео в существующем VideoFrame, не меняя его положение и размер?**

Да. Вы можете заменить [содержимое видео](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/setembeddedvideo/) внутри кадра, сохранив геометрию формы; это обычный сценарий обновления медиа в уже существующей раскладке.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. Встроенное видео имеет [тип содержимого](https://reference.aspose.com/slides/ru/php-java/aspose.slides/video/getcontenttype/) , который можно прочитать и использовать, например, при сохранении на диск.