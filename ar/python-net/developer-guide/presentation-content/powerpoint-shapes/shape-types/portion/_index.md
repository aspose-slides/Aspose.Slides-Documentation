---
title: إدارة أجزاء النص في العروض التقديمية باستخدام بايثون
linktitle: جزء النص
type: docs
weight: 70
url: /ar/python-net/portion/
keywords:
- جزء النص
- جزء من النص
- إحداثيات النص
- موضع النص
- PowerPoint
- OpenDocument
- عرض تقديمي
- بايثون
- Aspose.Slides
description: "تعلم كيفية إدارة أجزاء النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET، مما يعزز الأداء وقابلية التخصيص."
---

## **الحصول على إحداثيات أجزاء النص**

تم إضافة طريقة `get_coordinates` إلى فئة `Portion` التي تسمح باستخراج إحداثيات أجزاء النص:

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

نعم، يمكنك [تعيين ارتباط تشعبي](/slides/ar/python-net/manage-hyperlinks/) لجزء معين؛ سيصبح هذا الجزء فقط قابلًا للنقر، وليس الفقرة بأكملها.

**كيف يعمل ورث الأنماط: ما الذي يتجاوز الجزء منه، وما الذي يُستَخْدَم من الفقرة/إطار النص؟**

تملك خصائص المستوى `Portion` أعلى أولوية. إذا لم يتم تعيين خاصية على الـ[Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)، فإن المحرك يأخذها من الـ[Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/); وإذا لم تُحدد هناك أيضًا، فإنها تُستَخْدَم من الـ[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) أو نمط الـ[theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/theme/).

**ماذا يحدث إذا كان الخط المحدد لجزء `Portion` غير موجود على الجهاز/الخادم المستهدف؟**

تُطبق [قواعد استبدال الخطوط](/slides/ar/python-net/font-selection-sequence/). قد يتغير تدفق النص: قد تتغير المقاييس، والترقيم، والعرض، مما يؤثر على الدقة في تحديد الموضع.

**هل يمكنني ضبط شفافية تعبئة النص أو تدرجه لجزء معين دون التأثير على بقية الفقرة؟**

نعم، يمكن أن يختلف لون النص، والتعبئة، والشفافية على مستوى الـ[Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) عن القطع المجاورة.