---
title: تبدیل PPT و PPTX به PDF در PHP [ویژگی‌های پیشرفته گنجانده شده]
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
description: "PowerPoint PPT/PPTX را در PHP با استفاده از Aspose.Slides به PDFهای با کیفیت بالا و قابل جستجو تبدیل کنید، با مثال‌های سریع کد و گزینه‌های پیشرفته تبدیل."
---
## **نمای کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به قالب PDF در PHP چندین مزیت دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ چیدمان و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را شامل کنید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی‌های قلم را تشخیص دهید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای سازگاری را بر اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides، می‌توانید ارائه‌ها را در فرمت‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) بدهید و سپس ارائه را با استفاده از روش [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) به PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) متد [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) را فراهم می‌کند که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{% alert color="info" title="Note" %}}

Aspose.Slides for PHP via Java اطلاعات API و شماره نسخه خود را در اسناد خروجی وارد می‌کند. برای مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقداری به فرم "*Aspose.Slides v XX.XX*" پر می‌کند. **Note** اینکه نمی‌توانید Aspose.Slides را مجبور کنید این اطلاعات را از اسناد خروجی حذف یا تغییر دهد.

{{% /alert %}}

Aspose.Slides به شما اجازه می‌دهد تا:

* کل ارائه‌ها را به PDF تبدیل کنید
* اسلایدهای خاصی از یک ارائه را به PDF تبدیل کنید

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد PDFهای تولید شده به‌دقت مشابه ارائه‌های اصلی باشند. عناصر و ویژگی‌ها در تبدیل به‌درستی رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندهای ابرمتنی
* سرصفحه‌ها و پاورقی‌ها
* گلوله‌ها
* جداول

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائهٔ داده‌شده را با تنظیمات بهینه و در بالاترین سطوح کیفیت به PDF تبدیل کند.

مثال زیر یک ارائه را بارگذاری می‌کند و تمام اسلایدهای قابل مشاهده را با تنظیمات خروجی پیش‌فرض به PDF ذخیره می‌کند.

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

