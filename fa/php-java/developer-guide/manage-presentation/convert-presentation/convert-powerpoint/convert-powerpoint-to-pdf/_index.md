---
title: تبدیل PPT و PPTX به PDF در PHP [دارای ویژگی‌های پیشرفته]
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
description: "تبدیل PowerPoint PPT/PPTX به PDFهای با کیفیت بالا و قابل جستجو در PHP با استفاده از Aspose.Slides، همراه با مثال‌های کد سریع و گزینه‌های پیشرفتهٔ تبدیل."
---
## **نمای کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به فرمت PDF در PHP مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ چیدمان و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را شامل کنید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی‌های قلم را شناسایی کنید، اسلایدهای خاص را برای تبدیل انتخاب کنید و استانداردهای سازگاری را بر اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides، می‌توانید ارائه‌ها را در قالب‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [ارائه](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) بدهید و سپس با استفاده از متد [ذخیره](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) ارائه را به صورت PDF ذخیره کنید. کلاس [ارائه](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) متد [ذخیره](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) را ارائه می‌دهد که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java اطلاعات API و شماره نسخه خود را در اسناد خروجی درج می‌کند. برای مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقداری به شکل "*Aspose.Slides v XX.XX*" پر می‌کند. **توجه** داشته باشید که نمی‌توانید به Aspose.Slides بگویید این اطلاعات را در اسناد خروجی تغییر یا حذف کند.
{{% /alert %}}

Aspose.Slides به شما امکان تبدیل را می‌دهد:

* کل ارائه‌ها به PDF
* اسلایدهای خاص از یک ارائه به PDF

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد که PDF‌های خروجی به‌دقت با ارائه‌های اصلی مطابقت داشته باشند. عناصر و ویژگی‌ها در تبدیل به‌درستی رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندها
* سرصفحه‌ها و پاورنه‌ها
* گلوله‌ها
* جداول

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائه ارائه‌شده را به PDF تبدیل کند با استفاده از تنظیمات بهینه در سطوح کیفیت حداکثری.

