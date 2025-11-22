---
title: تحويل PPT و PPTX إلى PDF في C# [ميزات متقدمة مشمولة]
linktitle: تحويل PPT و PPTX إلى PDF
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
- ODP إلى PDF
- تحويل ODP إلى PDF
- حفظ PowerPoint كـ PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- C#
- Csharp
- .NET
- Aspose.Slides لـ .NET
description: "تعلم كيفية تحويل عروض PPT و PPTX و ODP إلى PDF في C# أو .NET باستخدام Aspose.Slides. نفّذ ميزات متقدمة مثل حماية كلمة المرور، ومعايير الامتثال، وخيارات مخصصة للحصول على وثائق PDF عالية الجودة وسهلة الوصول."
---

## **نظرة عامة**

تحويل عروض PowerPoint (PPT, PPTX, ODP، وغيرها) إلى صيغة PDF باستخدام C# يقدم عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي الخاص بك. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، واختيار شرائح معينة للتحويل، وتطبيق معايير الامتثال على الوثائق الناتجة.

## **تحويل PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالتنسيقات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF، مرر اسم الملف كوسيط إلى فئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة [حفظ](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). فئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation/) تكشف عن طريقة [حفظ](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for .NET يدرج معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، يملأ Aspose.Slides حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك إرشاد Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

Aspose.Slides يتيح لك تحويل:

* العروض بالكامل إلى PDF
* شرائح محددة من العرض إلى PDF

Aspose.Slides يصدر العروض إلى PDF، مع ضمان أن PDFs الناتجة تتطابق مع العروض الأصلية. يتم عرض العناصر والسمات بدقة في التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات
* الشرطات
* الجداول

## **تحويل PowerPoint إلى PDF**

عملية التحويل القياسية من PowerPoint إلى PDF تستخدم الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

يظهر هذا الكود C# كيفية تحويل عرض تقديمي (PPT, PPTX, ODP، إلخ) إلى PDF:
```c#
// إنشاء كائن Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// حفظ العرض التقديمي كملف PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```


{{%  alert  color="primary"  %}} 

Aspose يقدم محول **PowerPoint إلى PDF** مجاني عبر الإنترنت يوضح عملية تحويل العرض إلى PDF. يمكنك تشغيل اختبار بهذا المحول لتطبيق عملي للإجراء الموضح هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

Aspose.Slides يقدم خيارات مخصصة—خصائص تحت فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—تتيح لك تخصيص PDF الناتج، قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تعريف إعداد الجودة المفضل للصور النقطية، تحديد كيفية التعامل مع ملفات الميتا، ضبط مستوى الضغط للنص، تكوين DPI للصور، والمزيد.

المثال البرمجي أدناه يوضح كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة.
```c#
// إنشاء كائن PdfOptions.
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

    // تحديد وضع الامتثال لملف PDF.
    Compliance = PdfCompliance.Pdf15
};

// إنشاء كائن Presentation الذي يمثل ملف PowerPoint أو OpenDocument file.
using var presentation = new Presentation("PowerPoint.pptx");

// حفظ العرض التقديمي كملف PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام خاصية [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) من فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

هذا الكود C# يوضح كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:
```c#
// إنشاء كائن Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// إنشاء كائن PdfOptions.
var pdfOptions = new PdfOptions();

// إضافة الشرائح المخفية.
pdfOptions.ShowHiddenSlides = true;

// حفظ العرض التقديمي كملف PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

هذا الكود C# يوضح كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرور باستخدام معلمات الحماية من فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/):
```c#
// إنشاء كائن Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// إنشاء كائن PdfOptions.
var pdfOptions = new PdfOptions();

// تعيين كلمة مرور PDF وأذونات الوصول.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// حفظ العرض التقديمي كملف PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **اكتشاف استبدال الخطوط**

Aspose.Slides يوفر خاصية [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لتتمكن من اكتشاف استبدال الخطوط أثناء عملية تحويل العرض إلى PDF.

هذا الكود C# يوضح كيفية اكتشاف استبدال الخطوط:
```c#
public static void Main()
{
    // إنشاء كائن Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
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

لمزيد من المعلومات حول استلام ردود الفعل لاستبدال الخطوط أثناء عملية العرض، راجع [Getting Warning Callbacks for Fonts Substitution](/slides/ar/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/net/font-substitution/).

{{% /alert %}} 

## **تحويل شرائح محددة من PowerPoint إلى PDF**

هذا الكود C# يوضح كيفية تحويل شرائح محددة فقط من عرض PowerPoint إلى PDF:
```c#
// إنشاء كائن Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// تعيين مصفوفة أرقام الشرائح.
int[] slides = { 1, 3 };

// حفظ العرض التقديمي كملف PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```


## **تحويل PowerPoint إلى PDF مع حجم شريحة مخصص**

هذا الكود C# يوضح كيفية تحويل عرض PowerPoint إلى PDF بحجم شريحة محدد:
```c#
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

// حفظ العرض المُعدل إلى ملف PDF مع الملاحظات.
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```


## **تحويل PowerPoint إلى PDF في وضع الملاحظات على الشرائح**

هذا الكود C# يوضح كيفية تحويل عرض PowerPoint إلى PDF يتضمن الملاحظات:
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

// حفظ العرض التقديمي إلى PDF مع الملاحظات.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```


## **معايير إمكانية الوصول والامتثال لـ PDF**

Aspose.Slides يتيح لك استخدام إجراء تحويل يتوافق مع إرشادات إمكانية الوصول إلى محتوى الويب (**WCAG**) ([Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html)). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**, **PDF/A1b**, و **PDF/UA**.

هذا الكود C# يوضح عملية تحويل PowerPoint إلى PDF تنتج عدة ملفات PDF بناءً على معايير امتثال مختلفة:
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

Aspose.Slides يدعم عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ شائعة. يمكنك إجراء التحويلات التالية: [PDF إلى HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)، [PDF إلى image](https://products.aspose.com/slides/net/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). عمليات تحويل PDF إلى صيغ متخصصة أخرى—[PDF إلى SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—مدعومة أيضًا.

{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني تحويل ملفات PowerPoint متعددة إلى PDF دفعة واحدة؟**

نعم، Aspose.Slides يدعم التحويل الدفعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك iterating عبر ملفاتك وتطبيق عملية التحويل برمجياً.

**هل يمكن حماية PDF المحول بكلمة مرور؟**

بالطبع. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لتعيين كلمة مرور وتعريف أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

قم بتعيين خاصية `ShowHiddenSlides` في فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) إلى `true` لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة صورة عالية في PDF؟**

نعم، يمكنك التحكم في جودة الصورة عن طريق تعيين خصائص مثل `JpegQuality` و `SufficientResolution` في فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، Aspose.Slides يتيح لك تصدير PDFs متوافقة مع معايير مختلفة، بما في ذلك PDF/A1a, PDF/A1b, و PDF/UA، لضمان أن مستنداتك تلبي متطلبات الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides لـ .NET](/slides/ar/net/)
- [مرجع API لـ Aspose.Slides لـ .NET](https://reference.aspose.com/slides/net/)
- [محولات Aspose المجانية عبر الإنترنت](https://products.aspose.app/slides/conversion)