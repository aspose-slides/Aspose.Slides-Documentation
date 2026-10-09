---
title: ایجاد یا به‌روزرسانی نمودارهای ارائه PowerPoint در پایتون
linktitle: ایجاد یا به‌روزرسانی نمودارها
type: docs
weight: 10
url: /fa/python-java/create-chart/
keywords:
- افزودن نمودار
- ایجاد نمودار
- ویرایش نمودار
- تغییر نمودار
- به‌روزرسانی نمودار
- نمودار پراکنده
- نمودار دایره‌ای
- نمودار خطی
- نمودار درخت‌نقشه
- نمودار سهام
- نمودار جعبه‌ای و ویسکر
- نمودار قیفی
- نمودار خورشیدگرد
- نمودار هیستوگرام
- نمودار رادار
- نمودار چنددسته‌ای
- PowerPoint
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی نمودارها در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای پایتون از طریق جاوا. افزودن، قالب‌بندی و ویرایش نمودارها با مثال‌های کد عملی در پایتون."
---
## **نمای کلی**

این مقاله راهنمای جامعی برای ایجاد و سفارشی‌سازی نمودارها با Aspose.Slides ارائه می‌دهد. شما یاد می‌گیرید چگونه به‌صورت برنامه‌نویسی یک نمودار به اسلاید اضافه کنید، آن را با داده‌ها پر کنید و گزینه‌های قالب‌بندی مختلفی را اعمال کنید تا با نیازهای طراحی خاص شما سازگار شود. در طول مقاله، مثال‌های کد مفصل هر گام را نشان می‌دهند، از مقداردهی اولیهٔ ارائه و شی نمودار تا پیکربندی سری‌ها، محور‌ها و افسانه‌ها. با پیروی از این راهنما، درک محکمی از یکپارچه‌سازی تولید دینامیک نمودار در برنامه‌های خود به دست می‌آورید و فرآیند ایجاد ارائه‌های مبتنی بر داده را ساده می‌کنید.

## **ایجاد یک نمودار**

نمودارها به افراد کمک می‌کند تا داده‌ها را به‌سرعت تجسم کنند و بینش‌هایی پیدا کنند که ممکن است از جدول یا صفحه‌گسترده به‌راحتی مشهود نباشند.

**چرا نمودار ایجاد کنیم؟**

با استفاده از نمودارها می‌توانید:

* حجم زیاد داده‌ها را در یک اسلاید جمع‌آوری، فشرده یا خلاصه کنید
* الگوها و روندهای داده را آشکار کنید
* جهت و سرعت داده را در طول زمان یا نسبت به یک واحد اندازه‌گیری خاص استنتاج کنید
* نقطه‌های دور از معمول، انحرافات، خطاها، داده‌های بی‌معنی و غیره را شناسایی کنید
* داده‌های پیچیده را ارتباط یا ارائه دهید

در PowerPoint می‌توانید از عملکرد *Insert* برای ایجاد نمودارها استفاده کنید که قالب‌های متنوعی برای طراحی انواع نمودارها فراهم می‌آورد. با Aspose.Slides می‌توانید هم نمودارهای معمولی (بر پایهٔ انواع محبوب نمودار) و هم نمودارهای سفارشی ایجاد کنید.

{{% alert color="info" title="Note" %}}
برای ایجاد نمودارها، از کلاس [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) استفاده کنید. فیلدهای این کلاس متناظر با انواع مختلف نمودار هستند.
{{% /alert %}}

### **ایجاد نمودار ستونی خوشه‌ای**

