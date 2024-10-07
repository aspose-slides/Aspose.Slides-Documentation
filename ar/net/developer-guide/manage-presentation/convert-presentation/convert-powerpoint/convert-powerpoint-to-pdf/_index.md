---
title: تحويل PowerPoint إلى PDF في C#
linktitle: تحويل PowerPoint إلى PDF
type: docs
weight: 40
url: /net/convert-powerpoint-to-pdf/
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
- C#
- Csharp
- .NET
- Aspose.Slides لـ .NET
description: "تحويل عروض PowerPoint التقديمية إلى PDF في C# أو .NET. حفظ PowerPoint كـ PDF مع الامتثال أو معايير الوصول."
---

## **نظرة عامة**

تحويل وثائق PowerPoint إلى تنسيق PDF يوفر العديد من المزايا، بما في ذلك ضمان التوافق عبر الأجهزة المختلفة والحفاظ على تنسيق العرض التقديمي. يوضح لك هذا المقال كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات متنوعة للتحكم في جودة الصورة، وإدراج الشرائح المخفية، وحماية مستندات PDF بكلمة مرور، واكتشاف استبدال الخطوط، واختيار الشرائح للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

يمكنك استخدام Aspose.Slides لتحويل العروض التقديمية بهذه التنسيقات إلى PDF:

* PPT
* PPTX
* ODP

