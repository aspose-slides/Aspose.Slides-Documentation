---
title: Управление видеокадрами в презентациях с использованием PHP
linktitle: Видеокадр
type: docs
weight: 10
url: /ru/php-java/video-frame/
keywords:
- добавить видео
- создать видео
- встраивание видео
- извлечение видео
- получить видео
- видеокадр
- веб‑источник
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Научитесь программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides for PHP через Java. Быстрое руководство‑по‑действию."
---
Хорошо размещённое видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлечённости аудитории. 

PowerPoint позволяет добавлять видео на слайд в презентации двумя способами:

* Добавить или встроить локальное видео (хранящееся на вашем компьютере)
* Добавить онлайн‑видео (из веб‑источника, например YouTube).

Чтобы позволить вам добавлять видео (объекты video) в презентацию, Aspose.Slides предоставляет класс [Video](https://reference.aspose.com/slides/ru/php-java/aspose.slides/video/) , класс [VideoFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/) , а также другие соответствующие типы.

## **Создание встроенных видеокадров**

Если файл видео, который вы хотите добавить на свой слайд, хранится локально, вы можете создать видеокадр, чтобы встроить видео в вашу презентацию. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу. 
1. Добавьте объект [Video](https://reference.aspose.com/slides/ru/php-java/aspose.slides/video/) и передайте путь к файлу видео, чтобы встроить его в презентацию. 
1. Добавьте объект [VideoFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/) , чтобы создать кадр для видео. 
1. Сохраните изменённую презентацию. 

Этот код PHP показывает, как добавить локально хранящееся видео в презентацию:

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

В качестве альтернативы вы можете добавить видео, передав путь к файлу напрямую в метод [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/addvideoframe/) :

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
2. Получите ссылку на слайд по его индексу. 
3. Добавьте объект [Video](https://reference.aspose.com/slides/ru/php-java/aspose.slides/video/) и передайте ссылку на видео. 
4. Установите миниатюру для видеокадра. 
5. Сохраните презентацию. 

Этот код PHP показывает, как добавить видео из интернета на слайд в презентации PowerPoint:

```php
  # Создаёт объект Presentation, который представляет файл презентации
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

## **Управление субтитрами видео**

Aspose.Slides позволяет управлять закрытыми субтитрами для видеокадров в презентациях PowerPoint. Субтитры хранятся в формате WebVTT и доступны через метод [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/#getCaptionTracks) .

**Добавить субтитры к видеокадру**

Чтобы добавить субтитры к видеокадру:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) .
2. Добавьте видео в презентацию. 
3. Добавьте объект [VideoFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/) на слайд. 
4. Используйте коллекцию [CaptionsCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/captionscollection/) , возвращаемую методом [getCaptionTracks](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/#getCaptionTracks) , чтобы добавить дорожку субтитров WebVTT. 
5. Сохраните изменённую презентацию. 

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

**Извлечь субтитры из видеокадра**

Чтобы извлечь субтитры из видеокадра:

1. Загрузите презентацию, содержащую видео. 
2. Найдите целевой объект [VideoFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/) . 
3. Пройдите по коллекции [getCaptionTracks](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/#getCaptionTracks) . 
4. Сохраните каждую дорожку субтитров в файл `.vtt` . 

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

**Удалить субтитры из видеокадра**

Чтобы удалить субтитры из видеокадра:

1. Загрузите презентацию, содержащую видео. 
2. Получите целевой объект [VideoFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/) . 
3. Удалите дорожки субтитров из коллекции [getCaptionTracks](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/#getCaptionTracks) . 
4. Сохраните изменённую презентацию. 

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

Если необходимо удалить только одну дорожку субтитров, используйте методы [remove](https://reference.aspose.com/slides/ru/php-java/aspose.slides/captionscollection/#remove) , [removeAt](https://reference.aspose.com/slides/ru/php-java/aspose.slides/captionscollection/#removeAt) вместо [clear](https://reference.aspose.com/slides/ru/php-java/aspose.slides/captionscollection/#clear) .

## **Извлечение видео со слайдов**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать встроенные в презентацию видео.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) , чтобы загрузить презентацию, содержащую видео. 
2. Пройдите все объекты [Slide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/) . 
3. Пройдите все объекты [Shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/) , чтобы найти [VideoFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/) . 
4. Сохраните видео на диск. 

Этот код PHP показывает, как извлечь видео со слайда презентации:

```php
  # Создаёт объект Presentation, который представляет файл презентации
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

## **FAQ**

**Какие параметры воспроизведения видео можно изменить для VideoFrame?**

Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/setplaymode/) (авто или по щелчку) и [повтором](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/setplayloopmode/) . Эти параметры доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/) .

**Увеличивает ли добавление видео размер файла PPTX?**

Да. При встраивании локального видео бинарные данные включаются в документ, поэтому размер презентации возрастает пропорционально размеру файла. При добавлении онлайн‑видео встраивается ссылка и миниатюра, поэтому увеличение размера меньше.

**Можно ли заменить видео в существующем VideoFrame, не меняя его позицию и размер?**

Да. Вы можете заменить [видеоконтент](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/setembeddedvideo/) внутри кадра, сохранив геометрию фигуры; это часто используется для обновления медиа в существующем макете.

**Можно ли определить тип содержимого (MIME) встроенного видео?**

Да. Встроенное видео имеет [тип содержимого](https://reference.aspose.com/slides/ru/php-java/aspose.slides/video/getcontenttype/) , который можно прочитать и использовать, например при сохранении на диск.