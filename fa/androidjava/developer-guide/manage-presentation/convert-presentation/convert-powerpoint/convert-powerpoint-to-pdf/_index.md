---
title: تبدیل PPT و PPTX به PDF در Android [ویژگی‌های پیشرفته گنجانده شده]
linktitle: PowerPoint به PDF
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
description: "تبدیل PowerPoint PPT/PPTX به PDFهای با کیفیت بالا و قابل جستجو در Java با استفاده از Aspose.Slides برای Android، همراه با مثال‌های کد سریع و گزینه‌های پیشرفته تبدیل."
---
## **بررسی کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به فرمت PDF در Android مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ قالب‌بندی و چیدمان ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را گنجانید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی قلم‌ها را شناسایی کنید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای انطباق را بر اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در فرمت‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) پاس می‌دهید و سپس با استفاده از متد `save`، ارائه را به صورت PDF ذخیره می‌کنید. کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) متد `save` را فراهم می‌کند که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides برای Android از طریق Java اطلاعات API و شماره نسخه را به اسناد خروجی اضافه می‌کند. به عنوان مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقدار به شکل "*Aspose.Slides v XX.XX*" پر می‌کند. **Note** اینکه شما نمی‌توانید از Aspose.Slides بخواهید این اطلاعات را در اسناد خروجی تغییر یا حذف کند.

{{% /alert %}}

Aspose.Slides اجازه می‌دهد تا:

* کل ارائه‌ها به PDF
* اسلایدهای خاصی از یک ارائه به PDF

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌یابد PDF‌های تولید شده بسیار شبیه ارائه‌های اصلی باشند. عناصر و ویژگی‌ها به‌دقت در تبدیل رندر می‌شوند، از جمله:

* تصاویر
* کادرهای متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندها
* سرصفحه و پاورقی
* گلوله‌ها
* جداول

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائه‌ی ارائه‌شده را با تنظیمات بهینه و حداکثر کیفیت به PDF تبدیل کند.

این کد نشان می‌دهد چگونه یک ارائه (PPT، PPTX، ODP و غیره) را به PDF تبدیل کنید:

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نماینده یک فایل PowerPoint یا OpenDocument است.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // ارائه را به صورت PDF ذخیره کنید.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="info"  %}} 

