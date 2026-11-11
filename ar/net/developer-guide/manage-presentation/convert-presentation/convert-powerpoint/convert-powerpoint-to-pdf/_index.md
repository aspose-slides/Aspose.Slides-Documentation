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
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في .NET باستخدام Aspose.Slides، مع أمثلة كود C# سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى تنسيق PDF باستخدام C# يقدم عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي الخاص بك. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وإدراج الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدالات الخطوط، واختيار شرائح محددة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض التقديمية بالتنسيقات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF، قم بتمرير اسم الملف كمعامل إلى الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ثم احفظ العرض التقديمي كملف PDF باستخدام طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) تعرض طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) التي تُستخدم عادةً لتحويل عرض تقديمي إلى PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET يدرج معلومات واجهة برمجة التطبيقات ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، يقوم Aspose.Slides بملئ حقل Application بالقيمة "*Aspose.Slides*" وحقل PDF Producer بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك إرشاد Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.
{{% /alert %}}

يتيح لك Aspose.Slides تحويل:

* عروض تقديمية كاملة إلى PDF
* شرائح محددة من عرض تقديمي إلى PDF

يصدر Aspose.Slides العروض التقديمية إلى PDF، مما يضمن تطابق ملفات PDF الناتجة مع العروض الأصلية بشكل وثيق. يتم تمثيل العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

* صور
* صناديق نصية وأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط
* رؤوس وتذييلات
* نقط
* جداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

يقوم المثال التالي بتحميل عرض تقديمي وحفظ جميع الشرائح الظاهرة إلى PDF باستخدام إعدادات التصدير الافتراضية.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose تقدم محولًا مجانيًا عبر الإنترنت [**محول PowerPoint إلى PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) يوضح عملية تحويل العرض إلى PDF. يمكنك إجراء اختبار باستخدام هذا المحول لتنفيذ عمليًا للإجراءات الموضحة هنا.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع الخيارات**

يوفر Aspose.Slides خيارات مخصصة — خصائص تحت الفئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) — تتيح لك تخصيص PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، وتحديد طريقة معالجة ملفات الميتافي، وضبط مستوى ضغط النص، وتكوين DPI للصور، والمزيد.

يقوم المثال التالي بتصدير عرض تقديمي إلى PDF 1.5 مع ضبط جودة JPEG إلى 90، ودقة الصورة إلى 300 DPI، وحفظ ملفات الميتافي كـ PNG، وضغط نص Flate.

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

> **ملاحظة:** يمكنك تحسين جودة عرض تأثيرات الظل والانعكاس للنص عند التحويل إلى PDF عن طريق ضبط `PdfOptions.SufficientResolution` إلى قيمة أعلى (مثال، `300`). ينتج عن ذلك مخرجات PDF تتطابق بصورة أقرب مع مظهر PowerPoint.

### **اختيار ضغط الصورة تلقائيًا**

عند احتواء عرض تقديمي على العديد من الصور الفوتوغرافية أو لقطات الشاشة، فإن تقليل حجم PDF المُصدّر يمكن أن يسهل إرساله بالبريد الإلكتروني أو تنزيله. اضبط [PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/) إلى القيمة `true` لتحديد خوارزمية الضغط الأنسب لكل صورة تلقائيًا أثناء تصدير PDF.

يقوم المثال التالي بتحميل عرض تقديمي موجود، وتمكين اختيار ضغط الصورة تلقائيًا، ثم حفظه كملف PDF. تحتفظ جميع إعدادات تصدير PDF الأخرى بقيمها الافتراضية.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

تقوم هذه الخيار باختيار خوارزمية ضغط لكل صورة. تقليل [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) يؤدي إلى خفض جودة صورة JPEG، بينما يقلل تقليل [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) من إمكانية تقليل عينة الصور إلى دقة أقل، مما قد يقلل من التفاصيل. تمكين اختيار الضغط التلقائي لا يقلل من أي من هذين الإعدادين بحد ذاته.

