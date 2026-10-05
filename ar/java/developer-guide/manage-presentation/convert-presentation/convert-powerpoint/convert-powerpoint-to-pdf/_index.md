---
title: تحويل PPT و PPTX إلى PDF في Java [تتضمن ميزات متقدمة]
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
- Java
- Aspose.Slides
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في Java باستخدام Aspose.Slides، مع أمثلة كود سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT و PPTX و ODP وغيرها) إلى صيغة PDF باستخدام Java يوفر عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وتشمل الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدالات الخطوط، واختيار شرائح محددة للتحويل، وتطبيق معايير التوافق على مستندات الإخراج.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالصيقات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF، مرر اسم الملف كمعامل إلى فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) توفر طريقة [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) التي تُستخدم عادةً لتحويل عرض إلى PDF.

{{% alert color="info" title="Note" %}}

يضيف Aspose.Slides for Java معلومات API ورقم الإصدار إلى مستندات الإخراج. على سبيل المثال، عند تحويل عرض إلى PDF، يملأ Aspose.Slides حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة بالشكل "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك إرشاد Aspose.Slides لتغيير أو إزالة هذه المعلومات من مستندات الإخراج.

{{% /alert %}}

يسمح Aspose.Slides لك بتحويل:

* العروض كاملة إلى PDF
* شرائح محددة من عرض إلى PDF

يُصدّر Aspose.Slides العروض إلى PDF، مما يضمن أن ملفات PDF الناتجة تتطابق بشكل قريب مع العروض الأصلية. يتم عرض العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات الصفحات
* الرصاصات
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

المثال التالي يحمل عرضًا ويحفظ جميع الشرائح الظاهرة إلى PDF باستخدام إعدادات التصدير الافتراضية.

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

توفر Aspose أداة تحويل مجانية عبر الإنترنت [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) تُظهر عملية تحويل العرض إلى PDF. يمكنك تشغيل اختبار باستخدام هذه الأداة لتجربة عملية التنفيذ الموضحة هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة—خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)—تسمح لك بتخصيص PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تحديد إعداد الجودة المفضل للصور النقطية، وتحديد طريقة معالجة ملفات الميتا، وتعيين مستوى ضغط النص، وتكوين DPI للصور، وأكثر.

المثال التالي يُصدّر عرضًا إلى PDF 1.5 مع جودة JPEG مُحددة بـ 90، ودقة الصورة 300 DPI، وحفظ ملفات الميتا كـ PNG، وضغط نص Flate.

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

### **الحفاظ على ملفات OLE المضمّنة كمرفقات PDF**

إذا كان العرض يحتوي على دفتر عمل Excel مضمّن، قد ترغب في أن يتمكن مستلمو PDF من الوصول إلى بيانات الدفتر بالإضافة إلى مشاهدة الشرائح. استدعِ [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) مع `true` للحفاظ على ملفات OLE المضمّنة كمرفقات في PDF الناتج.

القيمة الافتراضية هي `false`: يتم عرض صورة المعاينة أو الأيقونة الخاصة بكائن OLE على صفحة PDF، لكن الملف المضمّن غير مُدرج كمرفق. ضبط الخيار على `true` يضيف بيانات الملف كذلك. تظل المعاينة تمثيلًا بصريًا؛ والمرفق يتيح للمستلمين فتح الملف المضمّن أو حفظه منفصلًا. لا يتحول كائن OLE إلى ورقة عمل Excel تفاعلية على صفحة PDF.

المثال التالي يحمل عرضًا يحتوي بالفعل على دفتر عمل Excel مضمّن ويصدّره إلى PDF مع إرفاق الدفتر.

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

1. افتح PDF المصدّر في عارض يدعم المرفقات، مثل Adobe Acrobat Reader.
2. افتح لوحة **Attachments** في العارض وحدد موقع دفتر العمل المضمّن.
3. احفظ المرفق وافتحه في Excel لفحص بياناته، أو افتحه مباشرة إذا سمح العارض بذلك. تكون المعاينة على صفحة PDF منفصلة عن المرفق.

