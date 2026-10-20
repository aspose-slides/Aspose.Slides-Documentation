---
title: تحويل PPT و PPTX إلى PDF على Android [ميزات متقدمة مضمنة]
linktitle: PowerPoint إلى PDF
type: docs
weight: 40
url: /ar/androidjava/convert-powerpoint-to-pdf/
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
- Android
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في Java باستخدام Aspose.Slides لنظام Android، مع أمثلة كود سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى تنسيق PDF على نظام Android يقدم عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي الخاص بك. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، وتحديد شرائح معينة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض التقديمية بالتنسيقات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF، مرّر اسم الملف كمعامل إلى فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) تُظهر طريقة [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) التي تُستخدم عادةً لتحويل عرض تقديمي إلى PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java inserts its API information and version number into output documents. For example, when converting a presentation to PDF, Aspose.Slides populates the Application field with "*Aspose.Slides*" and the PDF Producer field with a value in "*Aspose.Slides v XX.XX*" form. **ملاحظة** that you cannot instruct Aspose.Slides to change or remove this information from output documents.
{{% /alert %}}

Aspose.Slides يسمح لك بتحويل:

* العروض الكاملة إلى PDF
* شرائح محددة من العرض إلى PDF

Aspose.Slides يُصدّر العروض إلى PDF، مما يضمن أن ملفات PDF الناتجة تطابق العرض الأصلي عن كثب. تُرسم العناصر والسمات بدقة في التحويل، بما في ذلك:

* Images
* Text boxes and shapes
* Text formatting
* Paragraph formatting
* Hyperlinks
* Headers and footers
* Bullets
* Tables

## **تحويل PowerPoint إلى PDF**

عملية التحويل القياسية من PowerPoint إلى PDF تستخدم الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

المثال التالي يحمل عرضاً تقديمياً ويحفظ جميع الشرائح المرئية إلى PDF باستخدام إعدادات التصدير الافتراضية.

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

## **تحويل PowerPoint إلى PDF مع الخيارات**

Aspose.Slides يوفر خيارات مخصصة—الخصائص تحت فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)—التي تسمح لك بتخصيص PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تحديد إعداد جودة الصورة النقطية المفضلة، وتحديد كيفية التعامل مع ملفات الميتا، وضبط مستوى ضغط النص، وتكوين DPI للصور، والمزيد.

المثال التالي يُصدر عرضاً تقديمياً إلى PDF 1.5 بجودة JPEG مُضبوطة على 90، ودقة الصورة 300 DPI، والملفات الميتا محفوظة كـ PNG، وضغط نص Flate.

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

### **اختيار ضغط الصور تلقائيًا**

عندما يحتوي العرض على العديد من الصور الفوتوغرافية أو لقطات الشاشة، فإن تقليل حجم PDF المُصدَّر يمكن أن يُسهل إرساله بالبريد أو تنزيله. استدعِ [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) مع `true` لتحديد تلقائيًا أكثر خوارزمية ضغط ملائمة لكل صورة أثناء تصدير PDF.

المثال التالي يحمل عرضاً موجوداً، يفعّل اختيار ضغط الصور تلقائيًا، ويحفظه كمستند PDF. جميع إعدادات تصدير PDF الأخرى تحتفظ بقيمها الافتراضية.

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

هذا الخيار يختار خوارزمية ضغط لكل صورة. خفض القيمة الممررة إلى [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) يقلل من جودة صورة JPEG، بينما خفض القيمة الممررة إلى [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) يسمح بتقليل دقة الصور، مما قد يقلل من التفاصيل. تمكين الاختيار التلقائي للضغط لا يقلل من أي من هذين الإعدادين بحد ذاته.

اختيار خوارزميات ضغط الصور يتطلب وقت معالجة إضافي وذاكرة. يعتمد تخفيض الحجم على صور العرض وإعدادات التصدير؛ لا يُضمن تخفيض ثابت لكل عرض.

### **الحفاظ على ملفات OLE المضمنة كمرفقات PDF**

