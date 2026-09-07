---
title: جدول
type: docs
weight: 120
url: /fa/python-java/examples/elements/table/
keywords:
- مثال کد
- جدول
- افزودن جدول
- دسترسی به جدول
- حذف جدول
- ترکیب سلول‌ها
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "کار با جداول در Aspose.Slides برای Python از طریق Java: افزودن، دسترسی، حذف و ترکیب سلول‌ها در ارائه‌های PowerPoint و OpenDocument."
---
نمونه‌هایی برای افزودن جداول، دسترسی به آن‌ها، حذف آن‌ها و ترکیب سلول‌ها با استفاده از **Aspose.Slides for Python via Java**.

پکیج را همان‌طور که در [Installation](/slides/fa/python-java/installation/) توضیح داده شده نصب کنید. هر مثال قبل از راه‌اندازی JVM، `asposeslides` را وارد می‌کند و سپس پس از اجرای JVM، API را وارد می‌کند.

## **Add a Table**
یک جدول ساده با دو ردیف و دو ستون ایجاد کنید.

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

## **Access a Table**
شکل اولین جدول را در اسلاید بازیابی کنید.

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

    # دسترسی به اولین جدول در اسلاید.
    first_table = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Table):
            first_table = shape
            break
finally:
    presentation.dispose()
```

## **Remove a Table**
یک جدول را از اسلاید حذف کنید.

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

## **Merge Table Cells**
سلول‌های مجاور یک جدول را به یک سلول واحد ترکیب کنید.

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

    # ترکیب سلول‌ها.
    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), False)
finally:
    presentation.dispose()
```