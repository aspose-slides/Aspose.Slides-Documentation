---
title: "أشكال مجموعة العرض التقديمي باستخدام بايثون"
linktitle: "مجموعة الشكل"
type: docs
weight: 40
url: /ar/python-net/group/
keywords:
- "مجموعة الشكل"
- "مجموعة الشكل"
- "إضافة مجموعة"
- "نص بديل"
- "PowerPoint"
- "عرض تقديمي"
- "Python"
- "Aspose.Slides"
description: "تعلم كيفية تجميع وإلغاء تجميع الأشكال في PowerPoint ومجموعات OpenDocument باستخدام Aspose.Slides للبايثون — دليل سريع خطوة بخطوة مع كود مجاني."
---

## **نظرة عامة**

يتيح تجميع الأشكال التعامل مع عدة كائنات رسومية كوحدة واحدة بحيث يمكنك تحريكها، تغيير حجمها، تنسيقها، وتحويلها معًا. باستخدام Aspose.Slides للبايثون، يمكنك إنشاء [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)، إضافة وتنسيق الأشكال الفرعية داخله، وحفظ النتيجة إلى ملف PPTX. توضح هذه المقالة كيفية إضافة شكل مجموعة إلى شريحة وكيفية الوصول إلى بيانات الوصول مثل النص البديل من الأشكال داخل المجموعة، مما يتيح هيكلًا أنظف وعروضًا تقديمية أكثر ثراءً وصيانة.

## **إضافة أشكال المجموعة**

يدعم Aspose.Slides العمل مع أشكال المجموعات على الشريحة. تتيح لك هذه الخاصية بناء عروض تقديمية أغنى بمعاملة مجموعة من الأشكال ككائن واحد. يمكنك إضافة أشكال مجموعة جديدة، الوصول إلى المجموعات الموجودة، ملءها بالأشكال الفرعية، وقراءة أو تعديل أي من خصائصها. لإضافة شكل مجموعة إلى شريحة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى شريحة حسب الفهرس.
3. إضافة [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) إلى الشريحة.
4. إضافة أشكال إلى شكل المجموعة الجديد.
5. حفظ العرض المعدل كملف PPTX.

المثال أدناه يوضح كيفية إضافة شكل مجموعة إلى شريحة.

```py
import aspose.slides as slides

# إنشاء كائن الفئة Presentation.
with slides.Presentation() as presentation:
    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل مجموعة إلى الشريحة.
    group_shape = slide.shapes.add_group_shape()

    # إضافة أشكال داخل شكل المجموعة.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # كتابة ملف PPTX إلى القرص.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى خاصية النص البديل**

تشرح هذه القسم كيفية قراءة نص بديل للأشكال الموجودة داخل شكل مجموعة على شريحة باستخدام Aspose.Slides. للوصول إلى النص البديل للأشكال:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لتمثيل ملف PPTX.
2. الحصول على مرجع إلى الشريحة حسب الفهرس.
3. الوصول إلى مجموعة أشكال الشريحة.
4. الوصول إلى [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/).
5. قراءة خاصية النص البديل.

المثال أدناه يستخرج النص البديل للأشكال الموجودة داخل أشكال المجموعات.

```py
import aspose.slides as slides

# إنشاء كائن الفئة Presentation لفتح ملف PPTX.
with slides.Presentation("group_shape.pptx") as presentation:
    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # الوصول إلى شكل المجموعة.
            for child_shape in shape.shapes:
                # الوصول إلى خاصية النص البديل.
                print(child_shape.alternative_text)
```

## **الأسئلة المتكررة**

**هل يتم دعم التجميع المتداخل (مجموعة داخل مجموعة)؟**

نعم. يحتوي [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) على خاصية [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/)، التي تشير مباشرةً إلى دعم التسلسل الهرمي (يمكن أن تكون المجموعة فرعية لمجموعة أخرى).

**كيف يمكنني التحكم بترتيب z للمجموعة بالنسبة إلى الكائنات الأخرى على الشريحة؟**

استخدم خاصية [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/) الخاصة بـ [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) لتفقد أو تغيير موضعها في مكدس العرض.

**هل يمكنني منع التحريك/التحرير/إلغاء التجميع؟**

نعم. يتم كشف قسم القفل للمجموعة عبر [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/)، والذي يتيح لك تقييد العمليات على الكائن.