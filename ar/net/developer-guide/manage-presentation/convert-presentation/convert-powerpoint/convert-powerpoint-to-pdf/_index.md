---
title: تحويل PPT و PPTX إلى PDF في .NET [متضمنًا ميزات متقدمة]
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
- حفظ PowerPoint كـ PDF
- حفظ PPT كـ PDF
- حفظ PPTX كـ PDF
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

إن تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى تنسيق PDF باستخدام C# يقدم عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي الخاص بك. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، وتحديد شرائح معينة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالتنسيقات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF، مرّر اسم الملف كمعامل إلى فئة [العرض التقديمي](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة [حفظ](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/). فئة [العرض التقديمي](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) تعرض طريقة [حفظ](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/) التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

يضيف Aspose.Slides for .NET معلومات API ورقم الإصدار إلى المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، يملء Aspose.Slides حقل Application بالقيمة "*Aspose.Slides*" وحقل PDF Producer بقيمة على شكل "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك توجيه Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

يسمح Aspose.Slides لك بتحويل:

* العروض بالكامل إلى PDF
* شرائح محددة من العرض إلى PDF

يقوم Aspose.Slides بتصدير العروض إلى PDF، مما يضمن أن ملفات PDF الناتجة تطابق العروض الأصلية بدقة. يتم عرض العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات الصفحات
* النقاط
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

يعرض هذا الكود C# كيفية تحويل عرض (PPT، PPTX، ODP، إلخ) إلى PDF:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// حفظ العرض التقديمي كملف PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="info"  %}} 

تقدم Aspose أداة مجانية على الإنترنت **محول PowerPoint إلى PDF** ([https://products.aspose.app/slides/ar/conversion/ppt-to-pdf](https://products.aspose.app/slides/ar/conversion/ppt-to-pdf)) تُظهر عملية التحويل من العرض إلى PDF. يمكنك تجربة هذه الأداة للحصول على تنفيذ عملي للعملية الموضحة هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع الخيارات**

يوفر Aspose.Slides خيارات مخصصة—خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/)—تتيح لك تخصيص PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، وتحديد طريقة معالجة ملفات الميتافايل، وتعيين مستوى ضغط للنص، وتكوين DPI للصور، والمزيد.

يوضح المثال البرمجي أدناه كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة PdfOptions.
var pdfOptions = new PdfOptions
{
    // تعيين جودة صور JPG.
    JpegQuality = 90,

    // تعيين DPI للصور.
    SufficientResolution = 300,

    // تعيين سلوك ملفات الميتا.
    SaveMetafilesAsPng = true,

    // تعيين مستوى ضغط النص للمحتوى النصي.
    TextCompression = PdfTextCompression.Flate,

    // تحديد وضع الامتثال لـ PDF.
    Compliance = PdfCompliance.Pdf15
};

// إنشاء كائن من فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// حفظ العرض التقديمي كوثيقة PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام الخاصية [ShowHiddenSlides](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/showhiddenslides/) من فئة [PdfOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

يعرض هذا الكود C# كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// إنشاء كائن من فئة PdfOptions.
var pdfOptions = new PdfOptions();

// إضافة الشرائح المخفية.
pdfOptions.ShowHiddenSlides = true;

// حفظ العرض التقديمي كملف PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

يظهر هذا الكود C# كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرور باستخدام معلمات الحماية من فئة [PdfOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/):

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// إنشاء كائن من فئة PdfOptions.
var pdfOptions = new PdfOptions();

// تعيين كلمة مرور PDF وتحديد أذونات الوصول.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// حفظ العرض التقديمي كملف PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **كشف استبدال الخطوط**

يوفر Aspose.Slides الخاصية [WarningCallback](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveoptions/warningcallback/) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/) لتتيح لك اكتشاف استبدال الخطوط أثناء عملية التحويل من العرض إلى PDF.

يظهر هذا الكود C# كيفية اكتشاف استبدال الخطوط:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