این بخش توضیح می‌دهد چگونه با Aspose.Slides نمودارهای ستونی خوشه‌ای ایجاد کنید. شما یاد می‌گیرید یک ارائه را مقداردهی اولیه کنید، یک نمودار اضافه کنید و عناصر آن مانند عنوان، داده‌ها، سری‌ها، دسته‌ها و سبک را سفارشی کنید. مراحل زیر را دنبال کنید تا ببینید یک نمودار ستونی خوشه‌ای استاندارد چگونه تولید می‌شود:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation) ایجاد کنید.
1. با استفاده از ایندکس، به یک اسلاید ارجاع پیدا کنید.
1. یک نمودار با برخی داده‌ها اضافه کنید و نوع `ChartType.ClusteredColumn` را مشخص کنید.
1. یک عنوان به نمودار اضافه کنید.
1. به کاربرگ داده‌های نمودار دسترسی پیدا کنید.
1. تمام سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
1. سری‌ها و دسته‌های جدید اضافه کنید.
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.
1. رنگ پر را به سری‌های نمودار اعمال کنید.
1. برچسب‌ها را به سری‌های نمودار اضافه کنید.
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار ستونی خوشه‌ای ایجاد شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# یک شیء ارائه ایجاد می‌کند که نمایانگر یک فایل PPTX است.
presentation = Presentation()
try:
    # به اولین اسلاید دسترسی می‌یابد
    slide = presentation.getSlides().get_Item(0)

    # یک نمودار با داده‌های پیش‌فرض آن اضافه می‌کند
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500)

    # عنوان نمودار را تنظیم می‌کند
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # اندیس شیت داده‌های نمودار را تنظیم می‌کند
    default_worksheet_index = 0

    # کاربرگ داده‌های نمودار را دریافت می‌کند
    workbook = chart.getChartData().getChartDataWorkbook()

    # سری‌ها و دسته‌های پیش‌فرض تولید شده را حذف می‌کند
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # سری‌های جدید را اضافه می‌کند
    cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell,chart.getType())
    cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell,chart.getType())

    # دسته‌های جدید را اضافه می‌کند
    cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)

    # سری اول نمودار را می‌گیرد
    series = chart.getChartData().getSeries().get_Item(0)

    # اکنون داده‌های سری را پر می‌کند
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # رنگ پر را برای سری تنظیم می‌کند
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    # سری دوم نمودار را می‌گیرد
    series = chart.getChartData().getSeries().get_Item(1)

    # داده‌های سری را پر می‌کند
    cell = workbook.getCell(default_worksheet_index, 1, 2, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 2, 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 2, 60)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # رنگ پر را برای سری تنظیم می‌کند
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN)

    #Create برچسب‌های سفارشی برای هر دسته برای سری جدید
    # برچسب اول را برای نمایش نام دسته تنظیم می‌کند
    label = series.getDataPoints().get_Item(0).getLabel()
    label.getDataLabelFormat().setShowCategoryName(True)

    label = series.getDataPoints().get_Item(1).getLabel()
    label.getDataLabelFormat().setShowSeriesName(True)

    # مقدار را برای برچسب سوم نمایش می‌دهد
    label = series.getDataPoints().get_Item(2).getLabel()
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setShowSeriesName(True)
    label.getDataLabelFormat().setSeparator("/")

    # ارائه را با نمودار ذخیره می‌کند
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ایجاد نمودارهای پراکنده**

نمودارهای پراکنده (که به‌عنوان گراف‌های نقطه‌ای یا نمودارهای x‑y نیز شناخته می‌شوند) اغلب برای بررسی الگوها یا نشان دادن همبستگی بین دو متغیر استفاده می‌شوند.

از نمودار پراکنده زمانی استفاده کنید که:

* داده‌های عددی جفت‌وار دارید
* دو متغیری که به‑خوبی با هم جفت می‌شوند دارید
* می‌خواهید تعیین کنید آیا دو متغیر مرتبط هستند یا خیر
* متغیر مستقلی دارید که برای یک متغیر وابسته چند مقدار دارد

1. مراحل موجود در [Create Clustered Column Charts](#create-clustered-column-charts) را دنبال کنید.
2. برای گام سوم، یک نمودار با برخی داده‌ها اضافه کنید و نوع نمودار خود را یکی از موارد زیر تعیین کنید:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithMarkers) - _نمایانگر یک نمودار پراکنده است._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _نمایانگر یک نمودار پراکنده متصل با منحنی‌ها و نشانگرهای داده است._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _نمایانگر یک نمودار پراکنده متصل با منحنی‌ها بدون نشانگرهای داده است._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _نمایانگر یک نمودار پراکنده متصل با خطوط مستقیم و نشانگرهای داده است._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithStraightLines) - _نمایانگر یک نمودار پراکنده متصل با خطوط مستقیم بدون نشانگرهای داده است._

