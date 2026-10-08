---
title: "تحويل PPT و PPTX إلى PDF في .NET [تشمل الميزات المتقدمة]"
linktitle: "PowerPoint إلى PDF"
type: docs
weight: 40
url: /ar/net/convert-powerpoint-to-pdf/
keywords:
- "تحويل PowerPoint"
- "تحويل العرض"
- "PowerPoint إلى PDF"
- "العرض إلى PDF"
- "PPT إلى PDF"
- "تحويل PPT إلى PDF"
- "PPTX إلى PDF"
- "تحويل PPTX إلى PDF"
- "حفظ PowerPoint كـ PDF"
- "حفظ PPT كـ PDF"
- "حفظ PPTX كـ PDF"
- "تصدير PPT إلى PDF"
- "تصدير PPTX إلى PDF"
- "مرفق"
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في .NET باستخدام Aspose.Slides، مع أمثلة كود C# سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى تنسيق PDF باستخدام C# يقدم عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وإدراج الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، اختيار شرائح محددة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويل PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالتنسيقات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF، مرّر اسم الملف كوسيط إلى فئة [العرض](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة [حفظ](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). فئة [العرض](https://reference.aspose.com/slides/net/aspose.slides/presentation/) تكشف عن طريقة [حفظ](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{% alert color="info" title="Note" %}}

يضيف Aspose.Slides for .NET معلومات واجهة برمجة التطبيقات ورقم الإصدار إلى المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، يملأ Aspose.Slides حقل **Application** بـ "*Aspose.Slides*" وحقل **PDF Producer** بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك إرشاد Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

يسمح Aspose.Slides لك بتحويل:

* العروض بالكامل إلى PDF
* شرائح محددة من عرض إلى PDF

يصدّر Aspose.Slides العروض إلى PDF، مما يضمن أن PDFs الناتجة تتطابق بشكل وثيق مع العروض الأصلية. يتم عرض العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

* الصور
* صناديق النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات الصفحات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المزوّد إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

المثال التالي يحمّل عرضًا ويحفظ جميع الشرائح المرئية إلى PDF باستخدام إعدادات التصدير الافتراضية.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}

توفر Aspose أداة مجانية على الإنترنت [**محول PowerPoint إلى PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) تُظهر عملية تحويل العرض إلى PDF. يمكنك تجربة هذا المحول لتطبيق عملي للخطوات الموضحة هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة—خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—تتيح لك تخصيص PDF الناتج، قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، تحديد طريقة معالجة ملفات الميتافايل، ضبط مستوى ضغط النص، تكوين DPI للصور، وغير ذلك.

المثال التالي يصدر عرضًا إلى PDF 1.5 مع جودة JPEG مضبوطة على 90، دقة الصورة 300 DPI، حفظ ملفات الميتافايل كـ PNG، وضغط نص Flate.

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

### **حفظ ملفات OLE المضمنة كمرفقات PDF**

إذا كان العرض يحتوي على مصنف Excel مضمّن، قد ترغب في تمكين مستلمي PDF من الوصول إلى بيانات المصنف بالإضافة إلى عرض الشرائح. اضبط [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) على `true` لحفظ ملفات OLE المضمنة كمرفقات في PDF الناتج.

القيمة الافتراضية هي `false`: يتم عرض صورة معاينة أو أيقونة كائن OLE على صفحة PDF، لكن الملف المضمّن غير متضمن كمرفق. ضبط الخيار على `true` يضيف بيانات الملف كذلك. تبقى المعاينة تمثيلًا بصريًا؛ المرفق يتيح للمستلمين فتح أو حفظ الملف المضمّن بشكل منفصل. لا يتحول كائن OLE إلى ورقة عمل Excel تفاعلية على صفحة PDF.

المثال التالي يحمّل عرضًا يحتوي بالفعل على مصنف Excel مضمّن ويصدّره إلى PDF مع إرفاق المصنف.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

للتحقق من النتيجة:

1. افتح PDF المصدّر في عارض يدعم المرفقات، مثل Adobe Acrobat Reader.
2. افتح لوحة **المرفقات** في العارض وابحث عن المصنف المضمّن.
3. احفظ المرفق وافتحه في Excel لتفحص البيانات، أو افتحه مباشرة إذا سمح العارض بذلك. المعاينة على صفحة PDF منفصلة عن المرفق.

{{% alert color="info" title="Note" %}}

معايير PDF/A تفرض قيودًا على المرفقات: PDF/A-1 يحظر الملفات المضمّنة، PDF/A-2 يسمح فقط بمرفقات PDF/A، وPDF/A-3 يسمح بأنواع ملفات أخرى بما فيها مصنفات Excel. هذه متطلبات المعايير، ليست قيودًا خاصة بـ Aspose.Slides. يستخدم هذا المثال إعداد الامتثال PDF الافتراضي ولا يوضح تصدير PDF/A.

{{% /alert %}}

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام خاصية [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) من فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

المثال التالي يصدر عرضًا إلى PDF، مضمنًا أي شرائح مخفية.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

المثال التالي يصدر عرضًا إلى PDF يتطلب كلمة المرور `password` للفتح. تسمح أذونات الوصول بالطباعة، بما فيها الطباعة عالية الجودة.

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

يوفر Aspose.Slides الخاصية [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)، مما يمكنك من اكتشاف استبدال الخطوط أثناء عملية تحويل العرض إلى PDF.

