---
title: ذخیره ارائه‌ها در PHP
linktitle: ذخیره ارائه
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
- قالب Strict Office Open XML
- حالت Zip64
- تجدید تصویر بندانگشتی
- پیشرفت ذخیره
- PHP
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید ارائه‌ها را با استفاده از Aspose.Slides برای PHP از طریق Java ذخیره کنید — به PowerPoint یا OpenDocument صادر کنید در حالی که طرح‌ها، قلم‌ها و افکت‌ها حفظ می‌شوند."
---
## **بررسی کلی**

[Open Presentations in PHP](/slides/fa/php-java/open-presentation/) توضیح می‌دهد که چگونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) برای باز کردن یک ارائه استفاده کنید. این مقاله نحوه ایجاد و ذخیره ارائه‌ها را شرح می‌دهد. کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) شامل محتوای یک ارائه است. چه از ابتدا یک ارائه ایجاد کنید و چه یک ارائه موجود را ویرایش کنید، پس از اتمام می‌خواهید آن را ذخیره کنید. با Aspose.Slides برای PHP می‌توانید به **file** یا **stream** ذخیره کنید. این مقاله روش‌های مختلف ذخیره یک ارائه را توضیح می‌دهد.

## **ذخیره ارائه‌ها در فایل‌ها**

برای ذخیره یک ارائه در یک فایل، متد `save` کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) را فراخوانی کنید. نام فایل و قالب ذخیره را به متد بدهید. مثال زیر نحوه ذخیره یک ارائه با Aspose.Slides را نشان می‌دهد.

```php
// ایجاد نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است.
$presentation = new Presentation();
try {
    // کاری را اینجا انجام دهید...

    // ارائه را به یک فایل ذخیره کنید.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ذخیره ارائه‌ها در جریان‌ها**

می‌توانید یک ارائه را به یک جریان ذخیره کنید با این‌که یک جریان خروجی را به متد `save` کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) بدهید. یک ارائه می‌تواند به انواع مختلفی از جریان‌ها نوشته شود. در مثال زیر، یک ارائه جدید ایجاد می‌کنیم و آن را به یک جریان فایل ذخیره می‌کنیم.

```php
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // ارائه را به جریان ذخیره کنید.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **ذخیره ارائه‌ها با نوع نمای پیش‌تعریف‌شده**

