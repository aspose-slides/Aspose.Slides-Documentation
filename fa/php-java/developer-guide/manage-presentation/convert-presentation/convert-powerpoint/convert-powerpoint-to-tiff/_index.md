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
description: "بیاموزید چگونه به راحتی ارائه‌های PowerPoint (PPT، PPTX) را به تصاویر TIFF با کیفیت بالا با استفاده از Aspose.Slides برای PHP از طریق Java تبدیل کنید، به همراه مثال‌های کد."
---
## **مقدمه**

TIFF (**Tagged Image File Format**) یک فرمت تصویر رستر بدون اتلاف است که به‌دلیل کیفیت بالای خود و حفظ جزئیات گرافیک شناخته شده است. طراحان، عکاسان و ناشران دسکتاپ اغلب برای حفظ لایه‌ها، دقت رنگ و تنظیمات اصلی تصاویر از TIFF استفاده می‌کنند.

با استفاده از Aspose.Slides، می‌توانید اسلایدهای PowerPoint (PPT, PPTX) و اسلایدهای OpenDocument (ODP) را به‌صورت مستقیم به تصاویر TIFF با کیفیت بالا تبدیل کنید و اطمینان حاصل کنید که ارائه‌های شما حداکثر شباهت بصری را حفظ می‌کنند.

## **تبدیل ارائه به TIFF**

با استفاده از متد [save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#save) ارائه‌شده توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) می‌توانید به‌سرعت کل ارائه PowerPoint را به TIFF تبدیل کنید. تصاویر TIFF حاصل مطابق با اندازه پیش‌فرض اسلاید هستند.

این کد نحوه تبدیل یک ارائه PowerPoint به TIFF را نشان می‌دهد:

```php
// یک نمونه از کلاس Presentation ایجاد کنید که یک فایل ارائه (PPT، PPTX، ODP و غیره) را نمایندگی می‌کند.
$presentation = new Presentation("presentation.pptx");
try {
    // ارائه را به عنوان TIFF ذخیره کنید.
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **تبدیل ارائه به TIFF سیاه‑سفید**

متد [setBwConversionMode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/#setBwConversionMode) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/) به شما امکان می‌دهد الگوریتم مورد استفاده هنگام تبدیل یک اسلاید یا تصویر رنگی به TIFF سیاه‑سفید را مشخص کنید. توجه داشته باشید که این تنظیم فقط زمانی اعمال می‌شود که متد [setCompressionType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/#getCompressionType) بر روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

{{% alert color="info" title="توجه" %}}

[TiffOptions::setBwConversionMode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/#setBwConversionMode) یک تنظیم سطح خروجی است که الگوریتم تبدیل پیکسل را برای کل تصویر TIFF انتخاب می‌کند. برای تعریف نحوه نمایش یک شکل به‌صورت تک‌تک هنگام فعال بودن حالت نمایش سیاه‑سفید، از [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#setBlackWhiteMode) استفاده کنید. برای مثال‌ها به [Control Black-and-White Rendering for Shapes](/slides/fa/php-java/shape-formatting/#control-black-and-white-rendering-for-shapes) مراجعه کنید.

{{% /alert %}}

فرض کنید فایلی به نام "sample.pptx" با اسلاید زیر داریم:

![یک اسلاید ارائه](slide_black_and_white.png)

این کد نحوه تبدیل اسلاید رنگی به TIFF سیاه‑سفید را نشان می‌دهد:

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

![TIFF سیاه‑سفید](TIFF_black_and_white.png)

## **تبدیل ارائه به TIFF با اندازهٔ سفارشی**

اگر به تصویری TIFF با ابعاد مشخص نیاز دارید، می‌توانید مقادیر دلخواه خود را با استفاده از متدهای موجود در [TiffOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/) تنظیم کنید. به‌عنوان مثال، متد [setImageSize](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/#getImageSize) به شما امکان تعریف اندازه تصویر نهایی را می‌دهد.

این کد نحوه تبدیل یک ارائه PowerPoint به تصاویر TIFF با اندازهٔ سفارشی را نشان می‌دهد:

```php
// یک نمونه از کلاس Presentation ایجاد کنید که یک فایل ارائه (PPT، PPTX، ODP و غیره) را نمایندگی می‌کند.
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

    // عمق بسته به نوع فشرده‌سازی است و نمی‌تواند به‌صورت دستی تنظیم شود.

    // DPI تصویر را تنظیم کنید.
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // اندازه تصویر را تنظیم کنید.
    $tiffOptions->setImageSize(new Java("java.awt.Dimension", 1728, 1078));

    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // ارائه را به‌عنوان TIFF با اندازهٔ مشخص شده ذخیره کنید.
    $presentation->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

## **تبدیل ارائه به TIFF با فرمت پیکسل تصویر سفارشی**

با استفاده از متد [setPixelFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/#getPixelFormat) موجود در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/) می‌توانید فرمت پیکسل دلخواه خود را برای تصویر TIFF نهایی تعیین کنید.

این کد نحوه تبدیل یک ارائه PowerPoint به یک تصویر TIFF با فرمت پیکسل سفارشی را نشان می‌دهد:

```php
// یک نمونه از کلاس Presentation ایجاد کنید که یک فایل ارائه (PPT، PPTX، ODP و غیره) را نمایندگی می‌کند.
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat شامل مقادیر زیر است (طبق مستندات):
        Format1bppIndexed - 1 بیت به ازای هر پیکسل، نمایه‌ای.
        Format4bppIndexed - 4 بیت به ازای هر پیکسل، نمایه‌ای.
        Format8bppIndexed - 8 بیت به ازای هر پیکسل، نمایه‌ای.
        Format24bppRgb    - 24 بیت به ازای هر پیکسل، RGB.
        Format32bppArgb   - 32 بیت به ازای هر پیکسل، ARGB.
    */

    // ارائه را به‌عنوان TIFF با اندازهٔ تصویر مشخص شده ذخیره کنید.
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="نکته" color="info" %}}

به مبدل [رایگان PowerPoint به پوستر](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online) از Aspose نگاهی بیندازید.

{{% /alert %}}

## **سؤالات متداول**

**آیا می‌توانم به‌جای تبدیل کل ارائه PowerPoint، یک اسلاید را به‌صورت جداگانه به TIFF تبدیل کنم؟**

بله. Aspose.Slides به شما امکان می‌دهد اسلایدهای جداگانه از ارائه‌های PowerPoint و OpenDocument را به‌صورت مستقل به تصاویر TIFF تبدیل کنید.

**آیا محدودیتی برای تعداد اسلایدها هنگام تبدیل ارائه به TIFF وجود دارد؟**

خیر، Aspose.Slides هیچ محدودیتی برای تعداد اسلایدها اعمال نمی‌کند. می‌توانید ارائه‌های با هر اندازه‌ای را به فرمت TIFF تبدیل کنید.

**آیا انیمیشن‌ها و افکت‌های انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟**

خیر، TIFF یک فرمت تصویر ثابت است. بنابراین، انیمیشن‌ها و افکت‌های انتقال حفظ نمی‌شوند؛ تنها تصویر ثابت از اسلایدها استخراج می‌شود.