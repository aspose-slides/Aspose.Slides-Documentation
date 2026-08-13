---
title: تبدیل PPT و PPTX به PDF در جاوا [قابلیت‌های پیشرفته گنجانده شده]
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
description: "تبدیل PowerPoint PPT/PPTX به PDFهای با کیفیت بالا و قابل جستجو در جاوا با استفاده از Aspose.Slides، همراه با مثال‌های سریع کد و گزینه‌های پیشرفته تبدیل."
---
## **مرور کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به قالب PDF در جاوا مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ چیدمان و قالب‌بندی ارائه شما. این راهنما نحوه تبدیل ارائه‌ها به اسناد PDF، استفاده از گزینه‌های مختلف برای کنترل کیفیت تصویر، شامل کردن اسلایدهای مخفی، محافظت با رمز عبور از فایل‌های PDF، شناسایی جایگزینی قلم‌ها، انتخاب اسلایدهای خاص برای تبدیل و اعمال استانداردهای انطباق به اسناد خروجی را نشان می‌دهد.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در قالب‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [ارائه](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) پاس دهید و سپس ارائه را با استفاده از متد `save` به صورت PDF ذخیره کنید. کلاس [ارائه](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) متد `save` را ارائه می‌دهد که معمولاً برای تبدیل ارائه به PDF استفاده می‌شود.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides برای جاوا اطلاعات API و شماره نسخه خود را به اسناد خروجی اضافه می‌کند. به عنوان مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقداری به شکل "*Aspose.Slides v XX.XX*" پر می‌کند. **توجه** داشته باشید که نمی‌توانید Aspose.Slides را مجبور کنید این اطلاعات را از اسناد خروجی تغییر یا حذف کند.
{{% /alert %}}

Aspose.Slides به شما امکان تبدیل زیر را می‌دهد:

* کل ارائه‌ها به PDF
* اسلایدهای خاص از یک ارائه به PDF

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد که PDFهای حاصل به‌دقت با ارائه‌های اصلی مطابقت دارند. عناصر و ویژگی‌ها به‌درستی در تبدیل رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندهای فراگیر
* سرصفحه‌ها و پانویس‌ها
* گلوله‌ها
* جدول‌ها

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائهٔ داده‌شده را با تنظیمات بهینه و حداکثر کیفیت به PDF تبدیل کند.

این کد نشان می‌دهد چگونه یک ارائه (PPT، PPTX، ODP و غیره) را به PDF تبدیل کنید:

```java
import com.aspose.slides.*;

// یک شیء Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است را نمونه‌سازی می‌کند.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // ارائه را به عنوان PDF ذخیره می‌کند.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="info"  %}} 
Aspose یک **مبدل آنلاین رایگان PowerPoint به PDF**[https://products.aspose.app/slides/fa/conversion/ppt-to-pdf] ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک تست زنده از روند توضیح داده‌شده اجرا کنید.
{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—ویژگی‌های موجود در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/)—را فراهم می‌کند که به شما اجازه می‌دهد PDF حاصل را شخصی‌سازی کنید، با رمز عبور PDF را قفل کنید یا نحوهٔ پیشرفت فرآیند تبدیل را مشخص کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی می‌توانید تنظیم کیفیت ترجیحی برای تصویرهای رستر، نحوهٔ پردازش متافایل‌ها، سطح فشرده‌سازی متن، DPI تصویر و موارد دیگر را تعیین کنید.

کد نمونه زیر نشان می‌دهد چگونه یک ارائه PowerPoint را با چندین گزینه سفارشی به PDF تبدیل کنید:

```java
import com.aspose.slides.*;

// یک شیء PdfOptions را نمونه‌سازی می‌کند.
PdfOptions pdfOptions = new PdfOptions();

// کیفیت تصاویر JPG را تنظیم می‌کند.
pdfOptions.setJpegQuality((byte)90);

// DPI تصاویر را تنظیم می‌کند.
pdfOptions.setSufficientResolution(300);

// رفتار متافایل‌ها را تنظیم می‌کند.
pdfOptions.setSaveMetafilesAsPng(true);

