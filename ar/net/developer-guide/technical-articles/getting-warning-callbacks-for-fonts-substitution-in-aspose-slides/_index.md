---
title: الحصول على ردود التحذير لاستبدال الخطوط في .NET
type: docs
weight: 120
url: /ar/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- استدعاء التحذير
- استبدال الخط
- عملية العرض
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعرّف على كيفية الحصول على ردود التحذير لاستبدال الخطوط في Aspose.Slides for .NET وعرض عروض PowerPoint وOpenDocument بدقة."
---

## **نظرة عامة**

يتيح لك Aspose.Slides for .NET استلام ردود تحذير لاستبدال الخطوط عندما لا يتوفر الخط المطلوب على الجهاز أثناء عملية العرض. تساعدك هذه الردود في تشخيص المشكلات المتعلقة بالخطوط المفقودة أو غير المتاحة.

## **تمكين ردود التحذير**

يوفر Aspose.Slides for .NET واجهات برمجة تطبيقات بسيطة لاستلام ردود التحذير عند عرض شرائح العروض التقديمية. اتبع الخطوات التالية لتكوين ردود التحذير:

1. إنشاء فئة رد استدعاء مخصصة تُنفّذ واجهة [IWarningCallback](https://reference.aspose.com/slides/net/aspose.slides.warnings/iwarningcallback/) لمعالجة التحذيرات.
1. تعيين رد التحذير باستخدام فئات الخيارات مثل [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/)، [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/)، وغيرها.
1. تحميل عرض تقديمي يستخدم خطًا غير متوفر على الجهاز المستهدف.
1. إنشاء صورة مصغرة للشريحة أو تصدير العرض التقديمي لملاحظة النتيجة.

**فئة رد التحذير المخصصة:**
```c#
class FontWarningHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss)
        {
            Console.WriteLine(warning.Description);
        }

        return ReturnAction.Continue;
    }
}

// مثال على المخرجات:
//
// سيتم استبدال الخط من XYZ إلى {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```


**إنشاء صورة مصغرة للشريحة:**
```c#
// إعداد استدعاء تحذير لمعالجة التحذيرات المتعلقة بالخطوط أثناء عرض الشريحة.
var options = new RenderingOptions();
options.WarningCallback = new FontWarningHandler();

// تحميل العرض التقديمي من مسار الملف المحدد.
using var presentation = new Presentation("sample.pptx");

// Generate a thumbnail image for each slide in the presentation.
foreach (var slide in presentation.Slides)
{
    // الحصول على صورة مصغرة للشريحة باستخدام خيارات العرض المحددة.
    using var image = slide.GetImage(options);
    // ...
}
```


**تصدير إلى تنسيق PDF:**
```c#
// إعداد استدعاء تحذير لمعالجة التحذيرات المتعلقة بالخطوط أثناء تصدير PDF.
var options = new PdfOptions();
options.WarningCallback = new FontWarningHandler();

// تحميل العرض التقديمي من مسار الملف المحدد.
using var presentation = new Presentation("sample.pptx");

// تصدير العرض التقديمي كملف PDF.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Pdf, options);
// ...
```


**تصدير إلى تنسيق HTML:**
```c#
// إعداد استدعاء تحذير لمعالجة التحذيرات المتعلقة بالخطوط أثناء تصدير HTML.
var options = new HtmlOptions();
options.WarningCallback = new FontWarningHandler();

// تحميل العرض التقديمي من مسار الملف المحدد.
using var presentation = new Presentation("sample.pptx");

// تصدير العرض التقديمي بصيغة HTML.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Html, options);
// ...
```
