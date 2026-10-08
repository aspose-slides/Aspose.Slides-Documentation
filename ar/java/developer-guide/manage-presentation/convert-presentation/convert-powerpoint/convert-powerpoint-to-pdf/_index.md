---
title: تحويل PPT و PPTX إلى PDF في Java [تشمل الميزات المتقدمة]
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
- حفظ PowerPoint كملف PDF
- حفظ PPT كملف PDF
- حفظ PPTX كملف PDF
- تصدير PPT إلى PDF
- تصدير PPTX إلى PDF
- مرفق
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في Java باستخدام Aspose.Slides، مع أمثلة شفرة سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى تنسيق PDF في Java يقدم عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي الخاص بك. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصورة، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدالات الخطوط، واختيار شرائح محددة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالتنسيقات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF، مرّر اسم الملف كمعامل إلى فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) تكشف طريقة [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) التي تُستخدم عادةً لتحويل عرض تقديمي إلى PDF.

{{% alert color="info" title="Note" %}}
يقوم Aspose.Slides for Java بإدراج معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، يملأ Aspose.Slides حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملحوظة** أنه لا يمكنك إرشاد Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.
{{% /alert %}}

يتيح لك Aspose.Slides تحويل:
* جميع العروض إلى PDF
* شرائح محددة من عرض تقديمي إلى PDF

يصدر Aspose.Slides العروض إلى PDF، مما يضمن أن ملفات PDF الناتجة تطابق العرض الأصلي عن كثب. يتم عرض العناصر والسمات بدقة أثناء التحويل، بما في ذلك:
* الصور
* صناديق النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* الترويسات والتذييلات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

المثال التالي يحمل عرضًا تقديميًا ويحفظ جميع الشرائح الظاهرة إلى PDF باستخدام إعدادات التصدير الافتراضية.

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
تقدم Aspose أداة تحويل مجانية على الإنترنت لـ [**محول PowerPoint إلى PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) توضح عملية تحويل العرض إلى PDF. يمكنك إجراء اختبار باستخدام هذه الأداة لتطبيق عملي للإجراء الموضح هنا.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع الخيارات**

يوفر Aspose.Slides خيارات مخصصة — خصائص تحت الفئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) — التي تسمح لك بتخصيص PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد طريقة سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، وتحديد طريقة معالجة ملفات الميتا، وتعيين مستوى ضغط للنص، وضبط DPI للصور، وأكثر من ذلك.

المثال التالي يصدر عرضًا تقديميًا إلى PDF 1.5 مع جودة JPEG مضبوطة على 90، ودقة الصورة على 300 DPI، وحفظ ملفات الميتا كـ PNG، وضغط نص Flate.

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

### **الحفاظ على ملفات OLE المضمنة كمرفقات PDF**

إذا كان العرض يحتوي على مصنف Excel مضمّن، قد ترغب في أن يتمكن مستلمو PDF من الوصول إلى بيانات المصنف بالإضافة إلى مشاهدة الشرائح. استدعِ [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) مع `true` للحفاظ على ملفات OLE المضمنة كمرفقات في PDF الناتج.

القيمة الافتراضية هي `false`: يتم عرض صورة المعاينة أو الأيقونة لكائن OLE على صفحة PDF، لكن الملف المضمن لا يُضمّن كمرفق. ضبط الخيار على `true` يضيف بيانات الملف أيضًا. تبقى المعاينة تمثيلًا بصريًا؛ المرفق يتيح للمستلمين فتح أو حفظ الملف المضمن بشكل منفصل. لا يتحول كائن OLE إلى ورقة عمل Excel تفاعلية على صفحة PDF.

المثال التالي يحمل عرضًا يحتوي بالفعل على مصنف Excel مضمّن ويصدِّره إلى PDF مع إرفاق المصنف.

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
1. افتح ملف PDF المصدر في عارض يدعم المرفقات، مثل Adobe Acrobat Reader.
2. افتح لوحة **المرفقات** في العارض وحدد المصنف المضمن.
3. احفظ المرفق وافتحه في Excel لفحص بياناته، أو افتحه مباشرة إذا كان العارض يسمح بذلك. المعاينة على صفحة PDF منفصلة عن المرفق.

{{% alert color="info" title="Note" %}}
تفرض معايير PDF/A قيودًا على المرفقات: PDF/A-1 يمنع الملفات المضمنة، PDF/A-2 يسمح فقط بمرفقات PDF/A، وPDF/A-3 يسمح بأنواع ملفات أخرى، بما في ذلك مصنفات Excel. هذه متطلبات المعايير، ليست قيودًا خاصة بـ Aspose.Slides. يستخدم هذا المثال الإعداد الافتراضي للامتثال لـ PDF ولا يوضح تصدير PDF/A.
{{% /alert %}}

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) من الفئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

المثال التالي يصدر عرضًا إلى PDF، متضمنًا أي شرائح مخفية.

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

المثال التالي يصدر عرضًا إلى PDF يتطلب كلمة المرور `password` لفتحه. تسمح أذونات الوصول بالطباعة، بما في ذلك الطباعة عالية الجودة.

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

### **اكتشاف استبدالات الخط**

يوفر Aspose.Slides طريقة [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) تحت الفئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) التي تتيح لك اكتشاف استبدالات الخط أثناء عملية تحويل العرض إلى PDF.

