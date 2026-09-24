---
title: مدیریت مجموعه‌های داده نمودار در ارائه‌ها با Python
linktitle: مجموعه‌های داده
type: docs
url: /fa/python-java/chart-series/
keywords:
- مجموعه نمودار
- همپوشانی مجموعه
- رنگ مجموعه
- نام مجموعه
- نقطه داده
- سلول دفتر کار
- فاصله مجموعه
- مقدار منفی
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه مجموعه‌های نمودار، نقاط داده، سلول‌های دفتر کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با Aspose.Slides برای Python از طریق Java مدیریت کنید."
---
## **نمای کلی**

یک نمودار داده‌های ترسیم‌شده خود را در یک دفتر کار داده‌های نمودار ذخیره می‌کند. یک [ChartSeries](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/) یک مجموعه مقادیر مرتبط را نشان می‌دهد و هر [ChartDataPoint](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapoint/) در این مجموعه به یک یا چند سلول دفتر کار ارجاع می‌دهد. اشیای [ChartCategory](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartcategory/) برچسب‌ها یا مقادیر گروه‌آوری مشترک بین مجموعه‌ها را فراهم می‌کنند. بنابراین نام مجموعه، دسته‌ها و مقادیر نقاط به جای اینکه فقط به‌صورت متن نمایش داده شوند، به اشیای [ChartDataCell](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatacell/) مرتبط می‌شوند.

