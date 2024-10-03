---
title: Конвертировать PowerPoint в TIFF
type: docs
weight: 90
url: /ru/cpp/convert-powerpoint-to-tiff/
keywords: "Конвертировать презентацию PowerPoint, PowerPoint в TIFF, PPT в TIFF, PPTX в TIFF, C++, CPP, Aspose.Slides"
description: "Конвертировать презентацию PowerPoint в TIFF на C++"
---

**TIFF** (формат файлов с тэгами изображения) — это без потерь растровый и высококачественный формат изображения. Профессионалы используют TIFF для своих дизайнерских, фотографических и издательских нужд. Например, если вы хотите сохранить слои и настройки в своем дизайне или изображении, вы можете сохранить свою работу в виде файла изображения TIFF.

Aspose.Slides позволяет вам конвертировать слайды PowerPoint напрямую в TIFF.

{{% alert title="Совет" color="primary" %}}

Вы можете попробовать [БЕСПЛАТНЫЙ конвертер PowerPoint в постер](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) от Aspose.

{{% /alert %}}

## **Конвертировать PowerPoint в TIFF**

Используя метод [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/), предоставленный классом [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), вы можете быстро конвертировать всю презентацию PowerPoint в TIFF. Полученные TIFF-изображения соответствуют стандартному размеру слайдов.

Этот код на C++ показывает, как конвертировать PowerPoint в TIFF:

```c++
// Путь к директории документов.
String dataDir = GetDataPath();

// Создает объект Presentation, который представляет файл презентации
auto presentation = System::MakeObject<Presentation>(dataDir + u"DemoFile.pptx");

// Сохраняет презентацию как TIFF
presentation->Save(dataDir + u"Tiffoutput_out.tiff", SaveFormat::Tiff);
```

## **Конвертировать PowerPoint в черно-белый TIFF**

В Aspose.Slides 23.10 добавлено новое свойство ([BwConversionMode](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/)) в класс [TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options), которое позволяет вам указать алгоритм, который используется при конвертации цветного слайда или изображения в черно-белый TIFF. Обратите внимание, что эта настройка применяется только тогда, когда свойство [CompressionType](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) установлено на `CCITT4` или `CCITT3`.

Этот код на C++ показывает, как конвертировать цветной слайд или изображение в черно-белый TIFF:

```c++
System::SharedPtr<TiffOptions> tiffOptions = System::MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);
```

## **Конвертировать PowerPoint в TIFF с пользовательским размером**

Если вам нужно TIFF-изображение с определенными размерами, вы можете задать свои предпочтительные значения через свойства, предоставленные в [TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options). С помощью свойства [ImageSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) вы можете задать размер для получаемого изображения.

Этот код на C++ показывает, как конвертировать PowerPoint в TIFF-изображения с пользовательским размером:

```c++
// Путь к директории документов.
System::String dataDir = GetDataPath();

// Создает объект Presentation, который представляет файл презентации
auto pres = System::MakeObject<Presentation>(dataDir + u"Convert_Tiff_Custom.pptx");

// Создает класс TiffOptions
auto opts = System::MakeObject<TiffOptions>();

// Устанавливает тип сжатия
opts->set_CompressionType(TiffCompressionTypes::Default);

auto notesOptions = opts->get_NotesCommentsLayouting();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
// Типы сжатия

// Default - Означает стандартную схему сжатия (LZW).
// None - Означает отсутствие сжатия.
// CCITT3
// CCITT4
// LZW
// RLE

// Глубина зависит от типа сжатия и не может быть установлена вручную.
// Единица измерения разрешения всегда равна 2 (точек на дюйм)

// Устанавливает DPI изображения
opts->set_DpiX(200);
opts->set_DpiY(100);

// Устанавливает размер изображения
opts->set_ImageSize(System::Drawing::Size(1728, 1078));

// Сохраняет презентацию в TIFF с указанным размером
pres->Save(dataDir + u"TiffWithCustomSize_out.tiff", SaveFormat::Tiff, opts);
```


## **Конвертировать PowerPoint в TIFF с индивидуальным форматом пикселя изображения**

Используя свойство [PixelFormat](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) в классе [TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options), вы можете указать предпочтительный формат пикселя для получаемого TIFF-изображения.

Этот код на C++ показывает, как конвертировать PowerPoint в TIFF-изображение с индивидуальным форматом пикселя:

```c++
// Путь к директории документов.
System::String dataDir = GetDataPath();

// Создает объект Presentation, который представляет файл презентации
auto presentation = System::MakeObject<Presentation>(dataDir + u"DemoFile.pptx");

auto options = System::MakeObject<TiffOptions>();
options->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat включает следующие значения (как можно увидеть из документации):
Format1bppIndexed; // 1 бит на пиксель, индексированный.
Format4bppIndexed; // 4 бита на пиксель, индексированный.
Format8bppIndexed; // 8 бит на пиксель, индексированный.
Format24bppRgb; // 24 бита на пиксель, RGB.
Format32bppArgb; // 32 бита на пиксель, ARGB.
*/

// Сохраняет презентацию в TIFF с указанным размером
presentation->Save(dataDir + u"Tiff_With_Custom_Image_Pixel_Format_out.tiff", SaveFormat::Tiff, options);
```