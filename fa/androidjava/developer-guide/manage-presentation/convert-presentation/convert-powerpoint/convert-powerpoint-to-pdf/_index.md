---
title: "تبدیل PPT و PPTX به PDF در اندروید [قابلیت‌های پیشرفته گنجانده شده]"
linktitle: "PowerPoint به PDF"
type: docs
weight: 40
url: /fa/androidjava/convert-powerpoint-to-pdf/
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
- صادرات PPT به PDF
- صادرات PPTX به PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "تبدیل PowerPoint PPT/PPTX به PDFهای با کیفیت بالا و جستجوپذیر در Java با استفاده از Aspose.Slides برای اندروید، همراه با مثال‌های کد سریع و گزینه‌های پیشرفته تبدیل."
---
## **مرور کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به فرمت PDF در اندروید مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ چیدمان و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را شامل شوید، فایل‌های PDF را با گذرواژه محافظت کنید، جایگزینی فونت‌ها را شناسایی کنید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای سازگاری را بر روی اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides، می‌توانید ارائه‌ها را در فرمت‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) پاس دهید و سپس با استفاده از متد `save` ارائه را به عنوان PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) متد `save` را ارائه می‌دهد که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides برای Android از طریق Java اطلاعات API و شماره نسخه خود را در اسناد خروجی وارد می‌کند. به عنوان مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقداری به شکل "*Aspose.Slides v XX.XX*" پر می‌کند. **توجه** داشته باشید که نمی‌توانید به Aspose.Slides بگویید این اطلاعات را در اسناد خروجی تغییر یا حذف کند.
{{% /alert %}}

Aspose.Slides به شما امکان می‌دهد:

* کل ارائه‌ها را به PDF تبدیل کنید
* اسلایدهای خاصی از یک ارائه را به PDF تبدیل کنید

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد که PDFهای حاصل به‌ شدت به ارائه‌های اصلی نزدیک باشند. عناصر و خصوصیات به‌دقت در تبدیل رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندها
* سرصفحه‌ها و پاورقی‌ها
* گلوله‌ها
* جداول

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائه ارائه‌شده را با استفاده از تنظیمات بهینه و در بالاترین سطح کیفیت به PDF تبدیل کند.

```java
// نمونه‌سازی کلاس Presentation که فایل PowerPoint یا OpenDocument را نمایندگی می‌کند.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // ارائه را به صورت PDF ذخیره کنید.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 
Aspose یک **PowerPoint to PDF converter**(https://products.aspose.app/slides/fa/conversion/ppt-to-pdf) رایگان آنلاین ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک آزمون اجرا کنید تا پیاده‌سازی زنده روش توضیح‌داده‌شده را مشاهده کنید.
{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—خصوصیات تحت کلاس [PdfOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfoptions/)—را فراهم می‌کند که به شما امکان می‌دهد PDF حاصل را سفارشی کنید، PDF را با گذرواژه قفل کنید یا نحوه پیشرفت فرآیند تبدیل را مشخص کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی تبدیل، می‌توانید تنظیم کیفیت دلخواه برای تصاویر رستری، نحوه‌ی پردازش متافایل‌ها، سطح فشرده‌سازی متن، DPI تصاویر و موارد دیگر را تعریف کنید.

کد زیر نشان می‌دهد چگونه یک ارائه PowerPoint را با چندین گزینه سفارشی به PDF تبدیل کنید.

```java
// نمونه‌سازی کلاس PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// کیفیت تصاویر JPG را تنظیم کنید.
pdfOptions.setJpegQuality((byte)90);

// DPI تصاویر را تنظیم کنید.
pdfOptions.setSufficientResolution(300);

/// رفتار متافایل‌ها را تنظیم کنید.
pdfOptions.setSaveMetafilesAsPng(true);

