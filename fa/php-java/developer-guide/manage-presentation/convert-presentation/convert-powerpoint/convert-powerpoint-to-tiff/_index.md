---
title: تبدیل ارائه‌های PowerPoint به TIFF در PHP
titlelink: PowerPoint به TIFF
type: docs
weight: 90
url: /fa/php-java/convert-powerpoint-to-tiff/
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
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه به راحتی ارائه‌های PowerPoint (PPT, PPTX) را به تصاویر TIFF با کیفیت بالا با استفاده از Aspose.Slides برای PHP از طریق Java تبدیل کنید، با مثال‌های کد."
---
## **مقدمه**

TIFF (**Tagged Image File Format**) یک قالب تصویر رستر بدون اتلاف گسترده است که به دلیل کیفیت استثنایی و حفظ جزئیات گرافیک‌ها شناخته می‌شود. طراحان، عکاسان و ناشران دسکتاپ اغلب TIFF را برای حفظ لایه‌ها، دقت رنگ و تنظیمات اصلی در تصاویر خود انتخاب می‌کنند.

با استفاده از Aspose.Slides، می‌توانید به راحتی اسلایدهای PowerPoint (PPT, PPTX) و اسلایدهای OpenDocument (ODP) را به صورت مستقیم به تصاویر TIFF با کیفیت بالا تبدیل کنید و اطمینان حاصل کنید که ارائه‌های شما حداکثر وفاداری بصری را حفظ می‌کنند.

## **تبدیل یک ارائه به TIFF**

با استفاده از روش [ذخیره](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#save) ارائه‌شده توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/)، می‌توانید به سرعت یک ارائه PowerPoint کامل را به TIFF تبدیل کنید. تصاویر TIFF حاصل مطابق با اندازه پیش‌فرض اسلاید هستند.

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را به TIFF تبدیل کنیم:

```php
// یک شیء از کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است را ایجاد کنید.
$presentation = new Presentation("presentation.pptx");
try {
    // ارائه را به صورت TIFF ذخیره کنید.
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **تبدیل یک ارائه به TIFF سیاه و سفید**

متد [setBwConversionMode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/#setBwConversionMode) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/) به شما امکان می‌دهد الگوریتم استفاده‌شده هنگام تبدیل یک اسلاید یا تصویر رنگی به TIFF سیاه و سفید را مشخص کنید. توجه داشته باشید که این تنظیم فقط زمانی اعمال می‌شود که متد [setCompressionType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/#getCompressionType) بر روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

{{% alert color="info" title="Note" %}}
[TiffOptions::setBwConversionMode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/#setBwConversionMode) یک تنظیم در سطح خروجی است که الگوریتم تبدیل پیکسل را برای کل تصویر TIFF انتخاب می‌کند. برای تعریف نحوه نمایش یک شکل فرد هنگام فعال بودن حالت نمایش سیاه و سفید، از [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#setBlackWhiteMode) استفاده کنید. برای مثال‌ها به [Control Black-and-White Rendering for Shapes](/php-java/shape-formatting/#control-black-and-white-rendering-for-shapes) مراجعه کنید.
{{% /alert %}}

فرض کنید فایلی به نام "sample.pptx" با اسلاید زیر داشته باشیم:

![یک اسلاید ارائه](slide_black_and_white.png)

این کد نشان می‌دهد چگونه اسلاید رنگی را به TIFF سیاه و سفید تبدیل کنیم:

```php
$tiffOptions = new TiffOptions();
$tiffOptions->setCompressionType(TiffCompressionTypes::CCITT4);
$tiffOptions->setBwConversionMode(BlackWhiteConversionMode::Dithering);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![TIFF سیاه و سفید](TIFF_black_and_white.png)

## **تبدیل یک ارائه به TIFF با اندازه سفارشی**

اگر به تصویر TIFF با ابعاد خاصی نیاز دارید، می‌توانید مقادیر دلخواه خود را با استفاده از متدهای موجود در [TiffOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/) تنظیم کنید. به عنوان مثال، متد [setImageSize](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/#getImageSize) به شما امکان می‌دهد اندازه تصویر خروجی را تعریف کنید.

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را به تصاویر TIFF با اندازه سفارشی تبدیل کنیم:

```php
// یک شیء از کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است را ایجاد کنید.
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // نوع فشرده‌سازی را تنظیم کنید.
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    انواع فشرده‌سازی:
        Default - طرح فشرده‌سازی پیش‌فرض (LZW) را مشخص می‌کند.
        None - عدم فشرده‌سازی را مشخص می‌کند.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // عمق بسته به نوع فشرده‌سازی است و نمی‌توان آن را به صورت دستی تنظیم کرد.

    // DPI تصویر را تنظیم کنید.
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // اندازه تصویر را تنظیم کنید.
    $tiffOptions->setImageSize(new Java("java.awt.Dimension", 1728, 1078));

    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // ارائه را به صورت TIFF با اندازه مشخص ذخیره کنید.
    $presentation->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

## **تبدیل یک ارائه به TIFF با فرمت پیکسل تصویر سفارشی**

با استفاده از متد [setPixelFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/#getPixelFormat) از کلاس [TiffOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/) می‌توانید فرمت پیکسل مورد نظر خود را برای تصویر TIFF خروجی مشخص کنید.

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را به تصویر TIFF با فرمت پیکسل سفارشی تبدیل کنیم:

```php
// یک شیء از کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است را ایجاد کنید.
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat شامل مقادیر زیر است (همان‌طور که در مستندات آمده):
        Format1bppIndexed - 1 بیت در هر پیکسل، نمایه‌ای.
        Format4bppIndexed - 4 بیت در هر پیکسل، نمایه‌ای.
        Format8bppIndexed - 8 بیت در هر پیکسل، نمایه‌ای.
        Format24bppRgb    - 24 بیت در هر پیکسل، RGB.
        Format32bppArgb   - 32 بیت در هر پیکسل، ARGB.
    */

    // ارائه را به صورت TIFF با اندازه تصویر مشخص ذخیره کنید.
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Tip" color="info" %}}
به مبدل رایگان PowerPoint به پوستر Aspose مراجعه کنید: [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**آیا می‌توانم یک اسلاید منفرد را به جای کل ارائه PowerPoint به TIFF تبدیل کنم؟**

بله. Aspose.Slides به شما امکان می‌دهد اسلایدهای منفرد از ارائه‌های PowerPoint و OpenDocument را به طور جداگانه به تصاویر TIFF تبدیل کنید.

**آیا محدودیتی برای تعداد اسلایدها هنگام تبدیل یک ارائه به TIFF وجود دارد؟**

خیر، Aspose.Slides محدودیتی برای تعداد اسلایدها اعمال نمی‌کند. می‌توانید هر اندازه‌ای از ارائه‌ها را به فرمت TIFF تبدیل کنید.

**آیا انیمیشن‌ها و افکت‌های انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟**

خیر، TIFF یک قالب تصویر ثابت است. بنابراین، انیمیشن‌ها و افکت‌های انتقال حفظ نمی‌شوند؛ تنها لحظات ثابت اسلایدها صادر می‌شوند.