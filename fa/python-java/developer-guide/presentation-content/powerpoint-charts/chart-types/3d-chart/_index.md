---
title: سفارشی‌سازی نمودارهای 3D در ارائه‌ها با استفاده از Python
linktitle: نمودار 3D
type: docs
url: /fa/python-java/3d-chart/
keywords:
- نمودار 3D
- چرخش
- عمق
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "نمودارهای 3D را در ارائه‌های PowerPoint با Aspose.Slides برای Python از طریق Java ایجاد کنید. چرخش، نسبت‌های ارتفاع، عمق نمودار و فاصله بین سری‌ها را با مثال‌های Python تنظیم کنید."
---
## **نمای کلی**

Aspose.Slides for Python via Java به شما اجازه می‌دهد نمای یک نمودار 3D را از طریق متد [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D) سفارشی کنید. این مقاله نشان می‌دهد چگونه چرخش، نسبت‌های ارتفاع، عمق، محورها با زاویهٔ راست و فاصله بین سری‌ها را تنظیم کنید و سپس ارائه را در قالب PPTX ذخیره کنید.

## **تنظیم چرخش و عمق یک نمودار 3D**

مثال زیر یک [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد می‌کند و با استفاده از [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) یک نمودار ستونی 3D استک‌شده را به اولین اسلاید آن اضافه می‌کند. این مثال سری‌ها و دسته‌بندی‌های پیش‌فرض را با دو سری که هر کدام شامل سه مقدار هستند جایگزین می‌کند. شاخص کاربرگ `0` کاربرگ دادهٔ اول نمودار را مشخص می‌کند؛ ردیف `0` نام‌های سری‌ها را دارد و ستون `0` برچسب‌های دسته‌بندی را دارد.

متدهای [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) و [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) به ترتیب چرخش نمودار را به 40 و 270 درجه تنظیم می‌کنند. متد [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) عمق آن را به 150٪ از عرض تنظیم می‌کند، در حالی که [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) محورها را به جای پرسپکتیو، با زاویهٔ راست فعال می‌سازد. ارائهٔ حاصل شامل نمودار پر شده با این تنظیمات نمای 3D است.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم نسبت‌های ارتفاع یک نمودار 3D**

از [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) برای تنظیم ارتفاع یک نمودار 3D به عنوان درصدی از عرض آن استفاده کنید. این کار نسبت‌های صحنهٔ 3D را بدون تغییر اندازهٔ شیء نمودار در اسلاید تغییر می‌دهد.

مثال زیر یک نمودار [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) با دادهٔ پیش‌فرض ایجاد می‌کند: سه سری و چهار دسته‌بندی. این مثال سه ارائه با نسبت‌های ارتفاع 50٪، 100٪ و 200٪ ذخیره می‌کند. موقعیت، عرض و ارتفاع نمودار ثابت می‌مانند. داده‌ها، چرخش، عمق، فاصلهٔ سری‌ها و فرمت‌بندی در همهٔ سه فایل یکسان هستند؛ فقط درصد ارتفاع تغییر می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

تصاویر زیر تنظیمات ارتفاع مشابه را در مثال .NET معادل نشان می‌دهند و با استفاده از Microsoft PowerPoint استخراج شده‌اند. درصد کمتر صحنه‌ای صاف‌تر و درصد بیشتر صحنه‌ای بلندتر در همان شیء نمودار تولید می‌کند. PowerPoint ممکن است فاصلهٔ تیک‌های محور و مکان برچسب‌ها را نیز برای سازگاری با صحنه تنظیم کند.

| ارتفاع: 50% | ارتفاع: 100% | ارتفاع: 200% |
| --- | --- | --- |
| ![3D column chart with height set to 50 percent of its width](height_percent_50.png) | ![3D column chart with height set to 100 percent of its width](height_percent_100.png) | ![3D column chart with height set to 200 percent of its width](height_percent_200.png) |

این متدها جنبه‌های مختلفی از نمودار را کنترل می‌کنند:

| متد | اثر |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | ارتفاع صحنهٔ 3D به عنوان درصدی از عرض آن. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | ارتفاع شیء نمودار در اسلاید، به پویینت. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | عمق صحنهٔ 3D به عنوان درصدی از عرض آن. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | فاصله بین سری‌ها در محور عمق، به عنوان درصدی از عرض علامت‌گذار. |

تنظیم ارتفاع بر نمودارهای ستونی و میله‌ای 3D شامل انواع سیلندری، مخروطی و هرمی، همچنین نمودارهای خطی، مساحی، کیک و سطح 3D اثر می‌گذارد. مقایسهٔ بالا از نوع تأیید شدهٔ `Column3D` استفاده می‌کند. این تنظیم ظاهر نمودارهای 2D مانند `ClusteredColumn` یا `BubbleWith3D` را تغییر نمی‌دهد؛ این نام‌ها اعضای کلاس [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) هستند. برای تنظیمات دیگر ظاهر نمودار، به [Chart Formatting](/slides/fa/python-java/chart-formatting/) مراجعه کنید.

## **تنظیم فاصله بین سری‌ها**

از [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) برای کنترل فاصله بین داده‌های سری‌ها در طول محور عمق یک نمودار 3D استفاده کنید؛ این مقدار به صورت درصدی از عرض علامت‌گذار بیان می‌شود. مقادیر از **0 تا 500** مجاز هستند: `0` فاصله را حذف می‌کند، در حالی که مقادیر بزرگتر فضای بین سری‌ها را افزایش می‌دهند. با عمق ثابت نمودار، افزایش فاصله باعث نازک‌تر شدن علامت‌گذارها در محور عمق می‌شود.

دسترسی به گروه از طریق [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) انجام می‌شود. این تنظیم بر تمام سری‌های موجود در آن گروه اعمال می‌شود، نه فقط سری‌ای که برای دسترسی استفاده شده است. متد [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) مقدار فاصله عمق را برمی‌گرداند و تنظیمات گروه والد را منعکس می‌کند.

این تنظیم بر نمودارهای ستونی و میله‌ای 3D شامل انواع سیلندری، مخروطی و هرمی، همچنین نمودارهای خطی و مساحی 3D اثر می‌گذارد. ظاهر این نمودارها به این بستگی دارد که سری‌ها در عمق، به‌صورت خوشه‌ای یا استک‌شده چیدمان داشته باشند. برای مقایسهٔ واضح فاصله‌ها بین سری‌های جداگانه، از `ChartType.Column3D` در کلاس [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) استفاده کنید.

این متدها جنبه‌های مختلفی از نمودار را کنترل می‌کنند:

| متد | اثر |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | فاصله بین سری‌ها در محور عمق، به عنوان درصدی از عرض علامت‌گذار. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | فاصله بین خوشه‌های میله یا ستون مجاور، به عنوان درصدی از عرض میله یا ستون. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | عمق کلی نمودار، به عنوان درصدی از عرض نمودار. |

مثال زیر به‌صورت خودکفا از داده‌های پیش‌فرض نمودار استفاده می‌کند که شامل سه سری و چهار دسته‌بندی است. این مثال دو ارائه با داده، چرخش، عرض فاصله و عمق نمودار یکسان ذخیره می‌کند؛ فقط عمق فاصله تغییر می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

تصاویر زیر تنظیمات عمق فاصلهٔ مشابه را در مثال .NET معادل نشان می‌دهند و با استفاده از Microsoft PowerPoint استخراج شده‌اند.

| عمق فاصله: 0% | عمق فاصله: 500% |
| --- | --- |
| ![3D column chart with no gap between series along the depth axis](gap_depth_0.png) | ![3D column chart with a 500 percent gap between series along the depth axis](gap_depth_500.png) |

## **تغییر نوع سری 3D و شکل میله**

در یک نمودار سیلندری خوشه‌ای، سری اول با شکل میلهٔ سیلندری آغاز می‌شود. مثال مقدارهای عددی برگردانده شده توسط [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) و [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) را قبل و بعد از هر تغییر چاپ می‌کند. جدول نام ثابت‌های متناظر را نشان می‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| تغییر به سری اول | نوع سری | شکل میله |
| --- | --- | --- |
| ایجاد نمودار | `ClusteredCylinder` | `Cylinder` |
| تنظیم نوع سری به `ClusteredCone` | `ClusteredCone` | `Cone` |
| تنظیم شکل میله به `Box` | `ClusteredColumn3D` | `Box` |

تنظیم شکل به `Box` همچنین نوع سری را به `ClusteredColumn3D` تغییر می‌دهد. اگر کد شما بر پایهٔ نوع سری تصمیم می‌گیرد، پس از تغییر شکل، `series.getType()` را فراخوانی کنید. مقدار کشیده‌شده قبل از انتساب هنوز شاخهٔ `ClusteredCone` را انتخاب می‌کند.

![PowerPoint comparison showing the first series as cylinders, cones, and rectangular columns from left to right](series-shapes.png)

## **سوالات متداول**

**کدام انواع نمودارها حالت 3D را در Aspose.Slides پشتیبانی می‌کنند؟**

Aspose.Slides انواع 3D نمودارهای ستونی را پشتیبانی می‌کند، از جمله Column 3D، Clustered Column 3D، Stacked Column 3D و 100% Stacked Column 3D، به همراه انواع 3D مرتبط که از طریق کلاس [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) در دسترس هستند. برای دریافت فهرست دقیق و به‌روز، اعضای [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) را در مرجع API نسخهٔ نصب شدهٔ خود بررسی کنید.

**آیا می‌توانم تصویر رستر شدهٔ یک نمودار 3D برای گزارش یا وب دریافت کنم؟**

بله. می‌توانید نمودار را با استفاده از [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) به تصویر خروجی بگیرید یا کل اسلاید را با [render the entire slide](/slides/fa/python-java/convert-powerpoint-to-png/) به فرمت‌هایی مانند PNG یا JPEG تبدیل کنید. این کار زمانی مفید است که به پیش‌نمایش رستر شده نیاز داشته باشید یا بخواهید نمودار را بدون نیاز به PowerPoint در اسناد، داشبوردها یا صفحات وب جاسازی کنید.

**کارایی ساخت و رندر نمودارهای بزرگ 3D چقدر است؟**

کارایی به حجم داده و پیچیدگی بصری وابسته است. برای بهترین نتایج، اثرات 3D را به حداقل برسانید، از بافت‌های سنگین روی دیوارها و نواحی نمودار خودداری کنید، تعداد نقاط داده در هر سری را تا حد امکان محدود کنید و به خروجی با رزولوشن و ابعاد مناسب برای نمایش یا چاپ هدف رندر کنید.