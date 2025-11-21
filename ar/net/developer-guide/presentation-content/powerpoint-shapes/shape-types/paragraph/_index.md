---
title: الحصول على حدود الفقرة من العروض التقديمية في .NET
linktitle: فقرة
type: docs
weight: 60
url: /ar/net/paragraph/
keywords:
- حدود الفقرة
- حدود جزء النص
- إحداثيات الفقرة
- إحداثيات الجزء
- حجم الفقرة
- حجم جزء النص
- إطار النص
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية استرجاع حدود الفقرة وجزء النص في Aspose.Slides for .NET لتحسين موضع النص في عروض PowerPoint التقديمية."
---

## **الحصول على إحداثيات الفقرة والجزء في TextFrame**
باستخدام Aspose.Slides for .NET، يمكن للمطورين الآن الحصول على الإحداثيات المستطيلة للفقرة داخل مجموعة الفقرات في TextFrame. كما يسمح بالحصول على إحداثيات الجزء داخل مجموعة الأجزاء للفقرة. في هذا الموضوع، سنوضح بمساعدة مثال كيفية الحصول على إحداثيات مستطيلة للفقرة مع موقع الجزء داخل الفقرة.

## **الحصول على الإحداثيات المستطيلة للفقرة**
تم إضافة الطريقة الجديدة **GetRect()**. تسمح بالحصول على مستطيل حدود الفقرة.
```c#
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```


## **الحصول على حجم الفقرة والجزء داخل إطار نص خلية الجدول**
للحصول على حجم وإحداثيات [الجزء](https://reference.aspose.com/slides/net/aspose.slides/portion) أو [الفقرة](https://reference.aspose.com/slides/net/aspose.slides/paragraph) داخل إطار نص خلية جدول، يمكنك استخدام طريقتي [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/methods/getrect) و[IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/methods/getrect).

يعرض هذا الكود العيني العملية الموصوفة:
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


## **الأسئلة المتكررة**
**بأي وحدة تُقاس الإحداثيات التي تُرجَع للفقرة وأجزاء النص؟**
بالنقاط، حيث إن 1 بوصة = 72 نقطة. ينطبق ذلك على جميع الإحداثيات والأبعاد على الشريحة.

**هل يؤثر التفاف الكلمات على حدود الفقرة؟**
نعم. إذا تم تمكين [اللف](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/) في الـ[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)، يتم كسر النص ليتناسب مع عرض المنطقة، مما يُغيّر الحدود الفعلية للفقرة.

**هل يمكن ربط إحداثيات الفقرة ببكسلات الصورة المصدرة بموثوقية؟**
نعم. يمكن تحويل النقاط إلى بكسلات باستخدام: pixels = points × (DPI / 72). النتيجة تعتمد على DPI المختار للتصيير/التصدير.

**كيف أحصل على معلمات تنسيق الفقرة "الفعّالة" مع مراعاة وراثة النمط؟**
استخدم [هيكل بيانات تنسيق الفقرة الفعّالة](/slides/ar/net/shape-effective-properties/); يُعيد القيم النهائية المجمّعة للمسافات البادئة، والمسافات، واللف، واتجاه النص من اليمين إلى اليسار، وغير ذلك.