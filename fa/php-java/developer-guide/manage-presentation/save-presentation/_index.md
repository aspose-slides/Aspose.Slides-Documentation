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
- تازه‌سازی تصویر بندانگشتی
- پیشرفت ذخیره‌سازی
- PHP
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید ارائه‌ها را با استفاده از Aspose.Slides برای PHP از طریق Java ذخیره کنید — صادر کردن به PowerPoint یا OpenDocument در حالی که طرح‌ها، قلم‌ها و افکت‌ها حفظ می‌شوند."
---
## **مروری کلی**

[Open Presentations in PHP](/slides/fa/php-java/open-presentation/) نحوه استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) برای باز کردن یک ارائه را توصیف کرد. این مقاله توضیح می‌دهد چگونه ارائه‌ها را ایجاد و ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) شامل محتوای یک ارائه است. چه از ابتدا یک ارائه ایجاد کنید و چه یک ارائه موجود را ویرایش کنید، در پایان می‌خواهید آن را ذخیره کنید. با Aspose.Slides برای PHP می‌توانید به **فایل** یا **جریان** (stream) ذخیره کنید. این مقاله روش‌های مختلف ذخیره یک ارائه را توضیح می‌دهد.

## **ذخیره ارائه‌ها در فایل‌ها**

یک ارائه را با فراخوانی متد `save` کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) به یک فایل ذخیره کنید. نام فایل و قالب ذخیره‌سازی را به متد پاس دهید. مثال زیر نشان می‌دهد چگونه یک ارائه را با Aspose.Slides ذخیره کنید.

```php
// یک شیء از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
$presentation = new Presentation();
try {
    // در اینجا برخی کارها انجام دهید...

    // ارائه را در یک فایل ذخیره کنید.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ذخیره ارائه‌ها در جریان‌ها**

می‌توانید یک ارائه را با پاس کردن یک جریان خروجی به متد `save` کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) در یک جریان ذخیره کنید. یک ارائه می‌تواند به انواع مختلف جریان‌ها نوشته شود. در مثال زیر، یک ارائه جدید می‌سازیم و آن را در یک جریان فایل ذخیره می‌کنیم.

```php
// یک شیء از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // ارائه را در جریان ذخیره کنید.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **ذخیره ارائه‌ها با نوع نمایش پیش‌تعریف‌شده**