public static void Main()
{
    // إنشاء كائن من فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
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

{{%  alert color="info"  %}} 

لمزيد من المعلومات حول تلقي ردود الاستدعاء لاستبدال الخطوط أثناء عملية التجسيد، راجع المقالة [Getting Warning Callbacks for Fonts Substitution](/slides/ar/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/net/font-substitution/).

{{% /alert %}} 

## **تحويل شرائح محددة من PowerPoint إلى PDF**

يعرض هذا الكود C# كيفية تحويل شرائح محددة فقط من عرض PowerPoint إلى PDF:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// تعيين مصفوفة أرقام الشرائح.
int[] slides = { 1, 3 };

// حفظ العرض التقديمي كملف PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

يعرض هذا الكود C# كيفية تحويل عرض PowerPoint إلى PDF مع حجم شريحة محدد:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

// تحميل عرض PowerPoint.
using var presentation = new Presentation("SelectedSlides.pptx");

// إنشاء عرض تقديمي جديد بحجم شريحة معدل.
using var resizedPresentation = new Presentation();

// تعيين حجم الشريحة المخصص.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// استنساخ الشريحة الأولى من العرض الأصلي.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// إزالة الشريحة الفارغة التي تم إنشاء العرض الجديد معها.
resizedPresentation.Slides.RemoveAt(1);

// حفظ العرض المعاد تحجيمه كملف PDF.
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشريحة**

يعرض هذا الكود C# كيفية تحويل عرض PowerPoint إلى PDF يتضمن الملاحظات:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// تحميل عرض PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// Configure the PDF options with Notes Layout.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// Save the presentation to a PDF with notes.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **إمكانية الوصول ومعايير الامتثال لملف PDF**

يسمح Aspose.Slides لك باستخدام إجراء تحويل يتوافق مع [إرشادات وصول محتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

يعرض هذا الكود C# عملية تحويل من PowerPoint إلى PDF تنتج ملفات PDF متعددة بناءً على معايير امتثال مختلفة:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ شائعة. يمكنك إجراء التحويلات التالية: [PDF إلى HTML](https://products.aspose.com/slides/ar/net/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/ar/net/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/ar/net/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/ar/net/conversion/pdf-to-png/). كما يتم دعم عمليات التحويل إلى صيغ متخصصة—[PDF إلى SVG](https://products.aspose.com/slides/ar/net/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/ar/net/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/ar/net/conversion/pdf-to-xml/).

{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، يعامل Aspose.Slides الرسومات المعقدة مثل SmartArt، المخططات، والصيغ ككائن واحد. لا يتم الحفاظ على عناصر المسار الفردية ك محتوى منفصل وقد تُصنّف كملامح؛ يُقدم النص البديل فقط للكائن الكامل.

## **الأسئلة المتكررة**

### هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعيًا؟

نعم، يدعم Aspose.Slides التحويل الدفعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك تكرار الملفات وتطبيق عملية التحويل برمجيًا.

### هل يمكن حماية PDF الناتج بكلمة مرور؟

بالطبع. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

### كيف يمكن إدراج الشرائح المخفية في PDF؟

قم بتعيين الخاصية `ShowHiddenSlides` في فئة [PdfOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/) إلى `true` لتضمين الشرائح المخفية في PDF الناتج.

### هل يستطيع Aspose.Slides الحفاظ على جودة الصور العالية في PDF؟

نعم، يمكنك التحكم في جودة الصورة بتعيين خصائص مثل `JpegQuality` و`SufficientResolution` في فئة [PdfOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

### هل يدعم Aspose.Slides معايير الامتثال PDF/A؟

نعم، يتيح Aspose.Slides تصدير PDFs تتوافق مع معايير مختلفة، بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، مما يضمن تلبية مستنداتك لمتطلبات الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides for .NET](/slides/ar/net/)
- [مرجع API لـ Aspose.Slides for .NET](https://reference.aspose.com/slides/ar/net/)
- [محولات Aspose المجانية على الإنترنت](https://products.aspose.app/slides/ar/conversion)