---
title: Convert PPT and PPTX to PDF in Java [Advanced Features Included]
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
- ذخیره PowerPoint به صورت PDF
- ذخیره PPT به صورت PDF
- ذخیره PPTX به صورت PDF
- خروجی PPT به PDF
- خروجی PPTX به PDF
- پیوست
- PDF/A1a
- PDF/A1b
- PDF/UA
- جاوا
- Aspose.Slides
description: "تبدیل PowerPoint PPT/PPTX به PDFهای با کیفیت بالا و قابل جستجو در جاوا با استفاده از Aspose.Slides، همراه با مثال‌های سریع کد و گزینه‌های پیشرفته تبدیل."
---
## **مرور کلی**

تبدیل ارائه‌های PowerPoint (PPT, PPTX, ODP و غیره) به فرمت PDF در جاوا مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ طرح‌بندی و قالب‌بندی ارائه شما. این راهنما نحوه تبدیل ارائه‌ها به اسناد PDF، استفاده از گزینه‌های مختلف برای کنترل کیفیت تصویر، شامل کردن اسلایدهای مخفی، حفاظت از فایل‌های PDF با رمز عبور، تشخیص جایگزینی فونت، انتخاب اسلایدهای خاص برای تبدیل و اعمال استانداردهای انطباق بر اسناد خروجی را نشان می‌دهد.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در فرمت‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به‌عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) پاس دهید و سپس با استفاده از متد [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ارائه را به PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) متد [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) را ارائه می‌دهد که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{% alert color="info" title="Note" %}}
Aspose.Slides برای جاوا اطلاعات API و شماره نسخه خود را در اسناد خروجی درج می‌کند. به عنوان مثال، هنگام تبدیل یک ارائه به PDF، فیلد Application با "*Aspose.Slides*" پر می‌شود و فیلد PDF Producer مقداری به شکل "*Aspose.Slides v XX.XX*" دریافت می‌کند. **Note** اینکه نمی‌توانید Aspose.Slides را مجبور کنید این اطلاعات را در اسناد خروجی تغییر یا حذف کند.
{{% /alert %}}

Aspose.Slides به شما اجازه می‌دهد:

* کل ارائه‌ها را به PDF تبدیل کنید
* اسلایدهای خاصی از یک ارائه را به PDF تبدیل کنید

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد PDFهای حاصل به‌دقت با ارائه‌های اصلی مطابقت دارند. عناصر و ویژگی‌ها به‌صورت دقیق در حین تبدیل رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندهای هیپرمتن
* سرصفحه‌ها و پاورقی‌ها
* گلوله‌ها
* جدول‌ها

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائه ارائه‌شده را با تنظیمات بهینه و در بالاترین سطوح کیفیت به PDF تبدیل کند.

