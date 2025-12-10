---
title: "إدارة أجزاء النص في العروض التقديمية باستخدام C++"
linktitle: "جزء النص"
type: docs
weight: 70
url: /ar/cpp/portion/
keywords:
- "جزء النص"
- "جزء من النص"
- "إحداثيات النص"
- "موضع النص"
- "PowerPoint"
- "عرض تقديمي"
- "C++"
- "Aspose.Slides"
description: "تعلم كيفية إدارة أجزاء النص في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ C++، مما يعزز الأداء والتخصيص."
---

## **احصل على إحداثيات جزء من النص**
**GetCoordinates()** تم إضافة الطريقة إلى IPortion وفئة Portion والتي تسمح باسترجاع إحداثيات بداية الجزء:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```


## **الأسئلة المتكررة**

**هل يمكنني تطبيق ارتباط تشعبي على جزء فقط من النص داخل فقرة واحدة؟**

نعم، يمكنك [تعيين ارتباط تشعبي](/slides/ar/cpp/manage-hyperlinks/) لجزء منفرد؛ سيتاح النقر فقط على هذا الجزء، وليس على الفقرة بأكملها.

**كيف يعمل وراثة الأنماط: ماذا يتجاوز الـPortion وماذا يُؤخذ من الـParagraph / الـTextFrame؟**

خصائص المستوى الخاص بالـPortion لها الأولوية الأعلى. إذا لم يتم تعيين خاصية على [Portion](https://reference.aspose.com/slides/cpp/aspose.slides/portion/)، فإن المحرك يأخذها من [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/); إذا لم تُحدد هناك أيضًا، فإنها تُؤخذ من [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/) أو من نمط [theme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/theme/).

**ماذا يحدث إذا كان الخط المحدد للـPortion غير موجود على الجهاز/الخادم المستهدف؟**

تُطبق [Font substitution rules](/slides/ar/cpp/font-selection-sequence/). قد يتغير تنسيق النص: يمكن أن تتغير المقاييس، والقطع، والعرض، وهذا مهم لتحديد المواقع بدقة.

**هل يمكنني ضبط شفافية تعبئة النص أو تدرج اللون للـPortion بشكل مستقل عن باقي الفقرة؟**

نعم، يمكن أن يختلف لون النص، والتعبئة، والشفافية على مستوى [Portion](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) عن القطع المجاورة.