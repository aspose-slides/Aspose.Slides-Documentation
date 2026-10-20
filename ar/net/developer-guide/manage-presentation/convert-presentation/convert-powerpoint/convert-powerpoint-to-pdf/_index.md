---
title: تحويل PPT و PPTX إلى PDF في .NET [يتضمن ميزات متقدمة]
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
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في .NET باستخدام Aspose.Slides، مع أمثلة كود C# السريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى صيغة PDF باستخدام C# يمنح عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصورة، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، اختيار شرائح معينة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويل PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالتنسيقات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF، قم بتمرير اسم الملف كمعامل إلى فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) تعرض طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{% alert color="info" title="ملاحظة" %}}

يقوم Aspose.Slides for .NET بإدراج معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، يملأ Aspose.Slides حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة على صيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك توجيه Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

يسمح Aspose.Slides لك بتحويل:

* العروض الكاملة إلى PDF
* شرائح محددة من عرض تقديمي إلى PDF

يصدر Aspose.Slides العروض إلى PDF، مع ضمان تطابق ملفات PDF الناتجة مع العروض الأصلية بدقة. يتم تمثيل العناصر والسمات بدقة في التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات الصفحات
* العلامات النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

المثال التالي يحمل عرضًا تقديميًا ويحفظ جميع الشرائح المرئية إلى PDF باستخدام إعدادات التصدير الافتراضية.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="ملاحظة" %}}

تقدم Aspose أداة مجانية على الإنترنت [**محول PowerPoint إلى PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) تُظهر عملية تحويل العرض إلى PDF. يمكنك تجربة هذه الأداة للحصول على تنفيذ عملي للإجراء الموصوف هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة—خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—تتيح لك تخصيص PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تحديد إعداد الجودة المفضل للصور النقطية، وتحديد طريقة معالجة ملفات metafile، وتعيين مستوى ضغط النص، وتكوين DPI للصور، وأكثر.

المثال التالي يصدر عرضًا تقديميًا إلى PDF 1.5 مع جودة JPEG مضبوطة على 90، دقة الصورة على 300 DPI، وحفظ ملفات metafile كـ PNG، وضغط نص Flate.

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

### **تحديد ضغط الصورة تلقائيًا**

عند احتواء العرض على العديد من الصور أو لقطات الشاشة، يمكن أن يقلل تقليل حجم PDF المُصدَّر من صعوبة إرساله عبر البريد الإلكتروني أو تحميله. اضبط [PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/) إلى `true` لتحديد أفضل خوارزمية ضغط لكل صورة تلقائيًا أثناء تصدير PDF.

المثال التالي يحمل عرضًا موجودًا، يفعّل اختيار ضغط الصورة التلقائي، ويحفظه كمستند PDF. جميع إعدادات تصدير PDF الأخرى تحتفظ بقيمها الافتراضية.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

هذا الخيار يحدد خوارزمية ضغط لكل صورة. خفض قيمة [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) يقلل من جودة صورة JPEG، بينما خفض قيمة [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) يسمح بتقليل دقة الصور، ما قد يقلل التفاصيل. تمكين الاختيار التلقائي للضغط لا يقلل من أي من هذين الإعدادين بحد ذاته.

يتطلب اختيار خوارزميات ضغط الصور وقت معالجة وذاكرة إضافية. يعتمد تقليل الحجم على صور العرض وإعدادات التصدير؛ لا يمكن ضمان تقليل ثابت لكل عرض.

### **الحفاظ على ملفات OLE المضمنة كمرفقات PDF**

إذا كان العرض يحتوي على مصنف Excel مضمّن، قد ترغب في أن يتمكن مستلمو PDF من الوصول إلى بيانات المصنف بالإضافة إلى مشاهدة الشرائح. اضبط [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) إلى `true` للحفاظ على ملفات OLE المضمنة كمرفقات في PDF الناتج.

