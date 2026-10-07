---
title: مدیریت سری‌های داده نمودار در ارائه‌ها با پایتون
linktitle: سری‌های داده
type: docs
url: /fa/python-java/chart-series/
keywords:
- سری نمودار
- همپوشانی سری
- رنگ سری
- نام سری
- نقطه داده
- سلول دفتر کار
- فاصله سری
- مقدار منفی
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه سری‌های نمودار، نقاط داده، سلول‌های دفتر کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با Aspose.Slides برای پایتون از طریق جاوا مدیریت کنید."
---
## **نمای کلی**

یک نمودار داده‌های رسم‌شده خود را در یک دفتر کار داده‌های نمودار ذخیره می‌کند. یک [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) نمایانگر یک مجموعه از مقادیر مرتبط است و هر [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) در این سری به یک یا چند سلول دفتر کار اشاره می‌کند. اشیاء [ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک بین سری‌ها را فراهم می‌کنند. بنابراین نام سری، دسته‌ها و مقادیر نقاط به اشیاء [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) متصل هستند نه اینکه فقط به‌عنوان متن نمایش ذخیره شوند.

برای یک نمودار دسته‌ای معمولی، دفتر کار پیش‌فرض از ردیف 0 برای نام‌های سری، ستون 0 برای نام‌های دسته و سلول‌های باقی‌مانده برای مقادیر سری‌ها استفاده می‌کند. شاخص‌های کاربرگ، ردیف و ستون که به [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) منتقل می‌شوند، صفر‑مبنا هستند. این چینش وقتی که نمودار را با داده‌های پیش‌فرض ایجاد می‌کنید مفید است، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر دفتر کار، سلول‌های مرجع توسط سری‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار دارای سه حوزه متفاوت هستند:

- تنظیمات سطح سری، مانند [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat)، ظاهر پیش‌فرض همه نقاط در یک سری را فراهم می‌کند.
- تنظیمات نقطه‑داده، مانند [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat)، ظاهر سری را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروه بر روی سری‌های سازگاری که به همان [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) تعلق دارند اعمال می‌شود. برای تنظیم گزینه‌هایی مانند overlap یا gap width، به گروه از طریق [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) دسترسی پیدا کنید.

وقتی پرکردن صریح برای نقطه یا سری تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم تنظیمات سری و هم نقطه موجود باشد، تنظیمات نقطه بر نقطه مربوطه اولویت دارد.

![نمودار‑سری‑پاورپوینت](chart-series-powerpoint.png)

## **تنظیم Overlap سری نمودار**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) گزارش می‌دهد که نوارها یا ستون‌ها در یک نمودار 2D چقدر هم‌پوشانی دارند، از ‎‑100 تا 100 درصد. این یک تصویر فقط‑خواندنی از تنظیمات گروه سری والد است. برای به‌روزرسانی هر سری سازگار در آن گروه از [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) استفاده کنید. این گزینه برای انواع نموداری که نوارها یا ستون‌های گروهی نمایش می‌دهند اعمال می‌شود؛ برای گروه‌های سری نامرتبط در یک نمودار ترکیبی تأثیری ندارد.

مثال زیر overlap گروه حاوی اولین سری را تنظیم می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # نمودار جدید شامل سری‌ها، دسته‌ها و مقادیر نمونه است.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![Overlap سری](series_overlap.png)

## **تغییر رنگ پر کردن سری**

از [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) برای تنظیم پر کردن پیش‌فرض یک سری کامل استفاده کنید. اگر نقطه‌ای پر کردن صریح داشته باشد، تنظیم [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) آن، پر کردن سری را برای آن نقطه بازنویسی می‌کند.

مثال زیر پرکردن آبی صلب را به اولین سری اعمال می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![رنگ سری](series_color.png)

## **تغییر نام سری**

نام یک سری در دفتر کار داده‌های نمودار ذخیره می‌شود و به‌طور معمول در legend نمایش داده می‌شود. در دفتر کار پیش‌فرض ایجادشده برای نمودار ستون خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین سری را شامل می‌شود. متغیرهای نام‌گذاری شده در مثال زیر این ساختار را آشکار می‌سازند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

همچنین می‌توانید سلولی که توسط [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName) مرجع شده است به‌روز کنید. این روش از فرض ردیف و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![نام سری](series_name.png)

### **ایجاد یک سری با نام از چند سلول**

یک نام سری مرکب زمانی مفید است که نام محصول و دوره گزارش در سلول‌های جداگانه دفتر کار ذخیره شوند. به‌عنوان مثال می‌توانید `Product A` در B1 و `2026` در C1 را به یک نام سری ترکیب کنید در حالی که هر دو بخش به سلول‌های منبع خود پیوند دارند.

از [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) برای دریافت بازه نام استفاده کنید، سپس آن مجموعه را به [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add) منتقل کنید. آرگومان `skipHiddenCells` کنترل می‌کند که آیا سلول‌های مخفی گنجانده شوند یا نه: `True` آن‌ها را حذف می‌کند، در حالی که `False` آن‌ها را شامل می‌شود. این مثال از `False` برای گنجاندن هر سلول در بازه نام استفاده می‌کند.

مثال زیر یک ارائه با یک سری و دو نقطه داده ایجاد می‌کند. سلول‌های B1:C1 فقط نام سری را فراهم می‌کنند؛ A2:A3 برچسب‌های دسته را فراهم می‌کنند و B2:B3 مقادیر عددی را فراهم می‌کنند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # این دو سلول نام سری را فراهم می‌کنند.
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # سلول‌های جداگانه دسته‌ها و نقاط داده عددی را فراهم می‌کنند.
    north_category = workbook.getCell(0, 1, 0, "North")
    south_category = workbook.getCell(0, 2, 0, "South")
    chart.getChartData().getCategories().add(north_category)
    chart.getChartData().getCategories().add(south_category)
    north_value = workbook.getCell(0, 1, 1, jpype.JInt(120))
    south_value = workbook.getCell(0, 2, 1, jpype.JInt(150))
    series.getDataPoints().addDataPointForBarSeries(north_value)
    series.getDataPoints().addDataPointForBarSeries(south_value)

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نام سری حاصل `Product A 2026` است، با یک فاصله بین دو مقدار سلولی. legend این را به عنوان یک ورودی برای هر دو ستون نمایش می‌دهد. تصویر زیر نتیجه را نشان می‌دهد:

![نمودار ستون با مقادیر شمال و جنوب و نام سری مرکب Product A 2026 در legend](composite_series_name.png)

## **دریافت رنگ پر کردن خودکار سری**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) رنگی را برمی‌گرداند که از ایندکس سری و سبک نمودار محاسبه شده است. این رنگی است که وقتی پر کردن سری صریحاً تعریف نشده باشد استفاده می‌شود. فراخوانی این متد تنها رنگ محاسبه‌شده را می‌خواند؛ پر کردن جدیدی تعیین نمی‌کند.

مثال زیر رنگ خودکار هر سری پیش‌فرض را چاپ می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

خروجی مثال برای سبک پیش‌فرض نمودار:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

رنگ‌های دقیق به سبک و تم نمودار بستگی دارند.

## **تنظیم رنگ پر کردن معکوس برای یک سری نمودار**

برای سری‌های نوار، ستون و حباب، می‌توان با استفاده از [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) مقادیر منفی را با پر کردن متفاوت نمایش داد. پر کردن معمولی سری را به‌صورت صلب تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) تعیین کنید. اعداد منفی در دفتر کار بدون تغییر باقی می‌مانند؛ تنها رنگ نمایش آن‌ها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک سری جایگزین می‌کند. ردیف 0 کاربرگ نام سری را دارد، ستون 0 نام دسته‌ها را دارد و ستون 1 مقادیر را دارد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![رنگ پر کردن صلب معکوس](inverted_solid_fill_color.png)