يتطلب اختيار خوارزميات ضغط الصور زمن معالجة إضافي وذاكرة إضافية. يعتمد تقليل الحجم على صور العرض وإعدادات التصدير؛ لا يمكن ضمان تقليل ثابت لكل عرض تقديمي.

### **الحفاظ على ملفات OLE المضمنة كمرفقات PDF**

إذا كان العرض يحتوي على مصنف Excel مضمّن، قد ترغب في تمكين مستلمي PDF من الوصول إلى بيانات المصنف بالإضافة إلى عرض الشرائح. اضبط [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) إلى `true` للحفاظ على ملفات OLE المضمّنة كمرفقات في PDF الناتج.

القيمة الافتراضية هي `false`: يتم عرض صورة المعاينة أو الأيقونة لكائن OLE على صفحة PDF، لكن الملف المضمن لا يُدرج كمرفق. ضبط الخيار إلى `true` يضيف بيانات الملف أيضًا. تظل المعاينة تمثيلًا بصريًا؛ المرفق يسمح للمستلمين بفتح أو حفظ الملف المضمّن بشكل منفصل. لا يتحول كائن OLE إلى ورقة Excel تفاعلية على صفحة PDF.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

للتحقق من النتيجة:

1. افتح ملف PDF المُصدّر في عارض يدعم المرفقات، مثل Adobe Acrobat Reader.
2. افتح لوحة **المرفقات** في العارض وابحث عن المصنف المضمّن.
3. احفظ المرفق وافتحه في Excel لتفحص بياناته، أو افتحه مباشرة إذا سمح العارض بذلك. المعاينة على صفحة PDF منفصلة عن المرفق.

{{% alert color="info" title="Note" %}}
معايير PDF/A تفرض قيودًا على المرفقات: PDF/A-1 يحظر الملفات المضمّنة، PDF/A-2 يسمح فقط بمرفقات PDF/A، وPDF/A-3 يسمح بأنواع ملفات أخرى، بما في ذلك مصنفات Excel. هذه متطلبات المعايير، ليست قيودًا خاصة بـ Aspose.Slides. يستخدم هذا المثال الإعداد الافتراضي للامتثال لـ PDF ولا يوضح تصدير PDF/A.
{{% /alert %}}

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام الخاصية [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) من الفئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

يقوم المثال التالي بتصدير عرض تقديمي إلى PDF يتطلب كلمة المرور `password` للفتح. تسمح أذونات الوصول بالطباعة، بما في ذلك الطباعة عالية الجودة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **اكتشاف استبدالات الخطوط**

يوفر Aspose.Slides الخاصية [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) ضمن الفئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)، مما يتيح لك اكتشاف استبدالات الخطوط أثناء عملية تحويل العرض إلى PDF.

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
**ملاحظة**: لمزيد من المعلومات حول استبدال الخط، راجع مقالة [استبدال الخط](/slides/ar/net/font-substitution/).
{{% /alert %}}

### **معالجة الخطوط التي لا تمتلك نوعًا غامقًا مخصصًا**

يمكن للعرض تطبيق تنسيق غامق للنص حتى عندما لا يحتوي الخط على نوع غامق مخصص. يمكن للنص أن يبدو غامقًا عبر التجسيد الصناعي، الذي يزيد من سمك الحروف العادية. عندما يبدو هذا النص ثقيلًا جدًا أو يختلف عن المظهر المقصود في PDF، جرّب ضبط [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) إلى `true`. هذا الخيار يُظهر النص المتأثر كصورة نقطية أثناء تصدير PDF ويمكن أن يحسن مظهره لبعض الخطوط. قيمته الافتراضية هي `false`.

يتضمن العرض التجريبي صندوقي نص: أحدهما بنص عادي والآخر بنص غامق مطبق على نفس الخط الذي لا يمتلك نوعًا غامقًا مخصصًا. يقوم المثال التالي بتحميل العرض، وتفعيل تحويل الخطوط غير المدعومة إلى صورة نقطية، وتصديره إلى PDF:

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

