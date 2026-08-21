---
title: Конвертировать презентации PowerPoint в TIFF на C++
titlelink: PowerPoint в TIFF
type: docs
weight: 90
url: /ru/cpp/convert-powerpoint-to-tiff/
keywords:
- конвертировать PowerPoint
- конвертировать OpenDocument
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в TIFF
- презентацию в TIFF
- слайд в TIFF
- PPT в TIFF
- PPTX в TIFF
- сохранить PPT как TIFF
- сохранить PPTX как TIFF
- экспортировать PPT в TIFF
- экспортировать PPTX в TIFF
- C++
- Aspose.Slides
description: "Узнайте, как легко конвертировать презентации PowerPoint (PPT, PPTX) в изображения высокого качества TIFF с помощью Aspose.Slides для C++, с примерами кода."
---
## **Введение**

TIFF (**Tagged Image File Format**) — широко используемый формат растровых изображений без потерь, известный своей исключительным качеством и детальным сохранением графики. Дизайнеры, фотографы и настольные издатели часто выбирают TIFF для сохранения слоёв, точности цвета и оригинальных настроек в своих изображениях.

С помощью Aspose.Slides вы можете без усилий преобразовать свои слайды PowerPoint (PPT, PPTX) и слайды OpenDocument (ODP) непосредственно в изображения TIFF высокого качества, обеспечивая максимальную визуальную достоверность ваших презентаций.

## **Конвертировать презентацию в TIFF**

Используя метод [Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/save/) класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/), вы можете быстро преобразовать всю презентацию PowerPoint в TIFF. Полученные изображения TIFF соответствуют размеру слайда по умолчанию.

Этот код C++ демонстрирует, как преобразовать презентацию PowerPoint в TIFF:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantiate the Presentation class that represents a presentation file (PPT, PPTX, ODP, etc.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Save the presentation as TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Конвертировать презентацию в черно-белый TIFF**

Метод [set_BwConversionMode](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) в классе [TiffOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/tiffoptions/) позволяет указать алгоритм, используемый при преобразовании цветного слайда или изображения в черно-белый TIFF. Обратите внимание, что эта настройка применяется только когда метод [set_CompressionType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) установлен в `CCITT4` или `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) — настройка уровня экспорта, выбирающая алгоритм преобразования пикселей для полного изображения TIFF. Чтобы определить, как отдельный объект должен отображаться в режиме черно-белого отображения, используйте [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/set_blackwhitemode/). См. [Control Black-and-White Rendering for Shapes](/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes) для примеров.
{{% /alert %}}

Допустим, у нас есть файл "sample.pptx" со следующим слайдом:

![Слайд презентации](slide_black_and_white.png)

Этот код C++ демонстрирует, как преобразовать цветной слайд в черно-белый TIFF:

```cpp
#include <DOM/Presentation.h>
#include <Export/BlackWhiteConversionMode.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Результат:

![Черно-белый TIFF](TIFF_black_and_white.png)

## **Конвертировать презентацию в TIFF с пользовательским размером**

Если вам требуется изображение TIFF с определёнными размерами, вы можете задать нужные значения с помощью методов, доступных в [TiffOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/tiffoptions/). Например, метод [set_ImageSize](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/tiffoptions/set_imagesize/) позволяет определить размер получаемого изображения.

Этот код C++ демонстрирует, как преобразовать презентацию PowerPoint в изображения TIFF с пользовательским размером:

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Создайте экземпляр класса Presentation, представляющего файл презентации (PPT, PPTX, ODP и др.).
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Установите тип сжатия.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Типы сжатия:
    Default - Указывает схему сжатия по умолчанию (LZW).
    None - Указывает отсутствие сжатия.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// Глубина зависит от типа сжатия и не может быть установлена вручную.

// Установите DPI изображения.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// Установите размер изображения.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Сохраните презентацию в формате TIFF с указанным размером.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **Конвертировать презентацию в TIFF с пользовательским форматом пикселей изображения**

Используя метод [set_PixelFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) класса [TiffOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/tiffoptions/), вы можете указать предпочитаемый формат пикселей для получаемого изображения TIFF.

Этот код C++ демонстрирует, как преобразовать презентацию PowerPoint в изображение TIFF с пользовательским форматом пикселей:

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Создайте экземпляр класса Presentation, представляющего файл презентации (PPT, PPTX, ODP и т.п.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat содержит следующие значения (как указано в документации):
    Format1bppIndexed - 1 бит на пиксель, индексированный.
    Format4bppIndexed - 4 бита на пиксель, индексированный.
    Format8bppIndexed - 8 бит на пиксель, индексированный.
    Format24bppRgb    - 24 бита на пиксель, RGB.
    Format32bppArgb   - 32 бита на пиксель, ARGB.
*/

// Сохраните презентацию в формате TIFF с указанным размером изображения.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tip" color="info" %}}
Ознакомьтесь с [БЕСПЛАТНЫМ конвертером PowerPoint в постер от Aspose](https://products.aspose.app/slides/ru/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Часто задаваемые вопросы**

**Могу ли я конвертировать отдельный слайд, а не всю презентацию PowerPoint, в TIFF?**

Да. Aspose.Slides позволяет конвертировать отдельные слайды из презентаций PowerPoint и OpenDocument в изображения TIFF отдельно.

**Есть ли ограничение на количество слайдов при конвертации презентации в TIFF?**

Нет, Aspose.Slides не накладывает никаких ограничений на количество слайдов. Вы можете конвертировать презентации любого размера в формат TIFF.

**Сохраняются ли анимации PowerPoint и эффекты переходов при конвертации слайдов в TIFF?**

Нет, TIFF — статический формат изображения. Поэтому анимации и эффекты переходов не сохраняются; экспортируются только статические снимки слайдов.