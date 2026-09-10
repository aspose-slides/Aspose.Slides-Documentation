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
- سلول کتاب‌کار
- فاصله سری
- مقدار منفی
- پاورپوینت
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه سری‌های نمودار، نقاط داده، سلول‌های کتاب‌کار، قالب‌بندی، همپوشانی، عرض فاصله، و مقادیر منفی را در ارائه‌ها با Aspose.Slides برای پایتون از طریق جاوا مدیریت کنید."
---
## **نمای کلی**

یک نمودار داده‌های ترسیم‌شده خود را در یک کتاب‌کار داده‌های نمودار ذخیره می‌کند. یک [ChartSeries](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/) نمایانگر یک مجموعه مقادیر مرتبط است و هر [ChartDataPoint](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapoint/) در این مجموعه به یک یا چند سلول کتاب‌کار ارجاع می‌دهد. اشیاء [ChartCategory](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartcategory/) برچسب‌ها یا مقادیر گروه‌بندی را که بین مجموعه‌ها مشترک است، فراهم می‌کنند. بنابراین نام مجموعه، دسته‌ها و مقادیر نقاط به اشیاء [ChartDataCell](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatacell/) متصل هستند و تنها به‌عنوان متن نمایشی ذخیره نمی‌شوند.

برای یک نمودار دسته‌ای معمول، کتاب‌کار پیش‌فرض ردیف 0 را برای نام‌های سری، ستون 0 را برای نام‌های دسته و سلول‌های باقی‌مانده را برای مقادیر سری استفاده می‌کند. شاخص‌های کاربرگ، ردیف و ستون که به [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdataworkbook/#getCell) ارسال می‌شوند، بر پایه صفر هستند. این چیدمان زمانی که نمودار را با داده‌های پیش‌فرض ایجاد می‌کنید مفید است، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای ارائه‌ای که بارگذاری شده است، قبل از تغییر مقادیر کتاب‌کار، سلول‌هایی که توسط سری‌ها، دسته‌ها و نقاط داده ارجاع داده شده‌اند را بررسی کنید.

تنظیمات نمودار در سه حوزه مختلف قرار دارند:

- تنظیمات در سطح سری، مانند [ChartSeries.getFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getFormat)، ظاهر پیش‌فرض تمام نقاط یک سری را فراهم می‌کند.
- تنظیمات نقاط داده، مانند [ChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapoint/#getFormat)، ظاهر سری را برای یک نقطه خاص بازنویسی می‌کند.
- تنظیمات گروهی برای سری‌های سازگاری که به همان [ChartSeriesGroup](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseriesgroup/) تعلق دارند، اعمال می‌شود. برای تنظیم گزینه‌هایی مانند همپوشانی یا عرض فاصله، از [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getParentSeriesGroup) استفاده کنید.

زمانی که هیچ پر کردن صریحی برای نقطه یا سری تعیین نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. هنگامی که هر دو قالب‌بندی سری و نقطه وجود داشته باشد، قالب‌بندی نقطه بر آن نقطه اولویت دارد.

![نمودار-سری-پاورپوینت](chart-series-powerpoint.png)

## **تنظیم همپوشانی سری نمودار**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getOverlap) گزارش می‌دهد که نوارها یا ستون‌ها در یک نمودار دوبعدی تا چه میزان از –100 تا 100 درصد همپوشانی دارند. این یک پیش‌نمایش فقط‑خواندنی از تنظیمات در گروه سری والد است. برای به‌روزرسانی همه سری‌های سازگار در آن گروه از [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseriesgroup/#setOverlap) استفاده کنید. این گزینه به انواع نمودارهایی که نوارها یا ستون‌های گروهی را نمایش می‌دهند، اعمال می‌شود؛ برای گروه‌های سری نامرتبط در یک نمودار ترکیبی تأثیری ندارد.

مثال زیر همپوشانی را برای گروهی که شامل اولین سری است تنظیم می‌کند:

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

    # نمودار جدید شامل سری‌های نمونه، دسته‌ها و مقادیر است.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![همپوشانی سری](series_overlap.png)

## **تغییر رنگ پر کردن سری**

از [ChartSeries.getFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getFormat) برای تنظیم پر کردن پیش‌فرض یک سری کامل استفاده کنید. اگر برای یک نقطه پر کردن صریحی تنظیم شده باشد، تنظیمات [ChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapoint/#getFormat) آن پر کردن را برای آن نقطه بازنویسی می‌کند.

مثال زیر پر کردن رنگیء آبی ثابت را به اولین سری اعمال می‌کند:

```python
import jpime
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

نام یک سری در کتاب‌کار داده‌های نمودار ذخیره می‌شود و به‌طور معمول در راهنما (legend) نمایش داده می‌شود. در کتاب‌کار پیش‌فرض که برای یک نمودار ستونی خوشه‌ای ساخته می‌شود، سلول B1 که در ردیف 0، ستون 1 قرار دارد، نام اولین سری را شامل می‌شود. متغیرهای نام‌دار در مثال زیر این ساختار را به طور صریح نشان می‌دهند:

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

همچنین می‌توانید سلولی که توسط [ChartSeries.getName](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getName) ارجاع شده است، به‌روزرسانی کنید. این روش از فرض اینکه ردیف و ستونی خاص در یک نمودار موجود وجود دارد، جلوگیری می‌کند:

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

## **دریافت رنگ پر کردن خودکار سری**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) رنگی را برمی‌گرداند که بر پایهٔ اندیس سری و سبک نمودار محاسبه می‌شود. این همان رنگی است که وقتی پر کردن سری به‌صورت صریح تعریف نشده باشد، استفاده می‌شود. فراخوانی این متد فقط رنگ محاسبه‌شده را می‌خواند؛ پر کردن جدیدی تخصیص نمی‌دهد.

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

رنگ‌های دقیق به سبک و تم نمودار وابسته است.

## **تنظیم رنگ پر کردن معکوس برای یک سری نمودار**

برای سری‌های نوار، ستون و حباب، می‌توان با [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#setInvertIfNegative) مقادیر منفی را با پر کردن متفاوتی نمایش داد. پر کردن معمولی سری را به حالت ثابت تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) اختصاص دهید. اعداد منفی در کتاب‌کار بدون تغییر می‌مانند؛ فقط رنگ نمایش آن‌ها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک سری جایگزین می‌کند. ردیف 0 کاربرگ نام سری را دارد، ستون 0 نام‌های دسته و ستون 1 مقادیر را دارد:

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

![رنگ پر کردن ثابت معکوس](inverted_solid_fill_color.png)

می‌توانید معکوس‌سازی را برای یک نقطه از طریق [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) فعال کنید. در مثال زیر، معکوس‌سازی برای سری غیرفعال و تنها برای نقطهٔ انتخاب‌شده فعال شده است. همچنین برای قابل رؤیت شدن اثر، به نقطه مقدار منفی اختصاص داده شده است:

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

## **پاک‌سازی مقدار نقطه داده خاص**

برای خالی کردن یک نقطه بدون حذف سایر نقاط، سلول کتاب‌کار پشتیبان آن را به `None` تنظیم کنید. برای یک نمودار ستونی، مقدار ترسیم‌شده از طریق [ChartDataPoint.getValue](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapoint/#getValue) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را بر اساس تنظیمات خالی‌کردن نمودار به‌عنوان مقدار خالی در نظر می‌گیرد.

مثال زیر فقط نقطه دوم در اولین سری را پاک می‌کند:

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

نمودارهای پراکنده از سلول‌های جداگانه X و Y استفاده می‌کنند و نمودارهای حبابی نیز از سلول اندازه استفاده می‌کنند. فقط سلولی را که مقدار مورد نظر شما را نشان می‌دهد، پاک کنید. وقتی می‌خواهید سایر نقاط را حفظ کنید، از [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapointcollection/#clear) استفاده نکنید، زیرا این متد تمام نقاط داده را از مجموعه حذف می‌کند.

## **تنظیم عرض فاصله سری**

عرض فاصله به‌عنوان فضای بین خوشه‌های نوار یا ستون مجاور تعریف می‌شود و به‌صورت درصدی از عرض نوار یا ستون بیان می‌گردد. مشابه همپوشانی، این تنظیم به گروه سری والد تعلق دارد نه به یک سری منفرد. برای گروه یک بار از [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseriesgroup/#setGapWidth) فراخوانی کنید. مقدار بزرگتر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچکتر آن‌ها را متراکم‌تر می‌سازد.

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

![عرض فاصله](gap_width.png)

## **سؤال‌های متداول**

**کدام انواع نمودار از سری‌های داده پشتیبانی می‌کنند؟**

تمام انواع نمودارهای موجود در شمارندهٔ [ChartType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/charttype/) از داده‌های نمودار استفاده می‌کنند، اما سری‌های آن‌ها ساختار یا تنظیمات ارزش یکسانی ندارند. برای مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکنده از مقادیر X و Y، و نمودارهای حبابی اندازه حباب را اضافه می‌کنند. از متد ایجاد نقطه‑داده‌ای که با نوع سری مطابقت دارد استفاده کنید. گزینه‌هایی همچون همپوشانی و عرض فاصله فقط برای گروه‌های نوار یا ستون سازگار اعمال می‌شوند.

**یک گروه سری نمودار چیست؟**

یک [ChartSeriesGroup](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseriesgroup/) شامل سری‌های سازگاری است که تنظیمات رسم در سطح گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد؛ بنابراین تغییر گروهی که از طریق یک سری به آن دسترسی پیدا می‌کنید، لزوماً تمام سری‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه‌ساخته داده‌های پیش‌فرض دارد؟**

بله. به‌صورت پیش‌فرض، [ShapeCollection.addChart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addChart) نمونه‌ای از سری‌ها، دسته‌ها و مقادیر را ایجاد می‌کند. می‌توانید آن سلول‌ها را ویرایش کنید یا قبل از افزودن یک مجموعه دادهٔ کاملاً سفارشی، هر دو مجموعهٔ سری و دسته را پاک کنید. همچنین می‌توانید بارگذاری‌ای داشته باشید که نمودار را بدون دادهٔ پیش‌فرض ایجاد می‌کند.

**چگونه اشیاء نمودار به سلول‌های کتاب‌کار متصل می‌شوند؟**

نام‌های سری، برچسب‌های دسته و مقادیر نقطه داده به سلول‌های یک [ChartDataWorkbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده، المان مربوط به نمودار را به‌روز می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقدار سری را طوری هم‌راستا کنید که هر نقطه تحت دستهٔ موردنظر ترسیم شود.

**چگونه یک نقطه را به‌جای کل سری پاک‌سازی کنم؟**

سلول مقدار مربوطه را به `None` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان نقطهٔ خالی حفظ شود. تنها وقتی می‌خواهید تمام نقاط یک سری را حذف کنید، از [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapointcollection/#clear) استفاده کنید. اگر دسته‌ها را نیز حذف می‌کنید، باید تمام سری‌ها را به‌روز کنید تا مقادیر آن‌ها با مجموعهٔ دسته‌ها هم‌راستا بماند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و مقدار تنظیم‌شده از طریق [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#setDisplayBlanksAs) بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت شکاف، مقدار صفر یا با اتصال به نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که با معنی داده‌های مفقود در ارائهٔ شما سازگار باشد.

**مقدارهای منفی چگونه قالب‌بندی می‌شوند؟**

برای سری‌های نوار، ستون و حباب پشتیبانی‌شده، با فراخوانی [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#setInvertIfNegative) و تنظیم رنگی که از [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) دریافت می‌کنید، می‌توانید قالب‌بندی منفی را اعمال کنید. می‌توانید این رفتار را برای یک نقطهٔ تک با [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) بازنویسی کنید. این متدها فقط قالب‌بندی را تحت تأثیر قرار می‌دهند و مقادیر عددی ذخیره‌شده را تغییر نمی‌دهند.

**وقتی هم سری و هم نقطه قالب‌بندی شوند، کدام برتری دارد؟**

قالب‌بندی واضح نقطه داده برای آن نقطه اولویت دارد. نقاط دیگر به قالب‌بندی صریح سری یا، در صورت عدم تعریف قالب‌بندی سری، به سبک و تم خودکار نمودار ادامه می‌دهند. تنظیمات گروهی مانند همپوشانی و عرض فاصله برچیدگی را کنترل می‌کنند و بازنویسی‌های قالب‌بندی سطح نقطه نیستند.

**آیا محدودیتی برای تعداد سری‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانه‌ای برای تعداد سری‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظهٔ موجود، زمان رندر و خوانایی نمودار تعیین‌کنندهٔ حد معقولی هستند.

**زمانی که ستون‌ها بیش از حد نزدیک یا دور هستند، چه کاری باید انجام دهم؟**

روی گروه سری والد مناسب [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseriesgroup/#setGapWidth) فراخوانی کنید. مقدار را افزایش دهید تا فضای بین خوشه‌ها وسیع‌تر شود یا کاهش دهید تا خوشه‌ها به‌یکدیگر نزدیک‌تر شوند.