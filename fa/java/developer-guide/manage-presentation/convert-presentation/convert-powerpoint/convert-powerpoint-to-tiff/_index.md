---
title: تبدیل ارائه‌های PowerPoint به TIFF در Java
titlelink: PowerPoint به TIFF
type: docs
weight: 90
url: /fa/java/convert-powerpoint-to-tiff/
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
- صادر کردن PPT به TIFF
- صادر کردن PPTX به TIFF
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه به‌سادگی ارائه‌های PowerPoint (PPT، PPTX) را به تصاویر TIFF با کیفیت بالا با استفاده از Aspose.Slides برای Java تبدیل کنید، همراه با مثال‌های کد."
---
## **مقدمه**

TIFF (**Tagged Image File Format**) یک فرمت تصویر رستری بدون‌손실 است که به‌دلیل کیفیت بالا و حفظ جزئیات گرافیک شناخته شده است. طراحان، عکاسان و ناشران دسکتاپ اغلب برای نگهداری لایه‌ها، دقت رنگ و تنظیمات اصلی تصاویر از TIFF استفاده می‌کنند.

با استفاده از Aspose.Slides می‌توانید اسلایدهای PowerPoint (PPT، PPTX) و اسلایدهای OpenDocument (ODP) را به‌صورت مستقیم به تصاویر TIFF با کیفیت بالا تبدیل کنید و اطمینان حاصل کنید که ارائه‌های شما حداکثر وفاداری بصری را حفظ می‌کند.

## **تبدیل یک ارائه به TIFF**

با استفاده از روش [save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ارائه‌شده توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) می‌توانید به‌سرعت تمام ارائه PowerPoint را به TIFF تبدیل کنید. تصاویر TIFF تولید شده با اندازه پیش‌فرض اسلاید مطابقت دارند.

این کد نحوه تبدیل یک ارائه PowerPoint به TIFF را نشان می‌دهد:

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
Presentation presentation = new Presentation("presentation.pptx");
try {
    // ذخیرهٔ ارائه به عنوان TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **تبدیل یک ارائه به TIFF سیاه‑سفید**

متد [setBwConversionMode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/) به شما امکان می‌دهد الگوریتم مورد استفاده هنگام تبدیل اسلاید یا تصویر رنگی به TIFF سیاه‑سفید را مشخص کنید. توجه داشته باشید این تنظیم فقط زمانی اعمال می‌شود که متد [setCompressionType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) یک تنظیم سطح صادراتی است که الگوریتم تبدیل پیکسل را برای کل تصویر TIFF انتخاب می‌کند. برای تعیین نحوه نمایش یک شکل منفرد هنگام فعال بودن حالت نمایش سیاه‑سفید، از [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) استفاده کنید. برای مثال‌ها به **[کنترل رندر سیاه‑سفید برای اشکال](/slides/fa/java/shape-formatting/#control-black-and-white-rendering-for-shapes)** مراجعه کنید.
{{% /alert %}}

فرض کنید فایلی به نام "sample.pptx" داریم که شامل اسلاید زیر است:

![یک اسلاید ارائه](slide_black_and_white.png)

این کد نحوه تبدیل اسلاید رنگی به TIFF سیاه‑سفید را نشان می‌دهد:

```java
import com.aspose.slides.*;

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

نتیجه:

![TIFF سیاه‑سفید](TIFF_black_and_white.png)

## **تبدیل یک ارائه به TIFF با اندازهٔ سفارشی**

اگر به تصویر TIFF با ابعاد خاصی نیاز دارید، می‌توانید مقادیر دلخواه خود را با استفاده از متدهای موجود در [TiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/) تنظیم کنید. به‌عنوان مثال، متد [setImageSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) به شما اجازه می‌دهد اندازه تصویر خروجی را تعریف کنید.

این کد نحوه تبدیل یک ارائه PowerPoint به تصاویر TIFF با اندازهٔ سفارشی را نشان می‌دهد:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // تنظیم نوع فشرده‌سازی.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    انواع فشرده‌سازی:
        پیش‌فرض - مشخص می‌کند طرح فشرده‌سازی پیش‌فرض (LZW).
        بدون - مشخص می‌کند بدون فشرده‌سازی.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // عمق بستگی به نوع فشرده‌سازی دارد و نمی‌تواند به‌صورت دستی تنظیم شود.

    // تنظیم DPI تصویر.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // تنظیم اندازه تصویر.
    tiffOptions.setImageSize(new Dimension(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // ذخیرهٔ ارائه به صورت TIFF با اندازهٔ مشخص‌شده.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **تبدیل یک ارائه به TIFF با قالب پیکسل تصویر سفارشی**

با استفاده از متد [setPixelFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/) می‌توانید قالب پیکسل دلخواه خود را برای تصویر TIFF خروجی مشخص کنید.

این کد نحوه تبدیل یک ارائه PowerPoint به تصویر TIFF با قالب پیکسل سفارشی را نشان می‌دهد:

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat شامل مقادیر زیر (طبق مستندات) است:
        Format1bppIndexed - 1 بیت در هر پیکسل، ایندکس‌دار.
        Format4bppIndexed - 4 بیت در هر پیکسل، ایندکس‌دار.
        Format8bppIndexed - 8 بیت در هر پیکسل، ایندکس‌دار.
        Format24bppRgb    - 24 بیت در هر پیکسل، RGB.
        Format32bppArgb   - 32 بیت در هر پیکسل، ARGB.
    */
    
    // ذخیرهٔ ارائه به صورت TIFF با قالب پیکسل مشخص‌شده.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
مبدل **رایگان PowerPoint به پوستر** Aspose را در این لینک مشاهده کنید: [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم به‌جای تبدیل کل ارائه PowerPoint، یک اسلاید منفرد را به TIFF تبدیل کنم؟**

بله. Aspose.Slides به شما امکان می‌دهد اسلایدهای منفرد از ارائه‌های PowerPoint و OpenDocument را به‌صورت جداگانه به تصاویر TIFF تبدیل کنید.

**آیا محدودیتی در تعداد اسلایدها هنگام تبدیل یک ارائه به TIFF وجود دارد؟**

خیر، Aspose.Slides هیچ محدودیتی برای تعداد اسلایدها اعمال نمی‌کند. می‌توانید ارائه‌های با هر اندازه‌ای را به فرمت TIFF تبدیل کنید.

**آیا انیمیشن‌ها و افکت‌های انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟**

خیر، TIFF یک فرمت تصویر ثابت است. بنابراین انیمیشن‌ها و افکت‌های انتقال ذخیره نمی‌شوند؛ فقط snapshots ثابت از اسلایدها صادر می‌شوند.