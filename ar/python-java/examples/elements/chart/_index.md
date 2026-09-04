---
title: مخطط
type: docs
weight: 60
url: /ar/python-java/examples/elements/chart/
keywords:
- مخطط
- إضافة مخطط
- الوصول إلى مخطط
- إزالة مخطط
- تحديث مخطط
- أمثلة على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إنشاء، والوصول، وإزالة، وتحديث المخططات في عروض PowerPoint وOpenDocument التقديمية باستخدام Aspose.Slides للغة Python عبر Java."
---
توضح هذه المقالة كيفية إضافة المخططات، الوصول إليها، إزالتها، وتحديثها في عرض تقديمي باستخدام **Aspose.Slides for Python via Java**.

قم بتثبيت الحزمة كما هو موضح في [Installation](/slides/ar/python-java/installation/). كل مثال يستورد `asposeslides` قبل بدء الـ JVM، ثم يستورد واجهة البرمجة بعد تشغيل الـ JVM. شغّل مثال الإضافة أولاً لإنشاء `chart.pptx` للأمثلة المتبقية.

## **إضافة مخطط**

أضف مخطط منطقة إلى الشريحة الأولى واحفظ العرض التقديمي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # أضف مخطط منطقة إلى الشريحة الأولى.
    chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الوصول إلى مخطط**

ابحث عن أول مخطط في مجموعة الأشكال على الشريحة الأولى.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # الوصول إلى أول مخطط على الشريحة.
    first_chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            first_chart = shape
            break

    if first_chart is None:
        print("The first slide contains no charts.")
finally:
    presentation.dispose()
```

## **إزالة مخطط**

أزل أول مخطط من الشريحة واحفظ العرض التقديمي المعدل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # ابحث وأزل أول مخطط على الشريحة.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        slide.getShapes().remove(chart)
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تحديث بيانات المخطط**

اعرض عنوان المخطط، غير نصه، واحفظ العرض التقديمي المحدث.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # ابحث عن أول مخطط على الشريحة.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        # اعرض عنوان المخطط وغيّر نصه.
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Sales Report")
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```