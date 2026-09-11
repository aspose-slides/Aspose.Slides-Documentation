---
title: أشكال العروض التقديمية المجمعة في Python عبر Java
linktitle: مجموعة الشكل
type: docs
weight: 40
url: /ar/python-java/group/
keywords:
- شكل مجموعة
- مجموعة الأشكال
- إضافة مجموعة
- نص بديل
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية تجميع وفك تجميع الأشكال في عروض PowerPoint باستخدام Aspose.Slides لـ Python عبر Java—دليل خطوة بخطوة مع شفرة Python مجانية."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية العمل مع أشكال المجموعات في Aspose.Slides. توضح كيفية إضافة شكل مجموعة إلى شريحة، وضع أشكال داخلها، وحفظ العرض التقديمي المحدث. كما تُظهر كيفية الوصول إلى الأشكال المخزنة داخل مجموعة وقراءة النص البديل لها باستخدام [getAlternativeText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getAlternativeText). بالإضافة إلى ذلك، تغطي المقالة باختصار قدرات أشكال المجموعات ذات الصلة مثل المجموعات المتداخلة، وترتيب z، وخيارات القفل.

## **إضافة شكل مجموعة**

يدعم Aspose.Slides العمل مع أشكال المجموعات على الشرائح. تساعد هذه الميزة المطورين على إنشاء عروض تقديمية أغنى. يدعم Aspose.Slides for Python via Java إضافة والوصول إلى أشكال المجموعات. يمكنك ملء شكل مجموعة بأشكال أو الوصول إلى خصائصه. لإضافة شكل مجموعة إلى شريحة باستخدام Aspose.Slides for Python via Java:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بواسطة فهرسها.
1. إضافة شكل مجموعة إلى الشريحة.
1. إضافة أشكال إلى شكل المجموعة.
1. حفظ العرض التقديمي المعدل كملف PPTX.

المثال أدناه يضيف شكل مجموعة إلى شريحة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

# إنشاء كائن من الفئة Presentation.
presentation = Presentation()
try:
    # الحصول على الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # الوصول إلى مجموعة أشكال الشريحة.
    slide_shapes = slide.getShapes()

    # إضافة شكل مجموعة إلى الشريحة.
    group_shape = slide_shapes.addGroupShape()

    # إضافة أشكال داخل شكل المجموعة.
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

    # تعيين إطار شكل المجموعة.
    group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
    group_shape.setFrame(group_frame)

    # كتابة ملف PPTX إلى القرص.
    presentation.save("GroupShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الوصول إلى النص البديل**

توضح هذه الفقرة كيفية الوصول إلى النص البديل للأشكال داخل مجموعة على شريحة. للوصول إلى هذا النص باستخدام Aspose.Slides for Python via Java:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) التي تمثل ملف PPTX.
1. الحصول على مرجع إلى شريحة بواسطة فهرسها.
1. الوصول إلى مجموعة أشكال الشريحة.
1. الوصول إلى شكل المجموعة.
1. قراءة النص البديل لأشكاله باستخدام [getAlternativeText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getAlternativeText).

المثال أدناه يصل إلى النص البديل للأشكال داخل مجموعة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation

# إنشاء كائن من الفئة Presentation الذي يمثل ملف PPTX.
presentation = Presentation("AltText.pptx")
try:
    # الحصول على الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # الوصول إلى شكل في مجموعة أشكال الشريحة.
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # الوصول إلى الأشكال داخل المجموعة.
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # قراءة النص البديل.
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **FAQ**

**هل يتم دعم التجميع المتداخل (مجموعة داخل مجموعة)؟**

نعم. يحتوي [GroupShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/groupshape/) على طريقة [getParentGroup](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getParentGroup) التي تشير إلى دعم الهرمية: يمكن أن تكون المجموعة طفلاً لمجموعة أخرى.

**كيف يمكنني التحكم في ترتيب z للمجموعة بالنسبة للكائنات الأخرى على الشريحة؟**

استخدم طريقة [getZOrderPosition](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getZOrderPosition) لكائن [GroupShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/groupshape/) لتفقد موقعه في مكدس العرض.

**هل يمكنني منع النقل أو التحرير أو فك التجميع؟**

نعم. يتم كشف أقفال المجموعة عبر [getGroupShapeLock](https://reference.aspose.com/slides/ar/python-java/aspose.slides/groupshape/#getGroupShapeLock)، مما يتيح لك تقييد العمليات على الكائن.