// سطح فشرده‌سازی متن برای محتوای متنی را تنظیم می‌کند.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// حالت انطباق PDF را تعریف می‌کند.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// یک شیء Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است را نمونه‌سازی می‌کند.
Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    // ارائه را به عنوان یک سند PDF ذخیره می‌کند.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر یک ارائه شامل اسلایدهای مخفی باشد، می‌توانید با استفاده از متد `setShowHiddenSlides` کلاس [PdfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/) اسلایدهای مخفی را به‌عنوان صفحات در PDF نتیجۀ نهایی وارد کنید.

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را با اسلایدهای مخفی به PDF تبدیل کنید:

```java
import com.aspose.slides.*;

// یک شیء Presentation را نمونه‌سازی می‌کند که نمایانگر یک فایل PowerPoint یا OpenDocument است.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // یک شیء PdfOptions را نمونه‌سازی می‌کند.
    PdfOptions pdfOptions = new PdfOptions();

    // اسلایدهای مخفی را اضافه می‌کند.
    pdfOptions.setShowHiddenSlides(true);

    // ارائه را به عنوان PDF ذخیره می‌کند.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تبدیل PowerPoint به PDF با حفاظت رمز عبور**

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را با استفاده از پارامترهای حفاظت موجود در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/) به PDF محافظت‌شده با رمز عبور تبدیل کنید:

```java
import com.aspose.slides.*;

// یک شیء Presentation را نمونه‌سازی می‌کند که نمایانگر یک فایل PowerPoint یا OpenDocument است.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // یک شیء PdfOptions را نمونه‌سازی می‌کند.
    PdfOptions pdfOptions = new PdfOptions();

    // یک رمز عبور PDF و مجوزهای دسترسی تنظیم می‌کند.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // ارائه را به عنوان PDF ذخیره می‌کند.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تشخیص جایگزینی قلم‌ها**

Aspose.Slides متد `setWarningCallback` تحت کلاس [PdfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/) را فراهم می‌کند که به شما امکان می‌دهد در طول فرآیند تبدیل ارائه به PDF، جایگزینی قلم‌ها را شناسایی کنید.

این کد نشان می‌دهد چگونه جایگزینی قلم‌ها را شناسایی کنید:

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // یک شیء Presentation را نمونه‌سازی می‌کند که نمایانگر یک فایل PowerPoint یا OpenDocument است.
    Presentation presentation = new Presentation("sample.pptx");

    // تابع بازگشت هشدار را در گزینه‌های PDF تنظیم می‌کند.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // ارائه را به عنوان PDF ذخیره می‌کند.
        presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        presentation.dispose();
    }
}

// پیاده‌سازی تابع بازگشت هشدار.
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
برای دریافت بازگردانی هشدارها در طول پردازش رندر مربوط به جایگزینی قلم‌ها، به صفحه [دریافت بازگردانی هشدار برای جایگزینی قلم‌ها](/slides/fa/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) مراجعه کنید.

برای اطلاعات بیشتر درباره جایگزینی قلم، مقالهٔ [جایگزینی قلم](/slides/fa/java/font-substitution/) را ببینید.
{{% /alert %}} 

## **تبدیل اسلایدهای منتخب در PowerPoint به PDF**

این کد نشان می‌دهد چگونه تنها اسلایدهای خاصی از یک ارائه PowerPoint را به PDF تبدیل کنید:

```java
import com.aspose.slides.*;

// یک شیء Presentation را نمونه‌سازی می‌کند که نمایانگر یک فایل PowerPoint یا OpenDocument است.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // آرایه‌ای از شماره‌های اسلایدها را تعیین می‌کند.
    int[] slides = { 1, 3 };

    // ارائه را به عنوان PDF ذخیره می‌کند.
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

// یک شیء Presentation را نمونه‌سازی می‌کند که نمایانگر یک فایل PowerPoint یا OpenDocument است.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// یک ارائه جدید با اندازه اسلاید تنظیم‌شده ایجاد می‌کند.
Presentation resizedPresentation = new Presentation();

try {
    // اندازه سفارشی اسلاید را تنظیم می‌کند.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    // اولین اسلاید را از ارائه اصلی کپی می‌کند.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // اسلاید خالی که ارائه جدید با آن ایجاد شده بود را حذف می‌کند.
    resizedPresentation.getSlides().removeAt(1);

    // ارائه با اندازهٔ تغییر‌یافته را به‌صورت PDF ذخیره می‌کند.
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **تبدیل PowerPoint به PDF در نمای اسلایدهای یادداشت‌ها**

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF که شامل یادداشت‌هاست تبدیل کنید:

```java
import com.aspose.slides.*;

