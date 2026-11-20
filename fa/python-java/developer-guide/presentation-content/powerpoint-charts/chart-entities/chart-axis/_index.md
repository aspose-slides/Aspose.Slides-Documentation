---
title: "سفارشی‌سازی محورها در نمودارها در ارائه‌ها با استفاده از پایتون"
linktitle: "محور نمودار"
type: docs
url: /fa/python-java/chart-axis/
keywords:
- "محور نمودار"
- "محور عمودی"
- "محور افقی"
- "سفارشی‌سازی محور"
- "دستکاری محور"
- "مدیریت محور"
- "ویژگی‌های محور"
- "حداکثر مقدار"
- "حداقل مقدار"
- "خط محور"
- "قالب تاریخ"
- "عنوان محور"
- "موقعیت محور"
- "PowerPoint"
- "ارائه"
- "Python"
- "Aspose.Slides"
description: "کشف کنید چگونه از Aspose.Slides برای پایتون از طریق جاوا برای سفارشی‌سازی محورها در نمودارها در ارائه‌های PowerPoint برای گزارش‌ها و تجسم‌ها استفاده کنید."
---
## **مرور کلی**

این مقاله توضیح می‌دهد چگونه محورها را در نمودار با Aspose.Slides برای Python از طریق Java سفارشی کنید. این مقاله به مقادیر محاسبه‌شده محور، تعویض سطرها و ستون‌های نمودار، قابلیت مشاهده محور، فواصل برچسب‌های دسته‌بندی و علامت‌گذاری، دسته‌بندی‌های تاریخ و قالب‌بندی، چرخش عنوان، موقعیت محور، واحدهای نمایش، و مقیاس لگاریتمی می‌پردازد.

## **دریافت مقادیر بیشینه برای محور عمودی یک نمودار**

یک [ارائه](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید و یک نمودار ناحیه‌ای با داده‌های پیش‌فرض اضافه کنید. قبل از خواندن مقادیر محاسبه‌شده محور، با فراخوانی [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) اطمینان حاصل کنید که طرح نمودار به‌روز باشد.

محدوده‌های محور را با خواندن [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) و [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) به‌دست آورید و فواصل علامت‌گذاری را با [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) و [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) دریافت کنید. [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) و [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) مقیاس‌های زمان‌واحد را فراهم می‌آورند که برای محورهاهای تاریخ مرتبط هستند. مثال این مقادیر را در متغیرهای محلی ذخیره کرده و نمودار را ذخیره می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **جابجایی داده‌ها بین محورها**

از [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) برای تعویض نقش سری‌ها و دسته‌ها در داده‌های نمودار استفاده کنید. هر دسته قبلی تبدیل به یک سری می‌شود و هر سری قبلی تبدیل به یک دسته. این تغییر در نحوهٔ گروه‌بندی داده‌ها اعمال می‌شود؛ محورهای افقی و عمودی را تعویض نمی‌کند. مثال از [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) برای اتصال داده‌های پیش‌فرض به `Sheet1!A1:D5`، شامل سطر سرصفحه و ستون دسته، قبل از تعویض سطرها و ستون‌ها استفاده می‌کند. سپس نموداری با چهار سری و سه دسته ذخیره می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)
    chart.getChartData().setRange("Sheet1!A1:D5")
    chart.getChartData().switchRowColumn()

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **معکوس کردن ترتیب رسم محور**

از [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) برای معکوس کردن یک محور دسته یا مقدار استفاده کنید. برای مثال، یک نمودار میله‌ای افقی می‌تواند مراحل پروژه را از بالا به پایین به همان ترتیب برگهٔ کاری نشان دهد: برنامه‌ریزی، توسعه، تست. معکوس کردن یک محور جهت رسم را تغییر می‌دهد؛ داده‌های ورک‌بوک را نمره‌گذاری یا دوباره‌چین نمی‌کند. برای مقایسه، [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) نقش سری‌ها و دسته‌ها را عوض می‌کند.

مثال زیر یک نمودار میله‌ای افقی با سه مرحله و یک سری ایجاد می‌کند. یک ارائه با سه اسلاید ذخیره می‌شود: ترتیب عادی، دسته‌های معکوس، و مقادیر معکوس. هر نسخه از همان دیتاست استفاده می‌کند و در هر نسخه تنها یک محور معکوس می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CrossesType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320)
    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredBar)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.getCell(0, i + 1, 0, stage)
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(values[i]))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # اسلاید ۲: نمایش اولین دسته در بالا.
    category_slide = presentation.getSlides().addClone(slide)
    category_chart = category_slide.getShapes().get_Item(0)
    category_chart.getAxes().getVerticalAxis().setPlotOrderReversed(True)
    # محور مقدار افقی را در پایین نگه دار.
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # اسلاید ۳: فقط مقیاس عددی افقی را معکوس کن.
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

