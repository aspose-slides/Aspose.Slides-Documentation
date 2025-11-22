---
title: أ_shapes مجموعة العرض التقديمي باستخدام بايثون
linktitle: مجموعة الشكل
type: docs
weight: 40
url: /ar/python-net/group/
keywords:
- مجموعة الشكل
- مجموعة الشكل
- إضافة مجموعة
- نص بديل
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلّم كيفية تجميع وفك تجميع الأشكال في عروض PowerPoint ومستندات OpenDocument باستخدام Aspose.Slides للبايثون—دليل سريع خطوة بخطوة مع كود مجاني."
---

## **نظرة عامة**

يسمح تجميع الأشكال بالتعامل مع كائنات الرسم المتعددة كوحدة واحدة بحيث يمكنك نقلها، تغيير حجمها، تنسيقها وتحويلها معًا. باستخدام Aspose.Slides for Python، يمكنك إنشاء [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)، إضافة وتنسيق الأشكال الفرعية داخله، وحفظ النتيجة كملف PPTX. يوضح هذا المقال كيفية إضافة شكل مجموعة إلى شريحة وكيفية الوصول إلى بيانات الوصـــولية مثل النص البديل من الأشكال داخل المجموعة، مما يتيح هيكلًا أنظف وعروضًا تقديمية أغنى وأكثر صيانة.

## **إضافة أشكال المجموعة**

يدعم Aspose.Slides العمل مع أشكال المجموعة على الشريحة. تتيح لك هذه الميزة بناء عروض تقديمية أكثر غنىً عن طريق معالجة عدة أشكال ككائن واحد. يمكنك إضافة أشكال مجموعة جديدة، الوصول إلى الموجودة منها، تعبئتها بأشكال فرعية، وقراءة أو تعديل أي من خصائصها. لإضافة شكل مجموعة إلى شريحة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى شريحة بواسطة الفهرس.
3. إضافة [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) إلى الشريحة.
4. إضافة أشكال إلى شكل المجموعة الجديد.
5. حفظ العرض التقديمي المعدل كملف PPTX.

يوضح المثال أدناه كيفية إضافة شكل مجموعة إلى شريحة.
```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation.
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

تشرح هذه الفقرة كيفية قراءة النص البديل للأشكال الموجودة داخل شكل مجموعة على شريحة باستخدام Aspose.Slides. للوصول إلى النص البديل للأشكال:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لتمثيل ملف PPTX.
2. الحصول على مرجع إلى الشريحة بواسطة فهرسها.
3. الوصول إلى مجموعة الأشكال في الشريحة.
4. الوصول إلى [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/).
5. قراءة خاصية النص البديل.

المثال أدناه يسترجع النص البديل للأشكال الموجودة داخل أشكال المجموعة.
```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لفتح ملف PPTX.
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


## **الأسئلة الشائعة**

**هل يتم دعم التجميع المتداخل (مجموعة داخل مجموعة)؟**

نعم. يحتوي [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) على خاصية [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/) التي تشير مباشرة إلى دعم التسلسل الهرمي (يمكن أن تكون المجموعة فرعًا لمجموعة أخرى).

**كيف يمكنني التحكم بترتيب z للمجموعة بالنسبة للكائنات الأخرى على الشريحة؟**

استخدم خاصية [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/) الخاصة بـ [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) لفحص موقعها في طبقة العرض.

**هل يمكنني منع التحريك/التعديل/إلغاء التجميع؟**

نعم. يتم توفير قسم القفل للمجموعة عبر [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/)، والذي يتيح لك تقييد العمليات على الكائن.