// سطح فشرده‌سازی متن برای محتوای متنی را تنظیم کنید.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// حالت سازگاری PDF را تعریف کنید.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// نمونه‌سازی کلاس Presentation که فایل PowerPoint یا OpenDocument را نمایندگی می‌کند.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // ارائه را به عنوان سند PDF ذخیره کنید.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر یک ارائه شامل اسلایدهای مخفی باشد، می‌توانید از متد [setShowHiddenSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfoptions/) استفاده کنید تا اسلایدهای مخفی به‌عنوان صفحات در PDF حاصل گنجانده شوند.

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را با گنجاندن اسلایدهای مخفی به PDF تبدیل کنید:

```java
// نمونه‌سازی کلاس Presentation که فایل PowerPoint یا OpenDocument را نمایندگی می‌کند.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // نمونه‌سازی کلاس PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // افزودن اسلایدهای مخفی.
    pdfOptions.setShowHiddenSlides(true);

    // ارائه را به صورت PDF ذخیره کنید.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تبدیل PowerPoint به PDF با حفاظت گذرواژه**

این کد نحوه تبدیل یک ارائه PowerPoint به PDF محافظت‌شده با گذرواژه را با استفاده از پارامترهای حفاظت موجود در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfoptions/) نشان می‌دهد:

```java
// نمونه‌سازی کلاس Presentation که فایل PowerPoint یا OpenDocument را نمایندگی می‌کند.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // نمونه‌سازی کلاس PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // تنظیم گذرواژه PDF و مجوزهای دسترسی.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // ارائه را به صورت PDF ذخیره کنید.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تشخیص جایگزینی فونت‌ها**

Aspose.Slides متد [setWarningCallback](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfoptions/) فراهم می‌کند که به شما اجازه می‌دهد جایگزینی فونت‌ها را در طول فرآیند تبدیل ارائه به PDF شناسایی کنید.

این کد نشان می‌دهد چگونه جایگزینی فونت‌ها را شناسایی کنید:

```java
public static void main(String[] args) {
    // نمونه‌سازی کلاس Presentation که فایل PowerPoint یا OpenDocument را نمایندگی می‌کند.
    Presentation presentation = new Presentation("sample.pptx");

    // تنظیم فراخوانی هشدار در گزینه‌های PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // ذخیره ارائه به عنوان PDF.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// پیاده‌سازی فراخوانی هشدار.
private static class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 
برای اطلاعات بیشتر درباره جایگزینی فونت‌ها، مقاله [Font Substitution](/slides/fa/androidjava/font-substitution/) را مشاهده کنید.
{{% /alert %}} 

## **تبدیل اسلایدهای انتخابی از PowerPoint به PDF**

این کد نشان می‌دهد چگونه فقط اسلایدهای خاصی از یک ارائه PowerPoint را به PDF تبدیل کنید:

```java
// نمونه‌سازی کلاس Presentation که فایل PowerPoint یا OpenDocument را نمایندگی می‌کند.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // تنظیم آرایه‌ای از شماره اسلایدها.
    int[] slides = { 1, 3 };

    // ارائه را به عنوان PDF ذخیره کنید.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **تبدیل PowerPoint به PDF با اندازه اسلاید سفارشی**

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را با اندازه اسلاید مشخص به PDF تبدیل کنید:

```java
float slideWidth = 612;
float slideHeight = 792;

// نمونه‌سازی کلاس Presentation که فایل PowerPoint یا OpenDocument را نمایندگی می‌کند.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// ایجاد یک ارائه جدید با اندازه اسلاید تنظیم‌شده.
Presentation resizedPresentation = new Presentation();

try {
    // تنظیم اندازه سفارشی اسلاید.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // کپی‌برداری از اولین اسلاید ارائه اصلی.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // ذخیره ارائه تغییر یافته به صورت PDF با یادداشت‌ها.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **تبدیل PowerPoint به PDF در نمای اسلایدهای یادداشت‌ها**

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF ای که شامل یادداشت‌ها است، تبدیل کنید:

```java
// نمونه‌سازی کلاس Presentation که فایل PowerPoint یا OpenDocument را نمایندگی می‌کند.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // پیکربندی گزینه‌های PDF با چیدمان یادداشت‌ها.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // ذخیره ارائه به صورت PDF با یادداشت‌ها.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **دسترس‌پذیری و استانداردهای سازگاری برای PDF**

