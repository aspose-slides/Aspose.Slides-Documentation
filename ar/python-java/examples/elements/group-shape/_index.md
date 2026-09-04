---
title: مجموعة الأشكال
type: docs
weight: 170
url: /ar/python-java/examples/elements/group-shape/
keywords:
- مثال شفرة
- مجموعة الأشكال
- إضافة مجموعة أشكال
- الوصول إلى مجموعة أشكال
- إزالة مجموعة أشكال
- إلغاء تجميع الأشكال
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إدارة مجموعات الأشكال في العروض التقديمية باستخدام Aspose.Slides for Python via Java: إضافة، وصول، إزالة، وإلغاء تجميع الأشكال في ملفات PowerPoint و OpenDocument."
---
توضح هذه المقالة كيفية إنشاء مجموعات من الأشكال، والوصول إليها، وإزالتها، وإلغاء تجميع محتوياتها باستخدام **Aspose.Slides for Python via Java**.

قم بتثبيت الحزمة كما هو موضح في [Installation](/slides/ar/python-java/installation/). كل مثال يستورد `asposeslides` قبل تشغيل JVM، ثم يستورد الـ API بعد تشغيل JVM.

## **إضافة شكل مجموعة**

إنشاء مجموعة تحتوي على شكلين أساسيين.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)
    group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50)
finally:
    presentation.dispose()
```

## **الوصول إلى شكل مجموعة**

استرداد شكل المجموعة الأول من الشريحة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    first_group = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, GroupShape):
            first_group = shape
            break
finally:
    presentation.dispose()
```

## **إزالة شكل مجموعة**

حذف شكل مجموعة من الشريحة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()

    slide.getShapes().remove(group)
finally:
    presentation.dispose()
```

## **إلغاء تجميع الأشكال**

نقل شكل خارج حاوية المجموعة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    rectangle = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    # نقل الشكل خارج المجموعة.
    slide.getShapes().addClone(rectangle)
    group.getShapes().remove(rectangle)
finally:
    presentation.dispose()
```