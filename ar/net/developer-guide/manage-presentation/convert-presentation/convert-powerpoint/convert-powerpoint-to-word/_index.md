---
title: تحويل PowerPoint إلى Word
type: docs
weight: 110
url: /ar/net/convert-powerpoint-to-word/
keywords:
- تحويل PowerPoint
- PPT
- PPTX
- عرض تقديمي
- Word
- DOCX
- DOC
- PPTX إلى DOCX
- PPT إلى DOC
- PPTX إلى DOC
- PPT إلى DOCX
- C#
- Csharp
- .NET
- Aspose.Slides
description: "تحويل عرض PowerPoint إلى Word باستخدام C# أو .NET"
---

إذا كنت تخطط لاستخدام محتوى نصي أو معلومات من عرض تقديمي (PPT أو PPTX) بطرق جديدة، فقد تستفيد من تحويل العرض التقديمي إلى Word (DOC أو DOCX).

* عند مقارنته ببرنامج Microsoft PowerPoint، فإن تطبيق Microsoft Word مجهز بشكل أفضل بالأدوات أو الوظائف الخاصة بالمحتوى.
* إلى جانب وظائف التحرير في Word، قد تستفيد أيضًا من ميزات تحسين التعاون والطباعة والمشاركة.

{{% alert color="primary" %}} 

قد ترغب في تجربة [**محول العرض التقديمي إلى Word عبر الإنترنت**](https://products.aspose.app/slides/conversion/ppt-to-word) لترى ما يمكنك كسبه من العمل مع المحتوى النصي من الشرائح.

{{% /alert %}} 

### **Aspose.Slides و Aspose.Words**

لتحويل ملف PowerPoint (PPTX أو PPT) إلى Word (DOCX أو DOCX)، تحتاج إلى كل من [Aspose.Slides لـ .NET](https://products.aspose.com/slides/net/) و [Aspose.Words لـ .NET](https://products.aspose.com/words/net/).

كمكتبة API مستقلة، توفر [Aspose.Slides](https://products.aspose.app/slides) لـ .NET وظائف تتيح لك استخراج النصوص من العروض التقديمية.

[Aspose.Words](https://docs.aspose.com/words/net/) هو API متقدم لمعالجة المستندات يسمح للتطبيقات بإنشاء وتعديل وتحويل وتجسيد و طباعة الملفات، وأداء مهام أخرى مع المستندات بدون استخدام Microsoft Word.

## **تحويل PowerPoint إلى Word**

1. أضف هذه المساحات الاسمية إلى ملف program.cs الخاص بك:

```c#
using Aspose.Slides;
using Aspose.Words;
using System.IO;
```

2. استخدم هذه الشيفرة البرمجية لتحويل PowerPoint إلى Word:

```c#
using var presentation = new Presentation("sample.pptx");

var doc = new Document();
var builder = new DocumentBuilder(doc);

foreach (var slide in presentation.Slides)
{
    // يولد صورة الشريحة ويحفظها في دفق الذاكرة
    using var image = slide.GetImage(1, 1);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray());

    // يدرج نصوص الشريحة
    foreach (var shape in slide.Shapes)
    {
        if (shape is AutoShape autoShape)
        {
            builder.Writeln(autoShape.TextFrame.Text);
        }
    }

    builder.InsertBreak(BreakType.PageBreak);
}

doc.Save("output.docx");
```