---
title: الحصول على حدود الفقرة من العروض التقديمية في .NET
linktitle: حدود الفقرة
type: docs
weight: 43
url: /ar/net/paragraph-bounds/
keywords:
- حدود الفقرة
- إحداثيات الفقرة
- حجم الفقرة
- إطار النص
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية استرجاع حدود الفقرة في Aspose.Slides لـ .NET لتحسين موضع النص في عروض PowerPoint التقديمية."
---
## **نظرة عامة**

يشرح هذا المقال كيفية الحصول على حدود الفقرات وحجمها وإحداثياتها في Aspose.Slides. يوضح كيفية استرجاع مستطيل الفقرة من [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) باستخدام [IParagraph.GetRect](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/getrect/)، وكيفية الحصول على إحداثيات الفقرة داخل إطار نص خلية جدول، ويسلط الضوء على تفاصيل هامة مثل وحدات القياس، وتأثير تغليف النص على الحدود، وتحويل البيكسل، وقيم تنسيق الفقرة الفعّالة.

## **الحصول على إحداثيات مستطيلة لفقرة**

استخدم [IParagraph.GetRect](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/getrect/) للحصول على المستطيل الحدودى لفقرة.

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **الحصول على حجم الفقرة داخل إطار نص خلية جدول**

للحصول على الحجم والإحداثيات ل[IParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/) داخل إطار نص خلية جدول، استخدم [IParagraph.GetRect](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/getrect/). المستطيل المرجع يكون نسبياً إلى إطار نص خلية الجدول، لذا أضف موضع الجدول وإزاحة الخلية عندما تحتاج إلى إحداثيات على مستوى الشريحة.

المثال التالي يحصل على حدود الفقرة داخل خلية جدول ويرسم مستطيلات على الشريحة لتصوير تلك الحدود:

```csharp
using var presentation = new Presentation("source.pptx");
var slide = presentation.Slides[0];
var table = (ITable)slide.Shapes[0];
var cell = table.Rows[1][1];

var cellX = table.X + cell.OffsetX;
var cellY = table.Y + cell.OffsetY;

foreach (var paragraph in cell.TextFrame.Paragraphs)
{
    if (string.IsNullOrEmpty(paragraph.Text))
        continue;

    var paragraphRectangle = paragraph.GetRect();
    var paragraphRectangleX = paragraphRectangle.X + (float)cellX;
    var paragraphRectangleY = paragraphRectangle.Y + (float)cellY;

    var paragraphBoundsShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.Width,
        paragraphRectangle.Height);

    paragraphBoundsShape.FillFormat.FillType = FillType.NoFill;
    paragraphBoundsShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
    paragraphBoundsShape.LineFormat.FillFormat.FillType = FillType.Solid;
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **الأسئلة المتكررة**

**بأي وحدات يتم قياس إحداثيات الفقرة؟**

يتم قياسها بالنقاط، حيث إن البوصة الواحدة تساوي 72 نقطة. ينطبق ذلك على جميع الإحداثيات والأبعاد على الشريحة.

**هل يؤثر تغليف الكلمات على حدود الفقرة؟**

نعم. إذا تم تمكين [TextFrameFormat.WrapText](https://reference.aspose.com/slides/ar/net/aspose.slides/textframeformat/wraptext/) لإطار النص [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/)، يتم كسر النص ليتناسب مع عرض المنطقة، مما يغير الحدود الفعلية للفقرة.

**هل يمكن ربط إحداثيات الفقرة ببيكسلات في الصورة المصدرة بثقة؟**

نعم. احول النقاط إلى بيكسلات باستخدام الصيغة: pixels = points × (DPI / 72). النتيجة تعتمد على DPI المختار للعرض أو التصدير.

**كيف أحصل على معلمات تنسيق الفقرة "الفعّالة" مع مراعاة وراثة الأنماط؟**

استخدم [effective paragraph formatting data structure](/slides/ar/net/shape-effective-properties/); فهو يُعيد القيم النهائية المجمعة للمسافات البادئة، والمسافات، والتغليف، والاتجاه من اليمين إلى اليسار، وغيرها.