این کد Python نشان می‌دهد چگونه یک نمودار پراکنده با نشانگرهای مختلف برای هر سری ایجاد شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, MarkerStyleType, Presentation, SaveFormat

# یک شیء ارائه ایجاد می‌کند که نمایانگر یک فایل PPTX است.
presentation = Presentation()
try:
    # به اولین اسلاید دسترسی می‌یابد
    slide = presentation.getSlides().get_Item(0)

    # نمودار پیش‌فرض را ایجاد می‌کند
    chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400)

    # اندیس شیت داده‌های پیش‌فرض نمودار را دریافت می‌کند
    default_worksheet_index = 0

    # شیت داده‌های نمودار را دریافت می‌کند
    workbook = chart.getChartData().getChartDataWorkbook()

    # سری‌های نمونه را حذف می‌کند
    chart.getChartData().getSeries().clear()

    # سری‌های جدید را اضافه می‌کند
    cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(default_worksheet_index, 1, 3, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # اولین سری نمودار را می‌گیرد
    series = chart.getChartData().getSeries().get_Item(0)

    # نقطه جدید (1:3) را به سری اضافه می‌کند
    x_cell = workbook.getCell(default_worksheet_index, 2, 1, 1)
    y_cell = workbook.getCell(default_worksheet_index, 2, 2, 3)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # نقطه جدید (2:10) را اضافه می‌کند
    x_cell = workbook.getCell(default_worksheet_index, 3, 1, 2)
    y_cell = workbook.getCell(default_worksheet_index, 3, 2, 10)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # نوع سری را تغییر می‌دهد
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers)

    # نشانگر سری نمودار را تغییر می‌دهد
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Star)

    # دومین سری نمودار را می‌گیرد
    series = chart.getChartData().getSeries().get_Item(1)

    # نقطه جدید (5:2) را آنجا اضافه می‌کند
    x_cell = workbook.getCell(default_worksheet_index, 2, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 2, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # نقطه جدید (3:1) را اضافه می‌کند
    x_cell = workbook.getCell(default_worksheet_index, 3, 3, 3)
    y_cell = workbook.getCell(default_worksheet_index, 3, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # نقطه جدید (2:2) را اضافه می‌کند
    x_cell = workbook.getCell(default_worksheet_index, 4, 3, 2)
    y_cell = workbook.getCell(default_worksheet_index, 4, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # نقطه جدید (5:1) را اضافه می‌کند
    x_cell = workbook.getCell(default_worksheet_index, 5, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 5, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # نشانگر سری نمودار را تغییر می‌دهد
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Circle)

    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ایجاد نمودارهای دایره‌ای**

نمودارهای دایره‌ای برای نمایش رابطهٔ بخش به کل در داده‌ها مناسب هستند، به‌ویژه زمانی که داده‌ها شامل برچسب‌های دسته‌ای با مقادیر عددی باشد. اما اگر داده‌های شما شامل بخش‌ها یا برچسب‌های زیادی باشد، ممکن است بهتر باشد به‌جای آن از نمودار میله‌ای استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس، به یک اسلاید ارجاع پیدا کنید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.Pie](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Pie) را مشخص کنید.
4. به کتاب‌کار داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.
8. نقاط جدید برای نمودار اضافه کنید و رنگ‌های سفارشی برای بخش‌های نمودار دایره‌ای اعمال کنید.
9. برچسب‌ها را برای سری‌ها تنظیم کنید.
10. خطوط راهنما برای برچسب‌های سری فعال کنید.
11. زاویهٔ چرخش برای بخش‌های نمودار دایره‌ای تنظیم کنید.
12. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد Python نشان می‌دهد چگونه یک نمودار دایره‌ای ایجاد شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# یک شیء ارائه ایجاد می‌کند که نمایانگر یک فایل PPTX است.
presentation = Presentation()
try:
    # به اولین اسلاید دسترسی می‌یابد
    slide = presentation.getSlides().get_Item(0)

    # یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # عنوان نمودار را تنظیم می‌کند
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # اندیس شیت داده‌های نمودار را تنظیم می‌کند
    default_worksheet_index = 0

    # کاربرگ داده‌های نمودار را دریافت می‌کند
    workbook = chart.getChartData().getChartDataWorkbook()

    # سری‌ها و دسته‌های پیش‌فرض تولید شده را حذف می‌کند
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # دسته‌های جدید را اضافه می‌کند
    cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(cell)

    # سری‌های جدید را اضافه می‌کند
    cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(cell, chart.getType())

    #پر کردن داده‌های سری
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForPieSeries(cell)

    # اضافه کردن نقاط جدید و تنظیم رنگ بخش
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(True)

    point = series.getDataPoints().get_Item(0)
    point.getFormat().getFill().setFillType(FillType.Solid)
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN)

    # حاشیهٔ بخش را تنظیم می‌کند
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    point.getFormat().getLine().setWidth(3.0)
    point.getFormat().getLine().setStyle(LineStyle.ThinThick)
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    second_point = series.getDataPoints().get_Item(1)
    second_point.getFormat().getFill().setFillType(FillType.Solid)
    second_point.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    # حاشیهٔ بخش را تنظیم می‌کند
    second_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    second_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    second_point.getFormat().getLine().setWidth(3.0)
    second_point.getFormat().getLine().setStyle(LineStyle.Single)
    second_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot)

    third_point = series.getDataPoints().get_Item(2)
    third_point.getFormat().getFill().setFillType(FillType.Solid)
    third_point.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW)

    # حاشیهٔ بخش را تنظیم می‌کند
    third_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    third_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    third_point.getFormat().getLine().setWidth(2.0)
    third_point.getFormat().getLine().setStyle(LineStyle.ThinThin)
    third_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot)

    # برچسب‌های سفارشی برای هر دسته از سری جدید ایجاد می‌کند
    first_label = series.getDataPoints().get_Item(0).getLabel()

    first_label.getDataLabelFormat().setShowValue(True)

    second_label = series.getDataPoints().get_Item(1).getLabel()
    second_label.getDataLabelFormat().setShowValue(True)
    second_label.getDataLabelFormat().setShowLegendKey(True)
    second_label.getDataLabelFormat().setShowPercentage(True)

    third_label = series.getDataPoints().get_Item(2).getLabel()
    third_label.getDataLabelFormat().setShowSeriesName(True)
    third_label.getDataLabelFormat().setShowPercentage(True)

    # خطوط راهنما برای نمودار را نمایش می‌دهد
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(True)

    # زاویهٔ چرخش برای بخش‌های نمودار دایره‌ای را تنظیم می‌کند
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180)

    # ارائه را همراه با نمودار ذخیره می‌کند
    presentation.save("PieChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ایجاد نمودارهای خطی**

نمودارهای خطی (که به‌عنوان گراف‌های خطی نیز شناخته می‌شوند) در مواقعی که می‌خواهید تغییرات مقدار در طول زمان را نشان دهید، بهترین گزینه هستند. با استفاده از یک نمودار خطی می‌توانید مقادیر زیادی داده را به‌صورت همزمان مقایسه کنید، تغییرات و روندها را در طول زمان ردیابی کنید، ناهنجاری‌ها را در سری داده‌ها برجسته کنید و موارد دیگر.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از ایندکس، به یک اسلاید ارجاع پیدا کنید.
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.Line](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Line) را مشخص کنید.
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد Python نشان می‌دهد چگونه یک نمودار خطی ایجاد شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

