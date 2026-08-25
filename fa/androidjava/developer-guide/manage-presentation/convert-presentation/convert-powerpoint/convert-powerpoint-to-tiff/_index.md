---
title: تبدیل ارائه‌های PowerPoint به TIFF در Android
titlelink: PowerPoint به TIFF
type: docs
weight: 90
url: /fa/androidjava/convert-powerpoint-to-tiff/
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
- صدور PPT به TIFF
- صدور PPTX به TIFF
- Android
- Java
- Aspose.Slides
description: یاد بگیرید چگونه به راحتی ارائه‌های PowerPoint (PPT، PPTX) را به تصاویر TIFF با کیفیت بالا با استفاده از Aspose.Slides برای Android، با مثال‌های کد Java تبدیل کنید.
---
## **مقدمه**

TIFF (**Tagged Image File Format**) یک فرمت تصویر رستر با‑فشاری است که به‌ دلیل کیفیت استثنایی و حفظ جزئیات گرافیک‌ها به‌ صورت بی‌نقص، به‌ طور گسترده‌ای استفاده می‌شود. طراحان، عکاسان و ناشران دسکتاپ اغلب برای نگهداری لایه‌ها، دقت رنگ و تنظیمات اصلی تصاویر خود، از TIFF استفاده می­ کنند.

با استفاده از Aspose.Slides، می‌توانید اسلایدهای PowerPoint (PPT، PPTX) و اسلایدهای OpenDocument (ODP) را به‌ راحتی مستقیماً به تصاویر TIFF با کیفیت بالا تبدیل کنید و اطمینان حاصل کنید ارائه‌های شما حداکثر وفاداری بصری را حفظ می‌کنند.

## **تبدیل ارائه به TIFF**

با استفاده از متد [save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ارائه می‌شود، می‌توانید به سرعت یک ارائه PowerPoint کامل را به TIFF تبدیل کنید. تصاویر TIFF تولید شده با اندازه پیش‌فرض اسلاید مطابقت دارند.

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را به TIFF تبدیل کنید:

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
Presentation presentation = new Presentation("presentation.pptx");
try {
    // ذخیره ارائه به صورت TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **تبدیل ارائه به TIFF سیاه‑سفید**

متد [setBwConversionMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/) به شما امکان می‌دهد الگوریتم مورد استفاده هنگام تبدیل یک اسلاید یا تصویر رنگی به TIFF سیاه‑سفید را تعیین کنید. توجه داشته باشید که این تنظیم فقط زمانی اعمال می‌شود که متد [setCompressionType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) یک تنظیم سطح خروجی است که الگوریتم تبدیل پیکسل برای کل تصویر TIFF را انتخاب می‌کند. برای تعریف نحوه نمایش یک شکل منفرد زمانی که حالت نمایش سیاه‑سفید فعال است، از [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) استفاده کنید. برای مثال‌ها به [Control Black-and-White Rendering for Shapes](/slides/fa/androidjava/shape-formatting/#control-black-and-white-rendering-for-shapes) مراجعه کنید.
{{% /alert %}}

فرض کنید فایلی به نام "sample.pptx" با اسلاید زیر داشته باشیم:

![یک اسلاید ارائه](slide_black_and_white.png)

این کد نشان می‌دهد چگونه اسلاید رنگی را به TIFF سیاه‑سفید تبدیل کنید:

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

## **تبدیل ارائه به TIFF با اندازهٔ سفارشی**

اگر به تصویر TIFF با ابعاد خاصی نیاز دارید، می‌توانید مقادیر دلخواه خود را با استفاده از متدهای موجود در [TiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/) تنظیم کنید. به‌ عنوان مثال، متد [setImageSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) به شما امکان می‌دهد اندازهٔ تصویر خروجی را تعیین کنید.

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را به تصاویر TIFF با اندازهٔ سفارشی تبدیل کنید:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // تنظیم نوع فشرده‌سازی.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    انواع فشرده‌سازی:
        Default - طرح فشرده‌سازی پیش‌فرض را مشخص می‌کند (LZW).
        None - عدم فشرده‌سازی را مشخص می‌کند.
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
    tiffOptions.setImageSize(new Size(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // ذخیره ارائه به صورت TIFF با اندازه مشخص‌شده.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **تبدیل ارائه به TIFF با فرمت پیکسل سفارشی تصویر**

با استفاده از متد [setPixelFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) از کلاس [TiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/) می‌توانید فرمت پیکسل دلخواه خود را برای تصویر TIFF خروجی مشخص کنید.

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را به تصویر TIFF با فرمت پیکسل سفارشی تبدیل کنید:

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat مقادیر زیر را شامل می‌شود (طبق مستندات):
        Format1bppIndexed - ۱ بیت در هر پیکسل، نمایه‌گذاری شده.
        Format4bppIndexed - ۴ بیت در هر پیکسل، نمایه‌گذاری شده.
        Format8bppIndexed - ۸ بیت در هر پیکسل، نمایه‌گذاری شده.
        Format24bppRgb    - ۲۴ بیت در هر پیکسل، RGB.
        Format32bppArgb   - ۳۲ بیت در هر پیکسل، ARGB.
    */
    
    // ذخیره ارائه به صورت TIFF با فرمت پیکسل مشخص‌شده.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
به [مبدل رایگان PowerPoint به پوستر Aspose](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online) مراجعه کنید.
{{% /alert %}}

## **سؤالات متداول**

**آیا می‌توانم یک اسلاید تک‌تکه را به‌ جای تبدیل کل ارائه PowerPoint به TIFF تبدیل کنم؟**

بله. Aspose.Slides به شما امکان می‌دهد اسلایدهای جداگانه را از ارائه‌های PowerPoint و OpenDocument به‌ طور مستقل به تصاویر TIFF تبدیل کنید.

**آیا محدودیتی برای تعداد اسلایدها هنگام تبدیل یک ارائه به TIFF وجود دارد؟**

خیر، Aspose.Slides محدودیتی برای تعداد اسلایدها اعمال نمی‌کند. می‌توانید هر اندازه‌ای از ارائه‌ها را به فرمت TIFF تبدیل کنید.

**آیا انیمیشن‌ها و افکت‌های انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟**

خیر، TIFF یک قالب تصویر ثابت است. بنابراین انیمیشن‌ها و افکت‌های انتقال حفظ نمی‌شوند؛ فقط تصویرهای ثابت از اسلایدها صادر می‌شوند.