معکوس کردن یک محور می‌تواند محور عمود را به سمت مخالف نمودار جابه‌جا کند. [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) تعیین می‌کند که محور دیگر در کجا محور تنظیم‌شده را قطع می‌کند. در اسلاید ۲، فراخوانی آن با [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) بر روی محور دسته معکوس، محور مقدار افقی را در پایین نگه می‌دارد. برای تعیین نقطهٔ قطع مشخص، از [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) استفاده کنید. هنگام تغییر جهت تنظیمات قطع را بررسی کنید، به‌ویژه اگر نمودار پیش‌از‌پیش نقطهٔ قطع سفارشی داشته باشد. برای بازگرداندن جهت رسم عادی، [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) را با `False` فراخوانی کنید؛ تنظیمات قطع مستقل هستند.

| ترتیب عادی (اسلاید 1) | دسته‌بندی‌های معکوس (اسلاید 2) | مقادیر معکوس (اسلاید 3) |
| --- | --- | --- |
| ![نمودار میله‌ای افقی با ترتیب عادی محور دسته‌بندی و مقدار](axis-order-normal.png) | ![نمودار میله‌ای افقی با نمایش دسته‌بندی‌ها از بالا به پایین](axis-order-categories-reversed.png) | ![نمودار میله‌ای افقی با محور مقدار معکوس و صفر در سمت راست](axis-order-values-reversed.png) |
| دسته‌بندی‌ها از پایین به بالا می‌روند؛ مقادیر از چپ به راست افزایش می‌یابند. | برنامه‌ریزی، توسعه و تست از بالا به پایین اجرا می‌شوند. مقادیر و ترتیب سطرهای ورک‌بوک تغییر نکرده‌اند. | دسته‌بندی‌ها ترتیب عادی خود را حفظ می‌کنند؛ مقادیر از راست به چپ افزایش می‌یابند. محور دسته‌بندی در صفر سمت راست عبور می‌کند. |

## **غیرفعال کردن محور عمودی برای نمودارهای خطی**

با فراخوانی [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) با `False` بر روی محور عمودی، آن را مخفی کنید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد کرده و آن را با محور عمودی مخفی ذخیره می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **غیرفعال کردن محور افقی برای نمودارهای خطی**

با فراخوانی [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) با `False` بر روی محور افقی، آن را مخفی کنید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد کرده و آن را با محور افقی مخفی ذخیره می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **نمایش یا مخفی کردن خطوط راهنمای نمودار**

از [getShowMajorGridLines](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getShowMajorGridLines) و [getShowMinorGridLines](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getShowMinorGridLines) برای بررسی اینکه کدام خطوط راهنما توسط یک محور نمایش داده می‌شوند، استفاده کنید. برای نمایش خطوط راهنمای جزئی، از [getMinorGridLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getMinorGridLinesFormat) استفاده کنید و پرشدن خط را به رنگی ثابت و قابل رؤیت تنظیم کنید. برای مخفی کردن آن‌ها، پرشدن را به [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/#NoFill) تغییر دهید. برای خطوط راهنمای اصلی نیز می‌توانید از [getMajorGridLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getMajorGridLinesFormat) به همان شکل استفاده کنید. تغییر پرشدن، قابلیت مشاهدهٔ محور و علامت‌های تیک را حفظ می‌کند.

محور عمودی این نمودار ستونی خوشه‌ای در ابتدا فقط خطوط راهنمای اصلی را نشان می‌دهد. مثال خطوط راهنمای جزئی را به رنگ نارنجی تیره نمایش می‌دهد، سپس قبل از ذخیرهٔ ارائه، دوباره آن‌ها را مخفی می‌کند. در هر مرحله وضعیت نمایش خطوط راهنما چاپ می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230)
    axis = chart.getAxes().getVerticalAxis()
    print(f"Initial: major={axis.getShowMajorGridLines()}, minor={axis.getShowMinorGridLines()}")

    minor_fill = axis.getMinorGridLinesFormat().getLine().getFillFormat()
    minor_fill.setFillType(FillType.Solid)
    minor_fill.getSolidFillColor().setColor(Color(255, 140, 0))
    print(f"Enabled: minor={axis.getShowMinorGridLines()}")

    minor_fill.setFillType(FillType.NoFill)
    print(f"Hidden: major={axis.getShowMajorGridLines()}, minor={axis.getShowMinorGridLines()}")

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| خطوط راهنمای جزئی فعال | خطوط راهنمای جزئی مخفی |
| --- | --- |
| ![خطوط راهنمای جزئی نارنجی بین خطوط راهنمای اصلی بر روی محور عمودی](minor-gridlines-enabled.png) | ![نمودار ستونی مشابه با تنها خطوط راهنمای اصلی قابل مشاهده](minor-gridlines-hidden.png) |

