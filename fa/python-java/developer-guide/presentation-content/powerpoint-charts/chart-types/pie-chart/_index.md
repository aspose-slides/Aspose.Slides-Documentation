---
title: سفارشی‌سازی نمودارهای دایره‌ای در ارائه‌ها با استفاده از پایتون از طریق جاوا
linktitle: نمودار دایره‌ای
type: docs
url: /fa/python-java/pie-chart/
keywords:
- نمودار دایره‌ای
- مدیریت نمودار
- سفارشی‌سازی نمودار
- گزینه‌های نمودار
- تنظیمات نمودار
- گزینه‌های طرح
- رنگ برش
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی نمودارهای دایره‌ای در پایتون از طریق جاوا با Aspose.Slides. پیکربندی نمودارهای ثانویه، نمایش برچسب‌های داده و اعمال رنگ‌های خودکار برش در PowerPoint."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه با نمودارهای دایره‌ای در Aspose.Slides کار کنید. این مقاله نشان می‌دهد چگونه گزینه‌های نمودار ثانویه را برای نمودارهای Pie of Pie و Bar of Pie پیکربندی کنید و چگونه رنگ‌آمیزی خودکار برش‌ها را برای یک نمودار دایره‌ای استاندارد فعال کنید.

مثال‌ها بر روی وظایف سفارشی‌سازی نمودار متمرکز هستند، از جمله افزودن یک نمودار به اسلاید، تنظیم سری‌ها و تنظیمات برچسب، جایگزین کردن داده‌های پیش‌فرض نمودار با دسته‌ها و مقادیر سفارشی، و ذخیره‌سازی ارائه به‌روز شده.

## **گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie و Bar of Pie**

Aspose.Slides برای Python از طریق Java از گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie و Bar of Pie پشتیبانی می‌کند. این گزینه‌ها اندازه‌ی نمودار ثانویه و نحوه تقسیم نقاط داده بین دو نمودار را کنترل می‌کنند.

مثال زیر یک نمودار Pie of Pie را در یک ارائه جدید ایجاد می‌کند و مقادیر نقاط داده را به‌عنوان برچسب‌ها نمایش می‌دهد. متد [setSecondPieSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSecondPieSize) اندازه‌ی نمودار ثانویه را به 149٪ از نمودار اصلی تنظیم می‌کند. متد [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) تقسیم بر اساس درصد را انتخاب می‌کند، و متد [setPieSplitPosition](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) آستانه را روی 53٪ تعیین می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)
    series = chart.getChartData().getSeries().get_Item(0)

    # مقادیر را نمایش داده و نمودار ثانویه را پیکربندی کنید.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **انتخاب دسته‌ها برای نمودار ثانویه**

از تقسیم سفارشی استفاده کنید وقتی می‌خواهید دسته‌های خاصی را در نمودار ثانویه گروه‌بندی کنید بدون در نظر گرفتن مقادیر درصدی آن‌ها. برای مثال، یک گزارش فروش ممکن است Online و Events را با هم نشان داده تا خوانندگان بتوانند این دو کانال را مقایسه کنند، حتی اگر این دو به ترتیب 35٪ و 10٪ از کل فروش را تشکیل دهند.

متد [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) را همراه با [PieSplitType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/piesplittype/#Custom) فراخوانی کنید و نقاط را از طریق [getPieSplitCustomPoints](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) انتخاب کنید. متد [add](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#add) از مجموعه یک اندیس صفر‌پایه در سری می‌پذیرد؛ برای افزودن یک شیء نقطه داده از [addItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#addItem) استفاده کنید. در این مثال، اندیس 1 Online را انتخاب می‌کند و نقطه‌ی اندیس 3 Events را انتخاب می‌کند. Partners نیز به‌صورت موقت افزوده می‌شود، سپس با استفاده از [removeItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#removeItem) حذف می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200)

    # داده‌های پیش‌فرض را با فروش بر حسب کانال جایگزین کنید.
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(0, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setPieSplitBy(PieSplitType.Custom)
    series_group.setColorVaried(True)

    # Online را با اندیس صفر‑پایه‌اش و Events را با شیء نقطه‌داده‌ای آن انتخاب کنید.
    series_group.getPieSplitCustomPoints().add(1)
    series_group.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3))

    # Partners را از انتخاب حذف کنید بدون حذف داده منبع آن.
    series_group.getPieSplitCustomPoints().add(2)
    series_group.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2))

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Online (35) و Events (10) به‌عنوان برش‌های جداگانه در نمودار ثانویه ظاهر می‌شوند. در نمودار اصلی، آن‌ها توسط یک برش ترکیبی با مقدار 45، همراه با Retail (40) و Partners (15) نمایش داده می‌شوند. حذف Partners از انتخاب سفارشی آن را در نمودار اصلی نگه می‌دارد؛ این عمل دسته یا مقدار آن را از داده‌های منبع نمودار حذف نمی‌کند.

تصویر زیر ارائه ذخیره‌شده را در PowerPoint نشان می‌دهد:
![نمودار Pie of Pie با Online و Events در نمودار ثانویه و مقدار ترکیبی آن‌ها برابر 45 در نمودار اصلی](pie_of_pie_custom.png)

## **تنظیم رنگ خودکار برش‌های نمودار دایره‌ای**

Aspose.Slides برای Python از طریق Java می‌تواند به‌صورت خودکار رنگ‌های متفاوتی را به برش‌های نمودار دایره‌ای اختصاص دهد. مثال زیر یک نمودار دایره‌ای با عنوان مرکزی ایجاد می‌کند و داده‌های پیش‌فرض را با سه دسته فصلی و مقادیر آن‌ها جایگزین می‌کند. متد [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) مقادیر 20، 50 و 30 را به‌عنوان برچسب نمایش می‌دهد، در حالی که [setColorVaried](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setColorVaried) رنگ متمایزی را برای هر برش فعال می‌کند.

```python
import jpway
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # عنوان نمودار را به صورت مرکزچین اضافه کنید.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # داده‌های پیش‌فرض را با استفاده از اولین برگه جایگزین کنید.
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    # مقادیر را نمایش داده و رنگ‌های متفاوتی به برش‌ها اختصاص دهید.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getParentSeriesGroup().setColorVaried(True)

    presentation.save("pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سؤالات متداول**

**آیا انواع Pie of Pie و Bar of Pie پشتیبانی می‌شوند؟**

بله، کتابخانه [پشتیبانی می‌کند](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) یک نمودار ثانویه برای نمودارهای دایره‌ای، از جمله انواع Pie of Pie و Bar of Pie را.

**آیا می‌توانم فقط نمودار را به‌عنوان تصویر (مثلاً PNG) صادر کنم؟**

بله، می‌توانید [نمودار را به‌عنوان تصویر صادر کنید](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) (مانند PNG) را بدون صادر کردن کل ارائه.