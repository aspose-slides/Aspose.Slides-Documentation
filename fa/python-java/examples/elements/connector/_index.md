---
title: کانکتور
type: docs
weight: 190
url: /fa/python-java/examples/elements/connector/
keywords:
- مثال کد
- کانکتور
- اضافه کردن کانکتور
- دسترسی به کانکتور
- حذف کانکتور
- اتصال مجدد اشکال
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "نحوه افزودن، دسترسی، حذف و اتصال مجدد اشکال با کانکتورها را با استفاده از Aspose.Slides برای Python از طریق Java در ارائه‌های PPT، PPTX و ODP یاد بگیرید."
---
این مقاله نشان می‌دهد که چگونه اشکال را با کانکتورها وصل کنید و هدف‌های آن‌ها را با استفاده از **Aspose.Slides for Python via Java** تغییر دهید.

پکیج را همان‌طور که در [Installation](/slides/fa/python-java/installation/) توضیح داده شده است، نصب کنید. هر مثال قبل از راه‌اندازی JVM، `asposeslides` را ایمپورت می‌کند و سپس پس از اجرا شدن JVM، API را ایمپورت می‌نماید.

## **اضافه کردن یک کانکتور**

یک شکل کانکتور را بین دو نقطه روی اسلاید درج کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)
finally:
    presentation.dispose()
```

## **دسترسی به یک کانکتور**

اولین شکل کانکتور اضافه‌شده به اسلاید را بازیابی کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Connector, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    # دسترسی به اولین کانکتور در اسلاید.
    connector = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Connector):
            connector = shape
            break
finally:
    presentation.dispose()
```

## **حذف یک کانکتور**

یک کانکتور را از اسلاید حذف کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    slide.getShapes().remove(connector)
finally:
    presentation.dispose()
```

## **اتصال مجدد اشکال**

یک کانکتور را به دو شکل متصل کنید با تعیین هدف‌های شروع و پایان.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)
    shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 50, 50)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    connector.setStartShapeConnectedTo(shape1)
    connector.setEndShapeConnectedTo(shape2)
finally:
    presentation.dispose()
```