## **تغییر محور دسته‌بندی**

از [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) برای انتخاب یک محور دسته‌بندی تاریخ یا متن استفاده کنید. این مثال به فایل `ExistingChart.pptx` نیاز دارد که نمودار به‌عنوان اولین شکل در اولین اسلاید قرار دارد و سلول‌های دسته شامل مقادیر عددی تاریخ اکسل هستند. محور افقی به یک محور تاریخ تغییر می‌یابد. فراخوانی [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) با `False`، [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) با `1` و [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) با [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) علامت‌های اصلی را با فواصل یک‌ماهه قرار می‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().get_Item(0)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getHorizontalAxis().setMajorUnit(1)
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **تعیین نوع محور دسته‌بندی از داده‌ها**

پس از پرکردن دسته‌ها، [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisTypeAutomatically) را فراخوانی کنید و سپس با خواندن [getCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getCategoryAxisType) انتخاب را بررسی کنید. این روش زمانی مفید است که همان نمودار ممکن است برچسب‌های متنی یا مقادیر عددی تاریخ دریافت کند. متد در زمان فراخوانی نوع را تعیین می‌کند؛ حالت پایداری که بعداً تغییرات داده را دوباره ارزیابی کند فعال نمی‌کند. پس از جایگزینی دسته‌ها، دوباره آن را فراخوانی کنید.

مثال زیر یک نمودار با دسته‌های متنی ایجاد می‌کند و زمانی که نوع انتخابی [CategoryAxisType.Text](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Text) باشد `True` چاپ می‌شود. سپس مقادیر سلول‌های دسته را با تاریخ‌ها جایگزین می‌کند و مجدداً متد را فراخوانی می‌کند؛ وقتی نوع انتخابی [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date) باشد `True` چاپ می‌شود. تاریخ‌ها به‌صورت مقادیر عددی OLE Automation ذخیره می‌شوند که به‌عنوان تعداد روزها از 30 دسامبر 1899 محاسبه می‌شوند، نه به‌عنوان رشتهٔ تاریخ. [setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) کنترل می‌کند این مقادیر چگونه نمایش داده شوند؛ متن را به تاریخ عددی تبدیل نمی‌کند. برای اطلاعات بیشتر دربارهٔ سلول‌های دسته به [Chart Workbook](/slides/fa/python-java/chart-workbook/) مراجعه کنید.

از تعیین خودکار زمانی استفاده کنید که ورودی شناخته شده شامل دسته‌های متنی یا تاریخ‌های عددی باشد، همانند این مثال. برای برچسب‌های عددی معمولی، دسته‌های ترکیبی یا داده‌های خالی، صراحةً [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) را فراخوانی کنید تا معنای موردنظر اعمال شود. مقادیر عددی به تنهایی نشان نمی‌دهند که دسته‌ها نمایانگر تاریخ هستند.

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CategoryAxisType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series_name = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())
    labels = ["First", "Second", "Third"]

    for i, label in enumerate(labels):
        category_cell = workbook.getCell(0, i + 1, 0, label)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float((i + 1) * 10))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisTypeAutomatically()
    print(axis.getCategoryAxisType() == CategoryAxisType.Text)  # درست

    base_date = date(1899, 12, 30)
    dates = [date(2026, 1, 1), date(2026, 1, 2), date(2026, 2, 1)]

    for i, category_date in enumerate(dates):
        category_cell = workbook.getCell(0, i + 1, 0)
        category_cell.setValue(float((category_date - base_date).days))
        category_cell.setCustomNumberFormat("yyyy-mm-dd")

    axis.setCategoryAxisTypeAutomatically()
    print(axis.getCategoryAxisType() == CategoryAxisType.Date)  # درست

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **کنترل فواصل برچسب‌های محور دسته‌بندی**

