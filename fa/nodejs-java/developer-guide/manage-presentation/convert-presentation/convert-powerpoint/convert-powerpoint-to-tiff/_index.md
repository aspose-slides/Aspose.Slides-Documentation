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
- ذخیره PPT به صورت TIFF
- ذخیره PPTX به صورت TIFF
- صادر کردن PPT به TIFF
- صادر کردن PPTX به TIFF
- Node.js
- JavaScript
- Aspose.Slides
description: "چگونگی تبدیل آسان ارائه‌های PowerPoint (PPT, PPTX) به تصاویر TIFF با کیفیت بالا با استفاده از Aspose.Slides برای Node.js و نمونه‌های کد JavaScript را بیاموزید."
---
## **معرفی**

TIFF (**Tagged Image File Format**) یک فرمت تصویر رستری بدون از دست دادن داده است که به خاطر کیفیت استثنایی و حفظ جزئیات گرافیک شناخته می‌شود. طراحان، عکاسان و ناشران دسکتاپ اغلب برای حفظ لایه‌ها، دقت رنگ و تنظیمات اصلی تصاویرشان از TIFF استفاده می‌کنند.

با استفاده از Aspose.Slides می‌توانید به راحتی اسلایدهای PowerPoint (PPT, PPTX) و اسلایدهای OpenDocument (ODP) را به‌صورت مستقیم به تصاویر TIFF با کیفیت بالا تبدیل کنید تا ارائه‌های شما حداکثر شباهت بصری را حفظ کنند.

## **تبدیل ارائه به TIFF**

با استفاده از متد [save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) که در کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) موجود است، می‌توانید به سرعت یک ارائه کامل PowerPoint را به TIFF تبدیل کنید. تصاویر TIFF تولید شده مطابق با اندازه اسلاید پیش‌فرض خواهند بود.

این کد JavaScript نشان می‌دهد چگونه یک ارائه PowerPoint را به TIFF تبدیل کنیم:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// یک نمونه از کلاس Presentation که نمایانگر فایل ارائه (PPT، PPTX، ODP و غیره) است.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // ارائه را به عنوان TIFF ذخیره کنید.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **تبدیل ارائه به TIFF سیاه‑و‑سفید**

متد [setBwConversionMode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/) به شما اجازه می‌دهد الگوریتمی را که هنگام تبدیل یک اسلاید یا تصویر رنگی به TIFF سیاه‑و‑سفید استفاده می‌شود، مشخص کنید. توجه داشته باشید که این تنظیم فقط زمانی اعمال می‌شود که متد [setCompressionType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

{{% alert color="info" title="تذکر" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) یک تنظیم سطح خروجی است که الگوریتم تبدیل پیکسل را برای کل تصویر TIFF انتخاب می‌کند. برای تعیین نحوه نمایش یک شکل به‌صورت تک‌رنگ هنگام فعال بودن حالت نمایش سیاه‑و‑سفید، از [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) استفاده کنید. برای مثال‌ها به ‎[Control Black-and-White Rendering for Shapes](/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes)‎ مراجعه کنید.
{{% /alert %}}

فرض کنید فایلی به نام «sample.pptx» داریم که دارای اسلاید زیر است:

![یک اسلاید ارائه](slide_black_and_white.png)

این کد JavaScript نشان می‌دهد چگونه اسلاید رنگی را به TIFF سیاه‑و‑سفید تبدیل کنیم:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

![TIFF سیاه‑و‑سفید](TIFF_black_and_white.png)

## **تبدیل ارائه به TIFF با اندازه سفارشی**

اگر به تصویر TIFF با ابعاد خاصی نیاز دارید، می‌توانید مقادیر دلخواه خود را با استفاده از متدهای موجود در [TiffOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/) تنظیم کنید. به‌عنوان مثال، متد [setImageSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/#setImageSize) به شما امکان می‌دهد اندازه تصویر خروجی را تعریف کنید.

این کد JavaScript نشان می‌دهد چگونه یک ارائه PowerPoint را به تصاویر TIFF با اندازه سفارشی تبدیل کنیم:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// یک نمونه از کلاس Presentation که نمایانگر فایل ارائه (PPT، PPTX، ODP و غیره) است.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // نوع فشرده‌سازی را تنظیم کنید.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    انواع فشرده‌سازی:
        Default - طرح فشرده‌سازی پیش‌فرض (LZW) را مشخص می‌کند.
        None - عدم فشرده‌سازی را مشخص می‌کند.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // عمق رنگ توسط فرمت پیکسل کنترل می‌شود (به مثال زیر مراجعه کنید)؛ CCITT3 و CCITT4 همیشه 1 بیت در هر پیکسل تولید می‌کنند.

    // DPI تصویر را تنظیم کنید.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // اندازه تصویر را تنظیم کنید.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // ارائه را به عنوان TIFF با اندازه مشخص ذخیره کنید.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **تبدیل ارائه به TIFF با فرمت پیکسل تصویر سفارشی**

با استفاده از متد [setPixelFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) از کلاس [TiffOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/) می‌توانید فرمت پیکسل دلخواه خود را برای تصویر TIFF خروجی مشخص کنید.

این کد JavaScript نشان می‌دهد چگونه یک ارائه PowerPoint را به تصویر TIFF با فرمت پیکسل سفارشی تبدیل کنیم:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// یک نمونه از کلاس Presentation که نمایانگر فایل ارائه (PPT، PPTX، ODP و غیره) است.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat مقادیر زیر را شامل می‌شود (همان‌طور که در مستندات آمده است):
        Format1bppIndexed - 1 بیت در هر پیکسل، اندیس‌دار.
        Format4bppIndexed - 4 بیت در هر پیکسل، اندیس‌دار.
        Format8bppIndexed - 8 بیت در هر پیکسل، اندیس‌دار.
        Format24bppRgb    - 24 بیت در هر پیکسل، RGB.
        Format32bppArgb   - 32 بیت در هر پیکسل، ARGB.
    */

    /// ارائه را به عنوان TIFF با اندازه تصویر مشخص ذخیره کنید.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="نکته" color="info" %}}
به ابزار ‎[FREE PowerPoint to Poster converter](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online)‎ رایگان Aspose نگاهی بیندازید.
{{% /alert %}}

## **سؤالات متداول**

**آیا می‌توانم به‌جای تبدیل تمام ارائه به TIFF، فقط یک اسلاید را تبدیل کنم؟**

بله. Aspose.Slides به شما اجازه می‌دهد اسلایدهای فردی از ارائه‌های PowerPoint و OpenDocument را به‌صورت جداگانه به تصاویر TIFF تبدیل کنید.

**آیا در تبدیل یک ارائه به TIFF محدودیتی برای تعداد اسلایدها وجود دارد؟**

خیر، Aspose.Slides هیچ محدودیتی برای تعداد اسلایدها اعمال نمی‌کند. می‌توانید ارائه‌های هر اندازه‌ای را به فرمت TIFF تبدیل کنید.

**آیا انیمیشن‌ها و افکت‌های انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟**

خیر، TIFF یک فرمت تصویر ثابت است. بنابراین انیمیشن‌ها و افکت‌های انتقال حفظ نمی‌شوند؛ فقط تصاویری ثابت از اسلایدها صادر می‌شوند.