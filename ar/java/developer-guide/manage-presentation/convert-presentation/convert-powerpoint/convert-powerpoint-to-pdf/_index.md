---
title: تحويل PPT و PPTX إلى PDF في Java [مع ميزات متقدمة]
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في Java باستخدام Aspose.Slides، مع أمثلة شفرة سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

يقدم تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى تنسيق PDF في Java عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، تضمين الشرائح المخفية، حماية ملفات PDF بكلمة مرور، اكتشاف استبدالات الخطوط، اختيار شرائح محددة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالتنسيقات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF، مرّر اسم الملف كمعامل إلى فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة `save`. تُظهر فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) طريقة `save` التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

يقوم Aspose.Slides for Java بإدراج معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، يملأ Aspose.Slides حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنك لا تستطيع إرشاد Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

يسمح Aspose.Slides لك بتحويل:

* العروض بالكامل إلى PDF
* شرائح محددة من العرض إلى PDF

يصدر Aspose.Slides العروض إلى PDF، مما يضمن أن تكون ملفات PDF الناتجة مطابقة تقريبًا للعروض الأصلية. يتم عرض العناصر والسمات بدقة في عملية التحويل، بما في ذلك:

* الصور
* صناديق النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات
* النقاط
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF خيارات افتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

يعرض هذا الكود كيفية تحويل عرض (PPT، PPTX، ODP، إلخ) إلى PDF:

```java
// إنشاء كائن فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // حفظ العرض كملف PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

يوفر Aspose أداة مجانية على الإنترنت لتحويل [**PowerPoint إلى PDF**](https://products.aspose.app/slides/ar/conversion/ppt-to-pdf) توضح عملية تحويل العرض إلى PDF. يمكنك تجربة هذه الأداة لتنفيذ العملية حيًا كما هو موضح هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة—خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfoptions/)—تتيح لك تخصيص ملف PDF الناتج، قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، تحديد طريقة التعامل مع ملفات الميتا، ضبط مستوى الضغط للنص، تكوين DPI للصور، والمزيد.

يوضح مثال الشيفرة أدناه كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة.

```java
// إنشاء كائن من فئة PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// تحديد جودة صور JPG.
pdfOptions.setJpegQuality((byte)90);

// تحديد DPI للصور.
pdfOptions.setSufficientResolution(300);

// تحديد سلوك ملفات الميتا.
pdfOptions.setSaveMetafilesAsPng(true);

// تحديد مستوى ضغط النص للمحتوى النصي.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// تحديد وضع الامتثال لملف PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// إنشاء كائن من فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    // حفظ العرض كملف PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) من فئة [PdfOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

يعرض هذا الكود كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:

```java
// إنشاء كائن من فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // إنشاء كائن من فئة PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // إضافة الشرائح المخفية.
    pdfOptions.setShowHiddenSlides(true);

    // حفظ العرض كملف PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

يوضح هذا الكود كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرور باستخدام معلمات الحماية من فئة [PdfOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfoptions/):

```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // إنشاء كائن من فئة PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // تعيين كلمة مرور PDF وأذونات الوصول.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // حفظ العرض كملف PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **اكتشاف استبدالات الخطوط**

يوفر Aspose.Slides طريقة [setWarningCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfoptions/) التي تتيح لك اكتشاف استبدالات الخطوط أثناء عملية تحويل العرض إلى PDF.

يعرض هذا الكود كيفية اكتشاف استبدالات الخطوط:

