---
title: الحصول على حدود الفقرة من العروض التقديمية في .NET
linktitle: فقرة
type: docs
weight: 60
url: /ar/net/paragraph/
keywords:
- حدود الفقرة
- حدود الجزء النصي
- إحداثيات الفقرة
- إحداثيات الجزء
- حجم الفقرة
- حجم الجزء النصي
- إطار النص
- باوربوينت
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية استرجاع حدود الفقرة والجزء النصي في Aspose.Slides for .NET لتحسين تموضع النص في عروض باوربوينت."
---

## **الحصول على إحداثيات الفقرة والجزء داخل TextFrame**
باستخدام Aspose.Slides for .NET، يمكن للمطورين الآن الحصول على إحداثيات المستطيل للParagraph داخل مجموعة الفقرات في TextFrame. كما يسمح بالحصول على إحداثيات الـ Portion داخل مجموعة الـ Portion الخاصة بParagraph. في هذا الموضوع، سنوضح بمساعدة مثال كيفية الحصول على إحداثيات المستطيل للParagraph مع موضع الـ Portion داخل الفقرة.

## **الحصول على إحداثيات المستطيل للParagraph**
تمت إضافة الطريقة الجديدة **GetRect()**. تسمح بالحصول على مستطيل حدود الـ Paragraph.
```c#
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```


## **الحصول على حجم Paragraph و Portion داخل TextFrame في خلية جدول**
للحصول على حجم وإحداثيات الـ [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion) أو الـ [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) داخل TextFrame لخلية جدول، يمكنك استخدام طريقتي [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/methods/getrect) و[IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/methods/getrect).

يعرض هذا الكود المثال العملية الموضحة:
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

**ما الوحدات التي تُقاس بها الإحداثيات المُسترجعة للـ Paragraph و الـ Portion النصي؟**
بالنقاط (points)، حيث أن 1 بوصة = 72 نقطة. ينطبق ذلك على جميع الإحداثيات والأبعاد على الشريحة.

**هل يؤثر التفاف النص على حدود الـ Paragraph؟**
نعم. إذا تم تمكين [wrapping](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/) في الـ [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)، يتم كسر النص ليتناسب مع عرض المنطقة، مما يغيّر الحدود الفعلية للـ Paragraph.

**هل يمكن تحويل إحداثيات الـ Paragraph إلى بكسل في الصورة المصدرة بشكل موثوق؟**
نعم. يمكن تحويل النقاط إلى بكسل باستخدام: pixels = points × (DPI / 72). النتيجة تعتمد على DPI المختار للتصيير/التصدير.

**كيف أحصل على معلمات تنسيق الـ Paragraph “الفعّالة” مع مراعاة وراثة الأنماط؟**
استخدم [effective paragraph formatting data structure](/slides/ar/net/shape-effective-properties/); تُعيد القيم النهائية المجمعة للمسافات البادئة، والمسافات بين الأسطر، والالتفاف، والاتجاه من اليمين إلى اليسار، وأكثر.