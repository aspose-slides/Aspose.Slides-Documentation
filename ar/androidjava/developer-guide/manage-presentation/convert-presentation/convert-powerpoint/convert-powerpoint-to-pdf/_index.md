---
title: تحويل PPT و PPTX إلى PDF على Android [متضمنة الميزات المتقدمة]
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في Java باستخدام Aspose.Slides للأندرويد، مع أمثلة شفرة سريعة وخيارات تحويل متقدمة."
---

## **نظرة عامة**

تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى صيغة PDF على نظام Android يقدم عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات متعددة للتحكم في جودة الصور، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدالات الخطوط، واختيار شرائح معينة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويل PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالصيقات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF، مرّر اسم الملف كمعامل إلى فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة `save`. فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) تكشف عن طريقة `save` التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

يقوم Aspose.Slides for Android via Java بإدراج معلومات واجهة برمجة التطبيقات ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، يملأ Aspose.Slides حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة على شكل "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك إرشاد Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

يسمح لك Aspose.Slides بتحويل:

* العروض الكاملة إلى PDF
* شرائح محددة من العرض إلى PDF

يقوم Aspose.Slides بتصدير العروض إلى PDF، مما يضمن أن ملفات PDF الناتجة تطابق العروض الأصلية بشكل كبير. يتم عرض العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط الفائقة
* رؤوس وتذييلات الصفحات
* النقاط
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

هذا المثال يوضح كيفية تحويل عرض (PPT، PPTX، ODP، إلخ) إلى PDF:
```java
// إنشاء كائن فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // حفظ العرض التقديمي كملف PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


{{%  alert  color="primary"  %}} 

توفر Aspose مُحوّلًا مجانيًا على الإنترنت لـ **PowerPoint إلى PDF** عبر الرابط [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) يوضح عملية التحويل من العرض إلى PDF. يمكنك تجربة هذا المُحوّل لتنفيذ العملية مباشرة كما هو موضح هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة—خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)—تتيح لك تخصيص ملف PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، وتحديد كيفية معالجة ملفات الميتا، وضبط مستوى الضغط للنص، وتكوين DPI للصور، وغيرها.

المثال البرمجي أدناه يوضح كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة.
```java
// إنشاء كائن فئة PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// ضبط الجودة لصور JPG.
pdfOptions.setJpegQuality((byte)90);

// ضبط DPI للصور.
pdfOptions.setSufficientResolution(300);

/// تعيين سلوك ملفات الميتا.
pdfOptions.setSaveMetafilesAsPng(true);

// ضبط مستوى ضغط النص للمحتوى النصي.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// تعريف وضع امتثال PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// إنشاء كائن فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // حفظ العرض التقديمي كملف PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **تحويل PowerPoint إلى PDF مع شرائح مخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) من فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

هذا المثال يوضح كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:
```java
// إنشاء كائن فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // إنشاء كائن فئة PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // إضافة الشرائح المخفية.
    pdfOptions.setShowHiddenSlides(true);

    // حفظ العرض التقديمي كملف PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

هذا المثال يوضح كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرور باستخدام معلمات الحماية من فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/):
```java
// إنشاء كائن فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // إنشاء كائن فئة PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // تعيين كلمة مرور PDF وأذونات الوصول.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // حفظ العرض التقديمي كملف PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **اكتشاف استبدال الخطوط**

يوفر Aspose.Slides طريقة [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) التي تتيح لك اكتشاف استبدالات الخطوط أثناء عملية التحويل من العرض إلى PDF.

هذا المثال يوضح كيفية اكتشاف استبدال الخطوط:
```java
public static void main(String[] args) {
    // إنشاء كائن فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
    Presentation presentation = new Presentation("sample.pptx");

    // تعيين رد النداء للتحذير في خيارات PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // حفظ العرض التقديمي كملف PDF.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementation of the warning callback.
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

لمزيد من المعلومات حول استلام ردود الاستدعاء لاستبدالات الخطوط أثناء عملية العرض، راجع [Getting Warning Callbacks for Fonts Substitution](/slides/ar/androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/androidjava/font-substitution/).

{{% /alert %}} 

## **تحويل شرائح مختارة من PowerPoint إلى PDF**

هذا المثال يوضح كيفية تحويل شرائح محددة فقط من عرض PowerPoint إلى PDF:
```java
// إنشاء كائن فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // تعيين مصفوفة أرقام الشرائح.
    int[] slides = { 1, 3 };

    // حفظ العرض التقديمي كملف PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


## **تحويل PowerPoint إلى PDF مع حجم شريحة مخصص**

هذا المثال يوضح كيفية تحويل عرض PowerPoint إلى PDF بحجم شريحة محدد:
```java
float slideWidth = 612;
float slideHeight = 792;

// إنشاء كائن فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// إنشاء عرض تقديمي جديد بحجم شريحة معدل.
Presentation resizedPresentation = new Presentation();

try {
    // تعيين حجم الشريحة المخصَّص.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // استنساخ الشريحة الأولى من العرض التقديمي الأصلي.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // حفظ العرض التقديمي المعاد تحجيمه إلى ملف PDF مع الملاحظات.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشريحة**

هذا المثال يوضح كيفية تحويل عرض PowerPoint إلى PDF يتضمن الملاحظات:
```java
// إنشاء كائن فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // تكوين خيارات PDF مع تخطيط الملاحظات.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // حفظ العرض التقديمي إلى PDF مع الملاحظات.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


## **معايير الوصول والامتثال لملفات PDF**

يسمح لك Aspose.Slides باستخدام إجراء تحويل يتوافق مع [إرشادات الوصول إلى محتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال هذه: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

هذا المثال يوضح عملية تحويل PowerPoint إلى PDF تُنتج ملفات PDF متعددة بناءً على معايير امتثال مختلفة:
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

يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ ملفات شائعة. يمكنك إجراء التحويلات التالية: [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)، [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/)، [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)، و[PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). كما يتم دعم عمليات تحويل PDF إلى صيغ متخصصة أخرى—[PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)، [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)، و[PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/).

{{% /alert %}}

## **الأسئلة المتكررة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعة واحدة؟**

نعم، يدعم Aspose.Slides التحويل الجماعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك iterating عبر ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF الناتج بكلمة مرور؟**

بالطبع. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

**كيف يمكن تضمين الشرائح المخفية في PDF؟**

استخدم طريقة `setShowHiddenSlides` في فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة عالية للصور في PDF؟**

نعم، يمكنك التحكم في جودة الصور باستخدام طرق مثل `setJpegQuality` و`setSufficientResolution` في فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، يتيح لك Aspose.Slides تصدير ملفات PDF تتوافق مع معايير متعددة، بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، مما يضمن أن مستنداتك تلبي متطلبات الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides for Android via Java](/slides/ar/androidjava/)
- [مرجع API لـ Aspose.Slides for Android via Java](https://reference.aspose.com/slides/androidjava/)
- [محولات Aspose المجانية على الإنترنت](https://products.aspose.app/slides/conversion)