القيمة الافتراضية هي `false`: يتم عرض صورة معاينة كائن OLE أو أيقونته على صفحة PDF، لكن الملف المضمن لا يُضمَّن كمرفق. ضبط الخيار إلى `true` يضيف بيانات الملف أيضًا. تظل المعاينة تمثيلًا بصريًا؛ المرفق يتيح للمستلمين فتح أو حفظ الملف المضمّن بشكل منفصل. لا يتحول كائن OLE إلى ورقة عمل Excel تفاعلية على صفحة PDF.

المثال التالي يحمل عرضًا يحتوي بالفعل على مصنف Excel مضمّن ويصدّره إلى PDF مع إرفاق المصنف.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

للتحقق من النتيجة:

1. افتح PDF المُصدَّر في عارض يدعم مرفقات الملفات، مثل Adobe Acrobat Reader.
2. افتح لوحة **Attachments** للعارض وحدد المصنف المضمن.
3. احفظ المرفق وافتحه في Excel للتحقق من بياناته، أو افتحه مباشرة إذا سمح العارض بذلك. المعاينة على صفحة PDF منفصلة عن المرفق.

{{% alert color="info" title="ملاحظة" %}}

تفرض معايير PDF/A قيودًا على المرفقات: PDF/A-1 يحظر الملفات المضمّنة، PDF/A-2 يسمح فقط بمرفقات PDF/A، وPDF/A-3 يسمح بأنواع ملفات أخرى بما في ذلك مصنفات Excel. هذه متطلبات المعايير، ليست قيودًا خاصة بـ Aspose.Slides. يستخدم هذا المثال إعداد الامتثال الافتراضي للـ PDF ولا يُظهر تصدير PDF/A.

{{% /alert %}}

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام الخاصية [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) من فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

المثال التالي يصدر عرضًا تقديميًا إلى PDF، بما في ذلك أي شرائح مخفية.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

المثال التالي يصدر عرضًا تقديميًا إلى PDF يتطلب كلمة المرور `password` للفتح. تسمح أذونات الوصول بالطباعة، بما فيها الطباعة عالية الجودة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **كشف استبدال الخطوط**

يوفر Aspose.Slides الخاصية [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) التي تتيح لك اكتشاف استبدال الخطوط أثناء عملية تحويل العرض إلى PDF.

المثال التالي يصدر عرضًا تقديميًا إلى PDF ويطبع تحذيرات استبدال الخطوط إلى وحدة التحكم. يُطبع التحذير فقط عندما يتم استبدال خط غير متوفر أثناء التصدير.

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

{{% alert color="info" title="ملاحظة" %}}

لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/net/font-substitution/).

{{% /alert %}} 

### **معالجة الخطوط التي لا تحتوي على نمط سميك مخصص**

يمكن للعرض تطبيق تنسيق سميك للنص حتى وإن لم يتضمن الخط نمطًا سميكًا مخصصًا. لا يزال النص يظهر سميكًا عبر التسمك الصناعي، والذي يزيد من سمك الحروف العادية. عندما يبدو هذا النص ثقيلًا جدًا أو يختلف عن المظهر المقصود في PDF، جرّب ضبط [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) إلى `true`. هذا الخيار يرسم النص المتأثر كصورة نقطية أثناء تصدير PDF ويمكن أن يحسّن مظهره لبعض الخطوط. القيمة الافتراضية هي `false`.

يتضمن العرض التجريبي مربعين نصيين: أحدهما نص عادي والآخر نص سميك لنفس الخط الذي لا يحتوي على نمط سميك مخصص. المثال التالي يحمل العرض، يفعّل تحويل أنماط الخط غير المدعومة إلى نقطية، ويصدّره إلى PDF:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    RasterizeUnsupportedFontStyles = true
};

