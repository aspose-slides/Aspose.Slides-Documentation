---
title: تبدیل PPT و PPTX به PDF در Java [ویژگی‌های پیشرفته گنجانده شده]
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
- پیوست
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "PowerPoint PPT/PPTX را در Java با استفاده از Aspose.Slides به PDFهای با کیفیت بالا و جستجوپذیر تبدیل کنید، همراه با مثال‌های کد سریع و گزینه‌های پیشرفتهٔ تبدیل."
---
## **بررسی کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به فرمت PDF در Java چندین مزیت دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ چیدمان و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای پنهان را شامل کنید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی فونت‌ها را شناسایی کنید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای انطباق را بر اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در فرمت‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به‌عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) پاس می‌دهید و سپس ارائه را با استفاده از متد [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) به PDF ذخیره می‌کنید. کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) متد [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) را ارائه می‌دهد که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{% alert color="info" title="Note" %}}
Aspose.Slides برای Java اطلاعات API و شماره نسخه خود را به اسناد خروجی اضافه می‌کند. به عنوان مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با «*Aspose.Slides*» و فیلد PDF Producer را با مقداری به شکل «*Aspose.Slides v XX.XX*» پر می‌کند. **توجه** داشته باشید که نمی‌توانید به Aspose.Slides بگویید این اطلاعات را از اسناد خروجی تغییر یا حذف کند.
{{% /alert %}}

Aspose.Slides به شما اجازه می‌دهد تا تبدیل کنید:

* کل ارائه‌ها به PDF
* اسلایدهای خاصی از یک ارائه به PDF

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد که PDFهای حاصل به‌دقت مشابه ارائه‌های اصلی باشند. عناصر و ویژگی‌ها به‌دقت در تبدیل رندر می‌شوند، شامل:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* هایپرلینک‌ها
* سرصفحات و پاصفحات
* گلوله‌ها
* جداول

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائهٔ ارائه‌شده را با تنظیمات بهینه و در بالاترین سطوح کیفیت به PDF تبدیل کند.