برای یک نمودار دسته‌ای معمولی، دفتر کار پیش‌فرض ردیف 0 را برای نام‌های مجموعه، ستون 0 را برای نام‌های دسته و بقیه سلول‌ها را برای مقادیر مجموعه استفاده می‌کند. ایندکس‌های ورق کار، ردیف و ستون که به [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdataworkbook/#getCell) پاس می‌شوند، صفر‑محور هستند. این چیدمان وقتی نموداری را با داده‌های پیش‌فرض ایجاد می‌کنید مفید است، اما فرض نکنید که هر نمودار موجود از این چیدمان استفاده می‌کند. برای یک ارائهٔ بارگذاری‌شده، قبل از تغییر مقادیر دفتر کار، سلول‌های مورد ارجاع مجموعه‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار در سه سطح متفاوت وجود دارد:

- تنظیمات سطح مجموعه، مانند [ChartSeries.getFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getFormat)، ظاهر پیش‌فرض همهٔ نقاط در یک مجموعه را تعیین می‌کند.
- تنظیمات سطح نقطهٔ داده، مانند [ChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapoint/#getFormat)، ظاهر مجموعه را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروهی بر روی مجموعه‌های سازگاری که به یک [ChartSeriesGroup](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseriesgroup/) تعلق دارند اعمال می‌شود. برای تنظیم گزینه‌هایی مانند پوشش یا عرض فاصله، از [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getParentSeriesGroup) استفاده کنید.

وقتی هیچ پر کردن صریحی برای نقطه یا مجموعه تعیین نشده باشد، سبک و قالب‌بندی نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم‌زمان قالب‌بندی مجموعه و نقطه موجود باشد، قالب‌بندی نقطه در آن نقطه برتری دارد.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تنظیم پوشش همپوشانی مجموعهٔ نمودار**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getOverlap) میزان همپوشانی میله‌ها یا ستون‌ها را در یک نمودار دو‑بعدی، از ‎‑100 تا 100 درصد، گزارش می‌دهد. این مقدار فقط یک تصویر خواندنی از تنظیمات گروه والد مجموعه است. برای به‌روزرسانی همهٔ مجموعه‌های سازگار در آن گروه، از [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseriesgroup/#setOverlap) استفاده کنید. این گزینه برای انواع نمودارهایی که میله یا ستون‌های گروهی نمایش می‌دهند اعمال می‌شود؛ بر گروه‌های مجموعهٔ نامرتبط در یک نمودار ترکیبی تأثیری ندارد.

مثال زیر همپوشانی گروهی که شامل اولین مجموعه است تنظیم می‌کند:

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

    # نمودار جدید شامل مجموعه‌های نمونه، دسته‌ها و مقادیر است.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![The series overlap](series_overlap.png)

## **تغییر رنگ پر کردن مجموعه**

از [ChartSeries.getFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getFormat) برای تنظیم پر کردن پیش‌فرض یک مجموعهٔ کامل استفاده کنید. اگر برای یک نقطهٔ داده پر کردن صریحی تنظیم شده باشد، تنظیم [ChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapoint/#getFormat) آن، پر کردن مجموعه را برای همان نقطه بازنویسی می‌کند.

مثال زیر پر کردن آبی ثابت را برای اولین مجموعه اعمال می‌کند:

```python
import jpile
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpile.JClass("java.awt.Color")

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

![The color of the series](series_color.png)

## **تغییر نام مجموعه**

نام یک مجموعه در دفتر کار داده‌های نمودار ذخیره می‌شود و معمولا در افسانه (legend) نمایش داده می‌شود. در دفتر کار پیش‌فرض که برای یک نمودار ستونی خوشه‌ای ساخته می‌شود، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین مجموعه را شامل می‌شود. متغیرهای نام‌گذاری‌شده در مثال زیر این ساختار را به‌وضوح نشان می‌دهند:

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

همچنین می‌توانید سلولی را که قبلا توسط [ChartSeries.getName](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getName) ارجاع شده به‌روز کنید. این روش از فرض یک ردیف و ستون خاص در یک نمودار موجود جلوگیری می‌کند:

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

![The series name](series_name.png)

## **دریافت رنگ پر کردن خودکار مجموعه**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) رنگی که از اندیس مجموعه و سبک نمودار محاسبه می‌شود را برمی‌گرداند. این همان رنگی است که وقتی پر کردن مجموعه به‌صورت صریح تعریف نشده باشد، استفاده می‌شود. فراخوانی این متد فقط رنگ محاسبه‌شده را می‌خواند؛ پر کردن جدیدی اختصاص نمی‌دهد.

مثال زیر رنگ خودکار هر مجموعهٔ پیش‌فرض را چاپ می‌کند:

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

خروجی نمونه برای سبک نمودار پیش‌فرض:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

رنگ‌های دقیق به سبک و قالب‌بندی نمودار بستگی دارند.

## **تنظیم رنگ پر کردن معکوس برای مجموعهٔ نمودار**

برای مجموعه‌های میله‌ای، ستونی و حبابی، می‌توان با [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#setInvertIfNegative) مقادیر منفی را با پر کردن متفاوتی نمایش داد. پر کردن معمولی مجموعه را به‌صورت ثابت تنظیم کنید، معکوس کردن را فعال کنید و رنگ مقدار منفی را از طریق [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) اختصاص دهید. اعداد منفی در دفتر کار همان‌گونه باقی می‌مانند؛ فقط رنگ نمایش آن‌ها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک مجموعه جایگزین می‌کند. ردیف 0 ورق کار نام مجموعه را دارد، ستون 0 نام دسته‌ها و ستون 1 مقادیر را شامل می‌شود:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

می‌توانید برای یک نقطهٔ خاص معکوس کردن را از طریق [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) فعال کنید. در مثال زیر، معکوس برای مجموعه غیرفعال و فقط برای نقطهٔ انتخاب‌شده فعال شده است. همچنین برای قابل رؤیت شدن اثر، به نقطه مقدار منفی اختصاص داده شده است:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

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

## **پاک کردن مقدار یک نقطهٔ دادهٔ خاص**

برای حذف یک نقطه بدون حذف سایر نقاط، سلول پشت صحنهٔ دفتر کار آن را به `None` تنظیم کنید. برای یک نمودار ستونی، مقدار ترسیم‌شده از طریق [ChartDataPoint.getValue](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapoint/#getValue) قابل دسترسی است. نقطهٔ داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را به‌عنوان خالی طبق تنظیمات مقدار خالی نمودار در نظر می‌گیرد.

مثال زیر فقط نقطهٔ دوم در اولین مجموعه را پاک می‌کند:

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

نمودارهای پراکنده از سلول‌های جداگانه X و Y استفاده می‌کنند و نمودارهای حبابی نیز از سلول اندازه استفاده می‌کنند. فقط سلولی را که نمایانگر مقداری است که قصد حذف آن را دارید، پاک کنید. هنگام تمایل به حفظ سایر نقاط، از فراخوانی [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapointcollection/#clear) خودداری کنید، زیرا این متد تمام نقاط دادهٔ مجموعه را حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

یک سلول خالی در دفتر کار نمایانگر دادهٔ گمشده است؛ یک سلول حاوی `0` نمایانگر مقدار عددی شناخته‌شده‌ای است. برای خالی کردن یک سلول، [ChartDataCell.setValue](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatacell/#setValue) را با `None` فراخوانی کنید. مقدار عددی صفر صرفاً صفر می‌ماند، صرف‌نظر از تنظیم خالی‌سازی سلول.

از [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#setDisplayBlanksAs) برای انتخاب نحوهٔ نمایش سلول‌های خالی توسط نمودار استفاده کنید. این تنظیم برای کل نمودار اعمال می‌شود. این گزینه نحوهٔ ترسیم خالی‌ها را تغییر می‌دهد، بدون این‌که سلول خالی دفتر کار با صفر یا مقدار درونی‌سازی‌شده پر شود.

مثال خودکفا زیر یک نمودار خطی با یک مجموعه می‌سازد، مقدار روز 3 را خالی می‌کند و همان نمودار را با هر حالت ذخیره می‌کند. نیازی به فایل ورودی نیست. [ChartDataWorkbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdataworkbook/) از ورق کار 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام مجموعه را نگه می‌دارد. دادهٔ نهایی `10, 20, empty, 30, 40` است.

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

    # روز 3 را واقعاً خالی بگذارید، در حالی که دسته و نقطه داده آن را نگه می‌دارید.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

هر فایل خروجی حالت انتخاب‌شده را قبل از ذخیره‌سازی ذخیره می‌کند: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیرهٔ فقط یک نسخه، حالت دلخواه را تنظیم کنید و یک‌بار ارائه را ذخیره کنید به‌جای حلقه روی حالت‌ها.

مقایسهٔ زیر همان داده‌ها را در هر سه فایل نشان می‌دهد. روز 3 در هر حالت در دفتر کار خالی است:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

اثر قابل مشاهده به نوع نمودار بستگی دارد. یک نمودار خطی سه حالت را به‌راحتی مقایسه می‌کند. نمودارهای میله‌ای و ستونی خطی برای اتصال میان یک دستهٔ گمشده ندارند، بنابراین `Span` نمی‌تواند بخشی که در بالا نشان داده شده را تولید کند؛ یک ستون خالی و یک ستون با ارتفاع صفر نیز می‌توانند مشابه به‌نظر برسند. به‌طور مشابه، یک نمودار پراکنده فقط با نشانگرها خط متصلی ندارد. انتظار نتایج متفاوت برای هر نوع نمودار را نداشته باشید؛ خروجی را برای نوعی که استفاده می‌کنید بررسی کنید.

## **تنظیم عرض فاصلهٔ مجموعه**

عرض فاصله فضای بین خوشه‌های میله یا ستون مجاور است و به‌عنوان درصدی از عرض میله یا ستون بیان می‌شود. مانند همپوشانی، این تنظیم به گروه والد مجموعه تعلق دارد نه به یک مجموعهٔ منفرد. یک‌بار برای گروه [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseriesgroup/#setGapWidth) فراخوانی کنید. مقدار بزرگتر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچکتر آن‌ها را متراکم‌تر می‌سازد.

مثال زیر عرض فاصله را تغییر می‌دهد و فقط ارائهٔ نهایی را ذخیره می‌کند:

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

![The gap width](gap_width.png)

## **سؤالات متداول**

**کدام انواع نمودار از مجموعه داده پشتیبانی می‌کنند؟**

تمامی انواع نمودارهای نشان‌داده‌شده توسط شمارش‌گر [ChartType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/charttype/) از داده‌های نمودار استفاده می‌کنند، اما ساختار ارزش یا تنظیمات مجموعه‌های آنها یکسان نیست. به عنوان مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکنده از مقادیر X و Y، و نمودارهای حبابی اندازهٔ حباب را اضافه می‌کنند. از روش ایجاد نقطهٔ داده‌ای که با نوع مجموعه مطابقت دارد استفاده کنید. گزینه‌هایی مانند همپوشانی و عرض فاصله فقط برای گروه‌های میله‌ای یا ستونی سازگار کاربرد دارد.

**گروه مجموعهٔ نمودار چیست؟**

یک [ChartSeriesGroup](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseriesgroup/) شامل مجموعه‌های سازگاری است که تنظیمات ترسیم سطح‑گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک مجموعه دسترسی یافتید، لزوماً همهٔ مجموعه‌های نمودار را تحت تأثیر قرار نمی‌دهد.

**آیا یک نمودار تازه‌ساخته دادهٔ پیش‌فرض دارد؟**

بله. به‌صورت پیش‌فرض، [ShapeCollection.addChart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addChart) مجموعه‌ها، دسته‌ها و مقادیر نمونه ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن مجموعهٔ دادهٔ کاملاً سفارشی، هر دو مجموعه و دسته را پاک کنید. یک بار دیگر می‌توانید نموداری بدون دادهٔ پیش‌فرض نیز ایجاد کنید.

**اشیای نمودار چگونه به سلول‌های دفتر کار متصل می‌شوند؟**

نام‌های مجموعه، برچسب‌های دسته و مقادیر نقطهٔ داده به سلول‌های موجود در یک [ChartDataWorkbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده، عنصر مربوط به نمودار را به‌روز می‌کند. هنگام ساخت دادهٔ سفارشی، ردیف‌های دسته و ردیف‌های مقدار مجموعه را طوری تنظیم کنید که هر نقطه زیر دستهٔ موردنظر ترسیم شود.

**چگونه یک نقطه را به‌جای کل مجموعه پاک کنم؟**

سلول مقدار مربوطه را به `None` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان نقطهٔ خالی حفظ شود. فقط زمانی که می‌خواهید تمام نقاط یک مجموعه را حذف کنید، از [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapointcollection/#clear) استفاده کنید. اگر دسته‌ها را نیز حذف می‌کنید، همهٔ مجموعه‌ها را به‌روزرسانی کنید تا مقادیرشان با مجموعهٔ دسته‌ها هم‌تراز بماند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و مقداری که از طریق [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#setDisplayBlanksAs) تنظیم شده است بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت فاصله، به‌صورت مقادیر صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که معنای دادهٔ گمشده را در ارائهٔ شما بازتاب دهد. برای مثال کامل و مقایسهٔ بصری به بخش «کنترل نمایش سلول‌های خالی» مراجعه کنید.

**مقدارهای منفی چگونه قالب‌بندی می‌شوند؟**

برای مجموعه‌های میله‌ای، ستونی و حبابی پشتیبانی‌شده، [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#setInvertIfNegative) را فراخوانی کنید و رنگ بازگشتی از طریق [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) را تنظیم کنید. می‌توانید این رفتار را برای یک نقطهٔ منفرد با [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) بازنویسی کنید. این متدها فقط قالب‌بندی را تحت‌اثر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**وقتی هم مجموعه و هم نقطه قالب‌بندی شوند، کدام برنده می‌شود؟**

قالب‌بندی صریح نقطهٔ داده برای همان نقطه برتری دارد. نقاط دیگر همچنان از قالب‌بندی صریح مجموعه یا، وقتی قالب‌بندی مجموعه تعریف نشده باشد، از سبک و قالب‌بندی خودکار نمودار استفاده می‌کنند. تنظیمات گروهی مانند همپوشانی و عرض فاصله برچسب‌های چیدمان هستند و بازنویسی قالب‌بندی سطح نقطه نیستند.

**آیا محدودیتی برای تعداد مجموعه‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت شمارش‌گر مجموعهٔ ثابت جداگانه‌ای اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظه‌ی موجود، زمان رندر و قابلیت خواندن نمودار، تعیین‌کنندهٔ حد عملی هستند.

**چه کاری باید انجام دهم وقتی ستون‌ها بیش از حد نزدیک یا بیش از حد دور هستند؟**

بر روی گروه والد مناسب، [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseriesgroup/#setGapWidth) را فراخوانی کنید. برای افزایش فاصله بین خوشه‌ها مقدار را بزرگ کنید یا برای نزدیک‌تر کردن خوشه‌ها مقدار را کوچک کنید.