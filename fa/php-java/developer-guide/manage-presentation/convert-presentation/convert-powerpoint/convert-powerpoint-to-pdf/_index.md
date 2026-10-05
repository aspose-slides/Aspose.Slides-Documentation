---
title: تبدیل PPT و PPTX به PDF در PHP [ویژگی‌های پیشرفته گنجانده‌شده]
linktitle: PowerPoint به PDF
type: docs
weight: 40
url: /fa/php-java/convert-powerpoint-to-pdf/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- PowerPoint به PDF
- ارائه به PDF
- PPT به PDF
- تبدیل PPT به PDF
- PPTX به PDF
- تبدیل PPTX به PDF
- ذخیره PowerPoint به عنوان PDF
- ذخیره PPT به عنوان PDF
- ذخیره PPTX به عنوان PDF
- صادر کردن PPT به PDF
- صادر کردن PPTX به PDF
- پیوست
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "تبدیل PowerPoint PPT/PPTX به PDFهای با کیفیت بالا و قابل جستجو در PHP با استفاده از Aspose.Slides، همراه با مثال‌های سریع کد و گزینه‌های پیشرفته تبدیل."
---
## **مرور کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به فرمت PDF در PHP مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ طرح‌بندی و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای پنهان را شامل کنید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی فونت‌ها را تشخیص دهید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای انطباق را بر اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides، می‌توانید ارائه‌ها را در قالب‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) پاس دهید و سپس ارائه را با استفاده از متد [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) به PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) متد [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) را فراهم می‌کند که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{% alert color="info" title="Note" %}}
Aspose.Slides برای PHP از طریق Java اطلاعات API و شماره نسخه خود را در اسناد خروجی درج می‌کند. به عنوان مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقداری به شکل "*Aspose.Slides v XX.XX*" پر می‌کند. **Note** اینکه نمی‌توانید Aspose.Slides را مجبور کنید این اطلاعات را از اسناد خروجی حذف یا تغییر دهد.
{{% /alert %}}

Aspose.Slides به شما اجازه می‌دهد:

* تمام ارائه‌ها را به PDF تبدیل کنید
* اسلایدهای خاصی از یک ارائه را به PDF تبدیل کنید

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد فایل‌های PDF حاصل به‌دقت با ارائه‌های اصلی مطابقت داشته باشند. عناصر و ویژگی‌ها در حین تبدیل به‌صورت دقیق رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و شکل‌ها
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندهای فراخوانی
* سرصفحه و پاورقی
* گلوله‌ها
* جداول

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائه ارائه‌شده را با تنظیمات بهینه و بیشترین سطح کیفیت به PDF تبدیل کند.

