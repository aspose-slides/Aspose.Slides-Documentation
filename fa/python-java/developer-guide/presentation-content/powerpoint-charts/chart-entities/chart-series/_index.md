---
title: مدیریت سری داده‌های نمودار در ارائه‌ها با پایتون
linktitle: سری داده
type: docs
url: /fa/python-java/chart-series/
keywords:
- سری نمودار
- همپوشانی سری
- رنگ سری
- نام سری
- نقطه داده
- سلول کتاب کار
- فاصله سری
- مقدار منفی
- پاورپوینت
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه سری‌های نمودار، نقاط داده، سلول‌های کتاب کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با Aspose.Slides برای پایتون از طریق جاوا مدیریت کنید."
---
## **مروری کلی**

یک نمودار داده‌های ترسیم‌شده خود را در یک کتاب‌کار داده‌های نمودار ذخیره می‌کند. یک [ChartSeries](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/) نشان‌دهنده یک مجموعه از مقادیر مرتبط است و هر [ChartDataPoint](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapoint/) در این مجموعه به یک یا چند سلول کتاب‌کار اشاره می‌کند. اشیای [ChartCategory](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartcategory/) برچسب‌ها یا مقادیر گروه‌بندی شده‌ای را فراهم می‌آورند که بین مجموعه‌ها مشترک است. بنابراین نام مجموعه، دسته‌ها و مقادیر نقاط به جای این‌که فقط به‌صورت متن نمایش داده شوند، به اشیای [ChartDataCell](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatacell/) متصل می‌شوند.

