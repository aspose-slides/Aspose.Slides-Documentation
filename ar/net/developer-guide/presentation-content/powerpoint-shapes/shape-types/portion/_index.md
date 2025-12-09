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
description: "تعلم كيفية إدارة أجزاء النص في عروض PowerPoint باستخدام Aspose.Slides لـ .NET، مما يعزز الأداء والتخصيص."
---

## **الحصول على إحداثيات الموضع للجزء**
**GetCoordinates()** تم إضافة طريقة إلى IPortion و Portion class والتي تسمح باسترجاع إحداثيات بداية الجزء:
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


## **الأسئلة المتكررة**

**هل يمكنني تطبيق رابط تشعبي على جزء فقط من النص داخل فقرة واحدة؟**

نعم، يمكنك [تعيين ارتباط تشعبي](/slides/ar/net/manage-hyperlinks/) إلى جزء فردي؛ سيصبح هذا الجزء فقط قابلاً للنقر، وليس الفقرة بأكملها.

**كيف يعمل وراثة النمط: ما الذي يتجاوزه Portion، وما الذي يُؤخذ من Paragraph/TextFrame؟**

الخصائص على مستوى الجزء لها أعلى أولوية. إذا لم يتم تعيين خاصية على [الجزء](https://reference.aspose.com/slides/net/aspose.slides/portion/)، فإن المحرك يأخذها من [الفقرة](https://reference.aspose.com/slides/net/aspose.slides/paragraph/); إذا لم تُعيّن هناك أيضًا، من [إطار النص](https://reference.aspose.com/slides/net/aspose.slides/textframe/) أو نمط [السمة](https://reference.aspose.com/slides/net/aspose.slides.theme/theme/).

**ماذا يحدث إذا كان الخط المحدد للجزء غير موجود على الجهاز/الخادم المستهدف؟**

[قواعد استبدال الخط](/slides/ar/net/font-selection-sequence/) تُطبق. قد يتدفق النص مجدداً: قد تتغير المقاييس والواصلة والعرض، وهو ما يهم لتحديد المواقع بدقة.

**هل يمكنني ضبط شفافية تعبئة نص خاصة بالجزء أو تدرج لوني مستقل عن بقية الفقرة؟**

نعم، يمكن أن يختلف لون النص والتعبئة والشفافية على مستوى [الجزء](https://reference.aspose.com/slides/net/aspose.slides/portion/) عن القطع المجاورة.