Aspose.Slides به شما امکان استفاده از یک فرآیند تبدیل را می‌دهد که با [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار است. می‌توانید یک سند PowerPoint را با هر یک از این استانداردهای سازگاری صادر کنید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد یک فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که بر اساس استانداردهای مختلف سازگاری، چندین PDF تولید می‌کند:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Aspose.Slides عملیات تبدیل PDF را پشتیبانی می‌کند و به شما اجازه می‌دهد فایل‌های PDF را به فرمت‌های محبوب دیگر تبدیل کنید. می‌توانید تبدیل‌های [PDF to HTML](https://products.aspose.com/slides/fa/java/conversion/pdf-to-html/)، [PDF to image](https://products.aspose.com/slides/fa/java/conversion/pdf-to-image/)، [PDF to JPG](https://products.aspose.com/slides/fa/java/conversion/pdf-to-jpg/)، و [PDF to PNG](https://products.aspose.com/slides/fa/java/conversion/pdf-to-png/) را انجام دهید. سایر عملیات تبدیل PDF به فرمت‌های تخصصی—[PDF to SVG](https://products.aspose.com/slides/fa/java/conversion/pdf-to-svg/)، [PDF to TIFF](https://products.aspose.com/slides/fa/java/conversion/pdf-to-tiff/)، و [PDF to XML](https://products.aspose.com/slides/fa/java/conversion/pdf-to-xml/)—هم پشتیبانی می‌شوند.
{{% /alert %}}

> **نکته:** هنگام خروجی گرفتن به PDF/UA، Aspose.Slides گرافیک‌های پیچیده‌ای مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر جداگانه به‌عنوان محتواهای مستقل حفظ نمی‌شوند و ممکن است به‌عنوان artefact علامت‌گذاری شوند؛ متن جایگزین تنها برای کل شکل فراهم می‌شود.

## **سوالات متداول**

**آیا می‌توانم چندین فایل PowerPoint را به صورت دسته‌ای به PDF تبدیل کنم؟**  
بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی بر روی فایل‌های خود حلقه بزنید و فرآیند تبدیل را اعمال کنید.

**آیا امکان محافظت گذرواژه‌ای از PDF تبدیل‌شده وجود دارد؟**  
قطعا. می‌توانید با استفاده از کلاس [PdfOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfoptions/) یک گذرواژه تنظیم کنید و دسترسی‌ها را در طول فرآیند تبدیل تعریف کنید.

**چگونه می‌توانم اسلایدهای مخفی را در PDF گنجانده کنم؟**  
از متد `setShowHiddenSlides` در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfoptions/) استفاده کنید تا اسلایدهای مخفی در PDF نهایی گنجانده شوند.

**آیا Aspose.Slides می‌تواند کیفیت بالای تصویر را در PDF حفظ کند؟**  
بله، می‌توانید با استفاده از متدهایی مانند `setJpegQuality` و `setSufficientResolution` در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfoptions/) کیفیت تصویر را کنترل و اطمینان حاصل کنید که تصاویر در PDF با کیفیت بالا باشند.

**آیا Aspose.Slides استانداردهای سازگاری PDF/A را پشتیبانی می‌کند؟**  
بله، Aspose.Slides به شما اجازه می‌دهد PDFهایی صادر کنید که با استانداردهای مختلف از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند و تضمین می‌کند اسناد شما معیارهای دسترس‌پذیری و بایگانی را برآورده کنند.

## **منابع اضافی**

- [Aspose.Slides for Android via Java Documentation](/slides/fa/androidjava/)
- [Aspose.Slides for Android via Java API Reference](https://reference.aspose.com/slides/fa/androidjava/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/fa/conversion)