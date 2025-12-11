---
title: تحويل PPT و PPTX إلى PDF على Android [تضمين ميزات متقدمة]
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
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في Java باستخدام Aspose.Slides for Android، مع أمثلة شفرة سريعة وخيارات تحويل متقدمة."
---

## **نظرة عامة**

تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى تنسيق PDF على نظام Android يقدم عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وعرض العرض التقديمي. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصورة، تضمين الشرائح المخفية، حماية ملفات PDF بكلمة سر، اكتشاف استبدال الخطوط، اختيار شرائح محددة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالصيغة التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF، مرر اسم الملف كمعامل إلى فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة `save`. فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) توفر طريقة `save` التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

يقوم Aspose.Slides for Android via Java بإدراج معلومات واجهة برمجة التطبيقات ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، يملأ Aspose.Slides حقل Application بالقيمة "*Aspose.Slides*" وحقل PDF Producer بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنك لا تستطيع إرشاد Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

يسمح Aspose.Slides لك بتحويل:

* العروض بالكامل إلى PDF
* شرائح محددة من العرض إلى PDF

يصدر Aspose.Slides العروض إلى PDF، مما يضمن أن ملفات PDF الناتجة تتطابق إلى حد كبير مع العروض الأصلية. يتم تمثيل العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* الترويسات والتذييلات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

عملية تحويل PowerPoint إلى PDF القياسية تستخدم الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

يظهر هذا الكود كيفية تحويل عرض (PPT، PPTX، ODP، إلخ) إلى PDF:
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // حفظ العرض التقديمي كملف PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


{{%  alert  color="primary"  %}} 

يوفر Aspose أداة مجانية على الإنترنت **PowerPoint to PDF converter**(https://products.aspose.app/slides/conversion/ppt-to-pdf) توضح عملية تحويل العرض إلى PDF. يمكنك تشغيل اختبار باستخدام هذه الأداة لتجربة تنفيذ الإجراء الموصوف هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة—خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)—تتيح لك تخصيص PDF الناتج، قفل PDF بكلمة سر، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تحديد إعداد جودة الصورة النقطية المفضل لديك، تحديد طريقة معالجة ملفات الميتا، ضبط مستوى ضغط النص، تكوين DPI للصور، وأكثر.

يعرض مثال الكود أدناه كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة.
```java
// إنشاء كائن من فئة PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// تعيين جودة صور JPG.
pdfOptions.setJpegQuality((byte)90);

// تعيين DPI للصور.
pdfOptions.setSufficientResolution(300);

/// تعيين سلوك ملفات ميتا.
pdfOptions.setSaveMetafilesAsPng(true);

// تعيين مستوى ضغط النص للمحتوى النصي.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// تحديد وضع الامتثال لـ PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // حفظ العرض التقديمي كملف PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) من فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

يظهر هذا الكود كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // إنشاء كائن من فئة PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // إضافة الشرائح المخفية.
    pdfOptions.setShowHiddenSlides(true);

    // حفظ العرض التقديمي كملف PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **تحويل PowerPoint إلى PDF محمي بكلمة سر**

يعرض هذا الكود كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة سر باستخدام معلمات الحماية من فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/):
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // إنشاء كائن من فئة PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // تعيين كلمة مرور PDF وصلاحيات الوصول.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // حفظ العرض التقديمي كملف PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **اكتشاف استبدال الخطوط**

يوفر Aspose.Slides طريقة [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) لتتيح لك اكتشاف استبدال الخطوط أثناء عملية التحويل من العرض إلى PDF.

يعرض هذا الكود كيفية اكتشاف استبدال الخطوط:
```java
public static void main(String[] args) {
    // إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
    Presentation presentation = new Presentation("sample.pptx");

    // تعيين رد النداء التحذيري في خيارات PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // حفظ العرض التقديمي كملف PDF.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
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

لمزيد من المعلومات حول استقبال استدعاءات رد الفعل لاستبدال الخطوط أثناء عملية التصدير، راجع [Getting Warning Callbacks for Fonts Substitution](/slides/ar/androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

لمزيد من التفاصيل حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/androidjava/font-substitution/).

{{% /alert %}} 

## **تحويل شرائح محددة من PowerPoint إلى PDF**

يعرض هذا الكود كيفية تحويل شرائح محددة فقط من عرض PowerPoint إلى PDF:
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
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


## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

يعرض هذا الكود كيفية تحويل عرض PowerPoint إلى PDF بحجم شريحة محدد:
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

    // استنساخ الشريحة الأولى من العرض التقديمي الأصلي.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // حفظ العرض التقديمي المعاد تحجيمه كملف PDF مع الملاحظات.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشريحة**

يعرض هذا الكود كيفية تحويل عرض PowerPoint إلى PDF يتضمن الملاحظات:
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // تكوين خيارات PDF مع تخطيط الملاحظات.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // حفظ العرض التقديمي كملف PDF مع الملاحظات.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


## **معايير الوصول والامتثال لملفات PDF**

يسمح Aspose.Slides لك باستخدام إجراء تحويل يتوافق مع [إرشادات محتوى الويب للقدرة على الوصول (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

يعرض هذا الكود عملية تحويل PowerPoint إلى PDF تنتج ملفات PDF متعددة بناءً على معايير امتثال مختلفة:
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

يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ شائعة. يمكنك تنفيذ التحويلات إلى [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)، [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/)، [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)، و[PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). كما تدعم عمليات تحويل PDF إلى صيغ متخصصة—[PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)، [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)، و[PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—أيضًا.

{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعيًا؟**

نعم، يدعم Aspose.Slides التحويل الدفعي لملفات PPT أو PPTX متعددة إلى PDF. يمكنك التجول بين ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF المحول بكلمة سر؟**

بالتأكيد. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) لتعيين كلمة سر وتحديد أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

استخدم طريقة `setShowHiddenSlides` في فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة الصورة العالية في PDF؟**

نعم، يمكنك التحكم في جودة الصورة باستخدام طرق مثل `setJpegQuality` و`setSufficientResolution` في فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، يسمح Aspose.Slides لك بتصدير ملفات PDF تتوافق مع معايير مختلفة، بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، مما يضمن أن مستنداتك تلبي متطلبات الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides for Android via Java](/slides/ar/androidjava/)
- [مرجع API لـ Aspose.Slides for Android via Java](https://reference.aspose.com/slides/androidjava/)
- [محولات Aspose المجانية على الإنترنت](https://products.aspose.app/slides/conversion)