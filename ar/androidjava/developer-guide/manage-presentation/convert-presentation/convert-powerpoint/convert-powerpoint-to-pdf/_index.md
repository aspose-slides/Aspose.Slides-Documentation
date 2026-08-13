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
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في Java باستخدام Aspose.Slides لـ Android، مع أمثلة شيفرة سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى تنسيق PDF على نظام Android يوفر عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات متعددة للتحكم في جودة الصور، تضمين الشرائح المخفية، حماية ملفات PDF بكلمة مرور، اكتشاف استبدال الخطوط، اختيار شرائح معينة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض التقديمية بالصيغة التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF، مرّر اسم الملف كمعامل إلى فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة `save`. فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) تعرض طريقة `save` التي تُستخدم عادةً لتحويل العرض التقديمي إلى PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

تضيف Aspose.Slides for Android via Java معلومات واجهة برمجة التطبيقات ورقم الإصدار إلى المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، تقوم Aspose.Slides بملء الحقل Application بقيمة "*Aspose.Slides*" والحقل PDF Producer بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك توجيه Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

تسمح لك Aspose.Slides بـ:

* تحويل العروض الكاملة إلى PDF
* تحويل شرائح محددة من العرض إلى PDF

تُصدر Aspose.Slides العروض إلى PDF، مما يضمن أن ملفات PDF الناتجة تتطابق بدقة مع العروض الأصلية. يتم عرض العناصر والسمات بدقة خلال التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات الصفحات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية تحويل PowerPoint إلى PDF القياسية الخيارات الافتراضية. في هذه الحالة، تحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

يعرض هذا الكود كيفية تحويل عرض (PPT، PPTX، ODP، إلخ) إلى PDF:

```java
import com.aspose.slides.*;

// إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // حفظ العرض التقديمي كملف PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="info"  %}} 

توفر Aspose أداة مجانية على الإنترنت لـ [**محول PowerPoint إلى PDF**](https://products.aspose.app/slides/ar/conversion/ppt-to-pdf) تُظهر عملية تحويل العرض إلى PDF. يمكنك تجربة هذه الأداة لتنفيذ عمليًا الإجراء الموصوف هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع الخيارات**

توفر Aspose.Slides خيارات مخصصة—خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pdfoptions/)—تمكنك من تخصيص PDF الناتج، قفل PDF بكلمة مرور، أو تحديد طريقة سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، تحديد طريقة معالجة ملفات الميتا، ضبط مستوى ضغط النص، تكوين DPI للصور، وأكثر.

يوضح المثال البرمجي أدناه كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة.

```java
import com.aspose.slides.*;

// إنشاء كائن من الفئة PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// ضبط جودة صور JPG.
pdfOptions.setJpegQuality((byte)90);

// ضبط DPI للصور.
pdfOptions.setSufficientResolution(300);

/// ضبط سلوك ملفات الميتا.
pdfOptions.setSaveMetafilesAsPng(true);

// ضبط مستوى ضغط النص للمحتوى النصي.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// تعريف وضع امتثال PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // حفظ العرض التقديمي كملف PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) من فئة [PdfOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

يعرض هذا الكود كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:

```java
import com.aspose.slides.*;

// إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // إنشاء كائن من الفئة PdfOptions.
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

يوضح هذا الكود كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرور باستخدام معلمات الحماية من فئة [PdfOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pdfoptions/):

```java
import com.aspose.slides.*;

// إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // إنشاء كائن من الفئة PdfOptions.
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

توفر Aspose.Slides طريقة [setWarningCallback](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pdfoptions/) التي تمكنك من اكتشاف استبدال الخطوط أثناء عملية تحويل العرض إلى PDF.

يعرض هذا الكود كيفية اكتشاف استبدال الخطوط:

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
    Presentation presentation = new Presentation("sample.pptx");

    // ضبط رد النداء التحذيري في خيارات PDF.
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

{{%  alert color="info"  %}} 

لمزيد من المعلومات حول استبدال الخطوط، راجع مقال [Font Substitution](/slides/ar/androidjava/font-substitution/).

