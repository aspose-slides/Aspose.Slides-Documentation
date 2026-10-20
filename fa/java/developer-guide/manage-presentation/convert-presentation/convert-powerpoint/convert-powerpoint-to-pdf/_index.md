---
title: تبدیل PPT و PPTX به PDF در جاوا [شامل ویژگی‌های پیشرفته]
linktitle: پاورپوینت به PDF
type: docs
weight: 40
url: /fa/java/convert-powerpoint-to-pdf/
keywords:
- تبدیل پاورپوینت
- تبدیل ارائه
- پاورپوینت به PDF
- ارائه به PDF
- PPT به PDF
- تبدیل PPT به PDF
- PPTX به PDF
- تبدیل PPTX به PDF
- ذخیره پاورپوینت به عنوان PDF
- ذخیره PPT به عنوان PDF
- ذخیره PPTX به عنوان PDF
- صادرات PPT به PDF
- صادرات PPTX به PDF
- پیوست
- PDF/A1a
- PDF/A1b
- PDF/UA
- جاوا
- Aspose.Slides
description: "تبدیل پاورپوینت PPT/PPTX به PDFهای با کیفیت بالا و قابل جستجو در جاوا با استفاده از Aspose.Slides، همراه با مثال‌های کد سریع و گزینه‌های پیشرفته تبدیل."
---
## **نمای کلی**

تبدیل ارائه‌های پاورپوینت (PPT، PPTX، ODP و ...) به فرمت PDF در جاوا مزایای متعددی را ارائه می‌دهد، از جمله سازگاری بین دستگاه‌های مختلف و حفظ چیدمان و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را شامل کنید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی قلم‌ها را شناسایی کنید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای انطباق را بر روی اسناد خروجی اعمال کنید.

## **تبدیل‌های پاورپوینت به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در فرمت‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