مثال زیر یک ارائه را بارگذاری می‌کند و تمام اسلایدهای قابل مشاهده را با تنظیمات پیش‌فرض خروجی به PDF ذخیره می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose یک مبدل آنلاین رایگان [**مبدل PowerPoint به PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با استفاده از این مبدل یک تست زنده از روش شرح داده‌شده انجام دهید.
{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—ویژگی‌هایی تحت کلاس [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)—را فراهم می‌کند که به شما اجازه می‌دهد PDF حاصل را سفارشی کنید، PDF را با رمز عبور قفل کنید یا مشخص کنید فرآیند تبدیل چگونه پیش رود.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی می‌توانید تنظیم کیفیت دلخواه برای تصاویر رستری را تعریف کنید، نحوه‌ٔ پردازش متافایل‌ها را مشخص کنید، سطح فشرده‌سازی متن را تنظیم کنید، DPI تصاویر را پیکربندی کنید و موارد دیگر.

مثال زیر ارائه‌ای را به PDF 1.5 صادر می‌کند که کیفیت JPEG برابر 90، وضوح تصویر 300 DPI، متافایل‌ها به صورت PNG ذخیره می‌شوند و فشرده‌سازی متن به صورت Flate اعمال می‌شود.

```php
use aspose\slides\PdfCompliance;
use aspose\slides\PdfOptions;
use aspose\slides\PdfTextCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setJpegQuality(90);
$pdfOptions->setSufficientResolution(300);
$pdfOptions->setSaveMetafilesAsPng(true);
$pdfOptions->setTextCompression(PdfTextCompression::Flate);
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **حفظ فایل‌های OLE تعبیه‌شده به‌عنوان پیوست‌های PDF**

اگر ارائه شامل یک کارنامه Excel تعبیه‌شده باشد، ممکن است بخواهید دریافت‌کنندگان PDF به داده‌های کارنامه دسترسی داشته باشند و همچنین اسلایدها را مشاهده کنند. برای حفظ فایل‌های OLE تعبیه‌شده به‌عنوان پیوست در PDF، متد [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) را با مقدار `true` فراخوانی کنید.

مقدار پیش‌فرض `false` است: تصویر پیش‌نمایش یا آیکون شی OLE روی صفحه PDF رندر می‌شود، اما فایل تعبیه‌شده به‌عنوان پیوست گنجانده نمی‌شود. تنظیم این گزینه به `true` علاوه بر پیش‌نمایش، داده‌های فایل را نیز شامل می‌شود. پیش‌نمایش همچنان یک نمایش بصری باقی می‌ماند؛ پیوست به دریافت‌کنندگان امکان می‌دهد فایل تعبیه‌شده را به‌صورت جداگانه باز یا ذخیره کنند. شی OLE تبدیل به یک کاربرگ Excel تعاملی در صفحه PDF نمی‌شود.

مثال زیر یک ارائه که از قبل شامل یک کارنامه Excel تعبیه‌شده است بارگذاری می‌کند و آن را به PDF با پیوست کارنامه صادر می‌کند.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setIncludeOleData(true);

$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

برای بررسی نتیجه:

1. PDF صادرشده را در نمایشی باز کنید که از پیوست‌های فایل پشتیبانی می‌کند، مانند Adobe Acrobat Reader.
2. پنل **Attachments** Viewer را باز کنید و کارنامه تعبیه‌شده را پیدا کنید.
3. پیوست را ذخیره کنید و در Excel باز کنید تا داده‌های آن را بررسی کنید، یا در صورت امکان مستقیماً آن را باز کنید. پیش‌نمایش در صفحه PDF به‌صورت جدا از پیوست است.

{{% alert color="info" title="Note" %}}
استانداردهای PDF/A محدودیتی بر پیوست‌ها اعمال می‌کنند: PDF/A-1 از فایل‌های تعبیه‌شده منع می‌کند، PDF/A-2 تنها پیوست‌های PDF/A را اجازه می‌دهد و PDF/A-3 انواع دیگر فایل‌ها از جمله کارنامه‌های Excel را می‌پذیرد. این موارد الزامات استانداردهاست، نه محدودیت‌های خاص Aspose.Slides. این مثال از تنظیم پیش‌فرض انطباق PDF استفاده می‌کند و خروجی PDF/A را نشان نمی‌دهد.
{{% /alert %}}

### **تبدیل PowerPoint به PDF با اسلایدهای پنهان**

اگر ارائه شامل اسلایدهای پنهان باشد، می‌توانید با استفاده از متد [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) از کلاس [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) اسلایدهای پنهان را به‌عنوان صفحات در PDF نهایی گنجانید.

مثال زیر ارائه‌ای را به PDF صادر می‌کند که شامل هر اسلاید پنهان می‌شود.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setShowHiddenSlides(true);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **تبدیل PowerPoint به PDF با رمز عبور**

مثال زیر ارائه‌ای را به PDF صادر می‌کند که برای باز کردن نیاز به رمز عبور `password` دارد. مجوزهای دسترسی اجازه چاپ، از جمله چاپ با کیفیت بالا، را می‌دهند.

```php
use aspose\slides\PdfAccessPermissions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setPassword("password");
$pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **تشخیص جایگزینی فونت‌ها**

Aspose.Slides متد [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) ارائه می‌کند تا بتوانید در طول فرآیند تبدیل ارائه به PDF جایگزینی فونت‌ها را تشخیص دهید.

مثال زیر ارائه‌ای را به PDF صادر می‌کند و هشدارهای جایگزینی فونت را در کنسول چاپ می‌کند. هشدار فقط زمانی چاپ می‌شود که فونتی در دسترس نباشد و در حین خروجی‌گیری جایگزین شود.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));

$pdfOptions = new PdfOptions();
$pdfOptions->setWarningCallback($warningCallback);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
برای اطلاعات بیشتر در مورد جایگزینی فونت‌ها، مقاله [**جایگزینی فونت**](/slides/fa/php-java/font-substitution/) را مشاهده کنید.
{{% /alert %}}

## **تبدیل اسلایدهای منتخب از PowerPoint به PDF**

