---
title: تحويل PPT و PPTX إلى PDF في .NET [مع تضمين الميزات المتقدمة]
linktitle: PowerPoint إلى PDF
type: docs
weight: 40
url: /ar/net/convert-powerpoint-to-pdf/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- PowerPoint إلى PDF
- العرض إلى PDF
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
description: "تحويل عروض PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في .NET باستخدام Aspose.Slides، مع أمثلة كود C# سريعة وخيارات تحويل متقدمة."
---

## **نظرة عامة**

يُوفر تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى صيغة PDF في C# عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط العرض وتنسيقه. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف بدائل الخطوط، واختيار شرائح معينة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويل PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالصيغات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF، مرّر اسم الملف كوسيط إلى الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). تُعرِض الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) التي تُستَخدم عادةً لتحويل العرض إلى PDF.

{{%  alert title="ملاحظة"  color="warning"   %}} 

يقوم Aspose.Slides for .NET بإدراج معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، يملأ Aspose.Slides حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة على نمط "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك إرشاد Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

يسمح Aspose.Slides لك بتحويل:

* العروض بالكامل إلى PDF
* شرائح محددة من عرض إلى PDF

يصدّر Aspose.Slides العروض إلى PDF، مما يضمن تطابق ملفات PDF الناتجة مع العروض الأصلية بدقة. يتم عرض العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

* الصور
* صناديق النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* الترويسات والتذييلات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

يعرض هذا الكود C# كيفية تحويل عرض (PPT، PPTX، ODP، إلخ) إلى PDF:
```c#
// إنشاء مثيل لفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// حفظ العرض كملف PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```


{{%  alert  color="primary"  %}} 

