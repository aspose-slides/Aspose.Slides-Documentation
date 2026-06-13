---
title: تبدیل ارائه‌های PowerPoint به TIFF در جاوا
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
- ذخیره PPT به صورت TIFF
- ذخیره PPTX به صورت TIFF
- صدور PPT به TIFF
- صدور PPTX به TIFF
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه به راحتی ارائه‌های PowerPoint (PPT، PPTX) را به تصاویر TIFF با کیفیت بالا با استفاده از Aspose.Slides برای جاوا تبدیل کنید، همراه با مثال‌های کد."
---
## **معرفی**

TIFF (**Tagged Image File Format**) یک قالب تصویر رستر بدون از دست رفتن داده، که به دلیل کیفیت فوق‌العاده و حفظ دقیق گرافیک‌ها به‌طور گسترده‌ای استفاده می‌شود. طراحان، عکاسان و ناشران دسکتاپ اغلب برای حفظ لایه‌ها، دقت رنگ و تنظیمات اصلی تصاویر خود، TIFF را انتخاب می‌کنند.

با استفاده از Aspose.Slides می‌توانید به سادگی اسلایدهای PowerPoint (PPT, PPTX) و اسلایدهای OpenDocument (ODP) را مستقیم به تصاویر TIFF با کیفیت بالا تبدیل کنید و اطمینان حاصل کنید که ارائه‌های شما حداکثر وضوح بصری را حفظ می‌کند.

## **تبدیل یک ارائه به TIFF**

با استفاده از متد [save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ارائه می‌شود، می‌توانید به سرعت یک ارائه کامل PowerPoint را به TIFF تبدیل کنید. تصاویر TIFF حاصل مطابق با اندازه پیش‌فرض اسلاید هستند.

این کد نحوه تبدیل یک ارائه PowerPoint به TIFF را نشان می‌دهد:

```java
// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
Presentation presentation = new Presentation("presentation.pptx");
try {
    // ارائه را به عنوان TIFF ذخیره می‌کند.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **تبدیل یک ارائه به TIFF سیاه‌سفید**

متد [setBwConversionMode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/) به شما امکان می‌دهد الگوریتم مورد استفاده هنگام تبدیل یک اسلاید یا تصویر رنگی به TIFF سیاه‌سفید را مشخص کنید. توجه داشته باشید که این تنظیم فقط زمانی اعمال می‌شود که متد [setCompressionType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

فرض کنیم فایلی به نام "sample.pptx" با اسلاید زیر داریم:

![یک اسلاید ارائه](slide_black_and_white.png)

این کد نحوه تبدیل اسلاید رنگی به TIFF سیاه‌سفید را نشان می‌دهد:

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

![TIFF سیاه‌سفید](TIFF_black_and_white.png)

## **تبدیل یک ارائه به TIFF با اندازه سفارشی**

اگر به تصویری TIFF با ابعاد خاص نیاز دارید، می‌توانید مقادیر دلخواه خود را با استفاده از متدهای موجود در [TiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/) تنظیم کنید. به‌عنوان مثال، متد [setImageSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) به شما امکان تعریف اندازه تصویر حاصل را می‌دهد.

این کد نحوه تبدیل یک ارائه PowerPoint به تصاویر TIFF با اندازه سفارشی را نشان می‌دهد:

```java
// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
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

    // عمق به نوع فشرده‌سازی وابسته است و نمی‌توان آن را به‌صورت دستی تنظیم کرد.

    // تنظیم DPI تصویر.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // تنظیم اندازه تصویر.
    tiffOptions.setImageSize(new Dimension(1728, 1078));

    INotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // ذخیره ارائه به صورت TIFF با اندازه مشخص‌شده.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **تبدیل یک ارائه به TIFF با فرمت پیکسل تصویر سفارشی**

با استفاده از متد [setPixelFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) از کلاس [TiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/)، می‌توانید فرمت پیکسل دلخواه خود را برای تصویر TIFF حاصل تعیین کنید.

این کد نحوه تبدیل یک ارائه PowerPoint به تصویر TIFF با فرمت پیکسل سفارشی را نشان می‌دهد:

```java
// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat شامل مقادیر زیر است (همان‌طور که در مستندات ذکر شده):
        Format1bppIndexed - 1 بیت در هر پیکسل، با رنگ نمایه‌ای.
        Format4bppIndexed - 4 بیت در هر پیکسل، با رنگ نمایه‌ای.
        Format8bppIndexed - 8 بیت در هر پیکسل، با رنگ نمایه‌ای.
        Format24bppRgb    - 24 بیت در هر پیکسل، RGB.
        Format32bppArgb   - 32 بیت در هر پیکسل، ARGB.
    */
    
    // ارائه را به صورت TIFF با اندازه تصویر مشخص شده ذخیره می‌کند.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
به مبدل [رایگان PowerPoint به پوستر](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online) Aspose نگاهی بیندازید.
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم یک اسلاید تک به‌جای کل ارائه PowerPoint را به TIFF تبدیل کنم؟**

بله. Aspose.Slides به شما امکان می‌دهد اسلایدهای جداگانه از ارائه‌های PowerPoint و OpenDocument را به صورت مستقل به تصاویر TIFF تبدیل کنید.

**آیا محدودیتی برای تعداد اسلایدها هنگام تبدیل یک ارائه به TIFF وجود دارد؟**

خیر، Aspose.Slides محدودیتی برای تعداد اسلایدها اعمال نمی‌کند. می‌توانید ارائه‌های با هر اندازه‌ای را به فرمت TIFF تبدیل کنید.

**آیا انیمیشن‌ها و افکت‌های انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟**

خیر، TIFF یک فرمت تصویر ثابت است. بنابراین، انیمیشن‌ها و افکت‌های انتقال حفظ نمی‌شوند؛ فقط تصاویر ثابت از اسلایدها صادر می‌شوند.