مثال زیر اسلایدهای 1 و 3 را از یک ارائه به PDF صادر می‌کند. شماره‌های اسلاید در این آرایه یک‌پایه هستند و ارائه ورودی باید حداقل دارای سه اسلاید باشد.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $slides = array(1, 3);
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **تبدیل PowerPoint به PDF با اندازه سفارشی اسلاید**

مثال زیر اولین اسلاید را از یک ارائه به یک ارائه جدید با اندازه اسلاید 612 × 792 نقطه (8.5 × 11 اینچ) کپی می‌کند. محتویات اسلاید را برای جاگذاری مقیاس می‌دهد و اسلاید تک را به PDF صادر می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$slideWidth = 612.0;
$slideHeight = 792.0;

$presentation = new Presentation("SelectedSlides.pptx");
$resizedPresentation = new Presentation();

try {
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    // اسلاید خالی که ارائه جدید با آن ایجاد شده بود را حذف کنید.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **تبدیل PowerPoint به PDF در نمای اسلایدهای یادداشت**

مثال زیر ارائه‌ای را به PDF صادر می‌کند به‌طوری که یادداشت‌های سخنران هر اسلاید زیر اسلاید قرار می‌گیرد. برای مشاهده نتیجه، از یک ارائه حاوی یادداشت‌های سخنران استفاده کنید.

```php
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull);

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

$presentation = new Presentation("SelectedSlides.pptx");
try {
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **استانداردهای دسترسی‌پذیری و انطباق برای PDF**

Aspose.Slides به شما امکان می‌دهد از رویه‌ی تبدیل استفاده کنید که با [راهنمایی‌های دسترسی به محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار باشد. می‌توانید سند PowerPoint را به PDF صادر کنید با استفاده از هر یک از این استانداردهای انطباق: **PDF/A1a**, **PDF/A1b**, و **PDF/UA**.

این کد یک فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که بر اساس استانداردهای انطباق مختلف، چندین PDF تولید می‌کند:

```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose.Slides از عملیات تبدیل PDF پشتیبانی می‌کند و به شما اجازه می‌دهد فایل‌های PDF را به فرمت‌های محبوب دیگر تبدیل کنید. می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/)، [PDF به تصویر](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/)، [PDF به JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/)، و [PDF به PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) را انجام دهید. سایر عملیات تبدیل PDF به فرمت‌های تخصصی‌ مانند [PDF به SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/)، و [PDF به XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) نیز پشتیبانی می‌شود.
{{% /alert %}}

> **Note:** هنگام خروجی‌گیری به PDF/UA، Aspose.Slides گرافیک‌های پیچیده‌ای مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر به‌صورت جداگانه حفظ نمی‌شوند و ممکن است به‌عنوان اجسام مصنوعی علامت‌گذاری شوند؛ متن جایگزینی فقط برای کل شکل فراهم می‌شود.

## **سؤالات متداول**

**آیا می‌توانم چندین فایل PowerPoint را به‌صورت دسته‌ای به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی بر روی فایل‌های خود تکرار کنید و فرآیند تبدیل را اعمال نمایید.

**آیا امکان حفاظت از PDF تبدیل‌شده با رمز عبور وجود دارد؟**

بله. با استفاده از کلاس [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) می‌توانید یک رمز عبور تنظیم کنید و مجوزهای دسترسی را در طول فرآیند تبدیل تعریف کنید.

**چگونه اسلایدهای پنهان را در PDF گنجانده کنم؟**

در کلاس [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) متد [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) را با مقدار `true` فراخوانی کنید تا اسلایدهای پنهان در PDF نهایی گنجانده شوند.

**آیا Aspose.Slides می‌تواند کیفیت بالای تصویر را در PDF حفظ کند؟**

بله، می‌توانید با استفاده از متدهای [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setJpegQuality) و [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setSufficientResolution) در کلاس [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) کیفیت تصویر را کنترل کنید تا تصاویر با کیفیت بالا در PDF شما خروجی شوند.

**آیا Aspose.Slides استانداردهای انطباق PDF/A را پشتیبانی می‌کند؟**

بله، Aspose.Slides به شما امکان می‌دهد PDFهایی صادر کنید که با [استانداردهای مختلف](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/) از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند و اطمینان حاصل کنید اسناد شما نیازهای دسترسی‌پذیری و بایگانی را برآورده می‌کند.

## **منابع اضافی**

- [مستندات Aspose.Slides برای PHP از طریق Java](/slides/fa/php-java/)
- [مرجع API Aspose.Slides برای PHP از طریق Java](https://reference.aspose.com/slides/php-java/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/conversion)