---
title: فقرة
type: docs
weight: 60
url: /net/paragraph/
keywords: "فقرة, جزء, إحداثيات فقرة, إحداثيات جزء, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "فقرة وجزء في عرض PowerPoint في C# أو .NET"
---

## **الحصول على إحداثيات الفقرة والجزء في TextFrame**
باستخدام Aspose.Slides for .NET، يمكن للمطورين الآن الحصول على الإحداثيات المستطيلة للفقرة داخل مجموعة الفقرات في TextFrame. كما أنه يسمح لك بالحصول على إحداثيات الجزء داخل مجموعة الأجزاء من فقرة. في هذا الموضوع، سنقوم بتوضيح ذلك بمساعدة مثال يوضح كيفية الحصول على الإحداثيات المستطيلة للفقرة جنبًا إلى جنب مع موقع الجزء داخل فقرة.

## **الحصول على الإحداثيات المستطيلة للفقرة**
تم إضافة الطريقة الجديدة **GetRect()**. وهي تسمح بالحصول على مستطيل حدود الفقرة.

```c#
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **الحصول على حجم الفقرة والجزء داخل إطار نص خلية الجدول** ##

للحصول على [جزء](https://reference.aspose.com/slides/net/aspose.slides/portion) أو [فقرة](https://reference.aspose.com/slides/net/aspose.slides/paragraph) الحجم والإحداثيات في إطار نص خلية الجدول، يمكنك استخدام طرق [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/methods/getrect) و [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/methods/getrect).

هذا الكود النموذجي يوضح العملية الموصوفة:

```csharp
using (Presentation pres = new Presentation("source.pptx"))
{
    Table tbl = pres.Slides[0].Shapes[0] as Table;

    ICell cell = tbl.Rows[1][1];


    double x = tbl.X + tbl.Rows[1][1].OffsetX;
    double y = tbl.Y + tbl.Rows[1][1].OffsetY;

    foreach (IParagraph para in cell.TextFrame.Paragraphs)
    {
        if (para.Text == "")
            continue;

        RectangleF rect = para.GetRect();
        IAutoShape shape =
            pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
        shape.LineFormat.FillFormat.FillType = FillType.Solid;


        foreach (IPortion portion in para.Portions)
        {
            if (portion.Text.Contains("0"))
            {
                rect = portion.GetRect();
                shape =
                    pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                        rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

                shape.FillFormat.FillType = FillType.NoFill;
            }
        }
    }
}
```