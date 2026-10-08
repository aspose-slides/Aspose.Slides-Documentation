---
title: تحويل PPT و PPTX إلى PDF على Android [مع ميزات متقدمة]
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
- حفظ PowerPoint كملف PDF
- حفظ PPT كملف PDF
- حفظ PPTX كملف PDF
- تصدير PPT إلى PDF
- تصدير PPTX إلى PDF
- مرفق
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في Java باستخدام Aspose.Slides لنظام Android، مع أمثلة شفرة سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى تنسيق PDF على نظام Android يوفر عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق عرضك التقديمي. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، وتحديد شرائح معينة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالتنسيقات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF، قم بتمرير اسم الملف كمعامل إلى فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ثم احفظ العرض بصيغة PDF باستخدام طريقة [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). تعرض فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) طريقة [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) التي تُستخدم عادةً لتحويل عرض تقديمي إلى PDF.

{{% alert color="info" title="Note" %}}
يضيف Aspose.Slides for Android via Java معلومات واجهة برمجة التطبيقات ورقم الإصدار إلى المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، يقوم Aspose.Slides بملء حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك إرشاد Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.
{{% /alert %}}

يسمح لك Aspose.Slides بالتحويل:

* العروض الكاملة إلى PDF
* شرائح محددة من عرض تقديمي إلى PDF

يصدر Aspose.Slides العروض إلى PDF، مما يضمن أن ملفات PDF الناتجة تتطابق بشكل كبير مع العروض الأصلية. يتم عرض العناصر والسمات بدقة في التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* الترويسات والتذييلات
* النقاط
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة. المثال التالي يقوم بتحميل عرض تقديمي ويحفظ جميع الشرائح المرئية إلى PDF باستخدام إعدادات التصدير الافتراضية.

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
يوفر Aspose محولًا مجانيًا عبر الإنترنت [**محول PowerPoint إلى PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) يوضح عملية تحويل العرض إلى PDF. يمكنك تشغيل اختبار باستخدام هذا المحول لتطبيق حي للإجراء الموصوف هنا.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة—خصائص تحت فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)—تتيح لك تخصيص PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تحديد إعداد الجودة المفضل للصور النقطية، وتحديد كيفية معالجة ملفات الميتا، وتعيين مستوى الضغط للنص، وتكوين DPI للصور، والمزيد.

المثال التالي يصدر عرضًا إلى PDF 1.5 مع جودة JPEG محددة إلى 90، ودقة الصورة إلى 300 DPI، وحفظ ملفات الميتا كـ PNG، وضغط نص Flate.

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

### **حفظ ملفات OLE المضمنة كمرفقات PDF**

إذا كان العرض يحتوي على دفتر عمل Excel مضمّن، قد ترغب في أن يتمكن مستلمو PDF من الوصول إلى بيانات دفتر العمل بالإضافة إلى عرض الشرائح. استدعِ [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) مع `true` للحفاظ على ملفات OLE المضمّنة كمرفقات في PDF الناتج.

القيمة الافتراضية هي `false`: يتم عرض صورة المعاينة أو أيقونة كائن OLE على صفحة PDF، لكن ملفه المضمّن غير مشمول كمرفق. ضبط الخيار على `true` يضيف بيانات الملف أيضًا. تظل المعاينة تمثيلًا بصريًا؛ يسمح المرفق للمستلمين بفتح أو حفظ الملف المضمّن بشكل منفصل. لا يتحول كائن OLE إلى ورقة عمل Excel تفاعلية على صفحة PDF.

المثال التالي يقوم بتحميل عرض يحتوي بالفعل على دفتر عمل Excel مضمّن ويصدره إلى PDF مع إرفاق دفتر العمل.

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
1. افتح ملف PDF المُصدر في عارض يدعم مرفقات الملفات، مثل Adobe Acrobat Reader.
2. افتح لوحة **المرفقات** في العارض وحدد موقع دفتر العمل المضمّن.
3. احفظ المرفق وافتحه في Excel لتفحص بياناته، أو افتحه مباشرة إذا سمح العارض بذلك. المعاينة على صفحة PDF منفصلة عن المرفق.

{{% alert color="info" title="Note" %}}
تفرض معايير PDF/A قيودًا على المرفقات: PDF/A-1 تحظر الملفات المضمّنة، PDF/A-2 تسمح فقط بمرفقات PDF/A، وPDF/A-3 تسمح بأنواع ملفات أخرى، بما في ذلك دفاتر عمل Excel. هذه متطلبات المعايير، وليست قيودًا خاصة بـ Aspose.Slides. يستخدم هذا المثال الإعداد الافتراضي للامتثال للـ PDF ولا يوضح تصدير PDF/A.
{{% /alert %}}

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) من فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

المثال التالي يصدر عرضًا إلى PDF مع تضمين أي شرائح مخفية.

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

المثال التالي يصدر عرضًا إلى PDF يتطلب كلمة المرور `password` للفتح. تسمح أذونات الوصول بالطباعة، بما في ذلك الطباعة عالية الجودة.

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

### **اكتشاف استبدالات الخطوط**

يوفر Aspose.Slides طريقة [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)، مما يتيح لك اكتشاف استبدالات الخطوط أثناء عملية تحويل العرض إلى PDF.