{{% alert color="info" title="Note" %}}

تفرض معايير PDF/A قيودًا على المرفقات: PDF/A-1 يمنع الملفات المضمّنة، PDF/A-2 يسمح فقط بمرفقات PDF/A، وPDF/A-3 يسمح بأنواع ملفات أخرى بما فيها دفاتر Excel. هذه قيود المعايير نفسها، ليست قيودًا خاصة بـ Aspose.Slides. يستخدم هذا المثال إعداد التوافق الافتراضي ولا يوضح تصدير PDF/A.

{{% /alert %}}

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) من فئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

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

المثال التالي يصدر عرضًا إلى PDF يتطلب كلمة المرور `password` للفتح. تسمح أذونات الوصول بالطباعة، بما فيها الطباعة عالية الجودة.

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

يقدم Aspose.Slides طريقة [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)، مما يتيح لك اكتشاف استبدالات الخطوط أثناء عملية تحويل العرض إلى PDF.

المثال التالي يصدر عرضًا إلى PDF ويطبع تحذيرات استبدال الخطوط إلى وحدة التحكم. يتم طباعة تحذير فقط عندما يُستبدل خط غير متوفر أثناء التصدير.

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

لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/java/font-substitution/).

{{% /alert %}} 

## **تحويل شرائح محددة من PowerPoint إلى PDF**

المثال التالي يصدر الشريحة 1 والشريحة 3 من عرض إلى PDF. أرقام الشرائح في هذا المصفوفة تبدأ من 1، ويجب أن يحتوي العرض المدخل على ما لا يقل عن ثلاث شرائح.

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

المثال التالي ينسخ الشريحة الأولى من عرض إلى عرض جديد بحجم شريحة 612 × 792 نقطة (8.5 × 11 بوصة). يضبط محتوى الشريحة ليتناسب ويصدر الشريحة الفردية إلى PDF.

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

## **تحويل PowerPoint إلى PDF في وضع ملاحظات الشريحة**

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

## **معايير الوصول والامتثال لملفات PDF**

يتيح Aspose.Slides لك استخدام إجراء تحويل يتوافق مع [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

يظهر هذا الكود عملية تحويل PowerPoint إلى PDF تنتج ملفات PDF متعددة بناءً على معايير امتثال مختلفة:

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

يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ شائعة. يمكنك إجراء التحويلات التالية: [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)، [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/)، [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)، و[PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). كما يتم دعم عمليات تحويل PDF إلى صيغ متخصصة أخرى—[PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)، [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)، و[PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/).

{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسومات المعقدة مثل SmartArt والرسوم البيانية والصيغ ككيان واحد. لا يتم حفظ عناصر المسار الفردية كمحتوى منفصل وقد يتم وضع علامة عليها كعناصر غير مهمة؛ يتم توفير نص بديل للكيان بأكمله فقط.

## **الأسئلة المتكررة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعيًا؟**

نعم، يدعم Aspose.Slides تحويل دفعة متعددة من ملفات PPT أو PPTX إلى PDF. يمكنك التنقل عبر ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF المُحوّل بكلمة مرور؟**

نعم. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

استدعِ [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) مع `true` في فئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يستطيع Aspose.Slides الحفاظ على جودة عالية للصور في PDF؟**

نعم، يمكنك التحكم في جودة الصور باستخدام طرق مثل [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) و[setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) في فئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، يتيح Aspose.Slides لك تصدير ملفات PDF تتوافق مع [various standards](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/)، بما فيها PDF/A1a وPDF/A1b وPDF/UA، مما يضمن تلبية مستنداتك لمتطلبات الوصول والأرشفة.

## **موارد إضافية**

- [Aspose.Slides for Java Documentation](/slides/ar/java/)
- [Aspose.Slides for Java API Reference](https://reference.aspose.com/slides/java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)