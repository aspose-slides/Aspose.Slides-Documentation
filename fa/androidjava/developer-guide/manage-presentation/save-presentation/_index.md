---
title: ذخیره ارائه‌ها در اندروید
linktitle: ذخیره ارائه
type: docs
weight: 80
url: /fa/androidjava/save-presentation/
keywords:
- ذخیره PowerPoint
- ذخیره OpenDocument
- ذخیره ارائه
- ذخیره اسلاید
- ذخیره PPT
- ذخیره PPTX
- ذخیره ODP
- ارائه به فایل
- ارائه به جریان
- نوع نمای پیش‌تعریف‌شده
- قالب Strict Office Open XML
- حالت Zip64
- به‌روزرسانی تصویر بندانگشتی
- پیشرفت ذخیره‌سازی
- Android
- Java
- Aspose.Slides
description: "ارائه‌های PowerPoint و OpenDocument را در اندروید با Aspose.Slides به فایل‌ها یا جریان‌ها ذخیره کنید و خروجی PPTX و گزارش پیشرفت را پیکربندی نمایید."
---
## **نمای کلی**

پس از ایجاد یک ارائه یا [باز کردن یک ارائه موجود](/slides/fa/androidjava/open-presentation/)، از روش [Presentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) برای نوشتن نتیجه استفاده کنید. Aspose.Slides برای Android از طریق Java می‌تواند یک ارائه را در قالب‌های PowerPoint، OpenDocument، PDF و سایر فرمت‌ها به یک فایل یا جریان ذخیره کند. بخش‌های زیر عملیات‌های ذخیره‌سازی استاندارد و گزینه‌های موجود برای خروجی PPTX را پوشش می‌دهند.

## **ذخیره ارائه‌ها در فایل‌ها**

برای ذخیره یک ارائه در فایل، مسیر خروجی و یک مقدار [SaveFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveformat/) را به روش [Presentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) پاس می‌دهید. مقدار فرم‌ت تعیین می‌کند که Aspose.Slides چه نوع فایلی ایجاد کند.

مثال زیر یک ارائه را ایجاد کرده و به صورت فایل PPTX ذخیره می‌کند:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // محتواي ارائه را در اينجا اضافه يا اصلاح كنيد.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها در قالب اصلی خود**

برای مثال‌های شناسایی فایل و جریان، رفتار ارائه‌های تازه ایجاد شده و تمایز بین قالب‌های منبع و خروجی، به بخش [Determine the Original Presentation Format](/slides/fa/androidjava/detect-presentation-source-format/) مراجعه کنید.

در یک برنامه پردازش دسته‌ای، قالب ورودی ممکن است پیشاپیش شناخته نشده باشد. پس از بارگذاری یک فایل، قالب اصلی آن را از روش [IPresentation.getSourceFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) بخوانید. مقدار [SourceFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sourceformat/) به‌دست‌آمده را به [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) پاس دهید تا مقدار متناظر [SaveFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveformat/) به‌دست آید، و سپس از [Presentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) برای نوشتن ارائهٔ تغییر یافته استفاده کنید.

مثال کامل زیر هر فایل در یک پوشهٔ ورودی را پردازش می‌کند، عنوان آن را به‌روزرسانی می‌کند و در قالبی که از آن بارگذاری شده به پوشهٔ خروجی ذخیره می‌نماید:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SlideUtil;
import java.io.File;

File inputDirectory = new File("Input");
File outputDirectory = new File("Output");

if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    System.err.println("Cannot create the output directory.");
}