المثال التالي يصدر عرضًا إلى PDF ويطبع تحذيرات استبدال الخطوط إلى وحدة التحكم. يتم طباعة تحذير فقط عندما يتم استبدال خط غير متوفر أثناء التصدير.

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

لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/net/font-substitution/).

{{% /alert %}} 

### **معالجة الخطوط التي لا تحتوي على نمط غامق مخصص**

يمكن للعرض تطبيق تنسيق غامق على النص حتى وإن لم يكن للخط نمط غامق مخصَّص. لا يزال النص يظهر غامقًا عبر "الغامق الصناعي"، الذي يزيد من سمك الحروف العادية. عندما يبدو النص ثقيلًا جدًا أو يختلف عن الشكل المقصود في PDF، جرّب ضبط [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) إلى `true`. هذا الخيار يرسم النص المتأثر كصورة نقطية أثناء تصدير PDF ويمكن أن يحسّن مظهره لبعض الخطوط. القيمة الافتراضية هي `false`.

العرض العيني يحتوي على صندوقي نص: أحدهما نص عادي والآخر نص غامق مطبق على نفس الخط الذي لا يملك نمطًا غامقًا مخصصًا. المثال التالي يحمّل العرض، يفعّل تحويل الأنماط غير المدعومة إلى نقطية، ويصدّره إلى PDF:

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

المعاينات التالية تُظهر النتيجة مع تعطيل الخيار والنتيجة مع تفعيل الخيار. في هذا المثال، يكون للخط الغامق ضربات أثقل عندما يكون الخيار معطَّل. عند تفعيل الخيار، تكون الضربات أخف؛ النص العادي يبقى دون تغيير. قارن النتائج قبل اختيار الإعداد لعرضك.

| الخيار معطل (`false`, القيمة الافتراضية) | الخيار مفعَّل (`true`) |
|---|---|
| ![PDF مع تعطيل تحويل نمط الخط غير المدعوم إلى نقطية](unsupported-bold-disabled.png) | ![PDF مع تمكين تحويل نمط الخط غير المدعوم إلى نقطية](unsupported-bold-enabled.png) |

في هذا المثال، يؤدي تفعيل الخيار إلى تحويل النص الغامق فقط إلى صورة نقطية: لا يمكن تحديده أو نسخه أو البحث فيه كنص دون OCR، وتظهر حوافه أنعم عند تقريب 800%. يبقى النص العادي قابلًا للبحث. مع تعطيل الخيار، يظل كلا السلسلتين نصًا.

هذا الخيار يحول النص المهيأ كغامق عندما لا يمتلك الخط نمط غامق مخصص. [Font substitution](/slides/ar/net/font-substitution/) يختار بدلاً من ذلك خطًا آخر عندما لا يتوفر الخط الأصلي.

## **تحويل شرائح محددة من PowerPoint إلى PDF**

المثال التالي يصدر الشرائح 1 و3 من عرض إلى PDF. أرقام الشرائح في هذا المصفوفة تبدأ من الواحد، ويجب أن يحتوي العرض المدخل على ثلاث شرائح على الأقل.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

المثال التالي ينسخ الشريحة الأولى من عرض إلى عرض جديد بحجم شريحة 612 × 792 نقطة (8.5 × 11 بوصة). يضبط محتوى الشريحة ليتناسب ويصدّر الشريحة الوحيدة إلى PDF.

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

المثال التالي يصدر عرضًا إلى PDF، موضعًا ملاحظات المتحدث لكل شريحة أسفل الشريحة. استخدم عرضًا يحتوي على ملاحظات المتحدث لرؤية النتيجة.

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

## **معايير الوصول والامتثال للـ PDF**

يسمح Aspose.Slides لك باستخدام إجراء تحويل يتوافق مع [إرشادات الوصول إلى محتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال هذه: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

يعرض هذا الكود C# عملية تحويل PowerPoint إلى PDF تُنتج عدة ملفات PDF بناءً على معايير امتثال مختلفة:

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

يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى تنسيقات ملفات شائعة. يمكنك تنفيذ تحولات [PDF إلى HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/net/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). تدعم أيضًا عمليات تحويل PDF إلى تنسيقات متخصصة—[PDF إلى SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—.

{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسوم البيانية المعقدة مثل SmartArt، المخططات، والصيغ كشكل واحد. لا يتم حفظ عناصر المسار الفردية كمحتوى منفصل وقد تُعلَّم كمواد فنية؛ يُقدَّم النص البديل فقط للشكل بأكمله.

## **الأسئلة الشائعة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعيًا؟**

نعم، يدعم Aspose.Slides التحويل الدفعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنكIterate عبر ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF الناتج بكلمة مرور؟**

نعم. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لتعيين كلمة مرور وتعريف أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

اضبط خاصية [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) في فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) على `true` لتضمين الشرائح المخفية في PDF الناتج.

**هل يستطيع Aspose.Slides الحفاظ على جودة الصور العالية في PDF؟**

نعم، يمكنك التحكم في جودة الصور بضبط خصائص مثل [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) و[.SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) في فئة [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) لضمان صور ذات جودة عالية في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، يتيح Aspose.Slides لك تصدير ملفات PDF تتوافق مع معايير مختلفة، بما فيها PDF/A1a، PDF/A1b، وPDF/UA، مما يضمن أن مستنداتك تلبي متطلبات الوصول والأرشفة.

## **موارد إضافية**

- [Aspose.Slides for .NET Documentation](/slides/ar/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)