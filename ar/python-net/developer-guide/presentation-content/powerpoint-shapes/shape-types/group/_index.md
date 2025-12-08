---
title: تجميع أشكال العروض التقديمية باستخدام بايثون
linktitle: مجموعة الشكل
type: docs
weight: 40
url: /ar/python-net/group/
keywords:
- مجموعة الشكل
- مجموعة الأشكال
- إضافة مجموعة
- النص البديل
- بوربوينت
- عرض تقديمي
- بايثون
- Aspose.Slides
description: "تعلم كيفية تجميع وفك تجميع الأشكال في عروض PowerPoint ومستندات OpenDocument باستخدام Aspose.Slides for Python—دليل سريع خطوة بخطوة مع كود مجاني."
---

## **نظرة عامة**

يتيح تجميع الأشكال لك التعامل مع عدة كائنات رسم كوحدة واحدة بحيث يمكنك نقلها، تغيير حجمها، تنسيقها، وتحويلها معًا. باستخدام Aspose.Slides for Python، يمكنك إنشاء [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)، إضافة وتنسيق الأشكال الفرعية داخله، وحفظ النتيجة كملف PPTX. يوضح هذا المقال كيفية إضافة شكل مجموعة إلى شريحة وكيفية الوصول إلى بيانات الوصية مثل النص البديل من الأشكال داخل المجموعة، مما يتيح هيكلًا أنظف وعروضًا تقديمية أغنى وأسهل صيانة.

## **إضافة مجموعات الأشكال**

يدعم Aspose.Slides العمل مع مجموعات الأشكال على الشريحة. تتيح هذه الميزة إنشاء عروض تقديمية أغنى من خلال التعامل مع عدة أشكال كوحدة واحدة. يمكنك إضافة مجموعات أشكال جديدة، الوصول إلى المجموعات الحالية، ملءها بأشكال فرعية، وقراءة أو تعديل أي من خصائصها. لإضافة مجموعة أشكال إلى شريحة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى شريحة عبر الفهرس.
3. إضافة [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) إلى الشريحة.
4. إضافة أشكال إلى مجموعة الأشكال الجديدة.
5. حفظ العرض التقديمي المعدل كملف PPTX.

المثال أدناه يوضح كيفية إضافة مجموعة أشكال إلى شريحة.
```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation.
with slides.Presentation() as presentation:
    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة مجموعة أشكال إلى الشريحة.
    group_shape = slide.shapes.add_group_shape()

    # إضافة أشكال داخل مجموعة الأشكال.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # كتابة ملف PPTX إلى القرص.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```


## **الوصول إلى خاصية النص البديل**

يفسر هذا القسم كيفية قراءة النص البديل للأشكال الموجودة داخل مجموعة أشكال على شريحة باستخدام Aspose.Slides. للوصول إلى النص البديل للأشكال:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لتمثيل ملف PPTX.
2. الحصول على مرجع إلى الشريحة عبر فهرستها.
3. الوصول إلى مجموعة أشكال الشريحة.
4. الوصول إلى [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/).
5. قراءة خاصية النص البديل.

المثال أدناه يسترجع النص البديل للأشكال الموجودة داخل مجموعات الأشكال.
```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لفتح ملف PPTX.
with slides.Presentation("group_shape.pptx") as presentation:
    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # الوصول إلى مجموعة الأشكال.
            for child_shape in shape.shapes:
                # الوصول إلى خاصية النص البديل.
                print(child_shape.alternative_text)
```


## **الأسئلة المتكررة**

**هل يدعم التجميع المتداخل (مجموعة داخل مجموعة)؟**

نعم. يحتوي [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) على خاصية [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/) التي تشير مباشرة إلى دعم الهرمية (يمكن أن تكون المجموعة فرعية لمجموعة أخرى).

**كيف يمكنني التحكم في ترتيب Z للمجموعة بالنسبة للكائنات الأخرى على الشريحة؟**

استخدم خاصية [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/) في [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) لفحص أو تعديل موضعها في مكدس العرض.

**هل يمكنني منع التحريك/التعديل/إلغاء التجميع؟**

نعم. يتم الكشف عن قسم القفل للمجموعة عبر [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/)، مما يتيح لك تقييد العمليات على الكائن.