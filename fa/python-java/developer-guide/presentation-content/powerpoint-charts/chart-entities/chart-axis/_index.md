---
title: سفارشی‌سازی محورها در ارائه‌ها با استفاده از Python
linktitle: محور نمودار
type: docs
url: /fa/python-java/chart-axis/
keywords:
- محور نمودار
- محور عمودی
- محور افقی
- سفارشی‌سازی محور
- دستکاری محور
- مدیریت محور
- ویژگی‌های محور
- مقدار حداکثر
- مقدار حداقل
- خط محور
- قالب تاریخ
- عنوان محور
- موقعیت محور
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "کشف کنید چگونه از Aspose.Slides برای Python از طریق Java استفاده کنید تا محورها را در ارائه‌های PowerPoint برای گزارش‌ها و تجسم‌ها سفارشی کنید."
---
## **مروری**

این مقاله توضیح می‌دهد چگونه محورهای نمودار را با Aspose.Slides برای Python از طریق Java سفارشی کنیم. موضوعات شامل مقادیر محاسبه‌شده محور، جابه‌جایی سطرها و ستون‌های نمودار، قابلیت مشاهده محور، بازه‌های برچسب دسته‌ای و علامت تیک، دسته‌های تاریخی و قالب‌بندی، چرخش عنوان، موقعیت‌گذاری محور، واحدهای نمایش و مقیاس لگاریتمی است.

## **دست آوردن بیشینه مقادیر روی محور عمودی یک نمودار**