إذا كان العرض يحتوي على دفتر عمل Excel مضمّن، قد ترغب في أن يتمكن مستلمو PDF من الوصول إلى بيانات دفتر العمل بالإضافة إلى مشاهدة الشرائح. استدعِ [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) مع `true` للحفاظ على ملفات OLE المضمَّنة كمرفقات في PDF الناتج.

القيمة الافتراضية هي `false`: يُرسم صورة معاينة كائن OLE أو أيقونته على صفحة PDF، لكن الملف المضمّن لا يُضمن كمرفق. ضبط الخيار على `true` يضيف بيانات الملف أيضاً. تظل المعاينة تمثيلًا بصريًا؛ المرفق يتيح للمستلمين فتح أو حفظ الملف المضمّن بشكل منفصل. لا يصبح كائن OLE ورقة عمل Excel تفاعلية على صفحة PDF.

المثال التالي يحمل عرضاً يحتوي بالفعل على دفتر عمل Excel مضمّن ويُصدِّره إلى PDF مع إرفاق دفتر العمل.

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

للتحقق من النتيجة:

1. افتح PDF المُصدَّر في عارض يدعم المرفقات، مثل Adobe Acrobat Reader.
2. افتح لوحة **Attachments** في العارض وابحث عن دفتر العمل المضمّن.
3. احفظ المرفق وافتحه في Excel لتفحص بياناته، أو افتحه مباشرة إذا سمح العارض بذلك. المعاينة على صفحة PDF منفصلة عن المرفق.

{{% alert color="info" title="Note" %}}
معايير PDF/A تفرض قيودًا على المرفقات: PDF/A-1 تحظر الملفات المضمنة، PDF/A-2 تسمح فقط بمرفقات PDF/A، وPDF/A-3 تسمح بأنواع ملفات أخرى، بما في ذلك دفاتر عمل Excel. هذه متطلبات المعايير، ليست قيودًا خاصة بـ Aspose.Slides. المثال يستخدم إعداد الامتثال الافتراضي للـ PDF ولا يُظهر تصدير PDF/A.
{{% /alert %}}

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) من فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

المثال التالي يُصدّر عرضًا إلى PDF، بما في ذلك أي شرائح مخفية.

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

المثال التالي يُصدّر عرضًا إلى PDF يتطلب كلمة المرور `password` لفتحه. تسمح أذونات الوصول بالطباعة، بما في ذلك الطباعة عالية الجودة.

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

Aspose.Slides يوفر طريقة [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) تحت فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)، مما يتيح لك اكتشاف استبدال الخطوط أثناء عملية التحويل من العرض إلى PDF.

المثال التالي يُصدّر عرضًا إلى PDF ويطبع تحذيرات استبدال الخطوط إلى وحدة التحكم. يُطبع التحذير فقط عندما يتم استبدال خط غير متوفر أثناء التصدير.

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
للمزيد من المعلومات حول استبدال الخطوط، راجع مقال [استبدال الخط](/slides/ar/androidjava/font-substitution/).
{{% /alert %}} 

### **معالجة الخطوط التي لا تحتوي على نوع خط غامق مخصص**

يمكن للعرض تطبيق تنسيق غامق للنص حتى عندما لا يحتوي الخط على نوع غامق مخصص. لا يزال النص يظهر غامقًا عبر التسمين الاصطناعي، الذي يثقل الحروف العادية. عندما يبدو هذا النص ثقيلًا جدًا أو يختلف عن الشكل المقصود في PDF، جرّب استدعاء [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) مع `true`. هذا الخيار يرسم النص المتأثر كصورة نقطية أثناء تصدير PDF ويمكن أن يحسّن مظهره لبعض الخطوط. القيمة الافتراضية هي `false`.

العرض التجريبي يحتوي على صندوقي نص: أحدهما نص عادي والآخر نص غامق بنفس الخط الذي لا يحتوي على نوع غامق مخصص. المثال التالي يحمل العرض، يفعّل تمثيل الخط غير المدعوم كصورة نقطية، ويصدّره إلى PDF:

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

الصور التالية تُظهر النتيجة مع الخيار معطَّل ومعه مُفعَّل. في هذا المثال، النص الغامق له خطوط أثقل عندما يكون الخيار معطَّل. مع تمكين الخيار، تصبح الخطوط أخف؛ النص العادي يبقى كما هو. قارن النتائج قبل اختيار الإعداد لعرضك.