مثال زیر یک ارائه را بارگذاری کرده و تمام اسلایدهای قابل مشاهده را با تنظیمات پیش‌فرض صادرات به PDF ذخیره می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose یک **مبدل آنلاین رایگان PowerPoint به PDF**[**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با استفاده از این مبدل، یک آزمایش زنده از روشی که در اینجا توصیف شده است، انجام دهید.
{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—خصوصیات تحت کلاس [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)—را فراهم می‌کند که به شما اجازه می‌دهد PDF نهایی را سفارشی کنید، PDF را با رمز عبور قفل کنید یا نحوه پیشرفت فرآیند تبدیل را مشخص کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های تبدیل سفارشی می‌توانید تنظیم کیفیت ترجیحی خود برای تصاویر رستری را تعریف کنید، نحوه پردازش متافایل‌ها را مشخص کنید، سطح فشرده‌سازی متن را تنظیم کنید، DPI تصاویر را پیکربندی کنید و موارد دیگر.

مثال زیر یک ارائه را به PDF 1.5 صادر می‌کند که کیفیت JPEG بر روی 90 تنظیم شده، وضوح تصویر بر 300 DPI، متافایل‌ها به‌صورت PNG ذخیره می‌شوند و فشرده‌سازی متن Flate اعمال می‌شود.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setJpegQuality((byte)90);
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(PdfTextCompression.Flate);
pdfOptions.setCompliance(PdfCompliance.Pdf15);

Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **حفظ فایل‌های OLE تعبیه‌شده به‌عنوان پیوست‌های PDF**

اگر ارائه شامل یک کارپنج Excel تعبیه‌شده باشد، ممکن است بخواهید دریافت‌کنندگان PDF به داده‌های کارپنج دسترسی داشته باشند و همچنین اسلایدها را مشاهده کنند. برای حفظ فایل‌های OLE تعبیه‌شده به‌عنوان پیوست در PDF حاصل، متد [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) را با مقدار `true` فراخوانی کنید.

مقدار پیش‌فرض `false` است: تصویر پیش‌نمایش یا نماد شی OLE بر روی صفحه PDF رندر می‌شود، اما فایل تعبیه‌شده به‌عنوان پیوست شامل نمی‌شود. تنظیم این گزینه به `true` علاوه بر این دادهٔ فایل را شامل می‌شود. پیش‌نمایش همچنان یک نمایش بصری است؛ پیوست به دریافت‌کنندگان اجازه می‌دهد فایل تعبیه‌شده را به‌صورت جداگانه باز یا ذخیره کنند. شی OLE تبدیل به یک کارپنج Excel تعاملی در صفحه PDF نمی‌شود.

مثال زیر یک ارائه را که از پیش شامل کارپنج Excel تعبیه‌شده است بارگذاری کرده و آن را با پیوست کارپنج به PDF صادر می‌کند.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setIncludeOleData(true);

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

برای بررسی نتیجه:

1. PDF صادرشده را در یک نمایشگر که از پیوست‌های فایل پشتیبانی می‌کند، مثلاً Adobe Acrobat Reader، باز کنید.
2. پنل **Attachments** نمایشگر را باز کنید و کارپنج تعبیه‌شده را پیدا کنید.
3. پیوست را ذخیره کنید و در Excel باز کنید تا داده‌ها را بررسی کنید، یا اگر نمایشگر اجازه می‌دهد، مستقیماً باز کنید. پیش‌نمایش بر روی صفحه PDF جدا از پیوست است.

{{% alert color="info" title="Note" %}}
استانداردهای PDF/A محدودیت‌هایی بر پیوست‌ها اعمال می‌کنند: PDF/A-1 از فایل‌های تعبیه‌شده منع می‌کند، PDF/A-2 فقط پیوست‌های PDF/A را مجاز می‌داند و PDF/A-3 انواع دیگر فایل‌ها از جمله کارپنج‌های Excel را اجازه می‌دهد. این محدودیت‌ها الزام‌های استاندارد هستند، نه محدودیت‌های خاص Aspose.Slides. این مثال از تنظیم پیش‌فرض انطباق PDF استفاده می‌کند و صادرات PDF/A را نشان نمی‌دهد.
{{% /alert %}}

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر ارائه شامل اسلایدهای مخفی باشد، می‌توانید از متد [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) کلاس [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) استفاده کنید تا اسلایدهای مخفی به‌عنوان صفحات در PDF حاصل گنجانده شوند.

مثال زیر یک ارائه را به PDF صادر می‌کند در حالی که اسلایدهای مخفی نیز شامل می‌شوند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setShowHiddenSlides(true);

    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تبدیل PowerPoint به PDF با رمز عبور**

مثال زیر یک ارائه را به PDF صادر می‌کند که برای باز کردن به رمز عبور `password` نیاز دارد. اجازه دسترسی چاپ، از جمله چاپ با کیفیت بالا، را نیز فراهم می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تشخیص جایگزینی فونت‌ها**

Aspose.Slides متد [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) فراهم می‌کند که به شما امکان می‌دهد در حین فرآیند تبدیل ارائه به PDF، جایگزینی فونت‌ها را شناسایی کنید.

مثال زیر یک ارائه را به PDF صادر می‌کند و هشدارهای جایگزینی فونت را در کنسول چاپ می‌کند. هشدار فقط زمانی چاپ می‌شود که یک فونت ناموجود در حین صادرات جایگزین شود.

```java
import com.aspose.slides.*;

class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setWarningCallback(new FontSubstitutionHandler());

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
برای اطلاعات بیشتر درباره جایگزینی فونت، به مقاله [Font Substitution](/slides/fa/java/font-substitution/) مراجعه کنید.
{{% /alert %}} 

## **تبدیل اسلایدهای انتخابی از PowerPoint به PDF**

مثال زیر اسلایدهای 1 و 3 را از یک ارائه به PDF صادر می‌کند. شماره‌های اسلاید در این آرایه از یک‌به‌یک شروع می‌شوند و ارائه ورودی باید حداقل سه اسلاید داشته باشد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    int[] slides = { 1, 3 };
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **تبدیل PowerPoint به PDF با اندازه اسلاید سفارشی**

مثال زیر اولین اسلاید را از یک ارائه به یک ارائه جدید با اندازه اسلاید 612 × 792 نقطه (8.5 × 11 اینچ) کپی می‌کند. محتویات اسلاید را برای تناسب مقیاس می‌کند و اسلاید واحد را به PDF صادر می‌نماید.

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation resizedPresentation = new Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // اسلاید خالی که هنگام ایجاد ارائه جدید ایجاد شد را حذف کنید.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **تبدیل PowerPoint به PDF در نمای اسلاید یادداشت‌ها**

مثال زیر یک ارائه را به PDF صادر می‌کند به‌طوری که یادداشت‌های گوینده هر اسلاید در زیر اسلاید قرار می‌گیرد. برای مشاهده نتیجه، ارائه‌ای شامل یادداشت‌های گوینده استفاده کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **دسترس‌پذیری و استانداردهای انطباق برای PDF**

Aspose.Slides به شما اجازه می‌دهد از یک فرآیند تبدیل استفاده کنید که با [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) منطبق باشد. می‌توانید یک سند PowerPoint را به PDF صادر کنید با هر یک از این استانداردهای انطباق: **PDF/A1a**, **PDF/A1b**, و **PDF/UA**.

این کد یک فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که بر اساس استانداردهای مختلف انطباق، چند PDF تولید می‌کند:

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

{{% alert color="info" title="Note" %}}
Aspose.Slides عملیات تبدیل PDF را پشتیبانی می‌کند و به شما امکان می‌دهد فایل‌های PDF را به فرمت‌های محبوب دیگر تبدیل کنید. می‌توانید تبدیل‌های [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)، [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/)، [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)، و [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) را انجام دهید. سایر عملیات تبدیل PDF به فرمت‌های تخصصی—[PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)، [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)، و [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—هم نیز پشتیبانی می‌شوند.
{{% /alert %}}

> **Note:** هنگام صادرات به PDF/UA، Aspose.Slides گرافیک‌های پیچیده‌ای مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر جداگانه به‌عنوان محتوا حفظ نمی‌شوند و ممکن است به‌عنوان artefacts علامت‌گذاری شوند؛ متن جایگزین فقط برای کل شکل ارائه می‌شود.

## **سؤالات متداول**

**آیا می‌توانم چندین فایل PowerPoint را به‌صورت دسته‌ای به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی بر روی فایل‌های خود iterating کنید و فرآیند تبدیل را اعمال کنید.

**آیا می‌توان PDF تبدیل‌شده را با رمز عبور محافظت کرد؟**

بله. از کلاس [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) برای تنظیم رمز عبور و تعریف مجوزهای دسترسی در حین فرآیند تبدیل استفاده کنید.

**چگونه می‌توان اسلایدهای مخفی را در PDF گنجاند؟**

متد [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) را با مقدار `true` در کلاس [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) فراخوانی کنید تا اسلایدهای مخفی در PDF نهایی گنجانده شوند.

**آیا Aspose.Slides می‌تواند کیفیت تصویر بالا را در PDF حفظ کند؟**

بله، می‌توانید با استفاده از متدهایی مانند [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) و [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) در کلاس [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) کیفیت تصویر را در PDF خود تضمین کنید.

**آیا Aspose.Slides از استانداردهای انطباق PDF/A پشتیبانی می‌کند؟**

بله، Aspose.Slides به شما امکان می‌دهد PDFهایی صادر کنید که با [various standards](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/) از جمله PDF/A1a، PDF/A1b و PDF/UA منطبق باشند و تضمین کنند اسناد شما الزامات دسترس‌پذیری و آرشیو را برآورده می‌سازند.

## **منابع تکمیلی**

- [Aspose.Slides for Java Documentation](/slides/fa/java/)
- [Aspose.Slides for Java API Reference](https://reference.aspose.com/slides/java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)