Aspose.Slides به شما امکان می‌دهد نمای اولیه‌ای که PowerPoint هنگام باز شدن ارائه تولید شده استفاده می‌کند، از طریق کلاس [ViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewproperties/) تنظیم کنید. از متد [setLastView](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewproperties/#setLastView) با مقداری از شمارش [ViewType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewtype/) استفاده کنید.

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ذخیره ارائه‌ها در فرمت Strict Office Open XML**

Aspose.Slides به شما امکان می‌دهد ارائه‌ای را در فرمت Strict Office Open XML ذخیره کنید. از کلاس [PptxOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxoptions/) استفاده کنید و هنگام ذخیره، ویژگی conformance آن را تنظیم کنید. اگر مقدار [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/fa/php-java/aspose.slides/conformance/#Iso29500_2008_Strict) را تنظیم کنید، فایل خروجی در فرمت Strict Office Open XML ذخیره می‌شود.

مثال زیر یک ارائه ایجاد می‌کند و آن را در فرمت Strict Office Open XML ذخیره می‌کند.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// ایجاد نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است.
$presentation = new Presentation();
try {
    // ارائه را در قالب Strict Office Open XML ذخیره کنید.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **ذخیره ارائه‌ها در فرمت Office Open XML در حالت Zip64**

یک فایل Office Open XML یک آرشیو ZIP است که محدودیت ۴ GB (۲^۳۲ بایت) برای اندازهٔ فشرده‌نشدهٔ هر فایل، اندازهٔ فشردهٔ هر فایل و کل اندازهٔ آرشیو اعمال می‌کند و همچنین تعداد فایل‌ها را به ۶۵ ۵۳۵ (۲^۱۶‑۱) محدود می‌کند. افزونه‌های قالب ZIP64 این محدودیت‌ها را به ۲^۶۴ افزایش می‌دهند.

متد [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxoptions/#setZip64Mode) به شما امکان می‌دهد هنگام ذخیره یک فایل Office Open XML، زمان استفاده از افزونه‌های قالب ZIP64 را انتخاب کنید.

این متد می‌تواند با حالت‌های زیر استفاده شود:

- [IfNecessary](https://reference.aspose.com/slides/fa/php-java/aspose.slides/zip64mode/#IfNecessary) فقط در صورتی از افزونه‌های ZIP64 استفاده می‌کند که ارائه محدودیت‌های فوق را تجاوز کند. این حالت پیش‌فرض است.
- [Never](https://reference.aspose.com/slides/fa/php-java/aspose.slides/zip64mode/#Never) هرگز از افزونه‌های ZIP64 استفاده نمی‌کند.
- [Always](https://reference.aspose.com/slides/fa/php-java/aspose.slides/zip64mode/#Always) همیشه از افزونه‌های ZIP64 استفاده می‌کند.

کد زیر نشان می‌دهد چگونه یک ارائه را به صورت PPTX با فعال‌سازی افزونه‌های قالب ZIP64 ذخیره کنید:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setZip64Mode(Zip64Mode::Always);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
هنگامی که با [Zip64Mode.Never](https://reference.aspose.com/slides/fa/php-java/aspose.slides/zip64mode/#Never) ذخیره می‌کنید، اگر ارائه نتواند در قالب ZIP32 ذخیره شود، یک [PptxException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxexception/) پرتاب می‌شود.
{{% /alert %}}

## **ذخیره ارائه‌ها بدون تجدید تصویر بندانگشتی**

متد [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) تولید تصویر بندانگشتی را هنگام ذخیره یک ارائه به PPTX کنترل می‌کند:

- اگر به `true` تنظیم شود، تصویر بندانگشتی در حین ذخیره تجدید می‌شود. این مقدار پیش‌فرض است.
- اگر به `false` تنظیم شود، تصویر بندانگشتی فعلی حفظ می‌شود. اگر ارائه تصویری بندانگشتی نداشته باشد، هیچ تصویر جدیدی تولید نمی‌شود.

در کد زیر، ارائه بدون تجدید تصویر بندانگشتی به PPTX ذخیره می‌شود.

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setRefreshThumbnail(false);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pptx", SaveFormat::Pptx, $pptxOptions);
}
finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
این گزینه به کاهش زمان مورد نیاز برای ذخیره یک ارائه در قالب PPTX کمک می‌کند.
{{% /alert %}}

## **ذخیره به‌روزرسانی‌های پیشرفت به درصد**

گزارش پیشرفت ذخیره از طریق متد [setProgressCallback](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveoptions/#setProgressCallback) روی کلاس [SaveOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveoptions/) و زیرکلاس‌های آن پیکربندی می‌شود. یک پراکسی Java که رابط [IProgressCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprogresscallback/) را پیاده‌سازی می‌کند فراهم کنید؛ در زمان استخراج، این فراخوانی دوره‌ای به‌روزرسانی‌های درصدی دریافت می‌کند.

قطعه‌های کد زیر نشان می‌دهند چگونه از `IProgressCallback` استفاده کنید.

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // در اینجا از مقدار درصد پیشرفت استفاده کنید.
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted.");
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$saveOptions = new PdfOptions();
$saveOptions->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $saveOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose یک برنامهٔ رایگان [PowerPoint Splitter](https://products.aspose.app/slides/fa/splitter) بر پایه API خود توسعه داده است. این برنامه به شما اجازه می‌دهد یک ارائه را به چندین فایل تقسیم کنید با ذخیرهٔ اسلایدهای انتخابی به‌عنوان فایل‌های جدید PPTX یا PPT.
{{% /alert %}}

## **سوالات متداول**

**آیا «ذخیره سریع» (ذخیره افزایشی) برای نوشتن فقط تغییرات پشتیبانی می‌شود؟**

خیر. هر بار ذخیره یک فایل هدف کامل ایجاد می‌کند؛ «ذخیره سریع» افزایشی پشتیبانی نمی‌شود.

**آیا ذخیرهٔ یک نمونهٔ Presentation از چندین نخ به صورت همزمان ایمن است؟**

خیر. یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) **thread‑safe** نیست؛ آن را فقط از یک نخ ذخیره کنید.

**زمانی که ذخیره می‌کنید، چه اتفاقی برای پیوندهای هیپرلینک و فایل‌های خارجی لینک‌شده می‌افتد؟**

[Hyperlinks](/slides/fa/php-java/manage-hyperlinks/) حفظ می‌شوند. فایل‌های خارجی لینک‌شده (مثلاً ویدئوها با مسیرهای نسبی) به‌صورت خودکار کپی نمی‌شوند—اطمینان حاصل کنید مسیرهای مرجع قابل دسترس باقی بمانند.

**آیا می‌توانم متادیتای سند (نویسنده، عنوان، شرکت، تاریخ) را تنظیم/ذخیره کنم؟**

بله. ویژگی‌های استاندارد [document properties](/slides/fa/php-java/presentation-properties/) پشتیبانی می‌شوند و هنگام ذخیره در فایل نوشته می‌شوند.