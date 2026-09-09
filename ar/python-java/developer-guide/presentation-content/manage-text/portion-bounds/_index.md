---
title: الحصول على حدود جزء النص من العروض التقديمية في بايثون عبر جافا
linktitle: حدود الجزء
type: docs
weight: 47
url: /ar/python-java/portion-bounds/
keywords:
- حدود جزء النص
- جزء النص
- قطعة نص
- إحداثيات النص
- موضع النص
- PowerPoint
- العرض التقديمي
- Python
- Java
- Aspose.Slides
description: "تعلم كيفية استرداد حدود جزء النص في عروض PowerPoint التقديمية باستخدام Aspose.Slides لبايثون عبر جافا."
---
## **نظرة عامة**

يمثل جزء النص شظية محددة من النص داخل فقرة ويسمح لك بالعمل مع تلك الشظية بشكل مستقل عن المحتوى المحيط. في Aspose.Slides، يمكن استخدام الأجزاء عندما تحتاج إلى استرجاع حدود شظية النص، أو تطبيق تنسيق على جزء فقط من الفقرة، أو التحكم في سلوك النص بمستوى أكثر تفصيلاً.

توضح هذه المقالة كيفية الحصول على المستطيل المحيط بالجزء باستخدام [Portion.getRect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/#getRect). كما توضح كيفية الحصول على إحداثيات بداية الجزء باستخدام [Portion.getCoordinates](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/#getCoordinates). بالإضافة إلى ذلك، تسلط الضوء على سيناريوهات شائعة تتعلق بالجزء، مثل إضافة ارتباط تشعبي إلى شظية نص واحدة، وفهم كيفية حل التنسيق عبر الجزء والفقرة وإطار النص والموضوع الموروث، ومعالجة الحالات التي يكون فيها الخط المحدد غير متوفر.

## **الحصول على حدود جزء النص**

استخدم [Portion.getRect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/#getRect) لاسترجاع المستطيل المحيط بجزء النص:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **الحصول على إحداثيات جزء النص**

استخدم [Portion.getCoordinates](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/#getCoordinates) لاسترجاع إحداثيات بداية جزء النص:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**هل يمكنني إضافة ارتباط تشعبي إلى جزء فقط من النص داخل فقرة واحدة؟**

نعم، يمكنك [assign a hyperlink](/slides/ar/python-java/manage-hyperlinks/) لجزء منفرد؛ سيصبح ذلك الجزء فقط قابلًا للنقر، وليس الفقرة بأكملها.

**كيف يعمل وراثة الأنماط: ما الذي يتجاوزه الجزء، وما الذي يُؤخذ من الفقرة أو إطار النص؟**

لخصائص المستوى الجزء أولوية أعلى. إذا لم يتم تعيين خاصية على الـ[Portion](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/)، فإن Aspose.Slides يأخذها من الـ[Paragraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/). إذا لم تُضبط هناك أيضًا، يستخدم Aspose.Slides نمط الـ[TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) أو الـ[theme](https://reference.aspose.com/slides/ar/python-java/aspose.slides/theme/).

**ماذا يحدث إذا كان الخط المحدد لجزء ما غير موجود على الجهاز أو الخادم المستهدف؟**

تُطبق [Font substitution rules](/slides/ar/python-java/font-selection-sequence/). قد يتغير تدفق النص: قد تتغير المقاييس، والقطع، والعرض، وهذا يؤثر على التموضع الدقيق.

**هل يمكنني ضبط شفافية تعبئة النص للجزء أو تدرج لوني بشكل مستقل عن باقي الفقرة؟**

نعم، يمكن أن تختلف لون النص، والتعبئة، والشفافية على مستوى الـ[Portion](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/) عن الشظايا المجاورة.