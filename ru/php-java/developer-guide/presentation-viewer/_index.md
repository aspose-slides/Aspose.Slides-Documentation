---
title: Просмотрщик презентаций
type: docs
weight: 50
url: /php-java/presentation-viewer/
keywords: "Просмотрщик PowerPoint PPT"
description: "Просмотрщик PowerPoint PPT"
---

{{% alert color="primary" %}} 

Aspose.Slides для PHP через Java используется для создания файлов презентаций, включая слайды. Эти слайды можно просматривать, открывая презентации с помощью Microsoft PowerPoint. Но иногда разработчикам также может понадобиться просматривать слайды в виде изображений в своем любимом просмотрщике изображений или создавать свой собственный просмотрщик презентаций. В таких случаях Aspose.Slides для PHP через Java позволяет экспортировать отдельный слайд в изображение. В этой статье описывается, как это сделать.

{{% /alert %}} 

## **Живой пример**
Вы можете попробовать бесплатное приложение [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/), чтобы увидеть, что вы можете реализовать с помощью API Aspose.Slides:

[](https://products.aspose.app/slides/viewer/)

[![todo:image_alt_text](slides-viewer.png)](https://products.aspose.app/slides/viewer/)

## **Создание SVG-изображения из слайда**
Чтобы создать SVG-изображение из любого желаемого слайда с помощью Aspose.Slides для PHP через Java, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Получите ссылку на нужный слайд, используя его идентификатор или индекс.
- Получите SVG-изображение в потоке памяти.
- Сохраните поток памяти в файл.

```php
  # Создайте экземпляр класса Presentation, который представляет файл презентации
  $pres = new Presentation("CreateSlidesSVGImage.pptx");
  try {
    # Получите первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Создайте объект потока памяти
    $svgStream = new Java("java.io.FileOutputStream", "Aspose_out.svg");
    # Создайте SVG-изображение слайда и сохраните в поток памяти
    $sld->writeAsSvg($svgStream);
    $svgStream->close();
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

## **Создание SVG с пользовательскими идентификаторами фигур**
Aspose.Slides для PHP через Java можно использовать для создания [SVG](https://docs.fileformat.com/page-description-language/svg/) из слайда с пользовательским идентификатором фигуры. Для этого используйте свойство ID из [ISvgShape](https://reference.aspose.com/slides/php-java/aspose.slides/ISvgShape), которое представляет собой пользовательский идентификатор фигур в сгенерированном SVG. CustomSvgShapeFormattingController можно использовать для установки идентификатора фигуры.

```php

  class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    function __construct() {
      $this->m_shapeIndex = 0;
    }

    function __construct($shapeStartIndex) {
      $this->m_shapeIndex = $shapeStartIndex;
    }

    function formatShape($svgShape, $shape) {
      $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
  }

  $pres = new Presentation("pptxFileName.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "Aspose_out.svg");
    try {
      $svgOptions = new SVGOptions();
      $shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(), null, java("com.aspose.slides.ISvgShapeFormattingController"));
      $svgOptions->setShapeFormattingController($shapeFormattingController);
      $pres->getSlides()->get_Item(0)->writeAsSvg($stream, $svgOptions);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

## **Создание миниатюры слайда**
Aspose.Slides для PHP через Java поможет вам создать миниатюры изображений слайдов. Чтобы создать миниатюру любого желаемого слайда с помощью Aspose.Slides для PHP через Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите ссылку на любой желаемый слайд, используя его идентификатор или индекс.
1. Получите миниатюру изображения ссылающегося слайда на указанном масштабе.
1. Сохраните миниатюру изображения в любом желаемом формате изображения.

```php
  # Создайте экземпляр класса Presentation, который представляет файл презентации
  $pres = new Presentation("ThumbnailFromSlide.pptx");
  try {
    # Получите первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Создайте изображение в полном масштабе
    $slideImage = $sld->getImage(1.0, 1.0);
    # Сохраните изображение на диск в формате JPEG
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **Создание миниатюры с заданными пользователем размерами**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите ссылку на любой желаемый слайд, используя его идентификатор или индекс.
1. Получите миниатюру изображения ссылающегося слайда на указанном масштабе.
1. Сохраните миниатюру изображения в любом желаемом формате изображения.

```php
  # Создайте экземпляр класса Presentation, который представляет файл презентации
  $pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
  try {
    # Получите первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Размеры, заданные пользователем
    $desiredX = 1200;
    $desiredY = 800;
    # Получение масштабированного значения X и Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    # Создайте изображение в полном масштабе
    $slideImage = $sld->getImage($ScaleX, $ScaleY);
    # Сохраните изображение на диск в формате JPEG
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **Создание миниатюры из слайда в режиме заметок**
Чтобы создать миниатюру любого желаемого слайда в режиме заметок, используя Aspose.Slides для PHP через Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите ссылку на любой желаемый слайд, используя его идентификатор или индекс.
1. Получите миниатюру изображения ссылающегося слайда на указанном масштабе в режиме заметок.
1. Сохраните миниатюру изображения в любом желаемом формате изображения.

Следующий фрагмент кода производит миниатюру первого слайда презентации в режиме заметок.

```php
  # Создайте экземпляр класса Presentation, который представляет файл презентации
  $pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
  try {
    # Получите первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Размеры, заданные пользователем
    $desiredX = 1200;
    $desiredY = 800;
    # Получение масштабированного значения X и Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    $opts = new RenderingOptions();
    $opts->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # Создайте изображение в полном масштабе
    $slideImage = $sld->getImage($opts, $ScaleX, $ScaleY);
    # Сохраните изображение на диск в формате JPEG
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    $pres->dispose();
  }
```