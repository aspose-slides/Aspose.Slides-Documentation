---
title: تبدیل PPT و PPTX به PDF در جاوا [شامل ویژگی‌های پیشرفته]
linktitle: PowerPoint به PDF
type: docs
weight: 40
url: /fa/java/convert-powerpoint-to-pdf/
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- جاوا
- Aspose.Slides
description: "PowerPoint PPT/PPTX را در جاوا با استفاده از Aspose.Slides به PDFهای با کیفیت بالا و قابل جستجو تبدیل کنید، همراه با نمونه‌های کد سریع و گزینه‌های پیشرفتهٔ تبدیل."
---
## **نمای کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به فرمت PDF در جاوا چندین مزیت دارد، از جمله سازگاری در دستگاه‌های مختلف و حفظ چیدمان و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای پنهان را شامل کنید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی فونت‌ها را شناسایی کنید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای انطباق را بر اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به‌عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) پاس دهید و سپس با استفاده از متد `save`، ارائه را به‌صورت PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) متد `save` را که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود، در اختیار قرار می‌دهد.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides برای Java اطلاعات API و شماره نسخه خود را در اسناد خروجی درج می‌کند. به عنوان مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقدار به شکل "*Aspose.Slides v XX.XX*" پر می‌کند. **Note** اینکه نمی‌توانید Aspose.Slides را مجبور کنید تا این اطلاعات را از اسناد خروجی تغییر یا حذف کند.
{{% /alert %}}

Aspose.Slides به شما امکان می‌دهد تبدیل کنید:

* کل ارائه‌ها به PDF
* اسلایدهای خاصی از یک ارائه به PDF

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد PDFهای حاصل به‌دقت با ارائه‌های اصلی مطابقت داشته باشند. عناصر و ویژگی‌ها به‌طور دقیق در تبدیل رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و شکل‌ها
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* لینک‌های فراخوانی
* سرصفحه و پاصفحه
* علامت‌های بولت
* جداول

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائه ارائه‌شده را با تنظیمات بهینه و در بالاترین سطح کیفیت به PDF تبدیل کند.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // ارائه را به‌صورت PDF ذخیره کنید.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 
Aspose یک [**مبدل آنلاین رایگان PowerPoint به PDF**](https://products.aspose.app/slides/fa/conversion/ppt-to-pdf) ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با استفاده از این مبدل یک آزمون انجام دهید تا پیاده‌سازی زندهٔ روال شرح داده شده در اینجا را ببینید.
{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—خصوصیات تحت کلاس [PdfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/)—را فراهم می‌کند که به شما اجازه می‌دهد PDF حاصل را سفارشی کنید، آن را با رمز عبور قفل کنید، یا چگونگی پیشرفت فرآیند تبدیل را مشخص کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی می‌توانید تنظیم کیفیت دلخواه برای تصاویر رستر، نحوه پردازش متافایل‌ها، سطح فشرده‌سازی متن، DPI تصاویر و موارد دیگر را تعریف کنید.

```java
// نمونه‌سازی کلاس PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// تنظیم کیفیت برای تصاویر JPG.
pdfOptions.setJpegQuality((byte)90);

// تنظیم DPI برای تصاویر.
pdfOptions.setSufficientResolution(300);

// تنظیم رفتار برای متافایل‌ها.
pdfOptions.setSaveMetafilesAsPng(true);

// تنظیم سطح فشرده‌سازی متن برای محتوای متنی.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// تعریف حالت انطباق PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است.
Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    // ذخیره ارائه به‌صورت سند PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تبدیل PowerPoint به PDF با اسلایدهای پنهان**

اگر یک ارائه شامل اسلایدهای پنهان باشد، می‌توانید از متد [setShowHiddenSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/) استفاده کنید تا اسلایدهای پنهان به‌صورت صفحات در PDF حاصل گنجانده شوند.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // نمونه‌سازی کلاس PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // افزودن اسلایدهای پنهان.
    pdfOptions.setShowHiddenSlides(true);

    // ذخیره ارائه به‌صورت PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تبدیل PowerPoint به PDF با حفاظت رمز عبور**

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را با استفاده از پارامترهای حفاظت موجود در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/) به PDF دارای رمز عبور تبدیل کنید:

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // نمونه‌سازی کلاس PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // تنظیم رمز عبور PDF و مجوزهای دسترسی.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // ذخیره ارائه به‌صورت PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تشخیص جایگزینی فونت‌ها**

Aspose.Slides متد [setWarningCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/) ارائه می‌دهد که امکان تشخیص جایگزینی فونت‌ها را در طول فرآیند تبدیل ارائه به PDF فراهم می‌کند.

```java
public static void main(String[] args) {
    // نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است.
    Presentation presentation = new Presentation("sample.pptx");

    // تنظیم فراخوانی هشدار در گزینه‌های PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // ذخیره ارائه به‌صورت PDF.
        presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        presentation.dispose();
    }
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
برای اطلاعات بیشتر درباره دریافت فراخوانی‌ها برای جایگزینی فونت‌ها در طی فرآیند رندر، به مقاله [Getting Warning Callbacks for Fonts Substitution](/slides/fa/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) مراجعه کنید.

برای اطلاعات بیشتر درباره جایگزینی فونت، مقالهٔ [Font Substitution](/slides/fa/java/font-substitution/) را ببینید.
{{% /alert %}} 

## **تبدیل اسلایدهای انتخابی در PowerPoint به PDF**

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // تنظیم آرایه‌ای از شماره اسلایدها.
    int[] slides = { 1, 3 };

    // ذخیره ارائه به‌صورت PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **تبدیل PowerPoint به PDF با اندازه اسلاید سفارشی**

```java
float slideWidth = 612;
float slideHeight = 792;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// ایجاد یک ارائه جدید با اندازه اسلاید تنظیم‌شده.
Presentation resizedPresentation = new Presentation();

try {
    // تنظیم اندازه سفارشی اسلاید.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    // کلون کردن اولین اسلاید از ارائه اصلی.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // ذخیره ارائه تغییر اندازه یافته به‌صورت PDF با یادداشت‌ها.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **تبدیل PowerPoint به PDF در نمای اسلایدهای یادداشت‌ها**

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // پیکربندی گزینه‌های PDF با چیدمان یادداشت‌ها.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // ذخیره ارائه به‌صورت PDF با یادداشت‌ها.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **دسترس‌پذیری و استانداردهای انطباق برای PDF**

Aspose.Slides به شما اجازه می‌دهد از روال تبدیل استفاده کنید که با [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار باشد. می‌توانید یک سند PowerPoint را به PDF صادر کنید و از هر یک از این استانداردهای انطباق استفاده کنید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

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
Aspose.Slides عملیات تبدیل PDF را پشتیبانی می‌کند و به شما امکان می‌دهد فایل‌های PDF را به فرمت‌های محبوب تبدیل کنید. می‌توانید تبدیل‌های [PDF to HTML](https://products.aspose.com/slides/fa/java/conversion/pdf-to-html/)، [PDF to image](https://products.aspose.com/slides/fa/java/conversion/pdf-to-image/)، [PDF to JPG](https://products.aspose.com/slides/fa/java/conversion/pdf-to-jpg/)، و [PDF to PNG](https://products.aspose.com/slides/fa/java/conversion/pdf-to-png/) را انجام دهید. سایر عملیات تبدیل PDF به فرمت‌های تخصصی—[PDF to SVG](https://products.aspose.com/slides/fa/java/conversion/pdf-to-svg/)، [PDF to TIFF](https://products.aspose.com/slides/fa/java/conversion/pdf-to-tiff/)، و [PDF to XML](https://products.aspose.com/slides/fa/java/conversion/pdf-to-xml/)—نیز پشتیبانی می‌شوند.
{{% /alert %}}

> **توجه:** هنگام خروجی به PDF/UA، Aspose.Slides گرافیک‌های پیچیده مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر به صورت محتواهای جداگانه حفظ نمی‌شوند و ممکن است به‌عنوان artefacts علامت‌گذاری شوند؛ متن جایگزین فقط برای کل شکل ارائه می‌شود.

## **سوالات متداول**

**آیا می‌توانم چندین فایل PowerPoint را به‌صورت دسته‌ای به PDF تبدیل کنم؟**  
بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی به‌سراغ فایل‌های خود رفته و فرآیند تبدیل را اعمال کنید.

**آیا امکان محافظت از PDF تبدیل‌شده با رمز عبور وجود دارد؟**  
کاملاً ممکن است. از کلاس [PdfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/) برای تنظیم رمز عبور و تعریف مجوزهای دسترسی در طول فرآیند تبدیل استفاده کنید.

**چگونه اسلایدهای پنهان را در PDF گنجانده کنم؟**  
از متد `setShowHiddenSlides` در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/) استفاده کنید تا اسلایدهای پنهان در PDF نهایی گنجانده شوند.

**آیا Aspose.Slides می‌تواند کیفیت بالای تصویر را در PDF حفظ کند؟**  
بله، می‌توانید با استفاده از متدهایی مانند `setJpegQuality` و `setSufficientResolution` در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/) کیفیت تصویر را کنترل کنید تا تصاویر با کیفیت بالا در PDF شما قرار گیرند.

**آیا Aspose.Slides استانداردهای انطباق PDF/A را پشتیبانی می‌کند؟**  
بله، Aspose.Slides به شما اجازه می‌دهد PDFهایی صادر کنید که با [استانداردهای مختلف](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfcompliance/) از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند و اطمینان حاصل کنید اسناد شما نیازهای دسترس‌پذیری و بایگانی را برآورده می‌کنند.

## **منابع اضافی**

- [مستندات Aspose.Slides برای Java](/slides/fa/java/)
- [مرجع API Aspose.Slides برای Java](https://reference.aspose.com/slides/fa/java/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/fa/conversion)