به‌طور پیش‌فرض، نقاط یک نمودار خطی با خطوط مستقیم پیوسته به هم وصل می‌شوند. اگر می‌خواهید نقطه‌ها به‌جای خطوط پیوسته با خط‌چین وصل شوند، می‌توانید نوع خط‌چین دلخواه خود را به‌صورت زیر تعیین کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LineDashStyle, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    for series in line_chart.getChartData().getSeries():
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ایجاد نمودارهای درخت‌نقشه**

نمودارهای درخت‌نقشه برای داده‌های فروش که می‌خواهید اندازه نسبی دسته‌های داده را نشان دهید و به‌سرعت توجه را به آیتم‌های بزرگ‌سهم در هر دسته جلب کنید، بهترین گزینه هستند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس، به یک اسلاید ارجاع پیدا کنید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.Treemap](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Treemap) را مشخص کنید.
4. به کتاب‌کار داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.
8. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد Python نشان می‌دهد چگونه یک نمودار درخت‌نقشه ایجاد شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ParentLabelLayoutType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #شاخه 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #شاخه 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Treemap)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("Treemap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ایجاد نمودارهای سهام**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس، به یک اسلاید ارجاع پیدا کنید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#OpenHighLowClose) را تعیین کنید.
4. به کتاب‌کار داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.
8. فرمت خطوط بالا‑پایین را مشخص کنید.
9. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد Python نشان می‌دهد چگونه یک نمودار سهام ایجاد شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    cell = workbook.getCell(0, 1, 0, "A")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "B")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "C")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, 0, 1, "Open")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 2, "High")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 3, "Low")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 4, "Close")
    chart.getChartData().getSeries().add(cell, chart.getType())

    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 1, 72)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 1, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 1, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(1)
    cell = workbook.getCell(0, 1, 2, 172)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(2)
    cell = workbook.getCell(0, 1, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 3, 13)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(3)
    cell = workbook.getCell(0, 1, 4, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 4, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 4, 50)
    series.getDataPoints().addDataPointForStockSeries(cell)

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(True)
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)

    for series in chart.getChartData().getSeries():
        series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ایجاد نمودارهای جعبه‌ای و ویسکر**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس، به یک اسلاید ارجاع پیدا کنید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#BoxAndWhisker) را تعیین کنید.
