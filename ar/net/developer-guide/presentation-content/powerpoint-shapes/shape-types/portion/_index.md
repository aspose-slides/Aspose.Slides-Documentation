---
title: جزء
type: docs
weight: 70
url: /ar/net/portion/
keywords: "جزء, شكل PowerPoint, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "الحصول على جزء في عرض PowerPoint باستخدام C# أو .NET"
---

## **الحصول على إحداثيات موقع الجزء**
تم إضافة **GetCoordinates()** إلى IPortion وفئة Portion والتي تسمح باسترداد إحداثيات بداية الجزء:

```c#
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textFrame = (ITextFrame)shape.TextFrame;

    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (Portion portion in paragraph.Portions)
        {
            PointF point = portion.GetCoordinates();
            Console.Write(Environment.NewLine + "الإحداثيات X =" + point.X + " الإحداثيات Y =" + point.Y);
        }
    }
}
```