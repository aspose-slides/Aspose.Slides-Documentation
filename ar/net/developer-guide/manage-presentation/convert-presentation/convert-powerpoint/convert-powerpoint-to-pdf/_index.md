---
title: تحويل PPT و PPTX إلى PDF في .NET [مع ميزات متقدمة]
linktitle: PowerPoint إلى PDF
type: docs
weight: 40
url: /ar/net/convert-powerpoint-to-pdf/
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
- .NET
- C#
- Aspose.Slides
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في .NET باستخدام Aspose.Slides، مع أمثلة كود C# سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT ، PPTX ، ODP ، وما إلى ذلك) إلى تنسيق PDF في C# يوفر عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي الخاص بك. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، واختيار شرائح محددة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF، مرّر اسم الملف كمعامل إلى الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) ثم احفظ العرض التقديمي كملف PDF باستخدام طريقة [Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/). تُظهر الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) طريقة [Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/) التي تُستخدم عادةً لتحويل عرض تقديمي إلى PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
يقوم Aspose.Slides for .NET بإدراج معلومات API ورقم الإصدار الخاص به في المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، يملأ Aspose.Slides حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنك لا تستطيع إرشاد Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.
{{% /alert %}}

يتيح لك Aspose.Slides تحويل:
* العروض التقديمية بالكامل إلى PDF
* شرائح محددة من عرض تقديمي إلى PDF

يصدّر Aspose.Slides العروض التقديمية إلى PDF، مما يضمن أن ملفات PDF الناتجة تتطابق بشكل كبير مع العروض الأصلية. يتم تمثيل العناصر والسمات بدقة في عملية التحويل، بما في ذلك:
* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* الترويسات والتذييلات
* النقاط
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض التقديمي المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

يعرض هذا الكود C# كيفية تحويل عرض تقديمي (PPT ، PPTX ، ODP ، وما إلى ذلك) إلى PDF:
```c#
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو ملف OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// حفظ العرض التقديمي كملف PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 
تقدم Aspose أداة تحويل مجانية عبر الإنترنت من [**PowerPoint إلى PDF**](https://products.aspose.app/slides/ar/conversion/ppt-to-pdf) تُظهر عملية تحويل العرض التقديمي إلى PDF. يمكنك إجراء اختبار باستخدام هذه الأداة لتطبيق عملي للإجراء الموصوف هنا.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع الخيارات**

يوفر Aspose.Slides خيارات مخصّصة — خصائص ضمن الفئة [PdfOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/) — والتي تسمح لك بتخصيص ملف PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصّصة**

باستخدام خيارات التحويل المخصّصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، وتحديد كيفية معالجة ملفات الميتا، وتعيين مستوى ضغط النص، وتكوين DPI للصور، والمزيد.

يوضح المثال البرمجي أدناه كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصّصة.
```c#
// إنشاء كائن من فئة PdfOptions.
var pdfOptions = new PdfOptions
{
    // ضبط جودة صور JPG.
    JpegQuality = 90,

    // ضبط DPI للصور.
    SufficientResolution = 300,

    // ضبط سلوك ملفات الميتا.
    SaveMetafilesAsPng = true,

    // ضبط مستوى ضغط النص للمحتوى النصي.
    TextCompression = PdfTextCompression.Flate,

    // تعريف وضع الامتثال لـ PDF.
    Compliance = PdfCompliance.Pdf15
};

// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو ملف OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// حفظ العرض التقديمي كملف PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام الخاصية [ShowHiddenSlides](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/showhiddenslides/) من الفئة [PdfOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية كصفحات في ملف PDF الناتج.

يعرض الكود C# كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:
```c#
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو ملف OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// إنشاء كائن من فئة PdfOptions.
var pdfOptions = new PdfOptions();

// إضافة الشرائح المخفية.
pdfOptions.ShowHiddenSlides = true;

// حفظ العرض التقديمي كملف PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

يُظهر هذا الكود C# كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرور باستخدام معلمات الحماية من الفئة [PdfOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/):
```c#
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو ملف OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// إنشاء كائن من فئة PdfOptions.
var pdfOptions = new PdfOptions();

// تعيين كلمة مرور PDF وأذونات الوصول.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// حفظ العرض التقديمي كملف PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **اكتشاف استبدال الخطوط**

