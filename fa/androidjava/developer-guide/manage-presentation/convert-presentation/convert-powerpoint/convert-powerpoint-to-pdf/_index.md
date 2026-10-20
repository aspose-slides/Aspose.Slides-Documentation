---
title: تبدیل PPT و PPTX به PDF روی اندروید [قابلیت‌های پیشرفته گنجانده شده]
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
- صادر کردن PPT به PDF
- صادر کردن PPTX به PDF
- پیوست
- PDF/A1a
- PDF/A1b
- PDF/UA
- اندروید
- جاوا
- Aspose.Slides
description: "تبدیل PowerPoint PPT/PPTX به PDFهای با کیفیت بالا و قابل جستجو در جاوا با استفاده از Aspose.Slides برای اندروید، همراه با نمونه‌های کد سریع و گزینه‌های پیشرفته تبدیل."
---
## **نمای کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به فرمت PDF در اندروید مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ طرح‌بندی و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را شامل کنید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی فونت‌ها را شناسایی کنید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای مطابقت را بر اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در فرمت‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) بدهید و سپس ارائه را با استفاده از متد [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) به صورت PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) متد [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) را ارائه می‌دهد که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{% alert color="info" title="Note" %}}
Aspose.Slides برای Android از طریق Java اطلاعات API و شماره نسخه خود را در اسناد خروجی وارد می‌کند. به عنوان مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقداری به فرم "*Aspose.Slides v XX.XX*" پر می‌کند. **نکته** که نمی‌توانید Aspose.Slides را مجبور کنید این اطلاعات را در اسناد خروجی تغییر یا حذف کند.
{{% /alert %}}

Aspose.Slides به شما امکان می‌دهد تا:

* کل ارائه‌ها را به PDF تبدیل کنید
* اسلایدهای خاصی از یک ارائه را به PDF تبدیل کنید

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد که PDFهای حاصل به‌دقت با ارائه‌های اصلی مطابقت داشته باشند. عناصر و ویژگی‌ها به‌صورت دقیق در تبدیل رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و شکل‌ها
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندها
* سرصفحه‌ها و پانویس‌ها
* نمادهای گلوله‌ای
* جداول

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائه‌ی فراهم‌شده را با تنظیمات بهینه و در بالاترین سطوح کیفیت به PDF تبدیل کند.

