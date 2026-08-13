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
description: "با استفاده از Aspose.Slides برای Java و مثال‌های کد، به‌ راحتی یاد بگیرید چگونه ارائه‌های PowerPoint (PPT، PPTX) را به تصاویر TIFF با کیفیت بالا تبدیل کنید."
---
## **معرفی**

TIFF (**Tagged Image File Format**) یک فرمت تصویر رستر بی‌ضرر و به‌ طور گسترده مورد استفاده است که به دلیل کیفیت بی‌نظیر و حفظ دقیق گرافیک‌ها شناخته شده است. طراحان، عکاسان و ناشران دسکتاپ اغلب TIFF را برای حفظ لایه‌ها، دقت رنگ و تنظیمات اصلی در تصاویر خود انتخاب می‌کنند.

با استفاده از Aspose.Slides می‌توانید به راحتی اسلایدهای PowerPoint (PPT، PPTX) و اسلایدهای OpenDocument (ODP) را به‌ طور مستقیم به تصاویر TIFF با کیفیت بالا تبدیل کنید و از حفظ حداکثر دقت بصری ارائه‌های خود اطمینان حاصل کنید. 

## **تبدیل ارائه به TIFF**

با استفاده از متد [save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ارائه‌شده توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/)، می‌توانید به سرعت یک ارائهٔ کامل PowerPoint را به TIFF تبدیل کنید. تصاویر TIFF تولید شده مطابق با اندازه پیش‌فرض اسلاید هستند.

این کد نشان می‌دهد چگونه یک ارائهٔ PowerPoint را به TIFF تبدیل کنید:

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

## **تبدیل ارائه به TIFF سیاه‌وسفید**

متد [setBwConversionMode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/) به شما امکان می‌دهد الگوریتم مورد استفاده هنگام تبدیل اسلاید یا تصویر رنگی به TIFF سیاه‌وسفید را مشخص کنید. توجه داشته باشید این تنظیم فقط زمانی اعمال می‌شود که متد [setCompressionType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

فرض کنید فایلی به نام «sample.pptx» داریم که اسلاید زیر را شامل می‌شود:

![یک اسلاید ارائه](slide_black_and_white.png)

این کد نشان می‌دهد چگونه اسلاید رنگی را به TIFF سیاه‌وسفید تبدیل کنید:

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

## **تبدیل ارائه به TIFF با اندازهٔ سفارشی**

اگر به یک تصویر TIFF با ابعاد خاص نیاز دارید، می‌توانید مقادیر مورد نظر خود را با استفاده از متدهای موجود در [TiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/) تنظیم کنید. به‌عنوان مثال، متد [setImageSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) به شما امکان می‌دهد اندازهٔ تصویر تولید شده را تعریف کنید.

این کد نشان می‌دهد چگونه یک ارائهٔ PowerPoint را به تصاویر TIFF با اندازهٔ سفارشی تبدیل کنید:

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
        Default - شیوه فشرده‌سازی پیش‌فرض (LZW) را مشخص می‌کند.
        None - عدم فشرده‌سازی را مشخص می‌کند.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // عمق به نوع فشرده‌سازی بستگی دارد و نمی‌توان آن را به‌ صورت دستی تنظیم کرد.

    // تنظیم DPI تصویر.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // تنظیم اندازهٔ تصویر.
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

## **تبدیل ارائه به TIFF با فرمت پیکسل تصویر سفارشی**

با استفاده از متد [setPixelFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) از کلاس [TiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/)، می‌توانید فرمت پیکسل دلخواه خود را برای تصویر TIFF تولید شده مشخص کنید.

این کد نشان می‌دهد چگونه یک ارائهٔ PowerPoint را به تصویر TIFF با فرمت پیکسل سفارشی تبدیل کنید:

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
        ImagePixelFormat شامل مقادیر زیر است (طبق مستندات):
            Format1bppIndexed - 1 بیت در هر پیکسل، فهرست‌شده.
            Format4bppIndexed - 4 بیت در هر پیکسل، فهرست‌شده.
            Format8bppIndexed - 8 بیت در هر پیکسل، فهرست‌شده.
            Format24bppRgb    - 24 بیت در هر پیکسل، RGB.
            Format32bppArgb   - 32 بیت در هر پیکسل، ARGB.
    */
    
    // ذخیرهٔ ارائه به صورت TIFF با فرمت پیکسل مشخص‌شده.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
به [ابزار رایگان تبدیل PowerPoint به پوستر Aspose](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online) نگاهی بیندازید.
{{% /alert %}}

## **سوالات متداول**

### آیا می‌توانم یک اسلاید جداگانه را به‌ جای تبدیل کل ارائهٔ PowerPoint به TIFF تبدیل کنم؟

بله. Aspose.Slides به شما امکان می‌دهد اسلایدهای جداگانهٔ ارائه‌های PowerPoint و OpenDocument را به‌ طور مستقل به تصاویر TIFF تبدیل کنید.

### آیا محدودیتی برای تعداد اسلایدها هنگام تبدیل یک ارائه به TIFF وجود دارد؟

خیر، Aspose.Slides هیچ محدودیتی بر تعداد اسلایدها اعمال نمی‌کند. می‌توانید ارائه‌های با هر اندازه‌ای را به فرمت TIFF تبدیل کنید.

### آیا انیمیشن‌ها و افکت‌های انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟

خیر، TIFF یک فرمت تصویر ثابت است. بنابراین، انیمیشن‌ها و افکت‌های انتقال حفظ نمی‌شوند؛ فقط تصاویر ثابت از اسلایدها صادر می‌شوند.