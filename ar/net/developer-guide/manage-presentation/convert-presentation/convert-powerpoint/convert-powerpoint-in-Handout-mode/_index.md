---
title: تحويل العروض التقديمية إلى وضع النشرة في C#
type: docs
weight: 150
url: /ar/net/convert-powerpoint-in-Handout-mode/
keywords:
- تحويل PowerPoint
- وضع النشرة
- نشرة
- PowerPoint
- PPT
- PPTX
- عرض تقديمي
- C#
- Csharp
- .NET
- Aspose.Slides
description: "تحويل العروض التقديمية إلى وضع النشرة في C#"
---

## **تصدير وضع النشرات**

تتيح Aspose.Slides إمكانية تحويل العروض التقديمية إلى صيغ متعددة، بما في ذلك إنشاء نشرة للطباعة في وضع النشرة. يسمح لك هذا الوضع بتكوين كيفية ظهور عدة شرائح على صفحة واحدة، مما يجعله مفيدًا للمؤتمرات والندوات وغيرها من الفعاليات. يمكنك تفعيل هذا الوضع عن طريق تعيين خاصية `SlidesLayoutOptions` في الواجهات [IPdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ihtmloptions/), و[ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) .

لتكوين وضع النشرة، استخدم الكائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/handoutlayoutingoptions/) ، الذي يحدد عدد الشرائح التي توضع على صفحة واحدة وغيرها من معلمات العرض.

فيما يلي مثال على الشفرة يُظهر كيفية تحويل عرض تقديمي إلى PDF في وضع النشرة.
```c#
// تحميل عرض تقديمي.
using var presentation = new Presentation("sample.pptx");

// Set the export options.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 شرائح في صفحة واحدة أفقياً
        PrintSlideNumbers = true,                   // طباعة أرقام الشرائح
        PrintFrameSlide = true,                     // طباعة إطار حول الشرائح
        PrintComments = false                       // بدون تعليقات
    }
};

// Export the presentation to PDF with the chosen layout.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```


{{% alert color="warning" %}} 
ضع في اعتبارك أن خاصية `SlidesLayoutOptions` متاحة فقط لبعض صيغ الإخراج، مثل PDF وHTML وTIFF، وعند التصيير كصور.
{{% /alert %}} 

## **الأسئلة الشائعة**

**ما هو الحد الأقصى لعدد صور المصغرات للشرائح لكل صفحة في وضع النشرة؟**

تدعم Aspose.Slides [الإعدادات المسبقة](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) حتى 9 مصغرات لكل صفحة بترتيب أفقي أو عمودي: 1، 2، 3، 4 (أفقي/عمودي)، 6 (أفقي/عمودي)، و9 (أفقي/عمودي).

**هل يمكنني تعريف شبكة مخصصة، مثل 5 أو 8 شرائح لكل صفحة؟**

لا. يتم التحكم في عدد وترتيب المصغرات بدقة بواسطة تعداد [HandoutType](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) . لا يدعم التخطيطات العشوائية.

**هل يمكنني تضمين الشرائح المخفية في ناتج النشرة؟**

نعم. فعّل خيار `ShowHiddenSlides` في إعدادات التصدير للصيغة المستهدفة، مثل [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/), أو [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/).