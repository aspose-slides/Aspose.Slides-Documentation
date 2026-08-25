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
- صادرات PPT به TIFF
- صادرات PPTX به TIFF
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه به‌راحتی ارائه‌های PowerPoint (PPT، PPTX) را به تصاویر TIFF با کیفیت بالا با استفاده از Aspose.Slides برای C++ تبدیل کنید، همراه با مثال‌های کد."
---
## **معرفی**

TIFF (**Tagged Image File Format**) یک قالب تصویر رستری بدون افت کیفیت است که به دلیل کیفیت بالای خود و حفظ جزئیات گرافیک‌ها به‌طور گسترده‌ای استفاده می‌شود. طراحان، عکاسان و ناشران دسکتاپ اغلب برای حفظ لایه‌ها، دقت رنگ و تنظیمات اصلی تصاویر خود از TIFF استفاده می‌کنند.

با استفاده از Aspose.Slides می‌توانید اسلایدهای PowerPoint (PPT، PPTX) و اسلایدهای OpenDocument (ODP) را به‌صورت ساده به تصاویر TIFF با کیفیت بالا تبدیل کنید و اطمینان حاصل کنید که ارائه‌های شما حداکثر وضوح بصری را حفظ می‌کند.

## **تبدیل یک ارائه به TIFF**

با استفاده از متد [Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) ارائه‌شده توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) می‌توانید به‌سرعت تمام یک ارائه PowerPoint را به TIFF تبدیل کنید. تصاویر TIFF تولید شده مطابق با اندازه پیش‌فرض اسلاید هستند.

این کد C++ نشان می‌دهد چگونه یک ارائه PowerPoint را به TIFF تبدیل کنید:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Save the presentation as TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **تبدیل یک ارائه به TIFF سیاه‌وسفید**

متد [set_BwConversionMode](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/) به شما امکان می‌دهد الگوریتم مورد استفاده هنگام تبدیل اسلاید یا تصویر رنگی به TIFF سیاه‌وسفید را تعیین کنید. توجه داشته باشید که این تنظیم تنها زمانی اعمال می‌شود که متد [set_CompressionType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

{{% alert color="info" title="توجه" %}}
[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) یک تنظیم سطح خروجی است که الگوریتم تبدیل پیکسل را برای کل تصویر TIFF انتخاب می‌کند. برای تعیین نحوه نمایش یک شکل خاص هنگام فعال بودن حالت نمایش سیاه‌وسفید، از [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/set_blackwhitemode/) استفاده کنید. برای مثال‌ها، به [Control Black-and-White Rendering for Shapes](/slides/fa/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes) مراجعه کنید.
{{% /alert %}}

فرض کنید فایل «sample.pptx» زیر را داشته باشیم:

![یک اسلاید ارائه](/slide_black_and_white.png)

این کد C++ نشان می‌دهد چگونه اسلاید رنگی را به TIFF سیاه‌وسفید تبدیل کنید:

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

![TIFF سیاه‌وسفید](/TIFF_black_and_white.png)

## **تبدیل یک ارائه به TIFF با اندازه سفارشی**

اگر به تصویر TIFF با ابعاد خاصی نیاز دارید، می‌توانید مقادیر دلخواه خود را با استفاده از متدهای موجود در [TiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/) تنظیم کنید. به‌عنوان مثال، متد [set_ImageSize](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_imagesize/) امکان تعیین اندازه تصویر خروجی را فراهم می‌کند.

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
    Default - طرح فشرده‌سازی پیش‌فرض (LZW) را مشخص می‌کند.
    None - عدم فشرده‌سازی را مشخص می‌کند.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// عمق بسته به نوع فشرده‌سازی است و نمی‌تواند به‌صورت دستی تنظیم شود.

// تنظیم DPI تصویر.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// تنظیم اندازه تصویر.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// ذخیره ارائه به‌صورت TIFF با اندازه مشخص‌شده.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **تبدیل یک ارائه به TIFF با فرمت پیکسل تصویر سفارشی**

با استفاده از متد [set_PixelFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/) می‌توانید فرمت پیکسل مورد نظر خود را برای تصویر TIFF خروجی تعیین کنید.

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
ImagePixelFormat شامل مقادیر زیر است (طبق مستندات):
    Format1bppIndexed - 1 بیت در هر پیکسل، ایندکس شده.
    Format4bppIndexed - 4 بیت در هر پیکسل، ایندکس شده.
    Format8bppIndexed - 8 بیت در هر پیکسل، ایندکس شده.
    Format24bppRgb    - 24 بیت در هر پیکسل، RGB.
    Format32bppArgb   - 32 بیت در هر پیکسل، ARGB.
*/

// ذخیره ارائه به‌صورت TIFF با اندازه تصویر مشخص‌شده.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert color="info" title="نکته" %}}
به مبدل **رایگان PowerPoint به پوستر** Aspose در آدرس [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online) نگاهی بیندازید.
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم به‌جای تبدیل کل ارائه، اسلاید منفردی را به TIFF تبدیل کنم؟**

بله. Aspose.Slides به شما اجازه می‌دهد اسلایدهای منفرد از ارائه‌های PowerPoint و OpenDocument را به‌صورت جداگانه به تصاویر TIFF تبدیل کنید.

**آیا محدودیتی برای تعداد اسلایدها هنگام تبدیل یک ارائه به TIFF وجود دارد؟**

خیر، Aspose.Slides هیچ محدودیتی برای تعداد اسلایدها اعمال نمی‌کند. می‌توانید ارائه‌های با هر اندازه‌ای را به فرمت TIFF تبدیل کنید.

**آیا انیمیشن‌ها و افکت‌های انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟**

خیر، TIFF یک قالب تصویر ثابت است. بنابراین انیمیشن‌ها و افکت‌های انتقال حفظ نمی‌شوند؛ فقط تصویرهای ثابت از اسلایدها صادر می‌شوند.