---
title: أشكال مجموعة العرض التقديمي باستخدام Python
linktitle: مجموعة الأشكال
type: docs
weight: 40
url: /ar/python-net/group/
keywords:
- شكل مجموعة
- مجموعة الأشكال
- إضافة مجموعة
- نص بديل
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلّم كيفية تجميع وإلغاء تجميع الأشكال في عروض PowerPoint ومستندات OpenDocument باستخدام Aspose.Slides للـ Python — دليل سريع خطوة بخطوة مع كود مجاني."
---

## **نظرة عامة**

يتيح تجميع الأشكال معالجتها ككائن واحد، مما يسمح لك بنقلها، تعديل حجمها، تنسيقها وتحويلها معًا. باستخدام Aspose.Slides للـ Python، يمكنك إنشاء [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)، إضافة وترتيب الأشكال الفرعية داخله، وحفظ النتيجة كملف PPTX. توضح هذه المقالة كيفية إضافة شكل مجموعة إلى شريحة وكيفية الوصول إلى بيانات التعريف الخاصة بإمكانية الوصول مثل النص البديل من الأشكال داخل المجموعة، مما يساهم في بنية أنظف وعروض تقديمية أكثر ثراءً وسهولة في الصيانة.

## **إضافة أشكال مجموعة**

يدعم Aspose.Slides العمل مع أشكال المجموعة على الشريحة. تتيح لك هذه الميزة إنشاء عروض تقديمية أغنى من خلال معالجة عدة أشكال ككائن واحد. يمكنك إضافة أشكال مجموعة جديدة، الوصول إلى الموجودة منها، ملء المجموعة بأشكال فرعية، وقراءة أو تعديل أي من خصائصها. لإضافة شكل مجموعة إلى شريحة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى شريحة عن طريق الفهرس.
3. إضافة [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) إلى الشريحة.
4. إضافة أشكال إلى شكل المجموعة الجديد.
5. حفظ العرض التقديمي المعدل كملف PPTX.

يُظهر المثال أدناه كيفية إضافة شكل مجموعة إلى شريحة.

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
2. الحصول على مرجع إلى الشريحة باستخدام فهرسها.
3. الوصول إلى مجموعة أشكال الشريحة.
4. الوصول إلى [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/).
5. قراءة خاصية النص البديل.

المثال أدناه يستخرج النص البديل للأشكال الموجودة داخل أشكال المجموعة.

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

**هل يدعم التجميع المتداخل (مجموعة داخل مجموعة)؟**

نعم. يحتوي [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) على خاصية [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/) التي تشير مباشرة إلى دعم الهرمية (يمكن أن تكون مجموعة فرعية لمجموعة أخرى).

**كيف يمكن التحكم بترتيب Z للمجموعة بالنسبة للكائنات الأخرى على الشريحة؟**

استخدم خاصية [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/) الخاصة بـ [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) لفحص أو تعديل موقعها في مكدس العرض.

**هل يمكنني منع التحريك/التعديل/إلغاء التجميع؟**

نعم. يتم الكشف عن قسم القفل للمجموعة عبر [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/)، مما يتيح لك تقييد العمليات على الكائن.