Aspose یک ابزار آنلاین رایگان [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک آزمایش زنده از روند توضیحی انجام دهید.

{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—ویژگی‌های موجود در کلاس [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)—را فراهم می‌کند که به شما اجازه می‌دهد PDF نهایی را تنظیم کنید، PDF را با رمز عبور قفل کنید یا مشخص کنید فرآیند تبدیل به چه صورت پیش برود.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی می‌توانید تنظیم کیفیت دلخواه خود برای تصاویر رستری، نحوهٔ پردازش متافایل‌ها، سطح فشرده‌سازی متن، DPI برای تصاویر و موارد دیگر را تعریف کنید.

مثال زیر یک ارائه را با تنظیمات PDF 1.5، کیفیت JPEG برابر 90، وضوح تصویر 300 DPI، ذخیره متافایل‌ها به‌صورت PNG و فشرده‌سازی متن Flate صادر می‌کند.

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

### **حفظ فایل‌های OLE توکار به‌عنوان ضمیمه‌های PDF**

اگر ارائه شامل یک کارپوشهٔ Excel توکار باشد، ممکن است بخواهید دریافت‌کنندگان PDF به داده‌های کارپوشه دسترسی داشته باشند و همچنین اسلایدها را ببینند. برای حفظ فایل‌های OLE توکار به‌صورت ضمیمه در PDF نتیجه، متد [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) را با مقدار `true` صدا بزنید.

مقدار پیش‌فرض `false` است: تصویر پیش‌نمایش یا آیکون شیٔ OLE بر روی صفحه PDF رندر می‌شود، اما فایل توکار به‌عنوان ضمیمه گنجانده نمی‌شود. تنظیم این گزینه به `true` علاوه بر آن دادهٔ فایل را نیز شامل می‌شود. پیش‌نمایش همچنان یک نمایش بصری باقی می‌ماند؛ ضمیمه اجازه می‌دهد دریافت‌کنندگان فایل توکار را جداگانه باز یا ذخیره کنند. شیٔ OLE تبدیل به یک کاربرگ Excel تعاملی بر صفحه PDF نمی‌شود.

مثال زیر یک ارائه را که هم‌اکنون شامل یک کارپوشهٔ Excel توکار است، بارگذاری می‌کند و آن را با کارپوشه پیوست‌شده به PDF صادر می‌کند.

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

1. PDF صادرشده را در یک مرورگری که از ضمیمه‌های فایل پشتیبانی می‌کند، مانند Adobe Acrobat Reader، باز کنید.
2. پنل **Attachments** مرورگر را باز کنید و کارپوشهٔ توکار را پیدا کنید.
3. ضمیمه را ذخیره کنید و در Excel باز کنید تا داده‌ها را بررسی کنید، یا در صورت امکان مستقیماً باز کنید. پیش‌نمایش بر روی صفحه PDF جدا از ضمیمه است.

{{% alert color="info" title="Note" %}}

استانداردهای PDF/A محدودیت‌هایی برای ضمیمه‌ها اعمال می‌کنند: PDF/A‑1 فایل‌های توکار را ممنوع می‌کند، PDF/A‑2 فقط ضمیمه‌های PDF/A را مجاز می‌داند و PDF/A‑3 انواع فایل‌های دیگر از جمله کارپوشهٔ Excel را اجازه می‌دهد. این‌ها الزامات استانداردها هستند، نه محدودیت‌های خاص Aspose.Slides. این مثال از تنظیم پیش‌فرض سازگاری PDF استفاده می‌کند و خروجی PDF/A را نشان نمی‌دهد.

{{% /alert %}}

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر ارائه شامل اسلایدهای مخفی باشد، می‌توانید با استفاده از متد [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) از کلاس [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) اسلایدهای مخفی را به‌عنوان صفحات در PDF نهایی گنجانده شود.

مثال زیر یک ارائه را به PDF صادر می‌کند و هر اسلاید مخفی را نیز شامل می‌شود.

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

مثال زیر یک ارائه را به PDF صادر می‌کند که برای باز کردن نیاز به رمز عبور `password` دارد. مجوزهای دسترسی اجازه چاپ، از جمله چاپ با کیفیت بالا را می‌دهند.

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

### **تشخیص جایگزینی‌های قلم**

Aspose.Slides متد [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) فراهم می‌کند که به شما امکان می‌دهد در طول فرآیند تبدیل ارائه به PDF، جایگزینی‌های قلم را شناسایی کنید.

مثال زیر یک ارائه را به PDF صادر می‌کند و هشدارهای جایگزینی قلم را در کنسول چاپ می‌کند. هشدار فقط زمانی چاپ می‌شود که یک قلم غیرقابل دسترس جایگزین شود.

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

برای اطلاعات بیشتر در مورد جایگزینی قلم، مقالهٔ [Font Substitution](/slides/fa/php-java/font-substitution/) را ببینید.

{{% /alert %}} 

### **برخورد با قلم‌هایی بدون سبک بولد جداگانه**

یک ارائه می‌تواند قالب بولد را بر متن اعمال کند حتی اگر قلم آن دارای سبک بولد جداگانه نباشد. متن می‌تواند از طریق بولد مصنوعی، که گلیف‌های معمولی را به‌طور مصنوعی ضخیم می‌کند، به‌نظر بولد برسد. وقتی این متن در PDF بیش از حد سنگین به‌نظر می‌رسد یا از ظاهر موردنظر متفاوت است، می‌توانید متد [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) را با مقدار `true` فراخوانی کنید. این گزینه متن تحت تأثیر را به‌صورت bitmap هنگام خروجی PDF رستر می‌کند و می‌تواند ظاهر آن را برای برخی قلم‌ها بهبود بخشد. مقدار پیش‌فرض آن `false` است.

ارائهٔ نمونه شامل دو جعبه متن است: یکی با متن عادی و دیگری با قالب بولد بر همان قلم که سبک بولد جداگانه‌ای ندارد. مثال زیر ارائه را بارگذاری می‌کند، رستر کردن سبک‌های قلم پشتیبانی‌نشده را فعال می‌سازد و آن را به PDF صادر می‌کند:

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

پیش‌نمایش‌های زیر خروجی غیرفعال و فعال را نشان می‌دهند. در این مثال، متن بولد با گزینه غیرفعال خطوط سنگین‌تری دارد. با فعال‌سازی گزینه، خطوط آن سبک‌تر می‌شوند؛ متن عادی بدون تغییر باقی می‌ماند. قبل از انتخاب تنظیم برای ارائه خود نتایج را مقایسه کنید.

| گزینه غیرفعال (`false`، پیش‌فرض) | گزینه فعال (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

در این مثال، فعال کردن گزینه فقط متن بولد را به bitmap تبدیل می‌کند: بدون OCR نمی‌توان آن را انتخاب، کپی یا جستجو کرد و لبه‌های آن در بزرگ‌نمایی 800٪ نرم‌تر به‌نظر می‌رسند. متن عادی قابل جستجو می‌ماند. با غیرفعال بودن گزینه، هر دو رشته به‌عنوان متن باقی می‌مانند.

این گزینه متن قالب بولد را رستر می‌کند وقتی قلم آن دارای سبک بولد جداگانه نیست. [Font substitution](/slides/fa/php-java/font-substitution/) به جای آن قلم دیگری را انتخاب می‌کند وقتی قلم اصلی در دسترس نیست.

## **تبدیل اسلایدهای انتخاب‌شده از PowerPoint به PDF**

مثال زیر اسلایدهای 1 و 3 را از یک ارائه به PDF صادر می‌کند. شماره‌های اسلاید در این آرایه یک‌پایه‌اند و ارائهٔ ورودی باید حداقل شامل سه اسلاید باشد.

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

## **تبدیل PowerPoint به PDF با اندازهٔ اسلاید سفارشی**

مثال زیر اولین اسلاید را از یک ارائه به یک ارائهٔ جدید با اندازهٔ اسلاید 612 × 792 پوینت (8.5 × 11 اینچ) کپی می‌کند. محتویات اسلاید را برای پر کردن مقیاس می‌کند و اسلاید تک را به PDF صادر می‌کند.

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

    // اسلاید خالی که ارائه جدید با آن ایجاد شد را حذف کنید.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **تبدیل PowerPoint به PDF در نمای اسلاید یادداشت‌ها**

مثال زیر یک ارائه را به PDF صادر می‌کند به‌طوری که یادداشت‌های سخنران هر اسلاید زیر اسلاید قرار می‌گیرد. برای مشاهده نتیجه، از ارائه‌ای حاوی یادداشت‌های سخنران استفاده کنید.

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

## **دسترس‌پذیری و استانداردهای سازگاری برای PDF**

Aspose.Slides به شما اجازه می‌دهد از یک روش تبدیل استفاده کنید که با [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار باشد. می‌توانید یک سند PowerPoint را به PDF با هر یک از این استانداردهای سازگاری صادر کنید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که بر اساس استانداردهای مختلف سازگاری، چندین PDF تولید می‌کند:

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

Aspose.Slides از عملیات تبدیل PDF پشتیبانی می‌کند و اجازه می‌دهد فایل‌های PDF را به فرمت‌های محبوب دیگر تبدیل کنید. می‌توانید تبدیل‌های [PDF to HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/)، [PDF to image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/)، [PDF to JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/) و [PDF to PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) را انجام دهید. سایر عملیات تبدیل PDF به فرمت‌های تخصصی—[PDF to SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/)، [PDF to TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/)، و [PDF to XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)—نیز پشتیبانی می‌شوند.

{{% /alert %}}

> **Note:** هنگام خروجی به PDF/UA، Aspose.Slides گرافیک‌های پیچیده‌ای مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر جداگانه به‌عنوان محتوا حفظ نمی‌شوند و ممکن است به‌عنوان آثار هنری (artifacts) علامت‌گذاری شوند؛ متن جایگزین فقط برای کل شکل فراهم می‌شود.

## **سوالات متداول**

**آیا می‌توانم چندین فایل PowerPoint را به‌صورت دسته‌جمعی به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی بر روی فایل‌های خود تکرار کنید و فرآیند تبدیل را اعمال کنید.

**آیا می‌توان PDF تبدیل‌شده را با رمز عبور محافظت کرد؟**

بله. از کلاس [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) برای تنظیم رمز عبور و تعریف مجوزهای دسترسی در طول فرآیند تبدیل استفاده کنید.

**چگونه اسلایدهای مخفی را در PDF گنجانده کنم؟**

متد [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) را با مقدار `true` در کلاس [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) فراخوانی کنید تا اسلایدهای مخفی در PDF نهایی گنجانده شوند.

**آیا Aspose.Slides می‌تواند کیفیت تصویر بالا را در PDF حفظ کند؟**

بله، می‌توانید کیفیت تصویر را با استفاده از متدهایی مانند [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) و [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) در کلاس [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) کنترل کنید تا تصاویر با کیفیت بالا در PDF شما باشند.

**آیا Aspose.Slides از استانداردهای سازگاری PDF/A پشتیبانی می‌کند؟**

بله، Aspose.Slides به شما امکان می‌دهد PDFهایی صادر کنید که با [various standards](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/) از جمله PDF/A1a، PDF/A1b و PDF/UA مطابقت داشته باشند و اطمینان حاصل کنید اسناد شما الزامات دسترس‌پذیری و بایگانی را برآورده می‌کنند.

## **منابع اضافی**

- [Aspose.Slides for PHP via Java Documentation](/slides/fa/php-java/)
- [Aspose.Slides for PHP via Java API Reference](https://reference.aspose.com/slides/php-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)