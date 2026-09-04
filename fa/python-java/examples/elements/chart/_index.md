---
title: نمودار
type: docs
weight: 60
url: /fa/python-java/examples/elements/chart/
keywords:
- نمودار
- افزودن نمودار
- دسترسی به نمودار
- حذف نمودار
- به‌روزرسانی نمودار
- نمونه کد
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "ایجاد، دسترسی، حذف و به‌روزرسانی نمودارها در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Python از طریق Java."
---
این مقاله نحوه افزودن، دسترسی، حذف و به‌روزرسانی نمودارها در یک ارائه با استفاده از **Aspose.Slides for Python via Java** را نشان می‌دهد.

پکیج را همان‌طور که در [Installation](/slides/fa/python-java/installation/) توضیح داده شده است نصب کنید. هر مثال قبل از شروع JVM، `asposeslides` را وارد می‌کند و سپس پس از اجرای JVM، API را وارد می‌کند. برای مثال‌های بعدی ابتدا مثال افزودن را اجرا کنید تا `chart.pptx` ایجاد شود.

## **افزودن یک نمودار**

یک نمودار مساحت را به اولین اسلاید اضافه کنید و ارائه را ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # افزودن یک نمودار مساحت به اسلاید اول.
    chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **دسترسی به یک نمودار**

نمودار اول را در مجموعهٔ اشکال روی اولین اسلاید پیدا کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # دسترسی به اولین نمودار در اسلاید.
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

## **حذف یک نمودار**

نمودار اول را از اسلاید حذف کنید و ارائهٔ اصلاح شده را ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # یافتن و حذف اولین نمودار در اسلاید.
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

## **به‌روزرسانی داده‌های نمودار**

عنوان نمودار را نمایش دهید، متن آن را تغییر دهید و ارائهٔ به‌روزشده را ذخیره کنید.

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # یافتن اولین نمودار در اسلاید.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        # نمایش عنوان نمودار و تغییر متن آن.
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Sales Report")
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```