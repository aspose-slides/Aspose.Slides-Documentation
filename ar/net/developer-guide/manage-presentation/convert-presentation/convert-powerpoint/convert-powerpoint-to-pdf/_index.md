---
title: تحويل PPT و PPTX إلى PDF في .NET [متضمنة ميزات متقدمة]
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
- مرفق
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "تحويل عروض PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في .NET باستخدام Aspose.Slides، مع أمثلة كود C# سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

يسمح تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى صيغة PDF باستخدام C# بعدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصورة، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، واختيار شرائح معينة للتحويل، وتطبيق معايير الالتزام على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالصياغات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF، مرر اسم الملف كوسيط إلى الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). تُظهر فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) التي تُستعمل عادةً لتحويل العرض إلى PDF.

{{% alert color="info" title="Note" %}}
تُدرج Aspose.Slides for .NET معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، تملأ Aspose.Slides حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة على شكل "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك توجيه Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.
{{% /alert %}}

تسمح لك Aspose.Slides بـ:

* تحويل العروض بالكامل إلى PDF
* تحويل شرائح محددة من عرض إلى PDF

تصدّر Aspose.Slides العروض إلى PDF، مما يضمن أن PDFs الناتجة تتطابق بشكل كبير مع العروض الأصلية. تُرسم العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات
* النقاط
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، تحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

المثال التالي يحمل عرضًا ويحفظ جميع الشرائح المرئية إلى PDF باستخدام إعدادات التصدير الافتراضية.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
توفر Aspose أداة مجانية على الإنترنت [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) تُظهر عملية تحويل العرض إلى PDF. يمكنك إجراء اختبار باستخدام هذه الأداة للحصول على تنفيذ حي للإجراء الموضح هنا.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

توفر Aspose.Slides خيارات مخصصة—خصائص ضمن الفئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—تتيح لك تخصيص PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، وتحديد طريقة معالجة ملفات الميتافايل، وتعيين مستوى ضغط النص، وتكوين DPI للصور، وأكثر.

المثال التالي يُصدّر عرضًا إلى PDF 1.5 مع جودة JPEG مضبوطة على 90، ودقة الصورة على 300 DPI، وملفات الميتافايل تُحفظ كـ PNG، وضغط نص Flate.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    JpegQuality = 90,
    SufficientResolution = 300,
    SaveMetafilesAsPng = true,
    TextCompression = PdfTextCompression.Flate,
    Compliance = PdfCompliance.Pdf15
};

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **الحفاظ على ملفات OLE المدمجة كمرفقات PDF**

إذا كان العرض يحتوي على دفتر Excel مدمج، قد ترغب في تمكين مستقبلين PDF من الوصول إلى بيانات دفتر العمل بالإضافة إلى مشاهدة الشرائح. اضبط [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) على `true` للحفاظ على ملفات OLE المدمجة كمرفقات في PDF الناتج.

القيمة الافتراضية هي `false`: يتم عرض صورة معاينة كائن OLE أو أيقونته في صفحة PDF، لكن الملف المدمج غير مُدرج كمرفق. ضبط الخيار على `true` يضيف بيانات الملف كمرفق. تظل المعاينة تمثيلًا بصريًا؛ المرفق يتيح للمستقبلين فتح أو حفظ الملف المدمج بشكل منفصل. لا يتحول كائن OLE إلى ورقة عمل Excel تفاعلية في صفحة PDF.

المثال التالي يحمل عرضًا يحتوي بالفعل على دفتر Excel مدمج ويصدّره إلى PDF مع إرفاق دفتر العمل.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

للتحقق من النتيجة:

1. افتح PDF المصدر في عارض يدعم المرفقات، مثل Adobe Acrobat Reader.
2. افتح لوحة **Attachments** في العارض وحدد دفتر العمل المدمج.
3. احفظ المرفق وافتحه في Excel لتفحص بياناته، أو افتحه مباشرة إذا سمح العارض بذلك. المعاينة في صفحة PDF منفصلة عن المرفق.

