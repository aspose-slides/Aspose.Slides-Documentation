---
title: تبدیل PPT و PPTX به PDF در PHP [شامل ویژگی‌های پیشرفته]
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
- ذخیره PowerPoint به صورت PDF
- ذخیره PPT به صورت PDF
- ذخیره PPTX به صورت PDF
- صادرات PPT به PDF
- صادرات PPTX به PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "تبدیل PPT/PPTX PowerPoint به PDFهای با کیفیت بالا و قابل جستجو در PHP با استفاده از Aspose.Slides، همراه با مثال‌های کد سریع و گزینه‌های پیشرفته تبدیل."
---
## **بررسی کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به فرمت PDF در PHP مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ چینش و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را شامل کنید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی فونت‌ها را تشخیص دهید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای سازگاری را بر اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها در فرمت‌های زیر را به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به‌عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) بدهید و سپس با استفاده از متد `save`، ارائه را به PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) متد `save` را فراهم می‌کند که معمولاً برای تبدیل ارائه به PDF استفاده می‌شود.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for PHP via Java اطلاعات API و شماره نسخه خود را در اسناد خروجی درج می‌کند. به‌عنوان مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقداری به شکل "*Aspose.Slides v XX.XX*" پر می‌کند. **توجه** داشته باشید که نمی‌توانید Aspose.Slides را مجبور کنید این اطلاعات را از اسناد خروجی حذف یا تغییر دهد.

{{% /alert %}}

Aspose.Slides به شما امکان می‌دهد:

* تبدیل کل ارائه‌ها به PDF
* تبدیل اسلایدهای خاصی از یک ارائه به PDF

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد که PDFهای تولیدشده به‌طور دقیق با ارائه‌های اصلی مطابقت داشته باشند. عناصر و ویژگی‌ها به‌صورت دقیق در حین تبدیل رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندها
* سرصفحه‌ها و پاورقی‌ها
* بولت‌ها
* جداول

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائه ارائه‌شده را با تنظیمات بهینه و حداکثر کیفیت به PDF تبدیل کند.

این کد نشان می‌دهد چگونه یک ارائه (PPT، PPTX، ODP و غیره) را به PDF تبدیل کنید:

```php
# یک نمونه از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # ارائه را به صورت PDF ذخیره کنید.
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose یک [**مبدل آنلاین PowerPoint به PDF**](https://products.aspose.app/slides/fa/conversion/ppt-to-pdf) رایگان ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک آزمون زنده انجام دهید.

{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—ویژگی‌های موجود در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PdfOptions)—را فراهم می‌کند که به شما اجازه می‌دهد PDF نهایی را سفارشی کنید، PDF را با رمز عبور قفل کنید یا نحوه پیشرفت فرآیند تبدیل را تعیین کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی تبدیل، می‌توانید تنظیم کیفیت ترجیحی خود برای تصاویر raster را تعریف کنید، نحوه پردازش متافایل‌ها را مشخص کنید، سطح فشردگی متن را تنظیم کنید، DPI تصاویر را پیکربندی کنید و موارد دیگر.

مثال کد زیر نشان می‌دهد چگونه یک ارائه PowerPoint را با چند گزینه سفارشی به PDF تبدیل کنید.

```php
# یک نمونه از کلاس PdfOptions ایجاد کنید.
$pdfOptions = new PdfOptions();

# کیفیت تصاویر JPG را تنظیم کنید.
$pdfOptions->setJpegQuality(90);

# DPI تصاویر را تنظیم کنید.
$pdfOptions->setSufficientResolution(300);

# رفتار متافایل‌ها را تنظیم کنید.
$pdfOptions->setSaveMetafilesAsPng(true);

# سطح فشرده‌سازی متن برای محتوای متنی را تنظیم کنید.
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# حالت سازگاری PDF را تعریف کنید.
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# یک نمونه از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است، ایجاد کنید.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # ارائه را به صورت سند PDF ذخیره کنید.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر ارائه شامل اسلایدهای مخفی باشد، می‌توانید با استفاده از متد [setShowHiddenSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) از کلاس [PdfOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PdfOptions) اسلایدهای مخفی را به‌عنوان صفحات در PDF نهایی گنجانید.

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را با اسلایدهای مخفی به PDF تبدیل کنید:

```php
# یک نمونه از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # یک نمونه از کلاس PdfOptions ایجاد کنید.
    $pdfOptions = new PdfOptions();

    # اسلایدهای مخفی را اضافه کنید.
    $pdfOptions->setShowHiddenSlides(true);

    # ارائه را به صورت PDF ذخیره کنید.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **تبدیل PowerPoint به PDF با رمز عبور محافظت‌شده**

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را با استفاده از پارامترهای محافظت در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pdfoptions/) به PDF رمز‌دار تبدیل کنید:

```php
# یک نمونه از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # یک نمونه از کلاس PdfOptions ایجاد کنید.
    $pdfOptions = new PdfOptions();

    # یک رمز عبور PDF و مجوزهای دسترسی تنظیم کنید.
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # ارائه را به صورت PDF ذخیره کنید.
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **تشخیص جایگزینی فونت‌ها**

