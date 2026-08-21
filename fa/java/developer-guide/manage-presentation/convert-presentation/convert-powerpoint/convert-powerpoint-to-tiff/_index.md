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
- صادرات PPT به TIFF
- صادرات PPTX به TIFF
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه به راحتی ارائه‌های PowerPoint (PPT، PPTX) را به تصاویر TIFF با کیفیت بالا با استفاده از Aspose.Slides برای Java تبدیل کنید، همراه با مثال‌های کد."
---
## **معرفی**

TIFF (**Tagged Image File Format**) یک قالب تصویر رستر بدون‌فقدان که به طور وسیعی استفاده می‌شود و به‌دلیل کیفیت استثنایی و حفظ جزئیات گرافیک شناخته شده است. طراحان، عکاسان و ناشران دسکتاپ اغلب برای حفظ لایه‌ها، دقت رنگ و تنظیمات اصلی در تصاویر خود، TIFF را انتخاب می‌کنند.

با استفاده از Aspose.Slides می‌توانید به‌سادگی اسلایدهای PowerPoint (PPT، PPTX) و اسلایدهای OpenDocument (ODP) را به‌صورت مستقیم به تصاویر TIFF با کیفیت بالا تبدیل کنید و اطمینان حاصل کنید که ارائه‌های شما حداکثر وضوح بصری را حفظ می‌کنند.

## **تبدیل ارائه به TIFF**

با استفاده از متد [save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ارائه‌شده توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) می‌توانید به‌سرعت یک ارائه کامل PowerPoint را به TIFF تبدیل کنید. تصاویر TIFF تولید شده متناظر با اندازه پیش‌فرض اسلاید هستند.

این کد نحوه تبدیل یک ارائه PowerPoint به TIFF را نشان می‌دهد:

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نشانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
Presentation presentation = new Presentation("presentation.pptx");
try {
    // ذخیرهٔ ارائه به عنوان TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **تبدیل ارائه به TIFF سیاه‌وسفید**

متد [setBwConversionMode](httpshttps://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/) به شما امکان می‌دهد الگوریتم مورد استفاده هنگام تبدیل یک اسلاید یا تصویر رنگی به TIFF سیاه‌وسفید را مشخص کنید. توجه داشته باشید که این تنظیم فقط زمانی اعمال می‌شود که متد [setCompressionType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) بر روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) یک تنظیم سطح خروجی است که الگوریتم تبدیل پیکسل برای تصویر کامل TIFF را انتخاب می‌کند. برای تعریف نحوه نمایش یک شکل منفرد هنگامی که حالت نمایش سیاه‌وسفید فعال است، از [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) استفاده کنید. برای مثال‌ها به [Control Black-and-White Rendering for Shapes](/java/shape-formatting/#control-black-and-white-rendering-for-shapes) مراجعه کنید.
{{% /alert %}}

فرض کنید فایلی به نام "sample.pptx" با اسلاید زیر داریم:

![یک اسلاید ارائه](slide_black_and_white.png)

این کد نحوه تبدیل اسلاید رنگی به TIFF سیاه‌وسفید را نشان می‌دهد:

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

![TIFF سیاه‌وسفید](TIFF_black_and_white.png)

## **تبدیل ارائه به TIFF با اندازه سفارشی**

اگر به تصویر TIFF با ابعاد خاص نیاز دارید، می‌توانید مقادیر دلخواه خود را با استفاده از متدهای موجود در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/) تنظیم کنید. به‌ عنوان مثال، متد [setImageSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) به شما امکان می‌دهد اندازه تصویر خروجی را تعریف کنید.

این کد نحوه تبدیل یک ارائه PowerPoint به تصاویر TIFF با اندازه سفارشی را نشان می‌دهد:

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
        Default - مشخص می‌کند طرح فشرده‌سازی پیش‌فرض (LZW).
        None - مشخص می‌کند هیچ فشرده‌سازی نیست.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // عمق بستگی به نوع فشرده‌سازی دارد و نمی‌توان آن را به‌صورت دستی تنظیم کرد.

    // تنظیم DPI تصویر.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // تنظیم اندازه تصویر.
    tiffOptions.setImageSize(new Dimension(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // ذخیرهٔ ارائه به صورت TIFF با اندازهٔ مشخص شده.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **تبدیل ارائه به TIFF با فرمت پیکسل تصویر سفارشی**

با استفاده از متد [setPixelFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) از کلاس [TiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/) می‌توانید فرمت پیکسل دلخواه خود را برای تصویر TIFF تولید شده مشخص کنید.

این کد نحوه تبدیل یک ارائه PowerPoint به تصویر TIFF با فرمت پیکسل سفارشی را نشان می‌دهد:

```java
import com.aspose.slides.*;

// ایجاد نمونه از کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat شامل مقادیر زیر است (طبق مستندات):
        Format1bppIndexed - 1 بیت به ازای هر پیکسل، شاخص‌گذاری شده.
        Format4bppIndexed - 4 بیت به ازای هر پیکسل، شاخص‌گذاری شده.
        Format8bppIndexed - 8 بیت به ازای هر پیکسل، شاخص‌گذاری شده.
        Format24bppRgb    - 24 بیت به ازای هر پیکسل، RGB.
        Format32bppArgb   - 32 بیت به ازای هر پیکسل، ARGB.
    */
    
    // ذخیرهٔ ارائه به صورت TIFF با فرمت پیکسل مشخص شده.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
[مبدل رایگان PowerPoint به پوستر](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online)
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم یک اسلاید منفرد را به‌جای کل ارائه PowerPoint به TIFF تبدیل کنم؟**

بله. Aspose.Slides به شما امکان می‌دهد اسلایدهای منفرد از ارائه‌های PowerPoint و OpenDocument را به‌صورت جداگانه به تصاویر TIFF تبدیل کنید.

**آیا محدودیتی برای تعداد اسلایدها هنگام تبدیل یک ارائه به TIFF وجود دارد؟**

خیر، Aspose.Slides هیچ محدودیتی برای تعداد اسلایدها اعمال نمی‌کند. می‌توانید ارائه‌های با هر اندازه‌ای را به فرمت TIFF تبدیل کنید.

**آیا انیمیشن‌ها و افکت‌های انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟**

خیر، TIFF یک قالب تصویر ثابت است. بنابراین انیمیشن‌ها و افکت‌های انتقال حفظ نمی‌شوند؛ فقط تصویرهای ایستای اسلایدها صادر می‌شوند.