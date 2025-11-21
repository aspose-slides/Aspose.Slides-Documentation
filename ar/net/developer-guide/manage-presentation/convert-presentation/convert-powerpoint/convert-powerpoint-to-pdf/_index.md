---
title: تحويل PPT و PPTX إلى PDF في .NET [تشمل الميزات المتقدمة]
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
description: "قم بتحويل عروض PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في .NET باستخدام Aspose.Slides، مع أمثلة كود C# سريعة وخيارات تحويل متقدمة."
---

## **نظرة عامة**

إن تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى تنسيق PDF باستخدام C# يوفر العديد من المزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وعرض الملف التقديمي. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصورة، وإدراج الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدالات الخطوط، واختيار شرائح معينة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويل PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالصيغة التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF، مرّر اسم الملف كمعامل إلى فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) تعرض طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

يقوم Aspose.Slides for .NET بإدراج معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، يملأ Aspose.Slides حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك إبلاغ Aspose.Slides بتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

يسمح Aspose.Slides لك بتحويل:

* العروض بالكامل إلى PDF
* شرائح معينة من العرض إلى PDF

يصدر Aspose.Slides العروض إلى PDF، مع ضمان أن PDFs الناتجة تطابق العروض الأصلية بشكل وثيق. يتم عرض العناصر والسمات بدقة خلال التحويل، بما في ذلك:

* الصور
* صناديق النصوص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات الصفحات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

يعرض هذا الكود C# كيفية تحويل عرض (PPT، PPTX، ODP، إلخ) إلى PDF:
```c#
// إنشاء كائن من الفئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// حفظ العرض بصيغة PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```


{{%  alert  color="primary"  %}} 

توفر Aspose أداة مجانية على الإنترنت تُدعى [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) توضح عملية تحويل العرض إلى PDF. يمكنك تجربة الأداة للحصول على تنفيذ حي للإجراء الموضح هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة—خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—تمكنك من تخصيص PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، وتحديد كيفية معالجة ملفات الميتا، وضبط مستوى الضغط للنص، وتكوين DPI للصور، والمزيد.

يوضح المثال البرمجي أدناه كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة.
```c#
// إنشاء كائن من الفئة PdfOptions.
var pdfOptions = new PdfOptions
{
    // ضبط جودة صور JPG.
    JpegQuality = 90,

    // ضبط DPI للصور.
    SufficientResolution = 300,

    // تحديد سلوك ملفات الميتا.
    SaveMetafilesAsPng = true,

    // ضبط مستوى ضغط النص للمحتوى النصي.
    TextCompression = PdfTextCompression.Flate,

    // تحديد وضع الامتثال لملف PDF.
    Compliance = PdfCompliance.Pdf15
};

// إنشاء كائن من الفئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// حفظ العرض كملف PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام الخاصية [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) من فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لإدراج الشرائح المخفية كصفحات في PDF الناتج.

يعرض هذا الكود C# كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:
```c#
// إنشاء كائن من الفئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// إنشاء كائن من الفئة PdfOptions.
var pdfOptions = new PdfOptions();

// إضافة الشرائح المخفية.
pdfOptions.ShowHiddenSlides = true;

// حفظ العرض كملف PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

يعرض هذا الكود C# كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرور باستخدام معاملات الحماية من فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/):
```c#
// إنشاء كائن من الفئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// إنشاء كائن من الفئة PdfOptions.
var pdfOptions = new PdfOptions();

// تعيين كلمة مرور PDF وأذونات الوصول.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// حفظ العرض كملف PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **اكتشاف استبدالات الخطوط**

يوفر Aspose.Slides الخاصية [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) التي تمكنك من اكتشاف استبدالات الخطوط أثناء عملية تحويل العرض إلى PDF.

يعرض هذا الكود C# كيفية اكتشاف استبدالات الخطوط:
```c#
public static void Main()
{
    // إنشاء كائن من الفئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
    using var presentation = new Presentation("sample.pptx");

    // تعيين رد النداء للتحذير في خيارات PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // حفظ العرض كملف PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// تنفيذ رد النداء للتحذير.
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

لمزيد من المعلومات حول الحصول على ردود استدعاء لاستبدالات الخطوط أثناء عملية العرض، راجع [Getting Warning Callbacks for Fonts Substitution](/slides/ar/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/net/font-substitution/).

{{% /alert %}} 

## **تحويل شرائح محددة من PowerPoint إلى PDF**

يعرض هذا الكود C# كيفية تحويل شرائح معينة فقط من عرض PowerPoint إلى PDF:
```c#
// إنشاء كائن من الفئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// تعيين مصفوفة أرقام الشرائح.
int[] slides = { 1, 3 };

// حفظ العرض كملف PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```


## **تحويل PowerPoint إلى PDF مع حجم شريحة مخصص**

يعرض هذا الكود C# كيفية تحويل عرض PowerPoint إلى PDF بحجم شريحة محدد:
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


## **تحويل PowerPoint إلى PDF في وضع ملاحظات الشرائح**

يعرض هذا الكود C# كيفية تحويل عرض PowerPoint إلى PDF يشمل الملاحظات:
```c#
// تحميل عرض PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// تكوين خيارات PDF مع تخطيط الملاحظات.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// حفظ العرض إلى PDF مع الملاحظات.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```


## **معايير الوصول والامتثال للـ PDF**

يسمح Aspose.Slides لك باستخدام إجراء تحويل يتوافق مع [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

يعرض هذا الكود C# عملية تحويل PowerPoint إلى PDF تنتج عدة ملفات PDF بناءً على معايير الامتثال المختلفة:
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

يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ ملفات شائعة. يمكنك تنفيذ التحويلات التالية: [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)، [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/)، [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/)، و[PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). تدعم عمليات تحويل PDF إلى صيغ متخصصة أخرى—[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)، [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/)، و[PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/).

{{% /alert %}}

## **الأسئلة المتكررة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعيًا؟**

نعم، يدعم Aspose.Slides التحويل الدفعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك المرور على ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF الناتج بكلمة مرور؟**

بالطبع. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

قم بتعيين الخاصية `ShowHiddenSlides` في فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) إلى `true` لتضمين الشرائح المخفية في PDF الناتج.

**هل يستطيع Aspose.Slides الحفاظ على جودة الصور العالية في PDF؟**

نعم، يمكنك التحكم في جودة الصور بتعيين خصائص مثل `JpegQuality` و `SufficientResolution` في فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، يتيح لك Aspose.Slides تصدير ملفات PDF تتوافق مع معايير مختلفة، بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، مما يضمن أن مستنداتك تلبي متطلبات الوصول والأرشفة.

## **موارد إضافية**

- [Aspose.Slides for .NET Documentation](/slides/ar/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)