{{% alert color="info" title="Note" %}}
تفرض معايير PDF/A قيودًا على المرفقات: PDF/A-1 تحظر الملفات المدمجة، PDF/A-2 تسمح فقط بمرفقات PDF/A، وPDF/A-3 تسمح بأنواع ملفات أخرى بما فيها دفاتر Excel. هذه متطلبات المعايير، ليست قيودًا خاصة بـ Aspose.Slides. يستخدم هذا المثال الإعداد الافتراضي للامتثال لـ PDF ولا يُظهر تصدير PDF/A.
{{% /alert %}}

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام خاصية [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) من فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

المثال التالي يُصدّر عرضًا إلى PDF مع تضمين أي شرائح مخفية.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

المثال التالي يُصدّر عرضًا إلى PDF يتطلب كلمة المرور `password` للفتح. تسمح أذونات الوصول بالطباعة، بما فيها الطباعة عالية الجودة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **اكتشاف استبدال الخطوط**

توفر Aspose.Slides خاصية [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)، مما يتيح لك اكتشاف استبدال الخطوط أثناء عملية تحويل العرض إلى PDF.

المثال التالي يُصدّر عرضًا إلى PDF ويطبع تحذيرات استبدال الخطوط إلى وحدة التحكم. يتم طباعة التحذير فقط عندما يتم استبدال خط غير متوفر أثناء التصدير.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using System;

var pdfOptions = new PdfOptions();
pdfOptions.WarningCallback = new FontSubstitutionHandler();

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss && warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="info" title="Note" %}}
للمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/net/font-substitution/).
{{% /alert %}} 

## **تحويل الشرائح المحددة من PowerPoint إلى PDF**

المثال التالي يُصدّر الشريحتين 1 و3 من عرض إلى PDF. أرقام الشرائح في هذا المصفوفة تبدأ من الواحد، ويجب أن يحتوي العرض المدخل على ثلاث شرائح على الأقل.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **تحويل PowerPoint إلى PDF مع حجم شريحة مخصص**

المثال التالي ينسخ الشريحة الأولى من عرض إلى عرض جديد بحجم شريحة 612 × 792 نقطة (8.5 × 11 بوصة). يُعيد تحجيم محتوى الشريحة ليناسب الحجم ويُصدّر الشريحة الوحيدة إلى PDF.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

using var presentation = new Presentation("SelectedSlides.pptx");
using var resizedPresentation = new Presentation();

resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **تحويل PowerPoint إلى PDF في وضع ملاحظات الشريحة**

المثال التالي يُصدّر عرضًا إلى PDF، حيث يُوضع كل ملاحظات المتحدث أسفل الشريحة. استخدم عرضًا يحتوي على ملاحظات المتحدث لرؤية النتيجة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

using var presentation = new Presentation("NotesFile.pptx");
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **معايير الوصول والامتثال لـ PDF**

تمكّنك Aspose.Slides من استخدام إجراء تحويل يلتزم بـ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الالتزام التالية: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

يوضح الكود التالي عملية تحويل PowerPoint إلى PDF تُنتج ملفات PDF متعددة بناءً على معايير امتثال مختلفة:

```csharp
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

{{% alert color="info" title="Note" %}}
تدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ شائعة. يمكنك إجراء تحويلات [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)، [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/)، [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/)، و[PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). كما تُدعم عمليات تحويل PDF إلى صيغ متخصصة—[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)، [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/)، و[PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—.
{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، تعالج Aspose.Slides الرسومات المعقدة مثل SmartArt والرسوم البيانية والصيغ ككائن واحد. لا تُحافظ العناصر الفردية للمسار كمحتوى منفصل وقد تُصنّف كعناصر غير هامة؛ يُقدَّم النص البديل فقط للكائن الكامل.

## **الأسئلة المتكررة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعة واحدة؟**

نعم، تدعم Aspose.Slides التحويل الدفعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك التنقل عبر ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF الناتج بكلمة مرور؟**

نعم. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

**كيف أضمّن الشرائح المخفية في PDF؟**

اضبط خاصية [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) في فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) على `true` لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة صورة عالية في PDF؟**

نعم، يمكنك التحكم في جودة الصورة عبر ضبط خصائص مثل [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) و[SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) في فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل تدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، تتيح لك Aspose.Slides تصدير ملفات PDF تتوافق مع معايير مختلفة، بما فيها PDF/A1a، PDF/A1b، وPDF/UA، مما يضمن أن مستنداتك تلبي متطلبات الوصول والأرشفة.

## **موارد إضافية**

- [Aspose.Slides for .NET Documentation](/slides/ar/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)