المثال التالي يصدر عرضًا إلى PDF ويطبع تحذيرات استبدال الخط على وحدة التحكم. تُطبع التحذيرات فقط عندما يتم استبدال خط غير متوفر أثناء التصدير.

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
لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [استبدال الخطوط](/slides/ar/java/font-substitution/).
{{% /alert %}} 

### **معالجة الخطوط بدون نمط غامق مخصص**

يمكن للعرض تطبيق تنسيق غامق للنص حتى عندما لا يمتلك الخط نمطًا غامقًا مخصصًا. يمكن للنص أن يظهر غامقًا عبر الغامق الصناعي، الذي يزيد من سمك الحروف العادية. عندما يبدو هذا النص ثقيلًا جدًا أو مختلفًا عن المظهر المقصود في PDF، جرّب استدعاء [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) مع `true`. هذا الخيار يرسم النص المتأثر كصورة نقطية أثناء تصدير PDF ويمكن أن يحسن مظهره لبعض الخطوط. القيمة الافتراضية هي `false`.

العرض النموذجي يحتوي على صندوقي نص: أحدهما بنص عادي والآخر بنص غامق يُطبَّق على نفس الخط الذي لا يمتلك نمطًا غامقًا مخصصًا. المثال التالي يحمل العرض، يفعّل تمثيل الخطوط غير المدعومة كصورة نقطية، ويصدّره إلى PDF:

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

المعاينات التالية تُظهر الناتج مع الخيار معطَّل والناتج مع الخيار مفعَّل. في هذا المثال، النص الغامق يحتوي على خطوط أثقل عندما يكون الخيار معطَّل. مع تفعيل الخيار، تصبح الخطوط أخف؛ النص العادي يبقى كما هو. قارن النتائج قبل اختيار الإعداد لعرضك.

| الخيار معطل (`false`، الافتراضي) | الخيار مفعَّل (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

في هذا المثال، تفعيل الخيار يحوِّل النص الغامق فقط إلى صورة نقطية: لا يمكن تحديده أو نسخه أو البحث فيه كنص دون OCR، وتظهر حدوده أكثر نعومة عند تكبير 800٪. يبقى النص العادي قابلًا للبحث. مع تعطيل الخيار، يبقى كلا النصين نصًا.

هذا الخيار يرسم النص المنسق كغامق عندما لا يمتلك الخط نمطًا غامقًا مخصصًا. [استبدال الخطوط](/slides/ar/java/font-substitution/) يختار خطًا آخر عندما يكون الأصلي غير متاح.

## **تحويل الشرائح المحددة من PowerPoint إلى PDF**

المثال التالي يصدر الشرائح 1 و3 من عرض تقديمي إلى PDF. أرقام الشرائح في هذا المصفوفة تبدأ من 1، ويجب أن يحتوي العرض المدخل على ثلاث شرائح على الأقل.

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

## **تحويل PowerPoint إلى PDF مع حجم شريحة مخصص**

المثال التالي ينسخ الشريحة الأولى من عرض إلى عرض جديد بحجم شريحة 612 × 792 نقطة (8.5 × 11 بوصة). يضبط محتوى الشريحة ليتناسب ويصدّر الشريحة الواحدة إلى PDF.

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

    // إزالة الشريحة الفارغة التي تم إنشاء العرض الجديد بها.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشريحة**

المثال التالي يصدر عرضًا إلى PDF، ويضع ملاحظات المتحدث لكل شريحة أسفل الشريحة. استخدم عرضًا يحتوي على ملاحظات المتحدث لرؤية النتيجة.

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

## **معايير الوصول والامتثال لـ PDF**

يسمح لك Aspose.Slides باستخدام إجراء تحويل يتوافق مع [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال هذه: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

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
يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ ملفات شائعة. يمكنك تنفيذ تحويلات [PDF إلى HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/java/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). وتُدعم أيضًا عمليات تحويل PDF إلى صيغ متخصصة مثل [PDF إلى SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/).
{{% /alert %}}

> **ملحوظة:** عند التصدير إلى PDF/UA، يعامل Aspose.Slides الرسومات المعقدة مثل SmartArt والمخططات والصيغ كشكل واحد. لا تُحفظ عناصر المسار الفردية كمحتوى منفصل وقد تُعلم كملحقات؛ يُقدم النص البديل فقط للشكل كاملًا.

## **الأسئلة المتكررة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعة واحدة؟**  
نعم، يدعم Aspose.Slides التحويل الدفعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك التكرار عبر ملفاتك وتطبيق عملية التحويل برمجياً.

**هل من الممكن حماية PDF الناتج بكلمة مرور؟**  
نعم. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

**كيف أضمن تضمين الشرائح المخفية في PDF؟**  
استدعِ [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) مع `true` في فئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة صورة عالية في PDF؟**  
نعم، يمكنك التحكم في جودة الصورة باستخدام طرق مثل [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) و[setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) في فئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**  
نعم، يتيح لك Aspose.Slides تصدير ملفات PDF تتوافق مع [معايير مختلفة](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/)، بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، مما يضمن توافق مستنداتك مع متطلبات إمكانية الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides للـ Java](/slides/ar/java/)
- [مرجع API لـ Aspose.Slides للـ Java](https://reference.aspose.com/slides/java/)
- [محولات Aspose المجانية على الإنترنت](https://products.aspose.app/slides/conversion)