تعرض المعاينات التالية الناتج مع إلغاء تفعيل الخيار والناتج مع تفعيله. في هذا المثال، يكون النص الغامق بخطوط أكثر سمكًا عندما يكون الخيار معطلًا. عند تفعيل الخيار، تصبح خطوطه أخف؛ النص العادي يبقى دون تغيير. قارن النتائج قبل اختيار الإعداد لعرضك.

| الخيار معطل (`false`، الافتراضي) | الخيار مُفعَّل (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

في هذا المثال، يؤدي تفعيل الخيار إلى تحويل النص الغامق فقط إلى صورة نقطية: لا يمكن تحديده أو نسخه أو البحث فيه كنص دون OCR، وتظهر حوافه أكثر نعومة عند التكبير 800٪. يبقى النص العادي قابلًا للبحث. عندما يكون الخيار معطلًا، يظل كلا النصين نصًا.

هذا الخيار يحول النص المنسق كغامق إلى صورة نقطية عندما لا يمتلك الخط نوعًا غامقًا مخصصًا. [استبدال الخط](/slides/ar/net/font-substitution/) يختار بدلاً من ذلك خطًا آخر عندما يكون الأصلي غير متاح.

## **تحويل الشرائح المحددة من PowerPoint إلى PDF**

يقوم المثال التالي بتصدير الشريحتين 1 و 3 من عرض تقديمي إلى PDF. أرقام الشرائح في هذا المصفوفة تبدأ من 1، ويجب أن يحتوي العرض المدخل على ثلاث شرائح على الأقل.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

يقوم المثال التالي بنسخ الشريحة الأولى من عرض تقديمي إلى عرض تقديمي جديد بحجم شريحة 612 × 792 نقطة (8.5 × 11 بوصة). يقوم بضبط محتوى الشريحة لملاءمته ثم يصدر الشريحة الوحيدة إلى PDF.

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

## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشريحة**

يقوم المثال التالي بتصدير عرض تقديمي إلى PDF، مع وضع ملاحظات المتحدث لكل شريحة تحت الشريحة. استخدم عرضًا يحتوي على ملاحظات المتحدث لرؤية النتيجة.

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

## **معايير الوصول والامتثال لملفات PDF**

يتيح لك Aspose.Slides استخدام إجراء تحويل يتوافق مع [إرشادات محتوى الويب للوصول (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

يعرض هذا الكود C# عملية تحويل PowerPoint إلى PDF تنتج عدة ملفات PDF استنادًا إلى معايير امتثال مختلفة:

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
يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ ملفات شائعة. يمكنك إجراء التحويلات [PDF إلى HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/net/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). تدعم عمليات تحويل PDF إلى صيغ متخصصة —[PDF إلى SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)— كذلك.
{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسومات المعقدة مثل SmartArt والرسوم البيانية والصيغ كشكل واحد. لا يتم الحفاظ على عناصر المسار الفردية كمحتوى منفصل وقد تُعلم كقطع فنية؛ يتم توفير نص بديل فقط للشكل الكامل.

## **الأسئلة المتكررة**

**هل يمكنني تحويل ملفات PowerPoint متعددة إلى PDF دفعة واحدة؟**

نعم، يدعم Aspose.Slides التحويل الجماعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك تكرار الملفات وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF المحول بكلمة مرور؟**

نعم. استخدم الفئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لتعيين كلمة مرور وتعريف أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

اضبط الخاصية [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) في الفئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) إلى `true` لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة صورة عالية في PDF؟**

نعم، يمكنك التحكم في جودة الصورة عن طريق ضبط خصائص مثل [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) و[SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) في الفئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، يتيح لك Aspose.Slides تصدير ملفات PDF متوافقة مع معايير مختلفة، بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، مما يضمن أن مستنداتك تلبي متطلبات الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides لـ .NET](/slides/ar/net/)
- [مرجع API Aspose.Slides لـ .NET](https://reference.aspose.com/slides/net/)
- [محولات Aspose مجانية عبر الإنترنت](https://products.aspose.app/slides/conversion)

الميزة ذات الصلة: [تصدير العروض إلى PDF](/slides/ar/features/pdf-export/).