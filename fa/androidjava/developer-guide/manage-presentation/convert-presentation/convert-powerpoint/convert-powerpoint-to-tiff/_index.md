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
- صادرات PPT به TIFF
- صادرات PPTX به TIFF
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید که چگونه به راحتی ارائه‌های PowerPoint (PPT، PPTX) را به تصاویر TIFF با کیفیت بالا با استفاده از Aspose.Slides برای Android و با مثال‌های کد Java تبدیل کنید."
---
## **مقدمه**

TIFF (**Tagged Image File Format**) یک فرمت تصویر رستر بدون افت کیفیت است که به دلیل کیفیت فوق‌العاده و نگهداری دقیق گرافیک‌ها به‌طور گسترده‌ای مورد استفاده قرار می‌گیرد. طراحان، عکاسان و نشرکنندگان دسکتاپ اغلب TIFF را برای حفظ لایه‌ها، دقت رنگ و تنظیمات اصلی تصاویر خود انتخاب می‌کنند.

با استفاده از Aspose.Slides می‌توانید به راحتی اسلایدهای PowerPoint (PPT، PPTX) و اسلایدهای OpenDocument (ODP) خود را به‌صورت مستقیم به تصاویر TIFF با کیفیت بالا تبدیل کنید و اطمینان حاصل کنید که ارائه‌های شما حداکثر صحت بصری را حفظ می‌کنند.

## **تبدیل یک ارائه به TIFF**

با استفاده از متد [ذخیره](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) که توسط کلاس [ارائه](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ارائه می‌شود، می‌توانید به سرعت یک ارائه PowerPoint کامل را به TIFF تبدیل کنید. تصاویر TIFF تولید شده با اندازه پیش‌فرض اسلاید مطابقت دارند.

این کد نشان می‌دهد که چگونه یک ارائه PowerPoint را به TIFF تبدیل کنید:

```java
// یک نمونه از کلاس Presentation که نشان‌دهنده یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
Presentation presentation = new Presentation("presentation.pptx");
try {
    // ارائه را به عنوان TIFF ذخیره کنید.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **تبدیل یک ارائه به TIFF سیاه و سفید**

متد [setBwConversionMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/) به شما امکان می‌دهد الگوریتم مورد استفاده هنگام تبدیل یک اسلاید یا تصویر رنگی به TIFF سیاه و سفید را مشخص کنید. توجه داشته باشید که این تنظیم فقط زمانی اعمال می‌شود که متد [setCompressionType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) بر روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

فرض کنید فایلی به نام «sample.pptx» داریم که شامل اسلاید زیر است:

![یک اسلاید ارائه](slide_black_and_white.png)

این کد نشان می‌دهد که چگونه اسلاید رنگی را به TIFF سیاه و سفید تبدیل کنید:

```java
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

## **تبدیل یک ارائه به TIFF با اندازه سفارشی**

اگر به تصویری TIFF با ابعاد خاص نیاز دارید، می‌توانید مقادیر دلخواه خود را با استفاده از متدهای موجود در [TiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/) تنظیم کنید. به‌عنوان مثال، متد [setImageSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) به شما امکان می‌دهد اندازه تصویر خروجی را تعیین کنید.

این کد نشان می‌دهد که چگونه یک ارائه PowerPoint را به تصاویر TIFF با اندازه سفارشی تبدیل کنید:

```java
// نمونه‌سازی کلاس Presentation که نشان‌دهنده یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // تنظیم نوع فشرده‌سازی.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    انواع فشرده‌سازی:
        Default - طرح فشرده‌سازی پیش‌فرض (LZW) را مشخص می‌کند.
        None - عدم فشرده‌سازی را مشخص می‌کند.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // عمق بستگی به نوع فشرده‌سازی دارد و نمی‌توان به‌صورت دستی تنظیم کرد.

    // تنظیم DPI تصویر.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // تنظیم اندازه تصویر.
    tiffOptions.setImageSize(new Size(1728, 1078));

    INotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // ذخیره ارائه به عنوان TIFF با اندازه مشخص شده.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **تبدیل یک ارائه به TIFF با قالب پیکسل تصویر سفارشی**

با استفاده از متد [setPixelFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/) می‌توانید قالب پیکسل دلخواه خود را برای تصویر TIFF خروجی تعیین کنید.

این کد نشان می‌دهد که چگونه یک ارائه PowerPoint را به تصویر TIFF با قالب پیکسل سفارشی تبدیل کنید:

```java
// یک نمونه از کلاس Presentation که نشان‌دهنده یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat مقادیر زیر را شامل می‌شود (همان‌طور که در مستندات آمده است):
        Format1bppIndexed - 1 بیت در هر پیکسل، ایندکس‌شده.
        Format4bppIndexed - 4 بیت در هر پیکسل، ایندکس‌شده.
        Format8bppIndexed - 8 بیت در هر پیکسل، ایندکس‌شده.
        Format24bppRgb    - 24 بیت در هر پیکسل، RGB.
        Format32bppArgb   - 32 بیت در هر پیکسل، ARGB.
    */
    
    // ذخیرهٔ ارائه به صورت TIFF با اندازه تصویر مشخص شده.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="نکته" color="primary" %}}
به مبدل [رایگان PowerPoint به پوستر](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online) Aspose مراجعه کنید.
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم به‌جای تبدیل کل ارائه PowerPoint، اسلاید تک‌تکه را به TIFF تبدیل کنم؟**

بله. Aspose.Slides به شما اجازه می‌دهد که اسلایدهای جداگانه از ارائه‌های PowerPoint و OpenDocument را به‌صورت مجزا به تصاویر TIFF تبدیل کنید.

**آیا محدودیتی برای تعداد اسلایدها هنگام تبدیل یک ارائه به TIFF وجود دارد؟**

خیر، Aspose.Slides هیچ محدودیتی برای تعداد اسلایدها اعمال نمی‌کند. می‌توانید ارائه‌های با هر اندازه‌ای را به فرمت TIFF تبدیل کنید.

**آیا انیمیشن‌ها و اثرات انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟**

خیر، TIFF یک فرمت تصویر ثابت است. بنابراین، انیمیشن‌ها و اثرات انتقال حفظ نمی‌شوند؛ فقط نماهای ثابت اسلایدها صادر می‌شوند.