---
title: تحديد لغة العرض
type: docs
weight: 100
url: /net/presentation-localization/
keywords: "تغيير اللغة، تدقيق إملائي، تدقيق، تدقيق إملائي، عرض PowerPoint، C#، Csharp، Aspose.Slides for .NET"
description: "تغيير أو التحقق من اللغة في عرض PowerPoint. تدقيق إملائي للنص في C# أو .NET"
---
## **تغيير اللغة للنص في العرض والشكل**
- إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
- الحصول على مرجع شريحة باستخدام مؤشرها.
- إضافة شكل تلقائي من نوع المستطيل إلى الشريحة.
- إضافة بعض النصوص إلى TextFrame.
- تعيين معرف اللغة للنص.
- كتابة العرض كملف PPTX.

يتم توضيح تنفيذ الخطوات المذكورة أعلاه أدناه في مثال.

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("نص لتطبيق لغة التدقيق الإملائي");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```