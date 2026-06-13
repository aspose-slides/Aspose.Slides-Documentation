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
- صادرات PPT به TIFF
- صادرات PPTX به TIFF
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه به‌صورت آسان ارائه‌های PowerPoint (PPT، PPTX) را به تصاویر TIFF با کیفیت بالا با استفاده از Aspose.Slides برای PHP از طریق Java تبدیل کنید، همراه با مثال‌های کد."
---
## **معرفی**

TIFF (**Tagged Image File Format**) یک قالب تصویر رستری بدون‌اتلاف است که به‌دلیل کیفیت فوق‌العاده و حفظ دقیق گرافیک‌ها به‌طور گسترده‌ای استفاده می‌شود. طراحان، عکاسان و ناشران دسکتاپ غالباً TIFF را برای حفظ لایه‌ها، دقت رنگ و تنظیمات اصلی تصاویر خود انتخاب می‌کنند.

با استفاده از Aspose.Slides می‌توانید به‌راحتی اسلایدهای PowerPoint (PPT, PPTX) و اسلایدهای OpenDocument (ODP) را به‌صورت مستقیم به تصاویر TIFF با کیفیت بالا تبدیل کنید و اطمینان حاصل کنید که ارائه‌های شما حداکثر وضوح بصری را حفظ می‌کنند.

## **تبدیل یک ارائه به TIFF**

با استفاده از متد [save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#save) ارائه‌شده توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) می‌توانید به‌سرعت یک ارائه کامل PowerPoint را به TIFF تبدیل کنید. تصاویر TIFF حاصل مطابق با اندازه پیش‌فرض اسلاید هستند.

این کد نشان می‌دهد که چگونه یک ارائه PowerPoint را به TIFF تبدیل کنید:

```php
// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
$presentation = new Presentation("presentation.pptx");
try {
    // ارائه را به صورت TIFF ذخیره می‌کند.
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **تبدیل یک ارائه به TIFF سیاه و سفید**

متد [setBwConversionMode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/#setBwConversionMode) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/) به شما امکان می‌دهد الگوریتم استفاده‌شده هنگام تبدیل یک اسلاید یا تصویر رنگی به TIFF سیاه و سفید را مشخص کنید. توجه داشته باشید که این تنظیم فقط زمانی اعمال می‌شود که متد [setCompressionType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/#getCompressionType) بر روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

بیایید فرض کنیم فایلی به نام "sample.pptx" داریم که اسلاید زیر را در بر دارد:

![یک اسلاید ارائه](slide_black_and_white.png)

این کد نشان می‌دهد که چگونه اسلاید رنگی را به TIFF سیاه و سفید تبدیل کنید:

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

اگر به تصویری TIFF با ابعاد خاص نیاز دارید، می‌توانید مقادیر دلخواه خود را با استفاده از متدهای موجود در [TiffOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/) تنظیم کنید. به عنوان مثال، متد [setImageSize](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/#getImageSize) به شما امکان می‌دهد اندازه تصویر حاصل را تعریف کنید.

این کد نشان می‌دهد که چگونه یک ارائه PowerPoint را به تصاویر TIFF با اندازه سفارشی تبدیل کنید:

```php
// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // تنظیم نوع فشرده‌سازی.
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

    // عمق بستگی به نوع فشرده‌سازی دارد و نمی‌تواند به‌صورت دستی تنظیم شود.

    // تنظیم DPI تصویر.
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // تنظیم اندازه تصویر.
    $tiffOptions->setImageSize(new Java("java.awt.Dimension", 1728, 1078));

    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // ذخیره ارائه به صورت TIFF با اندازه مشخص شده.
    $presentation->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

## **تبدیل یک ارائه به TIFF با فرمت پیکسل تصویر سفارشی**

با استفاده از متد [setPixelFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/#getPixelFormat) از کلاس [TiffOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/) می‌توانید فرمت پیکسل دلخواه خود را برای تصویر TIFF حاصل مشخص کنید.

این کد نشان می‌دهد که چگونه یک ارائه PowerPoint را به تصویر TIFF با فرمت پیکسل سفارشی تبدیل کنید:

```php
// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat شامل مقادیر زیر است (همان‌طور که در مستندات ذکر شده):
        Format1bppIndexed - ۱ بیت به ازای هر پیکسل، ایندکس‌شده.
        Format4bppIndexed - ۴ بیت به ازای هر پیکسل، ایندکس‌شده.
        Format8bppIndexed - ۸ بیت به ازای هر پیکسل، ایندکس‌شده.
        Format24bppRgb    - ۲۴ بیت به ازای هر پیکسل، RGB.
        Format32bppArgb   - ۳۲ بیت به ازای هر پیکسل، ARGB.
    */

    // ارائه را به صورت TIFF با اندازه تصویر مشخص شده ذخیره می‌کند.
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Tip" color="primary" %}}

به مبدل رایگان PowerPoint به پوستر Aspose مراجعه کنید [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **پرسش‌های متداول**

**آیا می‌توانم یک اسلاید منفرد را به‌جای یک ارائه کامل PowerPoint به TIFF تبدیل کنم؟**

بله. Aspose.Slides به شما امکان می‌دهد اسلایدهای منفرد را از ارائه‌های PowerPoint و OpenDocument به‌صورت جداگانه به تصاویر TIFF تبدیل کنید.

**آیا محدودیتی برای تعداد اسلایدها هنگام تبدیل یک ارائه به TIFF وجود دارد؟**

خیر، Aspose.Slides هیچ محدودیتی برای تعداد اسلایدها اعمال نمی‌کند. می‌توانید ارائه‌های با هر اندازه‌ای را به فرمت TIFF تبدیل کنید.

**آیا انیمیشن‌ها و افکت‌های انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟**

خیر، TIFF یک فرمت تصویر ثابت است. بنابراین، انیمیشن‌ها و افکت‌های انتقال حفظ نمی‌شوند؛ فقط تصویرهای ثابت از اسلایدها صادر می‌شوند.