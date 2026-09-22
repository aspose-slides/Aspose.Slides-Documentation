---
title: ذخیرهٔ ارائه‌ها در PHP
linktitle: ذخیرهٔ ارائه
type: docs
weight: 80
url: /fa/php-java/save-presentation/
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
- پیشرفت ذخیره
- PHP
- Aspose.Slides
description: "PowerPoint و ارائه‌های OpenDocument را در PHP با Aspose.Slides به فایل‌ها یا جریان‌ها ذخیره کنید و خروجی PPTX و گزارش پیشرفت ذخیره را پیکربندی نمایید."
---
## **نمای کلی**

پس از اینکه یک ارائه ایجاد کردید یا [یک ارائه موجود را باز کنید](/slides/fa/php-java/open-presentation/)، از روش [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#save) برای نوشتن نتیجه استفاده کنید. Aspose.Slides for PHP via Java می‌تواند ارائه را در قالب PowerPoint، OpenDocument، PDF و سایر فرمت‌ها به یک فایل یا جریان ذخیره کند. بخش‌های زیر عملیات ذخیره‌سازی استاندارد و گزینه‌های موجود برای خروجی PPTX را پوشش می‌دهند.

## **ذخیره ارائه‌ها به فایل‌ها**

برای ذخیره یک ارائه به فایل، مسیر خروجی و مقدار [SaveFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveformat/) را به متد [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#save) پاس دهید. مقدار فرمت نوع فایلی که Aspose.Slides ایجاد می‌کند را تعیین می‌کند.

مثال زیر یک ارائه ایجاد می‌کند و آن را به عنوان فایل PPTX ذخیره می‌نماید:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // محتوا یا اسلایدهای ارائه را اینجا اضافه یا اصلاح کنید.

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ذخیره ارائه‌ها در فرمت اصلی آن‌ها**

برای مثال‌های تشخیص فایل و جریان، رفتار ارائه‌های تازه ایجاد شده و تمایز بین فرمت‌های منبع و خروجی، به [Determine the Original Presentation Format](/slides/fa/php-java/detect-presentation-source-format/) مراجعه کنید.

در یک برنامه پردازش دسته‌ای، ممکن است فرمت ورودی از پیش شناخته‌شده نباشد. پس از بارگذاری یک فایل، فرمت اصلی آن را با استفاده از متد [Presentation::getSourceFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getSourceFormat) بخوانید. مقدار [SourceFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sourceformat/) حاصل را به [SlideUtil::toSaveFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideutil/#toSaveFormat) پاس دهید تا مقدار [SaveFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveformat/) متناظر به دست آید، سپس از [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#save) برای نوشتن ارائهٔ تغییر یافته استفاده کنید.

مثال کامل زیر هر فایل را در یک پوشهٔ ورودی پردازش می‌کند، عنوان آن را به‌روز می‌سازد و در پوشهٔ خروجی به فرمتی که از آن بارگذاری شده است ذخیره می‌کند:

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$inputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Input";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Output";

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    echo("Cannot create the output directory." . PHP_EOL);
}

$inputFiles = is_dir($inputDirectory) ? scandir($inputDirectory) : false;
if ($inputFiles !== false && is_dir($outputDirectory)) {
    foreach ($inputFiles as $fileName) {
        $inputPath = $inputDirectory . DIRECTORY_SEPARATOR . $fileName;
        if (!is_file($inputPath)) {
            continue;
        }

        $presentation = null;
        $presentationLoaded = false;
        try {
            $presentation = new Presentation($inputPath);
            $presentationLoaded = true;
            $saveFormat = SlideUtil::toSaveFormat($presentation->getSourceFormat());
            $presentation->getDocumentProperties()->setTitle("Processed by the batch application");

            $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;
            $presentation->save($outputPath, $saveFormat);
        } catch (\Throwable $exception) {
            echo("Cannot process '" . $inputPath . "': " . $exception->getMessage() . PHP_EOL);
        } finally {
            if ($presentationLoaded) {
                $presentation->dispose();
            }
        }
    }
}
```

[SlideUtil::toSaveFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideutil/#toSaveFormat) فرمت‌های PPT، PPTX، ODP، PPTM، PPSX، PPSM، POTX، POTM، PPS، POT، OTP، FODP و XML PowerPoint را به فرمت‌های ذخیرهٔ ارائهٔ متناظرشان نگاشت می‌کند. این نگاشت فقط برای فرمت‌های منبع ارائه است؛ برای انتخاب فرمت‌های خروجی مانند PDF، HTML، TIFF یا تصاویر طراحی نشده است. ارسال مقدار [SourceFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sourceformat/) پشتیبانی‌نشده یا نامعتبر منجر به ایجاد یک [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html) می‌شود.

فایل‌های قدیمی PPT، PPS و POT از همان بستهٔ باینری استفاده می‌کنند. هنگام بارگذاری چنین ارائه‌ای از یک جریان بدون پسوند فایل، ممکن است یک فایل PPS یا POT به عنوان PPT شناسایی شود. اگر حفظ این زیرنوع‌های قدیمی لازم باشد، نام فایل اصلی یا فرادادهٔ فرمت را به‌طور جداگانه نگه دارید و هنگام انتخاب نام فایل و فرمت خروجی از آن استفاده کنید.

## **ذخیره ارائه‌ها به جریان‌ها**

برای نوشتن یک ارائه بدون وابستگی به مسیر نهایی فایل، یک جریان قابل نوشتن و مقدار [SaveFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveformat/) را به متد [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#save) پاس دهید. این روش زمانی مفید است که خروجی باید از یک سرویس وب بازگردانده شود، در پایگاه داده ذخیره شود یا در حافظه پردازش شود.

مثال زیر یک ارائهٔ جدید را به یک جریان فایل ذخیره می‌کند:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $outputStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        $presentation->save($outputStream, SaveFormat::Pptx);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **ذخیره ارائه‌ها با نوع نمای پیش‌تعریف‌شده**

می‌توانید نمایی را که PowerPoint هنگام باز کردن اولیهٔ یک ارائهٔ ذخیره‌شده استفاده می‌کند، مشخص کنید. پیش از ذخیره، از متد [ViewProperties::setLastView](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewproperties/#setLastView) با مقدار [ViewType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewtype/) استفاده کنید.

مثال زیر نمای Slide Master را به عنوان نمای اولیه تنظیم می‌کند:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ذخیره ارائه‌ها در فرمت Strict Office Open XML**

برای ایجاد یک فایل PPTX که با پروفایل Strict از Office Open XML سازگار باشد، یک نمونهٔ [PptxOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxoptions/) ایجاد کرده و با استفاده از متد [PptxOptions::setConformance](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxoptions/#setConformance) مقدار [Conformance::Iso29500_2008_Strict](https://reference.aspose.com/slides/fa/php-java/aspose.slides/conformance/#Iso29500-2008-Strict) را تنظیم کنید. سپس گزینه‌ها را به متد [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#save) پاس دهید.

```php
use aspose\slides\Conformance;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

$presentation = new Presentation();
try {
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **ذخیره ارائه‌ها در فرمت Office Open XML در حالت Zip64**

یک آرشیو ZIP استاندارد اندازهٔ فشرده و غیر فشرده هر ورودی، کل اندازهٔ آرشیو و تعداد ورودی‌ها را محدود می‌کند. از آنجا که یک فایل PPTX یک آرشیو ZIP است، یک ارائهٔ بسیار بزرگ می‌تواند این محدودیت‌ها را عبور کند. افزونه‌های Zip64 محدودیت‌های مربوط به اندازه و تعداد ورودی‌ها را افزایش می‌دهند.

از متد [PptxOptions::setZip64Mode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxoptions/#setZip64Mode) برای کنترل اینکه آیا Aspose.Slides افزونه‌های ZIP64 می‌نویسد یا نه استفاده کنید:

- [IfNecessary](https://reference.aspose.com/slides/fa/php-java/aspose.slides/zip64mode/#IfNecessary) فقط زمانی از ZIP64 استفاده می‌کند که ارائه از محدودیت‌های استاندارد ZIP عبور کند. این حالت پیش‌فرض است.
- [Never](https://reference.aspose.com/slides/fa/php-java/aspose.slides/zip64mode/#Never) افزونه‌های ZIP64 را غیرفعال می‌کند.
- [Always](https://reference.aspose.com/slides/fa/php-java/aspose.slides/zip64mode/#Always) همیشه افزونه‌های ZIP64 را می‌نویسد.

مثال زیر همیشه افزونه‌های ZIP64 را برای ارائهٔ خروجی فعال می‌کند:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\Zip64Mode;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setZip64Mode(Zip64Mode::Always);

    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
اگر [Zip64Mode::Never](https://reference.aspose.com/slides/fa/php-java/aspose.slides/zip64mode/#Never) استفاده شود و ارائه نتواند در محدودیت‌های استاندارد ZIP جای بگیرد، عملیات ذخیره‌سازی یک [PptxException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxexception/) را پرتاب می‌کند.
{{% /alert %}}

## **ذخیره ارائه‌ها در فرمت Office Open XML با سطوح فشرده‌سازی**

برای خروجی PPTX، می‌توانید با استفاده از متد [PptxOptions::setCompressionLevel](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxoptions/#setCompressionLevel) سرعت ذخیره‌سازی را در مقابل اندازهٔ فایل متعادل کنید. کلاس [CompressionLevel](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compressionlevel/) این مقادیر را ارائه می‌دهد:

- [None](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compressionlevel/#None) داده‌ها را بدون فشرده‌سازی ذخیره می‌کند.
- [Level1](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compressionlevel/#Level1) سریع‌ترین فشرده‌سازی و بزرگ‌ترین خروجی فشرده را فراهم می‌کند.
- [Level2](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compressionlevel/#Level2) تا [Level5](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compressionlevel/#Level5) به‌تدریج خروجی کوچکتر را به قیمت سرعت ذخیره‌سازی ترجیح می‌دهند.
- [Level6](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compressionlevel/#Level6) بین سرعت ذخیره و اندازهٔ فایل تعادل برقرار می‌کند. این سطح پیش‌فرض است.
- [Level7](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compressionlevel/#Level7) و [Level8](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compressionlevel/#Level8) بیشتر خروجی کوچکتر را نسبت به سرعت ذخیره ترجیح می‌دهند.
- [Level9](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compressionlevel/#Level9) قوی‌ترین فشرده‌سازی را فراهم می‌کند و بیشترین زمان پردازش را می‌طلبد.

مثال زیر یک ارائه را بدون فشرده‌سازی ذخیره می‌کند:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::None);

    $presentation->save("OutputNoCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

مثال زیر از حداکثر سطح فشرده‌سازی استفاده می‌کند:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::Level9);

    $presentation->save("OutputMaximumCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **ذخیره ارائه‌ها بدون به‌روزرسانی تصویر بندانگشتی**

هنگام ذخیرهٔ یک ارائه به صورت PPTX، متد [PptxOptions::setRefreshThumbnail](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) تصویر بندانگشتی سند را کنترل می‌کند:

- `true` تصویر بندانگشتی را در طول عملیات ذخیره بازسازی می‌کند. این مقدار پیش‌فرض است.
- `false` تصویر بندانگشتی موجود را حفظ می‌کند. اگر ارائه تصویر بندانگشتی نداشته باشد، Aspose.Slides هیچ‌کدام را تولید نمی‌کند.

مثال زیر یک ارائه را بدون به‌روزرسانی تصویر بندانگشتی ذخیره می‌کند:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setRefreshThumbnail(false);

    $presentation->save("Output.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
غیرفعال‌سازی به‌روزرسانی تصویر بندانگشتی می‌تواند زمان مورد نیاز برای ذخیرهٔ فایل PPTX را کاهش دهد.
{{% /alert %}}

## **به‌روزرسانی پیشرفت ذخیره به درصد**

برای نظارت بر یک عملیات ذخیره، یک پروکسی Java که رابط [IProgressCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprogresscallback/) را پیاده‌سازی می‌کند، فراهم کنید و این پروکسی را به متد [SaveOptions::setProgressCallback](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveoptions/#setProgressCallback) پاس دهید. سپس Aspose.Slides متد [IProgressCallback::reporting](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprogresscallback/#reporting-double-) را با مقادیر پیشرفت در طول خروجی فراخوانی می‌کند.

مثال زیر پیشرفت یک خروجی PDF را به کنسول گزارش می‌دهد:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class ExportProgressHandler {
    function reporting($progressValue) {
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted." . PHP_EOL);
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$options = new PdfOptions();
$options->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
آسپوز یک ابزار رایگان [PowerPoint Splitter](https://products.aspose.app/slides/fa/splitter) ارائه می‌دهد که با API Aspose.Slides ساخته شده است. این ابزار اسلایدهای انتخاب‌شده را از یک ارائه به صورت فایل‌های جداگانه PPT یا PPTX ذخیره می‌کند.
{{% /alert %}}

## **سوالات متداول**

**آیا Aspose.Slides از ذخیره incremental یا “ذخیره سریع” پشتیبانی می‌کند؟**

خیر. هر عملیات ذخیره یک فایل خروجی کامل می‌نویسد و فقط بخش‌های تغییر یافته را به‌روز نمی‌کند.

**آیا چندین رشته می‌توانند همان نمونهٔ Presentation را ذخیره کنند؟**

خیر. یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) [thread‑safe نیست](/slides/fa/php-java/multithreading/). دسترسی و ذخیره هر نمونه باید فقط از یک رشته به‌صورت همزمان انجام شود.

**چه اتفاقی برای پیوندهای فراگیر و فایل‌های لینک‌شده خارجی رخ می‌دهد وقتی یک ارائه را ذخیره می‌کنم؟**

[Hyperlinks](/slides/fa/php-java/manage-hyperlinks/) در ارائه باقی می‌مانند. Aspose.Slides فایل‌های لینک‌شده خارجی را کپی نمی‌کند، بنابراین ارائهٔ ذخیره‌شده باید همچنان قادر به دسترسی به مکان‌های آن‌ها باشد.

**آیا می‌توانم متادیتای سند مانند نویسنده، عنوان، شرکت و تاریخ ایجاد را ذخیره کنم؟**

بله. قبل از ذخیره، [ویژگی‌های سند](/slides/fa/php-java/presentation-properties/) مناسب را تنظیم کنید و Aspose.Slides آنها را در فایل خروجی می‌نویسد.