using var presentation = new Presentation("unsupported-bold.pptx");
presentation.Save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
```

يعرض المعاين التالي النتيجة مع تعطيل الخيار ومع تفعيل الخيار. في هذا المثال، يكون للنص السميك خطوط أثقل مع تعطيل الخيار. مع تفعيل الخيار، تصبح خطوطه أخف؛ النص العادي يبقى دون تغيير. قارن النتائج قبل اختيار الإعداد المناسب لعرضك.

| الخيار معطل (`false`، القيمة الافتراضية) | الخيار مفعَّل (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

في هذا المثال، يؤدي تفعيل الخيار إلى تحويل النص السميك فقط إلى صورة نقطية: لا يمكن تحديده أو نسخه أو البحث فيه كنص دون OCR، وتظهر حوافه أكثر نعومة عند التكبير 800 %. يبقى النص العادي قابلاً للبحث. مع تعطيل الخيار، يبقى كلا النصين كنص.

هذا الخيار يُحول النص المنسق كـ سميك عندما لا يتوفر للخط نمط سميك مخصص. بدلاً من ذلك، تقوم [Font Substitution](/slides/ar/net/font-substitution/) باختيار خط آخر عندما يكون الأصلي غير متوفر.

## **تحويل شرائح مختارة من PowerPoint إلى PDF**

المثال التالي يصدر الشرائح 1 و 3 من عرض تقديمي إلى PDF. أرقام الشرائح في هذا المصفوفة تبدأ من الواحد، ويجب أن يحتوي العرض على الأقل على ثلاث شرائح.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

المثال التالي ينسخ الشريحة الأولى من عرض تقديمي إلى عرض تقديمي جديد بحجم شريحة 612 × 792 نقطة (8.5 × 11 بوصة). يضبط محتوى الشريحة لتناسب الحجم ويصدّر الشريحة الوحيدة إلى PDF.

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

المثال التالي يصدر عرضًا تقديميًا إلى PDF، حيث يضع ملاحظات المتحدث أسفل كل شريحة. استخدم عرضًا يحتوي على ملاحظات المتحدث لرؤية النتيجة.

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

## **إمكانية الوصول ومعايير الامتثال للـ PDF**

يسمح Aspose.Slides باستخدام إجراء تحويل يتماشى مع [إرشادات إمكانية الوصول لمحتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال هذه: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

يعرض هذا الكود C# عملية تحويل PowerPoint إلى PDF تنتج ملفات PDF متعددة بناءً على معايير الامتثال المختلفة:

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

{{% alert color="info" title="ملاحظة" %}}

يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى تنسيقات ملفات شائعة. يمكنك إجراء تحويلات [PDF إلى HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/net/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). كما يتم دعم عمليات تحويل PDF إلى تنسيقات متخصصة—[PDF إلى SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—أيضًا.

{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسومات المعقدة مثل SmartArt والرسوم البيانية والصيغ كشكل واحد. لا تُحفظ عناصر المسار الفردية كمحتوى منفصل وقد تُصنَّف كعناصر فنية؛ يُقدَّم النص البديل فقط للكامل.

## **الأسئلة الشائعة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعة واحدة؟**

نعم، يدعم Aspose.Slides التحويل الجماعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك تكرار ملفاتك وتطبيق عملية التحويل برمجياً.

**هل يمكن حماية PDF الناتج بكلمة مرور؟**

نعم. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لتعيين كلمة مرور وتعريف أذونات الوصول أثناء عملية التحويل.

**كيف يمكن تضمين الشرائح المخفية في PDF؟**

اضبط الخاصية [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) في فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) إلى `true` لتضمين الشرائح المخفية في PDF الناتج.

**هل يستطيع Aspose.Slides الحفاظ على جودة عالية للصور في PDF؟**

نعم، يمكنك التحكم في جودة الصور بتعيين خصائص مثل [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) و[SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) في فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، يتيح Aspose.Slides تصدير ملفات PDF تتوافق مع معايير مختلفة، بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، لضمان توافر إمكانية الوصول ومتطلبات الأرشفة لمستنداتك.

## **موارد إضافية**

- [Aspose.Slides for .NET Documentation](/slides/ar/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)