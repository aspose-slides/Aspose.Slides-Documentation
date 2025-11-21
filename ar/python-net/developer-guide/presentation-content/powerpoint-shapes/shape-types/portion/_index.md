---
title: إدارة أجزاء النص في العروض التقديمية باستخدام Python
linktitle: جزء النص
type: docs
weight: 70
url: /ar/python-net/portion/
keywords:
- جزء النص
- قطعة النص
- إحداثيات النص
- موضع النص
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إدارة أجزاء النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للPython عبر .NET، مما يعزز الأداء والتخصيص."
---

## **الحصول على إحداثيات أجزاء النص**
تمت إضافة طريقة [get_coordinates](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_coordinates/) إلى فئة [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) التي تسمح باسترجاع إحداثيات أجزاء النص:
```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```


## **الأسئلة الشائعة**

**هل يمكنني تطبيق ارتباط تشعبي على جزء فقط من النص داخل فقرة واحدة؟**
نعم، يمكنك [تعيين ارتباط تشعبي](/slides/ar/python-net/manage-hyperlinks/) إلى جزء فردي؛ فقط هذا الجزء سيكون قابلًا للنقر، وليس الفقرة بأكملها.

**كيف يعمل وراثة الأنماط: ما الذي يتجاوز الـPortion وما الذي يُؤخذ من الـParagraph/ـTextFrame؟**
لدى خصائص مستوى الـPortion أعلى أسبقية. إذا لم يتم تعيين خاصية على الـ[Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)، فإن المحرك يأخذها من الـ[Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/); وإذا لم تُحدد هناك أيضًا، فإنها تُؤخذ من الـ[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) أو نمط الـ[theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/theme/) .

**ماذا يحدث إذا كان الخط المحدد للـPortion غير موجود على الجهاز/الخادم الهدف؟**
تُطبق [قواعد استبدال الخط](/slides/ar/python-net/font-selection-sequence/). قد يتغير تدفق النص: قد تتغير المقاييس، والفسرة، والعرض، وهو ما يؤثر على التحديد الدقيق للموقع.

**هل يمكنني تعيين شفافية أو تدرج تعبئة نص خاص بالـPortion بشكل مستقل عن باقي الفقرة؟**
نعم، يمكن أن يختلف لون النص، والتعبئة، والشفافية على مستوى الـ[Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) عن القطع المجاورة.