{{% /alert %}} 

## **تحويل الشرائح المحددة من PowerPoint إلى PDF**

يوضح هذا الكود كيفية تحويل شرائح معينة فقط من عرض PowerPoint إلى PDF:

```java
import com.aspose.slides.*;

// إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
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

يوضح هذا الكود كيفية تحويل عرض PowerPoint إلى PDF بحجم شريحة محدد:

```java
float slideWidth = 612;
float slideHeight = 792;

// إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// إنشاء عرض تقديمي جديد بحجم شريحة معدل.
Presentation resizedPresentation = new Presentation();

try {
    // ضبط حجم الشريحة المخصص.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // استنساخ الشريحة الأولى من العرض التقديمي الأصلي.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // إزالة الشريحة الفارغة التي تم إنشاء العرض التقديمي الجديد معها.
    resizedPresentation.getSlides().removeAt(1);

    // حفظ العرض التقديمي المُعدل كملف PDF.
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **تحويل PowerPoint إلى PDF في وضع ملاحظات الشريحة**

يوضح هذا الكود كيفية تحويل عرض PowerPoint إلى PDF يتضمن الملاحظات:

```java
import com.aspose.slides.*;

// إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // تهيئة خيارات PDF مع تخطيط الملاحظات.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // حفظ العرض التقديمي إلى ملف PDF مع الملاحظات.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **معايير الوصول والامتثال لملفات PDF**

تسمح لك Aspose.Slides باستخدام إجراء تحويل يتوافق مع [إرشادات محتوى الويب للوصول (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

يعرض هذا الكود عملية تحويل PowerPoint إلى PDF تنتج ملفات PDF متعددة بناءً على معايير الامتثال المختلفة:

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

{{% alert title="Note" color="warning" %}} 

تدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى تنسيقات ملفات شائعة. يمكنك تنفيذ تحويلات [PDF إلى HTML](https://products.aspose.com/slides/ar/java/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/ar/java/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/ar/java/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/ar/java/conversion/pdf-to-png/). تدعم أيضًا عمليات تحويل PDF إلى صيغ متخصصة—[PDF إلى SVG](https://products.aspose.com/slides/ar/java/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/ar/java/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/ar/java/conversion/pdf-to-xml/)。

{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، تتعامل Aspose.Slides مع الرسومات المعقدة مثل SmartArt والرسوم البيانية والصيغ كشكل واحد. لا يتم الحفاظ على عناصر المسار الفردية ك محتوى منفصل وقد تُعامل كعناصر فنية؛ يتم توفير النص البديل فقط للشكل كاملًا.

## **الأسئلة المتكررة**

### هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعيًا؟

نعم، تدعم Aspose.Slides التحويل الجماعي لملفات PPT أو PPTX متعددة إلى PDF. يمكنك تكرار عملية التحويل على ملفاتك برمجيًا.

### هل يمكن حماية PDF الناتج بكلمة مرور؟

بالتأكيد. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pdfoptions/) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

### كيف يمكنني تضمين الشرائح المخفية في PDF؟

استخدم طريقة `setShowHiddenSlides` في فئة [PdfOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

### هل يمكن لـ Aspose.Slides الحفاظ على جودة عالية للصور في PDF؟

نعم، يمكنك التحكم في جودة الصور باستخدام طرق مثل `setJpegQuality` و `setSufficientResolution` في فئة [PdfOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

### هل تدعم Aspose.Slides معايير الامتثال PDF/A؟

نعم، تتيح لك Aspose.Slides تصدير ملفات PDF تتوافق مع معايير مختلفة، بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، لضمان توافق مستنداتك مع متطلبات الوصول والحفظ الأرشيفي.

## **موارد إضافية**

- [توثيق Aspose.Slides for Android via Java](/slides/ar/androidjava/)
- [مرجع API لـ Aspose.Slides for Android via Java](https://reference.aspose.com/slides/ar/androidjava/)
- [محولات Aspose المجانية على الإنترنت](https://products.aspose.app/slides/ar/conversion)