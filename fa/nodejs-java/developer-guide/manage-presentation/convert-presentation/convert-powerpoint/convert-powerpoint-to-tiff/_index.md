---
title: تبدیل ارائه‌های PowerPoint به TIFF در جاوااسکریپت
titlelink: PowerPoint به TIFF
type: docs
weight: 90
url: /fa/nodejs-java/convert-powerpoint-to-tiff/
keywords:
- تبدیل پاورپوینت
- تبدیل OpenDocument
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- پاورپوینت به TIFF
- ارائه به TIFF
- اسلاید به TIFF
- PPT به TIFF
- PPTX به TIFF
- ذخیره PPT به عنوان TIFF
- ذخیره PPTX به عنوان TIFF
- صادر کردن PPT به TIFF
- صادر کردن PPTX به TIFF
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "یاد بگیرید چگونه به سادگی ارائه‌های PowerPoint (PPT، PPTX) را به تصاویر TIFF با کیفیت بالا تبدیل کنید با استفاده از Aspose.Slides برای Node.js، با مثال‌های کد جاوااسکریپت."
---
## **معرفی**

TIFF (**Tagged Image File Format**) یک قالب تصویر رستر بدون افت کیفیت است که به دلیل کیفیت استثنایی و حفظ جزئیات گرافیک به‌طور گسترده‌ای استفاده می‌شود. طراحان، عکاسان و ناشران دسکتاپ اغلب برای حفظ لایه‌ها، دقت رنگ و تنظیمات اصلی در تصاویر خود، TIFF را انتخاب می‌کنند.

با استفاده از Aspose.Slides، می‌توانید به راحتی اسلایدهای PowerPoint (PPT, PPTX) و اسلایدهای OpenDocument (ODP) را به‌صورت مستقیم به تصاویر TIFF با کیفیت بالا تبدیل کنید و اطمینان حاصل کنید که ارائه‌های شما حداکثر وفاداری بصری را حفظ می‌کنند.

## **تبدیل یک ارائه به TIFF**

با استفاده از متد [save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) ارائه‌شده توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/)، می‌توانید به سرعت یک ارائه کامل PowerPoint را به TIFF تبدیل کنید. تصاویر TIFF حاصل مطابق با اندازه پیش‌فرض اسلاید هستند.

این کد JavaScript نشان می‌دهد چگونه یک ارائه PowerPoint را به TIFF تبدیل کنید:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// نمونه‌سازی کلاس Presentation که نمایانگر فایل ارائه (PPT، PPTX، ODP و غیره) است.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // ذخیره ارائه به صورت TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **تبدیل یک ارائه به TIFF سیاه‌وسفید**

متد [setBwConversionMode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/) به شما امکان می‌دهد الگوریتم مورد استفاده هنگام تبدیل اسلاید یا تصویر رنگی به TIFF سیاه‌وسفید را تعیین کنید. توجه داشته باشید که این تنظیم فقط زمانی اعمال می‌شود که متد [setCompressionType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) بر روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

{{% alert color="info" title="توجه" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) یک تنظیم سطح خروجی است که الگوریتم تبدیل پیکسل برای کل تصویر TIFF را انتخاب می‌کند. برای تعیین نحوه نمایش یک شکل به‌صورت سیاه‌وسفید هنگامی که حالت نمایش سیاه‌وسفید فعال است، از [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) استفاده کنید. برای مثال‌ها به [Control Black-and-White Rendering for Shapes](/slides/fa/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes) مراجعه نمایید.
{{% /alert %}}

فرض کنید فایلی به‌نام "sample.pptx" داریم که شامل اسلاید زیر است:

![یک اسلاید ارائه](slide_black_and_white.png)

این کد JavaScript نشان می‌دهد چگونه اسلاید رنگی را به TIFF سیاه‌وسفید تبدیل کنیم:

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

![TIFF سیاه‌وسفید](TIFF_black_and_white.png)

## **تبدیل یک ارائه به TIFF با اندازه سفارشی**

اگر به یک تصویر TIFF با ابعاد خاص نیاز دارید، می‌توانید مقادیر دلخواه خود را با استفاده از متدهای موجود در [TiffOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/) تنظیم کنید. برای مثال، متد [setImageSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/#setImageSize) به شما امکان می‌دهد اندازه تصویر حاصل را تعیین کنید.

این کد JavaScript نشان می‌دهد چگونه یک ارائه PowerPoint را به تصاویر TIFF با اندازه سفارشی تبدیل کنید:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// نمونه‌سازی کلاس Presentation که نمایانگر فایل ارائه (PPT، PPTX، ODP و غیره) است.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // تنظیم نوع فشرده‌سازی.
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

    // عمق رنگ توسط قالب پیکسل کنترل می‌شود (مثال زیر را ببینید)؛ CCITT3 و CCITT4 همیشه ۱ بیت در هر پیکسل تولید می‌کنند.

    // تنظیم DPI تصویر.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // تنظیم اندازه تصویر.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // ذخیره ارائه به صورت TIFF با اندازه مشخص شده.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **تبدیل یک ارائه به TIFF با قالب پیکسل تصویر سفارشی**

با استفاده از متد [setPixelFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) از کلاس [TiffOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/)، می‌توانید قالب پیکسل مورد نظر خود را برای تصویر TIFF حاصل مشخص کنید.

این کد JavaScript نشان می‌دهد چگونه یک ارائه PowerPoint را به تصویر TIFF با قالب پیکسل سفارشی تبدیل کنید:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// نمونه‌سازی کلاس Presentation که نمایانگر فایل ارائه (PPT، PPTX، ODP و غیره) است.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat شامل مقادیر زیر است (طبق مستندات):
        Format1bppIndexed - 1 بیت در هر پیکسل، فهرست‌شده.
        Format4bppIndexed - 4 بیت در هر پیکسل، فهرست‌شده.
        Format8bppIndexed - 8 بیت در هر پیکسل، فهرست‌شده.
        Format24bppRgb    - 24 بیت در هر پیکسل، RGB.
        Format32bppArgb   - 32 بیت در هر پیکسل، ARGB.
    */

    /// ذخیره ارائه به صورت TIFF با اندازه تصویر مشخص شده.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="نکته" color="info" %}}
به مبدل [رایگان PowerPoint به پوستر](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online) از Aspose نگاهی بیندازید.
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم یک اسلاید منفرد به‌جای کل ارائه PowerPoint را به TIFF تبدیل کنم؟**

بله. Aspose.Slides به شما امکان می‌دهد اسلایدهای منفرد از ارائه‌های PowerPoint و OpenDocument را به‌صورت جداگانه به تصویرهای TIFF تبدیل کنید.

**آیا محدودیتی برای تعداد اسلایدها هنگام تبدیل یک ارائه به TIFF وجود دارد؟**

خیر، Aspose.Slides هیچ محدودیتی برای تعداد اسلایدها اعمال نمی‌کند. می‌توانید هر اندازه‌ای از ارائه‌ها را به فرمت TIFF تبدیل کنید.

**آیا انیمیشن‌ها و افکت‌های انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟**

خیر، TIFF یک فرمت تصویر ثابت است. بنابراین، انیمیشن‌ها و افکت‌های انتقال حفظ نمی‌شوند؛ تنها تصاویر ثابت از اسلایدها صادر می‌شوند.