می‌توانید برای یک نقطه معکوس‌سازی را از طریق [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) فعال کنید. در مثال زیر معکوس‌سازی برای سری غیرفعال و تنها برای نقطه انتخابی فعال شده است. نقطه همچنین مقدار منفی دریافت می‌کند تا اثر قابل مشاهده باشد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpade.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **پاک‑سازی مقدار یک نقطه داده خاص**

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول پشتیبان دفتر کار آن را به `None` تنظیم کنید. برای نمودار ستون، مقدار رسم‌شده از طریق [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را بر اساس تنظیمات خالی‑مقدار نمودار به‌عنوان خالی در نظر می‌گیرد.

مثال زیر تنها نقطه دوم در اولین سری را پاک می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نمودارهای پراکندگی از سلول‌های جداگانه X و Y استفاده می‌کنند و نمودارهای حباب نیز از یک سلول اندازه بهره می‌برند. فقط سلولی که نمایانگر مقداری است که می‌خواهید حذف کنید، پاک کنید. هنگام تمایلات به نگه داشتن نقاط دیگر، از فراخوانی [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) خودداری کنید، چراکه این متد تمام نقاط داده را از مجموعه حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های مخفی که مقادیر دارند، موردی متفاوت نسبت به سلول‌های خالی هستند. برای شامل یا مستثنی کردن داده‌ها از ردیف‌ها و ستون‌های مخفی کاربرگ، به [Include Data from Hidden Rows and Columns](/slides/fa/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns) مراجعه کنید.

یک سلول خالی دفتر کار نشان‌دهنده دادهٔ گمشده است؛ یک سلول حاوی `0` نمایانگر مقدار عددی شناخته‌شده است. برای خالی کردن یک سلول، [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) را با `None` فراخوانی کنید. یک صفر عددی همچنان صفر باقی می‌ماند صرف‌نظر از تنظیم خالی‑سلول.

از [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) برای انتخاب نحوهٔ نمایش سلول‌های خالی در نمودار استفاده کنید. این تنظیم برای کل نمودار اعمال می‌شود. این تنظیم نحوهٔ رسم خالی‌ها را تغییر می‌دهد، بدون این‌که سلول خالی دفتر کار را با صفر یا مقدار درونی‌سازی‌شده پر کند.

مثال خودکفای زیر یک نمودار خطی با یک سری ایجاد می‌کند، مقدار روز 3 را خالی می‌کند و همان نمودار را با هر حالت ذخیره می‌کند. نیازی به فایل ورودی نیست. [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) از کاربرگ 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام سری را نگه می‌دارد. دادهٔ نهایی `10, 20, empty, 30, 40` است.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayBlanksAsType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(0, 0, 1, "Measurements")
    series = chart_data.getSeries().add(series_name_cell, chart.getType())
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # روز ۳ را به‌طور واقعی خالی بگذارید، در حالی که دسته و نقطه داده آن را حفظ می‌کنید.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

هر فایل خروجی حالت پیش‌تنظیم‌شده قبل از ذخیره‌سازی را ذخیره می‌کند: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیرهٔ تنها یک نسخه، حالت مطلوب را تنظیم کنید و یک بار ارائه را ذخیره کنید به جای تکرار بر روی حالت‌ها.

مقایسهٔ زیر همان داده را در هر سه فایل نشان می‌دهد. روز 3 در دفتر کار در هر حالت خالی است:

![نمودارهای خطی با دادهٔ یکسان: Gap خط را در روز 3 قطع می‌کند، Zero خط را به صفر می‌برد و Span روز 2 را به روز 4 متصل می‌کند.](display_blanks_as.png)

اثر قابل مشاهده به نوع نمودار بستگی دارد. یک نمودار خطی سه حالت را به‌راحتی مقایسه می‌کند. نمودارهای نوار و ستون خطی برای اتصال بین دستهٔ گمشده ندارند، بنابراین `Span` نمی‌تواند بخشی که در بالا نشان داده شد را تولید کند؛ یک ستون گمشده و یک ستون صفر‑ارتفاع می‌توانند مشابه به نظر برسند. به‌طور مشابه، یک نمودار پراکندگی فقط با نقاط نشانگر خط متصل‌کننده‌ای ندارد. انتظار نتایج سه‌گانهٔ متمایز برای هر نوع نمودار را نداشته باشید؛ خروجی را برای نوعی که استفاده می‌کنید بررسی کنید.

## **تنظیم عرض شکاف سری**

عرض شکاف فضای بین خوشه‌های نوار یا ستون مجاور است که به‌صورت درصدی از عرض نوار یا ستون بیان می‌شود. مانند overlap، این تنظیم متعلق به گروه سری والد است نه به یک سری. یک بار برای گروه فراخوانی [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) کنید. مقدار بزرگتر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچکتر آنها را متراکم‌تر می‌سازد.

مثال زیر عرض شکاف را تغییر می‌دهد و فقط ارائهٔ نهایی را ذخیره می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![عرض شکاف](gap_width.png)

## **پرسش‌های متداول**

**کدام انواع نمودار از سری داده پشتیبانی می‌کند؟**

تمام انواع نمودار معرفی‌شده توسط شمارشگر [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) از داده‌های نمودار استفاده می‌کنند، اما سری‌های آنها ساختار ارزش یا تنظیمات یکسانی ندارند. به‌عنوان مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکندگی از مقادیر X و Y، و نمودارهای حباب اندازه حباب را اضافه می‌کنند. از روش ایجاد نقطه‑داده‌ای که با نوع سری هم‌خوانی دارد استفاده کنید. گزینه‌هایی مانند overlap و gap width فقط برای گروه‌های نوار یا ستون سازگار اعمال می‌شوند.

**یک گروه سری نمودار چیست؟**

یک [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) شامل سری‌های سازگاری است که تنظیمات رسم سطح‑گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک سری دسترسی پیدا می‌شود لزوماً همه سری‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه‌ساخته دارای داده پیش‌فرض است؟**

بله. به صورت پیش‌فرض، [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) سری‌های نمونه، دسته‌ها و مقادیر نمونه را ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن مجموعهٔ دادهٔ کاملاً سفارشی، هر دو مجموعهٔ سری و دسته را پاک کنید. یک overload نیز می‌تواند نموداری بدون داده پیش‌فرض ایجاد کند.

**چگونه اشیاء نمودار به سلول‌های دفتر کار متصل می‌شوند؟**

نام‌های سری، برچسب‌های دسته و مقادیر نقطه‑داده به سلول‌های یک [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول مرجع، عنصر مربوط به نمودار را به‌روز می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر سری را هم‌راستا نگه دارید تا هر نقطه زیر دستهٔ موردنظر رسم شود.

**چگونه یک نقطه را به‌جای کل سری پاک کنم؟**

سلول مقدار مربوطه را به `None` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان یک نقطهٔ خالی حفظ شود. فقط وقتی می‌خواهید تمام نقاط یک سری را حذف کنید، از [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) استفاده کنید. اگر دسته‌ها را نیز حذف می‌کنید، هر سری را به‌روزرسانی کنید تا مقادیرشان با مجموعهٔ دسته هم‌راستا بماند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و مقداری که از طریق [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) تنظیم شده است بستگی دارد. نمودارهای پشتیبانی‑شده می‌توانند خالی‌ها را به‌عنوان فاصله، به‌عنوان مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که معنی دادهٔ گمشده را در ارائهٔ شما منعکس کند. برای مثال کامل و مقایسهٔ بصری به بخش [Control the Display of Empty Cells](#control-the-display-of-empty-cells) مراجعه کنید.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای سری‌های نوار، ستون و حباب پشتیبانی‑شده، [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) را فراخوانی کنید و رنگ بازگردانده‌شده توسط [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) را تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ فردی از طریق [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) بازنویسی کنید. این متدها فقط قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**کدام قالب‌بندی برنده می‌شود وقتی هم سری و هم نقطه قالب‌بندی شده باشند؟**

قالب‌بندی صریح نقطه‑داده برای همان نقطه اولویت دارد. نقاط دیگر ادامه می‌دهند از قالب صریح سری یا، اگر قالب سری تعریف نشده باشد، از سبک و تم خودکار نمودار استفاده کنند. تنظیمات گروه مانند overlap و gap width بر چیدمان تأثیر می‌گذارند و جایگزین قالب‌بندی نقطه‑سطحی نیستند.

**آیا محدودیتی برای تعداد سری‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانه‌ای برای تعداد سری‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظهٔ موجود، زمان رندر و خوانایی نمودار تعیین‌کنندهٔ حد قابل استفاده هستند.

**چه کاری باید انجام دهم وقتی ستون‌ها بیش از حد نزدیک یا دور از هم هستند؟**

بر روی گروه سری والد مناسب از [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) فراخوانی کنید. مقدار را افزایش دهید تا فضای بین خوشه‌ها گسترده‌تر شود یا مقدار را کاهش دهید تا خوشه‌ها به‌یکدیگر نزدیک‌تر شوند.