File[] inputFiles = inputDirectory.listFiles(File::isFile);
if (inputFiles != null && outputDirectory.isDirectory()) {
    for (File inputFile : inputFiles) {
        try {
            Presentation presentation = new Presentation(inputFile.getPath());
            try {
                int saveFormat = SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                File outputFile = new File(outputDirectory, inputFile.getName());
                presentation.save(outputFile.getPath(), saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (IllegalArgumentException exception) {
            System.err.println("Cannot map the source format of '" + inputFile.getPath() + "': " + exception.getMessage());
        } catch (Exception exception) {
            System.err.println("Cannot process '" + inputFile.getPath() + "': " + exception.getMessage());
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) قالب‌های PPT، PPTX، ODP، PPTM، PPSX، PPSM، POTX، POTM، PPS، POT، OTP، FODP و PowerPoint XML را به فرمت‌های ذخیره‌سازی متناظرشان نگاشت می‌کند. این نگاشت فقط برای قالب‌های منبع ارائه است؛ برای انتخاب قالب‌های خروجی مانند PDF، HTML، TIFF یا تصاویر در نظر گرفته نشده است. عبور یک مقدار [SourceFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sourceformat/) نامعتبر یا غیرپشتیبانی‌شده منجر به پرتاب یک [IllegalArgumentException](https://developer.android.com/reference/java/lang/IllegalArgumentException) می‌شود.

فایل‌های Legacy PPT، PPS و POT از همان مخزن باینری استفاده می‌کنند. زمانی که چنین ارائه‌ای از یک جریان بدون پسوند فایل بارگذاری می‌شود، ممکن است یک فایل PPS یا POT به‌عنوان PPT شناسایی شود. اگر حفظ این زیرنوع‌های قدیمی ضروری باشد، نام فایل یا فرادادهٔ قالب اصلی را جداگانه نگه‌دارید و هنگام انتخاب نام و قالب خروجی از آن استفاده کنید.

## **ذخیره ارائه‌ها در جریان‌ها**

برای نوشتن یک ارائه بدون نیاز به مسیر نهایی فایل، یک جریان قابل نوشتن و یک مقدار [SaveFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveformat/) را به روش [Presentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) پاس دهید. این روش وقتی خروجی باید از یک سرویس وب بازگردانده شود، در یک دیتابیس ذخیره گردد یا در حافظه پردازش شود، مفید است.

مثال زیر یک ارائهٔ جدید را در یک جریان فایل ذخیره می‌کند:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileOutputStream;
import java.io.OutputStream;

Presentation presentation = new Presentation();
try {
    OutputStream outputStream = new FileOutputStream("Output.pptx");
    try {
        presentation.save(outputStream, SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها با یک نوع نمای پیش‌تعریف‌شده**

می‌توانید نمایی که PowerPoint هنگام باز کردن ارائه ذخیره‌شده ابتدا نمایش می‌دهد، مشخص کنید. قبل از ذخیره از روش [ViewProperties.setLastView](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) با یک مقدار [ViewType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/viewtype/) استفاده کنید.

مثال زیر نمای Master Slide را به‌عنوان نمای اولیه تنظیم می‌کند:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها در فرمت Strict Office Open XML**

برای ایجاد یک فایل PPTX که با پروفایل Strict قالب Office Open XML سازگار باشد، یک نمونهٔ [PptxOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pptxoptions/) ایجاد کنید و با روش [setConformance](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pptxoptions/#setConformance-int-) مقدار [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) را تنظیم کنید. سپس گزینه‌ها را به روش [Presentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) پاس دهید.

```java
import com.aspose.slides.Conformance;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

Presentation presentation = new Presentation();
try {
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها در قالب Office Open XML در حالت Zip64**

یک آرشیو ZIP استاندارد اندازه فشرده و غیر فشرده هر ورودی، مجموع اندازه آرشیو و تعداد ورودی‌ها را محدود می‌کند. از آنجا که یک فایل PPTX یک آرشیو ZIP است، یک ارائهٔ بسیار بزرگ می‌تواند از این محدودیت‌ها فراتر برود. افزونه‌های ZIP64 این محدودیت‌ها را افزایش می‌دهند.

از روش [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pptxoptions/#setZip64Mode-int-) برای کنترل نوشتن افزونه‌های ZIP64 توسط Aspose.Slides استفاده کنید:

- [IfNecessary](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/zip64mode/#IfNecessary) تنها زمانی ZIP64 را به‌کار می‌برد که ارائه از محدودیت‌های ZIP استاندارد فراتر رود. این حالت پیش‌فرض است.
- [Never](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/zip64mode/#Never) افزونه‌های ZIP64 را غیرفعال می‌کند.
- [Always](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/zip64mode/#Always) همیشه افزونه‌های ZIP64 را می‌نویسد.

مثال زیر همیشه برای ارائهٔ خروجی افزونه‌های ZIP64 را فعال می‌کند:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.Zip64Mode;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setZip64Mode(Zip64Mode.Always);

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
اگر [Zip64Mode.Never](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/zip64mode/#Never) استفاده شود و ارائه نتواند در محدودیت‌های ZIP استاندارد جا بگیرد، عملیات ذخیره‌سازی یک [PptxException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pptxexception/) را پرتاب می‌کند.
{{% /alert %}}

## **ذخیره ارائه‌ها در قالب Office Open XML با سطوح فشرده‌سازی**

برای خروجی PPTX می‌توانید با استفاده از روش [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pptxoptions/#setCompressionLevel-int-) سرعت ذخیره‌سازی را در برابر اندازهٔ فایل متعادل کنید. کلاس [CompressionLevel](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compressionlevel/) این مقادیر را فراهم می‌کند:

- [None](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compressionlevel/#None) داده‌ها را بدون فشرده‌سازی ذخیره می‌کند.
- [Level1](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compressionlevel/#Level1) سریع‌ترین فشرده‌سازی و بزرگترین خروجی فشرده را فراهم می‌کند.
- [Level2](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compressionlevel/#Level2) تا [Level5](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compressionlevel/#Level5) به‌صورت تدریجی خروجی کوچکتر را نسبت به سرعت ذخیره‌سازی ترجیح می‌دهند.
- [Level6](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compressionlevel/#Level6) بین سرعت ذخیره‌سازی و اندازهٔ فایل تعادل برقرار می‌کند. این سطح پیش‌فرض است.
- [Level7](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compressionlevel/#Level7) و [Level8](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compressionlevel/#Level8) بیشتر به خروجی کوچکتر نسبت به سرعت اهمیت می‌دهند.
- [Level9](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compressionlevel/#Level9) قوی‌ترین فشرده‌سازی را فراهم می‌کند و زمان پردازش بیشتری می‌طلبد.

مثال زیر یک ارائه را بدون فشرده‌سازی ذخیره می‌کند:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.None);

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

مثال زیر از حداکثر سطح فشرده‌سازی استفاده می‌کند:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.Level9);

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها بدون به‌روزرسانی تصویر بندانگشتی**

هنگام ذخیرهٔ یک ارائه به‌صورت PPTX، روش [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) کنترل می‌کند که تصویر بندانگشتی سند چگونه رفتار کند:

- `true` تصویر بندانگشتی را در طول عملیات ذخیره‌سازی بازتولید می‌کند. این مقدار پیش‌فرض است.
- `false` تصویر بندانگشتی موجود را حفظ می‌کند. اگر ارائه بندانگشتی نداشته باشد، Aspose.Slides هیچ‌یک را تولید نمی‌کند.

مثال زیر یک ارائه را بدون به‌روزرسانی تصویر بندانگشتی ذخیره می‌کند:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("Output.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
غیرفعال کردن به‌روزرسانی تصویر بندانگشتی می‌تواند زمان لازم برای ذخیرهٔ یک فایل PPTX را کاهش دهد.
{{% /alert %}}

## **به‌روزرسانی پیشرفت ذخیره‌سازی به درصد**

برای نظارت بر عملیات ذخیره‌سازی، رابط [IProgressCallback](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iprogresscallback/) را پیاده‌سازی کنید و پیاده‌سازی را به روش [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-) پاس دهید. سپس Aspose.Slides در طول خروجی، متد [IProgressCallback.reporting](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iprogresscallback/#reporting-double-) را با مقادیر پیشرفت فراخوانی می‌کند.

مثال زیر پیشرفت یک خروجی PDF را در کنسول گزارش می‌دهد:

```java
import com.aspose.slides.IProgressCallback;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        int progress = (int) progressValue;
        System.out.println(progress + "% of the file has been converted.");
    }
}

PdfOptions options = new PdfOptions();
options.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose یک برنامهٔ رایگان [PowerPoint Splitter](https://products.aspose.app/slides/fa/splitter) ساخته‌شده با API Aspose.Slides ارائه می‌دهد. این برنامه اسلایدهای انتخابی را از یک ارائه به‌صورت فایل‌های جداگانهٔ PPT یا PPTX ذخیره می‌کند.
{{% /alert %}}

## **سؤال و جواب**

**آیا Aspose.Slides از ذخیره‌سازی افزایشی یا «ذخیره‌سازی سریع» پشتیبانی می‌کند؟**

نه. هر عملیات ذخیره‌سازی یک فایل خروجی کامل می‌نویسد و فقط قسمت‌های تغییر یافته را به‌روزرسانی نمی‌کند.

**آیا چندین رشته می‌توانند همزمان همان نمونهٔ Presentation را ذخیره کنند؟**

نه. یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) **thread‑safe نیست** (/slides/fa/androidjava/multithreading/). هر نمونه باید فقط از یک رشته در هر زمان دسترسی و ذخیره شود.

**هنگام ذخیرهٔ یک ارائه چه اتفاقی برای هایپرلینک‌ها و فایل‌های خارجی لینک‌شده می‌افتد؟**

[هایپرلینک‌ها](/slides/fa/androidjava/manage-hyperlinks/) در ارائه باقی می‌مانند. Aspose.Slides فایل‌های خارجی را کپی نمی‌کند، بنابراین ارائهٔ ذخیره‌شده باید همچنان قادر به دسترسی به مکان‌های آن‌ها باشد.

**آیا می‌توانم متادیتای سند مانند نویسنده، عنوان، شرکت و تاریخ ایجاد را ذخیره کنم؟**

بله. پیش از ذخیره‌سازی، ویژگی‌های سند مناسب را تنظیم کنید و Aspose.Slides آن‌ها را در فایل خروجی می‌نویسد.