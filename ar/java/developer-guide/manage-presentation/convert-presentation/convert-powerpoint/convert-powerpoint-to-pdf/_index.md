---
title: تحويل باوربوينت إلى PDF باستخدام Java
linktitle: تحويل باوربوينت إلى PDF
type: docs
weight: 40
url: /java/convert-powerpoint-to-pdf/
keywords:
- تحويل باوربوينت
- عرض تقديمي
- باوربوينت إلى PDF
- PPT إلى PDF
- PPTX إلى PDF
- حفظ باوربوينت كـ PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides لـ Java
description: "تحويل عروض باوربوينت إلى PDF باستخدام Java. حفظ باوربوينت كـ PDF مع الامتثال أو معايير الوصول."
---

## **نظرة عامة**

يوفر تحويل مستندات باوربوينت إلى تنسيق PDF العديد من المزايا، بما في ذلك ضمان التوافق عبر أجهزة مختلفة والحفاظ على التخطيط والتنسيق لعرضك التقديمي. تُظهر لك هذه المقالة كيفية تحويل العروض التقديمية إلى مستندات PDF، واستخدام خيارات متنوعة للتحكم في جودة الصورة، وتضمين الشرائح المخفية، وحماية مستندات PDF بكلمة مرور، واكتشاف استبدالات الخطوط، وتحديد الشرائح للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات باوربوينت إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض التقديمية في هذه التنسيقات إلى PDF:

* PPT
* PPTX
* ODP