يقدّم Aspose محولًا مجانيًا على الإنترنت **PowerPoint to PDF converter**[https://products.aspose.app/slides/conversion/ppt-to-pdf] يُظهر عملية التحويل من العرض إلى PDF. يمكنك تجربة هذا المحول لتنفيذ عمليّة حية للخطوات الموضحة هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يقدّم Aspose.Slides خيارات مخصصة—خصائص ضمن الفئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—تتيح لك تخصيص PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تحديد إعداد جودة الصور النقطية المفضلة، وتحديد طريقة معالجة ملفات الميتافايل، وتعيين مستوى ضغط النص، وتكوين DPI للصور، وأكثر.

يعرض مثال الكود أدناه كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة.
```c#
 // إنشاء كائن من الفئة PdfOptions.
 var pdfOptions = new PdfOptions
 {
     // تعيين جودة الصور بصيغة JPG.
     JpegQuality = 90,

     // تعيين DPI للصور.
     SufficientResolution = 300,

     // تحديد سلوك ملفات الميتا.
     SaveMetafilesAsPng = true,

     // تعيين مستوى ضغط النص للمحتوى النصي.
     TextCompression = PdfTextCompression.Flate,

     // تحديد وضع الامتثال لملف PDF.
     Compliance = PdfCompliance.Pdf15
 };

 // إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
 using var presentation = new Presentation("PowerPoint.pptx");

 // حفظ العرض كوثيقة PDF.
 presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام الخاصية [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) من الفئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

يعرض هذا الكود C# كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:
```c#
// إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// إنشاء كائن من الفئة PdfOptions.
var pdfOptions = new PdfOptions();

// إضافة الشرائح المخفية.
pdfOptions.ShowHiddenSlides = true;

// حفظ العرض كملف PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

يوضح هذا الكود C# كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرور باستخدام معلمات الحماية من الفئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/):
```c#
// إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// إنشاء كائن من الفئة PdfOptions.
var pdfOptions = new PdfOptions();

// تعيين كلمة مرور PDF وأذونات الوصول.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// حفظ العرض كملف PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **اكتشاف بدائل الخطوط**

يُوفر Aspose.Slides الخاصية [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) ضمن الفئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) التي تتيح لك اكتشاف بدائل الخطوط أثناء عملية التحويل من العرض إلى PDF.

يعرض هذا الكود C# كيفية اكتشاف بدائل الخطوط:
```c#
public static void Main()
{
    // إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument file. 
    using var presentation = new Presentation("sample.pptx");

    // تعيين رد الاتصال التحذيري في خيارات PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // حفظ العرض كملف PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// تنفيذ رد الاتصال التحذيري.
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

لمزيد من المعلومات حول الحصول على ردود استدعاء للخطوط المستبدلة أثناء عملية العرض، راجع [Getting Warning Callbacks for Fonts Substitution](/slides/ar/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

لمزيد من المعلومات حول بدائل الخطوط، اطلع على مقالة [Font Substitution](/slides/ar/net/font-substitution/).

{{% /alert %}} 

## **تحويل الشرائح المحددة من PowerPoint إلى PDF**

يوضح هذا الكود C# كيفية تحويل شرائح محددة فقط من عرض PowerPoint إلى PDF:
```c#
// إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// تعيين مصفوفة أرقام الشرائح.
int[] slides = { 1, 3 };

// حفظ العرض كملف PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```


## **تحويل PowerPoint إلى PDF مع حجم شريحة مخصص**

يوضح هذا الكود C# كيفية تحويل عرض PowerPoint إلى PDF بحجم شريحة محدد:
```c#
var slideWidth = 612;
var slideHeight = 792;

// تحميل عرض PowerPoint.
using var presentation = new Presentation("SelectedSlides.pptx");

// إنشاء عرض جديد بحجم شريحة معدل.
using var resizedPresentation = new Presentation();

// تحديد حجم الشريحة المخصص.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// نسخ الشريحة الأولى من العرض الأصلي.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// حفظ العرض المعاد تحجيمه كملف PDF مع الملاحظات.
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```


## **تحويل PowerPoint إلى PDF في وضع ملاحظة الشريحة**

يوضح هذا الكود C# كيفية تحويل عرض PowerPoint إلى PDF يتضمن الملاحظات:
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

// حفظ العرض إلى PDF مع الملاحظات.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```


## **معايير إمكانية الوصول والامتثال للـ PDF**

يتيح Aspose.Slides لك استخدام إجراءات تحويل تتوافق مع [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**, **PDF/A1b**, و **PDF/UA**.

يعرض هذا الكود C# عملية تحويل PowerPoint إلى PDF تُنتج ملفات PDF متعددة بناءً على معايير امتثال مختلفة:
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


{{% alert title="ملاحظة" color="warning" %}} 

يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ شائعة. يمكنك إجراء التحويلات [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)، [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/)، [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/)، و[PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). كما تُدعم عمليات التحويل المتخصصة مثل [PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)، [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/)، و[PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/).

{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعة واحدة؟**

نعم، يدعم Aspose.Slides التحويل الجماعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك تكرار ملفاتك وتطبيق عملية التحويل برمجياً.

**هل يمكن حماية PDF المحوّل بكلمة مرور؟**

بالطبع. استخدم الفئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لتعيين كلمة مرور وتعريف أذونات الوصول أثناء عملية التحويل.

**كيف أضمّن الشرائح المخفية في PDF؟**

قم بتعيين الخاصية `ShowHiddenSlides` في الفئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) إلى `true` لتضمين الشرائح المخفية في الـ PDF الناتج.

**هل يستطيع Aspose.Slides الحفاظ على جودة عالية للصور في PDF؟**

نعم، يمكنك التحكم في جودة الصور بتعيين خصائص مثل `JpegQuality` و `SufficientResolution` في الفئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لضمان صور عالية الجودة في ملف PDF.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، يتيح Aspose.Slides تصدير ملفات PDF تتوافق مع معايير مختلفة بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، مما يضمن تلبية مستنداتك لمتطلبات الوصول والأرشفة.

## **موارد إضافية**

- [Aspose.Slides for .NET Documentation](/slides/ar/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)