يقدم Aspose.Slides الخاصية [WarningCallback](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveoptions/warningcallback/) ضمن الفئة [PdfOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/)، مما يتيح لك اكتشاف استبدالات الخطوط أثناء عملية تحويل العرض إلى PDF.

هذا الكود C# يوضح كيفية اكتشاف استبدالات الخطوط:
```c#
public static void Main()
{
    // إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو ملف OpenDocument. 
    using var presentation = new Presentation("sample.pptx");

    // تعيين رد النداء التحذيري في خيارات PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // حفظ العرض التقديمي كملف PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// تنفيذ رد النداء التحذيري.
private class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 
لمزيد من المعلومات حول استلام ردود النداء لاستبدال الخطوط أثناء عملية العرض، راجع [الحصول على ردود النداء للتحذير بشأن استبدال الخطوط](/slides/ar/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

لمزيد من المعلومات حول استبدال الخطوط، راجع المقالة [Font Substitution](/slides/ar/net/font-substitution/).
{{% /alert %}} 

## **تحويل الشرائح المحددة من PowerPoint إلى PDF**

يُظهر هذا الكود C# كيفية تحويل شرائح محددة فقط من عرض PowerPoint إلى PDF:
```c#
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو ملف OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Set array of slide numbers.
int[] slides = { 1, 3 };

// Save the presentation as a PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

يُظهر هذا الكود C# كيفية تحويل عرض PowerPoint إلى PDF بحجم شريحة محدد:
```c#
var slideWidth = 612;
var slideHeight = 792;

// Load a PowerPoint presentation.
using var presentation = new Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
using var resizedPresentation = new Presentation();

// Set the custom slide size.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Clone the first slide from the original presentation.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```

## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشريحة**

يُظهر هذا الكود C# كيفية تحويل عرض PowerPoint إلى PDF يتضمن الملاحظات:
```c#
// تحميل عرض PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// تهيئة خيارات PDF مع تخطيط الملاحظات.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// حفظ العرض التقديمي كملف PDF مع الملاحظات.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **معايير إمكانية الوصول والامتثال لملف PDF**

يتيح لك Aspose.Slides استخدام إجراء تحويل يتوافق مع [إرشادات إمكانية وصول محتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال هذه: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

يُظهر هذا الكود C# عملية تحويل PowerPoint إلى PDF تنتج ملفات PDF متعددة بناءً على معايير امتثال مختلفة:
```c#
using var presentation = new Presentation("pres.pptx");

presentation.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1a
});

presentation.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1b
});

presentation.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfUa
});
```

{{% alert title="Note" color="warning" %}} 
يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ شائعة. يمكنك إجراء التحويلات: [PDF إلى HTML](https://products.aspose.com/slides/ar/net/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/ar/net/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/ar/net/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/ar/net/conversion/pdf-to-png/). تدعم أيضًا عمليات تحويل PDF إلى صيغ متخصصة — [PDF إلى SVG](https://products.aspose.com/slides/ar/net/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/ar/net/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/ar/net/conversion/pdf-to-xml/).
{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسومات المعقدة مثل SmartArt والمخططات والصيغ ككيان واحد. لا يتم الحفاظ على عناصر المسار الفردية ك محتوى منفصل وقد تُ标记 كعناصر غير مرغوب فيها؛ يتم توفير النص البديل للكيان بالكامل فقط.

## **الأسئلة المتكررة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعيًا؟**

نعم، يدعم Aspose.Slides التحويل الدفعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك المرور على ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF المحول بكلمة مرور؟**

بالطبع. استخدم الفئة [PdfOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

قم بتعيين خاصية `ShowHiddenSlides` في الفئة [PdfOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/) إلى `true` لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة عالية للصور في PDF؟**

نعم، يمكنك التحكم في جودة الصور عن طريق ضبط خصائص مثل `JpegQuality` و`SufficientResolution` في الفئة [PdfOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، يتيح لك Aspose.Slides تصدير ملفات PDF تتوافق مع معايير مختلفة، بما في ذلك PDF/A1a وPDF/A1b وPDF/UA، مما يضمن أن مستنداتك تلبي متطلبات إمكانية الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides لـ .NET](/slides/ar/net/)
- [مرجع API لـ Aspose.Slides لـ .NET](https://reference.aspose.com/slides/ar/net/)
- [محولات Aspose المجانية عبر الإنترنت](https://products.aspose.app/slides/ar/conversion)