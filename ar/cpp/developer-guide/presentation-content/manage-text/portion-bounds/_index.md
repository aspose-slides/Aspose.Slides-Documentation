---
title: الحصول على حدود جزء النص من العروض التقديمية في C++
linktitle: حدود الجزء
type: docs
weight: 47
url: /ar/cpp/portion-bounds/
keywords:
- حدود جزء النص
- جزء النص
- قطعة النص
- إحداثيات النص
- موضع النص
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية استرجاع حدود جزء النص في العروض التقديمية لـ PowerPoint باستخدام Aspose.Slides للغة C++."
---
## **نظرة عامة**

يمثل جزء النص شظية محددة من النص داخل فقرة ويسمح لك بالعمل مع تلك الشظية بشكل مستقل عن المحتوى المحيط. في Aspose.Slides، يمكن استخدام الأجزاء عندما تحتاج إلى استرجاع حدود شظية نصية، أو تطبيق تنسيق على جزء فقط من الفقرة، أو التحكم في سلوك النص بمستوى أكثر تفصيلاً.

توضح هذه المقالة كيفية الحصول على المستطيل المحيط لجزء باستخدام [IPortion::GetRect](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportion/getrect/). كما توضح كيفية الحصول على إحداثيات بداية الجزء باستخدام [IPortion::GetCoordinates](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportion/getcoordinates/). بالإضافة إلى ذلك، تسلط الضوء على السيناريوهات الشائعة المتعلقة بالأجزاء، مثل تطبيق ارتباط تشعبي على شظية نصية واحدة، وفهم كيفية حل التنسيق عبر الجزء والفقرة وإطار النص والوراثة من السمة، ومعالجة الحالات التي يكون فيها الخط المحدد غير متاح.

## **الحصول على حدود جزء النص**

استخدم [IPortion::GetRect](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportion/getrect/) لاسترجاع المستطيل المحيط لجزء النص:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto rectangle = portion->GetRect();
        auto rectangleX = rectangle.get_X();
        auto rectangleY = rectangle.get_Y();
        auto rectangleWidth = rectangle.get_Width();
        auto rectangleHeight = rectangle.get_Height();

        Console::WriteLine(u"X = {0}; Y = {1}; Width = {2}; Height = {3}", rectangleX, rectangleY, rectangleWidth, rectangleHeight);
    }
}

presentation->Dispose();
```

## **الحصول على إحداثيات جزء النص**

استخدم [IPortion::GetCoordinates](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportion/getcoordinates/) لاسترجاع إحداثيات بداية جزء النص:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto point = portion->GetCoordinates();
        auto pointX = point.get_X();
        auto pointY = point.get_Y();

        Console::WriteLine(u"X = {0}; Y = {1}", pointX, pointY);
    }
}

presentation->Dispose();
```

## **الأسئلة المتكررة**

**هل يمكنني تطبيق ارتباط تشعبي على جزء فقط من النص داخل فقرة واحدة؟**

نعم، يمكنك [تعيين ارتباط تشعبي](/slides/ar/cpp/manage-hyperlinks/) إلى جزء فردي؛ فقط تلك الشظية ستكون قابلة للنقر، وليس الفقرة بأكملها.

**كيف يعمل وراثة الأنماط: ما الذي يتغلب عليه الجزء، وما يُستمد من الفقرة أو إطار النص؟**

خصائص مستوى الجزء لها أعلى أولوية. إذا لم يتم تعيين خاصية على [IPortion](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportion/)، فإن Aspose.Slides يحصل عليها من [IParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/). إذا لم تُحدد هناك أيضاً، فإن Aspose.Slides يستخدم نمط [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) أو [theme](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/theme/) .

**ماذا يحدث إذا كان الخط المحدد لجزء ما غير موجود على الجهاز أو الخادم الهدف؟**

[قواعد استبدال الخط](/slides/ar/cpp/font-selection-sequence/) تُطبق. قد يحدث إعادة تدفق للنص: يمكن أن تتغير المقاييس، والفواصل، والعرض، وهو أمر مهم لتحديد المواقع بدقة.

**هل يمكنني تعيين شفافية تعبئة النص أو تدرج لوني خاص بالجزء بشكل مستقل عن باقي الفقرة؟**

نعم، يمكن أن تختلف لون النص، والتعبئة، والشفافية على مستوى [IPortion](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportion/) عن الشظيات المجاورة.