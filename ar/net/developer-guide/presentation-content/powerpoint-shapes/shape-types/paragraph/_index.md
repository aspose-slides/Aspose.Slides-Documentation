---
title: فقرة
type: docs
weight: 60
url: /ar/net/paragraph/
keywords: "فقرة, جزء, إحداثيات الفقرة, إحداثيات الجزء, عرض تقديمي PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "فقرة وجزء في عرض تقديمي PowerPoint باستخدام C# أو .NET"
---

## **الحصول على إحداثيات الفقرة والجزء في TextFrame**
باستخدام Aspose.Slides for .NET، يمكن للمطورين الآن الحصول على إحداثيات مستطيلة للفقرة داخل مجموعة الفقرات في TextFrame. كما يسمح بالحصول على إحداثيات الجزء داخل مجموعة الأجزاء للفقرة. في هذا الموضوع، سنوضح بمساعدة مثال كيفية الحصول على الإحداثيات المستطيلة للفقرة بالإضافة إلى موضع الجزء داخل الفقرة.

## **الحصول على إحداثيات المستطيل للParagraph**
تمت إضافة الطريقة الجديدة **GetRect()**. تسمح بالحصول على مستطيل حدود الفقرة.
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
للحصول على حجم [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion) أو [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) وإحداثياتهما في إطار نص خلية جدول، يمكنك استخدام طريقتي [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/methods/getrect) و[IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/methods/getrect).
يعرض هذا الكود العيني العملية الموضحة:
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


## **الأسئلة الشائعة**

**بأي وحدات تُرجَع الإحداثيات للفقرة وأجزاء النص؟**  
بالنقاط، حيث أن 1 بوصة = 72 نقطة. ينطبق ذلك على جميع الإحداثيات والأبعاد على الشريحة.

**هل يؤثر التفاف الكلمات على حدود الفقرة؟**  
نعم. إذا تم تفعيل [wrapping](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/) في الـ[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)، يتم تقسيم النص ليناسب عرض المنطقة، مما يغيّر الحدود الفعلية للفقرة.

**هل يمكن تحويل إحداثيات الفقرة إلى بيكسلات في الصورة المصدرة بثقة؟**  
نعم. احسب التحويل من النقاط إلى البيكسلات باستخدام: pixels = points × (DPI / 72). النتيجة تعتمد على قيمة DPI المختارة للتصيير/التصدير.

**كيف أحصل على معلمات تنسيق الفقرة "الفعّالة"، مع مراعاة وراثة النمط؟**  
استخدم [الهيكلية الفعّالة لتنسيق الفقرة](/slides/ar/net/shape-effective-properties/); تُعيد القيم النهائية المجمعّة للمسافات البادئة، التباعد، الالتفاف، الاتجاه من اليمين إلى اليسار، وغيرها.