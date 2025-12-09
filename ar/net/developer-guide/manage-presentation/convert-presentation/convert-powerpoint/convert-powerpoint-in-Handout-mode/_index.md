---
title: تحويل عروض PowerPoint التقديمية إلى وضع النشرة في .NET
linktitle: وضع النشرة
type: docs
weight: 150
url: /ar/net/convert-powerpoint-in-Handout-mode/
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
description: "تحويل العروض التقديمية إلى نشرات في .NET. ضبط عدد الشرائح في الصفحة، الحفاظ على الملاحظات، التصدير إلى PDF أو صور باستخدام Aspose.Slides، مع عينة كود C#. جرّبها مجانًا."
---

## **تصدير وضع النشرة**

توفر Aspose.Slides القدرة على تحويل العروض التقديمية إلى تنسيقات متعددة، بما في ذلك إنشاء نماذج للطباعة في وضع النشرة. يتيح لك هذا الوضع تكوين كيفية ظهور عدة شرائح على صفحة واحدة، مما يجعله مفيدًا للمؤتمرات والندوات وغيرها من الفعاليات. يمكنك تمكين هذا الوضع عن طريق تعيين خاصية `SlidesLayoutOptions` في واجهات [IPdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ihtmloptions/), و[ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) .

لتكوين وضع النشرة، استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/handoutlayoutingoptions/) ، الذي يحدد عدد الشرائح الموضوعة على صفحة واحدة وغيرها من معلمات العرض.

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
        PrintComments = false                       // بدون تعليقات
    }
};

// Export the presentation to PDF with the chosen layout.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```


{{% alert color="warning" %}} 
ضع في اعتبارك أن خاصية `SlidesLayoutOptions` متاحة فقط لبعض تنسيقات الإخراج، مثل PDF وHTML وTIFF، وأثناء التحويل إلى صور.
{{% /alert %}} 

## **الأسئلة الشائعة**

**ما هو الحد الأقصى لعدد المصغرات الشرائح في كل صفحة في وضع النشرة؟**

يدعم Aspose.Slides [الإعدادات المسبقة](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) حتى 9 مصغرات لكل صفحة مع ترتيب أفقي أو رأسي: 1، 2، 3، 4 (أفقي/رأسي)، 6 (أفقي/رأسي)، و9 (أفقي/رأسي).

**هل يمكنني تعريف شبكة مخصصة، مثل 5 أو 8 شرائح لكل صفحة؟**

لا. يتم التحكم في عدد وترتيب المصغرات بدقة عبر تعداد [HandoutType](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) ، ولا تُدعم التخطيطات العشوائية.

**هل يمكنني تضمين الشرائح المخفية في مخرجات النشرة؟**

نعم. قم بتمكين الخيار `ShowHiddenSlides` في إعدادات التصدير للتنسيق المستهدف، مثل [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/), أو [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/).