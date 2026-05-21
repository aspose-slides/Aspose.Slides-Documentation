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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في Java باستخدام Aspose.Slides لـ Android، مع أمثلة كود سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى تنسيق PDF في نظام Android يوفر عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي الخاص بك. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصورة، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدالات الخطوط، وتحديد شرائح معينة للتحويل، وتطبيق معايير الالتزام على المستندات الناتجة.

## **تحويل PowerPoint إلى PDF**

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF، مرّر اسم الملف كمعامل إلى الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة `save`. تُظهر الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) طريقة `save` التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{%  alert title="ملاحظة"  color="warning"   %}} 
يقوم Aspose.Slides for Android via Java بإدراج معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، يملأ Aspose.Slides حقل Application بالقيمة "*Aspose.Slides*" وحقل PDF Producer بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك توجيه Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.
{{% /alert %}}

يتيح لك Aspose.Slides تحويل:
* العروض الكاملة إلى PDF
* شرائح محددة من عرض تقديمي إلى PDF

يصدر Aspose.Slides العروض إلى PDF، مما يضمن تطابق ملفات PDF الناتجة مع العروض الأصلية بشكل كبير. يتم عرض العناصر والسمات بدقة في التحويل، بما في ذلك:
* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات
* تعداد نقطي
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية تحويل PowerPoint إلى PDF القياسية الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

يعرض هذا الشيفرة كيفية تحويل عرض تقديمي (PPT، PPTX، ODP، إلخ) إلى PDF:
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
تقدم Aspose أداة تحويل مجانية عبر الإنترنت [**PowerPoint to PDF converter**](https://products.aspose.app/slides/ar/conversion/ppt-to-pdf) تُظهر عملية تحويل العرض إلى PDF. يمكنك تشغيل اختبار باستخدام هذه الأداة لتنفيذ عمليًا للإجراء الموضح هنا.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع الخيارات**

يوفر Aspose.Slides خيارات مخصصة—خصائص ضمن الفئة [PdfOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pdfoptions/)—والتي تتيح لك تخصيص ملف PDF الناتج، وتقفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، وتحديد كيفية معالجة ملفات الميتا، وتعيين مستوى ضغط للنص، وتكوين DPI للصور، وأكثر.

يُظهر مثال الشيفرة أدناه كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة.
```java
// إنشاء كائن من فئة PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// تحديد جودة صور JPG.
pdfOptions.setJpegQuality((byte)90);

// تحديد DPI للصور.
pdfOptions.setSufficientResolution(300);

/// تحديد سلوك ملفات الميتا.
pdfOptions.setSaveMetafilesAsPng(true);

// تحديد مستوى ضغط النص للمحتوى النصي.
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

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) من الفئة [PdfOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pdfoptions/) لتضمين الشرائح المخفية كصفحات في ملف PDF الناتج.

يعرض هذا الشيفرة كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:
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

يُظهر هذا الشيفرة كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرور باستخدام معلمات الحماية من الفئة [PdfOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pdfoptions/):
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // إنشاء كائن من فئة PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // تحديد كلمة مرور PDF وأذونات الوصول.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // حفظ العرض التقديمي كملف PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **كشف استبدالات الخطوط**

يوفر Aspose.Slides الطريقة [setWarningCallback](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ضمن الفئة [PdfOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pdfoptions/)، مما يتيح لك اكتشاف استبدالات الخطوط أثناء عملية تحويل العرض إلى PDF.

يعرض هذا الشيفرة كيفية اكتشاف استبدالات الخطوط:
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
لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/androidjava/font-substitution/).
{{% /alert %}} 

## **تحويل الشرائح المحددة من PowerPoint إلى PDF**

يعرض هذا الشيفرة كيفية تحويل شرائح محددة فقط من عرض PowerPoint إلى PDF:
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

يعرض هذا الشيفرة كيفية تحويل عرض PowerPoint إلى PDF بحجم شريحة محدد:
```java
float slideWidth = 612;
float slideHeight = 792;

// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// إنشاء عرض تقديمي جديد بحجم شريحة معدّل.
Presentation resizedPresentation = new Presentation();

try {
    // تحديد حجم الشريحة المخصص.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // استنساخ الشريحة الأولى من العرض التقديمي الأصلي.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // حفظ العرض التقديمي المعدل كملف PDF مع الملاحظات.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **تحويل PowerPoint إلى PDF في وضع ملاحظات الشريحة**

يعرض هذا الشيفرة كيفية تحويل عرض PowerPoint إلى PDF يتضمن الملاحظات:
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

## **معايير الوصول والامتثال للـ PDF**

يتيح لك Aspose.Slides استخدام إجراء تحويل يلتزم بـ [دليل إرشادات إمكانية وصول محتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أيٍ من معايير الامتثال هذه: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

يعرض هذا الشيفرة عملية تحويل PowerPoint إلى PDF تنتج ملفات PDF متعددة بناءً على معايير امتثال مختلفة:
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

{{% alert title="ملاحظة" color="warning" %}} 
يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ شائعة. يمكنك إجراء التحويلات [PDF إلى HTML](https://products.aspose.com/slides/ar/java/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/ar/java/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/ar/java/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/ar/java/conversion/pdf-to-png/). تدعم عمليات التحويل الأخرى إلى صيغ متخصصة—[PDF إلى SVG](https://products.aspose.com/slides/ar/java/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/ar/java/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/ar/java/conversion/pdf-to-xml/). 
{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، يعامل Aspose.Slides الرسومات المعقدة مثل SmartArt والرسوم البيانية والصيغ كوحدة واحدة. لا يتم حفظ العناصر الفردية للمسار كمحتوى منفصل وقد يتم وضع علامة عليها كعناصر غير مرغوب فيها؛ يتم توفير النص البديل فقط للرسمة الكاملة.

## **الأسئلة المتكررة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعة واحدة؟**  
نعم، يدعم Aspose.Slides التحويل الجماعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك المرور عبر ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل من الممكن حماية PDF المحول بكلمة مرور؟**  
بالتأكيد. استخدم الفئة [PdfOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pdfoptions/) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**  
استخدم طريقة `setShowHiddenSlides` في الفئة [PdfOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة صورة عالية في PDF؟**  
نعم، يمكنك التحكم في جودة الصورة باستخدام طرق مثل `setJpegQuality` و `setSufficientResolution` في الفئة [PdfOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**  
نعم، يتيح لك Aspose.Slides تصدير ملفات PDF التي تتوافق مع معايير مختلفة، بما في ذلك PDF/A1a و PDF/A1b و PDF/UA، مما يضمن أن مستنداتك تلبي متطلبات الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides لـ Android عبر Java](/slides/ar/androidjava/)
- [مرجع API لـ Aspose.Slides لـ Android عبر Java](https://reference.aspose.com/slides/ar/androidjava/)
- [محولات Aspose المجانية عبر الإنترنت](https://products.aspose.app/slides/ar/conversion)