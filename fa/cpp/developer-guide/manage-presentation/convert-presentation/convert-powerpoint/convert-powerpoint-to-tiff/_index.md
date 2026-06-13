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
description: "یاد بگیرید چگونه به‌ راحتی ارائه‌های PowerPoint (PPT، PPTX) را به تصاویر TIFF با کیفیت بالا با استفاده از Aspose.Slides برای C++ تبدیل کنید، همراه با مثال‌های کد."
---
## **مقدمه**

TIFF (**Tagged Image File Format**) یک فرمت تصویر رستر بدون خسارت و گسترده استفاده است که به دلیل کیفیت استثنایی و حفظ جزئیات گرافیک شناخته می‌شود. طراحان، عکاسان و نشرکنندگان دسکتاپ اغلب TIFF را برای حفظ لایه‌ها، دقت رنگ و تنظیمات اصلی تصاویر خود انتخاب می‌کنند.

با استفاده از Aspose.Slides می‌توانید به‌ راحتی اسلایدهای PowerPoint (PPT، PPTX) و اسلایدهای OpenDocument (ODP) را به‌صورت مستقیم به تصاویر TIFF با کیفیت بالا تبدیل کنید و اطمینان حاصل کنید که ارائه‌های شما حداکثر صحت بصری را حفظ می‌ نمایند.

## **تبدیل یک ارائه به TIFF**

با استفاده از متد [Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) ارائه‌شده توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) می‌توانید به‌سرعت یک ارائه کامل PowerPoint را به TIFF تبدیل کنید. تصاویر TIFF حاصل مطابق با اندازه پیش‌فرض اسلاید هستند.

این کد C++ نشان می‌دهد که چگونه یک ارائه PowerPoint را به TIFF تبدیل کنید:

```cpp
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// ذخیرهٔ ارائه به‌عنوان TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **تبدیل یک ارائه به TIFF سیاه‑سفید**

متد [set_BwConversionMode](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/) به شما امکان می‌دهد الگوریتم استفاده‌شده هنگام تبدیل اسلاید یا تصویر رنگی به TIFF سیاه‑سفید را مشخص کنید. توجه داشته باشید که این تنظیم فقط زمانی اعمال می‌شود که متد [set_CompressionType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) بر روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

فرض کنید فایلی به نام "sample.pptx" داریم که اسلاید زیر را شامل می‌شود:

![یک اسلاید ارائه](slide_black_and_white.png)

این کد C++ نشان می‌دهد که چگونه اسلاید رنگی را به یک TIFF سیاه‑سفید تبدیل کنید:

```cpp
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

نتیجه:

![TIFF سیاه‑سفید](TIFF_black_and_white.png)

## **تبدیل یک ارائه به TIFF با اندازه سفارشی**

اگر به تصویر TIFF با ابعاد خاصی نیاز دارید، می‌توانید مقادیر دلخواه خود را با استفاده از متدهای موجود در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/) تنظیم کنید. برای مثال، متد [set_ImageSize](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_imagesize/) به شما امکان می‌دهد اندازه تصویر خروجی را تعریف کنید.

این کد C++ نشان می‌دهد که چگونه یک ارائه PowerPoint را به تصاویر TIFF با اندازه سفارشی تبدیل کنید:

```cpp
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// تنظیم نوع فشرده‌سازی.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
انواع فشرده‌سازی:
    Default - طرح فشرده‌سازی پیش‌فرض را مشخص می‌کند (LZW).
    None - عدم فشرده‌سازی را مشخص می‌کند.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// عمق بسته به نوع فشرده‌سازی است و نمی‌توان به‌صورت دستی تنظیم شد.

// تنظیم DPI تصویر.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// تنظیم اندازه تصویر.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// ذخیرهٔ ارائه به‌عنوان TIFF با اندازه مشخص شده.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **تبدیل یک ارائه به TIFF با قالب پیکسل تصویر سفارشی**

با استفاده از متد [set_PixelFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) از کلاس [TiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/) می‌توانید قالب پیکسل مورد نظر خود را برای تصویر TIFF خروجی مشخص کنید.

این کد C++ نشان می‌دهد که چگونه یک ارائه PowerPoint را به تصویر TIFF با قالب پیکسل سفارشی تبدیل کنید:

```cpp
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat شامل مقادیر زیر است (طبق مستندات):
    Format1bppIndexed - 1 بیت در هر پیکسل، فهرست‌شده.
    Format4bppIndexed - 4 بیت در هر پیکسل، فهرست‌شده.
    Format8bppIndexed - 8 بیت در هر پیکسل، فهرست‌شده.
    Format24bppRgb    - 24 بیت در هر پیکسل، RGB.
    Format32bppArgb   - 32 بیت در هر پیکسل، ARGB.
*/

// ذخیرهٔ ارائه به‌عنوان TIFF با اندازهٔ تصویر مشخص‌شده.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tip" color="primary" %}}
به [مبدل رایگان PowerPoint به پوستر Aspose](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online) نگاهی بیندازید.
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم یک اسلاید تک به‌جای کل ارائه PowerPoint به TIFF تبدیل کنم؟**

بله. Aspose.Slides به شما امکان می‌دهد اسلایدهای منفرد از ارائه‌های PowerPoint و OpenDocument را به‌صورت جداگانه به تصاویر TIFF تبدیل کنید.

**آیا محدودیتی برای تعداد اسلایدها هنگام تبدیل یک ارائه به TIFF وجود دارد؟**

خیر، Aspose.Slides هیچ محدودیتی برای تعداد اسلایدها اعمال نمی‌کند. می‌توانید ارائه‌های با هر اندازه‌ای را به فرمت TIFF تبدیل کنید.

**آیا انیمیشن‌ها و اثرات انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟**

خیر، TIFF یک فرمت تصویر ثابت است. بنابراین، انیمیشن‌ها و اثرات انتقال حفظ نمی‌شوند؛ فقط تصاویر ثابت از اسلایدها صادر می‌شود.