---
title: تحويل PPT و PPTX إلى PDF في Java [ميزات متقدمة مضمنة]
linktitle: PowerPoint إلى PDF
type: docs
weight: 40
url: /ar/java/convert-powerpoint-to-pdf/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- PowerPoint إلى PDF
- العرض التقديمي إلى PDF
- PPT إلى PDF
- تحويل PPT إلى PDF
- PPTX إلى PDF
- تحويل PPTX إلى PDF
- حفظ PowerPoint كـ PDF
- حفظ PPT كـ PDF
- حفظ PPTX كـ PDF
- تصدير PPT إلى PDF
- تصدير PPTX إلى PDF
- مرفق
- PDF/A1a
- PDF/A1b
- PDF/UA
- جافا
- Aspose.Slides
description: "تحويل ملفات PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في Java باستخدام Aspose.Slides، مع أمثلة شفرة سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT, PPTX, ODP، إلخ) إلى تنسيق PDF في Java يقدم عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي الخاص بك. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، واختيار شرائح محددة للتحويل، وتطبيق معايير الامتثال على المستندات المستخرجة.

## **تحويل PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض التقديمية بالتنسيقات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

To convert a presentation to PDF, pass the file name as an argument to the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class and then save the presentation as a PDF using a [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) method. The [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class exposes the [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) method that is typically used to convert a presentation to PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Java inserts its API information and version number into output documents. For example, when converting a presentation to PDF, Aspose.Slides populates the Application field with "*Aspose.Slides*" and the PDF Producer field with a value in "*Aspose.Slides v XX.XX*" form. **Note** that you cannot instruct Aspose.Slides to change or remove this information from output documents.
{{% /alert %}}

يتيح Aspose.Slides لك تحويل:
* العروض كاملة إلى PDF
* شرائح محددة من العرض إلى PDF

يصدّر Aspose.Slides العروض إلى PDF، مع ضمان أن تكون ملفات PDF الناتجة مطابقة بشكل كبير للعروض الأصلية. يتم تمثيل العناصر والسمات بدقة أثناء التحويل، بما في ذلك:
* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

عملية التحويل القياسية من PowerPoint إلى PDF تستخدم الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثلى بأعلى مستويات الجودة.

المثال التالي يقوم بتحميل عرض وت حفظ جميع الشرائح الظاهرة إلى PDF باستخدام إعدادات التصدير الافتراضية.

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
Aspose offers a free online [**محول PowerPoint إلى PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) that demonstrates the presentation-to-PDF conversion process. You can run a test with this converter for a live implementation of the procedure described here.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

Aspose.Slides provides custom options—properties under the [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) class—that allow you to customize the resulting PDF, lock the PDF with a password, or specify how the conversion process should proceed.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

Using custom conversion options, you can define your preferred quality setting for raster images, specify how metafiles should be handled, set a compression level for text, configure DPI for images, and more.

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

### **تحديد ضغط الصورة تلقائيًا**

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

### **الحفاظ على ملفات OLE المضمّنة كمرفقات PDF**

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

To check the result:

1. Open the exported PDF in a viewer that supports file attachments, such as Adobe Acrobat Reader.
2. Open the viewer's **Attachments** panel and locate the embedded workbook.
3. Save the attachment and open it in Excel to inspect its data, or open it directly if the viewer permits it. The preview on the PDF page is separate from the attachment.

{{% alert color="info" title="Note" %}}
The PDF/A standards impose restrictions on attachments: PDF/A-1 prohibits embedded files, PDF/A-2 permits only PDF/A attachments, and PDF/A-3 permits other file types, including Excel workbooks. These are requirements of the standards, not restrictions specific to Aspose.Slides. This example uses the default PDF compliance setting and does not demonstrate PDF/A export.
{{% /alert %}}

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

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

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

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

### **اكتشاف استبدال الخطوط**

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
For more information on font substitution, see the [استبدال الخط](/slides/ar/java/font-substitution/) article.
{{% /alert %}} 

### **معالجة الخطوط التي لا تملك نمطًا غامقًا مخصصًا**

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

| الخيار معطل (`false`، الافتراضي) | الخيار مفعّل (`true`) |
|---|---|
| ![PDF مع إلغاء تمثيل الخط غير المدعوم كصورة نقطية](unsupported-bold-disabled.png) | ![PDF مع تمثيل الخط غير المدعوم كصورة نقطية مفعّل](unsupported-bold-enabled.png) |

In this example, enabling the option turns only the bold text into a bitmap: it cannot be selected, copied, or searched as text without OCR, and its edges appear softer at 800% zoom. The regular text remains searchable. With the option disabled, both strings remain text.

This option rasterizes text formatted as bold when its font has no dedicated bold typeface. [Font substitution](/slides/ar/java/font-substitution/) instead selects another font when the original is unavailable.

## **تحويل شرائح محددة من PowerPoint إلى PDF**

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

## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

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

    // إزالة الشريحة الفارغة التي تم إنشاء العرض التقديمي الجديد معها.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشريحة**

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

## **معايير الوصول والامتثال للـ PDF**

Aspose.Slides allows you to use a conversion procedure that complies with [إرشادات الوصول إلى محتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). You can export a PowerPoint document to PDF using any of these compliance standards: **PDF/A1a**, **PDF/A1b**, and **PDF/UA**.

This code demonstrates a PowerPoint-to-PDF conversion process that produces multiple PDFs based on different compliance standards:

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
Aspose.Slides supports PDF conversion operations, allowing you to convert PDF files to popular file formats. You can perform [PDF إلى HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF إلى صورة](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF إلى JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), and [PDF إلى PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) conversions. Other PDF conversion operations to specialized formats—[PDF إلى SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF إلى TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), and [PDF إلى XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—are also supported.
{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسومات المعقدة مثل SmartArt والمخططات والصيغ ككائن واحد. لا يتم الحفاظ على عناصر المسار الفردية كمحتوى منفصل وقد يتم وضع علامة عليها كعناصر فنية؛ يتم توفير النص البديل فقط للكائن بأكمله.

## **الأسئلة المتداولة**

**هل يمكنني تحويل ملفات PowerPoint متعددة إلى PDF دفعيًا؟**  
نعم، يدعم Aspose.Slides التحويل الدفعي لملفات PPT أو PPTX المتعددة إلى PDF. يمكنك iterating عبر ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF الناتج بكلمة مرور؟**  
نعم. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) لتعيين كلمة مرور وتعريف أذونات الوصول أثناء عملية التحويل.

**كيف يمكن تضمين الشرائح المخفية في PDF؟**  
استدعِ [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) بـ `true` في فئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة الصورة العالية في PDF؟**  
نعم، يمكنك التحكم في جودة الصورة باستخدام أساليب مثل [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) و [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) في فئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) لضمان صور عالية الجودة في ملف PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال لـ PDF/A؟**  
نعم، يتيح Aspose.Slides تصدير ملفات PDF تتوافق مع [معايير مختلفة](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/)، بما في ذلك PDF/A1a و PDF/A1b و PDF/UA، مما يضمن أن مستنداتك تلبي متطلبات الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides for Java](/slides/ar/java/)
- [مرجع API لـ Aspose.Slides for Java](https://reference.aspose.com/slides/java/)
- [محولات Aspose المجانية عبر الإنترنت](https://products.aspose.app/slides/conversion)