| الخيار معطل (`false`، الافتراضي) | الخيار مفعل (`true`) |
|---|---|
| ![PDF مع تعطيل تمثيل الخط غير المدعوم كصورة نقطية](unsupported-bold-disabled.png) | ![PDF مع تمكين تمثيل الخط غير المدعوم كصورة نقطية](unsupported-bold-enabled.png) |

في هذا المثال، تمكين الخيار يحول فقط النص الغامق إلى صورة نقطية: لا يمكن تحديده أو نسخه أو البحث فيه كنص دون OCR، وتظهر حوافه ناعمة عند التكبير 800%. يبقى النص العادي قابلًا للبحث. مع تعطيل الخيار، يبقى كلا السلسلتين نصًا.

هذا الخيار يُمثِّل النص المنسق كغامق عندما لا يمتلك الخط نوعًا غامقًا مخصصًا. [استبدال الخط](/slides/ar/androidjava/font-substitution/) يختار بدلاً من ذلك خطًا آخر عندما يكون الأصلي غير متوفر.

## **تحويل الشرائح المحددة من PowerPoint إلى PDF**

المثال التالي يُصدّر الشرائح 1 و3 من عرض إلى PDF. أرقام الشرائح في هذه المصفوفة تبدأ من الواحد، ويجب أن يحتوي العرض المدخل على ثلاث شرائح على الأقل.

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

المثال التالي ينسخ الشريحة الأولى من عرض إلى عرض جديد بحجم شريحة 612 × 792 نقطة (8.5 × 11 بوصة). يُقَ س محتوى الشريحة لتناسب الحجم ويصدِّر الشريحة الوحيدة إلى PDF.

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

    // إزالة الشريحة الفارغة التي تم إنشاء العرض التقديمي الجديد بها.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **تحويل PowerPoint إلى PDF في وضع ملاحظات الشريحة**

المثال التالي يُصدّر عرضًا إلى PDF، ويضع ملاحظات المتحدث لكل شريحة أسفل الشريحة. استخدم عرضًا يحتوي على ملاحظات المتحدث لرؤية النتيجة.

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

Aspose.Slides يسمح لك باستخدام إجراء تحويل يتوافق مع [إرشادات محتوى الويب للوصول (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال هذه: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

هذا الكود يوضح عملية تحويل PowerPoint إلى PDF تنتج ملفات PDF متعددة بناءً على معايير امتثال مختلفة:

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
Aspose.Slides يدعم عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ ملفات شائعة. يمكنك إجراء تحويلات [PDF إلى HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/java/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). عمليات تحويل PDF إلى صيغ متخصصة أخرى—[PDF إلى SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—تُدعم أيضًا.
{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسومات المعقدة مثل SmartArt والرسوم البيانية والصيغ ككائن واحد. لا تُحافظ عناصر المسار الفردية كقُطَع محتوى منفصلة وقد تُ标记 كعناصر غير مهمة؛ النص البديل يُقدم فقط للكائن الكامل.

## **الأسئلة المتكررة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعيًا؟**

نعم، Aspose.Slides يدعم التحويل الدفعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك التنقل عبر ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية الـ PDF الناتج بكلمة مرور؟**

نعم. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) لضبط كلمة مرور وتعريف أذونات الوصول أثناء عملية التحويل.

**كيف يمكن تضمين الشرائح المخفية في PDF؟**

استدعِ [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) مع `true` في فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة عالية للصور في PDF؟**

نعم، يمكنك التحكم في جودة الصور باستخدام طرق مثل [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) و[setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) في فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير امتثال PDF/A؟**

نعم، Aspose.Slides يسمح لك بتصدير ملفات PDF تتوافق مع [المعايير المختلفة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/)، بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، لضمان أن مستنداتك تلبي متطلبات الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides لنظام Android عبر Java](/slides/ar/androidjava/)
- [مرجع API لـ Aspose.Slides لنظام Android عبر Java](https://reference.aspose.com/slides/androidjava/)
- [محولات Aspose المجانية عبر الإنترنت](https://products.aspose.app/slides/conversion)