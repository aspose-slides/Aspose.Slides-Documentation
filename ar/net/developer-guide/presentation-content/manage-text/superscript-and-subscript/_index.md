---
title: النص العلوي والنص السلفي
type: docs
weight: 80
url: /net/superscript-and-subscript/
keywords: "نص علوي, نص سلفي, إضافة نص علوي, إضافة نص سلفي, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "إضافة نص علوي ونص سلفي إلى عروض PowerPoint في C# أو .NET"
---

## **إدارة النص العلوي والنص السلفي**
يمكنك إضافة نص علوي ونص سلفي داخل أي جزء من الفقرة. لإضافة نص علوي أو نص سلفي في إطار نص Aspose.Slides، يجب استخدام **خاصية الإزاحة** في فئة PortionFormat.

تُرجع هذه الخاصية أو تضبط النص العلوي أو النص السلفي (قيمة من -100% (نص سلفي) إلى 100% (نص علوي). على سبيل المثال:

- أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- احصل على مرجع لشريحة باستخدام فهرسها.
- أضف شكل تلقائي من نوع مستطيل إلى الشريحة.
- الوصول إلى ITextFrame المرتبط بـ IAutoShape.
- مسح الفقرات الموجودة.
- أنشئ كائن فقرة جديد للحفاظ على النص العلوي وأضفه إلى مجموعة IParagraphs من ITextFrame.
- أنشئ كائن جزء جديد.
- اضبط خاصية الإزاحة للجزء بين 0 و100 لإضافة النص العلوي. (0 تعني عدم وجود نص علوي).
- اضبط بعض النصوص للجزء ثم أضف ذلك إلى مجموعة أجزاء الفقرة.
- أنشئ كائن فقرة جديد للحفاظ على النص السلفي وأضفه إلى مجموعة IParagraphs من ITextFrame.
- أنشئ كائن جزء جديد.
- اضبط خاصية الإزاحة للجزء بين 0 و-100 لإضافة النص السلفي. (0 تعني عدم وجود نص سلفي).
- اضبط بعض النصوص للجزء ثم أضف ذلك إلى مجموعة أجزاء الفقرة.
- احفظ العرض كملف PPTX.

تنفيذ الخطوات المذكورة أعلاه موضح أدناه.

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    // الحصول على الشريحة
    ISlide slide = presentation.Slides[0];

    // إنشاء مربع نص
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;
    textFrame.Paragraphs.Clear();

    // إنشاء فقرة للنص العلوي
    IParagraph superPar = new Paragraph();

    // إنشاء جزء مع نص عادي
    IPortion portion1 = new Portion();
    portion1.Text = "عنوان الشريحة";
    superPar.Portions.Add(portion1);

    // إنشاء جزء مع نص علوي
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // إنشاء فقرة للنص السلفي
    IParagraph paragraph2 = new Paragraph();

    // إنشاء جزء مع نص عادي
    IPortion portion2 = new Portion();
    portion2.Text = "أ";
    paragraph2.Portions.Add(portion2);

    // إنشاء جزء مع نص سلفي
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "ي";
    paragraph2.Portions.Add(subPortion);

    // إضافة الفقرات إلى مربع النص
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("TestOut.pptx", SaveFormat.Pptx);
    System.Diagnostics.Process.Start("TestOut.pptx");
 } 
```