Aspose.Slides به شما امکان می‌دهد نمای اولیه‌ای که PowerPoint هنگام باز شدن ارائه تولید شده استفاده می‌کند را از طریق کلاس [ViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewproperties/) تنظیم کنید. از متد [setLastView](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewproperties/#setLastView) با مقداری از شمارش‌گر [ViewType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewtype/) استفاده کنید.

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ذخیره ارائه‌ها در قالب Strict Office Open XML**

Aspose.Slides به شما امکان می‌دهد یک ارائه را در قالب Strict Office Open XML ذخیره کنید. از کلاس [PptxOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxoptions/) استفاده کنید و ویژگی conformance آن را هنگام ذخیره‌سازی تنظیم کنید. اگر [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/fa/php-java/aspose.slides/conformance/#Iso29500_2008_Strict) را تنظیم کنید، فایل خروجی در قالب Strict Office Open XML ذخیره می‌شود.

مثال زیر یک ارائه ایجاد کرده و آن را در قالب Strict Office Open XML ذخیره می‌کند.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// یک شیء از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
$presentation = new Presentation();
try {
    // ارائه را در قالب Strict Office Open XML ذخیره کنید.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **ذخیره ارائه‌ها در قالب Office Open XML در حالت Zip64**

یک فایل Office Open XML یک آرشیو ZIP است که محدودیت ۴ گیگابایت (۲^۳۲ بایت) برای اندازهٔ فشرده‌نشدهٔ هر فایل، اندازهٔ فشردهٔ هر فایل و کل آرشیو اعمال می‌کند و همچنین تعداد فایل‌ها را به ۶۵٬۵۳۵ (۲^۱۶‑۱) محدود می‌سازد. افزونه‌های فرمت ZIP64 این محدودیت‌ها را به ۲^۶۴ افزایش می‌دهند.

متد [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxoptions/#setZip64Mode) به شما اجازه می‌دهد هنگام ذخیرهٔ یک فایل Office Open XML مشخص کنید چه زمانی از افزونه‌های فرمت ZIP64 استفاده شود.

این متد می‌تواند با حالت‌های زیر استفاده شود:

- [IfNecessary](https://reference.aspose.com/slides/fa/php-java/aspose.slides/zip64mode/#IfNecessary) فقط در صورتی که ارائه محدودیت‌های فوق را تجاوز کند از افزونه‌های ZIP64 استفاده می‌کند. این حالت پیش‌فرض است.
- [Never](https://reference.aspose.com/slides/fa/php-java/aspose.slides/zip64mode/#Never) هرگز از افزونه‌های ZIP64 استفاده نمی‌کند.
- [Always](https://reference.aspose.com/slides/fa/php-java/aspose.slides/zip64mode/#Always) همیشه از افزونه‌های ZIP64 استفاده می‌کند.

کد زیر نشان می‌دهد چگونه یک ارائه را به عنوان فایل PPTX با فعال شدن افزونه‌های فرمت ZIP64 ذخیره کنید:

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
هنگامی که با [Zip64Mode.Never](https://reference.aspose.com/slides/fa/php-java/aspose.slides/zip64mode/#Never) ذخیره می‌کنید، اگر ارائه نتواند در فرمت ZIP32 ذخیره شود، یک [PptxException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxexception/) پرتاب می‌شود.
{{% /alert %}}

## **ذخیره ارائه‌ها در قالب Office Open XML با سطوح فشرده‌سازی**

هنگام کار با ارائه‌های بزرگ، می‌توانید سطح فشرده‌سازی را تنظیم کنید تا بین حجم فایل و زمان پردازش تعادل برقرار کنید. بسته به نیازهای شما ممکن است پردازش سریع‌تر یا فایل‌های خروجی کوچکتر ترجیح داده شود.

Aspose.Slides متد [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxoptions/#setCompressionLevel) را فراهم می‌کند که به شما اجازه می‌دهد سطح فشرده‌سازی استفاده‌شده هنگام ذخیرهٔ یک ارائه در قالب Office Open XML را مشخص کنید.

سطوح فشرده‌سازی موجود عبارتند از:

- [**None**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compressionlevel/#None): هیچ فشرده‌سازی‌ای اعمال نمی‌شود. فایل‌ها همان‌گونه ذخیره می‌شوند.
- [**Level1**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compressionlevel/#Level1): سریع‌ترین فشرده‌سازی با نسبت فشرده‌سازی کم‌ترین.
- [**Level2**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compressionlevel/#Level2): فشرده‌سازی سریع‌تر با نسبت کمی بهتر نسبت به **Level1**.
- [**Level3**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compressionlevel/#Level3): فشرده‌سازی بهتر نسبت به **Level2** با تأثیر متوسط بر زمان پردازش.
- [**Level4**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compressionlevel/#Level4): فشرده‌سازی بهتر نسبت به **Level3**.
- [**Level5**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compressionlevel/#Level5): فشرده‌سازی بالاتر نسبت به **Level4** با زمان پردازش افزوده.
- [**Level6**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compressionlevel/#Level6): فشرده‌سازی استاندارد که تعادل خوبی بین سرعت پردازش و حجم فایل ارائه می‌دهد. این *سطح فشرده‌سازی پیش‌فرض* است.
- [**Level7**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compressionlevel/#Level7): فشرده‌سازی بهتر نسبت به **Level6** با پردازش کندتر.
- [**Level8**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compressionlevel/#Level8): فشرده‌سازی بهتر نسبت به **Level7**.
- [**Level9**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compressionlevel/#Level9): حداکثر فشرده‌سازی. کوچک‌ترین حجم فایل را به هزینهٔ طولانی‌ترین زمان پردازش تولید می‌کند.

مثال زیر نشان می‌دهد چگونه یک ارائه را به عنوان فایل PPTX *بدون فشرده‌سازی* ذخیره کنید:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::None);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-out.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

این مثال نشان می‌دهد چگونه یک ارائه را به عنوان فایل PPTX با *حداکثر فشرده‌سازی* ذخیره کنید:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::Level9);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-level9.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

## **ذخیره ارائه‌ها بدون تازه‌سازی تصویر بندانگشتی**

متد [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) تولید تصویر بندانگشتی را هنگام ذخیرهٔ یک ارائه به PPTX کنترل می‌کند:

- اگر مقدار `true` باشد، تصویر بندانگشتی در زمان ذخیره تازه‌سازی می‌شود. این مقدار پیش‌فرض است.
- اگر مقدار `false` باشد، تصویر بندانگشتی فعلی حفظ می‌شود. اگر ارائه تصویر بندانگشتی نداشته باشد، هیچ‌کدام تولید نمی‌شود.

در کد زیر، ارائه بدون تازه‌سازی تصویر بندانگشتی به PPTX ذخیره می‌شود.

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
این گزینه به کاهش زمان لازم برای ذخیرهٔ یک ارائه در قالب PPTX کمک می‌کند.
{{% /alert %}}

## **به‌روزرسانی پیشرفت ذخیره به درصد**

گزارش‌گری پیشرفت ذخیره‌سازی از طریق متد [setProgressCallback](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveoptions/#setProgressCallback) در کلاس [SaveOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveoptions/) و زیرکلاس‌های آن تنظیم می‌شود. یک پروکسی Java که رابط [IProgressCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprogresscallback/) را پیاده‌سازی می‌کند ارائه کنید؛ در طول خروجی، این callback به‌صورت دوره‌ای به‌روزرسانی‌های درصدی دریافت می‌کند.

کدهای زیر نشان می‌دهند چگونه از `IProgressCallback` استفاده کنید.

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // از مقدار درصد پیشرفت در اینجا استفاده کنید.
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
Aspose یک برنامهٔ رایگان **PowerPoint Splitter** (https://products.aspose.app/slides/fa/splitter) را با استفاده از API خود توسعه داده است. این برنامه به شما اجازه می‌دهد یک ارائه را به چندین فایل تقسیم کنید و اسلایدهای انتخابی را به‌عنوان فایل‌های جدید PPTX یا PPT ذخیره کنید.
{{% /alert %}}

## **سؤالات متداول**

**آیا «ذخیره سریع» (ذخیره افزایشی) پشتیبانی می‌شود تا فقط تغییرات نوشته شوند؟**

خیر. هر بار ذخیره یک فایل هدف کامل ایجاد می‌کند؛ «ذخیره سریع» افزایشی پشتیبانی نمی‌شود.

**آیا ذخیرهٔ همان شیء Presentation از چندین رشته همزمان ایمن است؟**

خیر. یک شیء [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) **thread‑safe** نیست؛ آن را فقط از یک رشته ذخیره کنید.

**هنگام ذخیره چه اتفاقی برای پیوندهای هیپرتکست و فایل‌های پیوند خارجی می‌افتد؟**

[Hyperlinks](/slides/fa/php-java/manage-hyperlinks/) حفظ می‌شوند. فایل‌های پیوند خارجی (مثلاً ویدئوها با مسیرهای نسبی) به‌صورت خودکار کپی نمی‌شوند؛ اطمینان حاصل کنید مسیرهای ارجاعی در دسترس باقی بمانند.

**آیا می‌توان متادیتای سند (نویسنده، عنوان، شرکت، تاریخ) را تنظیم/ذخیره کرد؟**

بله. ویژگی‌های استاندارد [document properties](/slides/fa/php-java/presentation-properties/) پشتیبانی می‌شوند و در زمان ذخیره به فایل نوشته می‌شوند.