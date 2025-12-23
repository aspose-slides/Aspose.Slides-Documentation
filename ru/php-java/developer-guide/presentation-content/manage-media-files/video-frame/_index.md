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
description: "Узнайте, как программно добавлять и извлекать видеокадры в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для PHP через Java. Быстрое руководство."
---

Хорошо размещённое видео в презентации может сделать ваше сообщение более убедительным и повысить уровень вовлечённости аудитории. 

PowerPoint позволяет добавлять видео на слайд презентации двумя способами:

* Добавить или внедрить локальное видео (хранящееся на вашем компьютере)
* Добавить онлайн‑видео (из веб‑источника, например YouTube).

Чтобы позволить вам добавлять видео (видеобъекты) в презентацию, Aspose.Slides предоставляет интерфейсы [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/), [IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/) и другие соответствующие типы.

## **Create Embedded Video Frames**
Если файл видео, который вы хотите добавить на слайд, хранится локально, вы можете создать видеокадр, чтобы внедрить видео в презентацию. 

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)class.  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте объект [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) и передайте путь к файлу видео для внедрения его в презентацию.  
4. Добавьте объект [IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/) для создания кадра для видео.  
5. Сохраните изменённую презентацию.  

Этот PHP‑код показывает, как добавить локально сохранённое видео в презентацию:
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


Кроме того, вы можете добавить видео, передав путь к файлу напрямую в метод [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-):
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


## **Create Video Frames with Video from Web Sources**
Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) поддерживает видео с YouTube в презентациях. Если нужное вам видео доступно онлайн (например, на YouTube), вы можете добавить его в презентацию по веб‑ссылке. 

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)class.  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте объект [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) и передайте ссылку на видео.  
4. Установите миниатюру для видеокадра.  
5. Сохраните презентацию.  

Этот PHP‑код показывает, как добавить видео из интернета на слайд PowerPoint‑презентации:
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


## **Extract Video from Slides**
Помимо добавления видео на слайды, Aspose.Slides позволяет извлекать встроенные в презентацию видео.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) для загрузки презентации, содержащей видео.  
2. Пройдитесь по всем объектам [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/).  
3. Пройдитесь по всем объектам [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) в поисках [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).  
4. Сохраните видео на диск.  

Этот PHP‑код показывает, как извлечь видео со слайда презентации:
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


## **FAQ**

**Which video playback parameters can be changed for a VideoFrame?**  
Вы можете управлять [режимом воспроизведения](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplaymode/) (авто или по щелчку) и [зацикливанием](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplayloopmode/). Эти параметры доступны через свойства объекта [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).

**Does adding a video affect the PPTX file size?**  
Да. При внедрении локального видео его двоичные данные включаются в документ, поэтому размер презентации увеличивается пропорционально размеру файла. При добавлении онлайн‑видео в документ внедряются только ссылка и миниатюра, поэтому рост размера меньше.

**Can I replace the video in an existing VideoFrame without changing its position and size?**  
Да. Вы можете заменить [видео‑контент](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setembeddedvideo/) внутри кадра, сохранив геометрию формы; это распространённый сценарий обновления медиа в уже существующем макете.

**Can the content type (MIME) of an embedded video be determined?**  
Да. Для встроенного видео доступен [тип контента](https://reference.aspose.com/slides/php-java/aspose.slides/video/getcontenttype/), который можно прочитать и использовать, например, при сохранении его на диск.