هنگامی که نمودار دارای تعداد زیادی دسته باشد، برای کاهش تعداد برچسب‌های قابل مشاهدهٔ محور بدون حذف دسته‌ها یا نقاط داده می‌توانید فواصل برچسب‌ها را تنظیم کنید. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) را با `False` فراخوانی کنید و سپس فاصلهٔ دستهٔ موردنظر را به [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing) پاس بدهید. برای دسته‌های متنی در ترتیب عادی، شمارش از اولین دسته آغاز می‌شود:

| فاصله | برچسب‌های نمایش داده شده در مثال |
| --- | --- |
| `1` | دسته 1, دسته 2, دسته 3, ... دسته 24 |
| `2` | دسته 1, دسته 3, دسته 5, ... دسته 23 |
| `3` | دسته 1, دسته 4, دسته 7, ... دسته 22 |

فاصلهٔ `3` هر برچسب سوم را نمایش می‌دهد و دو برچسب بین برچسب‌های نمایش داده شده مخفی می‌ماند. این کار ستون‌های مربوطه را حذف نمی‌کند. فاصله‌دهی خودکار بر اساس فضای موجود یک فاصله انتخاب می‌کند؛ لزوماً همهٔ برچسب‌ها را نمایش نمی‌دهد.

علامت‌های تیک کنترل‌های جداگانه‌ای دارند. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) را با `False` فراخوانی کنید و از [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) برای تنظیم فاصلهٔ آن‌ها استفاده کنید. به عنوان مثال، `1` یک علامت تیک در هر فاصلهٔ دسته حفظ می‌کند در حالی که برچسب‌ها فقط هر سومین دسته نمایش داده می‌شوند. با تنظیم [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) به یک استایل قابل رؤیت می‌توانید نتیجه را ببینید. دوباره فراخوانی هر یک از تنظیم‌کننده‌های فاصله خودکار با `True` به نمودار اجازه می‌دهد که همان فاصله را خود انتخاب کند.

مثال زیر خودکفا ۲۴ دسته و یک سری ایجاد می‌کند، سپس سه اسلاید در `CategoryAxisIntervals.pptx` ذخیره می‌کند: فاصله خودکار، فاصلهٔ دستی برچسب با علامت‌های تیک مستقل، و بازگردانی فاصله خودکار. دو نسخهٔ کپی داده‌های اصلی نمودار را حفظ می‌کنند. نیازی به ارائهٔ ورودی نیست. متن برچسب افقی تفاوت چگالی را به‌وضوح نشان می‌دهد.

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType, TickMarkType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.setLegend(False)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn)
    for i in range(24):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(10 + i % 6 * 5))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisType(CategoryAxisType.Text)
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0)
    axis.getTextFormat().getPortionFormat().setFontHeight(12)
    axis.setMajorTickMark(TickMarkType.Outside)
    axis.setAutomaticTickLabelSpacing(True)
    axis.setAutomaticTickMarksSpacing(True)

    # اسلاید ۲: هر سومین برچسب را نشان بده، اما برای هر دسته یک علامت تیک حفظ کن.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # اسلاید ۳: بگذار نمودار دوباره هر دو فاصله را انتخاب کند.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**فضاگیری خودکار (اسلاید 1):** در این رندر، هر دومین برچسب دسته نمایش داده می‌شود و به دو خط می‌پیچد. نتیجهٔ خودکار ممکن است بسته به اندازه نمودار، قلم‌ها و رندرر متفاوت باشد.

![فاصله‌بندی خودکار برچسب‌های دسته با تمام ۲۴ ستون قابل مشاهده](category-axis-automatic.png)

**فضاگیری دستی (اسلاید 2):** هر سومین برچسب در یک خط نمایش داده می‌شود، در حالی که علامت‌های تیک در هر فاصلهٔ دسته باقی می‌مانند. تمام ۲۴ ستون، شامل آن‌هایی که بدون برچسب هستند، با همان مقادیر قابل مشاهده‌اند. اسلاید ۳ ظاهر خودکار نشان‌داده‌شده در بالا را بازمی‌گرداند.

![فضای‌بندی دستی برچسب‌های دسته به مقدار سه با تمام ۲۴ ستون قابل مشاهده](category-axis-manual.png)

### **انتخاب محور و فاصله صحیح**

