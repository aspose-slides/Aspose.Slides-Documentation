---
title: تبدیل PPT و PPTX به PDF در Android [ویژگی‌های پیشرفته در برگرفته]
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
- ذخیره PowerPoint به صورت PDF
- ذخیره PPT به صورت PDF
- ذخیره PPTX به صورت PDF
- صدور PPT به PDF
- صدور PPTX به PDF
- پیوست
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "تبدیل PowerPoint PPT/PPTX به PDFهای با کیفیت بالا و جستجوپذیر در Java با استفاده از Aspose.Slides برای Android، همراه با مثال‌های سریع کد و گزینه‌های پیشرفته تبدیل."
---
## **بررسی کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به فرمت PDF در اندروید چندین مزیت دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ چیدمان و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصاویر استفاده کنید، اسلایدهای مخفی را شامل کنید، فایل‌های PDF را با رمز عبور محافظت کنید، جابجایی قلم‌ها را شناسایی کنید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای سازگاری را بر اسناد خروجی اعمال کنید.

## **PowerPoint به PDF تبدیل‌ها**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در فرمت‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) پاس کنید و سپس ارائه را با استفاده از متد [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) به عنوان PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) متد [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) را در اختیار می‌گذارد که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{% alert color="info" title="نکته" %}}
Aspose.Slides برای Android از طریق Java اطلاعات API و شماره نسخه را در اسناد خروجی وارد می‌کند. به عنوان مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقداری به شکل "*Aspose.Slides v XX.XX*" پر می‌کند. **توجه** که نمی‌توانید به Aspose.Slides بگویید این اطلاعات را در اسناد خروجی تغییر یا حذف کند.
{{% /alert %}}

Aspose.Slides به شما اجازه می‌دهد تبدیل کنید:

* کل ارائه‌ها به PDF
* اسلایدهای خاصی از یک ارائه به PDF

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد PDFهای حاصل به‌دقت با ارائه‌های اصلی مطابقت داشته باشند. عناصر و ویژگی‌ها در تبدیل به‌درستی رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندهای هیپرمتنی
* سرصفحه‌ها و پاور‌صفحه‌ها
* گلوله‌ها
* جداول

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائه ارائه‌شده را به PDF با تنظیمات بهینه و در بالاترین سطوح کیفیت تبدیل کند.