لتحويل عرض تقديمي إلى PDF، عليك ببساطة تمرير اسم الملف كوسيلة في [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class ثم حفظ العرض التقديمي كملف PDF باستخدام [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) method. تعرض [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class طريقة [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) التي تُستخدم عادة لتحويل العرض التقديمي إلى PDF.

{{%  alert title="ملحوظة"  color="warning"   %}} 

تكتب Aspose.Slides لـ Java مباشرةً معلومات واجهة برمجة التطبيقات ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، تملأ Aspose.Slides لـ Java حقل التطبيق بقيمة '*Aspose.Slides*' وحقل منتج PDF بقيمة في شكل '*Aspose.Slides v XX.XX*'. **ملحوظة** أنه لا يمكنك إخبار Aspose.Slides لـ Java بتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

تتيح لك Aspose.Slides تحويل:

* عرض تقديمي كامل إلى PDF
* شرائح محددة في عرض تقديمي إلى PDF
* عرض تقديمي 

تُصدر Aspose.Slides العروض التقديمية إلى PDF بطريقة تجعل محتويات ملفات PDF الناتجة مشابهة جدًا لتلك الموجودة في العروض التقديمية الأصلية. تُRendered العناصر والسمات المعروفة بشكل صحيح في تحويل العروض التقديمية إلى PDF:

* الصور
* مربعات النص والأشكال الأخرى
* النصوص وتنسيقها
* الفقرات وتنسيقها
* الروابط التشعبية
* رؤوس وتذييلات
* النقاط
* الجداول

## **تحويل باوربوينت إلى PDF**

تُنفذ عملية تحويل باوربوينت PDF القياسية باستخدام خيارات افتراضية. في هذه الحالة، تحاول Aspose.Slides تحويل العرض التقديمي المقدم إلى PDF باستخدام الإعدادات المثلى عند أعلى مستويات الجودة.

يوضح لك هذا الكود في Java كيفية تحويل باوربوينت إلى PDF:

```java
// ينشئ كائن من فئة Presentation تمثل ملف باوربوينت
Presentation pres = new Presentation("PowerPoint.ppt");
try {
    // يحفظ العرض التقديمي كملف PDF
    pres.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert  color="primary"  %}} 

تقدم Aspose محول [**باوربوينت إلى PDF مجاني**](https://products.aspose.app/slides/conversion/ppt-to-pdf) يُظهر عملية تحويل العرض التقديمي إلى PDF. للحصول على تنفيذ حي للإجراء الموضح هنا، يمكنك إجراء اختبار مع المحول.

{{% /alert %}}

## **تحويل باوربوينت إلى PDF مع خيارات**

تقدم Aspose.Slides خيارات مخصصة - الخصائص الموجودة تحت [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/PdfOptions) class - التي تتيح لك تخصيص PDF (الذي ينتج عن عملية التحويل)، قفل PDF بكلمة مرور، أو حتى تحديد كيفية سير عملية التحويل.

### **تحويل باوربوينت إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تعيين إعداد الجودة المفضل لديك لصور raster، تحديد كيفية التعامل مع ملفات التعريف، تعيين مستوى ضغط للنصوص، تعيين DPI للصور، إلخ.

يوضح مثال الكود أدناه عملية يتم فيها تحويل عرض باوربوينت إلى PDF مع عدة خيارات مخصصة:

```java
// ينشئ فئة PdfOptions
PdfOptions pdfOptions = new PdfOptions();

// يعين الجودة لصور JPG
pdfOptions.setJpegQuality((byte)90);

// يعين DPI للصور
pdfOptions.setSufficientResolution(300);

// يعين السلوك لملفات التعريف
pdfOptions.setSaveMetafilesAsPng(true);

// يعين مستوى ضغط النصوص للمحتوى النصي
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// يحدد وضع الامتثال لـ PDF
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// ينشئ فئة Presentation تمثل مستند باوربوينت
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // يحفظ العرض التقديمي كمستند PDF
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تحويل باوربوينت إلى PDF مع الشرائح المخفية**

إذا كان العرض التقديمي يحتوي على شرائح مخفية، يمكنك استخدام خيار مخصص - خاصية [ShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IPdfOptions#getShowHiddenSlides--) من فئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/PdfOptions) - لإخبار Aspose.Slides بتضمين الشرائح المخفية كصفحات في ملف PDF الناتج.

يوضح لك هذا الكود في Java كيفية تحويل عرض باوربوينت إلى PDF مع تضمين الشرائح المخفية:

```java
// ينشئ كائن من فئة Presentation تمثل ملف باوربوينت
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // ينشئ فئة PdfOptions
    PdfOptions pdfOptions = new PdfOptions();
    
    // يضيف الشرائح المخفية
    pdfOptions.setShowHiddenSlides(true);
    
    // يحفظ العرض التقديمي كملف PDF
    pres.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **تحويل باوربوينت إلى PDF محمي بكلمة مرور**

يوضح لك هذا الكود في Java كيفية تحويل باوربوينت إلى PDF محمي بكلمة مرور (باستخدام معلمات الحماية من فئة [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/PdfOptions)):

```java
// ينشئ كائن Presentation يمثل ملف باوربوينت
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    /// ينشئ فئة PdfOptions
    PdfOptions pdfOptions = new PdfOptions();
    
    // يعين كلمة مرور PDF وأذونات الوصول
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);
    
    // يحفظ العرض التقديمي كملف PDF
    pres.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **اكتشاف استبدالات الخطوط**

تقدم Aspose.Slides الطريقة [getWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#getWarningCallback--) تحت فئة [SaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/) للسماح لك باكتشاف استبدالات الخطوط في عملية تحويل العرض التقديمي إلى PDF. 

يوضح لك هذا الكود في Java كيفية اكتشاف استبدالات الخطوط: 

```java
public void main(String[] args)
{
    LoadOptions loadOptions = new LoadOptions();
    FontSubstSendsWarningCallback warningCallback = new FontSubstSendsWarningCallback();
    loadOptions.setWarningCallback(warningCallback);

    Presentation pres = new Presentation("pres.pptx", loadOptions);
    try {
        
    } finally {
        if (pres != null) pres.dispose();
    }
}

private class FontSubstSendsWarningCallback implements IWarningCallback
{
    public int warning(IWarningInfo warning)
    {
        if (warning.getWarningType() == WarningType.CompatibilityIssue)
            return ReturnAction.Continue;

        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted"))
        {
            System.out.println("تحذير استبدال الخط: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

لمزيد من المعلومات حول الحصول على ردود الفعل لتحذيرات استبدال الخطوط في عملية التنسيق، انظر [الحصول على ردود تحذيرية لاستبدال الخطوط](https://docs.aspose.com/slides/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

لمزيد من المعلومات حول استبدال الخطوط، انظر المقالة [استبدال الخطوط](https://docs.aspose.com/slides/java/font-substitution/).

{{% /alert %}} 

## **تحويل الشرائح المحددة في باوربوينت إلى PDF**

يوضح لك هذا الكود في Java كيفية تحويل شرائح محددة في عرض باوربوينت إلى PDF:

```java
// ينشئ كائن Presentation يمثل ملف باوربوينت
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // يعين مصفوفة لمواقع الشرائح
    int[] slides = { 1, 3 };
    
    // يحفظ العرض التقديمي كملف PDF
    pres.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تحويل باوربوينت إلى PDF مع حجم شريحة مخصص**

يوضح لك هذا الكود في Java كيفية تحويل باوربوينت عندما يتم تحديد حجم الشريحة إلى PDF:

```java
// ينشئ كائن Presentation يمثل ملف باوربوينت 
Presentation pres = new Presentation("SelectedSlides.pptx");
try {
    Presentation outPres = new Presentation();
    try {
        ISlide slide = pres.getSlides().get_Item(0);

        outPres.getSlides().insertClone(0, slide);
        
        // يعين نوع وحجم الشريحة 
        outPres.getSlideSize().setSize(612F, 792F, SlideSizeScaleType.EnsureFit);
        
        PdfOptions pdfOptions = new PdfOptions();
        INotesCommentsLayoutingOptions options = pdfOptions.getNotesCommentsLayouting();
        options.setNotesPosition(NotesPositions.BottomFull);

        outPres.save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        if (pres != null) pres.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **تحويل باوربوينت إلى PDF في وضع عرض الملاحظات**

يوضح لك هذا الكود في Java كيفية تحويل باوربوينت إلى PDF مع الملاحظات:

```java
// ينشئ كائن Presentation يمثل ملف باوربوينت
Presentation pres = new Presentation("SelectedSlides.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    INotesCommentsLayoutingOptions options = pdfOptions.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);

    pres.save("Pdf_With_Notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **معايير الوصول والامتثال لـ PDF**

تتيح لك Aspose.Slides استخدام إجراء تحويل يتوافق مع [إرشادات الوصول لمحتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند باوربوينت إلى PDF باستخدام أي من معايير الامتثال هذه: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

يوضح هذا الكود في Java عملية تحويل باوربوينت إلى PDF حيث يتم الحصول على عدة ملفات PDF بناءً على معايير امتثال مختلفة:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    
    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    pres.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    pres.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    pres.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="ملحوظة" color="warning" %}} 

يمتد دعم Aspose.Slides لعمليات تحويل PDF ليتيح لك تحويل PDF إلى أكثر تنسيقات الملفات شيوعًا. يمكنك القيام بـ [PDF إلى HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/java/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) تحويلات. تدعم أيضًا عمليات تحويل PDF إلى تنسيقات متخصصة أخرى - [PDF إلى SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/).

{{% /alert %}}