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

TIFF (**Tagged Image File Format**) یک فرمت تصویر رایستری بدون فقدان (lossless) است که به دلیل کیفیت بی‌نظیر و حفظ دقیق گرافیک‌ها به‌طور گسترده‌ای مورد استفاده قرار می‌گیرد. طراحان، عکاسان و ناشران دسکتاپ اغلب برای حفظ لایه‌ها، دقت رنگ و تنظیمات اصلی تصاویر خود، TIFF را برمی‌گزینند.

با استفاده از Aspose.Slides می‌توانید به‌راحتی اسلایدهای PowerPoint (PPT, PPTX) و اسلایدهای OpenDocument (ODP) را مستقیماً به تصاویر TIFF با کیفیت بالا تبدیل کنید و اطمینان حاصل کنید ارائه‌های شما بیشترین صحت بصری را حفظ کنند.

## **تبدیل یک ارائه به TIFF**

با استفاده از متد [Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) ارائه‌شده توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) می‌توانید به سرعت یک ارائه کامل PowerPoint را به TIFF تبدیل کنید. تصاویر TIFF حاصل مطابق با اندازه پیش‌فرض اسلاید هستند.

این کد C++ نشان می‌دهد چگونه یک ارائه PowerPoint را به TIFF تبدیل کنیم:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// ارائه را به صورت TIFF ذخیره کنید.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **تبدیل یک ارائه به TIFF سیاه و سفید**

متد [set_BwConversionMode](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/) به شما امکان می‌دهد الگوریتم مورد استفاده هنگام تبدیل یک اسلاید یا تصویر رنگی به TIFF سیاه و سفید را تعیین کنید. توجه داشته باشید که این تنظیم فقط زمانی اعمال می‌شود که متد [set_CompressionType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

فرض کنید فایلی به نام "sample.pptx" داریم که شامل اسلاید زیر است:

![یک اسلاید ارائه](slide_black_and_white.png)

این کد C++ نشان می‌دهد چگونه اسلاید رنگی را به TIFF سیاه و سفید تبدیل کنیم:

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

![TIFF سیاه و سفید](TIFF_black_and_white.png)

## **تبدیل یک ارائه به TIFF با اندازه سفارشی**

اگر به تصویری TIFF با ابعاد خاص نیاز دارید، می‌توانید مقادیر دلخواه خود را با استفاده از متدهای موجود در [TiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/) تنظیم کنید. به عنوان مثال، متد [set_ImageSize](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_imagesize/) به شما اجازه می‌دهد اندازه تصویر خروجی را تعریف کنید.

این کد C++ نشان می‌دهد چگونه یک ارائه PowerPoint را به تصاویر TIFF با اندازه سفارشی تبدیل کنیم:

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
    None - بدون فشرده‌سازی است.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// عمق بستگی به نوع فشرده‌سازی دارد و نمی‌تواند به‌صورت دستی تنظیم شود.

// تنظیم DPI تصویر.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// تنظیم اندازه تصویر.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// ذخیره ارائه به صورت TIFF با اندازه مشخص‌شده.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **تبدیل یک ارائه به TIFF با قالب پیکسل تصویر سفارشی**

با استفاده از متد [set_PixelFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) از کلاس [TiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/) می‌توانید قالب پیکسل مورد نظر خود را برای تصویر TIFF خروجی تعیین کنید.

این کد C++ نشان می‌دهد چگونه یک ارائه PowerPoint را به تصویری TIFF با قالب پیکسل سفارشی تبدیل کنیم:

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
ImagePixelFormat شامل مقادیر زیر است (همانطور که در مستندات ذکر شده است):
    Format1bppIndexed - 1 بیت در هر پیکسل، فهرست‌دار.
    Format4bppIndexed - 4 بیت در هر پیکسل، فهرست‌دار.
    Format8bppIndexed - 8 بیت در هر پیکسل، فهرست‌دار.
    Format24bppRgb    - 24 بیت در هر پیکسل، RGB.
    Format32bppArgb   - 32 بیت در هر پیکسل، ARGB.
*/

// ذخیره ارائه به صورت TIFF با اندازه تصویر مشخص‌شده.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tip" color="info" %}}
به تبدیل‌کننده رایگان PowerPoint به پوستر Aspose نگاهی بیندازید: [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **سؤالات متداول**

### آیا می‌توانم یک اسلاید جداگانه را به‌جای تمام ارائه PowerPoint به TIFF تبدیل کنم؟

بله. Aspose.Slides به شما امکان می‌دهد اسلایدهای جداگانه را از ارائه‌های PowerPoint و OpenDocument به‌صورت مستقل به تصاویر TIFF تبدیل کنید.

### آیا محدودیتی برای تعداد اسلایدها هنگام تبدیل یک ارائه به TIFF وجود دارد؟

خیر، Aspose.Slides هیچ محدودیتی برای تعداد اسلایدها اعمال نمی‌کند. شما می‌توانید ارائه‌های با هر اندازه‌ای را به فرمت TIFF تبدیل کنید.

### آیا انیمیشن‌ها و اثرات انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟

خیر، TIFF یک فرمت تصویر ثابت است. بنابراین، انیمیشن‌ها و اثرات انتقال حفظ نمی‌شوند؛ تنها تصاویر ثابت از اسلایدها استخراج می‌شود.