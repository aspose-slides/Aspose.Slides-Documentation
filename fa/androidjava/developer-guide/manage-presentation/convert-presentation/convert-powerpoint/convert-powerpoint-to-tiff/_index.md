---
title: تبدیل ارائه‌های پاورپوینت به TIFF در اندروید
titlelink: پاورپوینت به TIFF
type: docs
weight: 90
url: /fa/androidjava/convert-powerpoint-to-tiff/
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
- خروجی PPT به TIFF
- خروجی PPTX به TIFF
- اندروید
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه به سادگی ارائه‌های پاورپوینت (PPT, PPTX) را به تصاویر TIFF کیفیت بالا تبدیل کنید با استفاده از Aspose.Slides برای اندروید، همراه با مثال‌های کد جاوا."
---
## **مقدمه**

TIFF (**Tagged Image File Format**) یک فرمت تصویر رستر بدون افت کیفیت است که به دلیل کیفیت استثنایی و حفظ جزئیات گرافیک‌ها به‌صورت گسترده‌ای مورد استفاده قرار می‌گیرد. طراحان، عکاسان و ناشران دسکتاپ معمولاً برای حفظ لایه‌ها، دقت رنگ و تنظیمات اصلی تصاویر خود، TIFF را انتخاب می‌کنند.

با استفاده از Aspose.Slides می‌توانید اسلایدهای PowerPoint (PPT, PPTX) و اسلایدهای OpenDocument (ODP) را به‌سرعت به تصاویر TIFF با کیفیت بالا تبدیل کنید و اطمینان حاصل کنید که ارائه‌های شما حداکثر وفاداری بصری را حفظ می‌کند. 

## **تبدیل ارائه به TIFF**

با استفاده از روش [save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ارائه می‌شود، می‌توانید یک ارائه PowerPoint را به سرعت به TIFF تبدیل کنید. تصاویر TIFF ایجاد شده متناسب با اندازه پیش‌فرض اسلاید خواهند بود.

این کد نحوه تبدیل یک ارائه PowerPoint به TIFF را نشان می‌دهد:

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
Presentation presentation = new Presentation("presentation.pptx");
try {
    // ذخیرهٔ ارائه به صورت TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **تبدیل ارائه به TIFF سیاه و سفید**

متد [setBwConversionMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/) امکان تعیین الگوریتم مورد استفاده هنگام تبدیل یک اسلاید یا تصویر رنگی به TIFF سیاه و سفید را فراهم می‌کند. توجه داشته باشید که این تنظیم فقط زمانی اعمال می‌شود که متد [setCompressionType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) بر روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

فرض کنید فایلی به نام «sample.pptx» داریم که شامل اسلاید زیر است:

![یک اسلاید ارائه](slide_black_and_white.png)

این کد نحوه تبدیل اسلاید رنگی به TIFF سیاه و سفید را نشان می‌دهد:

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

![TIFF سیاه و سفید](TIFF_black_and_white.png)

## **تبدیل ارائه به TIFF با اندازه سفارشی**

اگر به تصویر TIFF با ابعاد خاصی نیاز دارید، می‌توانید مقادیر مورد نظر خود را با استفاده از متدهای موجود در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/) تنظیم کنید. به‌عنوان مثال، متد [setImageSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) به شما امکان تعریف اندازه تصویر خروجی را می‌دهد.

این کد نحوه تبدیل یک ارائه PowerPoint به تصاویر TIFF با اندازه سفارشی را نشان می‌دهد:

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
        Default - طرح فشرده‌سازی پیش‌فرض (LZW) را مشخص می‌کند.
        None - هیچ فشرده‌سازی‌ای انجام نمی‌شود.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // عمق به نوع فشرده‌سازی بستگی دارد و نمی‌تواند به صورت دستی تنظیم شود.

    // تنظیم DPI تصویر.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // تنظیم اندازه تصویر.
    tiffOptions.setImageSize(new Size(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // ذخیرهٔ ارائه به صورت TIFF با اندازهٔ مشخص شده.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **تبدیل ارائه به TIFF با قالب پیکسل تصویر سفارشی**

با استفاده از متد [setPixelFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) از کلاس [TiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/) می‌توانید قالب پیکسل دلخواه خود را برای تصویر TIFF تولید شده مشخص کنید.

این کد نحوه تبدیل یک ارائه PowerPoint به تصویر TIFF با قالب پیکسل سفارشی را نشان می‌دهد:

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat شامل مقادیر زیر است (همان‌طور که در مستندات ذکر شده است):
        Format1bppIndexed - 1 بیت برای هر پیکسل، اندیس‌دار.
        Format4bppIndexed - 4 بیت برای هر پیکسل، اندیس‌دار.
        Format8bppIndexed - 8 بیت برای هر پیکسل، اندیس‌دار.
        Format24bppRgb    - 24 بیت برای هر پیکسل، RGB.
        Format32bppArgb   - 32 بیت برای هر پیکسل، ARGB.
    */
    
    // ذخیرهٔ ارائه به صورت TIFF با قالب پیکسل مشخص شده.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
به مبدل رایگان PowerPoint به پوستر Aspose نگاهی بیندازید: [مبدل رایگان PowerPoint به پوستر](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **سوالات متداول**

### آیا می‌توانم یک اسلاید جداگانه را به جای تمام ارائه به TIFF تبدیل کنم؟

بله. Aspose.Slides به شما امکان می‌دهد اسلایدهای فردی از ارائه‌های PowerPoint و OpenDocument را به‌صورت جداگانه به تصاویر TIFF تبدیل کنید.

### آیا محدودیتی برای تعداد اسلایدها هنگام تبدیل یک ارائه به TIFF وجود دارد؟

خیر، Aspose.Slides هیچ محدودیتی برای تعداد اسلایدها اعمال نمی‌کند. می‌توانید ارائه‌های با هر اندازه‌ای را به فرمت TIFF تبدیل کنید.

### آیا انیمیشن‌ها و افکت‌های انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟

خیر، TIFF یک فرمت تصویر ثابت است. بنابراین انیمیشن‌ها و افکت‌های انتقال حفظ نمی‌شوند؛ فقط تصاویر ثابت از اسلایدها استخراج می‌شود.