مثال زیر یک ارائه را بارگذاری می‌کند و تمام اسلایدهای قابل مشاهده را با تنظیمات پیش‌فرض صادرات به PDF ذخیره می‌کند.

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
Aspose یک مبدل آنلاین رایگان [**مبدل PowerPoint به PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید این مبدل را برای امتحان اجرای زندهٔ روش شرح داده‌شده در اینجا استفاده کنید.
{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—خصوصیات تحت کلاس [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)—را فراهم می‌کند که به شما اجازه می‌دهد PDF حاصل را سفارشی کنید، PDF را با رمز عبور قفل کنید، یا نحوهٔ پیشبرد فرآیند تبدیل را مشخص کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی تبدیل، می‌توانید تنظیم کیفیت دلخواه برای تصاویر رستر، نحوهٔ پردازش متافایل‌ها، سطح فشرده‌سازی متن، DPI تصاویر و موارد دیگر را تعریف کنید.

مثال زیر یک ارائه را با PDF 1.5، کیفیت JPEG برابر 90، وضوح تصویر 300 DPI، ذخیره متافایل‌ها به صورت PNG و فشرده‌سازی متن Flate به PDF صادر می‌کند.

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

### **حفظ فایل‌های OLE جاسازی‌شده به‌عنوان پیوست‌های PDF**

اگر یک ارائه شامل یک کاربری‌نامه Excel جاسازی‌شده باشد، ممکن است بخواهید دریافت‌کنندگان PDF به داده‌های کاربری‌نامه دسترسی داشته باشند و در عین حال اسلایدها را مشاهده کنند. با فراخوانی متد [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) با مقدار `true` می‌توانید فایل‌های OLE جاسازی‌شده را به‌عنوان پیوست در PDF حاصل حفظ کنید.

مقدار پیش‌فرض `false` است: تصویر پیش‌نمایش یا آیکون شیء OLE روی صفحه PDF رندر می‌شود، اما فایل جاسازی‌شده به‌عنوان پیوست شامل نمی‌شود. تنظیم این گزینه به `true` علاوه بر این دادهٔ فایل را نیز شامل می‌شود. پیش‌نمایش همچنان یک نمای بصری باقی می‌ماند؛ پیوست به دریافت‌کنندگان امکان می‌دهد فایل جاسازی‌شده را به‌صورت جداگانه باز یا ذخیره کنند. شیء OLE تبدیل به یک کاربرگ Excel تعاملی روی صفحه PDF نمی‌شود.

مثال زیر یک ارائه را که قبلاً شامل یک کاربری‌نامه Excel جاسازی‌شده است بارگذاری کرده و با پیوست کاربری‌نامه به PDF صادر می‌کند.

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

1. PDF صادرشده را در برنامه‌ای که قابلیت پیوست فایل‌ها را دارد (مانند Adobe Acrobat Reader) باز کنید.
2. پنل **Attachments** برنامه را باز کنید و کاربری‌نامه جاسازی‌شده را پیدا کنید.
3. پیوست را ذخیره کنید و در Excel باز کنید تا داده‌ها را بررسی کنید، یا در صورت امکان مستقیماً در برنامه مرورگر باز کنید. پیش‌نمایش روی صفحه PDF جدا از پیوست است.

{{% alert color="info" title="Note" %}}
استانداردهای PDF/A محدودیت‌هایی برای پیوست‌ها اعمال می‌کنند: PDF/A-1 از فایل‌های جاسازی‌شده منع می‌کند، PDF/A-2 تنها پیوست‌های PDF/A را مجاز می‌داند و PDF/A-3 انواع دیگر فایل‌ها از جمله کاربری‌نامه‌های Excel را اجازه می‌دهد. این موارد نیازهای استاندارد هستند، نه محدودیت‌های خاص Aspose.Slides. این مثال از تنظیم پیش‌فرض انطباق PDF استفاده می‌کند و خروجی PDF/A را نشان نمی‌دهد.
{{% /alert %}}

### **تبدیل PowerPoint به PDF با اسلایدهای پنهان**

اگر یک ارائه شامل اسلایدهای پنهان باشد، می‌توانید با استفاده از متد [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) از کلاس [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) اسلایدهای پنهان را به‌عنوان صفحات در PDF حاصل شامل کنید.

مثال زیر یک ارائه را با تمام اسلایدهای پنهان به PDF صادر می‌کند.

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

مثال زیر یک ارائه را به PDF صادر می‌کند که برای باز کردن به رمز `password` نیاز دارد. مجوزهای دسترسی چاپ، از جمله چاپ با کیفیت بالا، را اجازه می‌دهد.

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

Aspose.Slides متد [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) فراهم می‌کند تا بتوانید در طول فرآیند تبدیل ارائه به PDF جایگزینی فونت‌ها را شناسایی کنید.

مثال زیر یک ارائه را به PDF صادر می‌کند و هشدارهای جایگزینی فونت را در کنسول چاپ می‌کند. یک هشدار فقط زمانی چاپ می‌شود که یک فونت غیرقابل دسترس در حین صادرات جایگزین شود.

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
برای اطلاعات بیشتر دربارهٔ جایگزینی فونت، مقالهٔ [Font Substitution](/slides/fa/java/font-substitution/) را ببینید.
{{% /alert %}} 

### **پردازش فونت‌هایی که قلم ضخیم اختصاصی ندارند**

یک ارائه می‌تواند قالب‌گیری بولد را بر متن اعمال کند حتی اگر فونت آن قلم ضخیم اختصاصی نداشته باشد. متن می‌تواند همچنان به‌صورت بولد ظاهر شود از طریق بولد مصنوعی که گلیف‌های عادی را به‌صورت مصنوعی ضخیم می‌کند. وقتی این متن در PDF بسیار سنگین یا متفاوت از ظاهر موردنظر به‌نظر می‌رسد، می‌توانید با فراخوانی متد [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) با مقدار `true` این گزینه را فعال کنید. این گزینه متن تحت تاثیر را به‌صورت bitmap هنگام صادرات PDF رستر می‌کند و می‌تواند ظاهر آن را برای برخی فونت‌ها بهبود بخشد. مقدار پیش‌فرض آن `false` است.

نمونه ارائه دارای دو جعبه متن است: یکی با متن معمولی و دیگری با قالب‌گیری بولد بر همان فونت که قلم ضخیم اختصاصی ندارد. مثال زیر ارائه را بارگذاری می‌کند، رسترینگ سبک‌های فونت پشتیبانی‌نشده را فعال می‌کند و آن را به PDF صادر می‌نماید:

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

پیش‌نمایش‌های زیر خروجی غیرفعال و خروجی فعال را نشان می‌دهند. در این مثال، متن بولد با گزینه غیرفعال خطوط ضخیم‌تری دارد. با فعال‌سازی گزینه، خطوط آن نازک‌تر هستند؛ متن معمولی تغییر نمی‌کند. قبل از انتخاب تنظیم برای ارائهٔ خود نتایج را مقایسه کنید.

| گزینه غیرفعال (`false`، پیش‌فرض) | گزینه فعال (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

در این مثال، فعال‌سازی گزینه تنها متن بولد را به bitmap تبدیل می‌کند: بدون OCR نمی‌توان آن را انتخاب، کپی یا جستجو کرد و لبه‌های آن در بزرگ‌نمایی 800٪ نرم‌تر به‌نظر می‌رسد. متن معمولی همچنان قابل جستجو باقی می‌ماند. وقتی گزینه غیرفعال باشد، هر دو رشته به‌صورت متن باقی می‌مانند.

این گزینه متن قالب‌دار به‌صورت بولد را وقتی فونت قلم ضخیم اختصاصی ندارد رستر می‌کند. [Font substitution](/slides/fa/java/font-substitution/) به‌جای آن فونت دیگری را وقتی فونت اصلی در دسترس نیست انتخاب می‌کند.

## **تبدیل اسلایدهای انتخابی از PowerPoint به PDF**

مثال زیر اسلایدهای 1 و 3 را از یک ارائه به PDF صادر می‌کند. شماره اسلایدها در این آرایه یک‌پایه هستند و ارائهٔ ورودی باید حداقل سه اسلاید داشته باشد.

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

## **تبدیل PowerPoint به PDF با اندازه سفارشی اسلاید**

مثال زیر اولین اسلاید را از یک ارائه به یک ارائهٔ جدید که اندازه اسلاید آن 612 × 792 نقطه (8.5 × 11 اینچ) است، کپی می‌کند. محتویات اسلاید را برای پر شدن مقیاس می‌کند و اسلاید تک را به PDF صادر می‌نماید.

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

    // اسلاید خالی که ارائه جدید با آن ایجاد شده بود را حذف کنید.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **تبدیل PowerPoint به PDF در نمای اسلاید نکات**

مثال زیر یک ارائه را به PDF صادر می‌کند به‌گونه‌ای که یادداشت‌های گوینده هر اسلاید زیر اسلاید قرار می‌گیرد. برای مشاهدهٔ نتیجه از یک ارائهٔ دارای یادداشت گوینده استفاده کنید.

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

## **استانداردهای دسترسی و انطباق برای PDF**

Aspose.Slides به شما اجازه می‌دهد از روشی استفاده کنید که با [راهنمای دسترسی به محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار باشد. می‌توانید یک سند PowerPoint را به PDF صادر کنید و هر یک از این استانداردهای انطباق را به کار ببرید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

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
Aspose.Slides عملیات‌های تبدیل PDF را پشتیبانی می‌کند و به شما اجازه می‌دهد فایل‌های PDF را به فرمت‌های محبوب تبدیل کنید. می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)، [PDF به تصویر](https://products.aspose.com/slides/java/conversion/pdf-to-image/)، [PDF به JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)، و [PDF به PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) را انجام دهید. سایر عملیات‌های تبدیل PDF به فرمت‌های تخصصی—[PDF به SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)، و [PDF به XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—نیز پشتیبانی می‌شوند.
{{% /alert %}}

> **توجه:** هنگام خروجی به PDF/UA، Aspose.Slides گرافیک‌های پیچیده‌ای مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد درنظر می‌گیرد. عناصر مسیر جداگانه به‌عنوان محتوای مستقل حفظ نمی‌شوند و ممکن است به‌عنوان artifacts علامت‌گذاری شوند؛ متن جایگزین فقط برای کل شکل فراهم می‌شود.

## **سوالات متداول**

**آیا می‌توانم چندین فایل PowerPoint را به صورت دسته‌ای به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی به‌طور متوالی بر روی فایل‌های خود پیمایش کنید و فرآیند تبدیل را اعمال کنید.

**آیا می‌توان PDF تبدیل‌شده را با رمز عبور محافظت کرد؟**

بله. با استفاده از کلاس [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) می‌توانید رمز عبور را تنظیم کرده و مجوزهای دسترسی را در طول فرآیند تبدیل تعریف کنید.

**چگونه می‌توانم اسلایدهای پنهان را در PDF شامل کنم؟**

با فراخوانی متد [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) با مقدار `true` در کلاس [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) می‌توانید اسلایدهای پنهان را در PDF حاصل به‌عنوان صفحات اضافه کنید.

**آیا Aspose.Slides می‌تواند کیفیت بالای تصویر را در PDF حفظ کند؟**

بله، می‌توانید با استفاده از متدهایی مانند [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) و [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) در کلاس [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) کیفیت تصویر را کنترل کنید تا تصاویر با کیفیت بالا در PDF شما قرار گیرند.

**آیا Aspose.Slides از استانداردهای انطباق PDF/A پشتیبانی می‌کند؟**

بله، Aspose.Slides به شما اجازه می‌دهد PDFهایی را صادر کنید که با [استانداردهای مختلف](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/) از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند و اطمینان حاصل کنید اسناد شما نیازهای دسترسی و بایگانی را برآورده می‌کنند.

## **منابع اضافی**

- [مستندات Aspose.Slides برای Java](/slides/fa/java/)
- [مرجع API Aspose.Slides برای Java](https://reference.aspose.com/slides/java/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/conversion)