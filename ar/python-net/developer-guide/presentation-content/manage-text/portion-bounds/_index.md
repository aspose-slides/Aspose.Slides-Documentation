---
title: الحصول على حدود جزء النص من العروض التقديمية في بايثون
linktitle: حدود الجزء
type: docs
weight: 47
url: /ar/python-net/portion-bounds/
keywords:
- حدود جزء النص
- جزء النص
- جزء نصي
- إحداثيات النص
- موضع النص
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية استرجاع حدود جزء النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر .NET."
---
## **نظرة عامة**

يمثل جزء النص جزءًا محددًا من النص داخل فقرة ويسمح لك بالعمل مع ذلك الجزء بشكل مستقل عن المحتوى المحيط. في Aspose.Slides، يمكن استخدام الأجزاء عندما تحتاج إلى استرجاع حدود جزء من النص، أو تطبيق تنسيق على جزء فقط من الفقرة، أو التحكم في سلوك النص على مستوى أكثر تفصيلاً.

توضح هذه المقالة كيفية الحصول على المستطيل المحيط بجزء النص باستخدام [Portion.get_rect](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/get_rect/). كما توضح كيفية الحصول على إحداثيات بداية جزء النص باستخدام [Portion.get_coordinates](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/get_coordinates/). بالإضافة إلى ذلك، تسلط الضوء على سيناريوهات شائعة متعلقة بالأجزاء، مثل تطبيق رابط تشعبي على جزء نص واحد، وفهم كيفية حل التنسيق عبر الجزء والفقرة وإطار النص والوراثة من السمة، ومعالجة الحالات التي يكون فيها الخط المحدد غير متوفر.

## **الحصول على حدود جزء النص**

استخدم [Portion.get_rect](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/get_rect/) لاسترجاع المستطيل المحيط بجزء النص:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **الحصول على إحداثيات جزء النص**

استخدم [Portion.get_coordinates](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/get_coordinates/) لاسترجاع إحداثيات بداية جزء النص:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **الأسئلة الشائعة**

**هل يمكنني تطبيق رابط تشعبي على جزء فقط من النص داخل فقرة واحدة؟**

نعم، يمكنك [تعيين رابط تشعبي](/slides/ar/python-net/manage-hyperlinks/) إلى جزء منفرد؛ سيصبح ذلك الجزء فقط قابلًا للنقر، وليس الفقرة بأكملها.

**كيف يعمل وراثة الأنماط: ما الذي يتجاوز الجزء، وما الذي يُؤخذ من الفقرة أو إطار النص؟**

لدى خصائص مستوى الجزء أولوية أعلى. إذا لم يتم تعيين خاصية على الـ [Portion](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/)، فإن Aspose.Slides يستقيها من الـ [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/). وإذا لم تُحدد هناك أيضًا، فإن Aspose.Slides يستخدم نمط الـ [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) أو [theme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/theme/) .

**ماذا يحدث إذا كان الخط المحدد لجزء ما غير موجود على الجهاز أو الخادم المستهدف؟**

تُطبّق [قواعد استبدال الخطوط](/slides/ar/python-net/font-selection-sequence/). قد يتغير تدفق النص: يمكن أن تتغير المقاييس والواصفات والفواصل والعرض، وهذا يؤثر على التموضع الدقيق.

**هل يمكنني تعيين شفافية تعبئة النص أو تدرج لوني خاص بالجزء بشكل مستقل عن باقي الفقرة؟**

نعم، يمكن أن يختلف لون النص والتعبئة والشفافية على مستوى الـ [Portion](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/) عن الأجزاء المجاورة.