لتحويل عرض تقديمي إلى PDF، عليك ببساطة تمرير اسم الملف كمعامل في [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class ثم حفظ العرض التقديمي كـ PDF باستخدام طريقة [`Save`](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). تصدر [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class الطريقة [`Save`](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/#presentationsave-method-5-of-9) التي تستخدم عادة لتحويل عرض تقديمي إلى PDF.

{{%  alert title="ملاحظة"  color="warning"   %}} 

Aspose.Slides لـ .NET يكتب مباشرة معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، يقوم Aspose.Slides لـ .NET بإدخال قيمة '*Aspose.Slides*' في حقل التطبيق وقيمة على شكل '*Aspose.Slides v XX.XX*' في حقل منتج PDF. **ملاحظة** أنه لا يمكنك إرشاد Aspose.Slides لـ .NET لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

يسمح Aspose.Slides لك بتحويل:

* عرض تقديمي كامل إلى PDF
* شرائح محددة في عرض تقديمي إلى PDF
* عرض تقديمي 

يصدر Aspose.Slides العروض التقديمية إلى PDF بطريقة تجعل محتويات ملفات PDF الناتجة مشابهة جدًا لتلك الموجودة في العروض التقديمية الأصلية. غالبًا ما يتم عرض هذه العناصر والسمات المعروفة بشكل صحيح أثناء تحويل العروض التقديمية إلى PDF:

* الصور
* صناديق النصوص وأشكال أخرى
* النصوص وتنسيقها
* الفقرات وتنسيقها
* الروابط التشعبية
* الترويسات والتذييلات
* الرموز النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

تتم عملية تحويل PowerPoint إلى PDF القياسية باستخدام الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض التقديمي المقدم إلى PDF باستخدام إعدادات مثلى على أعلى مستويات الجودة.

يوضح لك كود C# التالي كيفية تحويل PowerPoint (PPT، PPTX، ODP) إلى PDF:

```c#
// ينشئ كائن فئة Presentation الذي يمثل ملف PowerPoint، يمكن أن يكون PPT، PPTX، ODP إلخ.
Presentation presentation = new Presentation("PowerPoint.ppt");

// يحفظ العرض التقديمي كـ PDF
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 

توفر Aspose أداة تحويل [**PowerPoint إلى PDF مجانية عبر الإنترنت**](https://products.aspose.app/slides/conversion/ppt-to-pdf) توضح عملية تحويل العرض التقديمي إلى PDF. من أجل تنفيذ مباشر للإجراء الموصوف هنا، يمكنك إجراء اختبار مع المحول.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة - خصائص تحت فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) - التي تتيح لك تخصيص PDF (الذي ينتج عن عملية التحويل)، وتأمين PDF بكلمة مرور، أو حتى تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تعيين إعداد الجودة المفضل لديك لصور النقطية، تحديد كيفية التعامل مع ملفات الميتا، تعيين مستوى الضغط للنصوص، تعيين DPI للصور، إلخ.

يوضح مثال الكود أدناه عملية يتم فيها تحويل عرض PowerPoint إلى PDF مع العديد من الخيارات المخصصة:

```c#
// ينشئ كائن فئة PdfOptions
PdfOptions pdfOptions = new PdfOptions
{
    // يحدد الجودة لصور JPG
    JpegQuality = 90,

    // يحدد DPI للصور
    SufficientResolution = 300,

    // يحدد السلوك لملفات الميتا
    SaveMetafilesAsPng = true,

    // يحدد مستوى ضغط النص للمحتوى النصي
    TextCompression = PdfTextCompression.Flate,

    // يحدد وضع التوافق مع PDF
    Compliance = PdfCompliance.Pdf15
};

// ينشئ كائن فئة Presentation الذي يمثل وثيقة PowerPoint
using (Presentation presentation = new Presentation("PowerPoint.pptx"))
{
    // يحفظ العرض التقديمي كـ مستند PDF
    presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
}
```

### **تحويل PowerPoint إلى PDF مع شرائح مخفية**

إذا كان العرض التقديمي يحتوي على شرائح مخفية، يمكنك استخدام خيار مخصص - خاصية [`ShowHiddenSlides`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) من فئة [`PdfOptions`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) - لتوجيه Aspose.Slides لتضمين الشرائح المخفية كصفحات في PDF الناتجة.

يوضح كود C# التالي كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:

```c#
// ينشئ كائن فئة Presentation الذي يمثل ملف PowerPoint
Presentation presentation = new Presentation("PowerPoint.pptx");

// ينشئ كائن فئة PdfOptions
PdfOptions pdfOptions = new PdfOptions();

// يضيف الشرائح المخفية
pdfOptions.ShowHiddenSlides = true;

// يحفظ العرض التقديمي كـ PDF
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

يوضح كود C# التالي كيفية تحويل PowerPoint إلى PDF محمي بكلمة مرور (باستخدام معلمات الحماية من فئة [`PdfOptions`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)):

```c#
// ينشئ كائن فئة Presentation الذي يمثل ملف PowerPoint
Presentation presentation = new Presentation("PowerPoint.pptx");

/// ينشئ كائن فئة PdfOptions
PdfOptions pdfOptions = new PdfOptions();

// يحدد كلمة مرور PDF وأذونات الوصول
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// يحفظ العرض التقديمي كـ PDF
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **كشف استبدال الخطوط**

يوفر Aspose.Slides خاصية [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) تحت فئة [SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) للسماح لك بالكشف عن استبدال الخطوط في عملية تحويل عرض تقديمي إلى PDF. 

يوضح كود C# التالي كيفية الكشف عن استبدال الخطوط:

```c#
public static void Main()
{
    LoadOptions loadOptions = new LoadOptions();
    FontSubstSendsWarningCallback warningCallback = new FontSubstSendsWarningCallback();
    loadOptions.WarningCallback = warningCallback;

    using (Presentation pres = new Presentation("pres.pptx", loadOptions))
    {
    }
}

private class FontSubstSendsWarningCallback : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.CompatibilityIssue)
            return ReturnAction.Continue;

        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"تحذير استبدال الخط: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

لمزيد من المعلومات حول الحصول على ردود الفعل بشأن استبدال الخطوط في عملية العرض، انظر [الحصول على ردود التحذير لاستبدال الخطوط](https://docs.aspose.com/slides/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

لمزيد من المعلومات حول استبدال الخطوط، اقرأ المقالة [استبدال الخطوط](https://docs.aspose.com/slides/net/font-substitution/).

{{% /alert %}} 

## **تحويل الشرائح المحددة في PowerPoint إلى PDF**

يوضح كود C# التالي كيفية تحويل شرائح معينة في عرض PowerPoint إلى PDF:

```c#
// ينشئ كائن فئة Presentation الذي يمثل ملف PowerPoint
Presentation presentation = new Presentation("PowerPoint.pptx");

// يحدد مصفوفة من مواقع الشرائح
int[] slides = { 1, 3 };

// يحفظ العرض التقديمي كـ PDF
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **تحويل PowerPoint إلى PDF مع حجم شريحة مخصص**

يوضح كود C# التالي كيفية تحويل PowerPoint عندما يتم تحديد حجم شريحته إلى PDF:

```c#
// ينشئ كائن فئة Presentation الذي يمثل ملف PowerPoint 
Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];
auxPresentation.Slides.InsertClone(0, slide);

// يحدد نوع وحجم الشريحة 
// auxPresentation.SlideSize.SetSize(presentation.SlideSize.Size.Width, presentation.SlideSize.Size.Height,SlideSizeScaleType.EnsureFit);
auxPresentation.SlideSize.SetSize(612F, 792F,SlideSizeScaleType.EnsureFit);

PdfOptions pdfOptions = new PdfOptions();
INotesCommentsLayoutingOptions options = pdfOptions.NotesCommentsLayouting;
options.NotesPosition = NotesPositions.BottomFull;

auxPresentation.Save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
```

## **تحويل PowerPoint إلى PDF في عرض الشريحة الملاحظات**

يوضح كود C# التالي كيفية تحويل PowerPoint إلى ملاحظات PDF:

```c#
// ينشئ كائن فئة Presentation الذي يمثل ملف PowerPoint
using (Presentation presentation = new Presentation("NotesFile.pptx"))
{
	PdfOptions pdfOptions = new PdfOptions();
	INotesCommentsLayoutingOptions options = pdfOptions.NotesCommentsLayouting;
	options.NotesPosition = NotesPositions.BottomFull;

	// يحفظ العرض التقديمي إلى ملاحظات PDF
	presentation.Save("Pdf_Notes_out.tiff", SaveFormat.Pdf, pdfOptions);
}
```

## **معايير الوصول والامتثال لـ PDF**

يتيح Aspose.Slides لك استخدام إجراء تحويل يتوافق مع [إرشادات الوصول إلى محتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير وثيقة PowerPoint إلى PDF باستخدام أي من معايير الامتثال هذه: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

يوضح كود C# التالي عملية تحويل PowerPoint إلى PDF حيث يتم الحصول على عدة ملفات PDF بناءً على معايير الامتثال المختلفة:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
    {
        Compliance = PdfCompliance.PdfA1a
    });
   
    pres.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
    {
        Compliance = PdfCompliance.PdfA1b
    });
   
    pres.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
   {
        Compliance = PdfCompliance.PdfUa
    });
}
```

{{% alert title="ملاحظة" color="warning" %}} 

يدعم Aspose.Slides عمليات تحويل PDF مما يتيح لك تحويل PDF إلى أكثر تنسيقات الملفات شيوعًا. يمكنك القيام بـ [PDF إلى HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/net/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/)، و [PDF إلى PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) تحولات. كما تدعم عمليات تحويل PDF إلى تنسيقات متخصصة - [PDF إلى SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/)، و [PDF إلى XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/).

{{% /alert %}}