از این فاصلهٔ شمارش دسته برای یک محور دسته‌بندی متنی استفاده کنید، مثل محور دسته‌بندی یک نمودار ستونی، خطی، ناحیه‌ای یا میله‌ای. در نمودار ستونی، این محور افقی است. در نمودار میله‌ای افقی، محور دسته‌بندی عمودی است، بنابراین این تنظیمات را برای محوری که توسط [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) برگردانده می‌شود اعمال کنید. فاصله علامت‌های تیک همچنین برای محور سری در نمودارهایی که چنین محوری دارند، اعمال می‌شود.

از فاصله برچسب دسته برای تنظیم مقیاس عددی یک محور مقدار استفاده نکنید. در یک محور مقدار، [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) اختلافی بین مقادیر مشخص می‌کند؛ برای مثال، یک واحد اصلی `10` علامت‌ها را در 0، 10، 20 و ... زمانی که محور از صفر شروع می‌شود تولید می‌کند. یک فاصلهٔ برچسب دسته‌ای `3` به‌جای مقادیر عددی، موقعیت‌های دسته‌ای را شمارش می‌کند. نمودارهای پراکندگی و حباب از محورهای مقدار استفاده می‌کنند نه از محور دسته‌بندی متنی. برای محور تاریخ، از واحدهای اصلی مبتنی بر زمان و مقیاس‌ها همان‌طور که در [تغییر محور دسته‌بندی](#change-a-category-axis) توضیح شد، استفاده کنید.

## **تنظیم قالب تاریخ برای مقادیر محور دسته‌بندی**

مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به‌عنوان شماره‌های سریال OLE Automation در اولین صفحه‌کار (شاخص `0`) ذخیره می‌شوند و به‌عنوان تعداد روزها از 30 دسامبر 1899 محاسبه می‌شوند، نه به‌صورت رشته‌های تاریخ. از [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) با [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date) استفاده کنید، [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) را با `False` فراخوانی کنید و `yyyy` را به [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) پاس دهید تا برچسب‌های دسته سال‌های چهاررقمی را به‌صورت مستقل از قالب‌بندی سلول نمایش دهند.

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    base_date = date(1899, 12, 30)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        category_value = float((category_date - base_date).days)
        category_cell = workbook.getCell(0, i + 1, 0, category_value)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(i + 1))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم زاویه چرخش برای عنوان محور نمودار**

با فراخوانی [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) با `True` بر روی محور عمودی، متن عنوان را فراهم کنید و زاویهٔ چرخش را در قالب‌بندی متن بلوک عنوان تنظیم کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک نمودار ستونی ذخیره می‌کند که عنوان محور مقدار آن به‌صورت 90 درجه چرخیده است.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value")
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم موقعیت محور در محور دسته‌بندی یا مقدار**

از [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) برای کنترل اینکه آیا محور مقدار محور دسته‌بندی را بین دسته‌ها یا در علامت‌های تیک دسته قطع می‌کند، استفاده کنید. این تنظیم برای محورهاهای دسته‌بندی اعمال می‌شود. مثال این مقدار را بر روی محور دسته‌بندی افقی یک نمودار ستونی به `True` تنظیم کرده و نتیجه را ذخیره می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم واحد نمایش بر روی محور مقدار نمودار**

از [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) برای مقیاس‌بندی برچسب‌های محور مقدار بدون تغییر داده‌های پایه استفاده کنید. با تنظیم [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) به `Millions`، مقدار 60,000,000 به‌صورت 60 نمایش داده می‌شود. مثال یک نمودار ستونی ایجاد کرده و واحد نمایش میلیون‌ها را بر روی محور عمودی آن اعمال می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **پیکربندی محور مقدار لگاریتمی**

یک محور مقدار لگاریتمی زمانی مفید است که مقادیر مثبت چندین مرتبهٔ قدر را در بر بگیرند. برای مثال، یک سرویس ممکن است در طول پنج دوره درخواست‌های 10، 100، 1,000، 10,000 و 100,000 دریافت کند. در مقیاس خطی، مقادیر کوچک نزدیک به صفر به‌هم نزدیک می‌شوند. مقیاس لگاریتمی رشد نسبی آن‌ها را راحت‌تر مقایسه می‌کند: فاصله‌های مساوی نمایانگر نسبت‌های مساوی هستند نه تفاوت‌های مساوی.

