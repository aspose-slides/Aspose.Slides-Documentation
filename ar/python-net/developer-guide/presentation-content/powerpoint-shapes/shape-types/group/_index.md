---
title: تجميع أشكال العروض التقديمية باستخدام بايثون
linktitle: مجموعة الشكل
type: docs
weight: 40
url: /ar/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-types/group/
keywords:
- شكل مجموعة
- مجموعة الشكل
- إضافة مجموعة
- نص بديل
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية تجميع وإلغاء تجميع الأشكال في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Python—دليل سريع خطوة بخطوة مع كود مجاني."
---

## **نظرة عامة**

يتيح تجميع الأشكال التعامل مع عدة كائنات رسم كوحدة واحدة بحيث يمكنك تحريكها، تعديل حجمها، تنسيقها، وتحويلها معًا. باستخدام Aspose.Slides for Python، يمكنك إنشاء [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)، إضافة وتنسيق أشكال فرعية داخلها، وحفظ النتيجة كملف PPTX. تُظهر هذه المقالة كيفية إضافة شكل مجموعة إلى شريحة وكيفية الوصول إلى بيانات التعريف الخاصة بإمكانية الوصول مثل النص البديل من الأشكال داخل المجموعة، مما يتيح بنية أكثر نظافة وعروضًا تقديمية أكثر ثراءً وسهولة في الصيانة.

## **إضافة أشكال المجموعة**

يدعم Aspose.Slides العمل مع أشكال المجموعة على الشريحة. تتيح هذه الميزة بناء عروض تقديمية أغنى من خلال التعامل مع عدة أشكال ككائن واحد. يمكنك إضافة أشكال مجموعة جديدة، الوصول إلى الموجودة منها، تعبئتها بأشكال فرعية، وقراءة أو تعديل أي من خصائصها. لإضافة شكل مجموعة إلى شريحة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى شريحة وفق الفهرس.
3. إضافة [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) إلى الشريحة.
4. إضافة أشكال إلى شكل المجموعة الجديد.
5. حفظ العرض التقديمي المعدل كملف PPTX.

يوضح المثال أدناه كيفية إضافة شكل مجموعة إلى شريحة.

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add a group shape to the slide.
    group_shape = slide.shapes.add_group_shape()

    # Add shapes inside the group shape.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Write the PPTX file to disk.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى خاصية النص البديل**

تشرح هذه الفقرة كيفية قراءة النص البديل للأشكال الموجودة داخل شكل مجموعة على شريحة باستخدام Aspose.Slides. للوصول إلى النص البديل للأشكال:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لتمثيل ملف PPTX.
2. الحصول على مرجع إلى الشريحة وفق الفهرس.
3. الوصول إلى مجموعة أشكال الشريحة.
4. الوصول إلى [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/).
5. قراءة خاصية النص البديل.

يعرض المثال أدناه كيفية استرجاع النص البديل للأشكال الموجودة داخل أشكال المجموعة.

```py
import aspose.slides as slides

# Instantiate the Presentation class to open the PPTX file.
with slides.Presentation("group_shape.pptx") as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Access the group shape.
            for child_shape in shape.shapes:
                # Access the Alt Text property.
                print(child_shape.alternative_text)
```

## **الأسئلة المتكررة**

**هل يتم دعم التجميع المتداخل (مجموعة داخل مجموعة)؟**

نعم. يحتوي [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) على خاصية [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/) التي تشير مباشرةً إلى دعم الهرمية (يمكن أن تكون المجموعة فرعية لمجموعة أخرى).

**كيف يمكن التحكم بترتيب z للمجموعة مقارنةً بالكائنات الأخرى على الشريحة؟**

استخدم خاصية [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/) الخاصة بـ [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) لفحص أو تغيير موضعها في مكدس العرض.

**هل يمكن منع التحريك/التعديل/إلغاء التجميع؟**

نعم. يتم كشف قسم القفل للمجموعة عبر [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/)، مما يتيح لك تقييد العمليات على الكائن.