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
- веб-источник
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для PHP через Java. Быстрое руководство."
---

Хорошо размещённое видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлечённости аудитории. 

PowerPoint позволяет добавлять видео на слайд в презентации двумя способами:

* Добавить или встроить локальное видео (хранящееся на вашем компьютере)
* Добавить онлайн‑видео (из веб‑источника, например YouTube).

Чтобы вы могли добавлять видео (объекты video) в презентацию, Aspose.Slides предоставляет классы [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) и [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/), а также другие соответствующие типы.

## **Создать встроенные видеокадры**

Если видеофайл, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр, чтобы встроить видео в презентацию. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу. 
1. Добавьте объект [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) и передайте путь к файлу видео, чтобы встроить его в презентацию.
1. Добавьте объект [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) для создания кадра видео.
1. Сохраните изменённую презентацию. 

Этот код PHP показывает, как добавить локальное видео в презентацию:
```php
  # Создает экземпляр класса Presentation
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


Кроме того, вы можете добавить видео, передав путь к файлу напрямую в метод [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addvideoframe/):
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



## **Создать видеокадры с видео из веб‑источников**

Microsoft [PowerPoint 2013 и новее](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) поддерживает видео YouTube в презентациях. Если видео, которое вы хотите использовать, доступно онлайн (например на YouTube), вы можете добавить его в презентацию через веб‑ссылку. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу. 
1. Добавьте объект [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) и передайте ссылку на видео.
1. Установите миниатюру для видеокадра. 
1. Сохраните презентацию. 

Этот код PHP показывает, как добавить видео из веба на слайд в презентации PowerPoint:
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


## **Извлечь видео со слайдов**

Кроме добавления видео на слайды, Aspose.Slides позволяет извлекать видео, встроенное в презентации.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) для загрузки презентации, содержащей видео.
2. Пройдите по всем объектам [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/).
3. Пройдите по всем объектам [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) в поиске [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).
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


## **FAQ**

**Какие параметры воспроизведения видео можно изменить для VideoFrame?**

Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplaymode/) (авто или по щелчку) и [циклическим воспроизведением](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplayloopmode/). Эти параметры доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).

**Влияет ли добавление видео на размер файла PPTP?**

Да. При встраивании локального видео двоичные данные включаются в документ, поэтому размер презентации увеличивается пропорционально размеру файла. При добавлении онлайн‑видео встраиваются только ссылка и миниатюра, поэтому рост размера меньше.

**Могу ли я заменить видео в существующем VideoFrame, не изменяя его положение и размер?**

Да. Вы можете заменить [видеоконтент](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setembeddedvideo/) внутри кадра, сохранив геометрию формы; это типичный сценарий обновления медиа в существующей разметке.

**Можно ли определить тип контента (MIME) встроенного видео?**

Да. Встроенное видео имеет [тип контента](https://reference.aspose.com/slides/php-java/aspose.slides/video/getcontenttype/), который можно прочитать и использовать, например, при сохранении на диск.