4. به کتاب‌کار داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.
8. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد Python نشان می‌دهد چگونه یک نمودار جعبه‌ای و ویسکر ایجاد شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, QuartileMethodType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 1")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker)

    series.setQuartileMethod(QuartileMethodType.Exclusive)
    series.setShowMeanLine(True)
    series.setShowMeanMarkers(True)
    series.setShowInnerPoints(True)
    series.setShowOutlierPoints(True)

    cell = workbook.getCell(0, "B1", 15)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B2", 41)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B3", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B4", 10)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B5", 23)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B6", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ایجاد نمودارهای قیفی**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس، به یک اسلاید ارجاع پیدا کنید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.Funnel](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Funnel) را تعیین کنید.
4. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد Python نشان می‌دهد چگونه یک نمودار قیفی ایجاد شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Funnel)

    cell = workbook.getCell(0, "B1", 50)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B2", 100)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B3", 200)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B4", 300)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B5", 400)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B6", 500)
    series.getDataPoints().addDataPointForFunnelSeries(cell)

    presentation.save("Funnel.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ایجاد نمودارهای خورشیدگرد**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس، به یک اسلاید ارجاع پیدا کنید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.Sunburst](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Sunburst) را تعیین کنید.
4. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد Python نشان می‌دهد چگونه یک نمودار خورشیدگرد ایجاد شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #شاخه 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #شاخه 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Sunburst)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)

    presentation.save("Sunburst.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ایجاد نمودارهای هیستوگرام**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس، به یک اسلاید ارجاع پیدا کنید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.Histogram](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Histogram) را تعیین کنید.
4. به کتاب‌کار داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد Python نشان می‌دهد چگونه یک نمودار هیستوگرام ایجاد شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    cell = workbook.getCell(0, "A1", 15)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A2", -41)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A3", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A4", 10)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A5", -23)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A6", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic)

    presentation.save("Histogram.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ایجاد نمودارهای رادار**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس، به یک اسلاید ارجاع پیدا کنید.
3. یک نمودار با برخی داده‌ها اضافه کنید و نوع موردنظر خود را (در این مثال [ChartType.Radar](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Radar)) تعیین کنید.
4. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد Python نشان می‌دهد چگونه یک نمودار رادار ایجاد شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300)
    presentation.save("Radar-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ایجاد نمودارهای چنددسته‌ای**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس، به یک اسلاید ارجاع پیدا کنید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType.ClusteredColumn](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ClusteredColumn) را تعیین کنید.
4. به کتاب‌کار داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.
8. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد Python نشان می‌دهد چگونه یک نمودار چنددسته‌ای ایجاد شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450)
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)
    default_worksheet_index = 0

    cell = workbook.getCell(0, "c2", "A")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group1")
    cell = workbook.getCell(0, "c3", "B")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c4", "C")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group2")
    cell = workbook.getCell(0, "c5", "D")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c6", "E")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group3")
    cell = workbook.getCell(0, "c7", "F")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c8", "G")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group4")
    cell = workbook.getCell(0, "c9", "H")
    category = chart.getChartData().getCategories().add(cell)

    # افزودن سری‌ها
    cell = workbook.getCell(0, "D1", "Series 1")
    series = chart.getChartData().getSeries().add(cell, ChartType.ClusteredColumn)

    cell = workbook.getCell(default_worksheet_index, "D2", 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D3", 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D4", 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D5", 40)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D6", 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D7", 60)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D8", 70)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D9", 80)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # ذخیره ارائه با نمودار
    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ایجاد نمودارهای نقشه‌ای**