To convert a presentation to PDF, pass the file name as an argument to the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class and then save the presentation as a PDF using a [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) method. The [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class exposes the [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) method that is typically used to convert a presentation to PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides برای جاوا اطلاعات API و شماره نسخه خود را به اسناد خروجی اضافه می‌کند. به عنوان مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقداری به شکل "*Aspose.Slides v XX.XX*" پر می‌کند. **Note** که شما نمی‌توانید Aspose.Slides را مجبور کنید این اطلاعات را در اسناد خروجی تغییر یا حذف کند.
{{% /alert %}}

Aspose.Slides به شما امکان می‌دهد تبدیل کنید:

* کل ارائه‌ها به PDF
* اسلایدهای خاصی از یک ارائه به PDF

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد که PDFهای حاصل به‌دقت با ارائه‌های اصلی مطابقت دارند. عناصر و ویژگی‌ها به‌درستی در تبدیل رندر می‌شوند، شامل:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندهای فراخوان
* سرصفحه‌ها و پایین‌صفحه‌ها
* گلوله‌ها
* جدول‌ها

## **تبدیل پاورپوینت به PDF**

فرآیند استاندارد تبدیل پاورپوینت به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائهٔ ارائه‌شده را با تنظیمات بهینه و در بالاترین سطوح کیفیت به PDF تبدیل کند.

The following example loads a presentation and saves all visible slides to PDF using the default export settings.

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
Aspose یک مبدل آنلاین رایگان [**مبدل PowerPoint به PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ارائه می‌دهد که فرایند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک تست برای اجرای زندهٔ روال توضیح داده شده در اینجا انجام دهید.
{{% /alert %}}

## **تبدیل پاورپوینت به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی — خصوصیات تحت کلاس [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) — را فراهم می‌کند که به شما اجازه می‌دهد PDF حاصل را سفارشی کنید، PDF را با رمز عبور قفل کنید، یا نحوه پیشبرد فرآیند تبدیل را تعیین کنید.

### **تبدیل پاورپوینت به PDF با گزینه‌های سفارشی**

The following example exports a presentation to PDF 1.5 with JPEG quality set to 90, image resolution set to 300 DPI, metafiles saved as PNG, and Flate text compression.

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

When a presentation contains many photographs or screenshots, reducing the size of the exported PDF can make it easier to email or download. Call [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) with `true` to automatically select the most appropriate compression algorithm for each image during PDF export.

The following example loads an existing presentation, enables automatic image compression selection, and saves it as a PDF document. All other PDF export settings retain their default values.

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

This option selects a compression algorithm for each image. Lowering the value passed to [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) instead reduces JPEG image quality, while lowering the value passed to [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) allows images to be downsampled to a lower resolution, which can reduce detail. Enabling automatic compression selection does not itself lower either of these settings.

Selecting image compression algorithms requires additional processing time and memory. The size reduction depends on the presentation's images and export settings; a fixed reduction is not guaranteed for every presentation.

### **حفظ فایل‌های OLE جاسازی‌شده به عنوان پیوست‌های PDF**

If a presentation contains an embedded Excel workbook, you may want PDF recipients to access the workbook's data as well as view the slides. Call [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) with `true` to preserve embedded OLE files as attachments in the resulting PDF.

The default value is `false`: the OLE object's preview image or icon is rendered on the PDF page, but its embedded file is not included as an attachment. Setting the option to `true` additionally includes the file data. The preview remains a visual representation; the attachment lets recipients open or save the embedded file separately. The OLE object does not become an interactive Excel worksheet on the PDF page.

The following example loads a presentation that already contains an embedded Excel workbook and exports it to PDF with the workbook attached.

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

1. PDF صادرشده را در یک نمایشگر که از پیوست‌های فایل پشتیبانی می‌کند، مانند Adobe Acrobat Reader باز کنید.
2. پنل **Attachments** نمایشگر را باز کنید و کتاب کار جاسازی‌شده را پیدا کنید.
3. پیوست را ذخیره کنید و در Excel باز کنید تا داده‌های آن را بررسی کنید، یا اگر نمایشگر اجازه دهد مستقیماً باز کنید. پیش‌نمایش روی صفحه PDF جدا از پیوست است.

{{% alert color="info" title="Note" %}}
استانداردهای PDF/A محدودیت‌هایی بر پیوست‌ها اعمال می‌کنند: PDF/A-1 Fileهای جاسازی‌شده را ممنوع می‌کند، PDF/A-2 فقط پیوست‌های PDF/A را اجازه می‌دهد، و PDF/A-3 انواع دیگر فایل‌ها از جمله کتاب‌کارهای Excel را مجاز می‌داند. این‌ها الزامات استانداردها هستند، نه محدودیت‌های خاص Aspose.Slides. این مثال از تنظیم پیش‌فرض انطباق PDF استفاده می‌کند و خروجی PDF/A را نشان نمی‌دهد.
{{% /alert %}}

### **تبدیل پاورپوینت به PDF با اسلایدهای مخفی**

If a presentation contains hidden slides, you can use the [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) method from the [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) class to include the hidden slides as pages in the resulting PDF.

The following example exports a presentation to PDF, including any hidden slides.

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

### **تبدیل پاورپوینت به PDF با حفاظت توسط رمز عبور**

The following example exports a presentation to a PDF that requires the password `password` to open. The access permissions allow printing, including high-quality printing.

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

Aspose.Slides provides the [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) method under the [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) class, enabling you to detect font substitutions during the presentation-to-PDF conversion process.

The following example exports a presentation to PDF and prints font substitution warnings to the console. A warning is printed only when an unavailable font is substituted during export.

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
برای اطلاعات بیشتر در مورد جایگزینی قلم، مقالهٔ [جایگزینی قلم](/slides/fa/java/font-substitution/) را مشاهده کنید.
{{% /alert %}} 

### **مدیریت قلم‌هایی که نوع بولد اختصاصی ندارند**

A presentation can apply bold formatting to text even when its font has no dedicated bold typeface. The text can still appear bold through synthetic bolding, which artificially thickens the regular glyphs. When that text looks too heavy or otherwise differs from the intended appearance in PDF, try calling [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) with `true`. This option renders the affected text as a bitmap during PDF export and can improve its appearance for certain fonts. Its default value is `false`.

The sample presentation contains two text boxes: one with regular text and one with bold formatting applied to the same font, which has no dedicated bold typeface. The following example loads the presentation, enables rasterization of unsupported font styles, and exports it to PDF:

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

The following previews show the disabled output and the enabled output. In this example, the bold text has heavier strokes with the option disabled. With the option enabled, its strokes are lighter; the regular text is unchanged. Compare the results before choosing the setting for your presentation.

| گزینه غیرفعال (`false`، پیش‌فرض) | گزینه فعال (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In this example, enabling the option turns only the bold text into a bitmap: it cannot be selected, copied, or searched as text without OCR, and its edges appear softer at 800% zoom. The regular text remains searchable. With the option disabled, both strings remain text.

This option rasterizes text formatted as bold when its font has no dedicated bold typeface. [جایگزینی قلم](/slides/fa/java/font-substitution/) instead selects another font when the original is unavailable.

## **تبدیل اسلایدهای انتخاب‌شده از پاورپوینت به PDF**

The following example exports slides 1 and 3 from a presentation to PDF. Slide numbers in this array are one-based, and the input presentation must contain at least three slides.

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

## **تبدیل پاورپوینت به PDF با اندازهٔ اسلاید سفارشی**

The following example copies the first slide from a presentation into a new presentation with a slide size of 612 × 792 points (8.5 × 11 inches). It scales the slide content to fit and exports the single slide to PDF.

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

    // حذف اسلاید خالی که ارائه جدید با آن ایجاد شده بود.
    
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **تبدیل پاورپوینت به PDF در نمای اسلایدهای یادداشت‌ها**

The following example exports a presentation to PDF, placing each slide's speaker notes below the slide. Use a presentation containing speaker notes to see the result.

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

## **استانداردهای دسترس‌پذیری و انطباق برای PDF**

Aspose.Slides اجازه می‌دهد از یک روش تبدیل استفاده کنید که با [دستورالعمل‌های دسترسی به محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار باشد. می‌توانید سند پاورپوینت را به PDF صادر کنید و از هر یک از این استانداردهای انطباق استفاده کنید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

The code demonstrates a PowerPoint-to-PDF conversion process that produces multiple PDFs based on different compliance standards:

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
Aspose.Slides عملیات‌های تبدیل PDF را پشتیبانی می‌کند و به شما امکان می‌دهد فایل‌های PDF را به فرمت‌های محبوب دیگر تبدیل کنید. می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)، [PDF به تصویر](https://products.aspose.com/slides/java/conversion/pdf-to-image/)، [PDF به JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)، و [PDF به PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) را انجام دهید. سایر عملیات‌های تبدیل PDF به فرمت‌های تخصصی — [PDF به SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)، و [PDF به XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — نیز پشتیبانی می‌شوند.
{{% /alert %}}

> **Note:** When exporting to PDF/UA, Aspose.Slides treats complex graphics such as SmartArt, charts, and formulas as a single figure. Individual path elements are not preserved as separate content and may be marked as artifacts; alternative text is provided only for the whole figure.

## **سوالات متداول**

**آیا می‌توانم چندین فایل پاورپوینت را به صورت دسته‌ای به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید فایل‌های خود را در یک حلقه مرور کنید و فرآیند تبدیل را به‌صورت برنامه‌نویسی شده اعمال کنید.

**آیا می‌توان PDF تبدیل‌شده را با رمز عبور محافظت کرد؟**

بله. از کلاس [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) برای تنظیم رمز عبور و تعریف مجوزهای دسترسی در طول فرآیند تبدیل استفاده کنید.

**چگونه اسلایدهای مخفی را در PDF درج کنم؟**

با فراخوانی [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) با مقدار `true` در کلاس [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) اسلایدهای مخفی را در PDF نهایی گنجانده می‌شود.

**آیا Aspose.Slides می‌تواند کیفیت بالای تصویر را در PDF حفظ کند؟**

بله، می‌توانید کیفیت تصویر را با استفاده از روش‌هایی مانند [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) و [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) در کلاس [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) کنترل کنید تا تصاویر با کیفیت بالا در PDF شما باشند.

**آیا Aspose.Slides استانداردهای انطباق PDF/A را پشتیبانی می‌کند؟**

بله، Aspose.Slides به شما اجازه می‌دهد PDFهایی صادر کنید که با [استانداردهای مختلف](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/) از جمله PDF/A1a، PDF/A1b و PDF/UA سازگاری داشته باشند و اطمینان حاصل کنید اسناد شما الزامات دسترس‌پذیری و بایگانی را برآورده می‌کنند.

## **منابع بیشتر**

- [مستندات Aspose.Slides برای جاوا](/slides/fa/java/)
- [مرجع API Aspose.Slides برای جاوا](https://reference.aspose.com/slides/java/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/conversion)