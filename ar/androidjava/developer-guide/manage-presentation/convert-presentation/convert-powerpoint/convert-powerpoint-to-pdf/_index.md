---
title: تحويل PowerPoint إلى PDF في Java
linktitle: تحويل PowerPoint إلى PDF
type: docs
weight: 40
url: /androidjava/convert-powerpoint-to-pdf/
keywords:
- تحويل PowerPoint
- عرض تقديمي
- PowerPoint إلى PDF
- PPT إلى PDF
- PPTX إلى PDF
- حفظ PowerPoint كـ PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides لـ Android عبر Java
description: "تحويل العروض التقديمية PowerPoint إلى PDF في Java. حفظ PowerPoint كـ PDF مع الامتثال أو معايير الوصول."
---

## **نظرة عامة**

تحويل مستندات PowerPoint إلى صيغة PDF يقدم العديد من المزايا، بما في ذلك ضمان التوافق عبر مختلف الأجهزة والحفاظ على التخطيط والتنسيق لعرضك التقديمي. توضح هذه المقالة كيفية تحويل العروض التقديمية إلى مستندات PDF، واستخدام خيارات متنوعة للتحكم في جودة الصور، وإدراج الشرائح المخفية، وحماية مستندات PDF بكلمة مرور، وكشف استبدالات الخطوط، واختيار الشرائح للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض التقديمية في هذه الصيغ إلى PDF:

* PPT
* PPTX
* ODP