المثال التالي يصدر عرضًا إلى PDF ويطبع تحذيرات استبدال الخطوط في وحدة التحكم. يتم طباعة التحذير فقط عندما يتم استبدال خط غير متوفر أثناء التصدير.

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
لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [استبدال الخطوط](/slides/ar/androidjava/font-substitution/).
{{% /alert %}}

### **معالجة الخطوط بدون نوع خط عريض مخصص**

يمكن للعرض تطبيق تنسيق عريض على النص حتى عندما لا يحتوي الخط على نوع عريض مخصص. يمكن أن يظهر النص عريضًا عبر التسمك الصناعي، الذي يزيد من سمك الحروف العادية. عندما يبدو النص ثقيلًا جدًا أو يختلف عن الشكل المقصود في PDF، جرّب استدعاء [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) مع `true`. هذا الخيار يعرض النص المتأثر كصورة نقطية أثناء تصدير PDF ويمكن أن يحسن مظهره لبعض الخطوط. القيمة الافتراضية هي `false`.

يتضمن العرض النموذجي مربعين للنص: أحدهما نص عادي والآخر بنمط عريض يُطبق على نفس الخط الذي لا يملك نوعًا عريضًا مخصصًا. المثال التالي يحمل العرض، يفعّل تحويل الأنماط غير المدعومة إلى نقطية، ويصدره إلى PDF:

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

العروض التالية تُظهر النتيجة مع تعطيل الخيار والنتيجة مع تفعيل الخيار. في هذا المثال، يحتوي النص العريض على خطوط أثقل عندما يكون الخيار معطلًا. مع تفعيل الخيار، تكون خطوطه أخف؛ النص العادي يبقى دون تغيير. قارن النتائج قبل اختيار الإعداد لعرضك.

| الخيار معطل (`false`, الافتراضي) | الخيار مفعّل (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

في هذا المثال، يغيّر تفعيل الخيار النص العريض فقط إلى صورة نقطية: لا يمكن تحديده أو نسخه أو البحث فيه كنص دون OCR، وتظهر حوافه أكثر نعومة عند تكبير 800٪. يبقى النص العادي قابلاً للبحث. مع تعطيل الخيار، يبقى كلا السلسلتين نصًا.

هذا الخيار يحول النص المُنسق كعريض إلى نقطية عندما لا يمتلك الخط نوعًا عريضًا مخصصًا. [استبدال الخطوط](/slides/ar/androidjava/font-substitution/) يختار بدلاً من ذلك خطًا آخر عندما يكون الأصلي غير متوفر.

## **تحويل الشرائح المحددة من PowerPoint إلى PDF**

المثال التالي يصدر الشرائح 1 و 3 من عرض إلى PDF. أرقام الشرائح في هذا المصفوفة تبدأ من الواحد، ويجب أن يحتوي العرض المدخل على ثلاث شرائح على الأقل.

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

المثال التالي ينسخ الشريحة الأولى من عرض إلى عرض جديد بحجم شريحة 612 × 792 نقطة (8.5 × 11 بوصة). يقوم بتوسيع محتوى الشريحة ليتناسب ثم يصدر الشريحة الواحدة إلى PDF.

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

المثال التالي يصدر عرضًا إلى PDF، حيث يضع ملاحظات المتحدث لكل شريحة أسفل الشريحة. استخدم عرضًا يحتوي على ملاحظات المتحدث لتشاهد النتيجة.

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

## **معايير الوصول والامتثال لملف PDF**

يتيح لك Aspose.Slides استخدام إجراء تحويل يتوافق مع [إرشادات وصول محتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

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
يدعم Aspose.Slides عمليات تحويل PDF، مما يسمح لك بتحويل ملفات PDF إلى صيغ شائعة. يمكنك إجراء تحويلات [PDF إلى HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/java/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). عمليات تحويل PDF إلى صيغ متخصصة أخرى—[PDF إلى SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—مدعومة أيضًا.
{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، يعامل Aspose.Slides الرسومات المعقدة مثل SmartArt والرسوم البيانية والصيغ ككائن واحد. لا يتم الاحتفاظ بعناصر المسار الفردية كمحتوى منفصل وقد تُصنف كملفات أثرية؛ يتم توفير النص البديل فقط للكائن بالكامل.

## **الأسئلة الشائعة**

**هل يمكنني تحويل ملفات PowerPoint متعددة إلى PDF بشكل جماعي؟**  
نعم، يدعم Aspose.Slides التحويل الدفعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك المرور على ملفاتك وتطبيق عملية التحويل برمجياً.

**هل يمكن حماية PDF الناتج بكلمة مرور؟**  
نعم. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**  
استدعِ [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) مع `true` في فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة صورة عالية في PDF؟**  
نعم، يمكنك التحكم في جودة الصورة باستخدام طرق مثل [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) و[setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) في فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) لضمان صور عالية الجودة في PDF.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**  
نعم، يسمح Aspose.Slides لك بتصدير ملفات PDF تتوافق مع [معايير مختلفة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/)، بما في ذلك PDF/A1a وPDF/A1b وPDF/UA، مما يضمن أن مستنداتك تفي بمتطلبات الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides لنظام Android عبر Java](/slides/ar/androidjava/)
- [مرجع API لـ Aspose.Slides لنظام Android عبر Java](https://reference.aspose.com/slides/androidjava/)
- [محولات Aspose المجانية عبر الإنترنت](https://products.aspose.app/slides/conversion)