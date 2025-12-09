---
title: تحويل PPT و PPTX إلى PDF في Java [يتضمن ميزات متقدمة]
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
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في Java باستخدام Aspose.Slides، مع أمثلة برمجية سريعة وخيارات تحويل متقدمة."
---

## **نظرة عامة**

تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى صيغة PDF في Java يوفر عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، واختيار شرائح محددة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالصيغات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF، مرر اسم الملف كمعامل إلى فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة `save`. فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) تُظهر طريقة `save` التي تُستخدم عادةً لتحويل عرض إلى PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

يُدرج Aspose.Slides للـ Java معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، يقوم Aspose.Slides بملء حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة بصيغة "*Aspose.Slides v XX.XX*". **Note** أنه لا يمكنك توجيه Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

يسمح Aspose.Slides لك بتحويل:

* العروض بالكامل إلى PDF
* شرائح محددة من عرض إلى PDF

يُصدر Aspose.Slides العروض إلى PDF، مع ضمان أن تتطابق ملفات PDF الناتجة بشكل كبير مع العروض الأصلية. تُرسم العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات الصفحات
* النقاط
* الجداول

## **تحويل PowerPoint إلى PDF**

عملية تحويل PowerPoint إلى PDF القياسية تستخدم الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

هذا الكود يوضح كيفية تحويل عرض (PPT، PPTX، ODP، إلخ) إلى PDF:
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

يقدم Aspose محولًا مجانيًا على الإنترنت **PowerPoint to PDF converter**[https://products.aspose.app/slides/conversion/ppt-to-pdf] يوضح عملية تحويل العرض إلى PDF. يمكنك تجربة هذا المحول لتنفيذ عملي للخطوات الموضحة هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة—خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)—تسمح لك بتخصيص ملف PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، وتحديد كيفية معالجة ملفات الميتافي، وتعيين مستوى ضغط للنص، وتكوين DPI للصور، والمزيد.

يوضح مثال الكود أدناه كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة.
```java
// إنشاء كائن من فئة PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// تعيين جودة صور JPG.
pdfOptions.setJpegQuality((byte)90);

// تعيين DPI للصور.
pdfOptions.setSufficientResolution(300);

// تعيين سلوك ملفات الميتا.
pdfOptions.setSaveMetafilesAsPng(true);

// تعيين مستوى ضغط النص للمحتوى النصي.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// تعريف وضع التوافق PDF.
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

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) من فئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

هذا الكود يوضح كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:
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


### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

هذا الكود يوضح كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرور باستخدام معلمات الحماية من فئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/):
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // إنشاء كائن من فئة PdfOptions.
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

يوفر Aspose.Slides طريقة [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) تمكنك من اكتشاف استبدال الخطوط أثناء عملية تحويل العرض إلى PDF.

هذا الكود يوضح كيفية اكتشاف استبدال الخطوط:
```java
public static void main(String[] args) {
    // إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
    Presentation presentation = new Presentation("sample.pptx");

    // تعيين رد النداء التحذيري في خيارات PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // حفظ العرض التقديمي كملف PDF.
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

لمزيد من المعلومات حول استلام ردود النداء لاستبدال الخطوط أثناء عملية التصيير، راجع [Getting Warning Callbacks for Fonts Substitution](/slides/ar/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/java/font-substitution/).

{{% /alert %}} 

## **تحويل شرائح محددة في PowerPoint إلى PDF**

هذا الكود يوضح كيفية تحويل شرائح معينة فقط من عرض PowerPoint إلى PDF:
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

هذا الكود يوضح كيفية تحويل عرض PowerPoint إلى PDF بحجم شريحة محدد:
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

    // حفظ العرض التقديمي المعاد حجمه إلى ملف PDF مع الملاحظات.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **تحويل PowerPoint إلى PDF في وضع ملاحظات الشريحة**

هذا الكود يوضح كيفية تحويل عرض PowerPoint إلى PDF يتضمن الملاحظات:
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
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


## **معايير إمكانية الوصول والامتثال لـ PDF**

يتيح Aspose.Slides لك استخدام إجراء تحويل يتوافق مع [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

هذا الكود يوضح عملية تحويل PowerPoint إلى PDF تنتج ملفات PDF متعددة بناءً على معايير امتثال مختلفة:
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

يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ ملفات شائعة. يمكنك تنفيذ تحويلات [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)، [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/)، [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)، و[PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). تدعم أيضًا عمليات تحويل PDF إلى صيغ متخصصة—[PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)، [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)، و[PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/).

{{% /alert %}}

## **الأسئلة الشائعة**

1. **هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعيًا؟**

   نعم، يدعم Aspose.Slides التحويل الجماعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك المرور على ملفاتك وتطبيق عملية التحويل برمجيًا.

2. **هل يمكن حماية PDF الناتج بكلمة مرور؟**

   بالتأكيد. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

3. **كيف يمكن تضمين الشرائح المخفية في PDF؟**

   استخدم طريقة `setShowHiddenSlides` في فئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

4. **هل يمكن لـ Aspose.Slides الحفاظ على جودة عالية للصور في PDF؟**

   نعم، يمكنك التحكم في جودة الصورة باستخدام طرق مثل `setJpegQuality` و`setSufficientResolution` في فئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) لضمان صور ذات جودة عالية في PDF.

5. **هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

   نعم، يتيح Aspose.Slides تصدير ملفات PDF تتوافق مع معايير مختلفة، بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، مما يضمن أن مستنداتك تلبي متطلبات إمكانية الوصول والأرشفة.

## **موارد إضافية**

- [Aspose.Slides for Java Documentation](/slides/ar/java/)
- [Aspose.Slides for Java API Reference](https://reference.aspose.com/slides/java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)