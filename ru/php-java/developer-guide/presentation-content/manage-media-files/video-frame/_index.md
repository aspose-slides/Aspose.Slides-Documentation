---
title: Видеорама
type: docs
weight: 10
url: /ru/php-java/video-frame/
keywords: "Добавить видео, создать видеораму, извлечь видео, презентация PowerPoint, Java, Aspose.Slides для PHP через Java"
description: "Добавьте видеораму в презентацию PowerPoint"
---

Правильно размещённое видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлеченности вашей аудитории.

PowerPoint позволяет добавлять видео на слайд в презентации двумя способами:

* Добавить или встроить локальное видео (хранящееся на вашем компьютере)
* Добавить онлайн-видео (из веб-источника, такого как YouTube).

Чтобы позволить вам добавлять видео (видеообъекты) в презентацию, Aspose.Slides предоставляет интерфейсы [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) и [IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/), а также другие соответствующие типы.

## **Создание встроенной видеорамы**

Если видеофайл, который вы хотите добавить на свой слайд, хранится локально, вы можете создать видеораму для встраивания видео в вашу презентацию.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) и передайте путь к видеофайлу для встраивания видео в презентацию.
1. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/) для создания рамки для видео.
1. Сохраните изменённую презентацию.

Этот код на PHP показывает, как добавить видео, хранящееся локально, в презентацию:

```php
  # Создает экземпляр класса Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # Загружает видео
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Получает первый слайд и добавляет видеораму
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

Кроме того, вы можете добавить видео, передав его путь к файлу напрямую в метод [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-):

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

## **Создание видеорамы с видео из веб-источника**

Microsoft [PowerPoint 2013 и новее](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) поддерживает видео из YouTube в презентациях. Если видео, которое вы хотите использовать, доступно онлайн (например, на YouTube), вы можете добавить его в вашу презентацию через его веб-ссылку.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте объект [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) и передайте ссылку на видео.
1. Установите миниатюру для видеорамы.
1. Сохраните презентацию.

Этот код на PHP показывает, как добавить видео из интернета на слайд в презентации PowerPoint:

```php
  # Создает объект Presentation, представляющий файл презентации
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

## **Извлечение видео из слайда**

Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать видео, встроенные в презентации.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), чтобы загрузить презентацию, содержащую видео.
2. Перебирайте все объекты [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/).
3. Перебирайте все объекты [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/), чтобы найти [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).
4. Сохраните видео на диск.

Этот код на PHP показывает, как извлечь видео из слайда презентации:

```php
  # Создает объект Presentation, представляющий файл презентации
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