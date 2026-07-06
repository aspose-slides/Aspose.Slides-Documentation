---
title: الحصول على حدود جزء النص من العروض التقديمية في .NET
linktitle: حدود الجزء
type: docs
weight: 47
url: /ar/net/portion-bounds/
keywords:
- حدود جزء النص
- جزء النص
- جزء النص
- إحداثيات النص
- موضع النص
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية استرجاع حدود جزء النص في عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ .NET."
---
## **نظرة عامة**

يمثل جزء النص شظية محددة من النص داخل فقرة ويتيح لك العمل مع هذه الشظية بشكل مستقل عن المحتوى المحيط. في Aspose.Slides، يمكن استخدام الأجزاء عندما تحتاج إلى استرجاع حدود شظية نصية، أو تطبيق تنسيق على جزء فقط من الفقرة، أو التحكم في سلوك النص بمستوى أكثر تفصيلاً.

توضح هذه المقالة كيفية الحصول على المستطيل المحيط بالجزء باستخدام [IPortion.GetRect](https://reference.aspose.com/slides/ar/net/aspose.slides/iportion/getrect/). كما تظهر كيفية الحصول على إحداثيات بداية الجزء باستخدام [IPortion.GetCoordinates](https://reference.aspose.com/slides/ar/net/aspose.slides/iportion/getcoordinates/). بالإضافة إلى ذلك، تسلط الضوء على سيناريوهات شائعة تتعلق بالأجزاء، مثل تطبيق ارتباط تشعبي على شظية نصية واحدة، وفهم كيفية حل التنسيق عبر الجزء والفقرة وإطار النص ووراثة السمة، ومعالجة الحالات التي تكون فيها الخط المحدد غير موجود.

## **الحصول على حدود جزء النص**

استخدم [IPortion.GetRect](https://reference.aspose.com/slides/ar/net/aspose.slides/iportion/getrect/) لاسترجاع المستطيل المحيط بجزء النص:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var rectangle = portion.GetRect();
        Console.WriteLine($"X = {rectangle.X}; Y = {rectangle.Y}; Width = {rectangle.Width}; Height = {rectangle.Height}");
    }
}
```

## **الحصول على إحداثيات جزء النص**

استخدم [IPortion.GetCoordinates](https://reference.aspose.com/slides/ar/net/aspose.slides/iportion/getcoordinates/) لاسترجاع إحداثيات بداية جزء النص:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var point = portion.GetCoordinates();
        Console.WriteLine($"X = {point.X}; Y = {point.Y}");
    }
}
```

## **الأسئلة المتكررة**

**هل يمكنني تطبيق ارتباط تشعبي على جزء فقط من النص داخل فقرة واحدة؟**

نعم، يمكنك [assign a hyperlink](/slides/ar/net/manage-hyperlinks/) إلى جزء فردي؛ سيصبح هذا الشظية فقط قابلًا للنقر، وليس الفقرة بأكملها.

**كيف يعمل وراثة الأنماط: ما الذي يتجاوز الجزء، وما الذي يُؤخذ من الفقرة أو إطار النص؟**

خصائص مستوى الجزء لها أولوية قصوى. إذا لم يتم تعيين خاصية على [IPortion](https://reference.aspose.com/slides/ar/net/aspose.slides/iportion/)، فإن Aspose.Slides يأخذها من [IParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/). إذا لم تُحدد هناك أيضًا، يستخدم Aspose.Slides نمط [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) أو نمط [theme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/theme/).

**ماذا يحدث إذا كان الخط المحدد للجزء غير موجود على الجهاز أو الخادم المستهدف؟**

تنطبق [Font substitution rules](/slides/ar/net/font-selection-sequence/). قد يتغير تدفق النص: يمكن أن تتغير المقاييس والكسرة والعرض، مما يؤثر على التموقع الدقيق.

**هل يمكنني ضبط شفافية تعبئة النص أو تدرج لون خاص بالجزء بشكل مستقل عن بقية الفقرة؟**

نعم، يمكن أن تختلف لون النص، والتعبئة، والشفافية على مستوى [IPortion](https://reference.aspose.com/slides/ar/net/aspose.slides/iportion/) عن الشظايا المجاورة.