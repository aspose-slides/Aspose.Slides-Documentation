---
title: ذخیره ارائه‌ها در جاوا
linktitle: ذخیره ارائه
type: docs
weight: 80
url: /fa/java/save-presentation/
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
- فرمت Strict Office Open XML
- حالت Zip64
- به‌روزرسانی تصویر بندانگشتی
- پیشرفت ذخیره‌سازی
- جاوا
- Aspose.Slides
description: "ارائه‌های PowerPoint و OpenDocument را در جاوا با Aspose.Slides به فایل‌ها یا جریان‌ها ذخیره کنید و خروجی PPTX و گزارش‌گیری پیشرفت را پیکربندی کنید."
---
## **بررسی کلی**

پس از اینکه یک ارائه ایجاد کنید یا [یک ارائه موجود را باز کنید](/slides/fa/java/open-presentation/)، از روش [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) برای نوشتن نتیجه استفاده کنید. Aspose.Slides for Java می‌تواند یک ارائه را به یک فایل یا جریان در فرمت‌های PowerPoint، OpenDocument، PDF و سایر فرمت‌ها ذخیره کند. بخش‌های زیر عملیات ذخیره‌سازی استاندارد و گزینه‌های موجود برای خروجی PPTX را پوشش می‌دهند.

## **ذخیره ارائه‌ها در فایل‌ها**

برای ذخیره یک ارائه در فایل، مسیر خروجی و مقدار [SaveFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveformat/) را به روش [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) بدهید. مقدار فرمت نوع فایلی که Aspose.Slides ایجاد می‌کند را تعیین می‌کند.

مثال زیر یک ارائه ایجاد کرده و به‌عنوان فایل PPTX ذخیره می‌کند:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // در اینجا محتویات ارائه را اضافه یا اصلاح کنید.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها در فرمت اصلی آنها**

برای مثال‌های تشخیص فایل و جریان، رفتار ارائه‌های تازه‌ساخته‌شده و تمایز بین فرمت منبع و خروجی، به [Determine the Original Presentation Format](/slides/fa/java/detect-presentation-source-format/) مراجعه کنید.

