---
title: تبدیل ارائه‌های PowerPoint به TIFF در C++
titlelink: PowerPoint به TIFF
type: docs
weight: 90
url: /fa/cpp/convert-powerpoint-to-tiff/
keywords:
- تبدیل PowerPoint
- تبدیل OpenDocument
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به TIFF
- ارائه به TIFF
- اسلاید به TIFF
- PPT به TIFF
- PPTX به TIFF
- ذخیره PPT به عنوان TIFF
- ذخیره PPTX به عنوان TIFF
- خروجی PPT به TIFF
- خروجی PPTX به TIFF
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه به راحتی ارائه‌های PowerPoint (PPT، PPTX) را به تصاویر TIFF با کیفیت بالا با استفاده از Aspose.Slides برای C++ تبدیل کنید، همراه با مثال‌های کد."
---
## **معرفی**

TIFF (**Tagged Image File Format**) یک قالب تصویر رستری بدون از دست رفتن کیفیت است که به دلیل کیفیت برجسته و حفظ جزئیات گرافیک به‌طور گسترده‌ای مورد استفاده قرار می‌گیرد. طراحان، عکاسان و ناشرهای دسکتاپ غالباً برای حفظ لایه‌ها، دقت رنگ و تنظیمات اصلی در تصاویر خود، TIFF را انتخاب می‌کنند.

با استفاده از Aspose.Slides می‌توانید اسلایدهای PowerPoint (PPT, PPTX) و اسلایدهای OpenDocument (ODP) را به‌صورت مستقیم به تصاویر TIFF با کیفیت بالا تبدیل کنید و اطمینان حاصل کنید که ارائه‌های شما حداکثر وفاداری بصری را حفظ می‌کند.

## **تبدیل یک ارائه به TIFF**

با استفاده از متد [Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) فراهم شده است، می‌توانید به سرعت کل یک ارائه PowerPoint را به TIFF تبدیل کنید. تصاویر TIFF حاصل با اندازه پیش‌فرض اسلاید مطابقت دارند.

این کد C++ نشان می‌دهد چگونه یک ارائه PowerPoint را به TIFF تبدیل کنید:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// شی کلاس Presentation را که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است، نمونه‌سازی می‌کند.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Save the presentation as TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **تبدیل یک ارائه به TIFF سیاه و سفید**

متد [set_BwConversionMode](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/) به شما امکان می‌دهد الگوریتم مورد استفاده هنگام تبدیل یک اسلاید یا تصویر رنگی به TIFF سیاه و سفید را مشخص کنید. توجه داشته باشید که این تنظیم فقط زمانی اعمال می‌شود که متد [set_CompressionType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

{{% alert color="info" title="توضیح" %}}
[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) یک تنظیم سطح خروجی است که الگوریتم تبدیل پیکسل برای کل تصویر TIFF را انتخاب می‌کند. برای تعریف نحوه نمایش یک شکل به‌صورت فردی زمانی که حالت نمایش سیاه‑و‑سفید فعال است، از [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/set_blackwhitemode/) استفاده کنید. برای مثال‌ها به [Control Black-and-White Rendering for Shapes](/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes) مراجعه کنید.
{{% /alert %}}

فرض کنید فایلی به نام "sample.pptx" داریم که اسلاید زیر را شامل می‌شود:

![A presentation slide](slide_black_and_white.png)

این کد C++ نشان می‌دهد چگونه اسلاید رنگی را به TIFF سیاه و سفید تبدیل کنید:

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

نتیجه:

![Black-and-White TIFF](TIFF_black_and_white.png)

## **تبدیل یک ارائه به TIFF با اندازه سفارشی**

اگر به تصویری با ابعاد خاص نیاز دارید، می‌توانید مقادیر دلخواه خود را با استفاده از متدهای موجود در [TiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/) تنظیم کنید. به‌عنوان مثال، متد [set_ImageSize](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_imagesize/) به شما امکان می‌دهد اندازه تصویر نهایی را تعریف کنید.

این کد C++ نشان می‌دهد چگونه یک ارائه PowerPoint را به تصاویر TIFF با اندازه سفارشی تبدیل کنید:

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

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// تنظیم نوع فشرده‌سازی.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
انواع فشرده‌سازی:
    Default - طرح فشرده‌سازی پیش‌فرض را مشخص می‌کند (LZW).
    None - بدون فشرده‌سازی است.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// عمق بستگی به نوع فشرده‌سازی دارد و نمی‌توان آن را به‌صورت دستی تنظیم کرد.

// تنظیم DPI تصویر.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// تنظیم اندازه تصویر.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// ذخیره ارائه به عنوان TIFF با اندازه مشخص شده.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **تبدیل یک ارائه به TIFF با فرمت پیکسل تصویر سفارشی**

با استفاده از متد [set_PixelFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) از کلاس [TiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/) می‌توانید فرمت پیکسل دلخواه خود را برای تصویر TIFF خروجی تعیین کنید.

این کد C++ نشان می‌دهد چگونه یک ارائه PowerPoint را به تصویر TIFF با فرمت پیکسل سفارشی تبدیل کنید:

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat شامل مقادیر زیر است (همان‌طور که در مستندات ذکر شده است):
    Format1bppIndexed - 1 بیت در هر پیکسل، نشان‌دار.
    Format4bppIndexed - 4 بیت در هر پیکسل، نشان‌دار.
    Format8bppIndexed - 8 بیت در هر پیکسل، نشان‌دار.
    Format24bppRgb    - 24 بیت در هر پیکسل، RGB.
    Format32bppArgb   - 32 بیت در هر پیکسل، ARGB.
*/

// ذخیره ارائه به عنوان TIFF با اندازه تصویر مشخص شده.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="نکته" color="info" %}}
به مبدل **رایگان** PowerPoint به پوستر Aspose مراجعه کنید: [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم به جای تبدیل کل ارائه PowerPoint به TIFF، تنها یک اسلاید را تبدیل کنم؟**

بله. Aspose.Slides به شما امکان می‌دهد اسلایدهای منفرد از ارائه‌های PowerPoint و OpenDocument را به‌صورت جداگانه به تصاویر TIFF تبدیل کنید.

**آیا در تبدیل یک ارائه به TIFF محدودیتی برای تعداد اسلایدها وجود دارد؟**

خیر، Aspose.Slides هیچ محدودیتی برای تعداد اسلایدها اعمال نمی‌کند. می‌توانید هر اندازه ارائه‌ای را به فرمت TIFF تبدیل کنید.

**آیا انیمیشن‌ها و افکت‌های انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟**

خیر، TIFF یک قالب تصویر ثابت است. بنابراین انیمیشن‌ها و افکت‌های انتقال حفظ نمی‌شوند؛ فقط تصویرهای ایستایی از اسلایدها صادر می‌شوند.