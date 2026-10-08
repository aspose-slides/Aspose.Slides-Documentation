---
title: تبدیل PPT و PPTX به PDF در Android [قابلیت‌های پیشرفته گنجانده شده]
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
- پیوست
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "PowerPoint PPT/PPTX را به PDFهای با کیفیت بالا و قابل جستجو در Java با استفاده از Aspose.Slides برای Android تبدیل کنید، با مثال‌های کد سریع و گزینه‌های پیشرفته تبدیل."
---
## **مرور کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به قالب PDF در Android مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ چینش و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را شامل کنید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی قلم‌ها را شناسایی کنید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای انطباق را بر اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در قالب‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) پاس می‌دهید و سپس با استفاده از متد [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) ارائه را به PDF ذخیره می‌کنید. کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) متد [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) را در اختیار می‌گذارد که به طور معمول برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{% alert color="info" title="توجه" %}}

Aspose.Slides for Android via Java اطلاعات API و شماره نسخه خود را در اسناد خروجی وارد می‌کند. به‌عنوان مثال، هنگام تبدیل یک ارائه به PDF، فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقداری به شکل "*Aspose.Slides v XX.XX*" پر می‌کند. **توجه** داشته باشید که نمی‌توانید Aspose.Slides را مجبور کنید این اطلاعات را تغییر یا حذف کند.

{{% /alert %}}

Aspose.Slides به شما امکان می‌دهد:

* کل ارائه‌ها را به PDF تبدیل کنید
* اسلایدهای خاصی از یک ارائه را به PDF تبدیل کنید

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند، به‌طوری که PDFهای تولید شده به‌دقت با ارائه‌های اصلی مطابقت داشته باشند. عناصر و ویژگی‌ها در فرآیند تبدیل به‌درستی رندر می‌شوند، از جمله:

* تصویرها
* جعبه‌های متن و شکل‌ها
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندها
* سرصفحه و پاورقی
* بولت‌ها
* جدول‌ها

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائه ارائه‌شده را با تنظیمات بهینه و در بالاترین سطوح کیفیت به PDF تبدیل کند.

مثال زیر یک ارائه را بارگذاری می‌کند و تمام اسلایدهای قابل مشاهده را با تنظیمات خروجی پیش‌فرض به PDF ذخیره می‌نماید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="توجه" %}}