Aspose.Slides متد [setWarningCallback](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveoptions/#setWarningCallback) را در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pdfoptions/) ارائه می‌دهد که امکان تشخیص جایگزینی فونت‌ها را در حین فرآیند تبدیل ارائه به PDF فراهم می‌کند.

این کد نشان می‌دهد چگونه جایگزینی فونت‌ها را تشخیص دهید:

```php
class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss &&
        $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

// تنظیم فراخوانی هشدار در گزینه‌های PDF.
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// یک نمونه از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است، ایجاد کنید.
$presentation = new Presentation("sample.pptx");
try {
    //    ارائه را به صورت PDF ذخیره کنید.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{%  alert color="primary"  %}} 

برای اطلاعات بیشتر درباره جایگزینی فونت‌ها، مقاله [Font Substitution](/slides/fa/php-java/font-substitution/) را ببینید.

{{% /alert %}} 

## **تبدیل اسلایدهای انتخاب‌شده در PowerPoint به PDF**

این کد نشان می‌دهد چگونه فقط اسلایدهای خاصی از یک ارائه PowerPoint را به PDF تبدیل کنید:

```php
# یک نمونه از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است را ایجاد کنید.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # آرایه‌ای از شماره‌های اسلاید تنظیم کنید.
    $slides = array(1, 3);

    # ارائه را به صورت PDF ذخیره کنید.
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **تبدیل PowerPoint به PDF با اندازه سفارشی اسلاید**

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را با اندازه اسلاید مشخص به PDF تبدیل کنید:

```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# یک نمونه از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است ایجاد کنید.
$presentation = new Presentation("SelectedSlides.pptx");

# یک ارائه جدید با اندازه اسلاید تنظیم‌شده ایجاد کنید.
$resizedPresentation = new Presentation();

try {
    # اندازه اسلاید سفارشی را تنظیم کنید.
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # اسلاید اول را از ارائه اصلی کلون کنید.
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # ارائه تغییر اندازه‌یافته را به یک PDF با یادداشت‌ها ذخیره کنید.
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **تبدیل PowerPoint به PDF در حالت نمایش یادداشت اسلاید**

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF تبدیل کنید که شامل یادداشت‌ها باشد:

```php
# یک نمونه از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است را ایجاد کنید.
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # گزینه‌های PDF را با طرح‌بندی یادداشت‌ها پیکربندی کنید.
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # ارائه را به یک PDF با یادداشت‌ها ذخیره کنید.
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **دسترس‌پذیری و استانداردهای سازگاری برای PDF**

Aspose.Slides به شما اجازه می‌دهد از فرآیند تبدیل استفاده کنید که با [راهنمای دسترس‌پذیری محتوا وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار باشد. می‌توانید سند PowerPoint را به PDF صادر کنید که با هر یک از این استانداردهای سازگاری باشند: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که بر پایه استانداردهای مختلف سازگاری چندین PDF تولید می‌کند:

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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides عملیات‌های تبدیل PDF را پشتیبانی می‌کند و به شما امکان می‌دهد فایل‌های PDF را به فرمت‌های پرکاربرد تبدیل کنید. می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/fa/php-java/conversion/pdf-to-html/)، [PDF به تصویر](https://products.aspose.com/slides/fa/php-java/conversion/pdf-to-image/)، [PDF به JPG](https://products.aspose.com/slides/fa/php-java/conversion/pdf-to-jpg/)، و [PDF به PNG](https://products.aspose.com/slides/fa/php-java/conversion/pdf-to-png/) را انجام دهید. سایر عملیات‌های تبدیل PDF به فرمت‌های تخصصی—[PDF به SVG](https://products.aspose.com/slides/fa/php-java/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/fa/php-java/conversion/pdf-to-tiff/)، و [PDF به XML](https://products.aspose.com/slides/fa/php-java/conversion/pdf-to-xml/)—نیز پشتیبانی می‌شوند.

{{% /alert %}}

> **توجه:** هنگام خروجی به PDF/UA، Aspose.Slides گرافیک‌های پیچیده‌ای مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد درنظر می‌گیرد. عناصر مسیر جداگانه به‌عنوان محتوا حفظ نمی‌شوند و ممکن است به‌عنوان آثار جانبی علامت‌گذاری شوند؛ متن جایگزین فقط برای کل شکل ارائه می‌شود.

## **سوالات متداول**

**آیا می‌توانم چندین فایل PowerPoint را به صورت دسته‌ای به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی فایل‌هایتان را مرور کنید و فرآیند تبدیل را اعمال کنید.

**آیا می‌توانم PDF تبدیل‌شده را با رمز عبور محافظت کنم؟**

کاملاً امکان‌پذیر است. از کلاس [PdfOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pdfoptions/) برای تنظیم رمز عبور و تعریف سطوح دسترسی در طول فرآیند تبدیل استفاده کنید.

**چگونه اسلایدهای مخفی را در PDF گنجانده کنم؟**

از متد `setShowHiddenSlides` در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pdfoptions/) استفاده کنید تا اسلایدهای مخفی در PDF نهایی گنجانده شوند.

**آیا Aspose.Slides می‌تواند کیفیت تصویر بالا را در PDF حفظ کند؟**

بله، می‌توانید با استفاده از متدهایی مانند `setJpegQuality` و `setSufficientResolution` در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pdfoptions/) کیفیت تصویر را در PDF خود کنترل کنید.

**آیا Aspose.Slides از استانداردهای سازگاری PDF/A پشتیبانی می‌کند؟**

بله، Aspose.Slides به شما اجازه می‌دهد PDFهایی صادر کنید که با استانداردهای مختلف از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند و اطمینان حاصل کنید اسناد شما نیازهای دسترس‌پذیری و آرشیوی را برآورده می‌کنند.

## **منابع اضافی**

- [مستندات Aspose.Slides for PHP via Java](/slides/fa/php-java/)
- [مرجع API Aspose.Slides for PHP via Java](https://reference.aspose.com/slides/fa/php-java/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/fa/conversion)