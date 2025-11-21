---
title: تحويل عروض PowerPoint في وضع النشرة في .NET
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
description: "تحويل العروض التقديمية إلى نشرات في .NET. تعيين عدد الشرائح لكل صفحة، الاحتفاظ بالملاحظات، تصدير إلى PDF أو صور باستخدام Aspose.Slides، مع مثال كود C#. جربه مجانًا."
---

## **تصدير وضع النشرة**

توفر Aspose.Slides إمكانية تحويل العروض التقديمية إلى تنسيقات متعددة، بما في ذلك إنشاء نشرات للطباعة في وضع النشرة. يتيح لك هذا الوضع تكوين كيفية ظهور عدة شرائح على صفحة واحدة، مما يجعله مفيدًا للمؤتمرات والندوات والفعاليات الأخرى. يمكنك تمكين هذا الوضع عن طريق تعيين خاصية `SlidesLayoutOptions` في واجهات [IPdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ihtmloptions/), و[ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) .

لتكوين وضع النشرة، استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/handoutlayoutingoptions/) ، الذي يحدد عدد الشرائح التي تُوضع على صفحة واحدة وغيرها من معلمات العرض.

في الأسفل مثال على الشيفرة يُظهر كيفية تحويل عرض تقديمي إلى PDF في وضع النشرة.
```c#
// تحميل عرض تقديمي.
using var presentation = new Presentation("sample.pptx");

// Set the export options.
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

// Export the presentation to PDF with the chosen layout.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```


{{% alert color="warning" %}} 
ضع في اعتبارك أن خاصية `SlidesLayoutOptions` متاحة فقط لبعض تنسيقات الإخراج، مثل PDF، HTML، TIFF، وعند التصيير كصور.
{{% /alert %}} 

## **الأسئلة المتكررة**

**ما هو الحد الأقصى لعدد المصغرات الشرائحية في الصفحة في وضع النشرة؟**

تدعم Aspose.Slides [الإعدادات المسبقة](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) حتى 9 مصغرات في الصفحة مع ترتيب أفقي أو عمودي: 1، 2، 3، 4 (أفقي/عمودي)، 6 (أفقي/عمودي)، و9 (أفقي/عمودي).

**هل يمكنني تعريف شبكة مخصصة، مثل 5 أو 8 شرائح في الصفحة؟**

لا. يتم التحكم في عدد وترتيب المصغرات بصرامة بواسطة تعداد [HandoutType](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/)؛ ولا يدعم التخطيطات العشوائية.

**هل يمكنني تضمين الشرائح المخفية في مخرجات النشرة؟**

نعم. فعّل خيار `ShowHiddenSlides` في إعدادات التصدير للتنسيق المستهدف، مثل [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/)، أو [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/).