Aspose یک مبدل آنلاین رایگان [**PowerPoint به PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک آزمایش زنده از روش شرح داده شده در اینجا انجام دهید.

{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—دارای خصوصیات تحت کلاس [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)—را فراهم می‌کند که به شما اجازه می‌دهد PDF خروجی را شخصی‌سازی کنید، PDF را با رمز عبور قفل کنید یا نحوه پیشرفت فرآیند تبدیل را مشخص کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی می‌توانید تنظیم کیفیت دلخواه خود برای تصاویر رستر، نحوه‌ٔ پردازش متافایل‌ها، سطح فشرده‌سازی متن، DPI برای تصاویر و موارد دیگر را تعریف کنید.

مثال زیر ارائه‌ای را با کیفیت JPEG برابر 90، وضوح تصویر 300 DPI، متافایل‌ها به‌صورت PNG ذخیره و فشرده‌سازی متن Flate به PDF 1.5 صادر می‌کند.

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

### **حفظ فایل‌های OLE جاسازی‌شده به‌عنوان پیوستی‌های PDF**

اگر ارائه شامل یک کتاب‌کار Excel جاسازی‌شده باشد، ممکن است بخواهید دریافت‌کنندگان PDF هم به داده‌های کتاب‌کار دسترسی داشته باشند و هم اسلایدها را ببینند. با فراخوانی متد [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) با مقدار `true` می‌توانید فایل‌های OLE جاسازی‌شده را به‌عنوان پیوست در PDF نهایی حفظ کنید.

مقدار پیش‌فرض `false` است: تصویر پیش‌نمایش یا آیکون شی OLE روی صفحه PDF رندر می‌شود، اما فایل جاسازی‌شده به‌عنوان پیوست گنجانده نمی‌شود. تنظیم این گزینه بر روی `true` علاوه بر این، دادهٔ فایل را نیز شامل می‌شود. پیش‌نمایش همچنان یک نمایش بصری باقی می‌ماند؛ پیوست به دریافت‌کنندگان اجازه می‌دهد فایل جاسازی‌شده را به‌صورت جداگانه باز یا ذخیره کنند. شی OLE به‌عنوان یک کاربرگ تعاملی Excel در صفحه PDF تبدیل نمی‌شود.

مثال زیر ارائه‌ای را بارگذاری می‌کند که پیشاپیش شامل یک کتاب‌کار Excel جاسازی‌شده است و آن را با کتاب‌کار پیوست‌شده به PDF صادر می‌کند.

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

1. PDF صادرشده را در یک نمایشگر که از پیوست‌های فایل پشتیبانی می‌کند (مانند Adobe Acrobat Reader) باز کنید.
2. پنل **Attachments** نمایشگر را باز کنید و کتاب‌کار جاسازی‌شده را پیدا کنید.
3. پیوست را ذخیره کنید و در Excel باز کنید تا داده‌های آن را بررسی کنید، یا در صورت امکان مستقیم باز کنید. پیش‌نمایش روی صفحه PDF جدا از پیوست است.

{{% alert color="info" title="توجه" %}}

استانداردهای PDF/A محدودیت‌هایی برای پیوست‌ها اعمال می‌کنند: PDF/A‑1 از فایل‌های جاسازی‌شده منع می‌کند، PDF/A‑2 فقط پیوست‌های PDF/A را اجازه می‌دهد و PDF/A‑3 انواع دیگر فایل‌ها از جمله کتاب‌کارهای Excel را مجاز می‌سازد. این محدودیت‌ها بخشی از استانداردها هستند و نه محدودیت‌های خاص Aspose.Slides. این مثال از تنظیم پیش‌فرض انطباق PDF استفاده می‌کند و خروجی PDF/A را نشان نمی‌دهد.

{{% /alert %}}

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر ارائه شامل اسلایدهای مخفی باشد، می‌توانید با استفاده از متد [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) از کلاس [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) اسلایدهای مخفی را به‌عنوان صفحات در PDF نهایی گنجانده کنید.

مثال زیر ارائه‌ای را به PDF صادر می‌کند که اسلایدهای مخفی نیز در آن گنجانده شده‌اند.

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

مثال زیر ارائه‌ای را به PDFی صادر می‌کند که برای باز کردن آن نیاز به رمز عبور `password` دارد. مجوزهای دسترسی اجازه چاپ، از جمله چاپ با کیفیت بالا را می‌دهد.

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

### **شناسایی جایگزینی قلم‌ها**

Aspose.Slides متد [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) فراهم می‌کند که به شما امکان می‌دهد جایگزینی قلم‌ها را در طول فرآیند تبدیل ارائه به PDF شناسایی کنید.

مثال زیر ارائه‌ای را به PDF صادر می‌کند و هشدارهای جایگزینی قلم را در کنسول چاپ می‌کند. یک هشدار تنها زمانی چاپ می‌شود که قلمی موجود نباشد و جایگزین شود.

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

{{% alert color="info" title="توجه" %}}

برای اطلاعات بیشتر درباره جایگزینی قلم، مقالهٔ [جایگزینی قلم](/slides/fa/androidjava/font-substitution/) را ببینید.

{{% /alert %}} 

### **مدیریت قلم‌های بدون سبک بولد مخصوص**

یک ارائه می‌تواند قالب‌بندی بولد را بر متنی اعمال کند حتی اگر قلم آن سبک بولد مخصوص نداشته باشد. متن می‌تواند از طریق بولد مصنوعی که گلیف‌های عادی را ضخیم می‌کند، بولد ظاهر شود. وقتی این متن در PDF خیلی سنگین یا متفاوت از ظاهر موردنظر به‌نظر می‌رسد، می‌توانید با فراخوانی متد [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) با مقدار `true` این گزینه را فعال کنید. این گزینه متن تأثیر‌پذیر را هنگام خروجی PDF به صورت یک بیت‌مپ رستر می‌کند و می‌تواند ظاهر آن را برای قلم‌های خاص بهبود بخشد. مقدار پیش‌فرض آن `false` است.

ارائه نمونه شامل دو جعبهٔ متن است: یکی با متن عادی و دیگری با قالب‌بندی بولد بر همان قلم که سبک بولد مخصوصی ندارد. مثال زیر ارائه را بارگذاری می‌کند، رستر کردن سبک‌های قلم پشتیبانی‌نشده را فعال می‌کند و آن را به PDF صادر می‌نماید:

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

Presentation presentation = new Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

پیشنمایش‌های زیر خروجی غیرفعال و فعال را نشان می‌دهند. در این مثال، متن بولد با گزینه غیرفعال خطوط سنگین‌تری دارد. با فعال‌سازی گزینه، خطوط آن نازک‌تر هستند؛ متن عادی بدون تغییر می‌ماند. نتایج را قبل از انتخاب تنظیم برای ارائهٔ خود مقایسه کنید.

| گزینه غیرفعال (`false`، پیش‌فرض) | گزینه فعال (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

در این مثال، فعال‌سازی گزینه فقط متن بولد را به بیت‌مپ تبدیل می‌کند: این متن قابل انتخاب، کپی یا جستجو به‌عنوان متن بدون OCR نیست و لبه‌های آن در بزرگنمایی 800٪ نرم‌تر به‌نظر می‌رسند. متن عادی همچنان جستجوپذیر می‌ماند. با غیرفعال بودن گزینه، هر دو رشته به‌صورت متن باقی می‌مانند.

این گزینه متن قالب‌بندی‌شده به بولد را رستر می‌کند وقتی قلم آن سبک بولد مخصوصی نداشته باشد. [جایگزینی قلم](/slides/fa/androidjava/font-substitution/) به جای آن یک قلم دیگر را هنگامی که قلم اصلی در دسترس نباشد، انتخاب می‌کند.

## **صادرات اسلایدهای انتخابی از PowerPoint به PDF**

مثال زیر اسلایدهای 1 و 3 یک ارائه را به PDF صادر می‌کند. شماره‌های اسلاید در این آرایه یک‌پایه هستند و ارائه ورودی باید حداقل سه اسلاید داشته باشد.

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

## **تبدیل PowerPoint به PDF با اندازهٔ اسلاید سفارشی**

مثال زیر اسلاید اول یک ارائه را به یک ارائهٔ جدید با اندازهٔ اسلاید 612 × 792 نقطه (8.5 × 11 اینچ) کپی می‌کند. محتویات اسلاید را مقیاس می‌دهد تا بگنجد و اسلاید منفرد را به PDF صادر می‌کند.

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

    // اسلاید خالی را که ارائه جدید هنگام ایجاد داشت حذف کنید.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **تبدیل PowerPoint به PDF در نمای اسلاید یادداشت‌ها**

مثال زیر یک ارائه را به PDF صادر می‌کند به‌طوری که یادداشت‌های گویندهٔ هر اسلاید زیر اسلاید قرار می‌گیرد. برای مشاهده نتیجه یک ارائه شامل یادداشت‌های گوینده استفاده کنید.

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

Aspose.Slides به شما اجازه می‌دهد از یک رویهٔ تبدیل استفاده کنید که با [راهنمای دسترس‌پذیری محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار باشد. می‌توانید یک سند PowerPoint را به PDF صادر کنید و از هر یک از این استانداردهای انطباق استفاده کنید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد یک فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که بر اساس استانداردهای انطباق مختلف، چندین PDF تولید می‌کند:

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

{{% alert color="info" title="توجه" %}}

Aspose.Slides عملیات‌های تبدیل PDF را پشتیبانی می‌کند و امکان تبدیل فایل‌های PDF به قالب‌های محبوب را فراهم می‌سازد. می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)، [PDF به تصویر](https://products.aspose.com/slides/java/conversion/pdf-to-image/)، [PDF به JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)، و [PDF به PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) را انجام دهید. سایر عملیات‌های تبدیل PDF به قالب‌های تخصصی—[PDF به SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)، و [PDF به XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—هم قابل پشتیبانی هستند.

{{% /alert %}}

> **توجه:** هنگام خروجی به PDF/UA، Aspose.Slides گرافیک‌های پیچیده‌ای مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر جداگانه به‌عنوان محتوای مستقل حفظ نمی‌شوند و ممکن است به‌عنوان artefact علامت‌دار شوند؛ متن جایگزین فقط برای کل شکل ارائه می‌شود.

## **سؤال‌های متداول**

**آیا می‌توانم چندین فایل PowerPoint را به‌صورت دسته‌ای به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی روی فایل‌های خود پیمایش کنید و فرآیند تبدیل را اعمال نمایید.

**آیا امکان قفل کردن PDF تبدیل‌شده با رمز عبور وجود دارد؟**

بله. از کلاس [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) برای تنظیم رمز عبور و تعریف مجوزهای دسترسی در طول فرآیند تبدیل استفاده کنید.

**چگونه اسلایدهای مخفی را در PDF گنجانده کنم؟**

در کلاس [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) متد [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) را با مقدار `true` صدا بزنید تا اسلایدهای مخفی در PDF نهایی گنجانده شوند.

**آیا Aspose.Slides می‌تواند کیفیت تصویر بالا را در PDF حفظ کند؟**

بله، می‌توانید با استفاده از متدهایی مانند [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) و [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) در کلاس [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) کیفیت تصویر را در PDF خود به‌صورت بالا تضمین کنید.

**آیا Aspose.Slides استانداردهای انطباق PDF/A را پشتیبانی می‌کند؟**

بله، Aspose.Slides به شما امکان می‌دهد PDFهایی صادر کنید که با [استانداردهای مختلف](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/) از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند و تضمین می‌کند اسناد شما الزامات دسترس‌پذیری و بایگانی را برآورده کنند.

## **منابع اضافی**

- [مستندات Aspose.Slides برای Android via Java](/slides/fa/androidjava/)
- [مرجع API Aspose.Slides برای Android via Java](https://reference.aspose.com/slides/androidjava/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/conversion)