```java
public static void main(String[] args) {
    // إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
    Presentation presentation = new Presentation("sample.pptx");

    // تعيين رد النداء التحذيري في خيارات PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // حفظ العرض كملف PDF.
        presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        presentation.dispose();
    }
}

// تنفيذ رد النداء التحذيري.
private static class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

للمزيد من المعلومات حول استلام ردود النداء لاستبدالات الخطوط أثناء عملية التجسيد، راجع [Getting Warning Callbacks for Fonts Substitution](/slides/ar/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

للمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/java/font-substitution/).

{{% /alert %}} 

## **تحويل شرائح مختارة في PowerPoint إلى PDF**

يوضح هذا الكود كيفية تحويل شرائح محددة فقط من عرض PowerPoint إلى PDF:

```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // تعيين مصفوفة أرقام الشرائح.
    int[] slides = { 1, 3 };

    // حفظ العرض كملف PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

يوضح هذا الكود كيفية تحويل عرض PowerPoint إلى PDF بحجم شريحة محدد:

```java
float slideWidth = 612;
float slideHeight = 792;

// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// إنشاء عرض تقديمي جديد بحجم شريحة معدل.
Presentation resizedPresentation = new Presentation();

try {
    // تعيين حجم الشريحة المخصص.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    // استنساخ الشريحة الأولى من العرض الأصلي.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // حفظ العرض المعاد تحجيمه كملف PDF مع الملاحظات.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **تحويل PowerPoint إلى PDF في وضع ملاحظات الشريحة**

يوضح هذا الكود كيفية تحويل عرض PowerPoint إلى PDF يتضمن الملاحظات:

```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // تكوين خيارات PDF مع تخطيط الملاحظات.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // حفظ العرض إلى PDF مع الملاحظات.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **معايير الوصول والامتثال للـ PDF**

يتيح Aspose.Slides لك استخدام إجراء تحويل يتوافق مع [إرشادات الوصول لمحتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

يوضح هذا الكود عملية تحويل PowerPoint إلى PDF تنتج ملفات PDF متعددة بناءً على معايير امتثال مختلفة:

```java
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

{{% alert title="Note" color="warning" %}} 

يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى تنسيقات شائعة. يمكنك تنفيذ التحويلات التالية: [PDF إلى HTML](https://products.aspose.com/slides/ar/java/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/ar/java/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/ar/java/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/ar/java/conversion/pdf-to-png/). كما تُدعم عمليات تحويل PDF إلى تنسيقات متخصصة—[PDF إلى SVG](https://products.aspose.com/slides/ar/java/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/ar/java/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/ar/java/conversion/pdf-to-xml/)—أيضًا.

{{% /alert %}}

> **ملاحظة:** عند تصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسومات المعقدة مثل SmartArt والرسوم البيانية والصيغ ككائن واحد. لا يتم الحفاظ على عناصر المسار الفردية ك محتوى منفصل وقد تُعامل كعناصر فنية؛ يتم توفير النص البديل فقط للكائن بأكمله.

## **الأسئلة المتكررة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعة واحدة؟**

نعم، يدعم Aspose.Slides تحويل دفعة من ملفات PPT أو PPTX إلى PDF. يمكنك تكرار عملية التحويل على ملفاتك برمجياً.

**هل يمكن حماية PDF الناتج بكلمة مرور؟**

بالطبع. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfoptions/) لتعيين كلمة مرور وتعريف أذونات الوصول أثناء عملية التحويل.

**كيف يمكن تضمين الشرائح المخفية في PDF؟**

استخدم طريقة `setShowHiddenSlides` في فئة [PdfOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة عالية للصور في PDF؟**

نعم، يمكنك التحكم في جودة الصور باستخدام طرق مثل `setJpegQuality` و`setSufficientResolution` في فئة [PdfOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfoptions/) لضمان صور عالية الجودة في ملف PDF.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، يتيح Aspose.Slides تصدير ملفات PDF متوافقة مع [معايير مختلفة](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfcompliance/)، بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، لضمان تلبية وثائقك لمتطلبات الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides for Java](/slides/ar/java/)
- [مرجع API لـ Aspose.Slides for Java](https://reference.aspose.com/slides/ar/java/)
- [محولات Aspose المجانية على الإنترنت](https://products.aspose.app/slides/ar/conversion)