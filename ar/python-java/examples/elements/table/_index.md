---
title: جدول
type: docs
weight: 120
url: /ar/python-java/examples/elements/table/
keywords:
- مثال على الكود
- جدول
- إضافة جدول
- الوصول إلى جدول
- إزالة جدول
- دمج خلايا
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "العمل مع الجداول في Aspose.Slides للـ Python عبر Java: إضافة، وصول، إزالة، ودمج خلايا في عروض PowerPoint و OpenDocument."
---
أمثلة لإضافة الجداول، والوصول إليها، وإزالتها، ودمج الخلايا باستخدام **Aspose.Slides for Python via Java**.

قم بتثبيت الحزمة كما هو موضح في [التثبيت](/slides/ar/python-java/installation/). كل مثال يستورد `asposeslides` قبل بدء JVM، ثم يستورد واجهة برمجة التطبيقات بعد تشغيل JVM.

## **إضافة جدول**

إنشاء جدول بسيط بصفين وعمودين.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)
finally:
    presentation.dispose()
```

## **الوصول إلى جدول**

استرجاع أول شكل جدول على الشريحة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    # الوصول إلى أول جدول على الشريحة.
    first_table = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Table):
            first_table = shape
            break
finally:
    presentation.dispose()
```

## **إزالة جدول**

حذف جدول من شريحة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    slide.getShapes().remove(table)
finally:
    presentation.dispose()
```

## **دمج خلايا الجدول**

دمج الخلايا المتجاورة في جدول لتصبح خلية واحدة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    # دمج الخلايا.
    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), False)
finally:
    presentation.dispose()
```