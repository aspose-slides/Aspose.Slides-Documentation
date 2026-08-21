---
title: تبدیل ارائه‌های PowerPoint به TIFF در اندروید
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
- ذخیره PPT به صورت TIFF
- ذخیره PPTX به صورت TIFF
- خروجی PPT به TIFF
- خروجی PPTX به TIFF
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه به راحتی ارائه‌های PowerPoint (PPT، PPTX) را به تصاویر TIFF با کیفیت بالا با استفاده از Aspose.Slides برای Android، با مثال‌های کد Java، تبدیل کنید."
---
## **معرفی**

TIFF (**Tagged Image File Format**) یک فرمت رایج تصاویر رستر بدون فقدان است که به دلیل کیفیت استثنایی و حفظ دقیق گرافیک‌ها شناخته شده است. طراحان، عکاسان و ناشران دسکتاپ اغلب برای حفظ لایه‌ها، دقت رنگ و تنظیمات اصلی تصاویر خود، TIFF را انتخاب می‌کنند.

با استفاده از Aspose.Slides می‌توانید به راحتی اسلایدهای PowerPoint (PPT، PPTX) و اسلایدهای OpenDocument (ODP) خود را به‌صورت مستقیم به تصاویر TIFF با کیفیت بالا تبدیل کنید و اطمینان حاصل کنید که ارائه‌های شما حداکثر صحت بصری را حفظ می‌کنند.

## **تبدیل ارائه به TIFF**

با استفاده از متد [save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ارائه می‌شود، می‌توانید به سرعت یک ارائه کامل PowerPoint را به TIFF تبدیل کنید. تصاویر TIFF تولید شده با اندازه پیش‌فرض اسلاید مطابقت دارند.

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را به TIFF تبدیل کنیم:

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation که نمایانگر فایل ارائه (PPT، PPTX، ODP و غیره) است را ایجاد کنید.
Presentation presentation = new Presentation("presentation.pptx");
try {
    // ارائه را به صورت TIFF ذخیره کنید.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **تبدیل ارائه به TIFF سیاه و سفید**

متد [setBwConversionMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/) به شما امکان می‌دهد الگوریتم مورد استفاده هنگام تبدیل یک اسلاید یا تصویر رنگی به TIFF سیاه و سفید را مشخص کنید. توجه داشته باشید که این تنظیم فقط زمانی اعمال می‌شود که متد [setCompressionType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) بر روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) یک تنظیم در سطح خروجی است که الگوریتم تبدیل پیکسل برای کل تصویر TIFF را انتخاب می‌کند. برای تعریف نحوه نمایش یک شکل خاص وقتی حالت نمایش سیاه و سفید فعال است، از [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) استفاده کنید. برای مثال‌ها به [Control Black-and-White Rendering for Shapes](/androidjava/shape-formatting/#control-black-and-white-rendering-for-shapes) مراجعه کنید.
{{% /alert %}}

فرض کنید فایلی به نام "sample.pptx" داریم که شامل اسلاید زیر است:

![یک اسلاید ارائه](slide_black_and_white.png)

این کد نشان می‌دهد چگونه اسلاید رنگی را به TIFF سیاه و سفید تبدیل کنیم:

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

اگر به تصویر TIFF با ابعاد خاصی نیاز دارید، می‌توانید مقادیر دلخواه خود را با استفاده از متدهای موجود در [TiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/) تنظیم کنید. برای مثال، متد [setImageSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) به شما امکان می‌دهد اندازه تصویر خروجی را تعریف کنید.

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را به تصاویر TIFF با اندازه سفارشی تبدیل کنیم:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

//    // یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است را ایجاد کنید.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    //    // نوع فشرده‌سازی را تنظیم کنید.
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

    //    // عمق وابسته به نوع فشرده‌سازی است و نمی‌توان آن را به‌صورت دستی تنظیم کرد.

    //    // وضوح تصویر (DPI) را تنظیم کنید.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    //    // اندازه تصویر را تنظیم کنید.
    tiffOptions.setImageSize(new Size(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    //    // ارائه را با اندازه مشخص به صورت TIFF ذخیره کنید.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **تبدیل ارائه به TIFF با فرمت پیکسل تصویر سفارشی**

با استفاده از متد [setPixelFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) از کلاس [TiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/) می‌توانید فرمت پیکسل مورد نظر خود را برای تصویر TIFF خروجی مشخص کنید.

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را به تصویر TIFF با فرمت پیکسل سفارشی تبدیل کنیم:

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است را ایجاد کنید.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat شامل مقادیر زیر است (همان‌طور که در مستندات آمده):
        Format1bppIndexed - 1 بیت به ازای هر پیکسل، نمایه شده.
        Format4bppIndexed - 4 بیت به ازای هر پیکسل، نمایه شده.
        Format8bppIndexed - 8 بیت به ازای هر پیکسل، نمایه شده.
        Format24bppRgb    - 24 بیت به ازای هر پیکسل، RGB.
        Format32bppArgb   - 32 بیت به ازای هر پیکسل، ARGB.
    */
    
    // ارائه را با فرمت پیکسل مشخص به صورت TIFF ذخیره کنید.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
به [مبدل رایگان PowerPoint به پوستر](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online) Aspose مراجعه کنید.
{{% /alert %}}

## **پرسش‌های متداول**

**آیا می‌توانم به جای تبدیل کل ارائه PowerPoint، اسلاید فردی را به TIFF تبدیل کنم؟**

بله. Aspose.Slides به شما امکان می‌دهد تا اسلایدهای منفرد از ارائه‌های PowerPoint و OpenDocument را به صورت جداگانه به تصاویر TIFF تبدیل کنید.

**آیا محدودیتی برای تعداد اسلایدها هنگام تبدیل یک ارائه به TIFF وجود دارد؟**

خیر، Aspose.Slides هیچ محدودیتی برای تعداد اسلایدها اعمال نمی‌کند. می‌توانید ارائه‌های با هر اندازه‌ای را به فرمت TIFF تبدیل کنید.

**آیا انیمیشن‌ها و اثرات انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟**

خیر، TIFF یک فرمت تصویر ثابت است. بنابراین، انیمیشن‌ها و اثرات انتقال حفظ نمی‌شوند؛ فقط تصاویر ثابت از اسلایدها صادر می‌شوند.