با فراخوانی [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) با `True` بر روی محور مقدار و استفاده از [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) پایه را انتخاب کنید. این کار نحوهٔ نمایش مقادیر موجود را تغییر می‌دهد؛ داده‌ها را تغییر نمی‌دهد و خط روند لگاریتمی اضافه نمی‌کند. خط روند نشان‌دهندهٔ رابطهٔ برازش‌شده در داده‌هاست و ویژگی جداگانه‌ای است.

### **انتخاب محور مقدار و پایه**

برای نمودار خطی یا ستونی، محور مقدار توسط [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) برگردانده می‌شود. برای نمودار میله‌ای افقی، توسط [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis) برگردانده می‌شود. نمودارهای پراکندگی و حباب دو محور مقدار دارند؛ بنابراین محور افقی را برای مقادیر X، محور عمودی را برای مقادیر Y یا هر دو انتخاب کنید. پایه‌گذاری لگاریتمی را بر محور دسته‌بندی اعمال نکنید.

پایهٔ پیش‌فرض لگاریتمی `10` است. برای نمودارهای PPTX می‌توانید پایه‌ای بین `2` تا `1000` (شماره‌های صحیح) استفاده کنید؛ پایه‌های کسری مانند `2.5` نیز پشتیبانی می‌شوند. با پایهٔ `10` توان‌های متوالی مانند 10، 100، 1,000 و 10,000 به‌طور مساوی فاصله دارند.

### **مقایسه مقیاس خطی و لگاریتمی**

مثال زیر خودکفا یک نمودار خطی با پنج شمارش درخواست در اسلاید اول ایجاد می‌کند، سپس آن اسلاید را کلون می‌کند و در اسلاید دوم محور مقدار لگاریتمی پایه‌10 را فعال می‌کند. هر دو اسلاید داده‌های یکسان را حفظ می‌کنند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200)

    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Period {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # اسلاید اول را به‌صورت خطی نگه داشته و فقط مقیاس محور مقدار نسخهٔ کپی را تغییر دهید.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**مقیاس خطی (اسلاید 1):** فاصله‌های عمودی مساوی نشان‌دهندهٔ اختلافات مساوی در تعداد درخواست‌ها هستند. مقدار بزرگ‌ترین نقطه dominate می‌کند و مقادیر کوچکتر را تشخیص سخت می‌سازد.

![نمودار خطی در پاورپوینت که پنج تعداد درخواست را بر روی محور مقدار خطی نشان می‌دهد](value-axis-linear.png)

**مقیاس لگاریتمی (اسلاید 2):** فاصله‌های عمودی مساوی نمایانگر نسبت‌های برابر هستند. هر دوره ده برابر درخواست دورهٔ قبل دارد، بنابراین نقاط در مقیاس پایه‌10 خطی صعودی مستقیم شکل می‌دهند. برچسب‌های محور همچنان تعداد درخواست اصلی را نشان می‌دهند.

![همان پنج تعداد درخواست در پاورپوینت بر روی محور مقدار لگاریتمی پایه‌10](value-axis-logarithmic.png)

### **برخورد با مقادیر صفر و منفی**

مقیاس لگاریتمی تنها مقادیر مثبت صریح را نمایش می‌دهد. پیش از فعال‌سازی داده‌ها را بررسی کنید. اگر مقادیر صفر یا منفی معنایی داشته باشند، مقیاس خطی را حفظ کنید یا آن‌ها را به‌صورت جداگانه نشان دهید. اگر حذف این مقادیر برای تحلیل مناسب است، دلیل حذف را توضیح دهید. به‌صورت ساکت آن‌ها را با عددهای کوچک مثبت جایگزین نکنید، زیرا معنای داده را تغییر می‌دهد. هر حداقل یا حداکثر به‌صورت دستی پیکربندی‌شده برای محور لگاریتمی نیز باید مثبت باشد.

## **پرسش‌های متداول**

**چگونه مقدار تقاطع یک محور با محور دیگر را تنظیم کنم (تقاطع محورها)؟**

از [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) برای انتخاب رفتار تقاطع استفاده کنید. برای تعیین مقدار عددی تقاطع، از [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) استفاده کنید. این تنظیمات به شما امکان می‌دهند تقاطع محور را به خط پایه مناسب منتقل کنید.

**چگونه می‌توانم برچسب‌های تیک را نسبت به محور موقعیت دهیم؟**

از [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) با استفاده از [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/) استفاده کنید: `Low`، `High`، `NextTo` یا `None`. برای کنترل خود علامت‌های تیک، از [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) یا [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark) استفاده کنید؛ این تنظیمات جدا از موقعیت برچسب‌ها هستند.