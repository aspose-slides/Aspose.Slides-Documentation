---
title: تحويل عروض PowerPoint إلى وضع النشرة في .NET
linktitle: وضع النشرة
type: docs
weight: 150
url: /ar/net/convert-powerpoint-in-Handout-mode/
keywords:
- تحويل PowerPoint
- تحويل العرض
- وضع النشرة
- نشرة
- PowerPoint
- عرض
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "تحويل العروض إلى نشرات في .NET. ضبط عدد الشرائح في الصفحة، الحفاظ على الملاحظات، التصدير إلى PDF أو صور باستخدام Aspose.Slides، مع مثال كود C#. جرّبه مجانًا."
---

## **تصدير وضع النشرة**

توفر Aspose.Slides القدرة على تحويل العروض التقديمية إلى صيغ مختلفة، بما في ذلك إنشاء نشرات للطباعة في وضع النشرة. يتيح لك هذا الوضع تكوين كيفية ظهور عدة شرائح على صفحة واحدة، مما يجعله مفيدًا للمؤتمرات والندوات وغيرها من الفعاليات. يمكنك تمكين هذا الوضع عن طريق ضبط خاصية `SlidesLayoutOptions` في واجهات [IPdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ihtmloptions/), و[ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/).

لتكوين وضع النشرة، استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/handoutlayoutingoptions/) الذي يحدد عدد الشرائح التي توضع على صفحة واحدة وغيرها من معلمات العرض.

فيما يلي مثال على الشيفرة يوضح كيفية تحويل عرض تقديمي إلى PDF في وضع النشرة.
```c#
// تحميل عرض تقديمي.
using var presentation = new Presentation("sample.pptx");

// Set the export options.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 شرائح على صفحة واحدة أفقياً
        PrintSlideNumbers = true,                   // طباعة أرقام الشرائح
        PrintFrameSlide = true,                     // طباعة إطار حول الشرائح
        PrintComments = false                       // لا توجد تعليقات
    }
};

// Export the presentation to PDF with the chosen layout.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```


{{% alert color="warning" %}} 
احرص على أن خاصية `SlidesLayoutOptions` متاحة فقط لبعض صيغ الإخراج، مثل PDF وHTML وTIFF، وعند التحويل إلى صور.
{{% /alert %}} 

## **الأسئلة الشائعة**

**ما هو الحد الأقصى لعدد معاينات الشرائح في كل صفحة في وضع النشرة؟**

يدعم Aspose.Slides [الإعدادات المسبقة](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) حتى 9 معاينات لكل صفحة مع ترتيب أفقي أو عمودي: 1، 2، 3، 4 (أفقي/عمودي)، 6 (أفقي/عمودي)، و9 (أفقي/عمودي).

**هل يمكنني تحديد شبكة مخصصة، مثل 5 أو 8 شرائح لكل صفحة؟**

لا. يتم التحكم في عدد وترتيب المعاينات بدقة عبر تعداد [HandoutType](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/)، ولا تُدعم التخطيطات العشوائية.

**هل يمكنني تضمين الشرائح المخفية في مخرجات النشرة؟**

نعم. قم بتمكين خيار `ShowHiddenSlides` في إعدادات التصدير للصيغة المستهدفة، مثل [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/), أو [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/).