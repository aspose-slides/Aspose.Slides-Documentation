---
title: سفارشی‌سازی محورهای نمودار در ارائه‌ها با استفاده از پایتون
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
description: "کشف کنید چگونه می‌توانید از Aspose.Slides برای پایتون از طریق جاوا برای سفارشی‌سازی محورهای نمودار در ارائه‌های PowerPoint برای گزارش‌ها و تجسم‌ها استفاده کنید."
---
## **نمایش کلی**

این مقاله نحوه سفارشی‌سازی محورهای نمودار را با Aspose.Slides برای Python از طریق Java توضیح می‌دهد. این مقاله به مقادیر محاسبه‌شده محور، جابجایی سطرها و ستون‌های نمودار، نمایش محور، فاصله برچسب‌های دسته و تیک‌ها، دسته‌های تاریخ و قالب‌بندی، چرخش عنوان، موقعیت محور، واحدهای نمایش، و مقیاس لگاریتمی می‌پردازد.

## **دریافت حداکثر مقادیر در محور عمودی یک نمودار**

یک [ارائه](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید و یک نمودار ناحیه‌ای با داده‌های پیش‌فرض اضافه کنید. قبل از خواندن مقادیر محاسبه‌شده محور، برای به‌روزرسانی طرح نمودار، [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) را فراخوانی کنید.

مقادیر [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) و [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) را برای حدهای محور بخوانید و برای فواصل تیک‌ها [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) و [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) را استفاده کنید. [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) و [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) مقیاس‌های زمان‑واحد را فراهم می‌کنند که برای محورهای تاریخ مرتبط هستند. مثال این مقادیر را در متغیرهای محلی ذخیره کرده و نمودار را ذخیره می‌کند.

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

## **جابه‌جایی داده‌ها بین محورها**

از [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) برای تعویض نقش سری‌ها و دسته‌ها در داده‌های نمودار استفاده کنید. هر دسته قبلی به یک سری تبدیل می‌شود و هر سری قبلی به یک دسته تبدیل می‌شود. این تغییر، نحوه گروه‌بندی داده‌ها را تغییر می‌دهد؛ محورهای افقی و عمودی تعویض نمی‌شوند. مثال با استفاده از [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) داده‌های پیش‌فرض را به `Sheet1!A1:D5` (شامل سطر سرعنوان و ستون دسته) متصل می‌کند و سپس سطرها و ستون‌ها را جابه‌جا می‌کند. یک نمودار با چهار سری و سه دسته ذخیره می‌کند.

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

## **معکوس کردن ترتیب رسم یک محور**

از [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) برای معکوس کردن محور دسته یا مقدار استفاده کنید. به‌عنوان مثال، یک نمودار میله‌ای افقی می‌تواند مراحل پروژه را از بالا به پایین به همان ترتیب برگه کاری نشان دهد: برنامه‌ریزی، توسعه، آزمایش. معکوس کردن محور جهت رسم را تغییر می‌دهد؛ داده‌های کتاب‌کار را مرتب یا جابه‌جا نمی‌کند. برای مقایسه، [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) نقش سری‌ها و دسته‌ها را تعویض می‌کند.

مثال زیر یک نمودار میله‌ای افقی با سه مرحله و یک سری ایجاد می‌کند. یک ارائه با سه اسلاید ذخیره می‌کند: ترتیب عادی، دسته‌های معکوس، و مقادیر معکوس. هر کپی از همان مجموعه داده استفاده می‌کند و فقط یک محور در هر کپی معکوس می‌شود.

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
    # محور مقدار افقی را در پایین نگه دارید.
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # اسلاید ۳: فقط مقیاس عددی افقی را معکوس کنید.
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

معکوس کردن محور می‌تواند محور عمود بر آن را به سمت مخالف نمودار جابه‌جا کند. [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) تعیین می‌کند که محور دیگر در کجا محور پیکربندی‌شده را قطع می‌کند. در اسلاید ۲، فراخوانی آن با [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) روی محور دسته معکوس، محور مقدار افقی را در پایین نگه می‌دارد. برای یک نقطه قطع خاص، از [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) استفاده کنید. هنگام تغییر جهت، تنظیمات قطع را بررسی کنید، به‌ویژه اگر نمودار قبلاً نقطه قطع سفارشی دارد. برای بازگرداندن جهت رسم عادی، [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) را با `False` فراخوانی کنید؛ تنظیمات قطع مستقل هستند.

| ترتیب عادی (اسلاید ۱) | دسته‌های معکوس (اسلاید ۲) | مقادیر معکوس (اسلاید ۳) |
| --- | --- | --- |
| ![نمودار میله‌ای افقی با ترتیب عادی محور دسته و مقدار](axis-order-normal.png) | ![نمودار میله‌ای افقی با دسته‌های نمایش داده شده از بالا به پایین](axis-order-categories-reversed.png) | ![نمودار میله‌ای افقی با محور مقدار معکوس و صفر در سمت راست](axis-order-values-reversed.png) |
| دسته‌ها از پایین به بالا می‌روند؛ مقادیر از چپ به راست افزایش می‌یابند. | مراحل برنامه‌ریزی، توسعه و آزمایش از بالا به پایین اجرا می‌شوند. مقادیر و ترتیب سطرهای کتاب کار تغییر نمی‌کند. | دسته‌ها ترتیب عادی خود را حفظ می‌کنند؛ مقادیر از راست به چپ افزایش می‌یابند. محور دسته در صفر سمت راست عبور می‌کند. |

## **غیرفعال کردن محور عمودی برای نمودارهای خطی**

[setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) را با مقدار `False` روی محور عمودی فراخوانی کنید تا مخفی شود. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور عمودی مخفی ذخیره می‌کند.

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

[setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) را با مقدار `False` روی محور افقی فراخوانی کنید تا مخفی شود. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور افقی مخفی ذخیره می‌کند.

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

## **تغییر محور دسته**

از [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) برای انتخاب محور دسته تاریخ یا متن استفاده کنید. این مثال به فایل `ExistingChart.pptx` نیاز دارد که در اسلاید اول، اولین شکل، یک نمودار دارد و سلول‌های دسته شامل مقادیر عددی تاریخ Excel هستند. محور افقی را به یک محور تاریخ تغییر می‌دهد. فراخوانی [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) با `False`، [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) با `1` و [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) با [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) تیک‌های اصلی را در فواصل یک‌ماهه قرار می‌دهد.

```python
import jpade
import asposeslides

if not jpape.isJVMStarted():
    jpape.startJVM()

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

## **کنترل فواصل برچسب‌های محور دسته**

وقتی نمودار دسته‌های زیادی داشته باشد، تعداد برچسب‌های قابل مشاهده محور را بدون حذف دسته‌ها یا نقاط داده کاهش دهید. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) را با `False` فراخوانی کنید، سپس فاصله دسته دلخواه را به [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing) بدهید. برای دسته‌های متنی در ترتیب عادی، شمارش از اولین دسته آغاز می‌شود:

| فاصله | برچسب‌های نمایش داده شده در مثال |
| --- | --- |
| `1` | دسته 1, دسته 2, دسته 3, … دسته 24 |
| `2` | دسته 1, دسته 3, دسته 5, … دسته 23 |
| `3` | دسته 1, دسته 4, دسته 7, … دسته 22 |

یک فاصله `3` هر سومین برچسب را نمایش می‌دهد و دو برچسب میان برچسب‌های نمایش داده‌شده مخفی می‌مانند. این کار ستون‌های مربوطه را حذف نمی‌کند. فاصله خودکار بر پایه فضای موجود یک فاصله انتخاب می‌کند؛ لزوماً همه برچسب‌ها را نمایش نمی‌دهد.

تیک‌ها کنترل جداگانه‌ای دارند. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) را با `False` فراخوانی کنید و از [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) برای تنظیم فواصل آن‌ها استفاده کنید. برای مثال، `1` تیک را در هر فاصله دسته نگه می‌دارد در حالی که برچسب‌ها فقط هر سومین دسته ظاهر می‌شوند. با یک سبک قابل مشاهده، [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) را استفاده کنید تا نتیجه را ببینید. فراخوانی هر یک از تنظیم‌کننده‌های خودکار با `True` دوباره به نمودار اجازه می‌دهد همان فاصله را انتخاب کند.

مثال زیر ۲۴ دسته و یک سری ایجاد می‌کند، سپس سه اسلاید در `CategoryAxisIntervals.pptx` ذخیره می‌کند: فاصله خودکار، فاصله برچسب دستی با تیک‌های مستقل، و بازگرداندن فاصله خودکار. دو نسخه داده‌های اصلی نمودار را حفظ می‌کنند. ارائه ورودی مورد نیاز نیست. متن برچسب افقی تفاوت چگالی را به‌راحتی نشان می‌دهد.

```python
import jpype
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

    # اسلاید ۲: هر سومین برچسب را نمایش دهید، اما برای هر دسته یک تیک نگه دارید.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # اسلاید ۳: بگذارید نمودار دوباره هر دو فاصله را انتخاب کند.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**فاصله خودکار (اسلاید ۱):** در این رندر، هر دومین برچسب دسته نمایش داده می‌شود و روی دو خط می‌پیچد. نتیجه خودکار بسته به اندازه نمودار، قلم‌ها و رندر کننده می‌تواند متفاوت باشد.

![فاصله خودکار برچسب دسته با همه ۲۴ ستون قابل مشاهده](category-axis-automatic.png)

**فاصله دستی (اسلاید ۲):** هر سومین برچسب روی یک خط نمایش داده می‌شود، در حالی که تیک‌ها در هر فاصله دسته باقی می‌مانند. همه ۲۴ ستون، حتی آن‌هایی که برچسب ندارند، با همان مقادیر قابل مشاهده هستند. اسلاید ۳ ظاهر خودکار را که در بالا نشان داده شد بازمی‌گرداند.

![فاصله برچسب دسته به صورت سه‌تایی با همه ۲۴ ستون قابل مشاهده](category-axis-manual.png)

### **انتخاب محور و فاصله صحیح**

از این فاصله شمارش دسته برای محور دسته متنی استفاده کنید، مانند محور دسته یک نمودار ستون، خط، مساحت یا میله. در یک نمودار ستون، این محور افقی است. در یک نمودار میله‌ای افقی، محور دسته عمودی است، بنابراین این تنظیمات را به محوری که توسط [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) بازگردانده می‌شود اعمال کنید. فاصله تیک‑مارک همچنین به محور سری در نمودارهایی که چنین محوری دارند، اعمال می‌شود.

از فاصله برچسب دسته برای تنظیم مقیاس عددی محور مقدار استفاده نکنید. در یک محور مقدار، [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) اختلافی در مقدارها را مشخص می‌کند: برای مثال، یک واحد اصلی `10` تیک‌ها را در 0، 10، 20 و … وقتی محور از صفر شروع شود، تولید می‌کند. فاصله برچسب دسته `3` به‌جای مقدارها، موقعیت‌های دسته را می‌شمارد، صرف‌نظر از مقدار داده. نمودارهای پراکندگی و حباب از محورها‌ی مقدار استفاده می‌کنند نه محور دسته متنی. برای یک محور تاریخ، از واحدهای اصلی و مقیاس‌های مبتنی بر زمان همان‌طور که در [تغییر محور دسته](#change-a-category-axis) توضیح داده شده، استفاده کنید.

## **تنظیم قالب تاریخ برای مقادیر محور دسته**

مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به عنوان شماره‌های سریال OLE Automation در اولین کاربرگ (اندیس `0`) ذخیره می‌شوند که به‌عنوان تعداد روزهای گذشته از 30 دسامبر 1899 محاسبه می‌شوند. از [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) با [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date)، [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) را با `False` فراخوانی کنید و `yyyy` را به [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) بدهید تا برچسب‌های دسته سال‌های چهاررقمی را مستقل از قالب‌ بندی سلول نمایش دهند.

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

[setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) را با `True` روی محور عمودی فراخوانی کنید، متن عنوان را ارائه دهید و زاویه چرخش را در قالب‌بندی بلوک متن عنوان تنظیم کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک نمودار ستونی را با عنوان محور مقدار چرخانده به‌صورت 90 درجه ذخیره می‌کند.

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

## **تنظیم موقعیت محور بر روی محور دسته یا مقدار**

از [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) برای کنترل این‌که آیا محور مقدار در بین دسته‌ها یا در تیک‌های دسته محور دسته را قطع می‌کند، استفاده کنید. این تنظیم برای محورهای دسته اعمال می‌شود. مثال این تنظیم را روی محور دسته افقی یک نمودار ستونی به‌صورت `True` تنظیم می‌کند و نتیجه را ذخیره می‌کند.

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

از [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) برای مقیاس‌بندی برچسب‌های محور مقدار بدون تغییر داده‌های پایه استفاده کنید. با تنظیم [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) به `Millions`، مقدار 60,000,000 به‌صورت 60 نمایش داده می‌شود. مثال یک نمودار ستونی ایجاد می‌کند و واحد نمایش میلیون‌ها را به محور عمودی آن اعمال می‌کند.

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

یک محور مقدار لگاریتمی زمانی مفید است که مقادیر مثبت چندین مرتبه بزرگ شوند. به‌عنوان مثال، یک سرویس ممکن است در طول پنج دوره 10، 100، 1,000، 10,000 و 100,000 درخواست دریافت کند. در مقیاس خطی، مقادیر کوچک‌تر نزدیک به صفر به‌صورت تجمعی ظاهر می‌شوند. مقیاس لگاریتمی رشد نسبی آنها را آسان‌تر مقایسه می‌کند: فاصله‌های برابر نشان‌دهنده نسبت‌های برابر هستند نه اختلاف‌های برابر.

[setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) را با `True` روی محور مقدار فراخوانی کنید و از [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) برای انتخاب پایه استفاده کنید. این کار نحوه نمایش مقادیر موجود را تغییر می‌دهد؛ داده‌ها را تغییر نمی‌دهد یا خط روند لگاریتمی اضافه نمی‌کند. خط روند رابطه‌ای برازش‌شده در داده‌ها را نمایش می‌دهد و ویژگی جداگانه‌ای است.

### **انتخاب محور مقدار و پایه**

برای یک نمودار خط یا ستونی، محور مقدار توسط [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) بازگردانده می‌شود. برای یک نمودار میله‌ای افقی، توسط [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis) بازگردانده می‌شود. نمودارهای پراکندگی و حباب دو محور مقدار دارند، بنابراین برای مقادیر X محور افقی، برای مقادیر Y محور عمودی یا هر دو را انتخاب کنید. مقیاس لگاریتمی را بر روی محور دسته اعمال نکنید.

پایه پیش‌فرض لگاریتمی `10` است. برای نمودارهای PPTX، می‌توانید پایه‌ای بین `2` تا `1000` (شامل) استفاده کنید؛ پایه‌های کسری مانند `2.5` نیز پشتیبانی می‌شوند. با پایه `10`، توان‌های متوالی مانند 10، 100، 1,000 و 10,000 به‌صورت مساوی فاصله دارند.

### **مقایسه مقیاس خطی و لگاریتمی**

مثال زیر یک نمودار خطی با پنج شمارش درخواست در اسلاید اول ایجاد می‌کند، سپس آن اسلاید را کپی کرده و در اسلاید دوم محور مقدار لگاریتمی با پایه 10 را فعال می‌کند. هر دو اسلاید داده‌های یکسان را نگه می‌دارند.

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

    # اسلاید اول را خطی نگه دارید و فقط مقیاس محور مقدار نسخه کپی را تغییر دهید.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**مقیاس خطی (اسلاید ۱):** فواصل عمودی برابر نشان‌دهنده اختلاف‌های برابر در شمارش درخواست‌ها هستند. مقدار بزرگ‌ترین نقطه نمودار را domine می‌کند و مقادیر کوچکتر را تشخیص دشوار می‌سازد.

![نمودار خطی در PowerPoint که پنج شمارش درخواست را بر روی محور مقدار خطی نشان می‌دهد](value-axis-linear.png)

**مقیاس لگاریتمی (اسلاید ۲):** فواصل عمودی برابر نشان‌دهنده نسبت‌های برابر هستند. هر دوره درخواست‌ها ده‌برابر دوره قبلی است، بنابراین نقاط روی مقیاس پایه‑10 یک خط صعودی مستقیم تشکیل می‌دهند. برچسب‌های محور همچنان شمارش درخواست‌های اصلی را نشان می‌دهند.

![همان پنج شمارش درخواست در PowerPoint بر روی محور مقدار لگاریتمی پایه‑10](value-axis-logarithmic.png)

### **مدیریت مقادیر صفر و منفی**

مقیاس لگاریتمی فقط می‌تواند مقادیر مثبت صریح را نمایش دهد. قبل از فعال‌سازی آن داده‌ها را بررسی کنید. اگر مقادیر صفر یا منفی معنادار هستند، مقیاس خطی را حفظ کنید یا آنها را جداگانه نمایش دهید. اگر حذف این مقادیر برای تحلیل مناسب است، دلیل آن را توضیح دهید. به‌طور خاموش مقدارهای صفر یا منفی را با اعداد مثبت کوچک جایگزین نکنید، زیرا معنای داده‌ها را تغییر می‌دهد. هر حداقل یا حداکثر به‌صورت دستی تنظیم‌شده برای محور لگاریتمی نیز باید مثبت باشد.

## **پرسش‌های متداول**

**چگونه مقدار نقطه تقاطع یک محور با محور دیگر (تقاطع محور) را تنظیم کنم؟**

از [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) برای انتخاب رفتار تقاطع استفاده کنید. برای تعیین مقدار عددی تقاطع، از [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) استفاده کنید. این تنظیمات به شما اجازه می‌دهند تقاطع محور را به پایه مناسب جابه‌جا کنید.

**چگونه می‌توانم برچسب‌های تیک را نسبت به محور موقعیت‌یابی کنم؟**

[setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) را با استفاده از [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/) فراخوانی کنید: `Low`، `High`، `NextTo` یا `None`. برای کنترل خود تیک‌ها، از [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) یا [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark) استفاده کنید؛ این‌ها جدا از موقعیت برچسب‌ها هستند.