مثال زیر یک ارائه را بارگذاری می‌کند و همه اسلایدهای قابل مشاهده را با استفاده از تنظیمات صادرات پیش‌فرض به PDF ذخیره می‌کند.

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
Aspose یک [**مبدل PowerPoint به PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) آنلاین رایگان ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک تست زنده از روش توضیح داده شده در اینجا انجام دهید.
{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—ویژگی‌های تحت کلاس [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)—را فراهم می‌کند که به شما اجازه می‌دهد PDF خروجی را سفارشی کنید، PDF را با رمز عبور قفل کنید یا مشخص کنید فرآیند تبدیل چگونه پیش برود.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی تبدیل، می‌توانید تنظیم کیفیت دلخواه خود را برای تصاویر رستر، نحوه پردازش متافایل‌ها، سطح فشرده‌سازی متن، DPI برای تصاویر و موارد دیگر تعریف کنید.

مثال زیر یک ارائه را به PDF 1.5 صادر می‌کند با کیفیت JPEG تنظیم‌شده بر 90، وضوح تصویر تنظیم‌شده بر 300 DPI، متافایل‌ها به‌صورت PNG ذخیره می‌شوند و فشرده‌سازی متن Flate اعمال می‌شود.

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

### **انتخاب خودکار فشرده‌سازی تصویر**

هنگامی که یک ارائه شامل تعداد زیادی عکسبرداری یا اسکرین‌شات است، کاهش اندازه PDF صادرشده می‌تواند ارسال ایمیل یا دانلود را آسان‌تر کند. فراخوانی [PdfOptions::setBestImagesCompressionRatio](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) با `true` به‌طور خودکار مناسب‌ترین الگوریتم فشرده‌سازی را برای هر تصویر هنگام خروجی PDF انتخاب می‌کند.

مثال زیر یک ارائه موجود را بارگذاری می‌کند، انتخاب خودکار فشرده‌سازی تصویر را فعال می‌کند و آن را به‌عنوان سند PDF ذخیره می‌کند. تمام تنظیمات دیگر خروجی PDF ارزش پیش‌فرض خود را حفظ می‌کنند.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setBestImagesCompressionRatio(true);

$presentation = new Presentation("image-heavy.pptx");
try {
    $presentation->save("image-heavy.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

این گزینه الگوریتم فشرده‌سازی را برای هر تصویر انتخاب می‌کند. کاهش مقدار داده‌شده به [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) به‌جای این که کیفیت تصویر JPEG را کاهش دهد، در حالی که کاهش مقدار داده‌شده به [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) اجازه می‌دهد تصاویر به وضوح پایین‌تری کاهش نمونه شوند که می‌تواند جزئیات را کاهش دهد. فعال‌سازی انتخاب خودکار فشرده‌سازی به‌تنهایی هیچ‌یک از این تنظیمات را کاهش نمی‌دهد.

انتخاب الگوریتم‌های فشرده‌سازی تصویر نیاز به زمان پردازش و حافظه بیشتر دارد. کاهش اندازه به تصاویر و تنظیمات خروجی ارائه بستگی دارد؛ کاهش ثابت برای هر ارائه تضمین نمی‌شود.

### **حفظ فایل‌های OLE جاسازی‌شده به‌عنوان پیوست‌های PDF**

اگر یک ارائه شامل یک کتاب‌کار Excel جاسازی‌شده باشد، ممکن است بخواهید دریافت‌کنندگان PDF به داده‌های کتاب‌کار دسترسی داشته باشند و همزمان اسلایدها را ببینند. فراخوانی [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) با `true` فایل‌های OLE جاسازی‌شده را به‌عنوان پیوست در PDF حاصل حفظ می‌کند.

مقدار پیش‌فرض `false` است: تصویر پیش‌نمایش یا آیکون شیء OLE روی صفحه PDF رندر می‌شود، اما فایل جاسازی‌شده به‌عنوان پیوست شامل نمی‌شود. تنظیم گزینه به `true` علاوه بر این دادهٔ فایل را نیز شامل می‌شود. پیش‌نمایش همچنان یک نمایش بصری است؛ پیوست به دریافت‌کنندگان اجازه می‌دهد فایل جاسازی‌شده را به‌صورت جداگانه باز یا ذخیره کنند. شیء OLE تبدیل به یک ورک‌شیت تعاملی Excel در صفحه PDF نمی‌شود.

مثال زیر یک ارائه که قبلاً شامل یک کتاب‌کار Excel جاسازی‌شده است بارگذاری می‌کند و آن را به PDF با کتاب‌کار پیوست‌شده صادر می‌کند.

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

1. PDF صادرشده را در یک نمایشگری که از پیوست‌های فایل پشتیبانی می‌کند، مانند Adobe Acrobat Reader، باز کنید.
2. پنل **Attachments** نمایشگر را باز کنید و کتاب‌کار جاسازی‌شده را پیدا کنید.
3. پیوست را ذخیره کنید و در Excel باز کنید تا داده‌ها را بررسی کنید، یا اگر نمایشگر اجازه می‌دهد مستقیم باز کنید. پیش‌نمایش روی صفحه PDF جدا از پیوست است.

{{% alert color="info" title="Note" %}}
استانداردهای PDF/A محدودیت‌هایی برای پیوست‌ها اعمال می‌کنند: PDF/A-1 از فایل‌های جاسازی‌شده ممنوع می‌شود، PDF/A-2 فقط پیوست‌های PDF/A را اجازه می‌دهد و PDF/A-3 انواع فایل‌های دیگر از جمله کتاب‌کارهای Excel را مجاز می‌داند. این‌ها الزامات استانداردهاست، نه محدودیت‌های خاص Aspose.Slides. این مثال از تنظیم پیش‌فرض سازگاری PDF استفاده می‌کند و صادرات PDF/A را نشان نمی‌دهد.
{{% /alert %}}

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر یک ارائه شامل اسلایدهای مخفی باشد، می‌توانید از متد [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) در کلاس [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) استفاده کنید تا اسلایدهای مخفی را به‌عنوان صفحات در PDF نهایی شامل کنید.

مثال زیر یک ارائه را به PDF صادر می‌کند و تمام اسلایدهای مخفی را نیز شامل می‌شود.

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

### **تبدیل PowerPoint به PDF با حفاظت با رمز عبور**

مثال زیر یک ارائه را به PDF صادر می‌کند که برای باز کردن نیاز به رمز عبور `password` دارد. مجوزهای دسترسی اجازه چاپ، از جمله چاپ با کیفیت بالا، را می‌دهند.

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

### **تشخیص جایگزینی قلم‌ها**

Aspose.Slides متد [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) فراهم می‌کند که به شما امکان می‌دهد در فرآیند تبدیل ارائه به PDF، جایگزینی‌های قلم را تشخیص دهید.

مثال زیر یک ارائه را به PDF صادر می‌کند و هشدارهای جایگزینی قلم را در کنسول چاپ می‌کند. هشدار فقط زمانی چاپ می‌شود که قلمی در دسترس نباشد و در حین صادرات جایگزین شود.

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
برای اطلاعات بیشتر درباره جایگزینی قلم، به مقاله [جایگزینی قلم](/slides/fa/php-java/font-substitution/) مراجعه کنید.
{{% /alert %}} 

### **دست‌کاری قلم‌هایی بدون سبک بولد اختصاصی**

یک ارائه می‌تواند فرمت بولد را بر متنی اعمال کند حتی هنگامی که قلم آن سبک بولد اختصاصی ندارد. متن می‌تواند همچنان به‌صورت بولد ظاهر شود از طریق بولد مصنوعی که گلیف‌های معمولی را به‌صورت مصنوعی ضخیم می‌کند. وقتی آن متن در PDF خیلی سنگین یا متفاوت از ظاهر مطلوب به‌نظر می‌رسد، می‌توانید با فراخوانی [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) با `true` این گزینه را فعال کنید. این گزینه متن تحت تأثیر را به‌صورت بیت‌مپ در حین صادرات PDF رستر می‌کند و می‌تواند ظاهر آن را برای برخی قلم‌ها بهبود بخشد. مقدار پیش‌فرض آن `false` است.

ارائه نمونه دو جعبه متن دارد: یکی با متن عادی و دیگری با فرمت بولد اعمال شده بر همان قلم که سبک بولد اختصاصی ندارد. مثال زیر ارائه را بارگذاری می‌کند، رستر کردن سبک‌های قلم پشتیبانی‌نشده را فعال می‌کند و آن را به PDF صادر می‌کند:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setRasterizeUnsupportedFontStyles(true);

$presentation = new Presentation("unsupported-bold.pptx");
try {
    $presentation->save("rasterized.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

پیش‌نمایش‌های زیر خروجی غیرفعال و فعال را نشان می‌دهند. در این مثال، متن بولد با گزینه غیرفعال دارای خط‌های سنگین‌تری است. با فعال‌سازی گزینه، خط‌های آن سبک‌تر هستند؛ متن عادی تغییر نمی‌کند. قبل از انتخاب تنظیم برای ارائه خود، نتایج را مقایسه کنید.

| گزینه غیرفعال (`false`، پیش‌فرض) | گزینه فعال (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

در این مثال، فعال‌سازی گزینه فقط متن بولد را به بیت‌مپ تبدیل می‌کند: بدون OCR نمی‌تواند انتخاب، کپی یا جستجو شود و لبه‌های آن در بزرگنمایی 800٪ نرم‌تر به‌نظر می‌رسند. متن عادی همچنان قابل جستجوست. با گزینه غیرفعال، هر دو رشته به‌صورت متن باقی می‌مانند.

این گزینه متن فرمت شده به‌صورت بولد را رستر می‌کند وقتی قلم آن سبک بولد اختصاصی ندارد. [جایگزینی قلم](/slides/fa/php-java/font-substitution/) به‌جای آن قلم دیگری را وقتی قلم اصلی در دسترس نیست، انتخاب می‌کند.

## **تبدیل اسلایدهای انتخاب‌شده از PowerPoint به PDF**

مثال زیر اسلایدهای 1 و 3 را از یک ارائه به PDF صادر می‌کند. اعداد اسلایدها در این آرایه از یک شروع می‌شوند و ارائه ورودی باید حداقل سه اسلاید داشته باشد.

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

## **تبدیل PowerPoint به PDF با اندازه اسلاید سفارشی**

مثال زیر اولین اسلاید را از یک ارائه به یک ارائه جدید با اندازه اسلاید 612 × 792 نقطه (8.5 × 11 اینچ) کپی می‌کند. محتوای اسلاید را برای جا شدن مقیاس می‌دهد و اسلاید منفرد را به PDF صادر می‌کند.

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

    // حذف اسلاید خالی که ارائه جدید با آن ایجاد شده بود.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **تبدیل PowerPoint به PDF در نمای اسلایدهای یادداشت**

مثال زیر یک ارائه را به PDF صادر می‌کند به‌طوری که یادداشت‌های سخنران هر اسلاید زیر اسلاید قرار می‌گیرد. برای دیدن نتیجه از یک ارائه حاوی یادداشت‌های سخنران استفاده کنید.

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

## **استانداردهای دسترس‌پذیری و سازگاری برای PDF**

Aspose.Slides به شما اجازه می‌دهد از یک فرآیند تبدیل استفاده کنید که با [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار است. می‌توانید یک سند PowerPoint را به PDF صادر کنید با هر یک از این استانداردهای سازگاری: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

کد زیر یک فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که بر اساس استانداردهای مختلف سازگاری، چندین PDF تولید می‌کند:

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
Aspose.Slides عملیات تبدیل PDF را پشتیبانی می‌کند و به شما اجازه می‌دهد فایل‌های PDF را به فرمت‌های محبوب دیگر تبدیل کنید. می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/)، [PDF به تصویر](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/)، [PDF به JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/)، و [PDF به PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) را انجام دهید. سایر عملیات تبدیل PDF به فرمت‌های تخصصی—[PDF به SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/)، و [PDF به XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)—نیز پشتیبانی می‌شوند.
{{% /alert %}}

> **note:** هنگام صادرات به PDF/UA، Aspose.Slides گرافیک‌های پیچیده مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر جداگانه به‌عنوان محتوا حفظ نمی‌شوند و ممکن است به‌عنوان اثرات شناخته شوند؛ متن جایگزین تنها برای کل شکل فراهم می‌شود.

## **سوالات متداول**

**آیا می‌توانم چندین فایل PowerPoint را به‌صورت دسته‌ای به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی بر روی فایل‌های خود حلقه بزنید و فرآیند تبدیل را اعمال کنید.

**آیا امکان حفاظت با رمز عبور برای PDF تبدیل‌شده وجود دارد؟**

بله. از کلاس [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) برای تنظیم رمز عبور و تعریف مجوزهای دسترسی در طول فرآیند تبدیل استفاده کنید.

**چگونه می‌توانم اسلایدهای مخفی را در PDF شامل کنم؟**

متد [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) را با `true` در کلاس [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) فراخوانی کنید تا اسلایدهای مخفی در PDF نهایی گنجانده شوند.

**آیا Aspose.Slides می‌تواند کیفیت بالای تصویر را در PDF حفظ کند؟**

بله، می‌توانید کیفیت تصویر را با استفاده از متدهایی مانند [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) و [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) در کلاس [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) کنترل کنید تا تصاویر با کیفیت بالا در PDF شما باشند.

**آیا Aspose.Slides از استانداردهای سازگاری PDF/A پشتیبانی می‌کند؟**

بله، Aspose.Slides به شما امکان می‌دهد PDFهایی را صادر کنید که با [استانداردهای مختلف](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/) از جمله PDF/A1a، PDF/A1b و PDF/UA سازگاری دارند و مستندات شما نیازهای دسترس‌پذیری و آرشیو را برآورده می‌کنند.

## **منابع اضافی**

- [مستندات Aspose.Slides برای PHP از طریق Java](/slides/fa/php-java/)
- [مرجع API Aspose.Slides برای PHP از طریق Java](https://reference.aspose.com/slides/php-java/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/conversion)