نمودارهای نقشه‌ای داده‌های جغرافیایی را تجسم می‌کنند و به مقایسه مقادیر در مناطق مختلف کمک می‌نمایند.

این کد Python نشان می‌دهد چگونه یک نمودار نقشه‌ای ایجاد شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400)
    presentation.save("mapChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ایجاد نمودارهای ترکیبی**

یک نمودار ترکیبی (یا combo chart) دو یا چند نوع نمودار را در یک گراف ترکیب می‌کند. این نمودار به شما امکان می‌دهد تا تفاوت‌ها یا شباهت‌های بین دو یا چند مجموعه داده را برجسته، مقایسه یا بررسی کنید و روابط بین آن‌ها را شناسایی نمایید.

![The combination chart](combination_chart.png)

کد Python زیر نشان می‌دهد چگونه نمودار ترکیبی نمایش داده‌شده در بالا را در یک ارائه PowerPoint ایجاد کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisPositionType, ChartType, CrossesType, FillType, LegendPositionType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

def create_combo_chart():
    presentation = Presentation()
    slide = presentation.getSlides().get_Item(0)
    try:
        chart = create_chart_with_first_series(slide)

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()

def create_chart_with_first_series(slide):
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    # تنظیم عنوان نمودار.
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Chart Title")
    chart.getChartTitle().setOverlay(False)
    title_paragraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(18.0)

    # تنظیم افسانه نمودار.
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12.0)

    # حذف سری‌ها و دسته‌های پیش‌فرض تولید شده.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # اضافه کردن دسته‌های جدید.
    cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 4, 0, "Category 4")
    chart.getChartData().getCategories().add(cell)

    # اضافه کردن سری اول.
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 1, 4.3)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 1, 2.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 1, 3.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 1, 4.5)
    series.getDataPoints().addDataPointForBarSeries(cell)

    return chart

def add_second_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 2, "Series 2")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.ClusteredColumn)

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 2, 2.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 2, 4.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 2, 1.8)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 2, 2.8)
    series.getDataPoints().addDataPointForBarSeries(cell)

def add_third_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Series 3")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.Line)

    cell = workbook.getCell(worksheet_index, 1, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 3, 3.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 3, 5.0)
    series.getDataPoints().addDataPointForLineSeries(cell)

    series.setPlotOnSecondAxis(True)

def set_primary_axes_format(chart):
    # تنظیم محور افقی.
    horizontal_axis = chart.getAxes().getHorizontalAxis()
    horizontal_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    horizontal_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(horizontal_axis, "X Axis")

    # تنظیم محور عمودی.
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(vertical_axis, "Y Axis 1")

    # تنظیم رنگ خطوط شبکه اصلی عمودی.
    major_grid_lines_format = vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat()
    major_grid_lines_format.setFillType(FillType.Solid)
    color = Color(217, 217, 217)
    major_grid_lines_format.getSolidFillColor().setColor(color)

