---
title: Конвертировать PowerPoint в TIFF
type: docs
weight: 90
url: /androidjava/convert-powerpoint-to-tiff/
keywords: "Конвертировать презентацию PowerPoint, PowerPoint в TIFF, PPT в TIFF, PPTX в TIFF, Java, Aspose.Slides"
description: "Конвертируйте презентацию PowerPoint в TIFF на Java"

---

**TIFF** (формат файла с отметками изображения) — это безупречный растровый и высококачественный формат изображения. Профессионалы используют TIFF для своих дизайнерских работ, фотографии и настольного издательства. Например, если вы хотите сохранить слои и настройки в своем дизайне или изображении, вам может понадобиться сохранить свою работу в виде TIFF-файла изображения.

Aspose.Slides позволяет вам конвертировать слайды PowerPoint напрямую в TIFF.

{{% alert title="Совет" color="primary" %}}

Вам может быть интересно ознакомиться с [БЕСПЛАТНЫМ конвертером PowerPoint в плакат](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) от Aspose.

{{% /alert %}}

## **Конвертировать PowerPoint в TIFF**

Используя метод [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-), предоставленный классом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), вы можете быстро конвертировать всю презентацию PowerPoint в TIFF. Полученные изображения TIFF соответствуют размеру слайдов по умолчанию.

Этот код на Java показывает, как конвертировать PowerPoint в TIFF:

```java
// Создает объект Presentation, представляющий файл презентации
Presentation pres = new Presentation("presentation.pptx");
try {
    // Сохраняет презентацию как TIFF
    pres.save("tiff-image.tiff", SaveFormat.Tiff);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Конвертировать PowerPoint в черно-белый TIFF**

В Aspose.Slides 23.10 добавлено новое свойство ([BwConversionMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-)) в класс [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/), чтобы позволить вам указать алгоритм, который будет использоваться при конвертации цветного слайда или изображения в черно-белый TIFF. Обратите внимание, что эта настройка применяется только тогда, когда свойство [CompressionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) установлено на `CCITT4` или `CCITT3`.

Этот код на Java показывает, как конвертировать цветной слайд или изображение в черно-белый TIFF:

```java
TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Конвертировать PowerPoint в TIFF с заданным размером**

Если вам требуется TIFF-изображение с определенными размерами, вы можете задать ваши предпочтительные размеры через свойства, предоставленные в [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/). Например, с помощью свойства [ImageSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) вы можете установить размер для полученного изображения.

Этот код на Java показывает, как конвертировать PowerPoint в TIFF-изображения с заданным размером:

```java
// Создает объект Presentation, представляющий файл презентации
Presentation pres = new Presentation("presentation.pptx");
try {
    // Создает класс TiffOptions
    TiffOptions opts = new TiffOptions();
    
    // Устанавливает тип сжатия
    // Возможные значения:
    // Default - указывает на стандартную схему сжатия (LZW).
    // None - указывает на отсутствие сжатия.
    // CCITT3
    // CCITT4
    // LZW
    // RLE
    opts.setCompressionType(TiffCompressionTypes.Default);
    
    // Глубина – зависит от типа сжатия и не может быть установлена вручную.
    
    // Устанавливает DPI изображения
    opts.setDpiX(200);
    opts.setDpiY(100);
    
    // Устанавливает размер изображения
    opts.setImageSize(new java.awt.Dimension(1728, 1078));
    
    INotesCommentsLayoutingOptions options = opts.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);
    // Сохраняет презентацию в TIFF с заданным размером
    pres.save("tiff-ImageSize.tiff", SaveFormat.Tiff, opts);
} finally {
    if (pres != null) pres.dispose();
}    
```

## **Конвертировать PowerPoint в TIFF с пользовательским форматом пикселей изображения**

Используя свойство [PixelFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) в классе [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/), вы можете указать предпочтительный формат пикселей для полученного TIFF-изображения.

Этот код на Java показывает, как конвертировать PowerPoint в TIFF-изображение с пользовательским форматом пикселей:

```java
// Создает объект Presentation, представляющий файл презентации
Presentation pres = new Presentation("presentation.pptx");
try {
    TiffOptions options = new TiffOptions();
    options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    
    /*
     * ImagePixelFormat содержит следующие значения (как указано в документации):
     * Format1bppIndexed; // 1 бит на пиксель, индексированный.
     * Format4bppIndexed; // 4 бита на пиксель, индексированный.
     * Format8bppIndexed; // 8 бит на пиксель, индексированный.
     * Format24bppRgb;    // 24 бита на пиксель, RGB.
     * Format32bppArgb;   // 32 бита на пиксель, ARGB.
     */
    
    // Сохраняет презентацию в TIFF с указанным форматом изображения
    pres.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, options);
} finally {
    if (pres != null) pres.dispose();
}
```