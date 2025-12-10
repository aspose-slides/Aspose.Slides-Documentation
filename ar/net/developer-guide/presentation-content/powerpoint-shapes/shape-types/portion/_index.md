---
title: إدارة أجزاء النص في العروض التقديمية في .NET
linktitle: جزء النص
type: docs
weight: 70
url: /ar/net/portion/
keywords:
- جزء النص
- جزء من النص
- إحداثيات النص
- موضع النص
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إدارة أجزاء النص في عروض PowerPoint التقديمية باستخدام Aspose.Slides for .NET، مما يعزز الأداء والتخصيص."
---

## **الحصول على إحداثيات جزء من النص**
**GetCoordinates()** تم إضافة طريقة إلى IPortion وفئة Portion والتي تسمح باسترجاع إحداثيات بداية الجزء:
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
            Console.Write(Environment.NewLine + "Corrdinates X =" + point.X + " Corrdinates Y =" + point.Y);
        }
    }
}
```


## **الأسئلة الشائعة**

**هل يمكنني تطبيق ارتباط تشعبي على جزء فقط من النص داخل فقرة واحدة؟**
نعم، يمكنك [إسناد ارتباط تشعبي](/slides/ar/net/manage-hyperlinks/) إلى جزء فردي؛ سيكون هذا الجزء فقط قابلًا للنقر، وليس الفقرة بأكملها.

**كيف يعمل وراثة الأنماط: ما الذي يتجاوزه Portion، وما الذي يُستقبل من Paragraph/TextFrame؟**
خصائص المستوى Portion لها أعلى أولوية. إذا لم يتم تعيين خاصية على الـ[Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/)، فإن المحرك يأخذها من الـ[Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/); إذا لم تُحدد هناك أيضًا، من الـ[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) أو نمط الـ[theme](https://reference.aspose.com/slides/net/aspose.slides.theme/theme/).

**ماذا يحدث إذا كان الخط المحدد ل​ Portion مفقودًا على الجهاز/الخادم المستهدف؟**
تُطبق [قواعد استبدال الخطوط](/slides/ar/net/font-selection-sequence/). قد يتدفق النص مرة أخرى: قد تتغير المقاييس، الفواصل، والعرض، وهذا مهم للتحديد الدقيق للموقع.

**هل يمكنني تعيين شفافية تعبئة النص أو تدرج لوني خاص بـ Portion بشكل مستقل عن باقي الفقرة؟**
نعم، يمكن أن يختلف لون النص، التعبئة، والشفافية على مستوى الـ[Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) عن القطع المجاورة.