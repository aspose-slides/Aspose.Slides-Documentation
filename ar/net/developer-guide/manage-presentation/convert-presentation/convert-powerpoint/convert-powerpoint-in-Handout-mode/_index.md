---
title: تحويل عروض PowerPoint التقديمية في وضع النشرة في .NET
linktitle: وضع النشرة
type: docs
weight: 150
url: /ar/net/convert-powerpoint-in-handout-mode/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- وضع النشرة
- نشرة
- PowerPoint
- عرض تقديمي
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "تحويل العروض التقديمية إلى نشرات في .NET. ضبط عدد الشرائح لكل صفحة، الاحتفاظ بالملاحظات، التصدير إلى PDF أو صور باستخدام Aspose.Slides، مع مثال كود C#. جرّبه مجانًا."
---
## **المقدمة**

Aspose.Slides يتيح لك تحويل العروض التقديمية إلى صيغ إخراج تدعم وضع النشرة. في هذا الوضع، يتم ترتيب عدة شرائح على صفحة واحدة، وهو ما يكون مفيدًا لطباعة مواد العروض للموتمرات والندوات وغيرها من الفعاليات المماثلة.

يتم تكوين وضع النشرة من خلال الخاصية `SlidesLayoutOptions`، المتاحة في [IPdfOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/ipdfoptions/)، [IRenderingOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/irenderingoptions/)، [IHtmlOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/ihtmloptions/)، و[ITiffOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/itiffoptions/). لتحديد تخطيط النشرة، استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/handoutlayoutingoptions/).

لتحديد أبعاد صفحة النشرة واتجاهها قبل التصدير، راجع [حجم صفحة الملاحظات](/slides/ar/net/notes-size/).

## **تصدير وضع النشرة**

لتصدير عرض تقديمي في وضع النشرة، قم بتعيين الخاصية `SlidesLayoutOptions` لخيارات التصدير المستهدفة وعيّن كائنًا من نوع [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/handoutlayoutingoptions/) يحدد عدد الشرائح لكل صفحة ومعلمات العرض ذات الصلة.

فيما يلي مثال على التعليمات البرمجية يوضح كيفية تحويل عرض تقديمي إلى PDF في وضع النشرة.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// تحميل عرض تقديمي.
using var presentation = new Presentation("sample.pptx");

// ضبط خيارات التصدير.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 شرائح على صفحة واحدة أفقيًا
        PrintSlideNumbers = true,                   // طباعة أرقام الشرائح
        PrintFrameSlide = true,                     // طباعة إطار حول الشرائح
        PrintComments = false                       // لا تعليقات
    }
};

// تصدير العرض التقديمي إلى PDF باستخدام التخطيط المختار.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 

تذكر أن الخاصية `SlidesLayoutOptions` متاحة فقط لبعض صيغ الإخراج، مثل PDF وHTML وTIFF، وعند التصدير كصور.

{{% /alert %}} 

## **الأسئلة المتكررة**

### ما هو الحد الأقصى لعدد صور الشرائح المصغرة لكل صفحة في وضع النشرة؟

Aspose.Slides يدعم [الإعدادات المسبقة](https://reference.aspose.com/slides/ar/net/aspose.slides.export/handouttype/) حتى 9 صور مصغرة لكل صفحة بترتيب أفقي أو عمودي: 1، 2، 3، 4 (أفقي/عمودي)، 6 (أفقي/عمودي)، و9 (أفقي/عمودي).

### هل يمكنني تعريف شبكة مخصصة، مثل 5 أو 8 شرائح لكل صفحة؟

لا. يتم التحكم في عدد وترتيب الصور المصغرة بدقة من خلال تعداد [HandoutType](https://reference.aspose.com/slides/ar/net/aspose.slides.export/handouttype/)؛ لا تدعم التخطيطات العشوائية.

### هل يمكن تضمين الشرائح المخفية في ناتج النشرة؟

نعم. فعّل الخيار `ShowHiddenSlides` في إعدادات التصدير للصيغة المستهدفة، مثل [PdfOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/htmloptions/)، أو [TiffOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/).