در یک برنامه پردازش دسته‌ای، ممکن است فرمت ورودی از پیش شناخته‌شده نباشد. پس از بارگذاری یک فایل، فرمت اصلی آن را از روش [IPresentation.getSourceFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#getSourceFormat--) بخوانید. مقدار حاصل [SourceFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sourceformat/) را به [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideutil/#toSaveFormat-int-) بدهید تا مقدار متناظر [SaveFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveformat/) را دریافت کنید، و سپس از [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) برای نوشتن ارائه اصلاح‌شده استفاده کنید.

مثال کامل زیر هر فایل در یک پوشه ورودی را پردازش می‌کند، عنوان آن را به‌روز می‌کند و در پوشه خروجی به همان فرمی که بارگذاری شده ذخیره می‌کند:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideutil/#toSaveFormat-int-) فرمت‌های PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP و PowerPoint XML را به فرمت‌های ذخیره‌سازی مرتبطشان تبدیل می‌کند. این متد فقط فرمت‌های منبع ارائه را نگاشت می‌کند؛ برای انتخاب فرمت‌های خروجی مانند PDF، HTML، TIFF یا تصاویر منظور نیست. استفاده از مقدار [SourceFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sourceformat/) پشتیبانی‌نشده یا نامعتبر منجر به بروز یک [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html) می‌شود.

فایل‌های Legacy PPT, PPS و POT از همان کانتینر باینری استفاده می‌کنند. وقتی چنین ارائه‌ای بدون پسوند فایل از یک جریان بارگذاری شود، ممکن است یک فایل PPS یا POT به‌عنوان PPT تشخیص داده شود. اگر نیاز به حفظ این زیرنوع‌های قدیمی باشد، نام فایل یا متادیتای فرمت اصلی را به‌صورت جداگانه نگهداری کنید و هنگام انتخاب نام و فرمت خروجی از آن استفاده کنید.

## **ذخیره ارائه‌ها در جریان‌ها**

برای نوشتن یک ارائه بدون وابستگی به مسیر نهایی فایل، یک جریان قابل نوشتن و مقدار [SaveFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveformat/) را به روش [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) بدهید. این روش زمانی مفید است که خروجی باید از یک سرویس وب بازگردانده شود، در پایگاه‌داده ذخیره شود یا در حافظه پردازش گردد.

مثال زیر یک ارائه جدید را در یک جریان فایل ذخیره می‌کند:

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

## **ذخیره ارائه‌ها با نوع نمای پیش‌تعریف‌شده**

می‌توانید نمایی که PowerPoint به‌صورت اولیه هنگام باز کردن یک ارائه ذخیره‌شده استفاده می‌کند را مشخص کنید. پیش از ذخیره از روش [ViewProperties.setLastView](https://reference.aspose.com/slides/fa/java/com.aspose.slides/viewproperties/#setLastView-int-) همراه با مقدار [ViewType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/viewtype/) استفاده کنید.

مثال زیر نمای Slide Master را به عنوان نمای اولیه تنظیم می‌کند:

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

برای ایجاد یک فایل PPTX که با پروفایل Strict Office Open XML سازگار باشد، یک نمونه [PptxOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxoptions/) بسازید و از روش [setConformance](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxoptions/#setConformance-int-) همراه با [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/fa/java/com.aspose.slides/conformance/#Iso29500-2008-Strict) استفاده کنید. سپس این گزینه‌ها را به روش [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) بدهید.

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

## **ذخیره ارائه‌ها در فرمت Office Open XML در حالت Zip64**

یک آرشیو ZIP استاندارد اندازه فشرده و غیرفشرده هر ورودی، مجموع اندازه آرشیو و تعداد ورودی‌ها را محدود می‌کند. از آنجایی که یک فایل PPTX یک آرشیو ZIP است، یک ارائه بسیار بزرگ می‌تواند این محدودیت‌ها را عبور کند. افزونه‌های ZIP64 این محدودیت‌ها را افزایش می‌دهند.

از روش [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxoptions/#setZip64Mode-int-) برای کنترل نوشتن افزونه‌های ZIP64 استفاده کنید:

- [IfNecessary](https://reference.aspose.com/slides/fa/java/com.aspose.slides/zip64mode/#IfNecessary) فقط وقتی که ارائه از محدودیت‌های ZIP استاندارد فراتر رود ZIP64 را به کار می‌برد. این حالت پیش‌فرض است.
- [Never](https://reference.aspose.com/slides/fa/java/com.aspose.slides/zip64mode/#Never) افزونه‌های ZIP64 را غیرفعال می‌کند.
- [Always](https://reference.aspose.com/slides/fa/java/com.aspose.slides/zip64mode/#Always) همیشه افزونه‌های ZIP64 را می‌نویسد.

مثال زیر همیشه برای ارائه خروجی افزونه‌های ZIP64 را فعال می‌کند:

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
اگر از [Zip64Mode.Never](https://reference.aspose.com/slides/fa/java/com.aspose.slides/zip64mode/#Never) استفاده شود و ارائه نتواند در محدوده‌های ZIP استاندارد جا بگیرد، عملیات ذخیره یک [PptxException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxexception/) را پرتاب می‌کند.
{{% /alert %}}

## **ذخیره ارائه‌ها در فرمت Office Open XML با سطوح فشرده‌سازی**

برای خروجی PPTX می‌توانید با استفاده از روش [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxoptions/#setCompressionLevel-int-) سرعت ذخیره را در مقابل اندازه فایل متعادل کنید. کلاس [CompressionLevel](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compressionlevel/) این مقادیر را فراهم می‌کند:

- [None](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compressionlevel/#None) داده‌ها را بدون فشرده‌سازی ذخیره می‌کند.
- [Level1](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compressionlevel/#Level1) سریع‌ترین فشرده‌سازی را دارد اما بزرگ‌ترین خروجی فشرده را تولید می‌کند.
- [Level2](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compressionlevel/#Level2) تا [Level5](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compressionlevel/#Level5) به‌تدریج اولویت کوچک‌تر کردن خروجی را نسبت به سرعت ذخیره افزایش می‌دهند.
- [Level6](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compressionlevel/#Level6) بین سرعت ذخیره و اندازه فایل تعادل می‌یابد. این سطح پیش‌فرض است.
- [Level7](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compressionlevel/#Level7) و [Level8](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compressionlevel/#Level8) بیشتر به کوچک‌تر کردن خروجی نسبت به سرعت ذخیره اهمیت می‌دهند.
- [Level9](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compressionlevel/#Level9) قوی‌ترین فشرده‌سازی را فراهم می‌کند ولی زمان پردازش بیشتری می‌طلبد.

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

هنگامی که یک ارائه به صورت PPTX ذخیره می‌شود، روش [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) کنترل می‌کند که تصویر بندانگشتی سند چگونه باشد:

- `true` تصویر بندانگشتی را در طول عملیات ذخیره بازتولید می‌کند. این مقدار پیش‌فرض است.
- `false` تصویر بندانگشتی موجود را حفظ می‌کند. اگر ارائه تصویر بندانگشتی نداشته باشد، Aspose.Slides تصویر جدیدی تولید نمی‌کند.

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
غیرفعال کردن به‌روزرسانی تصویر بندانگشتی می‌تواند زمان مورد نیاز برای ذخیره یک فایل PPTX را کاهش دهد.
{{% /alert %}}

## **به‌روزرسانی پیشرفت ذخیره به صورت درصدی**

برای نظارت بر عملیات ذخیره، رابط [IProgressCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprogresscallback/) را پیاده‌سازی کنید و پیاده‌سازی را به روش [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-) پاس دهید. سپس Aspose.Slides در طول صادرات، متد [IProgressCallback.reporting](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprogresscallback/#reporting-double-) را با مقادیر پیشرفت فراخوانی می‌کند.

مثال زیر پیشرفت صادرات PDF را در کنسول گزارش می‌دهد:

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
Aspose یک برنامه رایگان **PowerPoint Splitter** (https://products.aspose.app/slides/fa/splitter) ساخته‌شده با API Aspose.Slides فراهم می‌کند. این ابزار اسلایدهای انتخابی را از یک ارائه به‌صورت فایل‌های جداگانه PPT یا PPTX ذخیره می‌نماید.
{{% /alert %}}

## **سؤالات متداول**

**آیا Aspose.Slides از ذخیره‌سازی تدریجی یا «ذخیره سریع» پشتیبانی می‌کند؟**

خیر. هر عملیات ذخیره یک فایل خروجی کامل می‌نویسد و فقط بخش‌های تغییر یافته را به‌روز نمی‌کند.

**آیا چندین رشته می‌توانند یک نمونه Presentation را ذخیره کنند؟**

خیر. یک نمونه [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) **thread‑safe** نیست. هر نمونه باید فقط از یک رشته در هر زمان دسترسی و ذخیره شود.

**چه اتفاقی برای پیوندهای فراخوانی و فایل‌های لینک‌دار خارجی می‌افتد وقتی یک ارائه را ذخیره می‌کنم؟**

[Hyperlinks](/slides/fa/java/manage-hyperlinks/) در ارائه باقی می‌مانند. Aspose.Slides فایل‌های لینک‌دار خارجی را کپی نمی‌کند، بنابراین ارائه ذخیره‌شده باید همچنان بتواند به مکان‌های آن‌ها دسترسی داشته باشد.

**آیا می‌توانم متادیتای سند مانند نویسنده، عنوان، شرکت و تاریخ ایجاد را ذخیره کنم؟**

بله. قبل از ذخیره، [document properties](/slides/fa/java/presentation-properties/) مناسب را تنظیم کنید و Aspose.Slides آن‌ها را در فایل خروجی می‌نویسد.