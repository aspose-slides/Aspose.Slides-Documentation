---
title: تحويل PPT و PPTX إلى PDF في .NET [الميزات المتقدمة مشمولة]
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

تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى تنسيق PDF باستخدام C# يوفر عدة مزايا، بما في ذلك التوافق عبر مختلف الأجهزة والحفاظ على تخطيط وتنسيق العرض التقديمي الخاص بك. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وإدراج الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، واختيار شرائح محددة للتحويل، وتطبيق معايير الالتزام على المستندات الناتجة.

## **تحويل PowerPoint إلى PDF**

Using Aspose.Slides, you can convert presentations in the following formats to PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF، مرّر اسم الملف كوسيطة إلى فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ثم احفظ العرض بصيغة PDF باستخدام طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) تكشف عن طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) التي تُستخدم عادةً لتحويل عرض تقديمي إلى PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
تُدرج Aspose.Slides for .NET معلومات API وإصدارها في المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، تقوم Aspose.Slides بملء حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنك لا تستطيع إرشاد Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.
{{% /alert %}}

تتيح لك Aspose.Slides تحويل:
* العروض الكاملة إلى PDF
* شرائح محددة من عرض تقديمي إلى PDF

تصدّر Aspose.Slides العروض إلى PDF، مما يضمن أن ملفات PDF الناتجة تتطابق بدقة مع العروض الأصلية. يتم عرض العناصر والسمات بدقة أثناء التحويل، بما في ذلك:
* الصور
* صناديق النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* الترويسات والتذييلات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، تحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

This C# code shows you how to convert a presentation (PPT, PPTX, ODP, etc.) to PDF:
```c#
// إنشاء كائن الفئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// حفظ العرض التقديمي كملف PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```


{{%  alert  color="primary"  %}} 
توفر Aspose أداة تحويل مجانية على الإنترنت **PowerPoint to PDF converter** تُظهر عملية تحويل العرض إلى PDF. يمكنك إجراء اختبار باستخدام هذه الأداة لتطبيق عملي للإجراء الموصوف هنا.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع الخيارات**

توفر Aspose.Slides خيارات مخصصة—خصائص تحت فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—تتيح لك تخصيص ملف PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، وتحديد طريقة معالجة ملفات الميتا، وضبط مستوى الضغط للنص، وتكوين DPI للصور، والمزيد.

The code example below demonstrates how to convert a PowerPoint presentation to PDF with several custom options.
```c#
// إنشاء كائن PdfOptions.
var pdfOptions = new PdfOptions
{
    // ضبط الجودة لصور JPG.
    JpegQuality = 90,

    // ضبط DPI للصور.
    SufficientResolution = 300,

    // ضبط سلوك ملفات الميتا.
    SaveMetafilesAsPng = true,

    // ضبط مستوى ضغط النص للمحتوى النصي.
    TextCompression = PdfTextCompression.Flate,

    // تحديد وضع التوافق مع PDF.
    Compliance = PdfCompliance.Pdf15
};

// إنشاء كائن Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// حفظ العرض التقديمي كملف PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام خاصية [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) من فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

This C# code shows how to convert a PowerPoint presentation to PDF with hidden slides included:
```c#
// إنشاء كائن الفئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// إنشاء كائن الفئة PdfOptions.
var pdfOptions = new PdfOptions();

// إضافة الشرائح المخفية.
pdfOptions.ShowHiddenSlides = true;

// حفظ العرض التقديمي كملف PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

This C# code demonstrates how to convert a PowerPoint presentation into a password-protected PDF using the protection parameters from the [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) class:
```c#
// إنشاء كائن الفئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// إنشاء كائن الفئة PdfOptions.
var pdfOptions = new PdfOptions();

// تعيين كلمة مرور PDF وأذونات الوصول.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// حفظ العرض التقديمي كملف PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **اكتشاف استبدال الخطوط**

توفر Aspose.Slides خاصية [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) تحت فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)، مما يتيح لك اكتشاف استبدال الخطوط أثناء عملية تحويل العرض إلى PDF.

This C# code shows how to detect font substitutions:
```c#
public static void Main()
{
    // إنشاء كائن الفئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
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
لمزيد من المعلومات حول تلقي ردود الاتصال لاستبدال الخطوط أثناء عملية العرض، راجع [Getting Warning Callbacks for Fonts Substitution](/slides/ar/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

لمزيد من المعلومات حول استبدال الخطوط، راجع مقال [Font Substitution](/slides/ar/net/font-substitution/).
{{% /alert %}} 

## **تحويل شرائح مختارة من PowerPoint إلى PDF**

This C# code demonstrates how to convert only specific slides from a PowerPoint presentation to PDF:
```c#
// إنشاء كائن الفئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// تحديد مصفوفة أرقام الشرائح.
int[] slides = { 1, 3 };

// حفظ العرض التقديمي كملف PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```


## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

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

```c#
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

// حفظ العرض التقديمي إلى PDF مع الملاحظات.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```


## **معايير الوصول والامتثال لـ PDF**

تتيح لك Aspose.Slides استخدام إجراء تحويل يتوافق مع [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

This C# code demonstrates a PowerPoint-to-PDF conversion process that produces multiple PDFs based on different compliance standards:
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
تدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ شائعة. يمكنك إجراء التحويلات [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)، [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/)، [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/)، و[PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). تدعم أيضًا عمليات تحويل PDF إلى صيغ متخصصة—[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)، [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/)، و[PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني تحويل ملفات PowerPoint متعددة إلى PDF دفعيًا؟**

نعم، تدعم Aspose.Slides تحويل دفعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك المرور عبر ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF الناتج بكلمة مرور؟**

بالطبع. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

قم بضبط خاصية `ShowHiddenSlides` في فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) إلى `true` لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة عالية للصور في PDF؟**

نعم، يمكنك التحكم في جودة الصور عن طريق ضبط خصائص مثل `JpegQuality` و`SufficientResolution` في فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لضمان جودة عالية للصور في PDF الخاص بك.

**هل تدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، تتيح لك Aspose.Slides تصدير ملفات PDF المتوافقة مع معايير مختلفة، بما في ذلك PDF/A1a وPDF/A1b وPDF/UA، مما يضمن أن مستنداتك تلتزم بمتطلبات الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides لـ .NET](/slides/ar/net/)
- [مرجع Aspose.Slides API لـ .NET](https://reference.aspose.com/slides/net/)
- [محولات أسبوز مجانية على الإنترنت](https://products.aspose.app/slides/conversion)