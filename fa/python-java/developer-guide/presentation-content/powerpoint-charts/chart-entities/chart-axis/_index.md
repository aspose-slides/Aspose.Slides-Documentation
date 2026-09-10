---
title: سفارشی‌سازی محورها در نمودارهای ارائه با Python
linktitle: محور نمودار
type: docs
url: /fa/python-java/chart-axis/
keywords:
- محور نمودار
- محور عمودی
- محور افقی
- سفارشی‌سازی محور
- دست‌کاری محور
- مدیریت محور
- ویژگی‌های محور
- حداکثر مقدار
- حداقل مقدار
- خط محور
- قالب تاریخ
- عنوان محور
- موقعیت محور
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید از Aspose.Slides برای Python از طریق Java برای سفارشی‌سازی محورها در نمودارهای ارائه PowerPoint جهت گزارش‌ها و بصری‌سازی‌ها استفاده کنید."
---
## **بررسی کلی**

این مقاله نحوهٔ سفارشی‌سازی محورهای نمودار در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه مقادیر واقعی محور را به‌دست آورید، داده‌ها را بین محورها جابجا کنید، محور عمودی یا افقی را برای نمودارهای خطی مخفی کنید، نوع محور رده‌ای را تغییر دهید، قالب تاریخ برای مقادیر محور رده‌ای را تنظیم کنید، عنوان محوری را چرخاند، موقعیت محور را تنظیم کنید و واحد نمایش محور مقدار را تعیین کنید.

## **دریافت مقادیر حداکثر در محور عمودی یک نمودار**

Aspose.Slides for Python via Java به شما امکان می‌دهد حداقل و حداکثر مقادیر در یک محور عمودی را به‌دست آورید. مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید.
1. مقدار حداکثر واقعی محور را دریافت کنید.
1. مقدار حداقل واقعی محور را دریافت کنید.
1. واحد اصلی واقعی محور را دریافت کنید.
1. واحد فرعی واقعی محور را دریافت کنید.
1. مقیاس واحد اصلی واقعی محور را دریافت کنید.
1. مقیاس واحد فرعی واقعی محور را دریافت کنید.

این قطعه کد نمونه—یک پیاده‌سازی از مراحل بالا—نحوهٔ دریافت مقادیر مورد نیاز را در Python نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    # ارائه را ذخیره می‌کند
    presentation.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **جابه‌جایی داده‌ها بین محورها**

Aspose.Slides به شما امکان می‌دهد داده‌ها را به سرعت بین محورها جابه‌جا کنید—داده‌های نشان‌داده‌شده در محور عمودی (y-axis) به محور افقی (x-axis) و بالعکس منتقل می‌شوند.

این کد Python نشان می‌دهد چگونه می‌توان عملیات جابه‌جایی داده‌ها بین محورهای یک نمودار را انجام داد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)

    # داده‌های پیش‌فرض نمودار را در workbook بارگذاری می‌کند — متد switchRowColumn کاربرگ را جای‌گذاری می‌کند،
    # بنابراین ابتدا باید پر شود
    workbook = chart.getChartData().getChartDataWorkbook()

    # سطرها و ستون‌ها را جابجا می‌کند
    chart.getChartData().switchRowColumn()

    # ارائه را ذخیره می‌کند
    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **غیرفعال‌سازی محور عمودی برای نمودارهای خطی**

این کد Python نشان می‌دهد چگونه می‌توانید محور عمودی یک نمودار خطی را مخفی کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **غیرفعال‌سازی محور افقی برای نمودارهای خطی**

این کد نشان می‌دهد چگونه می‌توانید محور افقی یک نمودار خطی را مخفی کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تغییر محور رده‌ای**

با استفاده از متد [setCategoryAxisType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/axis/#setCategoryAxisType) می‌توانید نوع محور رده‌ای دلخواه خود (**date** یا **text**) را تعیین کنید. این کد در Python این عملیات را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        if isinstance(chart, Chart):
            chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
            chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
            chart.getAxes().getHorizontalAxis().setMajorUnit(1)
            chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)
            presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
        else:
            print("The first shape is not a chart.")
    else:
        print("The presentation has no first shape to update.")
finally:
    presentation.dispose()
```

## **تنظیم قالب تاریخ برای مقادیر محور رده‌ای**

Aspose.Slides for Python via Java به شما امکان می‌دهد قالب تاریخ برای یک مقدار محور رده‌ای را تنظیم کنید. این عملیات در کد Python زیر نشان داده شده است:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

from datetime import datetime

def convert_to_oa_date(date):
    base_date = datetime(1899, 12, 30)
    return (date - base_date).total_seconds() / 86400


presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()
    category_date = datetime(2015, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A2", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2016, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A3", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2017, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A4", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2018, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A5", category_value)
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    value_cell = workbook.getCell(0, "B2", 1.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 2.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 3.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 4.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم زاویه چرخش برای عنوان محور یک نمودار**

Aspose.Slides for Python via Java به شما امکان می‌دهد زاویهٔ چرخش برای عنوان محور یک نمودار را تنظیم کنید. این کد Python این عملیات را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم موقعیت محور بر روی یک محور رده‌ای یا مقداردهی**

Aspose.Slides for Python via Java به شما امکان می‌دهد موقعیت محور را بر روی یک محور رده‌ای یا مقداردهی تنظیم کنید. این کد Python نشان می‌دهد چگونه می‌توان این کار را انجام داد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم واحد نمایش بر روی محور مقدار یک نمودار**

Aspose.Slides for Python via Java به شما امکان می‌دهد واحد نمایش یک محور مقدار نمودار را تنظیم کنید. سپس محور برچسب‌های تیک خود را بر اساس آن واحد مقیاس می‌دهد: با [DisplayUnitType.Millions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/displayunittype/#Millions)، محور که تا 60,000,000 می‌رود به صورت 0 تا 60 برچسب‌گذاری می‌شود. این کد Python این عملیات را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سوالات متداول**

**چگونه مقدار نقطهٔ تقاطع یک محور با محور دیگر (axis crossing) را تعیین کنم؟**

محورها یک [crossing setting](https://reference.aspose.com/slides/fa/python-java/aspose.slides/axis/#setCrossType) دارند: می‌توانید انتخاب کنید که در صفر، در حداکثر رده/مقدار یا در یک مقدار عددی خاص تقاطع کنند. این برای جابجایی محور X به بالا یا پایین یا برای تأکید بر یک خط پایه مفید است.

**چگونه می‌توانم موقعیت علامت‌های تیک را نسبت به محور (crossing, outside, inside) تنظیم کنم؟**

[موقعیت علامت تیک](https://reference.aspose.com/slides/fa/python-java/aspose.slides/axis/#setMajorTickMark) را به "cross"، "outside" یا "inside" تنظیم کنید. این بر قابلیت خواندن تأثیر می‌گذارد و به‌ویژه در نمودارهای کوچک، فضا را حفظ می‌کند.