def set_secondary_axes_format(chart):
    # تنظیم محور افقی ثانویه.
    secondary_horizontal_axis = chart.getAxes().getSecondaryHorizontalAxis()
    secondary_horizontal_axis.setPosition(AxisPositionType.Bottom)
    secondary_horizontal_axis.setCrossType(CrossesType.Maximum)
    secondary_horizontal_axis.setVisible(False)
    secondary_horizontal_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_horizontal_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # تنظیم محور عمودی ثانویه.
    secondary_vertical_axis = chart.getAxes().getSecondaryVerticalAxis()
    secondary_vertical_axis.setPosition(AxisPositionType.Right)
    secondary_vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    secondary_vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(secondary_vertical_axis, "Y Axis 2")

def set_axis_title(axis, axis_title):
    axis.setTitle(True)
    axis.getTitle().setOverlay(False)
    title_paragraph = axis.getTitle().addTextFrameForOverriding(axis_title).getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(12.0)

create_combo_chart()
```

## **به‌روزرسانی نمودارها**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید که نمای ارائهٔ شامل نموداری که می‌خواهید به‌روزرسانی کنید را نشان می‌دهد.
2. با استفاده از ایندکس، به یک اسلاید ارجاع پیدا کنید.
3. تمام اشکال را برای یافتن نمودار موردنظر مرور کنید.
4. به کاربرگ داده‌های نمودار دسترسی پیدا کنید.
5. سری‌های دادهٔ نمودار را با تغییر مقادیر سری‌ها اصلاح کنید.
6. یک سری جدید اضافه کنید و داده‌های آن را پر کنید.
7. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد Python نشان می‌دهد چگونه یک نمودار به‌روزرسانی شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# ارائه‌ای که حاوی نمودار برای به‌روزرسانی است را باز می‌کند
presentation = Presentation("ExistingChart.pptx")
try:
    # دسترسی به اسلاید اول
    slide = presentation.getSlides().get_Item(0)

    # دریافت نمودار از اسلاید
    chart = slide.getShapes().get_Item(0)

    # تنظیم اندیس شیت داده‌های نمودار
    default_worksheet_index = 0

    # دریافت کاربرگ داده‌های نمودار
    workbook = chart.getChartData().getChartDataWorkbook()

    # تغییر نام دسته نمودار
    workbook.getCell(default_worksheet_index, 1, 0, "Modified Category 1")
    workbook.getCell(default_worksheet_index, 2, 0, "Modified Category 2")

    # دریافت اولین سری نمودار
    series = chart.getChartData().getSeries().get_Item(0)

    # اکنون در حال به‌روزرسانی داده‌های سری است
    workbook.getCell(default_worksheet_index, 0, 1, "New_Series1")# تغییر نام سری
    series.getDataPoints().get_Item(0).getValue().setData(90)
    series.getDataPoints().get_Item(1).getValue().setData(123)
    series.getDataPoints().get_Item(2).getValue().setData(44)

    # دریافت دومین سری نمودار
    series = chart.getChartData().getSeries().get_Item(1)

    # اکنون در حال به‌روزرسانی داده‌های سری است
    workbook.getCell(default_worksheet_index, 0, 2, "New_Series2")# تغییر نام سری
    series.getDataPoints().get_Item(0).getValue().setData(23)
    series.getDataPoints().get_Item(1).getValue().setData(67)
    series.getDataPoints().get_Item(2).getValue().setData(99)

    # اکنون، افزودن یک سری جدید
    cell = workbook.getCell(default_worksheet_index, 0, 3, "Series 3")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # دریافت سومین سری نمودار
    series = chart.getChartData().getSeries().get_Item(2)

    # اکنون در حال پر کردن داده‌های سری است
    cell = workbook.getCell(default_worksheet_index, 1, 3, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 3, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 3, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    chart.setType(ChartType.ClusteredCylinder)

    # ذخیره ارائه با نمودار
    presentation.save("AsposeChartModified_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم محدودهٔ داده برای یک نمودار**

برای بررسی محدوده‌ای که هم‌اکنون توسط یک نمودار موجود استفاده می‌شود، به مقالهٔ [Retrieve a Chart's Data Range](/slides/fa/python-java/chart-workbook/#retrieve-a-charts-data-range) مراجعه کنید.

برای تنظیم محدودهٔ داده برای یک نمودار، این مراحل را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید که نمای ارائهٔ شامل نمودار را نشان می‌دهد.
2. با استفاده از ایندکس، به یک اسلاید ارجاع پیدا کنید.
3. تمام اشکال را برای یافتن نمودار موردنظر مرور کنید.
4. به داده‌های نمودار دسترسی پیدا کنید و محدوده را تنظیم کنید.
5. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد Python نشان می‌دهد چگونه محدودهٔ داده برای یک نمودار تنظیم شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# ارائه‌ای که حاوی نمودار است را باز می‌کند
presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)

    chart.getChartData().setRange("Sheet1!A1:B4")

    presentation.save("SetDataRange_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **استفاده از نشانگرهای پیش‌فرض در نمودارها**

هنگامی که از نشانگرهای پیش‌فرض در نمودارها استفاده می‌کنید، هر سری نمودار به‌صورت خودکار یک نماد نشانگر متفاوت دریافت می‌کند.

این کد Python نشان می‌دهد چگونه نشانگر سری نمودار به‌صورت خودکار تنظیم شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 0, "C1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 1, 1, 24)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 0, "C2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 1, 23)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 0, "C3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 1, -10)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 0, "C4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 4, 1, None)
    series.getDataPoints().addDataPointForLineSeries(cell)

    cell = workbook.getCell(0, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())
    #دریافت دومین سری نمودار
    second_series = chart.getChartData().getSeries().get_Item(1)

    #در حال پر کردن داده‌های سری
    cell = workbook.getCell(0, 1, 2, 30)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 2, 10)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 2, 60)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 2, 40)
    second_series.getDataPoints().addDataPointForLineSeries(cell)

    chart.setLegend(True)
    chart.getLegend().setOverlay(False)

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **پرسش‌های متداول**

**کدام انواع نمودارها توسط Aspose.Slides پشتیبانی می‌شوند؟**

Aspose.Slides طیف وسیعی از [chart types](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) را پشتیبانی می‌کند، از جمله میله‌ای، خطی، دایره‌ای، ناحیه‌ای، پراکنده، هیستوگرام، رادار و بسیاری دیگر. این انعطاف‌پذیری به شما اجازه می‌دهد تا مناسب‌ترین نوع نمودار را برای نیازهای تجسم داده‌تان انتخاب کنید.

**چگونه یک نمودار جدید به اسلاید اضافه کنم؟**

برای افزودن یک نمودار، ابتدا یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد می‌کنید، اسلاید موردنظر را با ایندکس دریافت می‌کنید و سپس متد افزودن نمودار را صدا می‌زنید، نوع نمودار و داده‌های اولیه را مشخص می‌کنید. این فرآیند نمودار را مستقیماً در ارائهٔ شما ادغام می‌کند.

**چگونه می‌توانم داده‌های نمایش داده‌شده در یک نمودار را به‌روزرسانی کنم؟**

می‌توانید داده‌های یک نمودار را با دسترسی به کتاب‌کار دادهٔ آن ([ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/))، حذف سری‌ها و دسته‌های پیش‌فرض و سپس افزودن داده‌های سفارشی خود، به‌روزرسانی کنید. این کار به شما امکان می‌دهد نمودار را برای بازتاب جدیدترین داده‌ها تازه‌سازی کنید.

**آیا امکان سفارشی‌سازی ظاهر نمودار وجود دارد؟**

بله، Aspose.Slides گزینه‌های سفارشی‌سازی گسترده‌ای ارائه می‌دهد. می‌توانید رنگ‌ها، قلم‌ها، برچسب‌ها، افسانه‌ها و سایر [formatting elements](/slides/fa/python-java/chart-entities/) را تغییر دهید تا ظاهر نمودار را مطابق با نیازهای طراحی خاص خود تنظیم کنید.