---
title: "الجزء"
type: docs
weight: 70
url: /ar/net/portion/
keywords: "الجزء, شكل PowerPoint, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "الحصول على الجزء في عرض PowerPoint باستخدام C# أو .NET"
---

## **الحصول على إحداثيات الجزء**
**GetCoordinates()** تم إضافة طريقة إلى IPortion وفئة Portion والتي تسمح باسترداد إحداثيات بداية الجزء:
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

نعم، يمكنك [تعيين ارتباط تشعبي](/slides/ar/net/manage-hyperlinks/) إلى جزء منفرد؛ سيصبح هذا المقطع قابلًا للنقر فقط، وليس الفقرة بأكملها.

**كيف يعمل وراثة الأنماط: ما الذي يتجاوزه Portion، وما الذي يُستمد من Paragraph/TextFrame؟**

خصائص مستوى Portion لها أعلى أولوية. إذا لم يتم تعيين خاصية على [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/)، فإن المحرك يأخذها من [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/); إذا لم تُعين هناك أيضًا، فإنها تُستمد من [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) أو نمط [theme](https://reference.aspose.com/slides/net/aspose.slides.theme/theme/).

**ماذا يحدث إذا كان الخط المحدد لـ Portion غير موجود على الجهاز/الخادم المستهدف؟**

[قواعد استبدال الخطوط](/slides/ar/net/font-selection-sequence/) تنطبق. قد يتغير تدفق النص: المقاييس، والتهجئة، والعرض قد يتغير، وهذا مهم للتموضع الدقيق.

**هل يمكنني تعيين شفافية تعبئة نصية أو تدرج خاص بـ Portion مستقل عن بقية الفقرة؟**

نعم، لون النص، التعبئة، والشفافية على مستوى [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) يمكن أن تختلف عن المقاطع المجاورة.