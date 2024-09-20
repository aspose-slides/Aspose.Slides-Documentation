---
title: Конвертировать PowerPoint в TIFF
type: docs
weight: 90
url: /php-java/convert-powerpoint-to-tiff/
keywords: "Конвертация презентации PowerPoint, PowerPoint в TIFF, PPT в TIFF, PPTX в TIFF, Java, Aspose.Slides"
description: "Конвертировать презентацию PowerPoint в TIFF"

---

**TIFF** (формат файлов с метками изображения) — это безупречный растр и высококачественный формат изображения. Профессионалы используют TIFF для своих дизайнерских, фотографических и издательских целей. Например, если вы хотите сохранить слои и настройки в своем дизайне или изображении, вам может понадобиться сохранить свою работу в виде файла изображения TIFF.

Aspose.Slides позволяет вам конвертировать слайды в PowerPoint непосредственно в TIFF.

{{% alert title="Совет" color="primary" %}}

Вам может быть интересно ознакомиться с [БЕСПЛАТНЫМ конвертером PowerPoint в постер](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) от Aspose.

{{% /alert %}}

## **Конвертировать PowerPoint в TIFF**

Используя метод [Save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save-java.lang.String-int-), предоставленный классом [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), вы можете быстро конвертировать всю презентацию PowerPoint в TIFF. Полученные изображения TIFF соответствуют стандартному размеру слайдов.

Этот код PHP показывает, как конвертировать PowerPoint в TIFF:

```php
// Создает объект Presentation, который представляет файл презентации
  $pres = new Presentation("presentation.pptx");
  try {
    # Сохраняет презентацию в формате TIFF
    $pres->save("tiff-image.tiff", SaveFormat::Tiff);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Конвертировать PowerPoint в черно-белый TIFF**

В Aspose.Slides 23.10 был добавлен новый параметр ([BwConversionMode](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setBwConversionMode-int-)) в класс [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/), который позволяет вам указать алгоритм, который будет использоваться при конвертации цветного слайда или изображения в черно-белый TIFF. Обратите внимание, что эта настройка применяется только тогда, когда параметр [CompressionType](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setCompressionType-int-) установлен на `CCITT4` или `CCITT3`.

Этот код PHP показывает, как конвертировать цветной слайд или изображение в черно-белый TIFF:

```php
  $tiffOptions = new TiffOptions();
  $tiffOptions->setCompressionType(TiffCompressionTypes.CCITT4);
  $tiffOptions->setBwConversionMode(BlackWhiteConversionMode->Dithering);
  $presentation = new Presentation("sample.pptx");
  try {
    $presentation->save("output.tiff", SaveFormat::Tiff, $tiffOptions);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Конвертировать PowerPoint в TIFF с заданным размером**

Если вам требуется TIFF-изображение с определенными размерами, вы можете задать свои предпочтительные размеры через свойства, предоставленные в [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/). Например, используя свойство [ImageSize](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-), вы можете задать размер для результирующего изображения.

Этот код PHP показывает, как конвертировать PowerPoint в TIFF-изображения с заданным размером:

```php
// Создает объект Presentation, который представляет файл Презентации
  $pres = new Presentation("presentation.pptx");
  try {
    # Создает класс TiffOptions
    $opts = new TiffOptions();
    # Устанавливает тип сжатия
    # Возможные значения:
    # Default - Указывает схему сжатия по умолчанию (LZW).
    # None - Указывает отсутствие сжатия.
    # CCITT3
    # CCITT4
    # LZW
    # RLE
    $opts->setCompressionType(TiffCompressionTypes.Default);
    # Глубина - зависит от типа сжатия и не может быть установлена вручную.
    # Устанавливает DPI изображения
    $opts->setDpiX(200);
    $opts->setDpiY(100);
    # Устанавливает размер изображения
    $opts->setImageSize(new Java("java.awt.Dimension", 1728, 1078));
    $options = $opts->getNotesCommentsLayouting();
    $options->setNotesPosition(NotesPositions::BottomFull);
    # Сохраняет презентацию в TIFF с указанным размером
    $pres->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $opts);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Конвертировать PowerPoint в TIFF с заданным форматом пикселей изображения**

Используя свойство [PixelFormat](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setPixelFormat-int-) в классе [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/), вы можете задать предпочитаемый формат пикселей для результирующего TIFF-изображения.

Этот код PHP показывает, как конвертировать PowerPoint в TIFF-изображение с заданным форматом пикселей:

```php
// Создает объект Presentation, который представляет файл Презентации
  $pres = new Presentation("presentation.pptx");
  try {
    $options = new TiffOptions();
    $options->setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /* ImagePixelFormat включает следующие значения (как указано в документации):
    Format1bppIndexed; // 1 бит на пиксель, индексированный.
    Format4bppIndexed; // 4 бита на пиксель, индексированный.
    Format8bppIndexed; // 8 бит на пиксель, индексированный.
    Format24bppRgb;    // 24 бита на пиксель, RGB.
    Format32bppArgb;   // 32 бита на пиксель, ARGB.
     */
    # Сохраняет презентацию в TIFF с указанным размером изображения
    $pres->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```