برای یک نمودار دسته‌ای معمولی، کتاب‌کار پیش‌فرض ردیف 0 را برای نام مجموعه‌ها، ستون 0 را برای نام دسته‌ها و سلول‌های باقی‌مانده را برای مقادیر مجموعه‌ها استفاده می‌کند. اندیس‌های کاربرگ، ردیف و ستون که به متد [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdataworkbook/#getCell) پاس می‌شوند، از صفر شروع می‌شوند. این چیدمان زمانی مفید است که با داده‌های پیش‌فرض یک نمودار ایجاد می‌کنید، اما فرض نکنید که هر نمودار موجود از این چیدمان استفاده می‌کند. برای یک ارائه‌ بارگذاری‌شده، پیش از تغییر مقادیر کتاب‌کار، سلول‌های ارجاع‌شده توسط مجموعه‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار دارای سه حوزه متفاوت هستند:

- تنظیمات سطح مجموعه، مانند [ChartSeries.getFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getFormat)، ظاهر پیش‌فرض همه نقاط در یک مجموعه را فراهم می‌آورند.
- تنظیمات نقطه داده، مانند [ChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapoint/#getFormat)، ظاهر مجموعه را برای یک نقطه خاص بازنویسی می‌کنند.
- تنظیمات گروه بر روی مجموعه‌های سازگاری که به همان [ChartSeriesGroup](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseriesgroup/) تعلق دارند اعمال می‌شوند. برای تنظیم گزینه‌هایی مانند overlap یا gap width، از [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getParentSeriesGroup) استفاده کنید.

زمانی که هیچ پر کردن صریحی برای نقطه یا مجموعه تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم تنظیمات مجموعه و هم تنظیمات نقطه وجود داشته باشد، تنظیمات نقطه برای آن نقطه اولویت دارد.

![نمودار‑سری‑پاورپوینت](chart-series-powerpoint.png)

## **تنظیم Overlap مجموعه نمودار**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getOverlap) میزان همپوشانی نوارها یا ستون‌ها در یک نمودار دو‑بعدی را از ‎-100 تا 100 درصد گزارش می‌دهد. این مقدار تنها یک تصویر فقط‑خواندنی از تنظیمات گروه مجموعه والد است. برای به‌روزرسانی تمام مجموعه‌های سازگار در آن گروه، از [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseriesgroup/#setOverlap) استفاده کنید. این گزینه برای انواع نموداری که نوارها یا ستون‌های گروهی را نمایش می‌دهند اعمال می‌شود؛ روی گروه‌های مجموعهٔ نامرتبط در یک نمودار ترکیبی تأثیری ندارد.

مثال زیر overlap را برای گروهی که شامل اولین مجموعه است تنظیم می‌کند:

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

![همپوشانی مجموعه‌ها](series_overlap.png)

## **تغییر رنگ پر کردن مجموعه**

از [ChartSeries.getFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getFormat) برای تنظیم پر کردن پیش‌فرض کل یک مجموعه استفاده کنید. اگر برای یک نقطه پر کردن صریحی تعریف شده باشد، تنظیمات [ChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapoint/#getFormat) آن نقطه، پر کردن مجموعه را بازنویسی می‌کند.

مثال زیر یک پر کردن آبی ثابت به اولین مجموعه اعمال می‌کند:

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

![رنگ مجموعه](series_color.png)

## **تغییر نام مجموعه**

نام یک مجموعه در کتاب‌کار داده‌های نمودار ذخیره می‌شود و به طور معمول در راهنمایی (legend) نمایش داده می‌شود. در کتاب‌کار پیش‌فرض ساخته‌شده برای یک نمودار ستون‌گروهی، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین مجموعه را دارد. متغیرهای نام‌گذاری‌شده در مثال زیر این ساختار را صریح می‌کنند:

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

همچنین می‌توانید سلولی را که توسط [ChartSeries.getName](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getName) ارجاع داده شده است، به‌روزرسانی کنید. این روش از فرض یک ردیف و ستون خاص در یک نمودار موجود جلوگیری می‌کند:

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

![نام مجموعه](series_name.png)

## **دریافت رنگ پر کردن خودکار مجموعه**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) رنگی را که بر پایهٔ شاخص مجموعه و سبک نمودار محاسبه می‌شود برمی‌گرداند. این همان رنگی است که هنگام عدم تعریف صریح پر کردن مجموعه استفاده می‌شود. فراخوانی این متد فقط رنگ محاسبه‌شده را می‌خواند؛ پر کردن جدیدی اعمال نمی‌کند.

مثال زیر رنگ خودکار هر مجموعه پیش‌فرض را چاپ می‌کند:

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

## **تنظیم رنگ پر کردن وارون برای یک مجموعه نمودار**

برای مجموعه‌های نوار، ستون و حباب، می‌توانید از [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#setInvertIfNegative) برای نمایش مقادیر منفی با پر کردن متفاوت استفاده کنید. پر کردن معمولی مجموعه را به حالت ثابت (solid) تنظیم کنید، وارونگی را فعال کنید و رنگ مقدار منفی را از طریق [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) تعیین کنید. اعداد منفی در کتاب‌کار بدون تغییر می‌مانند؛ فقط رنگ نمایش آن‌ها تغییر می‌کند.

مثال زیر دادهٔ پیش‌فرض نمودار را با یک مجموعه جایگزین می‌کند. ردیف 0 کاربرگ شامل نام مجموعه، ستون 0 شامل نام دسته‌ها و ستون 1 شامل مقادیر است:

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

![رنگ پر کردن ثابت وارون‌شده](inverted_solid_fill_color.png)

می‌توانید وارونگی را برای یک نقطه از طریق [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) فعال کنید. در مثال زیر، وارونگی برای مجموعه غیرفعال و فقط برای نقطهٔ انتخاب‌شده فعال می‌شود. همچنین به نقطه مقدار منفی اختصاص می‌یابد تا اثر به‌وضوح دیده شود:

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

## **پاک کردن مقدار یک نقطه دادهٔ خاص**

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول کتاب‌کار پشتیبان آن را به `None` تنظیم کنید. برای یک نمودار ستون، مقدار ترسیم‌شده از طریق [ChartDataPoint.getValue](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapoint/#getValue) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را بر اساس تنظیمات خالی بودن مقدار در نمودار به‌عنوان خالی در نظر می‌گیرد.

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

نمودارهای پراکندگی (scatter) از سلول‌های جداگانه X و Y استفاده می‌کنند و نمودارهای حبابی همچنین یک سلول اندازه دارند. فقط سلولی که نمایانگر مقدار مورد نظر برای حذف است را پاک کنید. هنگام تمایل به نگه داشتن نقاط دیگر، از فراخوانی [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapointcollection/#clear) خودداری کنید؛ این متد تمام نقاط مجموعه را حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های مخفی که دارای مقدار هستند موردی متفاوت نسبت به سلول‌های خالی هستند. برای شامل یا حذف داده‌ها از ردیف‌ها و ستون‌های مخفی کاربرگ، به بخش [Include Data from Hidden Rows and Columns](/slides/fa/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns) مراجعه کنید.

یک سلول خالی در کتاب‌کار نشانگر دادهٔ مفقود است؛ سلولی که `0` دارد نشانگر مقدار عددی شناخته‌شده است. برای خالی کردن یک سلول، متد [ChartDataCell.setValue](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatacell/#setValue) را با `None` صدا بزنید. مقدار عددی صفر همچنان صفر باقی می‌ماند، صرف‌نظر از تنظیم خالی بودن سلول.

از [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#setDisplayBlanksAs) استفاده کنید تا تعیین کنید نمودار سلول‌های خالی را چگونه نشان دهد. این تنظیم برای کل نمودار اعمال می‌شود و نحوهٔ رسم خالی‌ها را بدون پر کردن سلول خالی با صفر یا مقدار درونی تغییر می‌دهد.

مثال زیر یک نمودار خطی با یک مجموعه می‌سازد، مقدار روز 3 را خالی می‌کند و همان نمودار را با هر حالت ذخیره می‌کند. نیازی به فایل ورودی نیست. [ChartDataWorkbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdataworkbook/) از کاربرگ 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام مجموعه را نگه می‌دارد. دادهٔ نهایی `10, 20, empty, 30, 40` است.

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

    # روز ۳ را به‌صورت واقعی خالی بگذارید و در عین حال دسته‌بندی و نقطه دادهٔ آن را نگه دارید.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

هر فایل خروجی حالت انتخاب‌شده پیش از ذخیره‌سازی را نشان می‌دهد: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیرهٔ تنها یک نسخه، حالت مطلوب را تنظیم کنید و یک بار ارائه را ذخیره کنید به‌جای تکرار بر روی همه حالت‌ها.

مقایسهٔ زیر همان داده‌ها را در هر سه فایل نشان می‌دهد. روز 3 در کتاب‌کار در هر حالت خالی است:

![نمودارهای خطی با داده‌های یکسان: Gap خط را در روز 3 قطع می‌کند، Zero خط را به صفر می‌کشاند و Span روز 2 را به روز 4 متصل می‌کند.](display_blanks_as.png)

اثر قابل مشاهده به نوع نمودار بستگی دارد. یک نمودار خطی مقایسهٔ سه حالت را آسان می‌کند. نمودارهای نوار و ستون خطوطی برای اتصال بین دستهٔ مفقود ندارند، بنابراین `Span` نمی‌تواند بخشی که در بالا نشان داده شده است ایجاد کند؛ یک ستون مفقود و یک ستون صفر‑ارتفاع نیز ممکن است مشابه به‌نظر برسند. به‌گونهٔ مشابه، یک نمودار پراکندگی فقط با نشانگرها نیازی به خط وصل‌کننده ندارند. انتظار نتایج سه‌گانهٔ متمایز برای هر نوع نمودار نباشید؛ خروجی را برای نوع نموداری که استفاده می‌کنید بررسی کنید.

## **تنظیم فاصلهٔ بین مجموعه‌ها (Gap Width)**

Gap width فاصله بین خوشه‌های نوار یا ستون مجاور است که به‌صورت درصدی از عرض نوار یا ستون بیان می‌شود. مشابه overlap، این ویژگی متعلق به گروه مجموعهٔ والد است نه به یک مجموعه منفرد. برای گروه یک بار متد [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseriesgroup/#setGapWidth) را صدا بزنید. مقدار بزرگ‌تر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچک‌تر آن‌ها را متراکم‌تر می‌کند.

مثال زیر gap width را تغییر می‌دهد و تنها ارائهٔ نهایی را ذخیره می‌کند:

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

![فاصلهٔ بین مجموعه‌ها](gap_width.png)

## **سؤال‌های متداول**

**کدام انواع نمودار از مجموعه داده پشتیبانی می‌کنند؟**

تمام انواع نمودارهای نشان داده‌شده توسط شمارش [ChartType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/charttype/) از داده‌های نمودار استفاده می‌کنند، اما مجموعه‌های آن‌ها همه ساختار یا تنظیمات ارزش یکسانی ندارند. برای مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکندگی از مقادیر X و Y، و نمودارهای حبابی اندازهٔ حباب‌ها را اضافه می‌کنند. از متد ایجاد نقطه داده‌ای استفاده کنید که با نوع مجموعه مطابقت دارد. گزینه‌هایی مانند overlap و gap width فقط برای گروه‌های نوار یا ستون سازگار اعمال می‌شوند.

**یک گروه مجموعه نمودار چیست؟**

یک [ChartSeriesGroup](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseriesgroup/) شامل مجموعه‌های سازگاری است که تنظیمات رسم در سطح گروه را به اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک مجموعه دسترسی پیدا می‌کنید لزوماً تمام مجموعه‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه‌ساخته داده‌های پیش‌فرض دارد؟**

بله. به‌صورت پیش‌فرض، متد [ShapeCollection.addChart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addChart) مجموعه‌ها، دسته‌ها و مقادیر نمونه را ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن مجموعهٔ دادهٔ سفارشی کامل، هر دو مجموعه و دسته‌ها را پاک کنید. یک overload همچنین می‌تواند نمودار بدون دادهٔ پیش‌فرض ایجاد کند.

**اشیای نمودار چگونه به سلول‌های کتاب‌کار متصل هستند؟**

نام‌های مجموعه، برچسب‌های دسته و مقادیر نقطه داده به سلول‌های یک [ChartDataWorkbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده، عنصر مربوط به نمودار را به‌روز می‌کند. هنگام ساخت دادهٔ سفارشی، ردیف‌های دسته و ردیف‌های مقدار مجموعه را هم‌راستا نگه‌دارید تا هر نقطه زیر دستهٔ مورد نظر رسم شود.

**چگونه یک نقطه را به‌جای تمام مجموعه پاک کنم؟**

سلول مقدار مربوطه را به `None` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان نقطهٔ خالی باقی بماند. از [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapointcollection/#clear) فقط زمانی استفاده کنید که قصد حذف تمام نقاط آن مجموعه را دارید. اگر دسته‌ها را نیز حذف می‌کنید، تمام مجموعه‌ها را به‌روزرسانی کنید تا مقادیرشان با مجموعهٔ دسته‌ها هم‌سطح بماند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و مقداری که از طریق [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#setDisplayBlanksAs) پیکربندی شده است بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به عنوان فواصل، مقادیر صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که معنی دادهٔ مفقود را در ارائهٔ شما منعکس کند. برای مثال کامل و مقایسهٔ بصری به بخش [Control the Display of Empty Cells](#control-the-display-of-empty-cells) مراجعه کنید.

**مقدارهای منفی چگونه قالب‌بندی می‌شوند؟**

برای مجموعه‌های نوار، ستون و حباب پشتیبانی‌شده، متد [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#setInvertIfNegative) را صدا بزنید و رنگی که از طریق [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) دریافت می‌کنید را تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ منفرد با [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) بازنویسی کنید. این متدها بر قالب‌بندی تأثیر می‌گذارند، نه مقدارهای عددی ذخیره‌شده.

**زمانی که هم مجموعه و هم نقطه قالب‌بندی شده باشند، کدام یک برنده است؟**

قالب‌بندی صریح نقطه داده برای همان نقطه اولویت دارد. نقاط دیگر همچنان از قالب‌ بندی صریح مجموعه استفاده می‌کنند یا، اگر قالب‌ بندی مجموعه تعریف نشده باشد، از سبک و تم خودکار نمودار. تنظیمات گروه مانند overlap و gap width برچسب‌های مربوط به چیدمان هستند و بازنویسی‌های سطح نقطه نیستند.

**آیا محدودیتی برای تعداد مجموعه‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانه‌ای برای تعداد مجموعه‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظهٔ در دسترس، زمان رندر و قابلیت خواندن نمودار تعیین‌کنندهٔ حد قابل استفاده هستند.

**چگونه می‌توانم زمانی که ستون‌ها بیش از حد نزدیک یا دور هستند تنظیم کنم؟**

متد [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseriesgroup/#setGapWidth) را برای گروه مجموعهٔ والد مناسب صدا بزنید. مقدار را افزایش دهید تا فضای بین خوشه‌ها گسترده‌تر شود یا کاهش دهید تا خوشه‌ها به‌یکدیگر نزدیک‌تر شوند.