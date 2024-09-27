---
title: Конвертировать PowerPoint в TIFF
type: docs
weight: 90
url: /ru/net/convert-powerpoint-to-tiff/
keywords: "Конвертировать презентацию PowerPoint, PowerPoint в TIFF, PPT в TIFF, PPTX в TIFF, C#, Csharp, .NET, Aspose.Slides"
description: "Конвертировать презентацию PowerPoint в TIFF на C# или .NET."

---

TIFF (**Tagged Image File Format**) — это безошибочный растровый и высококачественный формат изображения. Профессионалы используют TIFF для своих дизайнерских, фотографических и издательских проектов. Например, если вы хотите сохранить слои и настройки в вашем дизайне или изображении, возможно, вы захотите сохранить свою работу в виде TIFF-файла.

Aspose.Slides позволяет конвертировать слайды в PowerPoint непосредственно в TIFF.

{{% alert title="Совет" color="primary" %}}

Вы можете ознакомиться с [БЕСПЛАТНЫМ конвертером PowerPoint в постер](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) от Aspose.

{{% /alert %}}

## **Конвертировать PowerPoint в TIFF**

Используя метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/), предоставленный классом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), вы можете быстро преобразовать всю презентацию PowerPoint в TIFF. Полученные TIFF-изображения соответствуют размеру слайдов по умолчанию.

Этот код на C# показывает, как конвертировать PowerPoint в TIFF:

```c#
// Создает объект Presentation, представляющий файл презентации
using (Presentation presentation = new Presentation("DemoFile.pptx"))
{
    // Сохраняет презентацию в формате TIFF
    presentation.Save("Tiffoutput_out.tiff", SaveFormat.Tiff);
}
```

## **Конвертировать PowerPoint в черно-белый TIFF**

В Aspose.Slides 23.10 добавлено новое свойство ([BwConversionMode](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/bwconversionmode/)) в класс [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/), чтобы вы могли указать алгоритм, который будет использоваться при конвертации цветного слайда или изображения в черно-белый TIFF. Обратите внимание, что эта настройка применяется только в том случае, если свойство [CompressionType](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/) установлено на `CCITT4` или `CCITT3`.

Этот код на C# показывает, как конвертировать цветной слайд или изображение в черно-белый TIFF:

```c#
var tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
```

## **Конвертировать PowerPoint в TIFF с пользовательским размером**

Если вам требуется TIFF-изображение с заданными размерами, вы можете определить свои предпочтительные размеры через свойства, предоставленные в [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/). Например, используя свойство [ImageSize](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/), вы можете установить размер для получаемого изображения.

Этот код на C# показывает, как конвертировать PowerPoint в TIFF-изображения с пользовательским размером:

```c#
// Создает объект Presentation, представляющий файл презентации
using (Presentation pres = new Presentation("Convert_Tiff_Custom.pptx"))
{
    // Создает класс TiffOptions
    TiffOptions opts = new TiffOptions();

    // Устанавливает тип сжатия
    opts.CompressionType = TiffCompressionTypes.Default;

    INotesCommentsLayoutingOptions notesOptions = opts.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;
    // Типы сжатия

    // Default - Указывает схему сжатия по умолчанию (LZW).
    // None - Указывает на отсутствие сжатия.
    // CCITT3
    // CCITT4
    // LZW
    // RLE

    // Глубина зависит от типа сжатия и не может быть установлена вручную.
    // Единица разрешения всегда равна “2” (точек на дюйм)

    // Устанавливает DPI изображения
    opts.DpiX = 200;
    opts.DpiY = 100;

    // Устанавливает размер изображения
    opts.ImageSize = new Size(1728, 1078);

    // Сохраняет презентацию в TIFF с указанным размером
    pres.Save("TiffWithCustomSize_out.tiff", SaveFormat.Tiff, opts);
}
```

## **Конвертировать PowerPoint в TIFF с пользовательским форматом пикселей изображения**

Используя свойство [PixelFormat](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/) в классе [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions), вы можете указать предпочтительный формат пикселей для получаемого TIFF-изображения.

Этот код на C# показывает, как конвертировать PowerPoint в TIFF-изображение с пользовательским форматом пикселей:

```c#
// Создает объект Presentation, представляющий файл презентации
using (Presentation presentation = new Presentation("DemoFile.pptx"))
{
    TiffOptions options = new TiffOptions();
   
    options.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat содержит следующие значения (как указано в документации):
    Format1bppIndexed; // 1 бит на пиксель, индексированный.
    Format4bppIndexed; // 4 бита на пиксель, индексированный.
    Format8bppIndexed; // 8 бит на пиксель, индексированный.
    Format24bppRgb; // 24 бита на пиксель, RGB.
    Format32bppArgb; // 32 бита на пиксель, ARGB.
    */

    // Сохраняет презентацию в TIFF с указанным размером изображения
    presentation.Save("Tiff_With_Custom_Image_Pixel_Format_out.tiff", SaveFormat.Tiff, options);
}
```