لتحويل عرض تقديمي إلى PDF، عليك ببساطة تمرير اسم الملف كمعامل في [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class ثم حفظ العرض التقديمي كـ PDF باستخدام طريقة [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-). يكشف [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class عن طريقة [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) التي تُستخدم عادةً لتحويل عرض تقديمي إلى PDF.

{{%  alert title="ملاحظة"  color="warning"   %}} 

Aspose.Slides لـ Android عبر Java يكتب مباشرةً معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، يقوم Aspose.Slides لـ Android عبر Java بتعبئة حقل التطبيق بقيمة '*Aspose.Slides*' وحقل منتج PDF بقيمة في شكل '*Aspose.Slides v XX.XX*'. **ملاحظة** أنك لا تستطيع توجيه Aspose.Slides لـ Android عبر Java لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

Aspose.Slides يسمح لك بتحويل:

* عرض تقديمي كامل إلى PDF
* شرائح معينة في عرض تقديمي إلى PDF
* عرض تقديمي 

Aspose.Slides يصدر العروض التقديمية إلى PDF بطريقة تجعل محتويات ملفات PDF الناتجة متشابهة جداً مع تلك الموجودة في العروض التقديمية الأصلية. هذه العناصر والسمات المعروفة غالبًا ما تُعرض بشكل صحيح في تحويلات العرض التقديمي إلى PDF:

* الصور
* صناديق النصوص وأشكال أخرى
* النصوص وتنسيقاتها
* الفقرات وتنسيقاتها
* الروابط التشعبية
* الترويسات والتذييل
* النقاط
* الجداول

## **تحويل PowerPoint إلى PDF**

تتم عملية تحويل PowerPoint إلى PDF القياسية باستخدام الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض التقديمي المقدم إلى PDF باستخدام الإعدادات المثلى عند مستويات الجودة القصوى.

يظهر لك هذا الكود في Java كيفية تحويل PowerPoint إلى PDF:

```java
// يقوم بإنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint
Presentation pres = new Presentation("PowerPoint.ppt");
try {
    // يحفظ العرض التقديمي كـ PDF
    pres.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert  color="primary"  %}} 

توفر Aspose محول [**PowerPoint إلى PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) مجاني عبر الإنترنت يوضح عملية تحويل العرض التقديمي إلى PDF. لتنفيذ مباشر للإجراء الموصوف هنا، يمكنك إجراء اختبار باستخدام المحول.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة—خصائص في فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PdfOptions)—تتيح لك تخصيص PDF (الناجم عن عملية التحويل)، قفل PDF بكلمة مرور، أو حتى تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تعيين إعداد الجودة المفضل لديك للصور النقطية، وتحديد كيفية التعامل مع ملفات التعريف، وتعيين مستوى ضغط للنصوص، وتعيين DPI للصورة، وما إلى ذلك.

يظهر مثال الكود أدناه عملية تحويل حيث يتم تحويل عرض تقديمي PowerPoint إلى PDF مع العديد من الخيارات المخصصة:

```java
// يقوم بإنشاء كائن من فئة PdfOptions
PdfOptions pdfOptions = new PdfOptions();

// تعيين الجودة لصورة JPG
pdfOptions.setJpegQuality((byte)90);

// تعيين DPI للصور
pdfOptions.setSufficientResolution(300);

// تعيين سلوك لملفات التعريف
pdfOptions.setSaveMetafilesAsPng(true);

// تعيين مستوى ضغط النص للمحتوى النصي
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// تحديد وضع الامتثال لملف PDF
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// يقوم بإنشاء كائن من فئة Presentation التي تمثل مستند PowerPoint
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // يحفظ العرض التقديمي كمستند PDF
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تحويل PowerPoint إلى PDF مع شرائح مخفية**

إذا كان عرض تقديمي يحتوي على شرائح مخفية، يمكنك استخدام خيار مخصص—خاصية [ShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPdfOptions#getShowHiddenSlides--) من فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PdfOptions)—لإرشاد Aspose.Slides لتضمين الشرائح المخفية كصفحات في ملف PDF الناتج.

يظهر لك هذا الكود في Java كيفية تحويل عرض تقديمي PowerPoint إلى PDF مع تضمين الشرائح المخفية:

```java
// يقوم بإنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // يقوم بإنشاء كائن من فئة PdfOptions
    PdfOptions pdfOptions = new PdfOptions();
    
    // إضافة الشرائح المخفية
    pdfOptions.setShowHiddenSlides(true);
    
    // يحفظ العرض التقديمي كـ PDF
    pres.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

يظهر لك هذا الكود في Java كيفية تحويل PowerPoint إلى PDF محمي بكلمة مرور (باستخدام معلمات الحماية من فئة [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PdfOptions)):

```java
// يقوم بإنشاء كائن Presentation الذي يمثل ملف PowerPoint
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    /// يقوم بإنشاء كائن من فئة PdfOptions
    PdfOptions pdfOptions = new PdfOptions();
    
    // تعيين كلمة مرور PDF وأذونات الوصول
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);
    
    // يحفظ العرض التقديمي كـ PDF
    pres.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **كشف استبدالات الخطوط**

يوفر Aspose.Slides أسلوب [getWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#getWarningCallback--) تحت فئة [SaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/) للسماح لك بكشف استبدالات الخطوط في عملية تحويل العرض التقديمي إلى PDF.

يظهر لك هذا الكود في Java كيفية كشف استبدالات الخطوط:

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
                warning.getDescription().startsWith("سيتم استبدال الخط"))
        {
            System.out.println("تحذير استبدال الخط: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

للحصول على مزيد من المعلومات حول الحصول على ردود الفعل بشأن استبدالات الخطوط في عملية العرض، انظر [الحصول على ردود التحذير لاستبدال الخطوط](https://docs.aspose.com/slides/androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

للحصول على مزيد من المعلومات حول استبدال الخط، انظر مقال [استبدال الخط](https://docs.aspose.com/slides/androidjava/font-substitution/).

{{% /alert %}} 

## **تحويل شرائح محددة في PowerPoint إلى PDF**

يظهر لك هذا الكود في Java كيفية تحويل شرائح محددة في عرض تقديمي PowerPoint إلى PDF:

```java
// يقوم بإنشاء كائن Presentation الذي يمثل ملف PowerPoint
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // تعيين مصفوفة لمواقع الشرائح
    int[] slides = { 1, 3 };
    
    // يحفظ العرض التقديمي كـ PDF
    pres.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تحويل PowerPoint إلى PDF مع حجم شريحة مخصص**

يظهر لك هذا الكود في Java كيفية تحويل PowerPoint عندما يتم تحديد حجم شريحته إلى PDF:

```java
// يقوم بإنشاء كائن Presentation الذي يمثل ملف PowerPoint 
Presentation pres = new Presentation("SelectedSlides.pptx");
try {
    Presentation outPres = new Presentation();
    try {
        ISlide slide = pres.getSlides().get_Item(0);

        outPres.getSlides().insertClone(0, slide);
        
        // تعيين نوع وحجم الشريحة 
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

## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشرائح**

يظهر لك هذا الكود في Java كيفية تحويل PowerPoint إلى PDF مع الملاحظات:

```java
// يقوم بإنشاء كائن Presentation الذي يمثل ملف PowerPoint
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

## **معايير الوصول والامتثال لملف PDF**

يتيح لك Aspose.Slides استخدام إجراء تحويل يتوافق مع [إرشادات الوصول لمحتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال هذه: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

يوضح هذا الكود في Java عملية تحويل PowerPoint إلى PDF حيث يتم الحصول على عدة ملفات PDF اعتمادًا على معايير الامتثال المختلفة:

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

{{% alert title="ملاحظة" color="warning" %}} 

تدعم Aspose.Slides عمليات تحويل PDF إلى الملفات الأكثر شيوعًا. يمكنك إجراء تحويل [PDF إلى HTML](https://products.aspose.com/slides/androidjava/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/androidjava/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/androidjava/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/androidjava/conversion/pdf-to-png/). تدعم أيضًا عمليات تحويل PDF إلى تنسيقات متخصصة—[PDF إلى SVG](https://products.aspose.com/slides/androidjava/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/androidjava/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/androidjava/conversion/pdf-to-xml/).

{{% /alert %}}