یک [ارائه](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید و یک نمودار ناحیه‌ای با داده‌های پیش‌فرض اضافه کنید. قبل از خواندن مقادیر محاسبه‌شده محور، برای بروز رسانی طرح نمودار، [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) را صدا بزنید.

[**getActualMaxValue**](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) و [**getActualMinValue**](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) را برای محدودیت‌های محور بخوانید، و [**getActualMajorUnit**](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) و [**getActualMinorUnit**](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) را برای بازه‌های تیک دریافت کنید. [**getActualMajorUnitScale**](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) و [**getActualMinorUnitScale**](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) مقیاس‌های واحد زمان را فراهم می‌کنند که در محورهای تاریخی محتوا دارند. مثال این مقادیر را در متغیرهای محلی ذخیره و نمودار را ذخیره می‌کند.

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

از [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) برای تعویض نقش‌های سری‌ها و دسته‌ها در داده‌های نمودار استفاده کنید. هر دسته‌ی قبلی به یک سری تبدیل می‌شود و هر سری قبلی به یک دسته. این تغییر نحوهٔ گروه‌بندی داده‌ها را تحت تأثیر قرار می‌دهد؛ محور افقی و عمودی جابه‌جا نمی‌شوند. مثال از [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) برای بایند کردن داده‌های پیش‌فرض به `Sheet1!A1:D5`، شامل سطر سرپرست و ستون دسته، پیش از جابه‌جایی سطرها و ستون‌ها استفاده می‌کند. سپس یک نمودار با چهار سری و سه دسته ذخیره می‌کند.

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

## **غیرفعال کردن محور عمودی برای نمودارهای خطی**

با فراخوانی [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) با مقدار `False` بر روی محور عمودی، آن را مخفی کنید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد کرده و آن را با محور عمودی مخفی ذخیره می‌کند.

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

با فراخوانی [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) با مقدار `False` بر روی محور افقی، آن را مخفی کنید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد کرده و آن را با محور افقی مخفی ذخیره می‌کند.

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

## **تغییر یک محور دسته‌ای**

از [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) برای انتخاب یک محور دسته‌ای تاریخی یا متنی استفاده کنید. این مثال به `ExistingChart.pptx` نیاز دارد که در اسلاید اول اولین شکل آن یک نمودار است و سلول‌های دسته شامل مقادیر عددی تاریخ اکسل می‌باشند. محور افقی به یک محور تاریخی تغییر می‌کند. با فراخوانی [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) با مقدار `False`، [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) با مقدار `1` و [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) با [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) تیک‌های اصلی را در بازه‌های یک‑ماه تنظیم می‌کند.

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

## **کنترل بازه برچسب‌های محور دسته‌ای**

زمانی که یک نمودار دسته‌های زیادی دارد، می‌توانید تعداد برچسب‌های قابل مشاهدهٔ محور را بدون حذف دسته‌ها یا نقاط داده کاهش دهید. با فراخوانی [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) با مقدار `False`، سپس بازهٔ دلخواه دسته را به [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing) بدهید. برای دسته‌های متنی به ترتیب عادی، شمارش از اولین دسته شروع می‌شود:

| فاصله | برچسب‌های نمایش داده شده در مثال |
| --- | --- |
| `1` | دسته 1, دسته 2, دسته 3, ... دسته 24 |
| `2` | دسته 1, دسته 3, دسته 5, ... دسته 23 |
| `3` | دسته 1, دسته 4, دسته 7, ... دسته 22 |

یک بازهٔ `3` هر برچسب سوم را نمایش می‌دهد و دو برچسب بین برچسب‌های نمایش داده‌شده مخفی می‌مانند. این کار ستون‌های مربوطه را حذف نمی‌کند. فاصلهٔ خودکار بر اساس فضای موجود یک بازه انتخاب می‌کند؛ لزوماً تمام برچسب‌ها را نشان نمی‌دهد.

علامت‌های تیک کنترل‌های جداگانه‌ای دارند. با فراخوانی [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) با مقدار `False` و استفاده از [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) بازهٔ آن‌ها را تنظیم کنید. برای مثال، مقدار `1` یک علامت تیک را در هر بازهٔ دسته نگه می‌دارد در حالی که برچسب‌ها فقط هر دستهٔ سوم نمایش داده می‌شوند. با استفاده از [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) یک سبک قابل مشاهده انتخاب کنید تا نتیجه را ببینید. فراخوانی هر کدام از تنظیم‌کننده‌های خودکار با مقدار `True` مجدداً به نمودار اجازه می‌دهد بازهٔ خودکار را انتخاب کند.

مثال مستقل زیر ۲۴ دسته و یک سری ایجاد می‌کند و سپس سه اسلاید در `CategoryAxisIntervals.pptx` ذخیره می‌کند: فاصلهٔ خودکار، فاصلهٔ دستی برچسب‌ها با علامت‌های تیک مستقل، و بازگرداندن فاصلهٔ خودکار. دو نسخهٔ کپی داده‌های اصلی نمودار را حفظ می‌کنند. ارائه ورودی لازم نیست. متن برچسب‌های افقی تفاوت تراکم را به‌راحتی نشان می‌دهد.

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

    # اسلاید ۲: هر برچسب سوم را نشان دهید، اما برای هر دسته یک علامت تیک نگه دارید.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # اسلاید ۳: بگذارید نمودار دوباره هر دو بازه را انتخاب کند.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**فاصلهٔ خودکار (اسلاید ۱):** در این رندر، هر برچسب دوم دسته نمایش داده می‌شود و بر دو خط می‌پیچد. نتیجهٔ خودکار ممکن است بسته به اندازهٔ نمودار، قلم‌ها و رندر کننده متفاوت باشد.

![فاصله برچسب دسته‌بندی خودکار با تمام ۲۴ ستون قابل مشاهده](category-axis-automatic.png)

**فاصلهٔ دستی (اسلاید ۲):** هر برچسب سوم روی یک خط نمایش داده می‌شود، در حالی که علامت‌های تیک در هر بازهٔ دسته باقی می‌مانند. تمام ۲۴ ستون، از جمله آن‌هایی که برچسب ندارند، با همان مقادیر قابل مشاهده‌اند. اسلاید ۳ ظاهر خودکار نشان داده شده در بالا را بازگردانده است.

![فاصله برچسب دسته‌بندی دستی به میزان سه با تمام ۲۴ ستون قابل مشاهده](category-axis-manual.png)

### **انتخاب محور و بازهٔ صحیح**

از این بازهٔ شمارش دسته برای یک محور دسته‌ای متنی استفاده کنید، مانند محور دسته‌ای یک نمودار ستونی، خطی، ناحیه‌ای یا میله‌ای. در یک نمودار ستونی، این محور افقی است. در یک نمودار میله‌ای افقی، محور دسته‌ای عمودی است، بنابراین این تنظیمات را به محوری که توسط [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) بازگردانده می‌شود اعمال کنید. فاصلهٔ علامت‌گذاری تیک همچنین به محوری سری در نمودارهایی که یک محور سری دارند اعمال می‌شود.

از فاصلهٔ برچسب دسته برای تنظیم مقیاس عددی یک محور مقداری استفاده نکنید. در یک محور مقدار، [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) اختلاف مقادیر را تعیین می‌کند: به‌عنوان مثال، یک واحد اصلی `10` تیک‌ها را در ۰، ۱۰، ۲۰ و … وقتی محور از صفر شروع می‌شود، ایجاد می‌کند. بازهٔ برچسب دسته‌ای `3` به‌جای مقادیر عددی، موقعیت‌های دسته‌ای را می‌شمارد. نمودارهای پراکنده و حبابی از محورهاى مقدار استفاده می‌کنند نه از محور دسته‌ای متنی. برای یک محور تاریخی، از واحدهای اصلی مبتنی بر زمان و مقیاس‌ها همان‌طور که در [تغییر یک محور دسته‌ای](#change-a-category-axis) توضیح داده شد، استفاده کنید.

## **تنظیم قالب تاریخ برای مقادیر محور دسته‌ای**

مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به‌عنوان عددهای سریال OLE Automation در اولین کاربرگ (اندیس `0`) ذخیره می‌شوند که به‌عنوان تعداد روزها از ۳۰‑دسامبر‑۱۸۹۹ برای این تاریخ‌ها محاسبه می‌شوند. با استفاده از [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) همراه با [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date)، [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) را با مقدار `False` صدا بزنید و `yyyy` را به [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) بدهید تا برچسب‌های دسته سال‌های چهاررقمی را مستقل از قالب سلول نمایش دهند.

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

## **تنظیم زاویهٔ چرخش برای عنوان محور نمودار**

با فراخوانی [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) با مقدار `True` بر روی محور عمودی، متن عنوان را فراهم کنید و زاویهٔ چرخش را در قالب‌بندی بلوک متنی عنوان تنظیم کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک نمودار ستونی را با عنوان محور مقدار که به‌صورت ۹۰ درجه چرخیده ذخیره می‌کند.

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

## **تنظیم موقعیت محور بر روی یک محور دسته‌ای یا مقدار**

از [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) برای کنترل این‌که آیا محور مقدار محور دسته‌ای را بین دسته‌ها یا بر روی علامت‌های تیک دسته عبور دهد، استفاده کنید. این تنظیم برای محورهاى دسته‌ای اعمال می‌شود. مثال این تنظیم را بر روی محور دسته‌ای افقی یک نمودار ستونی به `True` تغییر می‌دهد و نتیجه را ذخیره می‌کند.

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

## **تنظیم واحد نمایش بر روی محور مقدار یک نمودار**

با استفاده از [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) می‌توانید برچسب‌های یک محور مقدار را بدون تغییر داده‌های پایه مقیاس‌بندی کنید. با تنظیم [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) به `Millions`، مقدار 60,000,000 به صورت 60 نمایش داده می‌شود. مثال یک نمودار ستونی ایجاد می‌کند و واحد نمایش میلیون‌ها را بر روی محور عمودی آن اعمال می‌نماید.

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

یک محور مقدار لگاریتمی وقتی مفید است که مقادیر مثبت در چندین مرتبهٔ قدرت متفاوت قرار بگیرند. برای مثال، سرویسی ممکن است در پنج دوره درخواست‌های 10، 100، 1,000، 10,000 و 100,000 دریافت کند. در یک مقیاس خطی، مقادیر کوچکتر نزدیک به صفر به‌هم می‌چسبند. مقیاس لگاریتمی رشد نسبی آن‌ها را راحت‌تر مقایسه می‌کند: فواصل برابر نسبت‌های برابر را نشان می‌دهند نه اختلاف‌های عددی برابر.

با فراخوانی [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) با مقدار `True` بر روی محور مقدار و استفاده از [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) برای انتخاب پایه، این تنظیمات نحوهٔ نمایش مقادیر موجود را تغییر می‌دهد؛ داده‌ها را تغییر نمی‌دهد و خط روند لگاریتمی اضافه نمی‌کند. خط روند یک ویژگی جداگانه است که رابطهٔ برازش شده در داده‌ها را نشان می‌دهد.

### **انتخاب محور مقدار و پایه**

برای یک نمودار خطی یا ستونی، محور مقدار توسط [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) بازگردانده می‌شود. برای یک نمودار میله‌ای افقی، توسط [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis) بازگردانده می‌شود. نمودارهای پراکنده و حبابی دو محور مقدار دارند، بنابراین برای مقادیر X محور افقی، برای مقادیر Y محور عمودی یا هر دو را انتخاب کنید. از مقیاس لگاریتمی برای یک محور دسته‌ای استفاده نکنید.

پایهٔ پیش‌فرض لگاریتمی `10` است. برای نمودارهای PPTX می‌توانید پایه‌ای بین `2` تا `1000` (شامل) استفاده کنید؛ پایه‌های کسری مثل `2.5` نیز پشتیبانی می‌شوند. با پایهٔ `10` توان‌های متوالی مانند 10، 100، 1,000 و 10,000 به‌صورت برابر فاصله‌دار هستند.

### **مقایسه مقیاس خطی و لگاریتمی**

مثال خودمتضمن زیر یک نمودار خطی با پنج شمارش درخواست در اسلاید اول ایجاد می‌کند، سپس آن اسلاید را کلون کرده و در اسلاید دوم محور مقدار لگاریتمی با پایهٔ 10 را فعال می‌کند. هر دو اسلاید همان داده‌ها را حفظ می‌کنند.

```python
import jpage
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

    # اسلاید اول را به حالت خطی نگه دارید و فقط مقیاس محور مقدار نسخهٔ کپی را تغییر دهید.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**مقیاس خطی (اسلاید ۱):** فواصل عمودی برابر نشان‌دهندۀ اختلاف‌های مساوی در شمارش درخواست‌ها هستند. مقدار بزرگ‌ترین مقدار نمودار را تسلط می‌دهد و مقادیر کوچکتر را تشخیص سخت می‌شود.

![نمودار خطی در پاورپوینت که پنج شمارش درخواست را روی محور مقدار خطی نشان می‌دهد](value-axis-linear.png)

**مقیاس لگاریتمی (اسلاید ۲):** فواصل عمودی برابر نشان‌دهندۀ نسبت‌های مساوی هستند. هر دوره ده برابر درخواست دورهٔ قبلی دارد، بنابراین نقاط روی مقیاس لگاریتمی پایهٔ 10 یک خط راست صعودی می‌سازند. برچسب‌های محور هنوز شمارش درخواست‌های اصلی را نشان می‌دهند.

![پنج شمارش درخواست همان‌گونه در پاورپوینت روی محور مقدار لگاریتمی پایهٔ 10](value-axis-logarithmic.png)

### **مدیریت مقادیر صفر و منفی**

مقیاس لگاریتمی فقط مقادیر strictly مثبت را نمایش می‌دهد. پیش از فعال‌سازی آن داده‌ها را بررسی کنید. اگر مقادیر صفر یا منفی معنا دارند، مقیاس خطی را حفظ کنید یا آن‌ها را جداگانه نشان دهید. اگر حذف این مقادیر برای تحلیل مناسب است، دلایل حذف را توضیح دهید. به‌صورت خاموش آن‌ها را با اعداد مثبت کوچک جایگزین نکنید، زیرا معنای داده‌ها را تغییر می‌دهد. هر مقدار حداقل یا حداکثر به‌صورت دستی برای یک محور لگاریتمی نیز باید مثبت باشد.

## **سوالات متداول**

**چگونه مقدار عبور یک محور از محور دیگر (crossing) را تنظیم کنم؟**

از [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) برای انتخاب رفتار عبور استفاده کنید. برای تعیین مقدار عددی عبور، از [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) استفاده کنید. این تنظیمات به شما اجازه می‌دهند عبور محور را به پایه‌ای مناسب ببرید.

**چگونه می‌توان برچسب‌های تیک را نسبت به محور موقعیت‌دهی کرد؟**

با فراخوانی [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) به همراه [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`، `High`، `NextTo` یا `None`. برای کنترل خود علامت‌های تیک، از [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) یا [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark) استفاده کنید؛ این موارد جدا از موقعیت‌دهی برچسب‌ها هستند.