// یک شیء Presentation را نمونه‌سازی می‌کند که نمایانگر یک فایل PowerPoint یا OpenDocument است.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // تنظیم گزینه‌های PDF با چیدمان یادداشت‌ها.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // ارائه را به‌صورت PDF همراه با یادداشت‌ها ذخیره می‌کند.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **دسترس‌پذیری و استانداردهای انطباق برای PDF**

Aspose.Slides به شما اجازه می‌دهد از یک روند تبدیل استفاده کنید که با [راهنمای دسترس‌پذیری محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار باشد. می‌توانید سند PowerPoint را به PDF با هر یک از این استانداردهای انطباق صادر کنید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد یک فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که بر اساس استانداردهای مختلف انطباق، چندین PDF تولید می‌کند:

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
Aspose.Slides عملیات تبدیل PDF را پشتیبانی می‌کند و به شما امکان می‌دهد فایل‌های PDF را به قالب‌های محبوب دیگر تبدیل کنید. می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/fa/java/conversion/pdf-to-html/)، [PDF به تصویر](https://products.aspose.com/slides/fa/java/conversion/pdf-to-image/)، [PDF به JPG](https://products.aspose.com/slides/fa/java/conversion/pdf-to-jpg/)، و [PDF به PNG](https://products.aspose.com/slides/fa/java/conversion/pdf-to-png/) را انجام دهید. سایر عملیات تبدیل PDF به قالب‌های تخصصی—[PDF به SVG](https://products.aspose.com/slides/fa/java/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/fa/java/conversion/pdf-to-tiff/)، و [PDF به XML](https://products.aspose.com/slides/fa/java/conversion/pdf-to-xml/)—نیز پشتیبانی می‌شود.
{{% /alert %}}

> **توجه:** هنگام خروجی به PDF/UA، Aspose.Slides گرافیک‌های پیچیده‌ای مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر به‌صورت جداگانه حفظ نمی‌شوند و ممکن است به‌عنوان artifacts علامت‌گذاری شوند؛ متن جایگزین فقط برای کل شکل فراهم می‌شود.

## **سوالات متداول**

### آیا می‌توانم چندین فایل PowerPoint را به صورت دسته‌ای به PDF تبدیل کنم؟

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی فایل‌های خود را مرور کرده و فرآیند تبدیل را اعمال کنید.

### آیا امکان محافظت با رمز عبور از PDF تبدیل‌شده وجود دارد؟

به‌طور کامل. از کلاس [PdfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/) برای تنظیم رمز عبور و تعریف مجوزهای دسترسی در طول فرآیند تبدیل استفاده کنید.

### چگونه اسلایدهای مخفی را در PDF گنجانده کنم؟

از متد `setShowHiddenSlides` در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/) برای شامل کردن اسلایدهای مخفی در PDF نهایی استفاده کنید.

### آیا Aspose.Slides می‌تواند کیفیت بالای تصویر را در PDF حفظ کند؟

بله، می‌توانید با استفاده از متدهایی مانند `setJpegQuality` و `setSufficientResolution` در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/) کیفیت تصویر را کنترل کنید تا تصاویر با کیفیت بالا در PDF شما قرار گیرند.

### آیا Aspose.Slides استانداردهای انطباق PDF/A را پشتیبانی می‌کند؟

بله، Aspose.Slides به شما امکان صدور PDFهایی که با [استانداردهای مختلف](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfcompliance/) از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار هستند را می‌دهد تا اسناد شما الزامات دسترس‌پذیری و بایگانی را برآورده کنند.

## **منابع اضافی**

- [مستندات Aspose.Slides برای جاوا](/slides/fa/java/)
- [مرجع API Aspose.Slides برای جاوا](https://reference.aspose.com/slides/fa/java/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/fa/conversion)