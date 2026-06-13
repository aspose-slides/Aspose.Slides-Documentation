---
title: تبدیل ارائه‌های PowerPoint به TIFF در JavaScript
titlelink: PowerPoint به TIFF
type: docs
weight: 90
url: /fa/nodejs-java/convert-powerpoint-to-tiff/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه به‌راحتی ارائه‌های PowerPoint (PPT، PPTX) را به تصاویر TIFF با کیفیت بالا با استفاده از Aspose.Slides برای Node.js و مثال‌های کد JavaScript تبدیل کنید."
---
## **مقدمه**

TIFF (**Tagged Image File Format**) یک قالب تصویر نقطه‌ای بدون افت کیفیت است که به‌دلیل کیفیت استثنایی و حفظ جزئیات گرافیک‌ها شناخته شده است. طراحان، عکاسان و ناشران دسکتاپ غالباً برای حفظ لایه‌ها، دقت رنگ و تنظیمات اصلی در تصاویر خود از TIFF استفاده می‌کنند.

با استفاده از Aspose.Slides می‌توانید به‌راحتی اسلایدهای PowerPoint (PPT، PPTX) و اسلایدهای OpenDocument (ODP) را به‌صورت مستقیم به تصاویر TIFF با کیفیت بالا تبدیل کنید و اطمینان حاصل کنید که ارائه‌های شما حداکثر وفاداری بصری را حفظ می‌کنند.

## **تبدیل یک ارائه به TIFF**

با استفاده از متد [save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ارائه می‌شود، می‌توانید به سرعت یک ارائه PowerPoint کامل را به TIFF تبدیل کنید. تصاویر TIFF تولید شده متناسب با اندازه پیش‌فرض اسلاید می‌باشند.

این کد JavaScript نشان می‌دهد که چگونه یک ارائه PowerPoint را به TIFF تبدیل کنید:

```js
// نمونه‌سازی کلاس Presentation که یک فایل ارائه (PPT، PPTX، ODP و غیره) را نشان می‌دهد.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // ارائه را به‌صورت TIFF ذخیره کنید.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **تبدیل یک ارائه به TIFF سیاه‌سفید**

متد [setBwConversionMode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/) به شما امکان می‌دهد الگوریتم مورد استفاده هنگام تبدیل اسلاید یا تصویر رنگی به TIFF سیاه‌سفید را مشخص کنید. توجه داشته باشید که این تنظیم فقط زمانی اعمال می‌شود که متد [setCompressionType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) بر روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

فرض کنید یک فایل "sample.pptx" با اسلاید زیر داریم:

![یک اسلاید ارائه](slide_black_and_white.png)

این کد JavaScript نشان می‌دهد که چگونه اسلاید رنگی را به TIFF سیاه‌سفید تبدیل کنید:

```js
let tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(aspose.slides.BlackWhiteConversionMode.Dithering);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

نتیجه:

![TIFF سیاه‌سفید](TIFF_black_and_white.png)

## **تبدیل یک ارائه به TIFF با اندازه سفارشی**

اگر به تصویری TIFF با ابعاد خاص نیاز دارید، می‌توانید مقادیر دلخواه خود را با استفاده از متدهای موجود در [TiffOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/) تنظیم کنید. به‌عنوان مثال، متد [setImageSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/#setImageSize) به شما امکان می‌دهد اندازه تصویر خروجی را تعریف کنید.

این کد JavaScript نشان می‌دهد که چگونه یک ارائه PowerPoint را به تصاویر TIFF با اندازه سفارشی تبدیل کنید:

```js
// نمونه‌سازی کلاس Presentation که یک فایل ارائه (PPT، PPTX، ODP و غیره) را نشان می‌دهد.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // تنظیم نوع فشرده‌سازی.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    انواع فشرده‌سازی:
        Default - مشخص می‌کند طرح فشرده‌سازی پیش‌فرض (LZW).
        None - مشخص می‌کند بدون فشرده‌سازی.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // عمق بسته به نوع فشرده‌سازی است و نمی‌تواند به‌صورت دستی تنظیم شود.

    // تنظیم DPI تصویر.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // تنظیم اندازه تصویر.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // ذخیرهٔ ارائه به صورت TIFF با اندازهٔ مشخص.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **تبدیل یک ارائه به TIFF با فرمت پیکسل تصویر سفارشی**

با استفاده از متد [setPixelFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) از کلاس [TiffOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/) می‌توانید فرمت پیکسل دلخواه خود را برای تصویر TIFF تولید شده مشخص کنید.

این کد JavaScript نشان می‌دهد که چگونه یک ارائه PowerPoint را به تصویر TIFF با فرمت پیکسل سفارشی تبدیل کنید:

```js
// نمونه‌سازی کلاس Presentation که یک فایل ارائه (PPT، PPTX، ODP و غیره) را نشان می‌دهد.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat شامل مقادیر زیر است (همان‌طور که در مستندات آمده):
        Format1bppIndexed - 1 بیت در هر پیکسل، نشان‌گذاری شده.
        Format4bppIndexed - 4 بیت در هر پیکسل، نشان‌گذاری شده.
        Format8bppIndexed - 8 بیت در هر پیکسل، نشان‌گذاری شده.
        Format24bppRgb    - 24 بیت در هر پیکسل، RGB.
        Format32bppArgb   - 32 بیت در هر پیکسل، ARGB.
    */

    /// ارائه را به‌صورت TIFF با اندازه تصویر مشخص ذخیره کنید.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
به مبدل [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online) Aspose مراجعه کنید.
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم یک اسلاید منفرد را به جای کل ارائه PowerPoint به TIFF تبدیل کنم؟**

بله. Aspose.Slides به شما امکان می‌دهد اسلایدهای منفرد را از ارائه‌های PowerPoint و OpenDocument به‌صورت جداگانه به تصاویر TIFF تبدیل کنید.

**آیا محدودیتی برای تعداد اسلایدها هنگام تبدیل یک ارائه به TIFF وجود دارد؟**

خیر، Aspose.Slides هیچ محدودیتی برای تعداد اسلایدها اعمال نمی‌کند. می‌توانید ارائه‌های با هر اندازه‌ای را به فرمت TIFF تبدیل کنید.

**آیا انیمیشن‌ها و افکت‌های انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟**

خیر، TIFF یک فرمت تصویر ثابت است. بنابراین، انیمیشن‌ها و افکت‌های انتقال حفظ نمی‌شوند؛ فقط تصاویر ثابت از اسلایدها صادر می‌شوند.