مثال زیر یک ارائه را بارگیری کرده و تمام اسلایدهای قابل مشاهده را با استفاده از تنظیمات خروجی پیش‌فرض به PDF ذخیره می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="نکته" %}}
Aspose یک **مبدل PowerPoint به PDF**[**مبدل PowerPoint به PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) رایگان آنلاین ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک آزمایش برای پیاده‌سازی زنده‌ی روش شرح داده شده اینجا انجام دهید.
{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—ویژگی‌های تحت کلاس [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)—را فراهم می‌کند که به شما امکان می‌دهد PDF حاصل را سفارشی کنید، PDF را با رمز عبور قفل کنید یا نحوه پیشرفت فرآیند تبدیل را مشخص کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی تبدیل، می‌توانید تنظیم کیفیت ترجیحی خود برای تصاویر رستر، نحوه پردازش متافایل‌ها، سطح فشرده‌سازی متن، DPI برای تصاویر و موارد دیگر را تعریف کنید.

مثال زیر یک ارائه را به PDF 1.5 صادر می‌کند که کیفیت JPEG روی 90 تنظیم شده، وضوح تصویر روی 300 DPI، متافایل‌ها به‌صورت PNG ذخیره می‌شوند و فشرده‌سازی متن Flate اعمال می‌شود.

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

### **حفظ فایل‌های OLE جاسازی شده به عنوان پیوست‌های PDF**

اگر یک ارائه شامل یک کتاب‌کار Excel جاسازی‌شده باشد، ممکن است بخواهید دریافت‌کنندگان PDF بتوانند به داده‌های کتاب‌کار دسترسی داشته باشند و همچنین اسلایدها را مشاهده کنند. با فراخوانی متد [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) با مقدار `true`، فایل‌های OLE جاسازی‌شده به عنوان پیوست در PDF حاصل حفظ می‌شوند.

مقدار پیش‌فرض `false` است: تصویر پیش‌نمایش یا آیکون شیء OLE بر روی صفحه PDF رندر می‌شود، اما فایل جاسازی‌شده به‌عنوان پیوست شامل نمی‌شود. تنظیم گزینه به `true` علاوه بر این داده‌های فایل را نیز شامل می‌شود. پیش‌نمایش به‌عنوان نمای بصری باقی می‌ماند؛ پیوست به دریافت‌کنندگان اجازه می‌دهد فایل جاسازی‌شده را به‌صورت جداگانه باز یا ذخیره کنند. شیء OLE تبدیل به یک کاربرگ Excel تعاملی در صفحه PDF نمی‌شود.

مثال زیر یک ارائه را که پیشاپیش شامل یک کتاب‌کار Excel جاسازی‌شده است بارگیری می‌کند و آن را به PDF با کتاب‌کار پیوست‌شده صادر می‌کند.

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

1. PDF خروجی را در یک نمایشگر که از پیوست‌های فایل پشتیبانی می‌کند، مانند Adobe Acrobat Reader باز کنید.
2. پنل **پیوست‌ها** نمایشگر را باز کنید و کتاب‌کار جاسازی‌شده را پیدا کنید.
3. پیوست را ذخیره کنید و در Excel باز کنید تا داده‌های آن را بررسی کنید، یا اگر نمایشگر اجازه دهد مستقیماً آن را باز کنید. پیش‌نمایش بر روی صفحه PDF جدا از پیوست است.

{{% alert color="info" title="نکته" %}}
استانداردهای PDF/A محدودیت‌هایی برای پیوست‌ها اعمال می‌کنند: PDF/A-1 افزودن فایل‌های جاسازی‌شده را ممنوع می‌کند، PDF/A-2 فقط اجازه پیوست‌های PDF/A را می‌دهد و PDF/A-3 انواع دیگر فایل‌ها از جمله کتاب‌کارهای Excel را مجاز می‌داند. این‌ها الزامات استانداردها هستند و محدودیت‌های خاص Aspose.Slides نیستند. این مثال از تنظیم پیش‌فرض سازگاری PDF استفاده می‌کند و خروجی PDF/A را نشان نمی‌دهد.
{{% /alert %}}

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر یک ارائه شامل اسلایدهای مخفی باشد، می‌توانید از متد [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) در کلاس [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) استفاده کنید تا اسلایدهای مخفی به‌عنوان صفحات در PDF حاصل گنجانده شوند.

مثال زیر یک ارائه را به PDF صادر می‌کند که شامل هر اسلاید مخفی است.

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

### **تبدیل PowerPoint به PDF با محافظت رمز عبور**

مثال زیر یک ارائه را به PDF صادر می‌کند که برای باز کردن آن نیاز به رمز عبور `password` دارد. مجوزهای دسترسی اجازه چاپ، از جمله چاپ با کیفیت بالا، را می‌دهند.

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

### **شناسایی جابجایی قلم‌ها**

Aspose.Slides متد [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) فراهم می‌کند تا بتوانید جابجایی قلم‌ها را در طول فرآیند تبدیل ارائه به PDF شناسایی کنید.

مثال زیر یک ارائه را به PDF صادر می‌کند و هشدارهای جابجایی قلم را در کنسول چاپ می‌کند. هشدار فقط زمانی چاپ می‌شود که یک قلم غیرقابل دسترس جایگزین شود.

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

{{% alert color="info" title="نکته" %}}
برای اطلاعات بیشتر درباره جابجایی قلم‌ها، مقاله [جابجایی قلم](/slides/fa/androidjava/font-substitution/) را ببینید.
{{% /alert %}}

## **تبدیل اسلایدهای انتخابی از PowerPoint به PDF**

مثال زیر اسلایدهای 1 و 3 را از یک ارائه به PDF صادر می‌کند. شماره‌های اسلاید در این آرایه از یک شروع می‌شوند و ارائه ورودی باید حداقل سه اسلاید داشته باشد.

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

مثال زیر اسلاید اول را از یک ارائه به یک ارائه جدید با اندازه اسلاید 612 × 792 نقطه (8.5 × 11 اینچ) کپی می‌کند. محتویات اسلاید به‌گونه‌ای مقیاس می‌شود که در چارچوب بگنجد و اسلاید تک به PDF صادر می‌شود.

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

    // حذف اسلاید خالی که ارائه جدید با آن ساخته شده است.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **تبدیل PowerPoint به PDF در نمای اسلاید یادداشت‌ها**

مثال زیر یک ارائه را به PDF صادر می‌کند، به‌طوری که یادداشت‌های گوینده هر اسلاید زیر اسلاید قرار می‌گیرد. برای دیدن نتیجه از ارائه‌ای که شامل یادداشت‌های گوینده باشد استفاده کنید.

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

## **دسترس‌پذیری و استانداردهای سازگاری برای PDF**

Aspose.Slides به شما اجازه می‌دهد از روشی برای تبدیل استفاده کنید که با [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار باشد. می‌توانید یک سند PowerPoint را به PDF صادر کنید و از هر یک از این استانداردهای سازگاری استفاده کنید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد یک فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که بر اساس استانداردهای مختلف سازگاری، چندین PDF تولید می‌کند:

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

{{% alert color="info" title="نکته" %}}
Aspose.Slides عملیات‌های تبدیل PDF را پشتیبانی می‌کند و امکان تبدیل فایل‌های PDF به فرمت‌های محبوب را فراهم می‌آورد. می‌توانید تبدیل‌های [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)، [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/)، [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)، و [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) را انجام دهید. دیگر عملیات‌های تبدیل PDF به فرمت‌های تخصصی—مانند [PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)، [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)، و [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—نیز پشتیبانی می‌شوند.
{{% /alert %}}

> **توجه:** هنگام صادرات به PDF/UA، Aspose.Slides گرافیک‌های پیچیده‌ای مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر به‌صورت محتواهای جداگانه حفظ نمی‌شوند و ممکن است به‌عنوان artifacts علامت‌گذاری شوند؛ متن جایگزین تنها برای کل شکل ارائه می‌شود.

## **سؤالات متداول**

**آیا می‌توانم چندین فایل PowerPoint را به صورت دسته‌ای به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید در حلقه‌ای فایل‌های خود را پیمایش کنید و فرآیند تبدیل را برنامه‌نویسی کنید.

**آیا امکان محافظت رمز عبور برای PDF تبدیل‌شده وجود دارد؟**

بله. از کلاس [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) برای تنظیم رمز عبور و تعریف مجوزهای دسترسی در طول فرآیند تبدیل استفاده کنید.

**چگونه می‌توانم اسلایدهای مخفی را در PDF گنجانم؟**

متد [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) را با مقدار `true` در کلاس [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) فراخوانی کنید تا اسلایدهای مخفی در PDF حاصل گنجانده شوند.

**آیا Aspose.Slides می‌تواند کیفیت بالای تصویر را در PDF حفظ کند؟**

بله، می‌توانید با استفاده از متدهایی مانند [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) و [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) در کلاس [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) کیفیت تصویر را کنترل کنید تا تصاویر با کیفیت بالا در PDF شما حفظ شوند.

**آیا Aspose.Slides از استانداردهای سازگاری PDF/A پشتیبانی می‌کند؟**

بله، Aspose.Slides به شما اجازه می‌دهد PDFهایی صادر کنید که با [various standards](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/) شامل PDF/A1a، PDF/A1b و PDF/UA سازگار باشند و تضمین می‌کند اسناد شما الزامات دسترس‌پذیری و بایگانی را برآورده کنند.

## **منابع اضافی**

- [مستندات Aspose.Slides برای Android از طریق Java](/slides/fa/androidjava/)
- [مرجع API Aspose.Slides برای Android از طریق Java](https://reference.aspose.com/slides/androidjava/)
- [مبدل‌های رایگان آنلاین Aspose](https://products.aspose.app/slides/conversion)