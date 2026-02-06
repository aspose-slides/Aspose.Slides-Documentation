---
title: مجموعة شكل
type: docs
weight: 170
url: /ar/python-net/examples/elements/group-shape/
keywords:
- مجموعة
- إضافة مجموعة شكل
- الوصول إلى مجموعة شكل
- إزالة مجموعة شكل
- فك تجميع الأشكال
- أمثلة على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "العمل مع مجموعات الأشكال في بايثون باستخدام Aspose.Slides: إنشاء وفك تجميع، إعادة ترتيب الأشكال الفرعية، ضبط التحولات والحدود عبر PowerPoint وOpenDocument."
---
أمثلة لإنشاء مجموعات من الأشكال، الوصول إليها، إلغاء التجميع، وإزالتها باستخدام **Aspose.Slides for Python via .NET**.

## **إضافة مجموعة شكل**

إنشاء مجموعة تحتوي على شكلين أساسيين.

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # إضافة مجموعة شكل.
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى مجموعة شكل**

استرجاع الشكل الجماعي الأول من الشريحة.

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # الوصول إلى مجموعة الشكل الأولى على الشريحة.
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **إزالة مجموعة شكل**

حذف مجموعة شكل من الشريحة.

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # بافتراض أن الشكل الأول هو مجموعة شكل.
        group = slide.shapes[0]

        # إزالة مجموعة الشكل.
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **إلغاء تجميع الأشكال**

نقل الأشكال خارج حاوية المجموعة.

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # بافتراض أن الشكل الأول هو مجموعة شكل.
        group = slide.shapes[0]

        # نقل الأشكال خارج المجموعة.
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```