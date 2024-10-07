---
title: مجموعة
type: docs
weight: 40
url: /python-net/group/
keywords: "شكل مجموعة، شكل PowerPoint، عرض PowerPoint، Python، Aspose.Slides لـ Python عبر .NET"
description: "إضافة شكل مجموعة إلى عرض PowerPoint باستخدام Python"
---

## **إضافة شكل مجموعة**
يدعم Aspose.Slides العمل مع أشكال المجموعات على الشرائح. تساعد هذه الميزة المطورين على دعم عروض تقديمية أكثر تنوعًا. كما يدعم Aspose.Slides لـ Python عبر .NET إضافة أو الوصول إلى أشكال المجموعات. من الممكن إضافة أشكال إلى شكل مجموعة مُضاف لتعبئته أو الوصول إلى أي خاصية من خصائص شكل المجموعة. لإضافة شكل مجموعة إلى شريحة باستخدام Aspose.Slides لـ Python عبر .NET:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع شريحة باستخدام فهرسها.
1. إضافة شكل مجموعة إلى الشريحة.
1. إضافة الأشكال إلى شكل المجموعة المُضاف.
1. حفظ العرض المعدل كملف PPTX.

المثال أدناه يضيف شكل مجموعة إلى شريحة.

```py
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation 
with slides.Presentation() as pres:
    # الحصول على الشريحة الأولى 
    sld = pres.slides[0]

    # الوصول إلى مجموعة الأشكال في الشرائح 
    slideShapes = sld.shapes

    # إضافة شكل مجموعة إلى الشريحة 
    groupShape = slideShapes.add_group_shape()

    # إضافة أشكال داخل شكل المجموعة المُضاف 
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # إضافة إطار شكل المجموعة 
    groupShape.frame = slides.ShapeFrame(100, 300, 500, 40, -1, -1, 0)

    # كتابة ملف PPTX إلى القرص 
    pres.save("GroupShape_out.pptx", slides.export.SaveFormat.PPTX)
```



## **الوصول إلى خاصية AltText**
تظهر هذه الموضوعات خطوات بسيطة، مكتملة بأمثلة الكود، لإضافة شكل مجموعة والوصول إلى خاصية AltText لأشكال المجموعات على الشرائح. للوصول إلى AltText لشكل مجموعة في شريحة باستخدام Aspose.Slides لـ Python عبر .NET:

1. إنشاء مثيل لفئة `Presentation` التي تمثل ملف PPTX.
1. الحصول على مرجع شريحة باستخدام فهرسها.
1. الوصول إلى مجموعة الأشكال في الشرائح.
1. الوصول إلى شكل المجموعة.
1. الوصول إلى خاصية AltText.

المثال أدناه يصل إلى النص البديل لشكل المجموعة.

```py
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation التي تمثل ملف PPTX
with slides.Presentation(path + "AltText.pptx") as pres:

    # الحصول على الشريحة الأولى
    sld = pres.slides[0]

    for i in range(len(sld.shapes)):
        # الوصول إلى مجموعة الأشكال في الشرائح
        shape = sld.shapes[i]

        if type(shape) is slides.GroupShape:
            # الوصول إلى شكل المجموعة.
            for j in range(len(shape.shapes)):
                # الوصول إلى خاصية AltText
                print(shape.shapes[j].alternative_text)
```