Aspose یک [**تبدیل‌کننده PowerPoint به PDF**](https://products.aspose.app/slides/fa/conversion/ppt-to-pdf) آنلاین رایگان ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این تبدیل‌کننده یک آزمون زنده از روش شرح داده شده اجرا کنید.

{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—خصوصیات تحت کلاس [PdfOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfoptions/)—را فراهم می‌کند که به شما امکان سفارشی‌سازی PDF خروجی، قفل‌گذاری PDF با رمز عبور یا تعیین نحوه پیشرفت فرآیند تبدیل را می‌دهد.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی می‌توانید تنظیم کیفیت دلخواه برای تصاویر رستر، نحوه‌ٔ دستیابی به متافایل‌ها، سطح فشردگی متن، DPI برای تصاویر و موارد دیگر را تعریف کنید.

مثال کد زیر نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF با چندین گزینه سفارشی تبدیل کنید:

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// تنظیم کیفیت برای تصاویر JPG.
pdfOptions.setJpegQuality((byte)90);

// تنظیم DPI برای تصاویر.
pdfOptions.setSufficientResolution(300);

/// تنظیم رفتار برای متافایل‌ها.
pdfOptions.setSaveMetafilesAsPng(true);

// تنظیم سطح فشرده‌سازی متن برای محتواهای متنی.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// تعریف حالت انطباق PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// نمونه‌سازی کلاس Presentation که نماینده یک فایل PowerPoint یا OpenDocument است.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // ذخیره ارائه به عنوان سند PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر یک ارائه شامل اسلایدهای مخفی باشد، می‌توانید از متد [setShowHiddenSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfoptions/) استفاده کنید تا اسلایدهای مخفی به‌عنوان صفحات در PDF خروجی گنجانده شوند.

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF با اسلایدهای مخفی گنجانده شده تبدیل کنید:

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نماینده یک فایل PowerPoint یا OpenDocument است.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // نمونه‌سازی کلاس PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // افزودن اسلایدهای مخفی.
    pdfOptions.setShowHiddenSlides(true);

    // ذخیره ارائه به صورت PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تبدیل PowerPoint به PDF محافظت‌شده با رمز عبور**

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF محافظت‌شده با رمز عبور تبدیل کنید با استفاده از پارامترهای حفاظت از کلاس [PdfOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfoptions/):

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نماینده یک فایل PowerPoint یا OpenDocument است.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // نمونه‌سازی کلاس PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // تنظیم رمز عبور PDF و مجوزهای دسترسی.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // ذخیره ارائه به صورت PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **شناسایی جایگزینی قلم‌ها**

Aspose.Slides متد [setWarningCallback](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfoptions/) فراهم می‌کند که به شما امکان شناسایی جایگزینی قلم‌ها در طول فرآیند تبدیل ارائه به PDF را می‌دهد.

این کد نشان می‌دهد چگونه جایگزینی قلم‌ها را شناسایی کنید:

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // نمونه‌سازی کلاس Presentation که نماینده یک فایل PowerPoint یا OpenDocument است.
    Presentation presentation = new Presentation("sample.pptx");

    // تنظیم callback هشداری در گزینه‌های PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // ذخیره ارائه به صورت PDF.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// پیاده‌سازی callback هشدار.
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

{{%  alert color="info"  %}} 

برای اطلاعات بیشتر درباره جایگزینی قلم، مقاله [Font Substitution](/slides/fa/androidjava/font-substitution/) را ببینید.

{{% /alert %}} 

## **تبدیل اسلایدهای انتخاب‌شده از PowerPoint به PDF**

این کد نشان می‌دهد چگونه فقط اسلایدهای خاصی از یک ارائه PowerPoint را به PDF تبدیل کنید:

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نماینده یک فایل PowerPoint یا OpenDocument است.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // تنظیم آرایه‌ای از شماره اسلایدها.
    int[] slides = { 1, 3 };

    // ذخیره ارائه به صورت PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **تبدیل PowerPoint به PDF با اندازه اسلاید سفارشی**

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را با اندازه اسلاید مشخص به PDF تبدیل کنید:

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

// نمونه‌سازی کلاس Presentation که نماینده یک فایل PowerPoint یا OpenDocument است.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// ایجاد یک ارائه جدید با اندازه اسلاید تنظیم‌شده.
Presentation resizedPresentation = new Presentation();

try {
    // تنظیم اندازه سفارشی اسلاید.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // کلون کردن اولین اسلاید از ارائه اصلی.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // حذف اسلاید خالی که ارائه جدید با آن ساخته شده بود.
    resizedPresentation.getSlides().removeAt(1);

    // ذخیره ارائه با اندازه تغییر یافته به صورت PDF.
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **تبدیل PowerPoint به PDF در نمای اسلاید یادداشت‌ها**

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را به PDFی که شامل یادداشت‌هاست تبدیل کنید:

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نماینده یک فایل PowerPoint یا OpenDocument است.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // پیکربندی گزینه‌های PDF با چیدمان یادداشت‌ها.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // ذخیره ارائه به صورت PDF همراه با یادداشت‌ها.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **دسترس‌پذیری و استانداردهای انطباق برای PDF**

Aspose.Slides به شما اجازه می‌دهد از یک روش تبدیل استفاده کنید که با [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار باشد. می‌توانید یک سند PowerPoint را به PDF صادر کنید با هر یک از این استانداردهای انطباق: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد یک فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که PDFهای متعددی بر پایه استانداردهای انطباق مختلف تولید می‌کند:

```java
import com.aspose.slides.*;

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

Aspose.Slides عملیات‌های تبدیل PDF را پشتیبانی می‌کند و امکان تبدیل فایل‌های PDF به فرمت‌های محبوب را فراهم می‌آورد. می‌توانید تبدیل‌های [PDF to HTML](https://products.aspose.com/slides/fa/java/conversion/pdf-to-html/)، [PDF to image](https://products.aspose.com/slides/fa/java/conversion/pdf-to-image/)، [PDF to JPG](https://products.aspose.com/slides/fa/java/conversion/pdf-to-jpg/)، و [PDF to PNG](https://products.aspose.com/slides/fa/java/conversion/pdf-to-png/) را انجام دهید. سایر عملیات‌های تبدیل PDF به فرمت‌های تخصصی—[PDF to SVG](https://products.aspose.com/slides/fa/java/conversion/pdf-to-svg/)، [PDF to TIFF](https://products.aspose.com/slides/fa/java/conversion/pdf-to-tiff/)، و [PDF to XML](https://products.aspose.com/slides/fa/java/conversion/pdf-to-xml/)— نیز پشتیبانی می‌شوند.

{{% /alert %}}

> **Note:** هنگام خروجی گرفتن به PDF/UA، Aspose.Slides گرافیک‌های پیچیده‌ای مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر منفرد به‌عنوان محتوای جداگانه حفظ نمی‌شوند و ممکن است به‌عنوان artifact علامت‌گذاری شوند؛ متن جایگزین تنها برای کل شکل فراهم می‌شود.

## **سؤالات متداول**

### آیا می‌توانم چندین فایل PowerPoint را به صورت دسته‌ای به PDF تبدیل کنم؟

بله، Aspose.Slides تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF را پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی از طریق حلقه فایل‌ها را پردازش کرده و فرآیند تبدیل را اعمال کنید.

### آیا امکان قفل‌گذاری رمز عبور بر روی PDF تبدیل‌شده وجود دارد؟

به‌طور قطع. از کلاس [PdfOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfoptions/) استفاده کنید تا در زمان تبدیل یک رمز عبور تنظیم کرده و مجوزهای دسترسی را تعریف کنید.

### چگونه اسلایدهای مخفی را در PDF گنجانده کنم؟

متد `setShowHiddenSlides` را در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfoptions/) به‌کار بگیرید تا اسلایدهای مخفی در PDF نهایی گنجانده شوند.

### آیا Aspose.Slides می‌تواند کیفیت تصویر بالا را در PDF حفظ کند؟

بله، می‌توانید با استفاده از متدهایی مانند `setJpegQuality` و `setSufficientResolution` در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfoptions/) کیفیت تصویر را در PDF خود بالا نگه دارید.

### آیا Aspose.Slides استانداردهای انطباق PDF/A را پشتیبانی می‌کند؟

بله، Aspose.Slides به شما اجازه می‌دهد PDFهایی صادر کنید که با استانداردهای مختلفی از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند و اطمینان حاصل کنید اسناد شما نیازهای دسترس‌پذیری و آرشیو را برآورده می‌کنند.

## **منابع اضافی**

- [Aspose.Slides for Android via Java Documentation](/slides/fa/androidjava/)
- [Aspose.Slides for Android via Java API Reference](https://reference.aspose.com/slides/fa/androidjava/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/fa/conversion)