مثال زیر یک ارائه را بارگذاری می‌کند و تمام اسلایدهای قابل مشاهده را با استفاده از تنظیمات پیش‌فرض خروجی به PDF ذخیره می‌کند.

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
Aspose یک [**مبدل PowerPoint به PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) رایگان آنلاین ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک آزمایش برای اجرای زنده‌ی رویه‌ی توضیح‌داده‌شده انجام دهید.
{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—ویژگی‌هایی در زیر کلاس [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)—را فراهم می‌کند که به شما اجازه می‌دهد PDF حاصل را سفارشی کنید، PDF را با رمز عبور قفل کنید، یا نحوه پیشرفت فرآیند تبدیل را مشخص کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی تبدیل، می‌توانید تنظیم کیفیت دلخواه خود برای تصاویر رستر، نحوه پردازش متافایل‌ها، سطح فشرده‌سازی متن، DPI تصاویر و موارد دیگر را تعریف کنید.

مثال زیر یک ارائه را به PDF 1.5 صادر می‌کند با کیفیت JPEG تنظیم‌شده به 90، رزولوشن تصویر به 300 DPI، متافایل‌ها به صورت PNG ذخیره می‌شوند و فشرده‌سازی متن Flate اعمال می‌شود.

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

### **انتخاب خودکار فشرده‌سازی تصویر**

هنگامی که یک ارائه حاوی تعداد زیادی عکس یا اسکرین‌شات است، کاهش اندازه PDF صادر شده می‌تواند ارسال ایمیل یا بارگیری را آسان‌تر کند. با فراخوانی متد [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) با مقدار `true` به‌صورت خودکار الگوریتم فشرده‌سازی مناسب برای هر تصویر در طول خروجی PDF انتخاب می‌شود.

مثال زیر یک ارائه موجود را بارگذاری می‌کند، انتخاب خودکار فشرده‌سازی تصویر را فعال می‌کند و آن را به عنوان سند PDF ذخیره می‌نماید. تمام تنظیمات دیگر خروجی PDF مقادیر پیش‌فرض خود را حفظ می‌کنند.

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

Presentation presentation = new Presentation("image-heavy.pptx");
try {
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

این گزینه برای هر تصویر یک الگوریتم فشرده‌سازی انتخاب می‌کند. کاهش مقدار پاس شده به [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) به‌جای آن کیفیت تصویر JPEG را کاهش می‌دهد، در حالی که کاهش مقدار پاس شده به [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) به تصاویر اجازه می‌دهد تا به وضوح پایین‌تری نمونه‌برداری شوند که می‌تواند جزئیات را کم کند. فعال‌سازی انتخاب خودکار فشرده‌سازی خود به خود هیچ‌یک از این تنظیمات را کاهش نمی‌دهد.

انتخاب الگوریتم‌های فشرده‌سازی تصویر به زمان پردازش و حافظه بیشتری نیاز دارد. کاهش اندازه به تصاویر ارائه و تنظیمات خروجی بستگی دارد؛ کاهش ثابت برای هر ارائه تضمین نمی‌شود.

### **حفظ فایل‌های OLE جاسازی‌شده به عنوان پیوست‌های PDF**

اگر یک ارائه شامل یک کاربرگ Excel جاسازی‌شده باشد، ممکن است بخواهید دریافت‌کنندگان PDF به داده‌های کاربرگ دسترسی داشته باشند و همزمان اسلایدها را مشاهده کنند. با فراخوانی [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) با مقدار `true` می‌توانید فایل‌های OLE جاسازی‌شده را به‌عنوان پیوست در PDF حاصل حفظ کنید.

مقدار پیش‌فرض `false` است: تصویر پیش‌نمایش یا آیکون شیء OLE بر روی صفحه PDF رندر می‌شود، اما فایل جاسازی‌شده به‌عنوان پیوست گنجانده نمی‌شود. تنظیم گزینه به `true` علاوه بر این داده‌های فایل را شامل می‌شود. پیش‌نمایش به‌عنوان نمای تصویری باقی می‌ماند؛ پیوست به دریافت‌کنندگان امکان می‌دهد فایل جاسازی‌شده را به‌طور جداگانه باز یا ذخیره کنند. شیء OLE تبدیل به یک کاربرگ Excel تعاملی در صفحه PDF نمی‌شود.

مثال زیر یک ارائه را که قبلاً شامل یک کاربرگ Excel جاسازی‌شده است بارگذاری می‌کند و آن را به PDF با پیوست کاربرگ صادر می‌نماید.

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

1. PDF صادر شده را در یک نمایشگر که از پیوست‌های فایل پشتیبانی می‌کند (مانند Adobe Acrobat Reader) باز کنید.
2. پنل **پیوست‌ها** نمایشگر را باز کنید و کاربرگ جاسازی‌شده را پیدا کنید.
3. پیوست را ذخیره کنید و در Excel باز کنید تا داده‌های آن را بررسی کنید، یا اگر نمایشگر اجازه دهد به‌صورت مستقیم باز کنید. پیش‌نمایش در صفحه PDF جدا از پیوست است.

{{% alert color="info" title="Note" %}}
استانداردهای PDF/A محدودیت‌هایی برای پیوست‌ها اعمال می‌کنند: PDF/A-1 فایل‌های جاسازی‌شده را ممنوع می‌کند، PDF/A-2 فقط اجازه پیوست‌های PDF/A را می‌دهد و PDF/A-3 انواع فایل‌های دیگر از جمله کاربرگ‌های Excel را مجاز می‌کند. اینها الزامات استانداردها هستند، نه محدودیت‌های خاص Aspose.Slides. این مثال از تنظیم پیش‌فرض تطابق PDF استفاده می‌کند و خروجی PDF/A را نشان نمی‌دهد.
{{% /alert %}}

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر یک ارائه شامل اسلایدهای مخفی باشد، می‌توانید از متد [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) در کلاس [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) استفاده کنید تا اسلایدهای مخفی را به‌عنوان صفحات در PDF حاصل شامل کنید.

مثال زیر یک ارائه را به PDF صادر می‌کند و هر اسلاید مخفی را شامل می‌شود.

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

### **تبدیل PowerPoint به PDF محافظت‌شده با رمز عبور**

مثال زیر یک ارائه را به PDF صادر می‌کند که برای باز کردن به رمز عبور `password` نیاز دارد. مجوزهای دسترسی چاپ، از جمله چاپ با کیفیت بالا، را امکان‌پذیر می‌کند.

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

Aspose.Slides متد [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) را در زیر کلاس [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) فراهم می‌کند که به شما امکان می‌دهد جایگزینی فونت‌ها را در طول فرآیند تبدیل ارائه به PDF شناسایی کنید.

مثال زیر یک ارائه را به PDF صادر می‌کند و هشدارهای جایگزینی فونت را در کنسول چاپ می‌کند. هشدار فقط هنگامی چاپ می‌شود که فونتی در دسترس نباشد و در طول خروجی جایگزین شود.

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
برای اطلاعات بیشتر درباره جایگزینی فونت، مقاله [جایگزینی فونت](/slides/fa/androidjava/font-substitution/) را ببینید.
{{% /alert %}}

### **مدیریت فونت‌ها بدون نوع بولد اختصاصی**

یک ارائه می‌تواند قالب‌بندی بولد را بر متن اعمال کند حتی اگر فونت آن نوع بولد اختصاصی نداشته باشد. متن می‌تواند با بولد مصنوعی که گلیف‌های معمولی را به‌صورت مصنوعی ضخیم می‌کند، همچنان بولد به‌نظر برسد. وقتی این متن بیش از حد سنگین به‌نظر می‌رسد یا با ظاهر موردنظر در PDF متفاوت است، سعی کنید متد [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) را با `true` فراخوانی کنید. این گزینه متن‌های تحت‌تأثیر را به‌صورت بیت‌مپ در طول خروجی PDF رندر می‌کند و می‌تواند ظاهر آن‌ها را برای برخی فونت‌ها بهبود بخشد. مقدار پیش‌فرض آن `false` است.

ارائه نمونه شامل دو جعبه متن است: یکی با متن معمولی و دیگری با قالب‌بندی بولد اعمال‌شده به همان فونت که نوع بولد اختصاصی ندارد. مثال زیر ارائه را بارگذاری می‌کند، رسترایز کردن سبک‌های فونت پشتیبانی‌نشده را فعال می‌سازد و آن را به PDF صادر می‌کند:

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

پیش‌نمایش‌های زیر خروجی غیرفعال و فعال را نشان می‌دهند. در این مثال، متن بولد با گزینه غیرفعال خطوط ضخیم‌تری دارد. با فعال‌سازی گزینه، خطوط آن سبک‌تر می‌شوند؛ متن معمولی بدون تغییر می‌ماند. قبل از انتخاب تنظیم برای ارائه خود، نتایج را مقایسه کنید.

| گزینه غیرفعال (`false`، پیش‌فرض) | گزینه فعال (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

در این مثال، فعال‌سازی گزینه فقط متن بولد را به بیت‌مپ تبدیل می‌کند: این متن نمی‌تواند بدون OCR انتخاب، کپی یا جستجو شود و لبه‌های آن در بزرگ‌نمایی 800٪ نرم‌تر به‌نظر می‌رسند. متن معمولی همچنان قابل جستجو باقی می‌ماند. با گزینه غیرفعال، هر دو رشته به‌عنوان متن باقی می‌مانند.

این گزینه متن‌های قالب‌بندی‌شده به‌صورت بولد را رستر می‌کند زمانی که فونت آن نوع بولد اختصاصی ندارد. [جایگزینی فونت](/slides/fa/androidjava/font-substitution/) به‌جای آن فونت دیگری را زمانی که فونت اصلی در دسترس نیست انتخاب می‌کند.

## **تبدیل اسلایدهای انتخاب‌شده از PowerPoint به PDF**

مثال زیر اسلایدهای 1 و 3 را از یک ارائه به PDF صادر می‌کند. اعداد اسلاید در این آرایه به‑صورت یک‌پایه هستند و ارائه ورودی باید حداقل شامل سه اسلاید باشد.

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

مثال زیر اسلاید اول یک ارائه را به یک ارائه جدید با اندازه اسلاید 612 × 792 پوینت (8.5 × 11 اینچ) کپی می‌کند. محتویات اسلاید را برای جایگذاری مقیاس‌بندی می‌کند و اسلاید تک را به PDF صادر می‌کند.

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

## **تبدیل PowerPoint به PDF در نمای اسلاید یادداشت‌ها**

مثال زیر یک ارائه را به PDF صادر می‌کند و یادداشت‌های سخنران هر اسلاید را زیر اسلاید قرار می‌دهد. برای دیدن نتیجه از یک ارائه حاوی یادداشت‌های سخنران استفاده کنید.

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

Aspose.Slides به شما اجازه می‌دهد از یک روش تبدیل استفاده کنید که با [راهنمای دسترسی به محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) مطابقت دارد. می‌توانید یک سند PowerPoint را به PDF صادر کنید با استفاده از هر یک از این استانداردهای انطباق: **PDF/A1a**, **PDF/A1b** و **PDF/UA**.

این کد فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که PDFهای متعدد بر اساس استانداردهای مختلف انطباق تولید می‌کند:

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
Aspose.Slides عملیات تبدیل PDF را پشتیبانی می‌کند و به شما امکان می‌دهد فایل‌های PDF را به فرمت‌های محبوب تبدیل کنید. می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)، [PDF به تصویر](https://products.aspose.com/slides/java/conversion/pdf-to-image/)، [PDF به JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)، و [PDF به PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) را انجام دهید. سایر عملیات تبدیل PDF به فرمت‌های تخصصی—[PDF به SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)، و [PDF به XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)— نیز پشتیبانی می‌شود.
{{% /alert %}}

> **نکته:** هنگام خروجی به PDF/UA، Aspose.Slides گرافیک‌های پیچیده‌ای مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد درنظر می‌گیرد. عناصر مسیر جداگانه به‌عنوان محتوای مستقل حفظ نمی‌شوند و ممکن است به‌عنوان آثار جانبی علامت‌گذاری شوند؛ متن جایگزین فقط برای کل شکل ارائه می‌شود.

## **پرسش‌های متداول**

**آیا می‌توانم چندین فایل PowerPoint را به صورت دسته‌ای به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی بر روی فایل‌های خود حلقه بزنید و فرآیند تبدیل را اعمال کنید.

**آیا امکان محافظت از PDF تبدیل‌شده با رمز عبور وجود دارد؟**

بله. از کلاس [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) برای تنظیم رمز عبور و تعریف مجوزهای دسترسی در طول فرآیند تبدیل استفاده کنید.

**چگونه می‌توانم اسلایدهای مخفی را در PDF گنجانده کنم؟**

با فراخوانی [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) با مقدار `true` در کلاس [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) می‌توانید اسلایدهای مخفی را در PDF حاصل شامل کنید.

**آیا Aspose.Slides می‌تواند کیفیت بالای تصویر را در PDF حفظ کند؟**

بله، می‌توانید با استفاده از متدهایی مانند [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) و [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) در کلاس [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) کیفیت تصویر را کنترل کنید تا تصاویر با کیفیت بالا در PDF شما باشد.

**آیا Aspose.Slides از استانداردهای انطباق PDF/A پشتیبانی می‌کند؟**

بله، Aspose.Slides به شما امکان می‌دهد PDFهایی صادر کنید که با [استانداردهای مختلف](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/) از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند و اطمینان حاصل کنید اسناد شما الزامات دسترسی و بایگانی را برآورده می‌کنند.

## **منابع بیشتر**

- [مستندات Aspose.Slides برای Android از طریق Java](/slides/fa/androidjava/)
- [مرجع API Aspose.Slides برای Android از طریق Java](https://reference.aspose.com/slides/androidjava/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/conversion)