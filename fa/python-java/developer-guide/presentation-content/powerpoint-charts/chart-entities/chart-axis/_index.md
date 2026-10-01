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
description: "کشف کنید چگونه از Aspose.Slides برای پایتون از طریق جاوا برای سفارشی‌سازی محورهای نمودار در ارائه‌های PowerPoint جهت گزارش‌ها و تجسم‌ها استفاده کنید."  
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه محورهای نمودار را با Aspose.Slides برای Python از طریق Java سفارشی کنید. این مقاله به مقادیر محاسبه‌شده محور، تغییر سطرها و ستون‌های نمودار، قابلیت مشاهده محور، فاصله برچسب‌های دسته و علامت‌های تیک، دسته‌های تاریخ و قالب‌بندی، چرخش عنوان، موقعیت‌گذاری محور و واحدهای نمایش می‌پردازد.

## **دریافت مقادیر حداکثری بر روی محور عمودی یک نمودار**

یک [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید و یک نمودار ناحیه‌ای با داده‌های پیش‌فرض اضافه کنید. قبل از خواندن مقادیر محاسبه‌شده محور، [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) را صدا بزنید تا طرح‌بردار نمودار به‌روز باشد.

محدودیت‌های محور را با استفاده از [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) و [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) بخوانید و فواصل علامت‌های تیک را با [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) و [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) به‌دست آورید. [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) و [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) مقیاس‌های واحد زمان را فراهم می‌کنند که برای محورهای تاریخ relevant هستند. مثال این مقادیر را در متغیرهای محلی ذخیره می‌کند و نمودار را ذخیره می‌کند.

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

از [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) برای تعویض نقش‌ series و category در داده‌های نمودار استفاده کنید. هر دسته قبلی تبدیل به یک series می‌شود و هر series قبلی تبدیل به یک category می‌شود. این کار نحوه گروه‌بندی داده‌ها را تغییر می‌دهد؛ محورهای افقی و عمودی را جابه‌جا نمی‌کند. مثال از [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) برای اتصال داده‌های پیش‌فرض به `Sheet1!A1:D5` شامل سطر سرعنوان و ستون دسته، پیش از جابجایی سطرها و ستون‌ها استفاده می‌کند. سپس نموداری با چهار series و سه category ذخیره می‌کند.

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

با صدا زدن [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) با مقدار `False` بر روی محور عمودی، آن را پنهان کنید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور عمودی مخفی ذخیره می‌کند.

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

با صدا زدن [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) با مقدار `False` بر روی محور افقی، آن را پنهان کنید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور افقی مخفی ذخیره می‌کند.

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

## **تغییر محور دسته‌ای**

از [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) برای انتخاب یک محور دسته‌ای تاریخ یا متن استفاده کنید. این مثال به فایل `ExistingChart.pptx` نیاز دارد که نمودار به عنوان اولین شکل در اولین اسلاید قرار دارد و سلول‌های دسته شامل مقادیر عددی تاریخ Excel هستند. این مثال محور افقی را به یک محور تاریخ تبدیل می‌کند. با صدا زدن [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) با مقدار `False`، [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) با مقدار `1`، و [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) با [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) علامت‌های تیک اصلی را در فواصل یک‑ماه قرار می‌دهد.

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

## **کنترل فاصله برچسب‌های محور دسته‌ای**

هنگامی که نمودار دارای تعداد زیادی دسته باشد، می‌توانید تعداد برچسب‌های قابل مشاهده محور را بدون حذف دسته‌ها یا نقاط داده کاهش دهید. با صدا زدن [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) با مقدار `False`، سپس بازه دسته دلخواه را به [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing) پاس دهید. برای دسته‌های متنی در ترتیب عادی، شمارش از اولین دسته شروع می‌شود:

| فاصله | برچسب‌های نمایش‌داده‑شده در مثال |
| --- | --- |
| `1` | دسته 1, دسته 2, دسته 3, ... دسته 24 |
| `2` | دسته 1, دسته 3, دسته 5, ... دسته 23 |
| `3` | دسته 1, دسته 4, دسته 7, ... دسته 22 |

یک فاصله `3` هر برچسب سوم را نمایش می‌دهد و دو برچسب دیگر بین برچسب‌های نمایش‌داده‑شده مخفی می‌ماند. این کار ستون‌های مربوطه را حذف نمی‌کند. فاصله خودکار بر اساس فضای موجود یک فاصله را انتخاب می‌کند؛ لزوماً همه برچسب‌ها را نمایش نمی‌دهد.

علامت‌های تیک کنترل‌های جداگانه‌ای دارند. با صدا زدن [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) با مقدار `False` و استفاده از [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) فاصله آن‌ها را تنظیم کنید. برای مثال، مقدار `1` یک علامت تیک در هر فاصله دسته حفظ می‌کند در حالی که برچسب‌ها فقط هر سومین دسته ظاهر می‌شوند. از [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) با سبک قابل مشاهده استفاده کنید تا نتیجه را ببینید. صدا زدن هر یک از تنظیم‌کننده‌های فاصله خودکار با مقدار `True` دوباره به نمودار اجازه می‌دهد تا آن فاصله را مجدداً انتخاب کند.

مثال خودمحافظ زیر ۲۴ دسته و یک series ایجاد می‌کند، سپس سه اسلاید را در `CategoryAxisIntervals.pptx` ذخیره می‌کند: فاصله خودکار، فاصله برچسب دستی با علامت‌های تیک مستقل، و بازگرداندن فاصله خودکار. دو نسخه داده‌های اصلی نمودار را حفظ می‌کنند. نیازی به ارائه ورودی نیست. متن برچسب افقی باعث می‌شود تفاوت چگالی به‌راحتی دیده شود.

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

    # اسلاید ۲: هر برچسب سوم را نمایش دهید، اما برای هر دسته یک علامت تیک نگه دارید.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # اسلاید ۳: اجازه دهید نمودار دوباره هر دو فاصله را انتخاب کند.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**فاصله خودکار (اسلاید 1):** در این رندر، هر برچسب دوم دسته نمایش داده می‌شود و به دو خط می‌پیچد. نتیجه خودکار ممکن است با اندازه نمودار، فونت‌ها و رندرر متفاوت باشد.

![فاصله خودکار برچسب دسته با نمایش تمام ۲۴ ستون](category-axis-automatic.png)

**فاصله دستی (اسلاید 2):** هر سومین برچسب در یک خط نمایش داده می‌شود، در حالی که علامت‌های تیک در هر فاصله دسته باقی می‌مانند. تمام ۲۴ ستون، شامل آنهایی که برچسب ندارند، با همان مقادیر نمایش داده می‌شوند. اسلاید ۳ ظاهر خودکار نشان‌داده‌شده در بالا را بازگردانی می‌کند.

![فاصله دستی برچسب دسته به مقدار سه با نمایش تمام ۲۴ ستون](category-axis-manual.png)

### **انتخاب محور و فاصله صحیح**

از این فاصله شمارش‑دسته برای یک محور دسته‌ای متنی، مانند محور دسته‌ای یک نمودار ستونی، خطی، ناحیه‌ای یا میله‌ای استفاده کنید. در یک نمودار ستونی، این محور افقی است. در یک نمودار میله‌ای افقی، محور دسته‌ای عمودی است، بنابراین این تنظیمات را بر روی محوری که توسط [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) برگردانده می‌شود اعمال کنید. فاصله علامت‌های تیک همچنین برای محور series در نمودارهایی که دارای آن هستند کاربرد دارد.

از فاصله برچسب دسته برای تنظیم مقیاس عددی محور مقدار استفاده نکنید. در یک محور مقدار، [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) یک تفاوت مقدار را مشخص می‌کند: به عنوان مثال، یک واحد اصلی `10` علامت‌ها را در ۰، ۱۰، ۲۰ و غیره تولید می‌کند وقتی محور از صفر شروع می‌شود. یک فاصله برچسب دسته `3` به‌جای آن موقعیت‌های دسته را می‌شمارد، صرف‌نظر از مقادیر داده‌ای آن‌ها. نمودارهای پراکندگی و حبابی از محورها مقدار استفاده می‌کنند نه یک محور دسته متن. برای یک محور تاریخ، از واحدهای اصلی زمان‑مبنی و مقیاس‌ها همان‌طور که در [Change a Category Axis](#change-a-category-axis) توضیح داده شد استفاده کنید.

## **تنظیم قالب تاریخ برای مقادیر محور دسته‌ای**

مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به‌عنوان عدد سریال OLE Automation در اولین کاربرگ (شاخص `0`) ذخیره می‌شوند و به‌عنوان تعداد روزهای گذشته از 30 دسامبر 1899 محاسبه می‌شوند. از [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) با [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date) استفاده کنید، [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) را با مقدار `False` صدا بزنید و `yyyy` را به [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) پاس دهید تا برچسب‌های دسته سال‌های چهاررقمی را به‌طور مستقل از قالب‌بندی سلول نمایش دهند.

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

با صدا زدن [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) با مقدار `True` بر روی محور عمودی، متن عنوان را ارائه دهید و زاویه چرخش را در قالب‌بندی بلوک متن عنوان تنظیم کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک نمودار ستونی را ذخیره می‌کند که عنوان محور مقدار آن به‌صورت 90 درجه چرخیده است.

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

## **تنظیم موقعیت محور بر روی محور دسته‌ای یا مقدار**

از [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) برای کنترل این که آیا محور مقدار در میان دسته‌ها یا در علامت‌های تیک دسته محور عبور کند استفاده کنید. این تنظیم برای محورها دسته‌ای اعمال می‌شود. مثال این مقدار را بر روی محور دسته‌ای افقی یک نمودار ستونی به `True` تنظیم می‌کند و نتیجه را ذخیره می‌کند.

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

از [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) برای مقیاس‌بندی برچسب‌های محور مقدار بدون تغییر داده‌های پایه استفاده کنید. با تنظیم [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) به `Millions`، مقدار 60,000,000 به صورت 60 نمایش داده می‌شود. مثال یک نمودار ستونی ایجاد می‌کند و واحد نمایش میلیون‌ها را بر روی محور عمودی آن اعمال می‌کند.

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

## **FAQ**

**چگونه مقدار نقطه عبور یک محور از محور دیگر (crossing) را تنظیم کنم؟**

از [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) برای انتخاب رفتار عبور استفاده کنید. برای تعیین مقدار عددی عبور، از [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) استفاده کنید. این تنظیمات به شما امکان می‌دهند تا نقطه عبور محور را به مبنای مناسب منتقل کنید.

**چگونه می‌توانم برچسب‌های علامت‑تیک را نسبت به محور موقعیت‌گذاری کنم؟**

با صدا زدن [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) و استفاده از [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`، `High`، `NextTo` یا `None`. برای کنترل خود علامت‌های تیک، از [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) یا [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark) استفاده کنید؛ اینها جدا از موقعیت برچسب‌ها هستند.