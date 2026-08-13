---
title: تحويل PPT و PPTX إلى PDF في Java [متضمنًا ميزات متقدمة]
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في Java باستخدام Aspose.Slides، مع أمثلة كود سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى تنسيق PDF في Java يقدم عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وتشمل الشرائح المخفيّة، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، واختيار شرائح محددة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويل PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالصيغة التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF، مرّر اسم الملف كمعامل إلى الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) ثم احفظ العرض بصيغة PDF باستخدام طريقة `save`. الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) تعرض طريقة `save` التي تُستخدم عادةً لتحويل عرض تقديمي إلى PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
يقوم Aspose.Slides for Java بإدراج معلومات واجهة برمجة التطبيقات ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، يملأ Aspose.Slides حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة على شكل "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك توجيه Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.
{{% /alert %}}

Aspose.Slides يتيح لك تحويل:
* العروض الكاملة إلى PDF
* شرائح محددة من عرض تقديمي إلى PDF

يقوم Aspose.Slides بتصدير العروض إلى PDF، بما يضمن أن ملفات PDF الناتجة تطابق العروض الأصلية بشكل قريب. يتم عرض العناصر والسمات بدقة في التحويل، بما في ذلك:
* الصور
* صناديق النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* الترويسات والتذييلات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

عملية التحويل القياسية من PowerPoint إلى PDF تستخدم الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

يعرض هذا الكود كيفية تحويل عرض تقديمي (PPT، PPTX، ODP، إلخ) إلى PDF:
```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // حفظ العرض التقديمي كملف PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="info"  %}} 
تقدم Aspose أداة تحويل مجانية عبر الإنترنت [**PowerPoint to PDF converter**](https://products.aspose.app/slides/ar/conversion/ppt-to-pdf) تُظهر عملية تحويل العرض إلى PDF. يمكنك تشغيل اختبار باستخدام هذه الأداة لتنفيذ عملي للإجراء الموضح هنا.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

Aspose.Slides يوفر خيارات مخصصة — خصائص تحت الفئة [PdfOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfoptions/) — لتتمكن من تخصيص PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، وتحديد كيفية معالجة ملفات الميتا، وتعيين مستوى ضغط للنص، وضبط DPI للصور، وغير ذلك.

يوضح مثال الكود أدناه كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة.
```java
import com.aspose.slides.*;

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

// تعريف وضع الامتثال لـ PDF.
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

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) من فئة [PdfOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

يعرض هذا الكود كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:
```java
import com.aspose.slides.*;

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

يعرض هذا الكود كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرور باستخدام معلمات الحماية من فئة [PdfOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfoptions/):
```java
import com.aspose.slides.*;

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

توفر Aspose.Slides طريقة [setWarningCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfoptions/)، مما يتيح لك اكتشاف استبدال الخطوط أثناء عملية تحويل العرض إلى PDF.

يعرض هذا الكود كيفية اكتشاف استبدال الخطوط:
```java
import com.aspose.slides.*;

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

{{%  alert color="info"  %}} 
لمزيد من المعلومات حول تلقي ردود النداء لاستبدال الخطوط أثناء عملية التصيير، راجع [Getting Warning Callbacks for Fonts Substitution](/slides/ar/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).
لمزيد من المعلومات عن استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/java/font-substitution/).
{{% /alert %}} 

## **تحويل الشرائح المختارة في PowerPoint إلى PDF**

يوضح هذا الكود كيفية تحويل شرائح محددة فقط من عرض PowerPoint إلى PDF:
```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // تحديد مصفوفة أرقام الشرائح.
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
import com.aspose.slides.*;

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

    // إزالة الشريحة الفارغة التي تم إنشاء العرض التقديمي الجديد معها.
    resizedPresentation.getSlides().removeAt(1);

    // حفظ العرض التقديمي المعاد تحجيمه كملف PDF.
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشريحة**

يوضح هذا الكود كيفية تحويل عرض PowerPoint إلى PDF يتضمن الملاحظات:
```java
import com.aspose.slides.*;

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

## **معايير الوصول والامتثال لملف PDF**

يوفر Aspose.Slides إمكانية استخدام إجراء تحويل يتوافق مع [إرشادات الوصول إلى محتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

يوضح هذا الكود عملية تحويل من PowerPoint إلى PDF تنتج ملفات PDF متعددة بناءً على معايير الامتثال المختلفة:
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
يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ شائعة. يمكنك تنفيذ تحويلات [PDF إلى HTML](https://products.aspose.com/slides/ar/java/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/ar/java/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/ar/java/conversion/pdf-to-jpg/)، و [PDF إلى PNG](https://products.aspose.com/slides/ar/java/conversion/pdf-to-png/). عمليات تحويل PDF إلى صيغ متخصصة أخرى — [PDF إلى SVG](https://products.aspose.com/slides/ar/java/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/ar/java/conversion/pdf-to-tiff/)، و [PDF إلى XML](https://products.aspose.com/slides/ar/java/conversion/pdf-to-xml/) — مدعومة أيضًا.
{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسومات المعقدة مثل SmartArt والرسوم البيانية والصيغ ككيان واحد. لا يتم الحفاظ على عناصر المسار الفردية كمحتوى منفصل وقد تُعامل كملحقات؛ يتم توفير النص البديل فقط للكيان بأكمله.

## **الأسئلة المتكررة**

### Can I convert multiple PowerPoint files to PDF in bulk?

نعم، يدعم Aspose.Slides التحويل الدفعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك التنقل عبر ملفاتك وتطبيق عملية التحويل برمجيًا.

### Is it possible to password-protect the converted PDF?

بالطبع. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfoptions/) لتعيين كلمة مرور وتحديد أذونات الوصول خلال عملية التحويل.

### How do I include hidden slides in the PDF?

استخدم طريقة `setShowHiddenSlides` في فئة [PdfOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

### Can Aspose.Slides maintain high image quality in the PDF?

نعم، يمكنك التحكم في جودة الصور باستخدام طرق مثل `setJpegQuality` و `setSufficientResolution` في فئة [PdfOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfoptions/) لضمان صور عالية الجودة في ملف PDF الخاص بك.

### Does Aspose.Slides support PDF/A compliance standards?

نعم، يتيح Aspose.Slides تصدير ملفات PDF متوافقة مع [معايير مختلفة](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfcompliance/)، بما في ذلك PDF/A1a و PDF/A1b و PDF/UA، مما يضمن أن مستنداتك تلبي متطلبات الوصول والأرشفة.

## **الموارد الإضافية**

- [توثيق Aspose.Slides لـ Java](/slides/ar/java/)
- [مرجع API لـ Aspose.Slides لـ Java](https://reference.aspose.com/slides/ar/java/)
- [محولات Aspose المجانية عبر الإنترنت](https://products.aspose.app/slides/ar/conversion)